namespace SpawnCreator
{
    partial class unit_flags2
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
            this.button2.Location = new System.Drawing.Point(162, 308);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 8;
            this.button2.Text = "Reset";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(71, 308);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 7;
            this.button1.Text = "Select All";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // checkedListBox1
            // 
            this.checkedListBox1.FormattingEnabled = true;
            this.checkedListBox1.Items.AddRange(new object[] {
            "UNIT_FLAG2_FEIGN_DEATH",
            "UNIT_FLAG2_UNK1",
            "UNIT_FLAG2_IGNORE_REPUTATION",
            "UNIT_FLAG2_COMPREHEND_LANG",
            "UNIT_FLAG2_MIRROR_IMAGE",
            "UNIT_FLAG2_INSTANTLY_APPEAR_MODEL",
            "UNIT_FLAG2_FORCE_MOVEMENT",
            "UNIT_FLAG2_DISARM_OFFHAND",
            "UNIT_FLAG2_DISABLE_PRED_STATS",
            "UNIT_FLAG2_DISARM_RANGED",
            "UNIT_FLAG2_REGENERATE_POWER",
            "UNIT_FLAG2_RESTRICT_PARTY_INTERACTION",
            "UNIT_FLAG2_PREVENT_SPELL_CLICK",
            "UNIT_FLAG2_ALLOW_ENEMY_INTERACT",
            "UNIT_FLAG2_DISABLE_TURN",
            "UNIT_FLAG2_UNK2",
            "UNIT_FLAG2_PLAY_DEATH_ANIM",
            "UNIT_FLAG2_ALLOW_CHEAT_SPELLS"});
            this.checkedListBox1.Location = new System.Drawing.Point(14, 19);
            this.checkedListBox1.Name = "checkedListBox1";
            this.checkedListBox1.Size = new System.Drawing.Size(289, 274);
            this.checkedListBox1.TabIndex = 6;
            // 
            // unit_flags2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(316, 339);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.checkedListBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "unit_flags2";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "unit_flags2";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.unit_flags2_FormClosing);
            this.Load += new System.EventHandler(this.unit_flags2_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.CheckedListBox checkedListBox1;
    }
}