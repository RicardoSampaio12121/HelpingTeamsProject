using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using Logic.Repositories;
using Logic.Entities;

namespace Cliente
{
    public partial class MakeRequestForm : Form
    {
        private List<ProductInBasket> basket;

        public MakeRequestForm()
        {
            InitializeComponent();
            LoadDataGridView();
            basket = new();
        }

        private async void LoadDataGridView()
        {
            var content = await ProductsManagement.GetAllAvailableProducts();

            DataTable table = new();
            table = content.ToDataTable();

            dgvProducts.DataSource = table;
        }

        private void btnAdd_Click(object sender, System.EventArgs e)
        {
            int index = dgvProducts.SelectedRows[0].Index;
            var row = dgvProducts.Rows[index];
            //int teamId = int.Parse(row.Cells[0].Value.ToString());
            int quantity;

            using (var form = new QuantityForm())
            {
                var result = form.ShowDialog();
                quantity = form.Quantity;    
            }

            int productId = int.Parse(row.Cells[0].Value.ToString());

            ProductInBasket product = new()
            {
                productId = productId,
                quantity = quantity
            };

            basket.Add(product);
        }

        private async void btnSubmit_Click(object sender, System.EventArgs e)
        {
            int teamId = int.Parse(txtTeamId.Text);
            await ProductsManagement.MakeRequest(teamId, basket);
        }
    }
}
