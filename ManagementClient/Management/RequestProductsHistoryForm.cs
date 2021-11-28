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
    public partial class RequestProductsHistoryForm : Form
    {
        public RequestProductsHistoryForm(int reqId)
        {
            InitializeComponent();
            FillDataGridView(reqId);
        }

        private async void FillDataGridView(int reqId)
        {
            var content = await ProductsManagement.GetCompletedRequestProducts(reqId);
            DataTable data = new();
            data = content.ToDataTable();

            dgvProducts.DataSource = data;
        }
    }
}
