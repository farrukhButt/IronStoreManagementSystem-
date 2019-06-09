namespace IronStore
{
    partial class ViewCustomerPayment
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
            this.AddCustomerButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.CustomerDropDown = new System.Windows.Forms.ComboBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.RemainingDuesField = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.RemainingDuesField)).BeginInit();
            this.SuspendLayout();
            // 
            // AddCustomerButton
            // 
            this.AddCustomerButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.AddCustomerButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AddCustomerButton.ForeColor = System.Drawing.Color.White;
            this.AddCustomerButton.Location = new System.Drawing.Point(354, 12);
            this.AddCustomerButton.Name = "AddCustomerButton";
            this.AddCustomerButton.Size = new System.Drawing.Size(198, 32);
            this.AddCustomerButton.TabIndex = 45;
            this.AddCustomerButton.Text = "Load Customer";
            this.AddCustomerButton.UseVisualStyleBackColor = false;
            this.AddCustomerButton.Click += new System.EventHandler(this.AddCustomerButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(13, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(78, 20);
            this.label1.TabIndex = 44;
            this.label1.Text = "Customer";
            // 
            // CustomerDropDown
            // 
            this.CustomerDropDown.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CustomerDropDown.FormattingEnabled = true;
            this.CustomerDropDown.Location = new System.Drawing.Point(146, 23);
            this.CustomerDropDown.Name = "CustomerDropDown";
            this.CustomerDropDown.Size = new System.Drawing.Size(171, 21);
            this.CustomerDropDown.TabIndex = 43;
            
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dataGridView1.Location = new System.Drawing.Point(17, 103);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(726, 220);
            this.dataGridView1.TabIndex = 46;
            // 
            // RemainingDuesField
            // 
            this.RemainingDuesField.Enabled = false;
            this.RemainingDuesField.Location = new System.Drawing.Point(146, 65);
            this.RemainingDuesField.Maximum = new decimal(new int[] {
            10000000,
            0,
            0,
            0});
            this.RemainingDuesField.Minimum = new decimal(new int[] {
            10000000,
            0,
            0,
            -2147483648});
            this.RemainingDuesField.Name = "RemainingDuesField";
            this.RemainingDuesField.Size = new System.Drawing.Size(171, 20);
            this.RemainingDuesField.TabIndex = 47;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(13, 65);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(127, 20);
            this.label2.TabIndex = 48;
            this.label2.Text = "Remaining Dues";
            // 
            // ViewCustomerPayment
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(775, 344);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.RemainingDuesField);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.AddCustomerButton);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.CustomerDropDown);
            this.Name = "ViewCustomerPayment";
            this.Text = "ViewCustomerPayment";
            this.Load += new System.EventHandler(this.ViewCustomerPayment_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.RemainingDuesField)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button AddCustomerButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox CustomerDropDown;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.NumericUpDown RemainingDuesField;
        private System.Windows.Forms.Label label2;
    }
}