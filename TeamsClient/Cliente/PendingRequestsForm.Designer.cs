namespace Cliente
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
            this.btnProducts = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPendingRequests)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvPendingRequests
            // 
            this.dgvPendingRequests.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPendingRequests.Location = new System.Drawing.Point(12, 12);
            this.dgvPendingRequests.Name = "dgvPendingRequests";
            this.dgvPendingRequests.RowTemplate.Height = 25;
            this.dgvPendingRequests.Size = new System.Drawing.Size(450, 283);
            this.dgvPendingRequests.TabIndex = 0;
            // 
            // btnProducts
            // 
            this.btnProducts.Location = new System.Drawing.Point(468, 12);
            this.btnProducts.Name = "btnProducts";
            this.btnProducts.Size = new System.Drawing.Size(131, 56);
            this.btnProducts.TabIndex = 1;
            this.btnProducts.Text = "View products";
            this.btnProducts.UseVisualStyleBackColor = true;
            this.btnProducts.Click += new System.EventHandler(this.btnProducts_Click);
            // 
            // PendingRequestsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(611, 307);
            this.Controls.Add(this.btnProducts);
            this.Controls.Add(this.dgvPendingRequests);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "PendingRequestsForm";
            this.Text = "PendingRequestsForm";
            ((System.ComponentModel.ISupportInitialize)(this.dgvPendingRequests)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvPendingRequests;
        private System.Windows.Forms.Button btnProducts;
    }
}