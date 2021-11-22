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

        private void btnShowTeamMembers_Click(object sender, EventArgs e)
        {
            int index = dgvTeams.SelectedRows[0].Index;
            var row = dgvTeams.Rows[index];
            int teamId = int.Parse(row.Cells[0].Value.ToString());

            Form teamMembersForm = new TeamMembersForm(teamId);
            teamMembersForm.Show();
        }

        private void btnCreateTeam_Click(object sender, EventArgs e)
        {
            Form CreateTeamForm = new CreateTeamForm();
            CreateTeamForm.Show();
        }

        private void btnAddMember_Click(object sender, EventArgs e)
        {
            int index = dgvTeams.SelectedRows[0].Index;
            var row = dgvTeams.Rows[index];
            int teamId = int.Parse(row.Cells[0].Value.ToString());

            Form addTeamMemberForm = new AddTeamMemberForm(teamId);
            addTeamMemberForm.Show();
        }
    }
}
