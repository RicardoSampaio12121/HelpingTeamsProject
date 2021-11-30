using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Logic.Entities;
using Logic.Repositories;

namespace Management
{
    public partial class CreateTeamForm : Form
    {
        public CreateTeamForm()
        {
            InitializeComponent();
        }

        private List<TeamMemberModel> members = new();

        /// <summary>
        /// Adds a member to the list of members to add to the team
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnConfirmMember_Click(object sender, EventArgs e)
        {
            if(txtName.Text == "" || txtSurname.Text == "" || cbOrganization.Text == "")
            {
                MessageBox.Show("One or more required fields are not filled.");
            }
            else
            {
                members.Add(new TeamMemberModel()
                {
                    Name = txtName.Text,
                    Surname = txtSurname.Text,
                    Organization = cbOrganization.Text
                });
            }
        }

        /// <summary>
        /// Submits the information needed to create the team
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void btnCreateTean_Click(object sender, EventArgs e)
        {
            if(txtLocation.Text == "")
            {
                MessageBox.Show("The location field must be filled.");
            }
            else if (members.Any())
            {
                CreateTeamModel team = new()
                {
                    Location = txtLocation.Text
                };

                await TeamsManagement.CreateTeamWithMembers(team, members);
            }
            else if (!members.Any())
            {
                CreateTeamModel team = new()
                {
                    Location = txtLocation.Text
                };

                await TeamsManagement.CreateTeam(team);

                MessageBox.Show($"Team located in {team.Location} created successfully");
                this.Close();
            }
        }
    }
}