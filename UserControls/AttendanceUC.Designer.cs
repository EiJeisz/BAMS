namespace BAMS.UserControls
{
    partial class AttendanceUC
    {

        private System.ComponentModel.IContainer components = null;
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        private void InitializeComponent()
        {
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle13 = new DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AttendanceUC));
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle4 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle5 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle6 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle7 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle8 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle9 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle10 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle11 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle12 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle14 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle15 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle16 = new DataGridViewCellStyle();
            panelMain = new Panel();
            panel1 = new Panel();
            dgvAttendance = new DataGridView();
            panelfilter = new Panel();
            txtSearchName = new TextBox();
            label5 = new Label();
            pictureBox1 = new PictureBox();
            btnExportPdf = new Button();
            btnGenerateDTR = new Button();
            cmbEmployee = new ComboBox();
            label4 = new Label();
            dtTo = new DateTimePicker();
            label3 = new Label();
            dtFrom = new DateTimePicker();
            label2 = new Label();
            panelHeader = new Panel();
            label1 = new Label();
            colEmployeeId = new DataGridViewTextBoxColumn();
            colName = new DataGridViewTextBoxColumn();
            colDay = new DataGridViewTextBoxColumn();
            colAMIn = new DataGridViewTextBoxColumn();
            colAMOut = new DataGridViewTextBoxColumn();
            colPMIn = new DataGridViewTextBoxColumn();
            colPMOut = new DataGridViewTextBoxColumn();
            colOTIn = new DataGridViewTextBoxColumn();
            colOTOut = new DataGridViewTextBoxColumn();
            colLate = new DataGridViewTextBoxColumn();
            colUT = new DataGridViewTextBoxColumn();
            colOT = new DataGridViewTextBoxColumn();
            colTotalHours = new DataGridViewTextBoxColumn();
            colRemarks = new DataGridViewTextBoxColumn();
            panelMain.SuspendLayout();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvAttendance).BeginInit();
            panelfilter.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            panelHeader.SuspendLayout();
            SuspendLayout();
            // 
            // panelMain
            // 
            panelMain.Controls.Add(panel1);
            panelMain.Controls.Add(panelfilter);
            panelMain.Controls.Add(panelHeader);
            panelMain.Dock = DockStyle.Fill;
            panelMain.Location = new Point(0, 0);
            panelMain.Name = "panelMain";
            panelMain.Size = new Size(1265, 859);
            panelMain.TabIndex = 0;
            // 
            // panel1
            // 
            panel1.Controls.Add(dgvAttendance);
            panel1.Dock = DockStyle.Fill;
            panel1.Location = new Point(0, 172);
            panel1.Name = "panel1";
            panel1.Padding = new Padding(20);
            panel1.Size = new Size(1265, 687);
            panel1.TabIndex = 2;
            // 
            // dgvAttendance
            // 
            dgvAttendance.AllowUserToAddRows = false;
            dgvAttendance.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = Color.FromArgb(245, 245, 245);
            dgvAttendance.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            dgvAttendance.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvAttendance.BackgroundColor = Color.White;
            dgvAttendance.BorderStyle = BorderStyle.None;
            dgvAttendance.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = Color.FromArgb(25, 118, 210);
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            dataGridViewCellStyle2.ForeColor = Color.White;
            dataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.True;
            dgvAttendance.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            dgvAttendance.ColumnHeadersHeight = 45;
            dgvAttendance.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dgvAttendance.Columns.AddRange(new DataGridViewColumn[] { colEmployeeId, colName, colDay, colAMIn, colAMOut, colPMIn, colPMOut, colOTIn, colOTOut, colLate, colUT, colOT, colTotalHours, colRemarks });
            // ✅ IMPORTANT: CONNECT TO DATABASE
            colEmployeeId.DataPropertyName = "EmployeeID";
            colName.DataPropertyName = "Name";
            colDay.DataPropertyName = "Day";
            colAMIn.DataPropertyName = "AM_In_Display";
            colAMOut.DataPropertyName = "AM_Out_Display";
            colPMIn.DataPropertyName = "PM_In_Display";
            colPMOut.DataPropertyName = "PM_Out_Display";
            colOTIn.DataPropertyName = "OT_In";
            colOTOut.DataPropertyName = "OT_Out";
            colLate.DataPropertyName = "LateMinutes";
            colUT.DataPropertyName = "UT";
            colOT.DataPropertyName = "OT";
            colTotalHours.DataPropertyName = "TotalHoursDisplay";
            colRemarks.DataPropertyName = "Remarks";
            dataGridViewCellStyle13.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle13.BackColor = Color.White;
            dataGridViewCellStyle13.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle13.ForeColor = Color.Black;
            dataGridViewCellStyle13.SelectionBackColor = Color.FromArgb(232, 240, 254);
            dataGridViewCellStyle13.SelectionForeColor = Color.Black;
            dataGridViewCellStyle13.WrapMode = DataGridViewTriState.False;
            dgvAttendance.DefaultCellStyle = dataGridViewCellStyle13;
            dgvAttendance.Dock = DockStyle.Fill;
            dgvAttendance.EnableHeadersVisualStyles = false;
            dgvAttendance.GridColor = Color.LightGray;
            dgvAttendance.Location = new Point(20, 20);
            dgvAttendance.Name = "dgvAttendance";
            dgvAttendance.RowHeadersVisible = false;
            dgvAttendance.RowTemplate.Height = 38;
            dgvAttendance.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvAttendance.Size = new Size(1225, 647);
            dgvAttendance.TabIndex = 0;
            dgvAttendance.CellContentClick += dgvAttendance_CellContentClick;
            // 
            // panelfilter
            // 
            panelfilter.BackColor = Color.FromArgb(250, 250, 250);
            panelfilter.Controls.Add(txtSearchName);
            panelfilter.Controls.Add(label5);
            panelfilter.Controls.Add(pictureBox1);
            panelfilter.Controls.Add(btnGenerateDTR);
            panelfilter.Controls.Add(btnExportPdf); 
            panelfilter.Controls.Add(cmbEmployee);
            panelfilter.Controls.Add(label4);
            panelfilter.Controls.Add(dtTo);
            panelfilter.Controls.Add(label3);
            panelfilter.Controls.Add(dtFrom);
            panelfilter.Controls.Add(label2);
            panelfilter.Dock = DockStyle.Top;
            panelfilter.Location = new Point(0, 78);
            panelfilter.Name = "panelfilter";
            panelfilter.Padding = new Padding(20);
            panelfilter.Size = new Size(1265, 94);
            panelfilter.TabIndex = 1;
            // 
            // txtSearchName
            // 
            txtSearchName.BorderStyle = BorderStyle.FixedSingle;
            txtSearchName.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtSearchName.Location = new Point(32, 52);
            txtSearchName.Name = "txtSearchName";
            txtSearchName.PlaceholderText = "Search name ...";
            txtSearchName.Size = new Size(399, 29);
            txtSearchName.TabIndex = 10;
            txtSearchName.TextChanged += txtSearchName_TextChanged;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label5.Location = new Point(32, 26);
            label5.Name = "label5";
            label5.Size = new Size(115, 21);
            label5.TabIndex = 9;
            label5.Text = "Search Name:";
            // 
            // pictureBox1
            // 
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(946, 46);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(31, 35);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 8;
            pictureBox1.TabStop = false;
            // 
            // btnExportPdf
            // 
            btnExportPdf.BackColor = Color.FromArgb(211, 47, 47);
            btnExportPdf.Cursor = Cursors.Hand;
            btnExportPdf.FlatAppearance.BorderSize = 0;
            btnExportPdf.FlatStyle = FlatStyle.Flat;
            btnExportPdf.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnExportPdf.ForeColor = Color.White;
            btnExportPdf.Location = new Point(946, 46);
            btnExportPdf.Name = "btnExportPdf";
            btnExportPdf.Size = new Size(155, 35);
            btnExportPdf.TabIndex = 7;
            btnExportPdf.Text = "   Export PDF";
            btnExportPdf.UseVisualStyleBackColor = false;
            btnExportPdf.Click += btnExportPdf_Click;

            //
            // btnGenerateDTR
            //
            btnGenerateDTR.BackColor = Color.SeaGreen;
            btnGenerateDTR.Cursor = Cursors.Hand;
            btnGenerateDTR.FlatAppearance.BorderSize = 0;
            btnGenerateDTR.FlatStyle = FlatStyle.Flat;
            btnGenerateDTR.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            btnGenerateDTR.ForeColor = Color.White;

            // 👉 POSITION BESIDE EXPORT
            btnGenerateDTR.Location = new Point(1110, 46);

            btnGenerateDTR.Name = "btnGenerateDTR";
            btnGenerateDTR.Size = new Size(150, 35);
            btnGenerateDTR.Text = "Generate DTR";
            btnGenerateDTR.UseVisualStyleBackColor = false;
            btnGenerateDTR.Click += btnGenerateDTR_Click;
            // 
            // cmbEmployee
            // 
            cmbEmployee.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbEmployee.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            cmbEmployee.FormattingEnabled = true;
            cmbEmployee.Location = new Point(771, 52);
            cmbEmployee.Name = "cmbEmployee";
            cmbEmployee.Size = new Size(107, 29);
            cmbEmployee.TabIndex = 5;
            cmbEmployee.SelectedIndexChanged += cmbEmployee_SelectedIndexChanged;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label4.ForeColor = Color.Black;
            label4.Location = new Point(771, 26);
            label4.Name = "label4";
            label4.Size = new Size(86, 21);
            label4.TabIndex = 4;
            label4.Text = "Employee";
            label4.Click += label4_Click;
            // 
            // dtTo
            // 
            dtTo.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dtTo.Format = DateTimePickerFormat.Short;
            dtTo.Location = new Point(617, 52);
            dtTo.Name = "dtTo";
            dtTo.Size = new Size(103, 29);
            dtTo.TabIndex = 3;
            dtTo.ValueChanged += dtTo_ValueChanged;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.ForeColor = Color.Black;
            label3.Location = new Point(617, 26);
            label3.Name = "label3";
            label3.Size = new Size(32, 21);
            label3.TabIndex = 2;
            label3.Text = "To:";
            // 
            // dtFrom
            // 
            dtFrom.CalendarFont = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dtFrom.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dtFrom.Format = DateTimePickerFormat.Short;
            dtFrom.Location = new Point(449, 52);
            dtFrom.Name = "dtFrom";
            dtFrom.Size = new Size(119, 29);
            dtFrom.TabIndex = 1;
            dtFrom.ValueChanged += dtFrom_ValueChanged;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.ForeColor = Color.Black;
            label2.Location = new Point(449, 26);
            label2.Name = "label2";
            label2.Size = new Size(53, 21);
            label2.TabIndex = 0;
            label2.Text = "From:";
            // 
            // panelHeader
            // 
            panelHeader.BackColor = Color.FromArgb(21, 101, 192);
            panelHeader.Controls.Add(label1);
            panelHeader.Dock = DockStyle.Top;
            panelHeader.Location = new Point(0, 0);
            panelHeader.Name = "panelHeader";
            panelHeader.Size = new Size(1265, 78);
            panelHeader.TabIndex = 0;
            panelHeader.Paint += panelHeader_Paint;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 20.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.White;
            label1.Location = new Point(3, 21);
            label1.Name = "label1";
            label1.Size = new Size(273, 37);
            label1.TabIndex = 0;
            label1.Text = "Attendance Records";
            // 
            // colId
            // 
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleCenter;
            colEmployeeId.DefaultCellStyle = dataGridViewCellStyle3;
            colEmployeeId.FillWeight = 87.679903F;
            colEmployeeId.HeaderText = "Employee ID";
            colEmployeeId.MinimumWidth = 100;
            colEmployeeId.Name = "colEmployeeId";
            // 
            // colFullName
            // 
            dataGridViewCellStyle4.Alignment = DataGridViewContentAlignment.MiddleLeft;
            colName.DefaultCellStyle = dataGridViewCellStyle4;
            colName.FillWeight = 120.44165F;
            colName.HeaderText = "Name";
            colName.MinimumWidth = 100;
            colName.Name = "colName";
            // 
            // colDay
            // 
            dataGridViewCellStyle5.Alignment = DataGridViewContentAlignment.MiddleCenter;
            colDay.DefaultCellStyle = dataGridViewCellStyle5;
            colDay.FillWeight = 80F;
            colDay.HeaderText = "Day";
            colDay.Name = "colDay";
            // 
            // colAMIn
            // 
            dataGridViewCellStyle6.Alignment = DataGridViewContentAlignment.MiddleCenter;
            colAMIn.DefaultCellStyle = dataGridViewCellStyle6;
            colAMIn.FillWeight = 80F;
            colAMIn.HeaderText = "AM In";
            colAMIn.Name = "colAMIn";
            // 
            // colAMOut
            // 
            dataGridViewCellStyle7.Alignment = DataGridViewContentAlignment.MiddleCenter;
            colAMOut.DefaultCellStyle = dataGridViewCellStyle7;
            colAMOut.FillWeight = 80F;
            colAMOut.HeaderText = "AM Out";
            colAMOut.Name = "colAMOut";
            // 
            // colPMIn
            // 
            dataGridViewCellStyle8.Alignment = DataGridViewContentAlignment.MiddleCenter;
            colPMIn.DefaultCellStyle = dataGridViewCellStyle8;
            colPMIn.FillWeight = 80F;
            colPMIn.HeaderText = "PM In";
            colPMIn.Name = "colPMIn";
            // 
            // colPMOut
            // 
            dataGridViewCellStyle9.Alignment = DataGridViewContentAlignment.MiddleCenter;
            colPMOut.DefaultCellStyle = dataGridViewCellStyle9;
            colPMOut.FillWeight = 80F;
            colPMOut.HeaderText = "PM Out";
            colPMOut.Name = "colPMOut";
            // colOTIn
            dataGridViewCellStyle14.Alignment = DataGridViewContentAlignment.MiddleCenter;
            colOTIn.DefaultCellStyle = dataGridViewCellStyle14;
            colOTIn.FillWeight = 80F;
            colOTIn.HeaderText = "OT In";
            colOTIn.Name = "colOTIn";
            // colOTOut
            dataGridViewCellStyle15.Alignment = DataGridViewContentAlignment.MiddleCenter;
            colOTOut.DefaultCellStyle = dataGridViewCellStyle15;
            colOTOut.FillWeight = 80F;
            colOTOut.HeaderText = "OT Out";
            colOTOut.Name = "colOTOut";
            // colLate
            dataGridViewCellStyle16.Alignment = DataGridViewContentAlignment.MiddleCenter;
            colLate.DefaultCellStyle = dataGridViewCellStyle16;
            colLate.FillWeight = 100F;
            colLate.HeaderText = "Late Minutes";
            colLate.Name = "colLate";
            // 
            // colUT
            // 
            dataGridViewCellStyle10.Alignment = DataGridViewContentAlignment.MiddleCenter;
            colUT.DefaultCellStyle = dataGridViewCellStyle10;
            colUT.FillWeight = 70F;
            colUT.HeaderText = "U/T";
            colUT.Name = "colUT";
            // 
            // colOT
            // 
            dataGridViewCellStyle11.Alignment = DataGridViewContentAlignment.MiddleCenter;
            colOT.DefaultCellStyle = dataGridViewCellStyle11;
            colOT.FillWeight = 70F;
            colOT.HeaderText = "O/T";
            colOT.Name = "colOT";
            // 
            // colTotalHours
            // 
            dataGridViewCellStyle12.Alignment = DataGridViewContentAlignment.MiddleCenter;
            colTotalHours.DefaultCellStyle = dataGridViewCellStyle12;
            colTotalHours.FillWeight = 180F;
            colTotalHours.HeaderText = "Total Hours";
            colTotalHours.Name = "colTotalHours";

            dataGridViewCellStyle13.Alignment = DataGridViewContentAlignment.MiddleCenter;
            colRemarks.DefaultCellStyle = dataGridViewCellStyle13;
            colRemarks.FillWeight = 120F;
            colRemarks.HeaderText = "Remarks";
            colRemarks.Name = "colRemarks";
            // 
            // AttendanceUC
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            Controls.Add(panelMain);
            Name = "AttendanceUC";
            Size = new Size(1265, 859);
            Load += AttendanceUC_Load;
            panelMain.ResumeLayout(false);
            panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvAttendance).EndInit();
            panelfilter.ResumeLayout(false);
            panelfilter.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            panelHeader.ResumeLayout(false);
            panelHeader.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel panelMain;
        private Panel panelHeader;
        private Label label1;
        private Panel panelfilter;
        private DateTimePicker dtFrom;
        private Label label2;
        private DateTimePicker dtTo;
        private Label label3;
        private ComboBox cmbEmployee;
        private Label label4;
        private Panel panel1;
        private DataGridView dgvAttendance;
        private Button btnExportPdf;
        private PictureBox pictureBox1;
        private TextBox txtSearchName;
        private Label label5;
        private Button btnGenerateDTR;
        private DataGridViewTextBoxColumn colEmployeeId;
        private DataGridViewTextBoxColumn colName;
        private DataGridViewTextBoxColumn colDay;
        private DataGridViewTextBoxColumn colAMIn;
        private DataGridViewTextBoxColumn colAMOut;
        private DataGridViewTextBoxColumn colPMIn;
        private DataGridViewTextBoxColumn colPMOut;
        private DataGridViewTextBoxColumn colOTIn;
        private DataGridViewTextBoxColumn colOTOut;  
        private DataGridViewTextBoxColumn colLate;
        private DataGridViewTextBoxColumn colUT;
        private DataGridViewTextBoxColumn colOT;
        private DataGridViewTextBoxColumn colTotalHours;
        private DataGridViewTextBoxColumn colRemarks;
    }
}
