using eCodes.Models;
using eCodes.Models.Requests;
using eCodes.Services.Database;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace eCodes.WinUI
{
    public partial class frmSellerDetails : Form
    {
        public APIService SellersService { get; set; } = new APIService("Sellers");
        public APIService PersonsService { get; set; } = new APIService("Persons");


        private Sellers _model = null;
        public frmSellerDetails(Sellers model = null)
        {
            InitializeComponent();
            _model = model;
        }

        private async void btnSaveSeller_Click(object sender, EventArgs e)
        {
            if (ValidateChildren())
            {
                if (_model == null)
                {
                    SellerInsertRequest insert = new SellerInsertRequest
                    {
                        FirstName = txtFirstname.Text,
                        LastName = txtLastname.Text,
                        CityName = txtCityname.Text,
                        Jmbg = txtJMBG.Text,
                        Email = txtEmail.Text,
                        Gender = txtGender.Text,
                        Address = txtAddress.Text,
                        Name = txtName.Text,
                        PhoneNumber = txtPhoneNumber.Text,
                        Website = txtWebsite.Text,
                        Status = true,
                        DateOfBirth = dateTimeBirth.Value,
                        Password = txtPassword.Text,
                        PasswordConfirmation = txtConfirmPass.Text,
                        PayPalEmail = txtPayPalEmail.Text,                        
                    };

                    var seller = await SellersService.Post<Models.Sellers>(insert);
                    if (seller != null)
                        MessageBox.Show("Successfully registered your account", "Seller Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    SellerUpdateRequest update = new SellerUpdateRequest
                    {
                        FirstName = txtFirstname.Text,
                        LastName = txtLastname.Text,
                        Email = txtEmail.Text,
                        Gender = txtGender.Text,
                        Address = txtAddress.Text,
                        PhoneNumber = txtPhoneNumber.Text,
                        Website = txtWebsite.Text,
                        Status = true,
                        DateOfBirth = dateTimeBirth.Value,
                        Password = txtPassword.Text,
                        PasswordConfirmation = txtConfirmPass.Text,
                        PayPalEmail = txtPayPalEmail.Text,
                    };
                    _model = await SellersService.Put<Models.Sellers>(_model.SellerId, update);
                    if (_model != null)
                        MessageBox.Show("Your account was updated successfully!", "Seller Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }

        }
        private async void frmSellerDetails_Load(object sender, EventArgs e)
        {
            if (_model != null)
            {
                var person = await PersonsService.GetById<Persons>(_model.PersonId);
                txtFirstname.Text = person.FirstName;
                txtLastname.Text = person.LastName;
                txtCityname.Text = person.CityName;
                txtJMBG.Text = person.Jmbg;
                txtGender.Text = person.Gender;
                dateTimeBirth.Value = person.DateOfBirth;
                txtEmail.Text = _model.Email;
                txtPhoneNumber.Text = _model.PhoneNumber;
                txtName.Text = _model.Name;
                txtWebsite.Text = _model.Website;
                txtAddress.Text = _model.Address;
                txtPayPalEmail.Text = _model.PayPalEmail;
            }
        }
        private void txtFirstname_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtFirstname.Text))
            {
                e.Cancel = true;
                txtFirstname.Focus();
                errorProviderSellers.SetError(txtFirstname, "Firstname should not be left blank!");
            }
            else
            {
                e.Cancel = false;
                errorProviderSellers.SetError(txtFirstname, "");
            }
        }

        private void txtLastname_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtLastname.Text))
            {
                e.Cancel = true;
                txtLastname.Focus();
                errorProviderSellers.SetError(txtLastname, "Lastname should not be left blank!");
            }
            else
            {
                e.Cancel = false;
                errorProviderSellers.SetError(txtLastname, "");
            }
        }

        private void txtCityname_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtCityname.Text))
            {
                e.Cancel = true;
                txtCityname.Focus();
                errorProviderSellers.SetError(txtCityname, "City name should not be left blank!");
            }
            else
            {
                e.Cancel = false;
                errorProviderSellers.SetError(txtCityname, "");
            }
        }
        private void txtJMBG_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtJMBG.Text))
            {
                e.Cancel = true;
                txtJMBG.Focus();
                errorProviderSellers.SetError(txtJMBG, "JMBG should not be left blank!");
            }
            else
            {
                e.Cancel = false;
                errorProviderSellers.SetError(txtJMBG, "");
            }
        }

        private void txtGender_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtGender.Text))
            {
                e.Cancel = true;
                txtGender.Focus();
                errorProviderSellers.SetError(txtGender, "Gender should not be left blank!");
            }
            else
            {
                e.Cancel = false;
                errorProviderSellers.SetError(txtGender, "");
            }
        }

        private void txtName_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtName.Text))
            {
                e.Cancel = true;
                txtName.Focus();
                errorProviderSellers.SetError(txtName, "Name should not be left blank!");
            }
            else
            {
                e.Cancel = false;
                errorProviderSellers.SetError(txtName, "");
            }
        }

        private void txtAddress_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtAddress.Text))
            {
                e.Cancel = true;
                txtAddress.Focus();
                errorProviderSellers.SetError(txtAddress, "Address should not be left blank!");
            }
            else
            {
                e.Cancel = false;
                errorProviderSellers.SetError(txtAddress, "");
            }
        }

        private void txtPhoneNumber_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtPhoneNumber.Text))
            {
                e.Cancel = true;
                txtPhoneNumber.Focus();
                errorProviderSellers.SetError(txtPhoneNumber, "Phone number should not be left blank!");
            }
            else
            {
                e.Cancel = false;
                errorProviderSellers.SetError(txtPhoneNumber, "");
            }
        }

        private void txtEmail_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtEmail.Text))
            {
                e.Cancel = true;
                txtEmail.Focus();
                errorProviderSellers.SetError(txtEmail, "Email should not be left blank!");
            }
            else
            {
                e.Cancel = false;
                errorProviderSellers.SetError(txtEmail, "");
            }
        }

        private void txtPassword_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtPassword.Text))
            {
                e.Cancel = true;
                txtPassword.Focus();
                errorProviderSellers.SetError(txtPassword, "Password should not be left blank!");
            }
            else
            {
                e.Cancel = false;
                errorProviderSellers.SetError(txtPassword, "");
            }
        }

        private void txtConfirmPass_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtConfirmPass.Text))
            {
                e.Cancel = true;
                txtConfirmPass.Focus();
                errorProviderSellers.SetError(txtConfirmPass, "Password should not be left blank!");
            }
            else
            {
                e.Cancel = false;
                errorProviderSellers.SetError(txtConfirmPass, "");
            }
        }
    }
}
