namespace SpawnCreator
{
    partial class type_flags
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
            this.button2.Location = new System.Drawing.Point(236, 322);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 8;
            this.button2.Text = "Reset";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(145, 322);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 7;
            this.button1.Text = "Select All";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // checkedListBox1
            // 
            this.checkedListBox1.CheckOnClick = true;
            this.checkedListBox1.FormattingEnabled = true;
            this.checkedListBox1.Items.AddRange(new object[] {
            "CREATURE_TYPEFLAGS_TAMEABLE",
            "CREATURE_TYPEFLAGS_GHOST",
            "CREATURE_TYPEFLAGS_BOSS",
            "CREATURE_TYPEFLAGS_DO_NOT_PLAY_WOUND_PARRY_ANIMATION",
            "CREATURE_TYPEFLAGS_HIDE_FACTION_TOOLTIP",
            "CREATURE_TYPEFLAGS_UNK6",
            "CREATURE_TYPEFLAGS_SPELL_ATTACKABLE",
            "CREATURE_TYPEFLAGS_DEAD_INTERACT",
            "CREATURE_TYPEFLAGS_HERBLOOT",
            "CREATURE_TYPEFLAGS_MININGLOOT",
            "CREATURE_TYPEFLAGS_DONT_LOG_DEATH",
            "CREATURE_TYPEFLAGS_MOUNTED_COMBAT",
            "CREATURE_TYPEFLAGS_AID_PLAYERS",
            "CREATURE_TYPEFLAGS_IS_PET_BAR_USED",
            "CREATURE_TYPEFLAGS_MASK_UID",
            "CREATURE_TYPEFLAGS_ENGINEERLOOT",
            "CREATURE_TYPEFLAGS_EXOTIC",
            "CREATURE_TYPEFLAGS_USE_DEFAULT_COLLISION_BOX",
            "CREATURE_TYPEFLAGS_IS_SIEGE_WEAPON",
            "CREATURE_TYPEFLAGS_PROJECTILE_COLLISION",
            "CREATURE_TYPEFLAGS_HIDE_NAMEPLATE",
            "CREATURE_TYPEFLAGS_DO_NOT_PLAY_MOUNTED_ANIMATIONS",
            "CREATURE_TYPEFLAGS_IS_LINK_ALL",
            "CREATURE_TYPEFLAGS_INTERACT_ONLY_WITH_CREATOR",
            "CREATURE_TYPEFLAGS_FORCE_GOSSIP"});
            this.checkedListBox1.Location = new System.Drawing.Point(12, 13);
            this.checkedListBox1.Name = "checkedListBox1";
            this.checkedListBox1.Size = new System.Drawing.Size(441, 289);
            this.checkedListBox1.TabIndex = 6;
            // 
            // type_flags
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(465, 357);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.checkedListBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "type_flags";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "type_flags";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.type_flags_FormClosing);
            this.Load += new System.EventHandler(this.type_flags_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.CheckedListBox checkedListBox1;
    }
}
