using Logic;
using System;
using System.Windows.Forms;

namespace Cliente
{
    public partial class Form1 : Form
    {
        private int teamId;

        public Form1()
        {
            InitializeComponent();
            ApiConnector.Connect();
            using (var form = new TempLoginForm())
            {
                var result = form.ShowDialog();
                teamId = form.TeamId;
            }
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

        private void btnMakeRequestMenu_Click(object sender, EventArgs e)
        {
            OpenChildForm(new MakeRequestForm(teamId));
        }

        private void button2_Click(object sender, EventArgs e)
        {
            OpenChildForm(new PendingRequestsForm(teamId));
        }
    }
}
