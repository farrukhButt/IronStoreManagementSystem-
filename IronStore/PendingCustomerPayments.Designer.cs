namespace IronStore
{
    partial class PendingCustomerPayments
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
            this.MinimumPaymentField = new System.Windows.Forms.NumericUpDown();
            this.label = new System.Windows.Forms.Label();
            this.LoadButton = new System.Windows.Forms.Button();
            this.loadingLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MinimumPaymentField)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dataGridView1.Location = new System.Drawing.Point(29, 122);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(773, 296);
            this.dataGridView1.TabIndex = 3;
            // 
            // MinimumPaymentField
            // 
            this.MinimumPaymentField.Location = new System.Drawing.Point(204, 26);
            this.MinimumPaymentField.Maximum = new decimal(new int[] {
            10000000,
            0,
            0,
            0});
            this.MinimumPaymentField.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.MinimumPaymentField.Name = "MinimumPaymentField";
            this.MinimumPaymentField.Size = new System.Drawing.Size(120, 20);
            this.MinimumPaymentField.TabIndex = 5;
            this.MinimumPaymentField.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label
            // 
            this.label.AutoSize = true;
            this.label.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label.Location = new System.Drawing.Point(42, 26);
            this.label.Name = "label";
            this.label.Size = new System.Drawing.Size(138, 20);
            this.label.TabIndex = 4;
            this.label.Text = "Minimum Payment";
            // 
            // LoadButton
            // 
            this.LoadButton.BackColor = System.Drawing.Color.Blue;
            this.LoadButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LoadButton.ForeColor = System.Drawing.Color.White;
            this.LoadButton.Location = new System.Drawing.Point(379, 19);
            this.LoadButton.Name = "LoadButton";
            this.LoadButton.Size = new System.Drawing.Size(106, 28);
            this.LoadButton.TabIndex = 10;
            this.LoadButton.Text = "Load";
            this.LoadButton.UseVisualStyleBackColor = false;
            this.LoadButton.Click += new System.EventHandler(this.LoadButton_Click);
            // 
            // loadingLabel
            // 
            this.loadingLabel.AutoSize = true;
            this.loadingLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.loadingLabel.Location = new System.Drawing.Point(42, 80);
            this.loadingLabel.Name = "loadingLabel";
            this.loadingLabel.Size = new System.Drawing.Size(205, 20);
            this.loadingLabel.TabIndex = 11;
            this.loadingLabel.Text = "Please wait report is loading";
            this.loadingLabel.Visible = false;
            // 
            // PendingCustomerPayments
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(880, 483);
            this.Controls.Add(this.loadingLabel);
            this.Controls.Add(this.LoadButton);
            this.Controls.Add(this.MinimumPaymentField);
            this.Controls.Add(this.label);
            this.Controls.Add(this.dataGridView1);
            this.Name = "PendingCustomerPayments";
            this.Text = "PendingCustomerPayments";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MinimumPaymentField)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.NumericUpDown MinimumPaymentField;
        private System.Windows.Forms.Label label;
        private System.Windows.Forms.Button LoadButton;
        private System.Windows.Forms.Label loadingLabel;
    }
}