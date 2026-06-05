using QuestPDF.Fluent;
using QuestPDF.Helpers;
using QuestPDF.Infrastructure;
using System;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using PdfColor = QuestPDF.Helpers.Colors;
using System.Collections.Generic;

namespace BAMS.UserControls
{
    public partial class AttendanceUC : UserControl
    {
        private readonly string connectionString =
        "Server=Your_SERVER;Database=Your_DATABASE;User Id=Your_USER;Password=Your_PASSWORD;TrustServerCertificate=True;";

        public AttendanceUC()
        {
            InitializeComponent();

            dgvAttendance.AutoGenerateColumns = false;

            dgvAttendance.ReadOnly = true;
            dgvAttendance.AllowUserToAddRows = false;
            dgvAttendance.AllowUserToDeleteRows = false;
            dgvAttendance.AllowUserToResizeRows = false;
            dgvAttendance.AllowUserToResizeColumns = false;
            dgvAttendance.AllowUserToOrderColumns = false;
            dgvAttendance.EditMode = DataGridViewEditMode.EditProgrammatically;

            dtFrom.Value = DateTime.Today.AddMonths(-1);
            dtTo.Value = DateTime.Today;

            InitializeEmployeeCombo();
            LoadAttendance();
        }

        private void InitializeEmployeeCombo()
        {
            cmbEmployee.Items.Clear();
            cmbEmployee.Items.Add("All");
            cmbEmployee.SelectedIndex = 0;
        }

        private void LoadAttendance()
        {
            try
            {
                using (var conn = new Microsoft.Data.SqlClient.SqlConnection(connectionString))
                {
                    conn.Open();

                    string name = txtSearchName.Text?.Trim() ?? "";

                    string query = @"
                    SELECT 
                        A.EmployeeID,
                        U.Name,
                        A.Day,
                        A.AM_In,
                        A.AM_Out,
                        A.PM_In,
                        A.PM_Out
                    FROM Attendance A
                    INNER JOIN Users U ON A.EmployeeID = U.EmployeeID
                    WHERE 
                        (@Name = '' OR U.Name LIKE '%' + @Name + '%')
                        AND (@Employee = 'All' OR U.Name = @Employee)
                        AND A.Day BETWEEN @From AND @To
                    ORDER BY A.EmployeeID, A.Day";

                    var cmd = new Microsoft.Data.SqlClient.SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@From", dtFrom.Value.Date);
                    cmd.Parameters.AddWithValue("@To", dtTo.Value.Date);
                    cmd.Parameters.AddWithValue("@Name", name);
                    cmd.Parameters.AddWithValue("@Employee", cmbEmployee.Text);

                    var adapter = new Microsoft.Data.SqlClient.SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);

                    dt.Columns.Add("OT_In", typeof(string));
                    dt.Columns.Add("OT_Out", typeof(string));
                    dt.Columns.Add("LateMinutes", typeof(int));
                    dt.Columns.Add("UT", typeof(int));
                    dt.Columns.Add("OT", typeof(int));
                    dt.Columns.Add("TotalHoursDisplay", typeof(string));
                    dt.Columns.Add("Remarks", typeof(string));

                    foreach (DataRow row in dt.Rows)
                    {
                        TimeSpan? AM_In = row["AM_In"] == DBNull.Value ? null : (TimeSpan?)row["AM_In"];
                        TimeSpan? AM_Out = row["AM_Out"] == DBNull.Value ? null : (TimeSpan?)row["AM_Out"];
                        TimeSpan? PM_In = row["PM_In"] == DBNull.Value ? null : (TimeSpan?)row["PM_In"];
                        TimeSpan? PM_Out = row["PM_Out"] == DBNull.Value ? null : (TimeSpan?)row["PM_Out"];

                        if (!dt.Columns.Contains("AM_In_Display"))
                            dt.Columns.Add("AM_In_Display", typeof(string));

                        if (!dt.Columns.Contains("AM_Out_Display"))
                            dt.Columns.Add("AM_Out_Display", typeof(string));

                        if (!dt.Columns.Contains("PM_In_Display"))
                            dt.Columns.Add("PM_In_Display", typeof(string));

                        if (!dt.Columns.Contains("PM_Out_Display"))
                            dt.Columns.Add("PM_Out_Display", typeof(string));

                        TimeSpan officialAM = new TimeSpan(8, 0, 0);
                        TimeSpan lateLimitAM = new TimeSpan(8, 10, 0);
                        TimeSpan officialPM = new TimeSpan(13, 0, 0);
                        TimeSpan lateLimitPM = new TimeSpan(13, 10, 0);
                        TimeSpan officialOut = new TimeSpan(17, 0, 0);

                        int late = 0, ut = 0, ot = 0;
                        string OT_In = "", OT_Out = "";

                        if (AM_In != null && AM_In > lateLimitAM)
                            late += (int)(AM_In.Value - officialAM).TotalMinutes;

                        if (PM_In != null && PM_In > lateLimitPM)
                            late += (int)(PM_In.Value - officialPM).TotalMinutes;

                        if (PM_Out != null && PM_Out < officialOut)
                            ut = (int)(officialOut - PM_Out.Value).TotalMinutes;

                        if (PM_Out != null && PM_Out > officialOut)
                        {
                            OT_In = DateTime.Today.Add(officialOut).ToString("hh:mm tt");
                            OT_Out = DateTime.Today.Add(PM_Out.Value).ToString("hh:mm tt");
                            ot = (int)(PM_Out.Value - officialOut).TotalMinutes;
                        }

                        double total = 0;
                        if (AM_In != null && AM_Out != null)
                            total += (AM_Out.Value - AM_In.Value).TotalHours;

                        if (PM_In != null && PM_Out != null)
                            total += (PM_Out.Value - PM_In.Value).TotalHours;

                        string remarks = "On Time";

                        if (AM_In == null && PM_In == null)
                            remarks = "Absent";
                        else
                        {
                            List<string> r = new List<string>();
                            if (late > 0) r.Add("Late");
                            if (ut > 0) r.Add("Undertime");
                            if (ot > 0) r.Add("Overtime");

                            if (r.Count > 0)
                                remarks = string.Join(", ", r);
                        }

                        row["AM_In_Display"] = AM_In.HasValue ? DateTime.Today.Add(AM_In.Value).ToString("hh:mm tt") : "";
                        row["AM_Out_Display"] = AM_Out.HasValue ? DateTime.Today.Add(AM_Out.Value).ToString("hh:mm tt") : "";
                        row["PM_In_Display"] = PM_In.HasValue ? DateTime.Today.Add(PM_In.Value).ToString("hh:mm tt") : "";
                        row["PM_Out_Display"] = PM_Out.HasValue ? DateTime.Today.Add(PM_Out.Value).ToString("hh:mm tt") : "";
                        row["OT_In"] = OT_In;
                        row["OT_Out"] = OT_Out;
                        row["LateMinutes"] = late;
                        row["UT"] = ut;
                        row["OT"] = ot;
                        row["TotalHoursDisplay"] = Math.Round(total, 2);

                        int hours = (int)total;
                        int minutes = (int)((total - hours) * 60);

                        row["TotalHOursDisplay"] = $"{hours:D2}:{minutes:D2}";
                        row["Remarks"] = remarks;
                    }

                    dgvAttendance.DataSource = dt;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading attendance: " + ex.Message);
            }
        }

