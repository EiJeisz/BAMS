using BAMS.Repositories;
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace BAMS.Forms
{
    public partial class AddUserForm : Form
    {
        private int userId;

        public AddUserForm(int id = 0)
        {
            InitializeComponent();

            userId = id;

            SetupComboBoxes();
            SetupPlaceholders();

            if (userId != 0)
                LoadUserData();
        }

        private void SetupComboBoxes()
        {
            cmbGender.Items.Clear();
            cmbGender.Items.AddRange(new object[]
            {
                "Select Gender",
                "Male",
                "Female"
            });
            cmbGender.SelectedIndex = 0;

            cmbPosition.Items.Clear();
            cmbPosition.Items.AddRange(new object[]
            {
                "Select Position",
                "Admin",
                "Staff",
                "Official"
            });
            cmbPosition.SelectedIndex = 0;
        }

        private void SetupPlaceholders()
        {
            SetPlaceholder(txtEmployeeID, "Employee ID");
            SetPlaceholder(txtName, "Name");
        }

        private void SetPlaceholder(TextBox box, string placeholder)
        {
            box.Text = placeholder;
            box.ForeColor = Color.Gray;

            box.Enter += (s, e) =>
            {
                if (box.ForeColor == Color.Gray)
                {
                    box.Text = "";
                    box.ForeColor = Color.Black;
                }
            };

            box.Leave += (s, e) =>
            {
                if (string.IsNullOrWhiteSpace(box.Text))
                {
                    box.Text = placeholder;
                    box.ForeColor = Color.Gray;
                }
            };
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
                    return;
                }

                DataRow row = dt.Rows[0];

                txtEmployeeID.Text = row["EmployeeID"]?.ToString() ?? "";
                txtEmployeeID.ForeColor = Color.Black;

                txtName.Text = row["Name"]?.ToString() ?? "";
                txtName.ForeColor = Color.Black;

                string gender = row["Gender"]?.ToString() ?? "Select Gender";
                string position = row["Position"]?.ToString() ?? "Select Position";

                cmbGender.SelectedIndex = cmbGender.Items.Contains(gender)
                    ? cmbGender.Items.IndexOf(gender)
                    : 0;

                cmbPosition.SelectedIndex = cmbPosition.Items.Contains(position)
                    ? cmbPosition.Items.IndexOf(position)
                    : 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading user:\n" + ex.Message);
            }
        }

        private bool ValidateForm()
        {
            if (txtEmployeeID.ForeColor == Color.Gray || string.IsNullOrWhiteSpace(txtEmployeeID.Text))
            {
                MessageBox.Show("Enter Employee ID");
                return false;
            }

            if (txtName.ForeColor == Color.Gray || string.IsNullOrWhiteSpace(txtName.Text))
            {
                MessageBox.Show("Enter Name");
                return false;
            }

            if (cmbGender.SelectedIndex == 0)
            {
                MessageBox.Show("Please select a Gender");
                return false;
            }

            if (cmbPosition.SelectedIndex == 0)
            {
                MessageBox.Show("Please select a Position");
                return false;
            }

            return true;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!ValidateForm())
                return;

            if (!int.TryParse(txtEmployeeID.Text, out int employeeId))
            {
                MessageBox.Show("Employee ID must be a number.");
                return;
            }

            try
            {
                UserRepository repo = new UserRepository();

                string name = (txtName.Text ?? "").Trim();

                if (userId == 0)
                {
                    repo.AddUser(employeeId, name, cmbGender.Text, cmbPosition.Text);
                    MessageBox.Show("User added successfully!");
                }
                else
                {
                    repo.UpdateUser(employeeId, name, cmbGender.Text, cmbPosition.Text);
                    MessageBox.Show("User updated successfully!");
                }

                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error saving user:\n" + ex.Message);
            }
        }

        private void btnCancel2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtName_TextChanged(object sender, EventArgs e) { }
        private void txtEmployeeID_TextChanged(object sender, EventArgs e) { }
        private void cmbGender_SelectedIndexChanged(object sender, EventArgs e) { }
        private void cmbPosition_SelectedIndexChanged(object sender, EventArgs e) { }
    }
}