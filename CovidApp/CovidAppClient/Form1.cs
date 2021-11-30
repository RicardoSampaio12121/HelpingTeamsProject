/*
 * Author: Ricardo Sampaio
 * Email: ricardo_cs@outlook.pt
 * 
 * Author: Claudio Silva
 * Email: a18843@alunos.ipca.pt
 * 
 * This projects aims to simulate a program that lets members from GNR or PSP report positive COVID-19 cases they encounter
 * and the people they were in contact with.
 */

using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace CovidAppClient
{
    public partial class Form1 : Form
    {
        CovidApi.ICases cov = new CovidApi.CasesClient();
        private List<int> ccs = new();

        public Form1()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Adds the cc in the textbos to a list
        /// The list contains the ccs that were in contact with the infected case
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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

        /// <summary>
        /// This button submits the data to the SOAP service that will insert the data into the database
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void btnSubmit_Click(object sender, EventArgs e)
        {
            if(!int.TryParse(txtInf.Text, out int cc))
            {
                MessageBox.Show("Invalid cc!");
            }
            else
            {
                await cov.InsertDetectedCaseAsync(cc);

                if (ccs.Count > 0)
                {
                    await cov.InsertUsersInContactAsync(ccs.ToArray(), cc);
                }
                MessageBox.Show("Done!");
            }
            txtCont.Text = string.Empty;
            txtInf.Text = string.Empty;
            ccs.Clear();
        }
    }
}
