using System.Windows.Forms;
using Logic.Repositories;
using Logic.Entities;
using System.Data;

namespace Cliente
{
    public partial class PendingRequestProductsForm : Form
    {
        private int _requestId;

        public PendingRequestProductsForm(int requestId)
        {
            InitializeComponent();
            _requestId = requestId;

            FillDataGridView();
        }

        /// <summary>
        /// Fills the datagridview with the products related to a pending request
        /// </summary>
        private async void FillDataGridView()
        {
            var content = await ProductsManagement.GetPendingRequestProducts(_requestId);

            DataTable table = new();
            table = content.ToDataTable();

            dgvProducts.DataSource = table;
        }
    }
}
