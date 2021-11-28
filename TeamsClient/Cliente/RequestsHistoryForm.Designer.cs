namespace Cliente
{
    partial class RequestsHistoryForm
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
            this.dgvCompletedRequests = new System.Windows.Forms.DataGridView();
            this.btnViewProducts = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCompletedRequests)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvCompletedRequests
            // 
            this.dgvCompletedRequests.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCompletedRequests.Dock = System.Windows.Forms.DockStyle.Left;
            this.dgvCompletedRequests.Location = new System.Drawing.Point(0, 0);
            this.dgvCompletedRequests.Name = "dgvCompletedRequests";
            this.dgvCompletedRequests.RowTemplate.Height = 25;
            this.dgvCompletedRequests.Size = new System.Drawing.Size(440, 307);
            this.dgvCompletedRequests.TabIndex = 0;
            // 
            // btnViewProducts
            // 
            this.btnViewProducts.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnViewProducts.Location = new System.Drawing.Point(440, 0);
            this.btnViewProducts.Name = "btnViewProducts";
            this.btnViewProducts.Size = new System.Drawing.Size(171, 51);
            this.btnViewProducts.TabIndex = 1;
            this.btnViewProducts.Text = "Ver Produtos";
            this.btnViewProducts.UseVisualStyleBackColor = true;
            this.btnViewProducts.Click += new System.EventHandler(this.btnViewProducts_Click);
            // 
            // RequestsHistoryForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(611, 307);
            this.Controls.Add(this.btnViewProducts);
            this.Controls.Add(this.dgvCompletedRequests);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "RequestsHistoryForm";
            this.Text = "RequestsHistoryForm";
            ((System.ComponentModel.ISupportInitialize)(this.dgvCompletedRequests)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvCompletedRequests;
        private System.Windows.Forms.Button btnViewProducts;
    }
}