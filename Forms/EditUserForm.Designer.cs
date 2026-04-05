namespace BAMS.Forms
{
    partial class EditUserForm
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

        #region Windows Form Designer generated code
        private void InitializeComponent()
        {
            txtName = new TextBox();
            cmbGender = new ComboBox();
            cmbPosition = new ComboBox();
            btnSave = new Button();
            label1 = new Label();
            SuspendLayout();
            // 
            // txtName
            // 
            txtName.Font = new Font("Segoe UI", 12F);
            txtName.Location = new Point(139, 154);
            txtName.Name = "txtName";
            txtName.Size = new Size(293, 29);
            txtName.TabIndex = 0;
            txtName.Text = "Name";
            txtName.TextChanged += txtName_TextChanged;
            // 
            // cmbGender
            // 
            cmbGender.Font = new Font("Segoe UI", 12F);
            cmbGender.FormattingEnabled = true;
            cmbGender.Location = new Point(139, 194);
            cmbGender.Name = "cmbGender";
            cmbGender.Size = new Size(293, 29);
            cmbGender.TabIndex = 1;
            cmbGender.Text = "Gender";
            // 
            // cmbPosition
            // 
            cmbPosition.Font = new Font("Segoe UI", 12F);
            cmbPosition.FormattingEnabled = true;
            cmbPosition.Location = new Point(139, 234);
            cmbPosition.Name = "cmbPosition";
            cmbPosition.Size = new Size(293, 29);
            cmbPosition.TabIndex = 2;
            cmbPosition.Text = "Position";
            // 
            // btnSave
            // 
            btnSave.BackColor = Color.RoyalBlue;
            btnSave.FlatStyle = FlatStyle.Popup;
            btnSave.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnSave.ForeColor = Color.White;
            btnSave.Location = new Point(222, 291);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(116, 33);
            btnSave.TabIndex = 5;
            btnSave.Text = "Save";
            btnSave.UseVisualStyleBackColor = false;
            btnSave.Click += btnSave_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 20.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.White;
            label1.Location = new Point(222, 81);
            label1.Name = "label1";
            label1.Size = new Size(150, 37);
            label1.TabIndex = 6;
            label1.Text = "EDIT USER";
            // 
            // EditUserForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.DeepSkyBlue;
            ClientSize = new Size(588, 450);
            Controls.Add(label1);
            Controls.Add(btnSave);
            Controls.Add(cmbPosition);
            Controls.Add(cmbGender);
            Controls.Add(txtName);
            Name = "EditUserForm";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Edit User";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtName;
        private ComboBox cmbGender;
        private ComboBox cmbPosition;
        private Button btnSave;
        private Label label1;
    }
}