using System;
using System.Data;
using Microsoft.Data.SqlClient;
using System.Windows.Forms;

namespace BAMS.UserControls
{
    public partial class DashboardUC : UserControl
    {
        private readonly string connectionString =
        "Server=Your_SERVER;Database=Your_DATABASE;User Id=Your_USER;Password=Your_PASSWORD;TrustServerCertificate=True;";

        public DashboardUC()
        {
            InitializeComponent();
            LoadDashboard();
        }

        private void DashboardUC_Load(object sender, EventArgs e)
        {
            LoadDashboard();
        }

        private void LoadDashboard()
        {
            LoadTotals();
            LoadAttendanceLog();
        }

        private void LoadTotals()
        {
            try
            {
                using SqlConnection conn = new SqlConnection(connectionString);
                conn.Open();

                DateTime today = DateTime.Today;

                SqlCommand cmdOfficial = new SqlCommand(@"
                    SELECT COUNT(DISTINCT A.EmployeeID)
                    FROM Attendance A
                    INNER JOIN Users U ON A.EmployeeID = U.EmployeeID
                    WHERE U.Position = 'Official'
                    AND CAST(A.Day AS DATE) = @Today", conn);

                cmdOfficial.Parameters.AddWithValue("@Today", today);

                object officialResult = cmdOfficial.ExecuteScalar();
                lblTotalOfficial.Text = officialResult?.ToString() ?? "0";


                SqlCommand cmdStaff = new SqlCommand(@"
                    SELECT COUNT(DISTINCT A.EmployeeID)
                    FROM Attendance A
                    INNER JOIN Users U ON A.EmployeeID = U.EmployeeID
                    WHERE U.Position = 'Staff'
                    AND CAST(A.Day AS DATE) = @Today", conn);

                cmdStaff.Parameters.AddWithValue("@Today", today);

                object staffResult = cmdStaff.ExecuteScalar();
                lbltotalStaff.Text = staffResult?.ToString() ?? "0";


                SqlCommand cmdUsers = new SqlCommand(@"
                    SELECT COUNT(DISTINCT EmployeeID)
                    FROM Attendance
                    WHERE CAST(Day AS DATE) = @Today", conn);

                cmdUsers.Parameters.AddWithValue("@Today", today);

                object usersResult = cmdUsers.ExecuteScalar();
                lblUserList.Text = usersResult?.ToString() ?? "0";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Dashboard totals error: " + ex.Message);
            }
        }

        private void LoadAttendanceLog()
        {
            try
            {
                using SqlConnection conn = new SqlConnection(connectionString);
                conn.Open();

                string query = @"
        SELECT
            A.EmployeeID,
            U.Name,
            U.Position,
            A.Day,
            A.AM_In,
            A.AM_Out,
            A.PM_In,
            A.PM_Out,
            A.TotalHours
        FROM Attendance A
        INNER JOIN Users U ON A.EmployeeID = U.EmployeeID
        WHERE CAST(A.Day AS DATE) = CAST(GETDATE() AS DATE)
        ORDER BY A.EmployeeID";

                SqlDataAdapter adapter = new SqlDataAdapter(query, conn);

                DataTable table = new DataTable();
                adapter.Fill(table);

                foreach (DataRow row in table.Rows)
                {
                    double totalHours = 0;

                    if (row["AM_In"] != DBNull.Value && row["AM_Out"] != DBNull.Value)
                    {
                        TimeSpan amIn = (TimeSpan)row["AM_In"];
                        TimeSpan amOut = (TimeSpan)row["AM_Out"];
                        totalHours += (amOut - amIn).TotalHours;
                    }

                    if (row["PM_In"] != DBNull.Value && row["PM_Out"] != DBNull.Value)
                    {
                        TimeSpan pmIn = (TimeSpan)row["PM_In"];
                        TimeSpan pmOut = (TimeSpan)row["PM_Out"];
                        totalHours += (pmOut - pmIn).TotalHours;
                    }

                    row["TotalHours"] = Math.Round(totalHours, 2);
                }


                dgvAttendance.AutoGenerateColumns = true;
                dgvAttendance.DataSource = table;

                dgvAttendance.ReadOnly = true;
                dgvAttendance.AllowUserToAddRows = false;
                dgvAttendance.AllowUserToDeleteRows = false;
                dgvAttendance.AllowUserToResizeColumns = false;
                dgvAttendance.AllowUserToResizeRows = false;
                dgvAttendance.AllowUserToOrderColumns = false;
                dgvAttendance.EditMode = DataGridViewEditMode.EditProgrammatically;

                foreach (DataGridViewColumn col in dgvAttendance.Columns)
                {
                    col.SortMode = DataGridViewColumnSortMode.NotSortable;
                }

                dgvAttendance.AutoSizeColumnsMode =
                DataGridViewAutoSizeColumnsMode.Fill;

                if (dgvAttendance.Columns.Contains("AM_In"))
                    dgvAttendance.Columns["AM_In"].DefaultCellStyle.Format = @"hh\:mm";

                if (dgvAttendance.Columns.Contains("AM_Out"))
                    dgvAttendance.Columns["AM_Out"].DefaultCellStyle.Format = @"hh\:mm";

                if (dgvAttendance.Columns.Contains("PM_In"))
                    dgvAttendance.Columns["PM_In"].DefaultCellStyle.Format = @"hh\:mm";

                if (dgvAttendance.Columns.Contains("PM_Out"))
                    dgvAttendance.Columns["PM_Out"].DefaultCellStyle.Format = @"hh\:mm";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Attendance log error: " + ex.Message);
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            LoadDashboard();
        }

        private void dgvAttendance_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
        }

        private void lbltotalStaff_Click(object sender, EventArgs e)
        {
        }

        private void lblUserList_Click(object sender, EventArgs e)
        {
        }
    }
}