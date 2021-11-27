namespace Management
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panelMenu = new System.Windows.Forms.Panel();
            this.button4 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.btnPendingRequestsMenu = new System.Windows.Forms.Button();
            this.btnTeams = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panelTop = new System.Windows.Forms.Panel();
            this.lblCurrentForm = new System.Windows.Forms.Label();
            this.panelForm = new System.Windows.Forms.Panel();
            this.panelMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panelTop.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelMenu
            // 
            this.panelMenu.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.panelMenu.Controls.Add(this.button4);
            this.panelMenu.Controls.Add(this.button3);
            this.panelMenu.Controls.Add(this.btnPendingRequestsMenu);
            this.panelMenu.Controls.Add(this.btnTeams);
            this.panelMenu.Controls.Add(this.pictureBox1);
            this.panelMenu.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelMenu.Location = new System.Drawing.Point(0, 0);
            this.panelMenu.Name = "panelMenu";
            this.panelMenu.Size = new System.Drawing.Size(173, 450);
            this.panelMenu.TabIndex = 0;
            // 
            // button4
            // 
            this.button4.Dock = System.Windows.Forms.DockStyle.Top;
            this.button4.Location = new System.Drawing.Point(0, 278);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(173, 58);
            this.button4.TabIndex = 4;
            this.button4.Text = "button4";
            this.button4.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            this.button3.Dock = System.Windows.Forms.DockStyle.Top;
            this.button3.Location = new System.Drawing.Point(0, 220);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(173, 58);
            this.button3.TabIndex = 3;
            this.button3.Text = "button3";
            this.button3.UseVisualStyleBackColor = true;
            // 
            // btnPendingRequestsMenu
            // 
            this.btnPendingRequestsMenu.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnPendingRequestsMenu.Location = new System.Drawing.Point(0, 162);
            this.btnPendingRequestsMenu.Name = "btnPendingRequestsMenu";
            this.btnPendingRequestsMenu.Size = new System.Drawing.Size(173, 58);
            this.btnPendingRequestsMenu.TabIndex = 2;
            this.btnPendingRequestsMenu.Text = "Pending Requests";
            this.btnPendingRequestsMenu.UseVisualStyleBackColor = true;
            this.btnPendingRequestsMenu.Click += new System.EventHandler(this.btnPendingRequestsMenu_Click);
            // 
            // btnTeams
            // 
            this.btnTeams.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnTeams.Location = new System.Drawing.Point(0, 104);
            this.btnTeams.Name = "btnTeams";
            this.btnTeams.Size = new System.Drawing.Size(173, 58);
            this.btnTeams.TabIndex = 1;
            this.btnTeams.Text = "Teams";
            this.btnTeams.UseVisualStyleBackColor = true;
            this.btnTeams.Click += new System.EventHandler(this.btnTeams_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.pictureBox1.Image = global::Management.Properties.Resources.anpc_logo;
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(173, 104);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // panelTop
            // 
            this.panelTop.Controls.Add(this.lblCurrentForm);
            this.panelTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTop.Location = new System.Drawing.Point(173, 0);
            this.panelTop.Name = "panelTop";
            this.panelTop.Size = new System.Drawing.Size(627, 104);
            this.panelTop.TabIndex = 1;
            // 
            // lblCurrentForm
            // 
            this.lblCurrentForm.AutoSize = true;
            this.lblCurrentForm.Location = new System.Drawing.Point(15, 46);
            this.lblCurrentForm.Name = "lblCurrentForm";
            this.lblCurrentForm.Size = new System.Drawing.Size(38, 15);
            this.lblCurrentForm.TabIndex = 0;
            this.lblCurrentForm.Text = "label1";
            // 
            // panelForm
            // 
            this.panelForm.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelForm.Location = new System.Drawing.Point(173, 104);
            this.panelForm.Name = "panelForm";
            this.panelForm.Size = new System.Drawing.Size(627, 346);
            this.panelForm.TabIndex = 2;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.panelForm);
            this.Controls.Add(this.panelTop);
            this.Controls.Add(this.panelMenu);
            this.Name = "Form1";
            this.Text = "Form1";
            this.panelMenu.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panelTop.ResumeLayout(false);
            this.panelTop.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelMenu;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button btnPendingRequestsMenu;
        private System.Windows.Forms.Button btnTeams;
        private System.Windows.Forms.Panel panelTop;
        private System.Windows.Forms.Panel panelForm;
        private System.Windows.Forms.Label lblCurrentForm;
    }
}
