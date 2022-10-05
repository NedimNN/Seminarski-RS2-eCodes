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
            AddButton();
            dgvUsers.AutoGenerateColumns = false;
        }

        private void AddButton()
        {
            //Delete btn
            DataGridViewButtonColumn deleteBtn = new DataGridViewButtonColumn();
            deleteBtn.HeaderText = "Delete";
            deleteBtn.Text = "Delete";
            deleteBtn.Name = "btnDelete";
            deleteBtn.UseColumnTextForButtonValue = true;
            deleteBtn.CellTemplate.Style.BackColor = Color.Red;
            deleteBtn.AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;

            dgvUsers.Columns.Add(deleteBtn);
        }

        public async void loadData()
        {
            var searchObject = new UserSearchObject();

            searchObject.Username = txtUsername.Text;
            searchObject.Email = txtEmail.Text;
            searchObject.IncludeRoles = true;

            var list = await UsersService.Get<List<Users>>(searchObject);

            dgvUsers.DataSource = list;
        }
        private async void btnShowUsers_Click(object sender, EventArgs e)
        {
            loadData();
        }

        private void dgvUsers_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            var item = dgvUsers.SelectedRows[0].DataBoundItem as Users;

            frmUserDetails frm = new frmUserDetails(item);
            frm.ShowDialog();

        }

        private async void frmUsers_Load(object sender, EventArgs e)
        {
            loadData();
        }

        private async void dgvUsers_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.ColumnIndex == 5) // delete btn column
            {
                DataGridViewCellCollection cellData = dgvUsers.Rows[e.RowIndex].Cells;
                UserSearchObject search = new UserSearchObject();
                search.Username = cellData[0].Value.ToString();
                search.Email = cellData[1].Value.ToString();
                List<Users> users = await UsersService.Get<List<Users>>(search);
                var usertoDelete = users.FirstOrDefault();

                if(usertoDelete != null)
                {
                    if(DialogResult.OK == MessageBox.Show("Are you sure you want to delete this user ?", "Delete Message", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning))
                    {
                        var deletedUser = await UsersService.Delete<Users>(usertoDelete.UserId);
                        if(deletedUser != null)
                        {
                            MessageBox.Show("You have successfully deleted the user " + deletedUser.Username, "User Deleted Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            loadData();
                        }
                    }
                    else
                    {
                        MessageBox.Show("The operation was canceled !", "User Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        loadData();
                    }
                }
                else
                    MessageBox.Show("Something went wrong, try again later !", "Product Info Message", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                
                


            }
        }
    }
}
