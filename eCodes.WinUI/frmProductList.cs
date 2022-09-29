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

namespace eCodes.WinUI
{
    public partial class frmProductList : Form
    {
        public APIService ProductService { get; set; } = new APIService("Products");
        public frmProductList()
        {
            InitializeComponent();
            dgvProductsList.AutoGenerateColumns = false;
        }

        private async void btnShowProducts_Click(object sender, EventArgs e)
        {
            var productSearchObject = new ProductSearchObjects();
            productSearchObject.Platform = txtPlatform.Text;
            productSearchObject.Duration = txtDuration.Text;
            productSearchObject.Name = txtName.Text;
            productSearchObject.SellerName = APIService.username;
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

            frmProductDetails frm = new frmProductDetails(item);
            frm.ShowDialog();
        }

        private async void frmProductList_LoadAsync(object sender, EventArgs e)
        {
            var productSearchObject = new ProductSearchObjects();
            productSearchObject.SellerName = APIService.username;
            productSearchObject.IncludeType = true;

            var list = await ProductService.Get<List<Products>>(productSearchObject);
            dgvProductsList.DataSource = list;

        }
    }
}
