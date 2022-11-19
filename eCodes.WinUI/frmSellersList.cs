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
    public partial class frmSellersList : Form
    {
        public APIService SellersService { get; set; } = new APIService("Sellers");

        public frmSellersList()
        {
            InitializeComponent();
            AddButtonColumn();
            dgvSellers.AutoGenerateColumns = false;
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

            dgvSellers.Columns.Add(deleteBtn);
        }
        public async void loadData()
        {
            var sellersSearch = new SellerSearchObject();

            sellersSearch.Name = txtName.Text;
            sellersSearch.PhoneNumber = txtPhonenumber.Text;
            sellersSearch.Address = txtAddress.Text;
            sellersSearch.Email = txtEmail.Text;
            sellersSearch.Status = cbStatus.Checked;
            sellersSearch.IncludePerson = true;

            var list = await SellersService.Get<List<Models.Sellers>>(sellersSearch);

            dgvSellers.DataSource = list;
        }
        private async void btnShowSellers_Click(object sender, EventArgs e)
        {
            loadData();
        }

        private void dgvSellers_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            var item = dgvSellers.SelectedRows[0].DataBoundItem as Sellers;

            frmSellerDetails frm = new frmSellerDetails(item);
            frm.ShowDialog();

        }

        private async void dgvSellers_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.ColumnIndex == 8)
            {
                DataGridViewCellCollection cellData = dgvSellers.Rows[e.RowIndex].Cells;
                bool status = (bool)cellData[7].Value;

                if (status == false)
                {
                    if (DialogResult.OK == MessageBox.Show("Are you sure you want to delete this seller ?", "Delete Message", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning))
                    {
                        SellerSearchObject search = new SellerSearchObject();
                        search.Name = cellData[0].Value.ToString();

                        List<Sellers> sellerList = await SellersService.Get<List<Sellers>>(search);
                        Sellers seller = sellerList.FirstOrDefault();

                        var deletedSeller = await SellersService.Delete<Sellers>(seller.SellerId);

                        if (deletedSeller != null)
                        {
                            MessageBox.Show("You have successfully deleted seller " + deletedSeller.Name + " and all of their products !", "Seller Deleted Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            loadData();
                        }
                    }
                    else
                    {
                        MessageBox.Show("The operation was canceled !");
                        loadData();

                    }
                }
                else
                {
                    MessageBox.Show("Can't delete a seller that didn't request deletion !", "Seller Info Message", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    loadData();
                }

            }
        }
        private void frmSellersList_Load(object sender, EventArgs e)
        {
            loadData();
        }
    }
}
