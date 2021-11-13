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
using FastMember;

namespace Management
{
    public partial class TeamsForm : Form
    {
        public TeamsForm()
        {
            InitializeComponent();
            LoadDataGridView();
        }

        private async void LoadDataGridView()
        {
            var content = await TeamsManagement.GetTeamsAsync();

            DataTable table = new();

            table = content.ToDataTable();

            dgvTeams.DataSource = table;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            



        }
    }
}
