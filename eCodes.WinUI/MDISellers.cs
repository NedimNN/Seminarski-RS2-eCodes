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

namespace eCodes.WinUI
{
    public partial class MDISellers : Form
    {
        private int childFormNumber = 0;
        public APIService SellerService { get; set; } = new APIService("Sellers");

        public MDISellers()
        {
            InitializeComponent();
        }

        private void menuSearchProducts_Click(object sender, EventArgs e)
        {
            frmProductList childForm = new frmProductList();
            childForm.MdiParent = this;
            childForm.MdiParent.Size = new Size(childForm.Width + childForm.MdiParent.MainMenuStrip.Size.Width, this.Height);
            childForm.Text = "Window " + childFormNumber++;
            childForm.WindowState = FormWindowState.Maximized;
            childForm.Show();
        }

        private void menuAddProducts_Click(object sender, EventArgs e)
        {
            frmProductDetails childForm = new frmProductDetails();
            childForm.MdiParent = this;
            childForm.MdiParent.Size = new Size(childForm.Width + childForm.MdiParent.MainMenuStrip.Size.Width, this.Height);
            childForm.Text = "Window " + childFormNumber++;
            childForm.WindowState = FormWindowState.Maximized;
            childForm.Show();
        }

        private async void  editProfileMenu_Click(object sender, EventArgs e)
        {
            SellerSearchObject search = new SellerSearchObject();
            search.Name = APIService.username;
            search.Status = true;
            List<Sellers> seller = await SellerService.Get<List<Sellers>>(search);
            frmSellerDetails childForm = new frmSellerDetails(seller.FirstOrDefault());
            childForm.MdiParent = this;
            childForm.MdiParent.Size = new Size(childForm.Width + childForm.MdiParent.MainMenuStrip.Size.Width, this.Height);
            childForm.Text = "Window " + childFormNumber++;
            childForm.WindowState = FormWindowState.Maximized;
            childForm.Show();
        }

        private async void requestAccountDeletionToolStripMenuItem_ClickAsync(object sender, EventArgs e)
        {
            SellerSearchObject search = new SellerSearchObject();
            search.Name = APIService.username;
            search.Status = true;
            List<Sellers> seller = await SellerService.Get<List<Sellers>>(search);
            frmInfo childForm = new frmInfo(seller.FirstOrDefault());
            childForm.MdiParent = this;
            childForm.MdiParent.Size = new Size(childForm.Width + childForm.MdiParent.MainMenuStrip.Size.Width, this.Height);
            childForm.Text = "Window " + childFormNumber++;
            childForm.WindowState = FormWindowState.Maximized;
            childForm.Show();
        }

        //private async void soldProductsToolStripMenuItem_Click(object sender, EventArgs e)
        //{
        //    SellerSearchObject search = new SellerSearchObject();
        //    search.Name = APIService.username;
        //    search.Status = true;
        //    List<Sellers> sellers = await SellerService.Get<List<Sellers>>(search);
        //    Sellers seller = sellers.FirstOrDefault();
        //    frmSoldProducts childForm = new frmSoldProducts(seller);
        //    childForm.MdiParent = this;
        //    childForm.MdiParent.Size = new Size(childForm.Width + childForm.MdiParent.MainMenuStrip.Size.Width, this.Height);
        //    childForm.Text = "Window " + childFormNumber++;
        //    childForm.WindowState = FormWindowState.Maximized;
        //    childForm.Show();
        //}
    }
}
