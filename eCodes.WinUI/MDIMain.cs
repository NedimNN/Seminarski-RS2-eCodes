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
    public partial class MDIMain : Form
    {
        private int childFormNumber = 0;

        public MDIMain()
        {
            InitializeComponent();
        }

        private void searchUsersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmUsers childForm = new frmUsers();
            childForm.MdiParent = this;
            childForm.MdiParent.Size = new Size(childForm.Width + childForm.MdiParent.MainMenuStrip.Size.Width, this.Height);
            childForm.Text = "Window " + childFormNumber++;
            childForm.WindowState = FormWindowState.Maximized;
            childForm.Show();
        }

        private void addUserToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmUserDetails childForm = new frmUserDetails();
            childForm.MdiParent = this;
            childForm.MdiParent.Size = new Size(childForm.Width + childForm.MdiParent.MainMenuStrip.Size.Width, this.Height);
            childForm.Text = "Window " + childFormNumber++;
            childForm.WindowState = FormWindowState.Maximized;
            childForm.Show();
        }

        private void searchProductsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmProductList childForm = new frmProductList();
            childForm.MdiParent = this;
            childForm.MdiParent.Size = new Size(childForm.Width + childForm.MdiParent.MainMenuStrip.Size.Width, this.Height);
            childForm.Text = "Window " + childFormNumber++;
            childForm.WindowState = FormWindowState.Maximized;
            childForm.Show();
        }

        private void searchSellers_Click(object sender, EventArgs e)
        {
            frmSellersList childForm = new frmSellersList();
            childForm.MdiParent = this;
            childForm.MdiParent.Size = new Size(childForm.Width + childForm.MdiParent.MainMenuStrip.Size.Width, this.Height);
            childForm.Text = "Window " + childFormNumber++;
            childForm.WindowState = FormWindowState.Maximized;
            childForm.Show();
        }

        private void addEmployeeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmEmployeeDetails childForm = new frmEmployeeDetails();
            childForm.MdiParent = this;
            childForm.MdiParent.Size = new Size(childForm.Width + childForm.MdiParent.MainMenuStrip.Size.Width, this.Height);
            childForm.Text = "Window " + childFormNumber++;
            childForm.WindowState = FormWindowState.Maximized;
            childForm.Show();
        }

        private void searchEmployeesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmEmployeesList childForm = new frmEmployeesList();
            childForm.MdiParent = this;
            childForm.MdiParent.Size = new Size(childForm.Width + childForm.MdiParent.MainMenuStrip.Size.Width, this.Height);
            childForm.Text = "Window " + childFormNumber++;
            childForm.WindowState = FormWindowState.Maximized;
            childForm.Show();
        }
    }
}
