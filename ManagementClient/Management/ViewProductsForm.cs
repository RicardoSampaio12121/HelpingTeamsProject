using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Logic.Entities;
using Logic.Repositories;

namespace Management
{
    public partial class ViewProductsForm : Form
    {
        public ViewProductsForm()
        {
            InitializeComponent();
            FillDataGridView();
        }

        private async void FillDataGridView()
        {
            var content = await ProductsManagement.GetProducts();
            DataTable table = new();
            table = content.ToDataTable();

            dgvProducts.DataSource = table;
        }

        private async void btnAddStock_Click(object sender, EventArgs e)
        {
            int index = dgvProducts.SelectedRows[0].Index;
            var row = dgvProducts.Rows[index];
            int prodId = int.Parse(row.Cells[0].Value.ToString());

            int quantityToAdd;

            using (var form = new AddStockForm())
            {
                var result = form.ShowDialog();
                quantityToAdd = form.Quantity;
            }

            await ProductsManagement.AddStock(prodId, quantityToAdd);

            MessageBox.Show("Stock updated successfully!");
            FillDataGridView();
        }
    }
}
