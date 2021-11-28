using Logic.Repositories;
using System.Data;
using System.Windows.Forms;


namespace Management
{
    public partial class RequestsHistory : Form
    {
        public RequestsHistory()
        {
            InitializeComponent();
            FillDataGridView();
        }

        private async void FillDataGridView()
        {
            var content = await ProductsManagement.GetCompletedRequests();

            DataTable data = new();
            data = content.ToDataTable();

            dgvRequests.DataSource = data;
        }

        private void btnInfo_Click(object sender, System.EventArgs e)
        {
            int index = dgvRequests.SelectedRows[0].Index;
            var row = dgvRequests.Rows[index];
            int reqId = int.Parse(row.Cells[0].Value.ToString());

            RequestProductsHistoryForm qphf = new(reqId);
            qphf.Show();
        }
    }
}
