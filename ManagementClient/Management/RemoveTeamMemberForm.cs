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
    public partial class RemoveTeamMemberForm : Form
    {
        private int teamId;

        public RemoveTeamMemberForm(int teamId)
        {
            InitializeComponent();
            FillCB(teamId);
        }

        /// <summary>
        /// Fills the datagridview with the team members of a team
        /// </summary>
        /// <param name="teamId"></param>
        private async void FillCB(int teamId)
        {
            var members = await TeamsManagement.GetTeamMembersAsync(teamId);
            BindingSource bs = new();
            bs.DataSource = members.Select(member => $"{member.Id}: {member.Name} {member.Surname} | {member.Organization}");
            cbMembers.DataSource = bs;
        }

        /// <summary>
        /// Gets the id from a string
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        private int GetIdFromText(string id)
        {
            string output = string.Empty;
            foreach(var c in id)
            {
                if(c == ':')
                {
                    return int.Parse(output);
                }
                output += c;
            }
            throw new Exception();
        }

        /// <summary>
        /// Removes a team member
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void btnRemove_Click(object sender, EventArgs e)
        {
            int id = GetIdFromText(cbMembers.Text);
            await TeamsManagement.RemoveMemberFromTeam(id);

            MessageBox.Show("User removed successfully!");
            Close();
        }
    }
}
