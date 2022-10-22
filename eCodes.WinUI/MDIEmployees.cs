using AutoMapper;
using eCodes.Models;
using eCodes.Models.SearchObjects;
using eCodes.Services;
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
    public partial class MDIEmployees : Form
    {
        private int childFormNumber = 0;
        public APIService EmployeeService { get; set; } = new APIService("Employee");
        public MDIEmployees()
        {
            InitializeComponent();
        }
        private void toolStripMenuShowOrders_Click(object sender, EventArgs e)
        {
            frmOrdersList childForm = new frmOrdersList();
            childForm.MdiParent = this;
            childForm.MdiParent.Size = new Size(childForm.Width + childForm.MdiParent.MainMenuStrip.Size.Width, this.Height);
            childForm.Text = "Window " + childFormNumber++;
            childForm.WindowState = FormWindowState.Maximized;
            childForm.Show();
        }

        private void toolStripShowProducts_Click(object sender, EventArgs e)
        {
            frmProductList childForm = new frmProductList();
            childForm.MdiParent = this;
            childForm.MdiParent.Size = new Size(childForm.Width + childForm.MdiParent.MainMenuStrip.Size.Width, this.Height);
            childForm.Text = "Window " + childFormNumber++;
            childForm.WindowState = FormWindowState.Maximized;
            childForm.Show();
        }

        private async void myProfileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            EmployeeSearchObject emp = new EmployeeSearchObject();
            emp.EmployeeNumber = Convert.ToInt32(APIService.username);

            var employee = await EmployeeService.Get<List<Models.Employees>>(emp);

            frmEmployeeDetails childForm = new frmEmployeeDetails(employee.FirstOrDefault());
            childForm.MdiParent = this;
            childForm.MdiParent.Size = new Size(childForm.Width + childForm.MdiParent.MainMenuStrip.Size.Width, this.Height);
            childForm.Text = "Window " + childFormNumber++;
            childForm.WindowState = FormWindowState.Maximized;
            childForm.Show();
        }

        private void searchSellersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmSellersList childForm = new frmSellersList();
            childForm.MdiParent = this;
            childForm.MdiParent.Size = new Size(childForm.Width + childForm.MdiParent.MainMenuStrip.Size.Width, this.Height);
            childForm.Text = "Window " + childFormNumber++;
            childForm.WindowState = FormWindowState.Maximized;
            childForm.Show();
        }

        private void transactionReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmGenerateReport childForm = new frmGenerateReport();
            childForm.MdiParent = this;
            childForm.MdiParent.Size = new Size(childForm.Width + childForm.MdiParent.MainMenuStrip.Size.Width, this.Height);
            childForm.Text = "Window " + childFormNumber++;
            childForm.WindowState = FormWindowState.Maximized;
            childForm.Show();
        }
    }
}
