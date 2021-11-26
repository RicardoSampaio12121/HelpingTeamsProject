namespace Management
{
    partial class TeamMembersForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.dgvTeamMembers = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTeamMembers)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvTeamMembers
            // 
            this.dgvTeamMembers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTeamMembers.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvTeamMembers.Location = new System.Drawing.Point(0, 0);
            this.dgvTeamMembers.Name = "dgvTeamMembers";
            this.dgvTeamMembers.RowTemplate.Height = 25;
            this.dgvTeamMembers.Size = new System.Drawing.Size(516, 278);
            this.dgvTeamMembers.TabIndex = 0;
            // 
            // TeamMembersForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(516, 278);
            this.Controls.Add(this.dgvTeamMembers);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Name = "TeamMembersForm";
            this.Text = "TeamMembersForm";
            ((System.ComponentModel.ISupportInitialize)(this.dgvTeamMembers)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvTeamMembers;
    }
}