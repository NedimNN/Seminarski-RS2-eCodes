using eCodes.Models;
using eCodes.Models.Requests;
using Flurl.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TaskbarClock;

namespace eCodes.WinUI
{
    public partial class frmUserDetails : Form
    {
        public APIService UsersService { get; set; } = new APIService("User");
        public APIService RolesService { get; set; } = new APIService("Roles");
        public APIService PersonsService { get; set; } = new APIService("Persons");

        private Users _model = null;

        public frmUserDetails(Users model = null)
        {
            InitializeComponent();
            _model = model;
        }

        private async void btnSave_Click(object sender, EventArgs e)
        {
            if (ValidateChildren())
            {
                var rolelist = clbRoles.CheckedItems.Cast<Roles>().ToList();
                var roleIdList = rolelist.Select(x => x.RoleId).ToList();

                if (_model == null)
                {
                    UserInsertRequest insert = new UserInsertRequest
                    {
                        FirstName = txtFirstName.Text,
                        LastName = txtLastName.Text,
                        CityName = txtCityName.Text,
                        Jmbg = txtJMBG.Text,
                        Email = txtEmail.Text,
                        Gender = txtGender.Text,
                        PhoneNumber = txtPhoneNumber.Text,
                        Username = txtUsername.Text,
                        UserRolesIdList = roleIdList,
                        Password = txtPassword.Text,
                        PasswordConfirmation = txtConfirmPass.Text,
                        Status = cbStatus.Checked,
                        DateOfBirth = dateTimeofBirth.Value
                    };
                    try
                    {
                        _model = await UsersService.Post<Models.Users>(insert);

                    }
                    catch (FlurlHttpException ex)
                    {
                        var errors = await ex.GetResponseJsonAsync<Dictionary<string, string[]>>();

                        var stringBuilder = new StringBuilder();
                        foreach (var error in errors)
                        {
                            stringBuilder.AppendLine($"{error.Key}, {string.Join(",", error.Value)}");
                        }

                        MessageBox.Show(stringBuilder.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    if (_model != null)
                        MessageBox.Show("Successfully added a user", "User Message", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                else
                {
                    UserUpdateRequest update = new UserUpdateRequest()
                    {
                        FirstName = txtFirstName.Text,
                        LastName = txtLastName.Text,
                        Email = txtEmail.Text,
                        Gender = txtGender.Text,
                        PhoneNumber = txtPhoneNumber.Text,
                        Password = txtPassword.Text,
                        PasswordConfirmation = txtConfirmPass.Text,
                        UserRolesIdList = roleIdList,
                        Status = cbStatus.Checked,
                        DateOfBirth = dateTimeofBirth.Value
                    };

                    _model = await UsersService.Put<Models.Users>(_model.UserId, update);
                    if(_model != null)
                        MessageBox.Show("Successfully updated user " + _model.Username, "User Message", MessageBoxButtons.OK, MessageBoxIcon.Information);


                }
            }
        }

        private async void frmUserDetails_Load(object sender, EventArgs e)
        {
            await LoadRoles();

            if(_model != null)
            {
                var person = await PersonsService.GetById<Persons>(_model.PersonId);
                txtFirstName.Text = person.FirstName;
                txtLastName.Text = person.LastName;
                txtCityName.Text = person.CityName;
                txtJMBG.Text = person.Jmbg;
                txtGender.Text = person.Gender;
                dateTimeofBirth.Value = person.DateOfBirth;
                txtEmail.Text = _model.Email;
                txtPhoneNumber.Text = _model.PhoneNumber;
                txtUsername.Text = _model.Username;
                cbStatus.Checked = _model.Status;
            }

        }

        private async Task LoadRoles()
        {
            var roles = await RolesService.Get<List<Roles>>();
            clbRoles.DataSource = roles;
            clbRoles.DisplayMember = "Name";
        }

        private void txtFirstName_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtFirstName.Text))
            {
                e.Cancel = true;
                txtFirstName.Focus();
                errorProviderUserDetails.SetError(txtFirstName, "Firstname should not be left blank!");
            }
            else
            {
                e.Cancel = false;
                errorProviderUserDetails.SetError(txtFirstName, "");
            }
        }

        private void txtLastName_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtLastName.Text))
            {
                e.Cancel = true;
                txtLastName.Focus();
                errorProviderUserDetails.SetError(txtLastName, "Lastname should not be left blank!");
            }
            else
            {
                e.Cancel = false;
                errorProviderUserDetails.SetError(txtLastName, "");
            }
        }

        private void txtCityName_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtCityName.Text))
            {
                e.Cancel = true;
                txtCityName.Focus();
                errorProviderUserDetails.SetError(txtCityName, "City name should not be left blank!");
            }
            else
            {
                e.Cancel = false;
                errorProviderUserDetails.SetError(txtCityName, "");
            }
        }

        private void txtJMBG_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtJMBG.Text))
            {
                e.Cancel = true;
                txtJMBG.Focus();
                errorProviderUserDetails.SetError(txtJMBG, "JMBG should not be left blank!");
            }
            else
            {
                e.Cancel = false;
                errorProviderUserDetails.SetError(txtJMBG, "");
            }
        }

        private void txtGender_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtGender.Text))
            {
                e.Cancel = true;
                txtGender.Focus();
                errorProviderUserDetails.SetError(txtGender, "Gender should not be left blank!");
            }
            else
            {
                e.Cancel = false;
                errorProviderUserDetails.SetError(txtGender, "");
            }
        }

        private void txtEmail_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtEmail.Text))
            {
                e.Cancel = true;
                txtEmail.Focus();
                errorProviderUserDetails.SetError(txtEmail, "Email should not be left blank!");
            }
            else
            {
                e.Cancel = false;
                errorProviderUserDetails.SetError(txtEmail, "");
            }
        }

        private void txtPhoneNumber_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtPhoneNumber.Text))
            {
                e.Cancel = true;
                txtPhoneNumber.Focus();
                errorProviderUserDetails.SetError(txtPhoneNumber, "Phone number should not be left blank!");
            }
            else
            {
                e.Cancel = false;
                errorProviderUserDetails.SetError(txtPhoneNumber, "");
            }
        }

        private void txtUsername_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtUsername.Text))
            {
                e.Cancel = true;
                txtUsername.Focus();
                errorProviderUserDetails.SetError(txtUsername, "Username should not be left blank!");
            }
            else
            {
                e.Cancel = false;
                errorProviderUserDetails.SetError(txtUsername, "");
            }
        }

        private void txtPassword_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtPassword.Text))
            {
                e.Cancel = true;
                txtPassword.Focus();
                errorProviderUserDetails.SetError(txtPassword, "Password should not be left blank!");
            }
            else
            {
                e.Cancel = false;
                errorProviderUserDetails.SetError(txtPassword, "");
            }
        }

        private void txtConfirmPass_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtConfirmPass.Text))
            {
                e.Cancel = true;
                txtConfirmPass.Focus();
                errorProviderUserDetails.SetError(txtConfirmPass, "Password confirmation should not be left blank!");
            }
            else
            {
                e.Cancel = false;
                errorProviderUserDetails.SetError(txtConfirmPass, "");
            }
        }
    }
}
