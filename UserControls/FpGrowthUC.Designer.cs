namespace BAMS.UserControls
{
    partial class FpGrowthUC
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

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle4 = new DataGridViewCellStyle();
            panelHeader = new Panel();
            label1 = new Label();
            panelFilters = new Panel();
            txtSearchName = new TextBox();
            button1 = new Button();
            label3 = new Label();
            dateTimePicker2 = new DateTimePicker();
            label2 = new Label();
            dateTimePicker1 = new DateTimePicker();
            panel2 = new Panel();
            dgvItems = new DataGridView();
            colItem = new DataGridViewTextBoxColumn();
            colSupports = new DataGridViewTextBoxColumn();
            panelItems = new Panel();
            label5 = new Label();
            dgvPatterns = new DataGridView();
            colPattern = new DataGridViewTextBoxColumn();
            colSupport = new DataGridViewTextBoxColumn();
            panelPatternHeader = new Panel();
            label4 = new Label();
            panelHeader.SuspendLayout();
            panelFilters.SuspendLayout();
            panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvItems).BeginInit();
            panelItems.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvPatterns).BeginInit();
            panelPatternHeader.SuspendLayout();
            SuspendLayout();
            // 
            // panelHeader
            // 
            panelHeader.BackColor = Color.FromArgb(21, 101, 192);
            panelHeader.Controls.Add(label1);
            panelHeader.Dock = DockStyle.Top;
            panelHeader.Location = new Point(0, 0);
            panelHeader.Name = "panelHeader";
            panelHeader.Size = new Size(1283, 83);
            panelHeader.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 20.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.White;
            label1.Location = new Point(3, 21);
            label1.Name = "label1";
            label1.Size = new Size(281, 37);
            label1.TabIndex = 0;
            label1.Text = "FP - Growth Analysis";
            // 
            // panelFilters
            // 
            panelFilters.Controls.Add(txtSearchName);
            panelFilters.Controls.Add(button1);
            panelFilters.Controls.Add(label3);
            panelFilters.Controls.Add(dateTimePicker2);
            panelFilters.Controls.Add(label2);
            panelFilters.Controls.Add(dateTimePicker1);
            panelFilters.Dock = DockStyle.Top;
            panelFilters.Location = new Point(0, 83);
            panelFilters.Margin = new Padding(30, 10, 30, 10);
            panelFilters.Name = "panelFilters";
            panelFilters.Size = new Size(1283, 109);
            panelFilters.TabIndex = 1;
            // 
            // txtSearchName
            // 
            txtSearchName.BackColor = Color.White;
            txtSearchName.BorderStyle = BorderStyle.FixedSingle;
            txtSearchName.Font = new Font("Segoe UI", 10F);
            txtSearchName.Location = new Point(43, 46);
            txtSearchName.Name = "txtSearchName";
            txtSearchName.Size = new Size(378, 25);
            txtSearchName.TabIndex = 5;
            txtSearchName.Text = "Search Name";
            txtSearchName.TextChanged += txtSearchFullName_TextChanged;
            // 
            // button1
            // 
            button1.BackColor = Color.DarkBlue;
            button1.FlatStyle = FlatStyle.Popup;
            button1.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button1.ForeColor = Color.White;
            button1.Location = new Point(1119, 38);
            button1.Name = "button1";
            button1.Size = new Size(93, 39);
            button1.TabIndex = 4;
            button1.Text = "Generate";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.Location = new Point(784, 17);
            label3.Name = "label3";
            label3.Size = new Size(32, 21);
            label3.TabIndex = 3;
            label3.Text = "To:";
            // 
            // dateTimePicker2
            // 
            dateTimePicker2.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dateTimePicker2.Location = new Point(784, 45);
            dateTimePicker2.Name = "dateTimePicker2";
            dateTimePicker2.Size = new Size(284, 29);
            dateTimePicker2.TabIndex = 2;
            dateTimePicker2.ValueChanged += dateTimePicker2_ValueChanged;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.Location = new Point(463, 17);
            label2.Name = "label2";
            label2.Size = new Size(53, 21);
            label2.TabIndex = 1;
            label2.Text = "From:";
            // 
            // dateTimePicker1
            // 
            dateTimePicker1.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dateTimePicker1.Location = new Point(459, 45);
            dateTimePicker1.Name = "dateTimePicker1";
            dateTimePicker1.Size = new Size(281, 29);
            dateTimePicker1.TabIndex = 0;
            dateTimePicker1.ValueChanged += dateTimePicker1_ValueChanged;
            // 
            // panel2
            // 
            panel2.Controls.Add(dgvItems);
            panel2.Controls.Add(panelItems);
            panel2.Controls.Add(dgvPatterns);
            panel2.Controls.Add(panelPatternHeader);
            panel2.Dock = DockStyle.Top;
            panel2.Location = new Point(0, 192);
            panel2.Name = "panel2";
            panel2.Padding = new Padding(40, 20, 40, 20);
            panel2.Size = new Size(1283, 512);
            panel2.TabIndex = 3;
            // 
            // dgvItems
            // 
            dgvItems.AllowUserToAddRows = false;
            dgvItems.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvItems.BackgroundColor = Color.White;
            dgvItems.BorderStyle = BorderStyle.None;
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = Color.CornflowerBlue;
            dataGridViewCellStyle3.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            dataGridViewCellStyle3.ForeColor = Color.White;
            dataGridViewCellStyle3.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.True;
            dgvItems.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            dgvItems.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvItems.Columns.AddRange(new DataGridViewColumn[] { colItem, colSupports });
            dgvItems.Dock = DockStyle.Top;
            dgvItems.EnableHeadersVisualStyles = false;
            dgvItems.Location = new Point(40, 276);
            dgvItems.Name = "dgvItems";
            dgvItems.ReadOnly = true;
            dgvItems.RowHeadersVisible = false;
            dgvItems.Size = new Size(1203, 150);
            dgvItems.TabIndex = 3;
            dgvItems.CellContentClick += dgvItems_CellContentClick;
            // 
            // colItem
            // 
            colItem.HeaderText = "Item";
            colItem.Name = "colItem";
            colItem.ReadOnly = true;
            // 
            // colSupports
            // 
            colSupports.HeaderText = "Supports";
            colSupports.Name = "colSupports";
            colSupports.ReadOnly = true;
            // 
            // panelItems
            // 
            panelItems.BackColor = Color.RoyalBlue;
            panelItems.Controls.Add(label5);
            panelItems.Dock = DockStyle.Top;
            panelItems.Location = new Point(40, 226);
            panelItems.Name = "panelItems";
            panelItems.Size = new Size(1203, 50);
            panelItems.TabIndex = 2;
            panelItems.Paint += panelItems_Paint;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label5.ForeColor = Color.White;
            label5.Location = new Point(38, 8);
            label5.Name = "label5";
            label5.Size = new Size(161, 30);
            label5.TabIndex = 0;
            label5.Text = "Frequent Items";
            // 
            // dgvPatterns
            // 
            dgvPatterns.AllowUserToAddRows = false;
            dgvPatterns.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvPatterns.BackgroundColor = Color.White;
            dgvPatterns.BorderStyle = BorderStyle.None;
            dataGridViewCellStyle4.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = Color.CornflowerBlue;
            dataGridViewCellStyle4.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            dataGridViewCellStyle4.ForeColor = Color.White;
            dataGridViewCellStyle4.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = DataGridViewTriState.True;
            dgvPatterns.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle4;
            dgvPatterns.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvPatterns.Columns.AddRange(new DataGridViewColumn[] { colPattern, colSupport });
            dgvPatterns.Dock = DockStyle.Top;
            dgvPatterns.EnableHeadersVisualStyles = false;
            dgvPatterns.Location = new Point(40, 76);
            dgvPatterns.Name = "dgvPatterns";
            dgvPatterns.ReadOnly = true;
            dgvPatterns.RowHeadersVisible = false;
            dgvPatterns.Size = new Size(1203, 150);
            dgvPatterns.TabIndex = 1;
            // 
            // colPattern
            // 
            colPattern.HeaderText = "Pattern";
            colPattern.Name = "colPattern";
            colPattern.ReadOnly = true;
            // 
            // colSupport
            // 
            colSupport.HeaderText = "Support";
            colSupport.Name = "colSupport";
            colSupport.ReadOnly = true;
            // 
            // panelPatternHeader
            // 
            panelPatternHeader.BackColor = Color.RoyalBlue;
            panelPatternHeader.Controls.Add(label4);
            panelPatternHeader.Dock = DockStyle.Top;
            panelPatternHeader.Location = new Point(40, 20);
            panelPatternHeader.Name = "panelPatternHeader";
            panelPatternHeader.Size = new Size(1203, 56);
            panelPatternHeader.TabIndex = 0;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label4.ForeColor = Color.White;
            label4.Location = new Point(38, 11);
            label4.Name = "label4";
            label4.Size = new Size(306, 30);
            label4.TabIndex = 0;
            label4.Text = "Frequent Attendance Patterns";
            // 
            // FpGrowthUC
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoSize = true;
            BackColor = Color.White;
            Controls.Add(panel2);
            Controls.Add(panelFilters);
            Controls.Add(panelHeader);
            Name = "FpGrowthUC";
            Size = new Size(1283, 827);
            panelHeader.ResumeLayout(false);
            panelHeader.PerformLayout();
            panelFilters.ResumeLayout(false);
            panelFilters.PerformLayout();
            panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvItems).EndInit();
            panelItems.ResumeLayout(false);
            panelItems.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvPatterns).EndInit();
            panelPatternHeader.ResumeLayout(false);
            panelPatternHeader.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel panelHeader;
        private Label label1;
        private Panel panelFilters;
        private Label label2;
        private DateTimePicker dateTimePicker1;
        private Button button1;
        private Label label3;
        private DateTimePicker dateTimePicker2;
        private Panel panel2;
        private Panel panelPatternHeader;
        private DataGridView dgvPatterns;
        private DataGridViewTextBoxColumn colPattern;
        private DataGridViewTextBoxColumn colSupport;
        private Label label4;
        private Panel panelItems;
        private Label label5;
        private DataGridView dgvItems;
        private DataGridViewTextBoxColumn colItem;
        private DataGridViewTextBoxColumn colSupports;
        private TextBox txtSearchName;
    }
}
