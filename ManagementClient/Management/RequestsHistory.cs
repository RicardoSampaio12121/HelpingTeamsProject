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

        /// <summary>
        /// Fills the datagridview with all the completed requests
        /// </summary>
        private async void FillDataGridView()
        {
            var content = await ProductsManagement.GetCompletedRequests();

            DataTable data = new();
            data = content.ToDataTable();

            dgvRequests.DataSource = data;
        }

        /// <summary>
        /// Show the products related to a completed request
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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
