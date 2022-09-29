using eCodes.Models;
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
    public partial class frmEmployeeDetails : Form
    {
        public APIService EmployeeService { get; set; } = new APIService("Employee");
        public APIService PersonsService { get; set; } = new APIService("Persons");


        private Employees _model = null;

        public frmEmployeeDetails(Employees model = null)
        {
            InitializeComponent();
            _model = model;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {

        }

        private async void EmployeeDetails_Load(object sender, EventArgs e)
        {
            if (_model != null)
            {
                var person = await PersonsService.GetById<Persons>(_model.PersonId);
                txtFirstName.Text = person.FirstName;
                txtLastName.Text = person.LastName;
                txtCityName.Text = person.CityName;
                txtJMBG.Text = person.Jmbg;
                txtGender.Text = person.Gender;
                dateTimeofBirth.Value = person.DateOfBirth;
                txtEmployeeNumber.Text = _model.EmployeeNumber.ToString();
                cbStatus.Checked = _model.Status;
            }
        }

        private void txtFirstName_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtFirstName.Text))
            {
                e.Cancel = true;
                txtFirstName.Focus();
                errorProviderEmployees.SetError(txtFirstName, "Firstname should not be left blank!");
            }
            else
            {
                e.Cancel = false;
                errorProviderEmployees.SetError(txtFirstName, "");
            }
        }

        private void txtLastName_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtLastName.Text))
            {
                e.Cancel = true;
                txtLastName.Focus();
                errorProviderEmployees.SetError(txtLastName, "Lastname should not be left blank!");
            }
            else
            {
                e.Cancel = false;
                errorProviderEmployees.SetError(txtLastName, "");
            }
        }

        private void txtCityName_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtCityName.Text))
            {
                e.Cancel = true;
                txtCityName.Focus();
                errorProviderEmployees.SetError(txtCityName, "City name should not be left blank!");
            }
            else
            {
                e.Cancel = false;
                errorProviderEmployees.SetError(txtCityName, "");
            }
        }

        private void txtJMBG_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtJMBG.Text))
            {
                e.Cancel = true;
                txtJMBG.Focus();
                errorProviderEmployees.SetError(txtJMBG, "JMBG should not be left blank!");
            }
            else
            {
                e.Cancel = false;
                errorProviderEmployees.SetError(txtJMBG, "");
            }
        }

        private void txtGender_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtGender.Text))
            {
                e.Cancel = true;
                txtGender.Focus();
                errorProviderEmployees.SetError(txtGender, "Gender should not be left blank!");
            }
            else
            {
                e.Cancel = false;
                errorProviderEmployees.SetError(txtGender, "");
            }
        }

        private void txtEmployeeNumber_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtEmployeeNumber.Text))
            {
                e.Cancel = true;
                txtEmployeeNumber.Focus();
                errorProviderEmployees.SetError(txtEmployeeNumber, "Employee Number should not be left blank!");
            }
            else
            {
                e.Cancel = false;
                errorProviderEmployees.SetError(txtEmployeeNumber, "");
            }
        }

        private void txtPassword_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtPassword.Text))
            {
                e.Cancel = true;
                txtPassword.Focus();
                errorProviderEmployees.SetError(txtPassword, "Password should not be left blank!");
            }
            else
            {
                e.Cancel = false;
                errorProviderEmployees.SetError(txtPassword, "");
            }
        }

        private void txtConfirmPass_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtConfirmPass.Text))
            {
                e.Cancel = true;
                txtConfirmPass.Focus();
                errorProviderEmployees.SetError(txtConfirmPass, "Password confirmation should not be left blank!");
            }
            else
            {
                e.Cancel = false;
                errorProviderEmployees.SetError(txtConfirmPass, "");
            }
        }

    }
}
