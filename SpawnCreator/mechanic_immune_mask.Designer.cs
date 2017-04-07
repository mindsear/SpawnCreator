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
            this.button3 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(130, 387);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 14;
            this.button2.Text = "Reset";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(32, 387);
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
            this.checkedListBox1.Location = new System.Drawing.Point(32, 77);
            this.checkedListBox1.Name = "checkedListBox1";
            this.checkedListBox1.Size = new System.Drawing.Size(276, 304);
            this.checkedListBox1.TabIndex = 12;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(233, 387);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 23);
            this.button3.TabIndex = 15;
            this.button3.Text = "Ok";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(328, 45);
            this.label1.TabIndex = 16;
            this.label1.Text = "This makes the creature immune to specific spell natures. \r\nSee Spell.dbc at row " +
    "effect_X_mechanic_id.\r\nUses references from SpellMechanic.dbc.";
            // 
            // mechanic_immune_mask
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(339, 420);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button3);
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
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.CheckedListBox checkedListBox1;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Label label1;
    }
}
