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