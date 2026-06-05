using BAMS.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BAMS.UserControls
{
    public partial class UserManagementUC : UserControl
    {
        public UserManagementUC()
        {
            InitializeComponent();
        }

        private void btnRegisterFingerprint_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow == null)
            {
                MessageBox.Show("Please select a user.");
                return;
            }

            int employeeId = Convert.ToInt32(
                dataGridView1.CurrentRow.Cells["EmployeeID"].Value
            );

            FingerprintRegistrationForm form = new FingerprintRegistrationForm(employeeId);
            form.ShowDialog();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
