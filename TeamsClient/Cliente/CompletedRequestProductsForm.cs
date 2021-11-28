using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Logic.Repositories;
using Logic.Entities;


namespace Cliente
{
    public partial class CompletedRequestProductsForm : Form
    {
        public CompletedRequestProductsForm(int reqId)
        {
            InitializeComponent();
            FillDataGridView(reqId);
        }

        private async void FillDataGridView(int reqId)
        {
            var content = await ProductsManagement.GetCompletedRequestProducts(reqId);
            DataTable table = new();
            table = content.ToDataTable();

            dgvCompletedRequestProducts.DataSource = table;
        }
    }
}
