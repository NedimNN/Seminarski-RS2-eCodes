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
        private bool dateChanged = false;

        public frmEmployeesList()
        {
            InitializeComponent();
            AddButtonColumn();
            dgvEmployeeList.AutoGenerateColumns = false;
        }

        private void AddButtonColumn()
        {
            //Delete btn
            DataGridViewButtonColumn deleteBtn = new DataGridViewButtonColumn();
            deleteBtn.HeaderText = "Delete";
            deleteBtn.Text = "Delete";
            deleteBtn.Name = "btnDelete";
            deleteBtn.UseColumnTextForButtonValue = true;
            deleteBtn.CellTemplate.Style.BackColor = Color.Red;
            deleteBtn.AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;


            dgvEmployeeList.Columns.Add(deleteBtn);
        }

        public async void loadData()
        {
            EmployeeSearchObject emp = new EmployeeSearchObject();

            emp.DateOfEmployement = dateTimeEmployment.Value;

            if (!string.IsNullOrWhiteSpace(txtEmployeeNumber.Text))
                emp.EmployeeNumber = Convert.ToInt32(txtEmployeeNumber.Text);
            else
                emp.EmployeeNumber = 0;
            if (dateChanged)
            {
                emp.DateOfEmployement = dateTimeEmployment.Value;
            }
            else
            {
                emp.DateOfEmployement = DateTime.MinValue;
            }

            emp.IncludePerson = true;

            var employees = await EmployeeService.Get<List<Models.Employees>>(emp);
            dateChanged = false;
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

        private async void dgvEmployeeList_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 8) // delete btn column
            { 
                EmployeeSearchObject search = new EmployeeSearchObject();
                int empNumber = Convert.ToInt32(dgvEmployeeList.Rows[e.RowIndex].Cells[2].Value);
                search.EmployeeNumber = empNumber;
                List<Employees> employees = await EmployeeService.Get<List<Employees>>(search);
                var employee = employees.FirstOrDefault();

                if(employee != null)
                {
                    if(DialogResult.OK == MessageBox.Show("Are you sure you want to delete this employee ?", "Delete Message", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning))
                    {
                        var deletedEmp = await EmployeeService.Delete<Employees>(employee.EmployeeId);

                        if(deletedEmp != null)
                        {
                            MessageBox.Show("You have successfully deleted the employee " + deletedEmp.Firstname + " " + deletedEmp.Lastname, "Employee Deleted Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            loadData();
                        }
                    }
                    else
                    {
                        MessageBox.Show("The operation was canceled !", "Employee Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        loadData();
                    }
                }
                else
                    MessageBox.Show("Something went wrong, try again later !", "Employee Info Message", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private async void frmEmployeesList_Load(object sender, EventArgs e)
        {
            loadData();
            dateTimeEmployment.ValueChanged += new System.EventHandler(DateTimeEmployment_ValueChanged);
        }

        private void DateTimeEmployment_ValueChanged(object? sender, EventArgs e)
        {
            dateChanged = true;
        }
    }
}
