namespace IronStore
{
    partial class OrderExtras
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
            this.ReturnOrderButton = new System.Windows.Forms.Button();
            this.OrderDetailButton = new System.Windows.Forms.Button();
            this.OrderIdField = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 20);
            this.label1.TabIndex = 2;
            this.label1.Text = "Order Id";
            // 
            // ReturnOrderButton
            // 
            this.ReturnOrderButton.BackColor = System.Drawing.Color.Blue;
            this.ReturnOrderButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ReturnOrderButton.ForeColor = System.Drawing.Color.White;
            this.ReturnOrderButton.Location = new System.Drawing.Point(288, 257);
            this.ReturnOrderButton.Name = "ReturnOrderButton";
            this.ReturnOrderButton.Size = new System.Drawing.Size(143, 28);
            this.ReturnOrderButton.TabIndex = 10;
            this.ReturnOrderButton.Text = "Return Order";
            this.ReturnOrderButton.UseVisualStyleBackColor = false;
            this.ReturnOrderButton.Click += new System.EventHandler(this.ReturnOrderButton_Click);
            // 
            // OrderDetailButton
            // 
            this.OrderDetailButton.BackColor = System.Drawing.Color.Blue;
            this.OrderDetailButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.OrderDetailButton.ForeColor = System.Drawing.Color.White;
            this.OrderDetailButton.Location = new System.Drawing.Point(437, 257);
            this.OrderDetailButton.Name = "OrderDetailButton";
            this.OrderDetailButton.Size = new System.Drawing.Size(170, 28);
            this.OrderDetailButton.TabIndex = 11;
            this.OrderDetailButton.Text = "View Order Detail";
            this.OrderDetailButton.UseVisualStyleBackColor = false;
            this.OrderDetailButton.Click += new System.EventHandler(this.OrderDetailButton_Click);
            // 
            // OrderIdField
            // 
            this.OrderIdField.Location = new System.Drawing.Point(102, 21);
            this.OrderIdField.Name = "OrderIdField";
            this.OrderIdField.Size = new System.Drawing.Size(119, 20);
            this.OrderIdField.TabIndex = 12;
            // 
            // OrderExtras
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(619, 297);
            this.Controls.Add(this.OrderIdField);
            this.Controls.Add(this.OrderDetailButton);
            this.Controls.Add(this.ReturnOrderButton);
            this.Controls.Add(this.label1);
            this.Name = "OrderExtras";
            this.Text = "OrderExtras";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button ReturnOrderButton;
        private System.Windows.Forms.Button OrderDetailButton;
        private System.Windows.Forms.TextBox OrderIdField;
    }
}