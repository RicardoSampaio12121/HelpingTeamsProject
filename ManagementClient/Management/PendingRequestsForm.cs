using System.Data;
using System.Windows.Forms;
using Logic.Repositories;

namespace Management
{
    public partial class PendingRequestsForm : Form
    {
        public PendingRequestsForm()
        {
            InitializeComponent();
            FillDataGridView();
        }

        private async void FillDataGridView()
        {
            var content = await ProductsManagement.GetPendingRequests();
            
            DataTable table = new();
            table = content.ToDataTable();

            dgvPendingRequests.DataSource = table;
        }

        private void btnInfo_Click(object sender, System.EventArgs e)
        {
            int index = dgvPendingRequests.SelectedRows[0].Index;
            var row = dgvPendingRequests.Rows[index];
            int reqId = int.Parse(row.Cells[0].Value.ToString());

            PendingRequestsProductsForm prodsForm = new(reqId);
            prodsForm.Show();
        }
    }
}
