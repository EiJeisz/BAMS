namespace BAMS.UserControls
{
    partial class UserManagementUC
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
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
            btnRegisterFingerprint = new Button();
            dataGridView1 = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // btnRegisterFingerprint
            // 
            btnRegisterFingerprint.BackColor = Color.Green;
            btnRegisterFingerprint.ForeColor = Color.White;
            btnRegisterFingerprint.Location = new Point(152, 234);
            btnRegisterFingerprint.Name = "btnRegisterFingerprint";
            btnRegisterFingerprint.Size = new Size(180, 35);
            btnRegisterFingerprint.TabIndex = 0;
            btnRegisterFingerprint.Text = "Register Fingerprint";
            btnRegisterFingerprint.UseVisualStyleBackColor = false;
            btnRegisterFingerprint.Click += btnRegisterFingerprint_Click;
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(115, 68);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.Size = new Size(240, 150);
            dataGridView1.TabIndex = 1;
            dataGridView1.CellContentClick += dataGridView1_CellContentClick;
            // 
            // UserManagementUC
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(dataGridView1);
            Controls.Add(btnRegisterFingerprint);
            Name = "UserManagementUC";
            Size = new Size(518, 355);
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Button btnRegisterFingerprint;
        private DataGridView dataGridView1;
    }
}
