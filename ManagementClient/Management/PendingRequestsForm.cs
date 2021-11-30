using System;
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

        /// <summary>
        /// Fills the datagridview with All the pending requests
        /// </summary>
        private async void FillDataGridView()
        {
            var content = await ProductsManagement.GetPendingRequests();
            
            DataTable table = new();
            table = content.ToDataTable();

            dgvPendingRequests.DataSource = table;
        }

        /// <summary>
        /// Shows the products related to a pending request
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnInfo_Click(object sender, System.EventArgs e)
        {
            int index = dgvPendingRequests.SelectedRows[0].Index;
            var row = dgvPendingRequests.Rows[index];
            int reqId = int.Parse(row.Cells[0].Value.ToString());

            PendingRequestsProductsForm prodsForm = new(reqId);
            prodsForm.Show();
        }

        /// <summary>
        /// Accepts a pending request
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void btnAcceptRequest_Click(object sender, System.EventArgs e)
        {
            //1º -> Recolher o id da request
            int index = dgvPendingRequests.SelectedRows[0].Index;
            var row = dgvPendingRequests.Rows[index];
            int reqId = int.Parse(row.Cells[0].Value.ToString());
            int teamId = int.Parse(row.Cells[1].Value.ToString());

            try
            {
                //2º -> A Logic que trate de aceitar a request em si
                await ProductsManagement.HandleRequest(reqId, teamId, "accepted");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            MessageBox.Show("Request successfully accepted!");

            FillDataGridView();
        }

        /// <summary>
        /// Declines a pending request
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void btnDeclineRequest_Click(object sender, EventArgs e)
        {
            int index = dgvPendingRequests.SelectedRows[0].Index;
            var row = dgvPendingRequests.Rows[index];
            int reqId = int.Parse(row.Cells[0].Value.ToString());
            int teamId = int.Parse(row.Cells[1].Value.ToString());

            await ProductsManagement.HandleRequest(reqId, teamId, "declined");

            MessageBox.Show("Request successfully declined!");
            FillDataGridView();
        }
    }
}