using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using Microsoft.Data.SqlClient;

namespace BAMS.UserControls
{
    public partial class UploadDataUC : UserControl
    {
        private string connectionString =
        "Server=Your_SERVER;Database=Your_DATABASE;User Id=Your_USER;Password=Your_PASSWORD;TrustServerCertificate=True;";

        public UploadDataUC()
        {
            InitializeComponent();

            panelDropZone.AllowDrop = true;
            panelDropZone.DragEnter += PanelDropZone_DragEnter;
            panelDropZone.DragDrop += PanelDropZone_DragDrop;
        }

        private void PanelDropZone_DragEnter(object? sender, DragEventArgs e)
        {
            if (e.Data!.GetDataPresent(DataFormats.FileDrop))
                e.Effect = DragDropEffects.Copy;
        }

        private void PanelDropZone_DragDrop(object? sender, DragEventArgs e)
        {
            if (e.Data != null && e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                string[] files = (string[])e.Data.GetData(DataFormats.FileDrop)!;

                if (files.Length > 0)
                    ProcessBiometricFile(files[0]);
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "Text/CSV Files|*.txt;*.csv";

            if (dialog.ShowDialog() == DialogResult.OK)
                ProcessBiometricFile(dialog.FileName);
        }

        private void label2_Click(object sender, EventArgs e)
        {
            pictureBox1_Click(sender, e);
        }

        private void ProcessBiometricFile(string filePath)
        {
            try
            {
                var logs = new Dictionary<string, List<TimeSpan>>();

                foreach (var line in File.ReadLines(filePath))
                {
                    var parts = line.Split(new char[] { '\t', ',', ' ' }, StringSplitOptions.RemoveEmptyEntries);

                    if (parts.Length < 3)
                        continue;

                    if (!int.TryParse(parts[0], out int employeeId))
                        continue;

                    if (!DateTime.TryParse(parts[1] + " " + parts[2], out DateTime dt))
                        continue;

                    if (!EmployeeExists(employeeId))
                        continue;

                    string key = employeeId + "_" + dt.Date.ToString("yyyy-MM-dd");

                    if (!logs.ContainsKey(key))
                        logs[key] = new List<TimeSpan>();

                    logs[key].Add(dt.TimeOfDay);
                }

                foreach (var kvp in logs)
                {
                    string[] keyParts = kvp.Key.Split('_');

                    int employeeId = int.Parse(keyParts[0]);
                    DateTime day = DateTime.Parse(keyParts[1]);

                    List<TimeSpan> times = kvp.Value
                        .OrderBy(t => t)
                        .ToList();

                    TimeSpan? AM_In = null;
                    TimeSpan? AM_Out = null;
                    TimeSpan? PM_In = null;
                    TimeSpan? PM_Out = null;

                    foreach (var time in times)
                    {
                        if (time < new TimeSpan(12, 0, 0))
                        {
                            if (AM_In == null)
                                AM_In = time;
                            else
                                AM_Out = time;
                        }
                        else
                        {
                            if (PM_In == null)
                                PM_In = time;
                            else
                                PM_Out = time;
                        }
                    }

                    if (AttendanceExists(employeeId, day))
                    {
                        UpdateAttendance(employeeId, day, AM_In, AM_Out, PM_In, PM_Out);
                    }
                    else
                    {
                        SaveAttendance(employeeId, day, AM_In, AM_Out, PM_In, PM_Out);
                    }
                }

                MessageBox.Show("Biometric logs imported successfully!");

                this.Parent?.Refresh();

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error importing file: " + ex.Message);
            }
        }

        private void UpdateAttendance(int employeeId, DateTime day,
        TimeSpan? AM_In, TimeSpan? AM_Out,
        TimeSpan? PM_In, TimeSpan? PM_Out)
        {
            TimeSpan total = TimeSpan.Zero;

            if (AM_In != null && AM_Out != null)
                total += AM_Out.Value - AM_In.Value;

            if (PM_In != null && PM_Out != null)
                total += PM_Out.Value - PM_In.Value;

            double totalHours = total.TotalHours;

            int lateMinutes = 0;
            TimeSpan expectedAMIn = new TimeSpan(8, 0, 0);

            if (AM_In != null && AM_In.Value > expectedAMIn)
                lateMinutes = (int)(AM_In.Value - expectedAMIn).TotalMinutes;

            bool absent = (AM_In == null && PM_In == null);

            double undertime = 0;
            double overtime = 0;

            if (totalHours < 8)
                undertime = 8 - totalHours;

            if (totalHours > 8)
                overtime = totalHours - 8;

            string remarks = "Present";

            if (absent)
                remarks = "Absent";
            else if (lateMinutes > 0)
                remarks = "Late";
            else if (undertime > 0)
                remarks = "Undertime";
            else if (overtime > 0)
                remarks = "Overtime";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                string query = @"UPDATE Attendance
                SET AM_In=@AM_In,
                    AM_Out=@AM_Out,
                    PM_In=@PM_In,
                    PM_Out=@PM_Out,
                    Undertime=@Undertime,
                    Overtime=@Overtime,
                    TotalHours=@TotalHours,
                    LateMinutes=@LateMinutes,
                    Absent=@Absent,
                    Remarks=@Remarks
                WHERE EmployeeID=@EmployeeID AND Day=@Day";

                SqlCommand cmd = new SqlCommand(query, conn);

                cmd.Parameters.AddWithValue("@EmployeeID", employeeId);
                cmd.Parameters.AddWithValue("@Day", day.Date);
                cmd.Parameters.AddWithValue("@AM_In", (object?)AM_In ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@AM_Out", (object?)AM_Out ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@PM_In", (object?)PM_In ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@PM_Out", (object?)PM_Out ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@Undertime", undertime);
                cmd.Parameters.AddWithValue("@Overtime", overtime);
                cmd.Parameters.AddWithValue("@TotalHours", totalHours);
                cmd.Parameters.AddWithValue("@LateMinutes", lateMinutes);
                cmd.Parameters.AddWithValue("@Absent", absent);
                cmd.Parameters.AddWithValue("@Remarks", remarks);

                cmd.ExecuteNonQuery();
            }
        }

