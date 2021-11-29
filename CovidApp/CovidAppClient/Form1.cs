using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CovidAppClient
{
    public partial class Form1 : Form
    {
        //CovidApi.ICases cov = new CoviidApi.CasesClient();

        CovidApi.ICases cov = new CovidApi.CasesClient();

        private List<int> ccs = new();

        public Form1()
        {
            InitializeComponent();
        }

        private void btnContact_Click(object sender, EventArgs e)
        {
            if(!int.TryParse(txtCont.Text, out int cc))
            {
                MessageBox.Show("Invalid cc!");
            }
            else
            {
                ccs.Add(cc);
                MessageBox.Show("User added!");
            }
            txtCont.Text = string.Empty;
        }

        private async void btnSubmit_Click(object sender, EventArgs e)
        {
            if(!int.TryParse(txtInf.Text, out int cc))
            {
                MessageBox.Show("Invalida cc!");
            }
            else
            {
                await cov.InsertDetectedCaseAsync(cc);
                await cov.InsertUsersInContactAsync(ccs.ToArray(), cc);

                MessageBox.Show("Done!");
            }
            txtCont.Text = string.Empty;
            txtInf.Text = string.Empty;

        }
    }
}
