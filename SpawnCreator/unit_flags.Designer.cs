namespace SpawnCreator
{
    partial class unit_flags
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
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.checkedListBox1 = new System.Windows.Forms.CheckedListBox();
            this.SuspendLayout();
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(165, 320);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 5;
            this.button2.Text = "Reset";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(74, 320);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 4;
            this.button1.Text = "Select All";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // checkedListBox1
            // 
            this.checkedListBox1.FormattingEnabled = true;
            this.checkedListBox1.Items.AddRange(new object[] {
            "UNIT_FLAG_SERVER_CONTROLLED",
            "UNIT_FLAG_NON_ATTACKABLE",
            "UNIT_FLAG_REMOVE_CLIENT_CONTROL",
            "UNIT_FLAG_PVP_ATTACKABLE",
            "UNIT_FLAG_RENAME",
            "UNIT_FLAG_PREPARATION",
            "UNIT_FLAG_UNK_6",
            "UNIT_FLAG_NOT_ATTACKABLE_1",
            "UNIT_FLAG_IMMUNE_TO_PC",
            "UNIT_FLAG_IMMUNE_TO_NPC",
            "UNIT_FLAG_LOOTING",
            "UNIT_FLAG_PET_IN_COMBAT",
            "UNIT_FLAG_PVP",
            "UNIT_FLAG_SILENCED",
            "UNIT_FLAG_CANNOT_SWIM",
            "UNIT_FLAG_UNK_15",
            "UNIT_FLAG_UNK_16",
            "UNIT_FLAG_PACIFIED",
            "UNIT_FLAG_STUNNED",
            "UNIT_FLAG_IN_COMBAT",
            "UNIT_FLAG_TAXI_FLIGHT",
            "UNIT_FLAG_DISARMED",
            "UNIT_FLAG_CONFUSED",
            "UNIT_FLAG_FLEEING",
            "UNIT_FLAG_PLAYER_CONTROLLED",
            "UNIT_FLAG_NOT_SELECTABLE",
            "UNIT_FLAG_SKINNABLE",
            "UNIT_FLAG_MOUNT",
            "UNIT_FLAG_UNK_28",
            "UNIT_FLAG_UNK_29",
            "UNIT_FLAG_SHEATHE",
            "UNIT_FLAG_UNK_31"});
            this.checkedListBox1.Location = new System.Drawing.Point(12, 12);
            this.checkedListBox1.Name = "checkedListBox1";
            this.checkedListBox1.Size = new System.Drawing.Size(289, 289);
            this.checkedListBox1.TabIndex = 3;
            // 
            // unit_flags
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(310, 355);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.checkedListBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "unit_flags";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "unit_flags";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.unit_flags_FormClosing);
            this.Load += new System.EventHandler(this.unit_flags_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.CheckedListBox checkedListBox1;
    }
}