using eCodes.Services.HelperMethods;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;



namespace eCodes.WinUI
{
    public partial class frmLogin : Form
    {
        private readonly UsersAPIService _api = new UsersAPIService("User");
        public frmLogin()
        {
            InitializeComponent();
        }

        private async void btnLogin_Click(object sender, EventArgs e)
        {
            APIService.username = txtUsername.Text;
            APIService.password = txtPassword.Text;
            if (ValidateChildren()) { 
                try
                {
                    var user = await _api.Get<dynamic>();
                    APIService.accountType = await _api.GetAccType(APIService.username);

                    if(APIService.accountType == "Seller" && user != null)
                    {

                        MDISellers MainForm = new MDISellers();
                        MainForm.Show();
                    }
                    else if(APIService.accountType == "Employee" && user != null)
                    {
                        MDIEmployees MainForm = new MDIEmployees();
                        MainForm.Show();
                    }
                    else if ((APIService.accountType.Contains("Administrator") || APIService.accountType.Contains("Manager")) && user != null)
                    {
                        MDIMain MainForm = new MDIMain();
                        MainForm.Show();
                    }
                    else
                    {
                        MessageBox.Show("Login failed for User: " + APIService.username + " ! This user was most likely deleted...");
                    }

                }
                catch ( Exception ex )
                {
                    MessageBox.Show("Wrong username or password!");
                }
            }

        }
        private void txtUsername_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtUsername.Text))
            {
                e.Cancel = true;
                txtUsername.Focus();
                errorProviderLogin.SetError(txtUsername, "Username should not be left blank!");
            }
            else
            {
                e.Cancel = false;
                errorProviderLogin.SetError(txtUsername, "");
            }
        }

        private void txtPassword_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtPassword.Text))
            {
                e.Cancel = true;
                txtPassword.Focus();
                errorProviderLogin.SetError(txtPassword, "Password should not be left blank!");
            }
            else
            {
                e.Cancel = false;
                errorProviderLogin.SetError(txtPassword, "");
            }
        }

        private void linkLabelRegister_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmSellerDetails frm = new frmSellerDetails();
            frm.Show();
        }
    }
}
