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
        private int _teamId;

        public MakeRequestForm(int teamId)
        {
            InitializeComponent();
            LoadDataGridView();
            basket = new();
            _teamId = teamId;
        }

        /// <summary>
        /// Fills the datagridview with all the available products
        /// </summary>
        private async void LoadDataGridView()
        {
            var content = await ProductsManagement.GetAllAvailableProducts();

            DataTable table = new();
            table = content.ToDataTable();

            dgvProducts.DataSource = table;
        }

        /// <summary>
        /// Adds a product into the basket
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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

        /// <summary>
        /// Makes the request
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void btnSubmit_Click(object sender, System.EventArgs e)
        {
            await ProductsManagement.MakeRequest(_teamId, basket);
            MessageBox.Show("Request done successfully!");
        }
    }
}