        private void txtSearchName_TextChanged(object sender, EventArgs e) => LoadAttendance();
        private void dtFrom_ValueChanged(object sender, EventArgs e) => LoadAttendance();
        private void dtTo_ValueChanged(object sender, EventArgs e) => LoadAttendance();
        private void cmbEmployee_SelectedIndexChanged(object sender, EventArgs e) => LoadAttendance();

        private void AttendanceUC_Load(object sender, EventArgs e)
        {

            dgvAttendance.ReadOnly = true;

            dgvAttendance.AllowUserToOrderColumns = false;
            dgvAttendance.AllowUserToResizeColumns = false;
            dgvAttendance.AllowUserToResizeRows = false;

            dgvAttendance.EditMode = DataGridViewEditMode.EditProgrammatically;

            foreach (DataGridViewColumn col in dgvAttendance.Columns)
            {
                col.SortMode = DataGridViewColumnSortMode.NotSortable;
                col.ReadOnly = true;
            }

            LoadAttendance();
        }

        private void btnExportPdf_Click(object sender, EventArgs e)
        {
            if (dgvAttendance.Rows.Count == 0)
            {
                MessageBox.Show("No data.");
                return;
            }

            using SaveFileDialog save = new SaveFileDialog
            {
                Filter = "PDF|*.pdf",
                FileName = "Attendance_Report.pdf"
            };

            if (save.ShowDialog() != DialogResult.OK) return;

            QuestPDF.Settings.License = LicenseType.Community;

            Document.Create(container =>
            {
                container.Page(page =>
                {
                    page.Size(PageSizes.A4.Landscape());
                    page.Margin(20);

                    page.Header().Text("Attendance Report")
                        .FontSize(18).Bold().AlignCenter();

                    page.Content().Table(table =>
                    {
                        table.ColumnsDefinition(columns =>
                        {
                            for (int i = 0; i < dgvAttendance.Columns.Count; i++)
                                columns.RelativeColumn();
                        });

                        table.Header(header =>
                        {
                            foreach (DataGridViewColumn col in dgvAttendance.Columns)
                            {
                                header.Cell().Border(1)
                                    .Background(PdfColor.Grey.Lighten2)
                                    .Text(col.HeaderText).Bold();
                            }
                        });

                        foreach (DataGridViewRow row in dgvAttendance.Rows)
                        {
                            if (row.IsNewRow) continue;

                            foreach (DataGridViewCell cell in row.Cells)
                            {
                                table.Cell().Border(1)
                                    .Text(cell.Value?.ToString() ?? "");
                            }
                        }
                    });
                });
            }).GeneratePdf(save.FileName);

            MessageBox.Show("Exported!");
        }

