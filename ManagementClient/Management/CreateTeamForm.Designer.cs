namespace Management
{
    partial class CreateTeamForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.txtLocation = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txtSurname = new System.Windows.Forms.TextBox();
            this.txtName = new System.Windows.Forms.TextBox();
            this.cbOrganization = new System.Windows.Forms.ComboBox();
            this.btnConfirmMember = new System.Windows.Forms.Button();
            this.btnCreateTean = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(16, 49);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(72, 21);
            this.label1.TabIndex = 0;
            this.label1.Text = "Location:";
            // 
            // txtLocation
            // 
            this.txtLocation.Location = new System.Drawing.Point(94, 49);
            this.txtLocation.Name = "txtLocation";
            this.txtLocation.Size = new System.Drawing.Size(237, 23);
            this.txtLocation.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label2.Location = new System.Drawing.Point(12, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(84, 40);
            this.label2.TabIndex = 2;
            this.label2.Text = "Team";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label3.Location = new System.Drawing.Point(12, 84);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(137, 40);
            this.label3.TabIndex = 3;
            this.label3.Text = "Members";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label4.Location = new System.Drawing.Point(13, 124);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(55, 21);
            this.label4.TabIndex = 4;
            this.label4.Text = "Name:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label5.Location = new System.Drawing.Point(12, 156);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(76, 21);
            this.label5.TabIndex = 5;
            this.label5.Text = "Surname:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label6.Location = new System.Drawing.Point(12, 188);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(103, 21);
            this.label6.TabIndex = 6;
            this.label6.Text = "Organization:";
            // 
            // txtSurname
            // 
            this.txtSurname.Location = new System.Drawing.Point(116, 156);
            this.txtSurname.Name = "txtSurname";
            this.txtSurname.Size = new System.Drawing.Size(215, 23);
            this.txtSurname.TabIndex = 3;
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(116, 127);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(215, 23);
            this.txtName.TabIndex = 2;
            // 
            // cbOrganization
            // 
            this.cbOrganization.FormattingEnabled = true;
            this.cbOrganization.Items.AddRange(new object[] {
            "PSP",
            "GNR",
            "ANEPC"});
            this.cbOrganization.Location = new System.Drawing.Point(116, 190);
            this.cbOrganization.Name = "cbOrganization";
            this.cbOrganization.Size = new System.Drawing.Size(215, 23);
            this.cbOrganization.TabIndex = 4;
            // 
            // btnConfirmMember
            // 
            this.btnConfirmMember.Location = new System.Drawing.Point(174, 235);
            this.btnConfirmMember.Name = "btnConfirmMember";
            this.btnConfirmMember.Size = new System.Drawing.Size(157, 38);
            this.btnConfirmMember.TabIndex = 6;
            this.btnConfirmMember.Text = "Confirm Member";
            this.btnConfirmMember.UseVisualStyleBackColor = true;
            this.btnConfirmMember.Click += new System.EventHandler(this.btnConfirmMember_Click);
            // 
            // btnCreateTean
            // 
            this.btnCreateTean.Location = new System.Drawing.Point(13, 235);
            this.btnCreateTean.Name = "btnCreateTean";
            this.btnCreateTean.Size = new System.Drawing.Size(157, 38);
            this.btnCreateTean.TabIndex = 5;
            this.btnCreateTean.Text = "Create Team";
            this.btnCreateTean.UseVisualStyleBackColor = true;
            this.btnCreateTean.Click += new System.EventHandler(this.btnCreateTean_Click);
            // 
            // CreateTeamForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(343, 293);
            this.Controls.Add(this.btnCreateTean);
            this.Controls.Add(this.btnConfirmMember);
            this.Controls.Add(this.cbOrganization);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.txtSurname);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtLocation);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "CreateTeamForm";
            this.Text = "CreateTeamForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtLocation;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtSurname;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.ComboBox cbOrganization;
        private System.Windows.Forms.Button btnConfirmMember;
        private System.Windows.Forms.Button btnCreateTean;
    }
}