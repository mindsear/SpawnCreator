namespace SpawnCreator
{
    partial class flags_extra
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
            this.SuspendLayout();
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(151, 339);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 17;
            this.button2.Text = "Reset";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(60, 339);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 16;
            this.button1.Text = "Select All";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // checkedListBox1
            // 
            this.checkedListBox1.CheckOnClick = true;
            this.checkedListBox1.FormattingEnabled = true;
            this.checkedListBox1.Items.AddRange(new object[] {
            "CREATURE_FLAG_EXTRA_INSTANCE_BIND",
            "CREATURE_FLAG_EXTRA_CIVILIAN",
            "CREATURE_FLAG_EXTRA_NO_PARRY",
            "CREATURE_FLAG_EXTRA_NO_PARRY_HASTEN",
            "CREATURE_FLAG_EXTRA_NO_BLOCK",
            "CREATURE_FLAG_EXTRA_NO_CRUSH",
            "CREATURE_FLAG_EXTRA_NO_XP_AT_KILL",
            "CREATURE_FLAG_EXTRA_TRIGGER",
            "CREATURE_FLAG_EXTRA_NO_TAUNT",
            "CREATURE_FLAG_EXTRA_NO_MOVE_FLAGS_UPDATE",
            "CREATURE_FLAG_EXTRA_WORLDEVENT",
            "CREATURE_FLAG_EXTRA_GUARD",
            "CREATURE_FLAG_EXTRA_NO_CRIT",
            "CREATURE_FLAG_EXTRA_NO_SKILLGAIN",
            "CREATURE_FLAG_EXTRA_TAUNT_DIMINISH",
            "CREATURE_FLAG_EXTRA_ALL_DIMINISH",
            "CREATURE_FLAG_EXTRA_NO_PLAYER_DAMAGE_REQ",
            "CREATURE_FLAG_EXTRA_DUNGEON_BOSS",
            "CREATURE_FLAG_EXTRA_IGNORE_PATHFINDING",
            "CREATURE_FLAG_EXTRA_IMMUNITY_KNOCKBACK"});
            this.checkedListBox1.Location = new System.Drawing.Point(12, 12);
            this.checkedListBox1.Name = "checkedListBox1";
            this.checkedListBox1.Size = new System.Drawing.Size(361, 319);
            this.checkedListBox1.TabIndex = 15;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(247, 339);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 23);
            this.button3.TabIndex = 18;
            this.button3.Text = "Ok";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // flags_extra
            // 
            this.AcceptButton = this.button3;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(382, 374);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.checkedListBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "flags_extra";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "flags_extra";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.flags_extra_FormClosing);
            this.Load += new System.EventHandler(this.flags_extra_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.CheckedListBox checkedListBox1;
        private System.Windows.Forms.Button button3;
    }
}
