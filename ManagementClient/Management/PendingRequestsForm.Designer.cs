namespace Management
{
    partial class PendingRequestsForm
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
            this.dgvPendingRequests = new System.Windows.Forms.DataGridView();
            this.btnInfo = new System.Windows.Forms.Button();
            this.btnAcceptRequest = new System.Windows.Forms.Button();
            this.btnDeclineRequest = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPendingRequests)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvPendingRequests
            // 
            this.dgvPendingRequests.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPendingRequests.Dock = System.Windows.Forms.DockStyle.Left;
            this.dgvPendingRequests.Location = new System.Drawing.Point(0, 0);
            this.dgvPendingRequests.Name = "dgvPendingRequests";
            this.dgvPendingRequests.RowTemplate.Height = 25;
            this.dgvPendingRequests.Size = new System.Drawing.Size(437, 307);
            this.dgvPendingRequests.TabIndex = 0;
            // 
            // btnInfo
            // 
            this.btnInfo.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnInfo.Location = new System.Drawing.Point(437, 0);
            this.btnInfo.Name = "btnInfo";
            this.btnInfo.Size = new System.Drawing.Size(174, 55);
            this.btnInfo.TabIndex = 1;
            this.btnInfo.Text = "View Products";
            this.btnInfo.UseVisualStyleBackColor = true;
            this.btnInfo.Click += new System.EventHandler(this.btnInfo_Click);
            // 
            // btnAcceptRequest
            // 
            this.btnAcceptRequest.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnAcceptRequest.Location = new System.Drawing.Point(437, 55);
            this.btnAcceptRequest.Name = "btnAcceptRequest";
            this.btnAcceptRequest.Size = new System.Drawing.Size(174, 55);
            this.btnAcceptRequest.TabIndex = 2;
            this.btnAcceptRequest.Text = "Accept Request";
            this.btnAcceptRequest.UseVisualStyleBackColor = true;
            this.btnAcceptRequest.Click += new System.EventHandler(this.btnAcceptRequest_Click);
            // 
            // btnDeclineRequest
            // 
            this.btnDeclineRequest.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnDeclineRequest.Location = new System.Drawing.Point(437, 110);
            this.btnDeclineRequest.Name = "btnDeclineRequest";
            this.btnDeclineRequest.Size = new System.Drawing.Size(174, 55);
            this.btnDeclineRequest.TabIndex = 3;
            this.btnDeclineRequest.Text = "Decline Request";
            this.btnDeclineRequest.UseVisualStyleBackColor = true;
            this.btnDeclineRequest.Click += new System.EventHandler(this.btnDeclineRequest_Click);
            // 
            // PendingRequestsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(611, 307);
            this.Controls.Add(this.btnDeclineRequest);
            this.Controls.Add(this.btnAcceptRequest);
            this.Controls.Add(this.btnInfo);
            this.Controls.Add(this.dgvPendingRequests);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "PendingRequestsForm";
            this.Text = "PendingRequestsForm";
            ((System.ComponentModel.ISupportInitialize)(this.dgvPendingRequests)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvPendingRequests;
        private System.Windows.Forms.Button btnInfo;
        private System.Windows.Forms.Button btnAcceptRequest;
        private System.Windows.Forms.Button btnDeclineRequest;
    }
}