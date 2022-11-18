using eCodes.Models.SearchObjects;
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
using Flurl;
using Flurl.Http;
using eCodes.Services;

namespace eCodes.WinUI
{
    public partial class frmProductList : Form
    {
        public ProductAPIService ProductService { get; set; } = new ProductAPIService("Products");

        public frmProductList()
        {
            InitializeComponent();
            AddButtonsColumns();
            dgvProductsList.AutoGenerateColumns = false;
        }

        private void AddButtonsColumns()
        {
            //Activate btn
            DataGridViewButtonColumn activateBtn = new DataGridViewButtonColumn();
            activateBtn.HeaderText = "Activate";
            activateBtn.Text = "Activate";
            activateBtn.Name = "btnActivate";
            activateBtn.UseColumnTextForButtonValue = true;
            activateBtn.CellTemplate.Style.BackColor = Color.Green;
            activateBtn.AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;

            dgvProductsList.Columns.Add(activateBtn);

            //Hide btn
            DataGridViewButtonColumn hideBtn = new DataGridViewButtonColumn();
            hideBtn.HeaderText = "Hide";
            hideBtn.Text = "Hide";
            hideBtn.Name = "btnHide";
            hideBtn.UseColumnTextForButtonValue = true;
            hideBtn.CellTemplate.Style.BackColor = Color.Orange;
            hideBtn.AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;


            dgvProductsList.Columns.Add(hideBtn);
           
            //Delete btn
            DataGridViewButtonColumn deleteBtn = new DataGridViewButtonColumn();
            deleteBtn.HeaderText = "Delete";
            deleteBtn.Text = "Delete";
            deleteBtn.Name = "btnDelete";
            deleteBtn.UseColumnTextForButtonValue = true;
            deleteBtn.CellTemplate.Style.BackColor = Color.Red;
            deleteBtn.AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;


            dgvProductsList.Columns.Add(deleteBtn);

        }

        private async void btnShowProducts_Click(object sender, EventArgs e)
        {
            var productSearchObject = new ProductSearchObjects();
            productSearchObject.Platform = txtPlatform.Text;
            productSearchObject.Duration = txtDuration.Text;
            productSearchObject.Name = txtName.Text;
            if(APIService.accountType == "Seller")
            {
                productSearchObject.SellerName = APIService.username;
                productSearchObject.StateMachine = "all";
            }
            if (!string.IsNullOrWhiteSpace(txtPrice.Text))
                productSearchObject.Price = Convert.ToDecimal(txtPrice.Text);
            productSearchObject.Code = txtCode.Text;
            productSearchObject.Version = txtVersion.Text;

            productSearchObject.IncludeType = true;

            var list = await ProductService.Get<List<Products>>(productSearchObject);
            dgvProductsList.DataSource = list;

        }

        private void dgvProductsList_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            var item = dgvProductsList.SelectedRows[0].DataBoundItem as Products;

            if(item?.StateMachine != "active") 
            {
                frmProductDetails frm = new frmProductDetails(item);
                frm.ShowDialog();
            }
            else
                MessageBox.Show("You can't edit an active product! ", "Product Message", MessageBoxButtons.OK, MessageBoxIcon.Error);

        }

        private void frmProductList_LoadAsync(object sender, EventArgs e)
        {
             loadData();
        }
        public async void loadData()
        {
            var productSearchObject = new ProductSearchObjects();
            if(APIService.accountType == "Seller")
            {
                productSearchObject.SellerName = APIService.username;
                productSearchObject.StateMachine = "all";
            }
            productSearchObject.IncludeType = true;

            var list = await ProductService.Get<List<Products>>(productSearchObject);
            dgvProductsList.DataSource = list;
        }

        private async void dgvProductsList_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 11) //Activate btn Column
            {
                DataGridViewCellCollection cellData = dgvProductsList.Rows[e.RowIndex].Cells;
                string code = (string)cellData[1].Value;
                ProductSearchObjects search = new ProductSearchObjects();
                search.Code = code;
                List<Products> products = await ProductService.Get<List<Products>>(search);
                var product = products.FirstOrDefault();
                if (product?.StateMachine != "active")
                {
                    if (DialogResult.OK == MessageBox.Show("Are you sure you want to activate this product ?", "Activate Message", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning))
                    {
                        var activated = await ProductService.Activate<Products>(product.ProductId);

                        if (activated != null)
                        {
                            MessageBox.Show("You have successfully activated the product " + activated.Name, "Product Activated Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            loadData();
                        }
                    }
                    else
                    {
                        MessageBox.Show("The operation was canceled !", "Product Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        loadData();
                    }

                }
                else
                    MessageBox.Show("Product is already active !", "Product Info Message", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (e.ColumnIndex == 12) //Hide btn Column
            {
                DataGridViewCellCollection cellData = dgvProductsList.Rows[e.RowIndex].Cells;
                string code = (string)cellData[1].Value;
                ProductSearchObjects search = new ProductSearchObjects();
                search.Code = code;
                List<Products> products = await ProductService.Get<List<Products>>(search);
                var product = products.FirstOrDefault();
                if (product?.StateMachine != "hidden")
                {
                    if (DialogResult.OK == MessageBox.Show("Are you sure you want to hide this product ?", "Hide Message", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning))
                    {
                        var hidden = await ProductService.Hide<Products>(product.ProductId);

                        if (hidden != null)
                        {
                            MessageBox.Show("You have successfully hidden the product " + hidden.Name, "Product Hidden Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            loadData();
                        }
                    }
                    else
                    {
                        MessageBox.Show("The operation was canceled !", "Product Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        loadData();
                    }
                }
                else
                    MessageBox.Show("Product is already hidden !", "Product Info Message", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (e.ColumnIndex == 13) // Delete btn Column
            {
                DataGridViewCellCollection cellData = dgvProductsList.Rows[e.RowIndex].Cells;
                string code = (string)cellData[1].Value;
                ProductSearchObjects search = new ProductSearchObjects();
                search.Code = code;
                List<Products> products = await ProductService.Get<List<Products>>(search);
                var product = products.FirstOrDefault();

                if (product?.StateMachine == "hidden" || product?.StateMachine == "draft")
                {
                    if (DialogResult.OK == MessageBox.Show("Are you sure you want to delete this product ?", "Delete Message", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning))
                    {
                        var deleted = await ProductService.Delete<Products>(product.ProductId);

                        if (deleted != null)
                        {
                            MessageBox.Show("You have successfully deleted the product " + deleted.Name, "Product Deleted Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            loadData();
                        }
                    }
                    else
                    {
                        MessageBox.Show("The operation was canceled !", "Product Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        loadData();
                    }
                }
                else
                    MessageBox.Show("You can't delete an active product, try hiding it and then deleting!", "Product Info Message", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
