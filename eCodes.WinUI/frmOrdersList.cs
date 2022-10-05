using AutoMapper;
using eCodes.Models;
using eCodes.Models.Requests;
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
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace eCodes.WinUI
{
    public partial class frmOrdersList : Form
    {
        public APIService OrderService { get; set; } = new APIService("Orders");
        private bool dateChanged = false;
        public frmOrdersList()
        {
            InitializeComponent();
            AddButtons();
            dgvOrderList.AutoGenerateColumns = false;
        }

        private void AddButtons()
        {
            //Cancel btn
            DataGridViewButtonColumn cancelbtn = new DataGridViewButtonColumn();
            cancelbtn.HeaderText = "Cancel";
            cancelbtn.Text = "Cancel";
            cancelbtn.Name = "btnCancel";
            cancelbtn.UseColumnTextForButtonValue = true;
            cancelbtn.CellTemplate.Style.BackColor = Color.Orange;
            cancelbtn.AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;


            dgvOrderList.Columns.Add(cancelbtn);

            //Delete btn
            DataGridViewButtonColumn deleteBtn = new DataGridViewButtonColumn();
            deleteBtn.HeaderText = "Delete";
            deleteBtn.Text = "Delete";
            deleteBtn.Name = "btnDelete";
            deleteBtn.UseColumnTextForButtonValue = true;
            deleteBtn.CellTemplate.Style.BackColor = Color.Red;
            deleteBtn.AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;


            dgvOrderList.Columns.Add(deleteBtn);
        }

        public async void loadData()
        {
            var orderSearch = new OrderSearchObject();
            orderSearch.OrderNumber = txtOrderNumber.Text;
            if(dateChanged)
            {
                orderSearch.Date = dateTimeOrderDate.Value;
            }
            else
            {
                orderSearch.Date = DateTime.MinValue;
            }
            orderSearch.Canceled = cbCanceled.Checked;
            orderSearch.BuyerName = txtBuyerName.Text;

            orderSearch.IncludeBuyer = true;
            orderSearch.IncludeItems = true;

            var orders = await OrderService.Get<List<Models.Orders>>(orderSearch);
            dateChanged = false;
            dgvOrderList.DataSource = orders;
        }

        private async void btnShowOrders_Click(object sender, EventArgs e)
        {
            loadData();
        }

        private void dgvOrderList_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            var item = dgvOrderList.SelectedRows[0].DataBoundItem as Orders;

            if (item != null)
            {
                frmOrderDetails frm = new frmOrderDetails(item);
                frm.ShowDialog();
            }
            else
                MessageBox.Show("Selected order cannot be displayed! Please try another one...","Order Message",MessageBoxButtons.OK,MessageBoxIcon.Information);
        }

        private void frmOrdersList_Load(object sender, EventArgs e)
        {
            loadData();
            dateTimeOrderDate.ValueChanged += new System.EventHandler(dateTimeOrderDate_ValueChanged);
        }
        private void dateTimeOrderDate_ValueChanged(object? sender,EventArgs e)
        {
            dateChanged = true;
        }
        private async void dgvOrderList_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.ColumnIndex == 6) // cancelbtn column
            {
                DataGridViewCellCollection cellData = dgvOrderList.Rows[e.RowIndex].Cells;
                OrderSearchObject search = new OrderSearchObject();
                search.OrderNumber = cellData[0].Value.ToString();
                search.BuyerName = cellData[1].Value.ToString();
                search.IncludeItems = true;
                search.IncludeBuyer = true;
                List<Orders> orders = await OrderService.Get<List<Orders>>(search);
                var order = orders.FirstOrDefault();
                if(order != null && order.Status == true && order.Canceled == false)
                {
                    if(DialogResult.OK == MessageBox.Show("Are you sure you want to cancel this order \nOrder Number: " + order.OrderNumber + " ?", "Cancel Message", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning))
                    {
                        OrdersUpdateRequest update = new OrdersUpdateRequest()
                        {
                            Canceled = true,
                            Status = false,
                        };


                        var updatedOrder = await OrderService.Put<Orders>(order.OrderId, update);
                        if(updatedOrder != null)
                        {
                            MessageBox.Show("You have successfully canceled the order \nOrder Number: " + updatedOrder.OrderNumber, "Order Canceled Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            loadData();
                        }
                        else
                        {
                            MessageBox.Show("Something went wrong!", "Order Canceled Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            loadData();
                        }
                    }
                    else
                    {
                        MessageBox.Show("The operation was canceled !", "Order Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        loadData();
                    }
                }
                else if (order != null)
                {
                    OrdersUpdateRequest update = new OrdersUpdateRequest()
                    {
                        Canceled = false,
                        Status = true,
                    };

                    var updatedOrder = await OrderService.Put<Orders>(order.OrderId, update);
                    if (updatedOrder != null)
                    {
                        MessageBox.Show("You have successfully reverted the cancel on order  \nOrder Number: " + updatedOrder.OrderNumber, "Order Revert Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        loadData();
                    }
                }
                else
                {
                    MessageBox.Show("Something went wrong!", "Order Canceled Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    loadData();
                }

            }
            else if(e.ColumnIndex == 7) // delete btn column
            {
                DataGridViewCellCollection cellData = dgvOrderList.Rows[e.RowIndex].Cells;
                OrderSearchObject search = new OrderSearchObject();
                search.OrderNumber = cellData[0].Value.ToString();
                search.BuyerName = cellData[1].Value.ToString();
                search.IncludeItems = true;
                search.IncludeBuyer = true;
                List<Orders> orders = await OrderService.Get<List<Orders>>(search);
                var order = orders.FirstOrDefault();

                if(order != null && order.Status == false && order.Canceled == true)
                {
                    if (DialogResult.OK == MessageBox.Show("Are you sure you want to delete this order \nOrder Number: " + order.OrderNumber + " ?", "Delete Message", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning))
                    {
                        var deletedOrder = await OrderService.Delete<Orders>(order.OrderId);

                        if(deletedOrder != null)
                        {
                            MessageBox.Show("You have successfully deleted the order \nOrder Number: " + deletedOrder.OrderNumber, "Order Deleted Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            loadData();
                        }
                    }
                    else
                    {
                        MessageBox.Show("The operation was canceled !", "Order Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        loadData();
                    }
                }
                else
                {
                    MessageBox.Show("You can only delete orders that are canceled ! \nTry searching only the canceled orders with the checkbox above ! ", "Order Delete Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    loadData();
                }
            }
        }
    }
}
