namespace SpawnCreator
{
    partial class mechanic_immune_mask
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
            this.button2.Location = new System.Drawing.Point(155, 332);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 14;
            this.button2.Text = "Reset";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(64, 332);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 13;
            this.button1.Text = "Select All";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // checkedListBox1
            // 
            this.checkedListBox1.CheckOnClick = true;
            this.checkedListBox1.FormattingEnabled = true;
            this.checkedListBox1.Items.AddRange(new object[] {
            "MECHANIC_CHARM",
            "MECHANIC_DISORIENTED",
            "MECHANIC_DISARM",
            "MECHANIC_DISTRACT",
            "MECHANIC_FEAR",
            "MECHANIC_GRIP",
            "MECHANIC_ROOT",
            "MECHANIC_PACIFY",
            "MECHANIC_SILENCE",
            "MECHANIC_SLEEP",
            "MECHANIC_SNARE",
            "MECHANIC_STUN",
            "MECHANIC_FREEZE",
            "MECHANIC_KNOCKOUT",
            "MECHANIC_BLEED",
            "MECHANIC_BANDAGE",
            "MECHANIC_POLYMORPH",
            "MECHANIC_BANISH",
            "MECHANIC_SHIELD",
            "MECHANIC_SHACKLE",
            "MECHANIC_MOUNT",
            "MECHANIC_INFECTED",
            "MECHANIC_TURN",
            "MECHANIC_HORROR",
            "MECHANIC_INVULNERABILITY",
            "MECHANIC_INTERRUPT",
            "MECHANIC_DAZE",
            "MECHANIC_DISCOVERY",
            "MECHANIC_IMMUNE_SHIELD",
            "MECHANIC_SAPPED",
            "MECHANIC_ENRAGED"});
            this.checkedListBox1.Location = new System.Drawing.Point(12, 12);
            this.checkedListBox1.Name = "checkedListBox1";
            this.checkedListBox1.Size = new System.Drawing.Size(276, 304);
            this.checkedListBox1.TabIndex = 12;
            // 
            // mechanic_immune_mask
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(297, 367);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.checkedListBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "mechanic_immune_mask";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "mechanic_immune_mask";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.mechanic_immune_mask_FormClosing);
            this.Load += new System.EventHandler(this.mechanic_immune_mask_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.CheckedListBox checkedListBox1;
    }
}
