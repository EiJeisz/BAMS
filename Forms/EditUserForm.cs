using BAMS.Repositories;
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace BAMS.Forms
{
    public partial class EditUserForm : Form
    {
        private int userId;

        public EditUserForm(int id)
        {
            InitializeComponent();

            userId = id;

            SetupComboBoxes();
            LoadUserData();
        }

        private void SetupComboBoxes()
        {
            cmbGender.Items.Clear();
            cmbGender.Items.AddRange(new object[]
            {
                "Male",
                "Female"
            });

            cmbPosition.Items.Clear();
            cmbPosition.Items.AddRange(new object[]
            {
                "Admin",
                "Staff",
                "Official"
            });

            cmbGender.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbPosition.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        private void LoadUserData()
        {
            try
            {
                UserRepository repo = new UserRepository();
                DataTable dt = repo.GetUserById(userId);

                if (dt.Rows.Count == 0)
                {
                    MessageBox.Show("User not found.");
                    this.Close();
                    return;
                }

                DataRow row = dt.Rows[0];

                txtName.Text = row["Name"].ToString();
                txtName.ForeColor = Color.Black;

                cmbGender.SelectedItem = row["Gender"].ToString();
                cmbPosition.SelectedItem = row["Position"].ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading user:\n" + ex.Message);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (txtName.Text.Trim() == "")
            {
                MessageBox.Show("Enter Name");
                return;
            }

            if (cmbGender.SelectedItem == null)
            {
                MessageBox.Show("Select Gender");
                return;
            }

            if (cmbPosition.SelectedItem == null)
            {
                MessageBox.Show("Select Position");
                return;
            }

            try
            {
                UserRepository repo = new UserRepository();

                repo.UpdateUser(
                    userId,
                    txtName.Text.Trim(),
                    cmbGender.Text,
                    cmbPosition.Text
                );

                MessageBox.Show("User updated successfully!");
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error updating user:\n" + ex.Message);
            }
        }

        private void txtName_TextChanged(object sender, EventArgs e)
        {

        }
    }
}