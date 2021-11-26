namespace Cliente
{
    partial class MakeRequestForm
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
            this.dgvProducts = new System.Windows.Forms.DataGridView();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnRequest = new System.Windows.Forms.Button();
            this.btnSubmit = new System.Windows.Forms.Button();
            this.txtTeamId = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProducts)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvProducts
            // 
            this.dgvProducts.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvProducts.Location = new System.Drawing.Point(12, 12);
            this.dgvProducts.Name = "dgvProducts";
            this.dgvProducts.RowTemplate.Height = 25;
            this.dgvProducts.Size = new System.Drawing.Size(439, 283);
            this.dgvProducts.TabIndex = 0;
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(457, 12);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(151, 53);
            this.btnAdd.TabIndex = 1;
            this.btnAdd.Text = "Adicionar";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnRequest
            // 
            this.btnRequest.Location = new System.Drawing.Point(457, 71);
            this.btnRequest.Name = "btnRequest";
            this.btnRequest.Size = new System.Drawing.Size(151, 53);
            this.btnRequest.TabIndex = 2;
            this.btnRequest.Text = "Request new product";
            this.btnRequest.UseVisualStyleBackColor = true;
            // 
            // btnSubmit
            // 
            this.btnSubmit.Location = new System.Drawing.Point(457, 130);
            this.btnSubmit.Name = "btnSubmit";
            this.btnSubmit.Size = new System.Drawing.Size(151, 53);
            this.btnSubmit.TabIndex = 3;
            this.btnSubmit.Text = "Submit";
            this.btnSubmit.UseVisualStyleBackColor = true;
            this.btnSubmit.Click += new System.EventHandler(this.btnSubmit_Click);
            // 
            // txtTeamId
            // 
            this.txtTeamId.Location = new System.Drawing.Point(461, 190);
            this.txtTeamId.Name = "txtTeamId";
            this.txtTeamId.Size = new System.Drawing.Size(100, 23);
            this.txtTeamId.TabIndex = 4;
            // 
            // MakeRequestForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(611, 307);
            this.Controls.Add(this.txtTeamId);
            this.Controls.Add(this.btnSubmit);
            this.Controls.Add(this.btnRequest);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.dgvProducts);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "MakeRequestForm";
            this.Text = "MakeRequestForm";
            ((System.ComponentModel.ISupportInitialize)(this.dgvProducts)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvProducts;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnRequest;
        private System.Windows.Forms.Button btnSubmit;
        private System.Windows.Forms.TextBox txtTeamId;
    }
}