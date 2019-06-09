namespace IronStore
{
    partial class PendingOrders
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.MarkOrderButton = new System.Windows.Forms.Button();
            this.CompleteOrderButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dataGridView1.Location = new System.Drawing.Point(21, 108);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(915, 388);
            this.dataGridView1.TabIndex = 12;
            // 
            // MarkOrderButton
            // 
            this.MarkOrderButton.BackColor = System.Drawing.Color.Blue;
            this.MarkOrderButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MarkOrderButton.ForeColor = System.Drawing.Color.White;
            this.MarkOrderButton.Location = new System.Drawing.Point(322, 527);
            this.MarkOrderButton.Name = "MarkOrderButton";
            this.MarkOrderButton.Size = new System.Drawing.Size(212, 28);
            this.MarkOrderButton.TabIndex = 13;
            this.MarkOrderButton.Text = "Mark Order as Delivered";
            this.MarkOrderButton.UseVisualStyleBackColor = false;
            this.MarkOrderButton.Click += new System.EventHandler(this.MarkOrderButton_Click);
            // 
            // CompleteOrderButton
            // 
            this.CompleteOrderButton.BackColor = System.Drawing.Color.Blue;
            this.CompleteOrderButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CompleteOrderButton.ForeColor = System.Drawing.Color.White;
            this.CompleteOrderButton.Location = new System.Drawing.Point(614, 527);
            this.CompleteOrderButton.Name = "CompleteOrderButton";
            this.CompleteOrderButton.Size = new System.Drawing.Size(229, 28);
            this.CompleteOrderButton.TabIndex = 14;
            this.CompleteOrderButton.Text = "View Complete Order";
            this.CompleteOrderButton.UseVisualStyleBackColor = false;
            this.CompleteOrderButton.Click += new System.EventHandler(this.CompleteOrderButton_Click);
            // 
            // PendingOrders
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(993, 582);
            this.Controls.Add(this.CompleteOrderButton);
            this.Controls.Add(this.MarkOrderButton);
            this.Controls.Add(this.dataGridView1);
            this.Name = "PendingOrders";
            this.Text = "PendingOrders";
            this.Load += new System.EventHandler(this.PendingOrders_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button MarkOrderButton;
        private System.Windows.Forms.Button CompleteOrderButton;
    }
}