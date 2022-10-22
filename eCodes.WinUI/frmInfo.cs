using eCodes.Models;
using eCodes.Models.Requests;
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
using System.Xml.Linq;

namespace eCodes.WinUI
{
    public partial class frmInfo : Form
    {
        public SellersAPIService SellersService { get; set; } = new SellersAPIService("Sellers");
        public ProductAPIService ProductService { get; set; } = new ProductAPIService("Products");
        public APIService PersonService { get; set; } = new APIService("Persons");


        private Sellers _model = null;
        public frmInfo(Sellers model = null)
        {
            InitializeComponent();
            _model = model;
        }

        private async void btnDelete_Click(object sender, EventArgs e)
        {
            if(_model != null)
            {
                ProductSearchObjects search = new ProductSearchObjects();
                search.SellerName = _model.Name;
                search.StateMachine = "all";
                List<Products> products = await ProductService.Get<List<Products>>(search);
                List<Products> updatedProducts = new List<Products>();
                if(products.Count > 0) { 
                    foreach (var product in products)
                    {
                        product.StateMachine = "hidden";
                        var updated = await ProductService.Hide<Models.Products>(product.ProductId);
                        updatedProducts.Add(updated);
                    }
                }
                _model = await SellersService.RequestDelete<Models.Sellers>(_model.SellerId);
                if (_model != null) {
                if(products.Count == 0 || updatedProducts.FirstOrDefault() != null) { 
                        MessageBox.Show("Your account was sent to employees for deletion and your products are currently hidden !", "Delete Seller", MessageBoxButtons.OK,MessageBoxIcon.Information);
                        var mdiParent = this.Parent.FindForm();
                        mdiParent.Close();
                    }
                }
                else
                    MessageBox.Show("Something went wrong!","Delete Seller", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
                MessageBox.Show("Something went wrong, try again later !", "Delete Seller", MessageBoxButtons.OK, MessageBoxIcon.Error);

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.CancelButton = btnCancel;
            this.Close();
        }
    }
}
