namespace Cliente
{
    partial class CompletedRequestProductsForm
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
            this.dgvCompletedRequestProducts = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCompletedRequestProducts)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvCompletedRequestProducts
            // 
            this.dgvCompletedRequestProducts.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCompletedRequestProducts.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvCompletedRequestProducts.Location = new System.Drawing.Point(0, 0);
            this.dgvCompletedRequestProducts.Name = "dgvCompletedRequestProducts";
            this.dgvCompletedRequestProducts.RowTemplate.Height = 25;
            this.dgvCompletedRequestProducts.Size = new System.Drawing.Size(429, 219);
            this.dgvCompletedRequestProducts.TabIndex = 0;
            // 
            // CompletedRequestProductsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(429, 219);
            this.Controls.Add(this.dgvCompletedRequestProducts);
            this.Name = "CompletedRequestProductsForm";
            this.Text = "CompletedRequestProductsForm";
            ((System.ComponentModel.ISupportInitialize)(this.dgvCompletedRequestProducts)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvCompletedRequestProducts;
    }
}