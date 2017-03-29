namespace SpawnCreator
{
    partial class SaveOptionsDialog
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
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button_execute_query = new System.Windows.Forms.Button();
            this.label_query_executed_successfully = new System.Windows.Forms.Label();
            this.label_copy_to_clipboard = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(12, 12);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(153, 29);
            this.button1.TabIndex = 0;
            this.button1.Text = "Save as *.sql";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.Location = new System.Drawing.Point(12, 61);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(153, 29);
            this.button2.TabIndex = 1;
            this.button2.Text = "Copy to Clipboard";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button_execute_query
            // 
            this.button_execute_query.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.button_execute_query.Location = new System.Drawing.Point(12, 111);
            this.button_execute_query.Name = "button_execute_query";
            this.button_execute_query.Size = new System.Drawing.Size(153, 27);
            this.button_execute_query.TabIndex = 2;
            this.button_execute_query.Text = "Execute Query";
            this.button_execute_query.UseVisualStyleBackColor = true;
            this.button_execute_query.Click += new System.EventHandler(this.button_execute_query_Click);
            // 
            // label_query_executed_successfully
            // 
            this.label_query_executed_successfully.AutoSize = true;
            this.label_query_executed_successfully.ForeColor = System.Drawing.Color.Green;
            this.label_query_executed_successfully.Location = new System.Drawing.Point(17, 163);
            this.label_query_executed_successfully.Name = "label_query_executed_successfully";
            this.label_query_executed_successfully.Size = new System.Drawing.Size(148, 13);
            this.label_query_executed_successfully.TabIndex = 76;
            this.label_query_executed_successfully.Text = "Query Executed Successfully!";
            this.label_query_executed_successfully.Visible = false;
            // 
            // label_copy_to_clipboard
            // 
            this.label_copy_to_clipboard.AutoSize = true;
            this.label_copy_to_clipboard.ForeColor = System.Drawing.Color.Green;
            this.label_copy_to_clipboard.Location = new System.Drawing.Point(-2, 163);
            this.label_copy_to_clipboard.Name = "label_copy_to_clipboard";
            this.label_copy_to_clipboard.Size = new System.Drawing.Size(178, 13);
            this.label_copy_to_clipboard.TabIndex = 77;
            this.label_copy_to_clipboard.Text = "Query has been copied to clipboard!";
            this.label_copy_to_clipboard.Visible = false;
            // 
            // SaveOptionsDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(178, 185);
            this.Controls.Add(this.label_copy_to_clipboard);
            this.Controls.Add(this.label_query_executed_successfully);
            this.Controls.Add(this.button_execute_query);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SaveOptionsDialog";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Chose an Option";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.SaveOptionsDialog_FormClosed);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button_execute_query;
        internal System.Windows.Forms.Label label_query_executed_successfully;
        internal System.Windows.Forms.Label label_copy_to_clipboard;
    }
}