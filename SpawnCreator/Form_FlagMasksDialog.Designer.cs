namespace SpawnCreator
{
    partial class Form_FlagMasksDialog
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
            this.checkedListBox1 = new System.Windows.Forms.CheckedListBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // checkedListBox1
            // 
            this.checkedListBox1.CheckOnClick = true;
            this.checkedListBox1.FormattingEnabled = true;
            this.checkedListBox1.Items.AddRange(new object[] {
            "UNK1\t",
            "Conjured item\t",
            "Openable (can be opened by right-click)\t",
            "Makes green \"Heroic\" text appear on item",
            "Deprecated Item\t",
            "Item can not be destroyed, except by using spell (item can be reagent for spell)",
            "UNK2",
            "No default 30 seconds cooldown when equipped",
            "UNK3",
            "Wrapper : Item can wrap other items",
            "UNK4",
            "Item is party loot and can be looted by all",
            "Item is refundable",
            "Charter (Arena or Guild)",
            "UNK5 // comment in code : Only readable items have this (but not all)",
            "UNK6",
            "UNK7",
            "UNK8",
            "Item can be prospected",
            "Unique equipped (player can only have one equipped at the same time)",
            "UNK9",
            "Item can be used during arena match",
            "Throwable (for tooltip ingame)",
            "Item can be used in shapeshift forms",
            "UNK10",
            "Profession recipes: can only be looted if you meet requirements and don\'t already" +
                " know it",
            "Item cannot be used in arena",
            "Bind to Account (Also needs Quality = 7 set)\t",
            "Spell is cast with triggered flag",
            "Millable",
            "UNK11\t",
            "Bind on Pickup tradeable"});
            this.checkedListBox1.Location = new System.Drawing.Point(12, 12);
            this.checkedListBox1.Name = "checkedListBox1";
            this.checkedListBox1.Size = new System.Drawing.Size(463, 454);
            this.checkedListBox1.TabIndex = 0;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(157, 472);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "Select All";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(238, 472);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 2;
            this.button2.Text = "Reset";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // Form_FlagMasksDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(486, 506);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.checkedListBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form_FlagMasksDialog";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Flag Masks";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form_FlagMasksDialog_FormClosing);
            this.Load += new System.EventHandler(this.Form_FlagMasksDialog_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.CheckedListBox checkedListBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
    }
}
