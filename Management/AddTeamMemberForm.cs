using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Logic.Repositories;
using Logic.Entities;

namespace Management
{
    public partial class AddTeamMemberForm : Form
    {
        private int _teamId;

        public AddTeamMemberForm(int teamId)
        {
            InitializeComponent();
            _teamId = teamId;
        }

        private async void btnAddMember_Click(object sender, EventArgs e)
        {
            TeamMemberModel member = new()
            {
                Name = txtName.Text,
                Surname = txtSurname.Text,
                Organization = cbOrganization.Text
            };

            await TeamsManagement.AddMemberToTeam(_teamId, member);

            MessageBox.Show("Member added successfully!");

            Close();
        }
    }
}
