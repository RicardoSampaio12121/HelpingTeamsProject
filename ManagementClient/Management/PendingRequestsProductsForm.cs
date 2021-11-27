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

namespace Management
{
    public partial class PendingRequestsProductsForm : Form
    {
        public PendingRequestsProductsForm(int reqId)
        {
            InitializeComponent();
            FillDataGridView(reqId);
        }

        private async void FillDataGridView(int reqId)
        {
            var content = await ProductsManagement.GetPendingRequestProducts(reqId);

            DataTable table = new();
            table = content.ToDataTable();

            dgvProducts.DataSource = table;
        }
    }
}
