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

namespace eCodes.WinUI
{
    public partial class frmProductDetails : Form
    {
        public APIService ProductsService { get; set; } = new APIService("Products");
        public APIService ProductTypesService { get; set; } = new APIService("ProductTypes");
        public APIService SellerService { get; set; } = new APIService("Sellers");
        private Products _model = null;
        public frmProductDetails(Products model = null)
        {
            InitializeComponent();
            _model = model;
        }

        private void txtName_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtName.Text))
            {
                e.Cancel = true;
                txtName.Focus();
                errorProviderProducts.SetError(txtName, "Name should not be left blank!");
            }
            else
            {
                e.Cancel = false;
                errorProviderProducts.SetError(txtName, "");
            }
        }

        private void txtGiftCardKey_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtGiftCardKey.Text))
            {
                e.Cancel = true;
                txtGiftCardKey.Focus();
                errorProviderProducts.SetError(txtGiftCardKey, "Gift card key should not be left blank!");
            }
            else
            {
                e.Cancel = false;
                errorProviderProducts.SetError(txtGiftCardKey, "");
            }
        }

        private void txtProductCode_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtProductCode.Text))
            {
                e.Cancel = true;
                txtProductCode.Focus();
                errorProviderProducts.SetError(txtProductCode, "Product code should not be left blank!");
            }
            else
            {
                e.Cancel = false;
                errorProviderProducts.SetError(txtProductCode, "");
            }
        }

        private void txtValue_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtValue.Text))
            {
                e.Cancel = true;
                txtValue.Focus();
                errorProviderProducts.SetError(txtValue, "Value should not be left blank!");
            }
            else
            {
                e.Cancel = false;
                errorProviderProducts.SetError(txtValue, "");
            }
        }

        private void txtPrice_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtPrice.Text))
            {
                e.Cancel = true;
                txtPrice.Focus();
                errorProviderProducts.SetError(txtPrice, "Price should not be left blank!");
            }
            else
            {
                e.Cancel = false;
                errorProviderProducts.SetError(txtPrice, "");
            }
        }

        private void txtPrice_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
        (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            // only allow one decimal point
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }

        private void txtDuration_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtDuration.Text))
            {
                e.Cancel = true;
                txtDuration.Focus();
                errorProviderProducts.SetError(txtDuration, "Duration should not be left blank!");
            }
            else
            {
                e.Cancel = false;
                errorProviderProducts.SetError(txtDuration, "");
            }
        }
        private void btnUploadImage_Click(object sender, EventArgs e)
        {
            string Chosen_file = "";
            oFDImage.InitialDirectory = System.Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            oFDImage.Title = "Insert an image";
            oFDImage.FileName = "";
            oFDImage.Filter = "JPG Images|*.jpg|JPEG Images|*.jpeg|PNG Images|*.png|BITMAPS|*.bmp";
            
            oFDImage.ShowDialog();

            if(oFDImage.ShowDialog() == DialogResult.Cancel)
            {
                MessageBox.Show("Operation was canceled!");
            }
            else
            {
                Chosen_file = oFDImage.FileName;
                pbImage.Image = Image.FromFile(Chosen_file);
            }

        }
        private async void btnSaveProduct_Click(object sender, EventArgs e)
        {      
            if(pbImage.Image != null)
            { 

                 if (ValidateChildren())
                 {
                     if(_model == null)
                     {
                         MemoryStream m = new MemoryStream();
                         pbImage.Image.Save(m, pbImage.Image.RawFormat);
                         byte[] imgBytes = m.ToArray();
                         SellerSearchObject search = new SellerSearchObject();
                         search.Name = APIService.username;
                         search.Status = true;
                         List<Sellers> seller = await SellerService.Get<List<Sellers>>(search);

                         ProductsInsertRequest insert = new ProductsInsertRequest
                         {
                             Name = txtName.Text,
                             Code = txtProductCode.Text,
                             Price = Convert.ToDecimal(txtPrice.Text),
                             GiftCardKey = txtGiftCardKey.Text,
                             Description = txtDescription.Text,
                             Duration = txtDuration.Text,
                             Value = Convert.ToInt32(txtValue.Text),
                             Version = txtVersion.Text,
                             Platform = txtPlatform.Text,
                             ProductTypeId = cbProductTypes.SelectedIndex + 1,
                             Picture = imgBytes,
                             SellerId = seller.First().SellerId 
                         };

                         _model = await ProductsService.Post<Models.Products>(insert);
                         if (_model != null)
                             MessageBox.Show("Product added successfully!", "Product Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                     }
                     else
                     {
                         MemoryStream m = new MemoryStream();
                         pbImage.Image.Save(m, pbImage.Image.RawFormat);
                         byte[] imgBytes = m.ToArray();

                         ProductsUpdateRequest update = new ProductsUpdateRequest
                         {
                             Name = txtName.Text,
                             Price = Convert.ToDecimal(txtPrice.Text),
                             GiftCardKey = txtGiftCardKey.Text,
                             Description = txtDescription.Text,
                             Duration = txtDuration.Text,
                             Value = Convert.ToInt32(txtValue.Text),
                             Version = txtVersion.Text,
                             Platform = txtPlatform.Text,
                             ProductTypeId = cbProductTypes.SelectedIndex + 1,
                             Picture = imgBytes
                         };
                         _model = await ProductsService.Put<Models.Products>(_model.ProductId, update);
                         if (_model != null)
                             MessageBox.Show("Product updated successfully!", "Product Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                     }
                 }
            }
            else
            {
                MessageBox.Show("Product can't be created/updated without a picture !", "Product Message", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

        }

        private async void frmProductDetails_Load(object sender, EventArgs e)
        {
            var productTypeList = await ProductTypesService.Get<List<Models.ProductTypes>>();

            foreach (var productType in productTypeList)
            {
                cbProductTypes.Items.Add(productType.Name + " ----- " + productType.Region);
            }

            if(_model != null)
            {
                txtDescription.Text = _model.Description;
                txtDuration.Text = _model.Duration;
                txtGiftCardKey.Text = _model.GiftCardKey;
                txtName.Text = _model.Name;
                txtPlatform.Text = _model.Platform;
                txtPrice.Text = Convert.ToString(_model.Price);
                txtProductCode.Text = _model.Code;
                txtValue.Text = Convert.ToString(_model.Value);
                txtVersion.Text = _model.Version;
                cbProductTypes.Items[0] = _model.ProductTypeName;
                MemoryStream m = new MemoryStream(_model.Picture);
                if(_model.Picture.Length > 0)
                    pbImage.Image = Image.FromStream(m);
            }

        }

        private void txtValue_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }
    }
}
