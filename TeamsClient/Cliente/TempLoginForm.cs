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
    public partial class TempLoginForm : Form
    {
        public TempLoginForm()
        {
            InitializeComponent();
        }

        public int TeamId { get; set; }

        /// <summary>
        /// Temporary login
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnLogin_Click(object sender, EventArgs e)
        {
            //TODO: Verificar se a equipa existe na base de dados
            TeamId = int.Parse(txtTeamId.Text);
            Close();
        }
    }
}