        private void btnGenerateDTR_Click(object sender, EventArgs e)
        {
            if (dgvAttendance.Rows.Count == 0)
            {
                MessageBox.Show("No data for DTR.");
                return;
            }

            using SaveFileDialog save = new SaveFileDialog
            {
                Filter = "PDF|*.pdf",
                FileName = "DTR.pdf"
            };

            if (save.ShowDialog() != DialogResult.OK) return;

            QuestPDF.Settings.License = LicenseType.Community;

            var firstRow = dgvAttendance.Rows[0];

            string employeeName = dgvAttendance.Rows
                .Cast<DataGridViewRow>()
                .Where(r => !r.IsNewRow)
                .Select(r => r.Cells["colName"].Value?.ToString())
                .FirstOrDefault() ?? "N/A";
            string employeeId = firstRow.Cells["colEmployeeId"].Value?.ToString() ?? "N/A";

            Document.Create(container =>
            {
                container.Page(page =>
                {
                    page.Size(PageSizes.A4);
                    page.Margin(30);

                    page.Header().Column(header =>
                    {
                        header.Item().Text("DAILY TIME RECORD")
                            .FontSize(18)
                            .Bold()
                            .AlignCenter();

                        header.Item().Text($"Employee Name: {employeeName}")
                            .FontSize(12);

                        header.Item().Text($"Employee ID: {employeeId}")
                            .FontSize(12);

                        header.Item().Text(
                            $"Period: {dtFrom.Value:MMMM dd, yyyy} - {dtTo.Value: MMMM dd, yyyy}")
                            .FontSize(12);

                        header.Item().PaddingBottom(10);
                    });

                    page.Content().Table(table =>
                    {
                        table.ColumnsDefinition(columns =>
                        {
                            columns.ConstantColumn(40);
                            columns.RelativeColumn();
                            columns.RelativeColumn();
                            columns.RelativeColumn();
                            columns.RelativeColumn();
                            columns.RelativeColumn();
                        });

                        table.Header(header =>
                        {
                            header.Cell().Border(1).AlignCenter().Text("Day").Bold();
                            header.Cell().Border(1).AlignCenter().Text("AM In").Bold();
                            header.Cell().Border(1).AlignCenter().Text("AM Out").Bold();
                            header.Cell().Border(1).AlignCenter().Text("PM In").Bold();
                            header.Cell().Border(1).AlignCenter().Text("PM Out").Bold();
                            header.Cell().Border(1).AlignCenter().Text("Total Hours").Bold();
                        });

                        foreach (DataGridViewRow row in dgvAttendance.Rows)
                        {
                            if (row.IsNewRow) continue;

                            DateTime day;
                            string dayText = DateTime.TryParse(
                                row.Cells["colDay"].Value?.ToString(), out day)
                                ? day.Day.ToString()
                                : "";

                            table.Cell().Border(1).AlignCenter().Text(dayText);
                            table.Cell().Border(1).AlignCenter().Text(row.Cells["colAMIn"].Value?.ToString() ?? "");
                            table.Cell().Border(1).AlignCenter().Text(row.Cells["colAMOut"].Value?.ToString() ?? "");
                            table.Cell().Border(1).AlignCenter().Text(row.Cells["colPMIn"].Value?.ToString() ?? "");
                            table.Cell().Border(1).AlignCenter().Text(row.Cells["colPMOut"].Value?.ToString() ?? "");
                            table.Cell().Border(1).AlignCenter().Text(row.Cells["colTotalHours"]?.Value?.ToString() ?? "");
                        }
                    });
                });
            })
            .GeneratePdf(save.FileName);

            MessageBox.Show("✔ Improved DTR Generated!");
        }

        private void dgvAttendance_CellContentClick(object sender, DataGridViewCellEventArgs e) { }
        private void panelHeader_Paint(object sender, PaintEventArgs e) { }
        private void label4_Click(object sender, EventArgs e) { }
    }
}