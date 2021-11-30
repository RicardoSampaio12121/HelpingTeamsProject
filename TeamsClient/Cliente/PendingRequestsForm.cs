using System.Windows.Forms;
using Logic.Repositories;
using Logic.Entities;
using System.Data;

namespace Cliente
{
    public partial class PendingRequestsForm : Form
    {
        private int _teamId;

        public PendingRequestsForm(int teamId)
        {
            InitializeComponent();
            _teamId = teamId;
            FillDataGridView();
        }

        /// <summary>
        /// Fills the datagridview with the pensing request related to the team "logged in"
        /// </summary>
        private async void FillDataGridView()
        {
            var content = await ProductsManagement.GetPendingRequests(_teamId);

            DataTable table = new();
            table = content.ToDataTable();

            dgvPendingRequests.DataSource = table;
        }

        /// <summary>
        /// Shows the products related to the request selected
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnProducts_Click(object sender, System.EventArgs e)
        {
            int index = dgvPendingRequests.SelectedRows[0].Index;
            var row = dgvPendingRequests.Rows[index];
            int reqId = int.Parse(row.Cells[0].Value.ToString());

            PendingRequestProductsForm productsForm = new(reqId);
            productsForm.Show();
        }
    }
}
