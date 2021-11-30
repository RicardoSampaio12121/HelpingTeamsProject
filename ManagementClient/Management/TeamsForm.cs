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

        /// <summary>
        /// Fills the datagridview with all the teams
        /// </summary>
        private async void LoadDataGridView()
        {
            var content = await TeamsManagement.GetTeamsAsync();

            DataTable table = new();

            table = content.ToDataTable();

            dgvTeams.DataSource = table;
        }

        /// <summary>
        /// Shows the team members of a specific team
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnShowTeamMembers_Click(object sender, EventArgs e)
        {
            int index = dgvTeams.SelectedRows[0].Index;
            var row = dgvTeams.Rows[index];
            int teamId = int.Parse(row.Cells[0].Value.ToString());

            Form teamMembersForm = new TeamMembersForm(teamId);
            teamMembersForm.Show();
        }

        /// <summary>
        /// Creates a new team
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCreateTeam_Click(object sender, EventArgs e)
        {
            Form CreateTeamForm = new CreateTeamForm();
            CreateTeamForm.Show();
        }

        /// <summary>
        /// Adds a member to an existing team
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAddMember_Click(object sender, EventArgs e)
        {
            int index = dgvTeams.SelectedRows[0].Index;
            var row = dgvTeams.Rows[index];
            int teamId = int.Parse(row.Cells[0].Value.ToString());

            Form addTeamMemberForm = new AddTeamMemberForm(teamId);
            addTeamMemberForm.Show();
        }

        /// <summary>
        /// Removes a member from a team
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnRemoveMember_Click(object sender, EventArgs e)
        {
            int index = dgvTeams.SelectedRows[0].Index;
            var row = dgvTeams.Rows[index];
            int teamId = int.Parse(row.Cells[0].Value.ToString());

            Form removeTeamMemberForm = new RemoveTeamMemberForm(teamId);
            removeTeamMemberForm.Show();
        }

        /// <summary>
        /// Removes a team
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void btnRemoveTeam_Click(object sender, EventArgs e)
        {
            int index = dgvTeams.SelectedRows[0].Index;
            var row = dgvTeams.Rows[index];
            int teamId = int.Parse(row.Cells[0].Value.ToString());

            //TODO: Add something like a personalized form to ask the user if he's sure he wants to delete the entire team

            await TeamsManagement.RemoveTeam(teamId);

            MessageBox.Show("Team removed successfully");
            LoadDataGridView();
        }
    }
}
