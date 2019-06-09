namespace IronStore
{
    partial class OrderByDate
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
            this.StartDateField = new System.Windows.Forms.DateTimePicker();
            this.EndDateField = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.LoadButton = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.CompleteOrderButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // StartDateField
            // 
            this.StartDateField.Location = new System.Drawing.Point(119, 24);
            this.StartDateField.Name = "StartDateField";
            this.StartDateField.Size = new System.Drawing.Size(200, 20);
            this.StartDateField.TabIndex = 0;
            // 
            // EndDateField
            // 
            this.EndDateField.Location = new System.Drawing.Point(507, 24);
            this.EndDateField.Name = "EndDateField";
            this.EndDateField.Size = new System.Drawing.Size(200, 20);
            this.EndDateField.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(83, 20);
            this.label1.TabIndex = 2;
            this.label1.Text = "Start Date";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(389, 25);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(77, 20);
            this.label2.TabIndex = 3;
            this.label2.Text = "End Date";
            // 
            // LoadButton
            // 
            this.LoadButton.BackColor = System.Drawing.Color.Blue;
            this.LoadButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LoadButton.ForeColor = System.Drawing.Color.White;
            this.LoadButton.Location = new System.Drawing.Point(747, 17);
            this.LoadButton.Name = "LoadButton";
            this.LoadButton.Size = new System.Drawing.Size(106, 28);
            this.LoadButton.TabIndex = 10;
            this.LoadButton.Text = "Load";
            this.LoadButton.UseVisualStyleBackColor = false;
            this.LoadButton.Click += new System.EventHandler(this.LoadButton_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dataGridView1.Location = new System.Drawing.Point(29, 81);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(915, 376);
            this.dataGridView1.TabIndex = 11;
            // 
            // CompleteOrderButton
            // 
            this.CompleteOrderButton.BackColor = System.Drawing.Color.Blue;
            this.CompleteOrderButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CompleteOrderButton.ForeColor = System.Drawing.Color.White;
            this.CompleteOrderButton.Location = new System.Drawing.Point(634, 502);
            this.CompleteOrderButton.Name = "CompleteOrderButton";
            this.CompleteOrderButton.Size = new System.Drawing.Size(229, 28);
            this.CompleteOrderButton.TabIndex = 12;
            this.CompleteOrderButton.Text = "View Complete Order";
            this.CompleteOrderButton.UseVisualStyleBackColor = false;
            this.CompleteOrderButton.Click += new System.EventHandler(this.CompleteOrderButton_Click);
            // 
            // OrderByDate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(988, 568);
            this.Controls.Add(this.CompleteOrderButton);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.LoadButton);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.EndDateField);
            this.Controls.Add(this.StartDateField);
            this.Name = "OrderByDate";
            this.Text = "OrderByDate";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DateTimePicker StartDateField;
        private System.Windows.Forms.DateTimePicker EndDateField;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button LoadButton;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button CompleteOrderButton;
    }
}