        private bool EmployeeExists(int employeeId)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                string query = "SELECT COUNT(*) FROM Users WHERE EmployeeID=@EmployeeID";

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@EmployeeID", employeeId);

                int count = (int)cmd.ExecuteScalar()!;

                return count > 0;
            }
        }

        private bool AttendanceExists(int employeeId, DateTime day)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                string query = "SELECT COUNT(*) FROM Attendance WHERE EmployeeID=@EmployeeID AND Day=@Day";

                SqlCommand cmd = new SqlCommand(query, conn);

                cmd.Parameters.AddWithValue("@EmployeeID", employeeId);
                cmd.Parameters.AddWithValue("@Day", day.Date);

                int count = (int)cmd.ExecuteScalar()!;

                return count > 0;
            }
        }

        private void SaveAttendance(int employeeId, DateTime day,
        TimeSpan? AM_In, TimeSpan? AM_Out,
        TimeSpan? PM_In, TimeSpan? PM_Out)
        {
            TimeSpan total = TimeSpan.Zero;

            if (AM_In != null && AM_Out != null)
                total += AM_Out.Value - AM_In.Value;

            if (PM_In != null && PM_Out != null)
                total += PM_Out.Value - PM_In.Value;

            double totalHours = total.TotalHours;

            int lateMinutes = 0;
            TimeSpan expectedAMIn = new TimeSpan(8, 0, 0);

            if (AM_In != null && AM_In.Value > expectedAMIn)
                lateMinutes = (int)(AM_In.Value - expectedAMIn).TotalMinutes;

            bool absent = (AM_In == null && PM_In == null);

            double undertime = 0;
            double overtime = 0;

            if (totalHours < 8)
                undertime = 8 - totalHours;

            if (totalHours > 8)
                overtime = totalHours - 8;

            string remarks = "Present";

            if (absent)
                remarks = "Absent";
            else if (lateMinutes > 0)
                remarks = "Late";
            else if (undertime > 0)
                remarks = "Undertime";
            else if (overtime > 0)
                remarks = "Overtime";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                string query = @"INSERT INTO Attendance
                (EmployeeID, Day, AM_In, AM_Out, PM_In, PM_Out,
                 Undertime, Overtime, TotalHours, LateMinutes, Absent, Remarks)
                VALUES
                (@EmployeeID,@Day,@AM_In,@AM_Out,@PM_In,@PM_Out,
                 @Undertime,@Overtime,@TotalHours,@LateMinutes,@Absent,@Remarks)";

                SqlCommand cmd = new SqlCommand(query, conn);

                cmd.Parameters.AddWithValue("@EmployeeID", employeeId);
                cmd.Parameters.AddWithValue("@Day", day.Date);
                cmd.Parameters.AddWithValue("@AM_In", (object?)AM_In ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@AM_Out", (object?)AM_Out ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@PM_In", (object?)PM_In ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@PM_Out", (object?)PM_Out ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@Undertime", undertime);
                cmd.Parameters.AddWithValue("@Overtime", overtime);
                cmd.Parameters.AddWithValue("@TotalHours", totalHours);
                cmd.Parameters.AddWithValue("@LateMinutes", lateMinutes);
                cmd.Parameters.AddWithValue("@Absent", absent);
                cmd.Parameters.AddWithValue("@Remarks", remarks);

                cmd.ExecuteNonQuery();
            }
        }

        private void panelTitle_Paint(object? sender, PaintEventArgs e) { }

        private void panelDropZone_Paint(object? sender, PaintEventArgs e) { }
    }
}

