using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Management
{
    public partial class AddStockForm : Form
    {
        public AddStockForm()
        {
            InitializeComponent();
        }

        public int Quantity { get; set; }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            Quantity = int.Parse(txtQuantity.Text);
            Close();
        }
    }
}
