using eCodes.Models;
using eCodes.Models.SearchObjects;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace eCodes.WinUI
{
    public partial class frmUsers : Form
    {
        public APIService UsersService { get; set; } = new APIService("User");

        public frmUsers()
        {
            InitializeComponent();
            dgvUsers.AutoGenerateColumns = false;
        }

        private async void btnShowUsers_Click(object sender, EventArgs e)
        {
            var searchObject = new UserSearchObject();

            searchObject.Username = txtUsername.Text;
            searchObject.Email = txtEmail.Text;
            searchObject.IncludeRoles = true;

            var list = await UsersService.Get<List<Users>>(searchObject);

            dgvUsers.DataSource = list;
            
        }

        private void dgvUsers_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            var item = dgvUsers.SelectedRows[0].DataBoundItem as Users;

            frmUserDetails frm = new frmUserDetails(item);
            frm.ShowDialog();

        }
    }
}
