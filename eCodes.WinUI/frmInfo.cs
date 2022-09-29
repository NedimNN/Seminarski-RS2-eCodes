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
        public APIService SellersService { get; set; } = new APIService("Sellers");
        public APIService ProductService { get; set; } = new APIService("Products");
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
                Persons person = await PersonService.GetById<Persons>(_model.PersonId);

                SellerUpdateRequest update = new SellerUpdateRequest
                {
                    FirstName = person.FirstName,
                    LastName = person.LastName,
                    Email = _model.Email,
                    Gender = person.Gender,
                    Address = _model.Address,
                    PhoneNumber = _model.PhoneNumber,
                    Website = _model.Website,
                    Status = false,
                    DateOfBirth = person.DateOfBirth,
                    Password = "0",
                    PasswordConfirmation = "0"
                };

                ProductSearchObjects search = new ProductSearchObjects();
                search.SellerName = _model.Name;
                search.StateMachine = "all";
                List<Products> products = await ProductService.Get<List<Products>>(search);
                List<Products> updatedProducts = new List<Products>();
                foreach (var product in products)
                {
                    product.StateMachine = "hidden";
                    var updated = await ProductService.Put<Products>(product.ProductId, product);
                    updatedProducts.Add(updated);
                }

                _model = await SellersService.Put<Models.Sellers>(_model.SellerId, update);

                if (_model != null && updatedProducts.FirstOrDefault() != null)
                    MessageBox.Show("Your account was sent to employees for deletion and your products are currently hidden !", "Delete Seller", MessageBoxButtons.OK,MessageBoxIcon.Information);
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
