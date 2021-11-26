using Logic;
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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            ApiConnector.Connect();
        }

        private Form activeForm = null;
        /// <summary>
        /// Abre o formulário pedido
        /// </summary>
        /// <param name="childForm"></param>
        private void OpenChildForm(Form childForm)
        {
            if (activeForm != null)
            {
                activeForm.Close();
            }
            activeForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            panelForm.Controls.Add(childForm);
            panelForm.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
        }


        private void btnTeams_Click(object sender, EventArgs e)
        {
            lblCurrentForm.Text = "Teams management";
            OpenChildForm(new TeamsForm());
        }
    }
}
