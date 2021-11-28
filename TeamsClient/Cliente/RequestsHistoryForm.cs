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
    public partial class RequestsHistoryForm : Form
    {
        public RequestsHistoryForm(int teamId)
        {
            InitializeComponent();
            LoadDataGridView(teamId);
        }

        private async void LoadDataGridView(int teamId)
        {
            var content = await ProductsManagement.GetCompletedRequests(teamId);
            DataTable table = new();
            table = content.ToDataTable();

            dgvCompletedRequests.DataSource = table;
        }

        private void btnViewProducts_Click(object sender, EventArgs e)
        {
            int index = dgvCompletedRequests.SelectedRows[0].Index;
            var row = dgvCompletedRequests.Rows[index];
            int reqId = int.Parse(row.Cells[0].Value.ToString());

            CompletedRequestProductsForm f = new(reqId);
            f.Show();
        }
    }
}
