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


namespace Management
{
    public partial class TeamMembersForm : Form
    {
        public TeamMembersForm(int teamId)
        {
            InitializeComponent();
            LoadDataGridView(teamId);
        }

        private async void LoadDataGridView(int teamId)
        {
            var content = await TeamsManagement.GetTeamMembersAsync(teamId);
            DataTable data = new();

            data = content.ToDataTable();

            dgvTeamMembers.DataSource = data;
        }
    }
}
