using eCodes.Models;
using eCodes.Models.SearchObjects;
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
    public partial class frmEmployeesList : Form
    {
        public APIService EmployeeService { get; set; } = new APIService("Employee");

        public frmEmployeesList()
        {
            InitializeComponent();
            dgvEmployeeList.AutoGenerateColumns = false;
        }
        public async void loadData()
        {
            EmployeeSearchObject emp = new EmployeeSearchObject();

            emp.DateOfEmployement = dateTimeEmployment.Value;

            if (!string.IsNullOrWhiteSpace(txtEmployeeNumber.Text))
                emp.EmployeeNumber = Convert.ToInt32(txtEmployeeNumber.Text);
            else
                emp.EmployeeNumber = 0;

            emp.IncludePerson = true;

            var employees = await EmployeeService.Get<List<Models.Employees>>(emp);

            dgvEmployeeList.DataSource = employees;
        }

        private async void btnShowEmployees_Click(object sender, EventArgs e)
        {
            loadData();
        }

        private void dgvEmployeeList_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            var item = dgvEmployeeList.SelectedRows[0].DataBoundItem as Employees;

            frmEmployeeDetails frm = new frmEmployeeDetails(item);
            frm.ShowDialog();
        }
    }
}
