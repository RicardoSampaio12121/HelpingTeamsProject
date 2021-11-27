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

        private async void FillDataGridView()
        {
            var content = await ProductsManagement.GetPendingRequests(_teamId);

            DataTable table = new();
            table = content.ToDataTable();

            dgvPendingRequests.DataSource = table;
        }

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
