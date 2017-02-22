namespace SpawnCreator
{
    partial class Predefined_SAI_Templates
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Predefined_SAI_Templates));
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.Description_Name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Value_Param1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Param2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Param3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Param4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Param5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Param6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Comment = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Description_Name,
            this.Value_Param1,
            this.Param2,
            this.Param3,
            this.Param4,
            this.Param5,
            this.Param6,
            this.Comment});
            this.dataGridView1.Location = new System.Drawing.Point(12, 12);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(959, 160);
            this.dataGridView1.TabIndex = 0;
            // 
            // Description_Name
            // 
            this.Description_Name.HeaderText = "Description_Name";
            this.Description_Name.Name = "Description_Name";
            // 
            // Value_Param1
            // 
            this.Value_Param1.HeaderText = "Value_Param1";
            this.Value_Param1.Name = "Value_Param1";
            // 
            // Param2
            // 
            this.Param2.HeaderText = "Param2";
            this.Param2.Name = "Param2";
            // 
            // Param3
            // 
            this.Param3.HeaderText = "Param3";
            this.Param3.Name = "Param3";
            // 
            // Param4
            // 
            this.Param4.HeaderText = "Param4";
            this.Param4.Name = "Param4";
            // 
            // Param5
            // 
            this.Param5.HeaderText = "Param5";
            this.Param5.Name = "Param5";
            // 
            // Param6
            // 
            this.Param6.HeaderText = "Param6";
            this.Param6.Name = "Param6";
            // 
            // Comment
            // 
            this.Comment.HeaderText = "Comment";
            this.Comment.Name = "Comment";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(448, 178);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(89, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "Ok";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Predefined_SAI_Templates
            // 
            this.AcceptButton = this.button1;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(982, 207);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.dataGridView1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Predefined_SAI_Templates";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Predefined SAI Templates";
            this.Load += new System.EventHandler(this.Predefined_SAI_Templates_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Description_Name;
        private System.Windows.Forms.DataGridViewTextBoxColumn Value_Param1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Param2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Param3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Param4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Param5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Param6;
        private System.Windows.Forms.DataGridViewTextBoxColumn Comment;
    }
}