using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cliente
{
    public partial class QuantityForm : Form
    {
        public QuantityForm()
        {
            InitializeComponent();
        }

        public int Quantity { get; set; }

        /// <summary>
        /// Asks for the quantity the team wants of a product
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSubmit_Click(object sender, EventArgs e)
        {
            this.Quantity = int.Parse(txtQuantity.Text);
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
