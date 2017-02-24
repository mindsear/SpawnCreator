namespace SpawnCreator
{
    partial class Disable_Form
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Disable_Form));
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.timer2 = new System.Windows.Forms.Timer(this.components);
            this.textBox_SourceType = new System.Windows.Forms.TextBox();
            this.textBox_comment = new System.Windows.Forms.TextBox();
            this.label_Executed_Successfully = new System.Windows.Forms.Label();
            this.comboBox_SourceType = new System.Windows.Forms.ComboBox();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.label78 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.textBox_entry = new System.Windows.Forms.TextBox();
            this.label89 = new System.Windows.Forms.Label();
            this.label80 = new System.Windows.Forms.Label();
            this.label81 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label_mysql_status2 = new System.Windows.Forms.Label();
            this.label85 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label88 = new System.Windows.Forms.Label();
            this.label87 = new System.Windows.Forms.Label();
            this.panel7 = new System.Windows.Forms.Panel();
            this.label86 = new System.Windows.Forms.Label();
            this.label_stopwatch = new System.Windows.Forms.Label();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.pictureBox9 = new System.Windows.Forms.PictureBox();
            this.panel6 = new System.Windows.Forms.Panel();
            this.label84 = new System.Windows.Forms.Label();
            this.panel5 = new System.Windows.Forms.Panel();
            this.label83 = new System.Windows.Forms.Label();
            this.button_Execute_Query = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.button_flags_dis_spell = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.textBox_params_0 = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.textBox_params_1 = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.button_flags_dis_map = new System.Windows.Forms.Button();
            this.button_flags_dis_vmap = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.linkLabel2 = new System.Windows.Forms.LinkLabel();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel7.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox9)).BeginInit();
            this.panel6.SuspendLayout();
            this.panel5.SuspendLayout();
            this.SuspendLayout();
            // 
            // timer1
            // 
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // timer2
            // 
            this.timer2.Interval = 1000;
            this.timer2.Tick += new System.EventHandler(this.timer2_Tick);
            // 
            // textBox_SourceType
            // 
            this.textBox_SourceType.Location = new System.Drawing.Point(393, 130);
            this.textBox_SourceType.Name = "textBox_SourceType";
            this.textBox_SourceType.Size = new System.Drawing.Size(36, 20);
            this.textBox_SourceType.TabIndex = 124;
            this.textBox_SourceType.Text = "0";
            this.textBox_SourceType.Visible = false;
            // 
            // textBox_comment
            // 
            this.textBox_comment.Location = new System.Drawing.Point(205, 359);
            this.textBox_comment.Multiline = true;
            this.textBox_comment.Name = "textBox_comment";
            this.textBox_comment.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.textBox_comment.Size = new System.Drawing.Size(415, 37);
            this.textBox_comment.TabIndex = 118;
            this.toolTip1.SetToolTip(this.textBox_comment, "A comment as to why the something was disabled, ");
            this.textBox_comment.TextChanged += new System.EventHandler(this.textBox_comment_TextChanged);
            // 
            // label_Executed_Successfully
            // 
            this.label_Executed_Successfully.AutoSize = true;
            this.label_Executed_Successfully.Font = new System.Drawing.Font("Arial Rounded MT Bold", 11.25F);
            this.label_Executed_Successfully.ForeColor = System.Drawing.Color.ForestGreen;
            this.label_Executed_Successfully.Location = new System.Drawing.Point(301, 463);
            this.label_Executed_Successfully.Name = "label_Executed_Successfully";
            this.label_Executed_Successfully.Size = new System.Drawing.Size(223, 17);
            this.label_Executed_Successfully.TabIndex = 123;
            this.label_Executed_Successfully.Tag = "";
            this.label_Executed_Successfully.Text = "Query executed successfully!";
            this.label_Executed_Successfully.Visible = false;
            // 
            // comboBox_SourceType
            // 
            this.comboBox_SourceType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_SourceType.FormattingEnabled = true;
            this.comboBox_SourceType.Items.AddRange(new object[] {
            "DISABLE_TYPE_SPELL",
            "DISABLE_TYPE_QUEST",
            "DISABLE_TYPE_MAP",
            "DISABLE_TYPE_BATTLEGROUND",
            "DISABLE_TYPE_ACHIEVEMENT_CRITERIA",
            "DISABLE_TYPE_OUTDOORPVP",
            "DISABLE_TYPE_VMAP",
            "DISABLE_TYPE_MMAP",
            "DISABLE_TYPE_LFG_MAP"});
            this.comboBox_SourceType.Location = new System.Drawing.Point(183, 153);
            this.comboBox_SourceType.Name = "comboBox_SourceType";
            this.comboBox_SourceType.Size = new System.Drawing.Size(246, 21);
            this.comboBox_SourceType.TabIndex = 122;
            this.comboBox_SourceType.SelectedIndexChanged += new System.EventHandler(this.comboBox_SourceType_SelectedIndexChanged);
            // 
            // label78
            // 
            this.label78.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(58)))), ((int)(((byte)(89)))), ((int)(((byte)(114)))));
            this.label78.Cursor = System.Windows.Forms.Cursors.Hand;
            this.label78.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label78.ForeColor = System.Drawing.Color.Black;
            this.label78.Location = new System.Drawing.Point(560, 4);
            this.label78.Name = "label78";
            this.label78.Size = new System.Drawing.Size(26, 26);
            this.label78.TabIndex = 114;
            this.label78.Text = "<";
            this.toolTip1.SetToolTip(this.label78, "Back to Main Menu");
            this.label78.Click += new System.EventHandler(this.label78_Click);
            this.label78.MouseEnter += new System.EventHandler(this.label78_MouseEnter);
            this.label78.MouseLeave += new System.EventHandler(this.label78_MouseLeave);
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(58)))), ((int)(((byte)(89)))), ((int)(((byte)(114)))));
            this.label1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(592, 4);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(26, 26);
            this.label1.TabIndex = 80;
            this.label1.Text = "--";
            this.toolTip1.SetToolTip(this.label1, "Minimize");
            this.label1.Click += new System.EventHandler(this.label1_Click);
            this.label1.MouseEnter += new System.EventHandler(this.label1_MouseEnter);
            this.label1.MouseLeave += new System.EventHandler(this.label1_MouseLeave);
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(58)))), ((int)(((byte)(89)))), ((int)(((byte)(114)))));
            this.label2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(624, 4);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(26, 26);
            this.label2.TabIndex = 79;
            this.label2.Text = "X";
            this.toolTip1.SetToolTip(this.label2, "Close");
            this.label2.Click += new System.EventHandler(this.label2_Click);
            this.label2.MouseEnter += new System.EventHandler(this.label2_MouseEnter);
            this.label2.MouseLeave += new System.EventHandler(this.label2_MouseLeave);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(464, 137);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(109, 13);
            this.label4.TabIndex = 133;
            this.label4.Text = "             Entry             ";
            this.toolTip1.SetToolTip(this.label4, "Entry of Spell/Quest/Map/BG/Achievement/Map");
            // 
            // textBox_entry
            // 
            this.textBox_entry.Location = new System.Drawing.Point(455, 153);
            this.textBox_entry.Name = "textBox_entry";
            this.textBox_entry.Size = new System.Drawing.Size(128, 20);
            this.textBox_entry.TabIndex = 117;
            this.textBox_entry.Text = "0";
            this.textBox_entry.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBox_entry.TextChanged += new System.EventHandler(this.textBox_entry_TextChanged);
            this.textBox_entry.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox_entry_KeyPress);
            // 
            // label89
            // 
            this.label89.AutoSize = true;
            this.label89.Font = new System.Drawing.Font("Arial Rounded MT Bold", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label89.ForeColor = System.Drawing.Color.White;
            this.label89.Location = new System.Drawing.Point(50, 23);
            this.label89.Name = "label89";
            this.label89.Size = new System.Drawing.Size(59, 12);
            this.label89.TabIndex = 21;
            this.label89.Text = "HH:mm:ss";
            // 
            // label80
            // 
            this.label80.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(58)))), ((int)(((byte)(89)))), ((int)(((byte)(114)))));
            this.label80.Cursor = System.Windows.Forms.Cursors.Hand;
            this.label80.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label80.ForeColor = System.Drawing.Color.White;
            this.label80.Location = new System.Drawing.Point(857, 6);
            this.label80.Name = "label80";
            this.label80.Size = new System.Drawing.Size(26, 26);
            this.label80.TabIndex = 3;
            this.label80.Text = "--";
            // 
            // label81
            // 
            this.label81.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(58)))), ((int)(((byte)(89)))), ((int)(((byte)(114)))));
            this.label81.Cursor = System.Windows.Forms.Cursors.Hand;
            this.label81.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label81.ForeColor = System.Drawing.Color.White;
            this.label81.Location = new System.Drawing.Point(885, 6);
            this.label81.Name = "label81";
            this.label81.Size = new System.Drawing.Size(26, 26);
            this.label81.TabIndex = 2;
            this.label81.Text = "X";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(58)))), ((int)(((byte)(89)))), ((int)(((byte)(114)))));
            this.panel2.Controls.Add(this.label78);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.label_mysql_status2);
            this.panel2.Controls.Add(this.label85);
            this.panel2.Controls.Add(this.label80);
            this.panel2.Controls.Add(this.label81);
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(651, 34);
            this.panel2.TabIndex = 114;
            this.panel2.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panel2_MouseDown);
            this.panel2.MouseMove += new System.Windows.Forms.MouseEventHandler(this.panel2_MouseMove);
            this.panel2.MouseUp += new System.Windows.Forms.MouseEventHandler(this.panel2_MouseUp);
            // 
            // label_mysql_status2
            // 
            this.label_mysql_status2.AutoSize = true;
            this.label_mysql_status2.BackColor = System.Drawing.Color.Transparent;
            this.label_mysql_status2.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_mysql_status2.ForeColor = System.Drawing.Color.LawnGreen;
            this.label_mysql_status2.Location = new System.Drawing.Point(132, 8);
            this.label_mysql_status2.Name = "label_mysql_status2";
            this.label_mysql_status2.Size = new System.Drawing.Size(101, 18);
            this.label_mysql_status2.TabIndex = 20;
            this.label_mysql_status2.Text = "Connected!";
            // 
            // label85
            // 
            this.label85.AutoSize = true;
            this.label85.BackColor = System.Drawing.Color.Transparent;
            this.label85.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label85.ForeColor = System.Drawing.Color.White;
            this.label85.Location = new System.Drawing.Point(10, 8);
            this.label85.Name = "label85";
            this.label85.Size = new System.Drawing.Size(125, 18);
            this.label85.TabIndex = 18;
            this.label85.Text = "MySQL Status:";
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(53)))), ((int)(((byte)(65)))));
            this.panel3.Controls.Add(this.label89);
            this.panel3.Controls.Add(this.label88);
            this.panel3.Controls.Add(this.label87);
            this.panel3.Controls.Add(this.panel7);
            this.panel3.Controls.Add(this.label_stopwatch);
            this.panel3.Controls.Add(this.linkLabel1);
            this.panel3.Controls.Add(this.pictureBox9);
            this.panel3.Controls.Add(this.panel6);
            this.panel3.Controls.Add(this.panel5);
            this.panel3.Location = new System.Drawing.Point(0, 32);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(167, 463);
            this.panel3.TabIndex = 115;
            // 
            // label88
            // 
            this.label88.AutoSize = true;
            this.label88.ForeColor = System.Drawing.Color.Lime;
            this.label88.Location = new System.Drawing.Point(20, 212);
            this.label88.Name = "label88";
            this.label88.Size = new System.Drawing.Size(130, 26);
            this.label88.TabIndex = 100;
            this.label88.Tag = "";
            this.label88.Text = "File has been successfully\r\n               saved !";
            this.label88.Visible = false;
            // 
            // label87
            // 
            this.label87.AutoSize = true;
            this.label87.ForeColor = System.Drawing.Color.Lime;
            this.label87.Location = new System.Drawing.Point(29, 213);
            this.label87.Name = "label87";
            this.label87.Size = new System.Drawing.Size(120, 26);
            this.label87.TabIndex = 99;
            this.label87.Tag = "";
            this.label87.Text = "Query has been copied \r\n         to clipboard!";
            this.label87.Visible = false;
            // 
            // panel7
            // 
            this.panel7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(58)))), ((int)(((byte)(89)))), ((int)(((byte)(114)))));
            this.panel7.Controls.Add(this.label86);
            this.panel7.Cursor = System.Windows.Forms.Cursors.Hand;
            this.panel7.Location = new System.Drawing.Point(0, 161);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(167, 38);
            this.panel7.TabIndex = 22;
            this.panel7.MouseEnter += new System.EventHandler(this.panel7_MouseEnter);
            this.panel7.MouseLeave += new System.EventHandler(this.panel7_MouseLeave);
            // 
            // label86
            // 
            this.label86.AutoSize = true;
            this.label86.BackColor = System.Drawing.Color.Transparent;
            this.label86.Cursor = System.Windows.Forms.Cursors.Hand;
            this.label86.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label86.ForeColor = System.Drawing.Color.White;
            this.label86.Location = new System.Drawing.Point(12, 9);
            this.label86.Name = "label86";
            this.label86.Size = new System.Drawing.Size(138, 20);
            this.label86.TabIndex = 1;
            this.label86.Text = " Copy to Clipboard";
            this.label86.Click += new System.EventHandler(this.label86_Click);
            this.label86.MouseEnter += new System.EventHandler(this.label86_MouseEnter);
            this.label86.MouseLeave += new System.EventHandler(this.label86_MouseLeave);
            // 
            // label_stopwatch
            // 
            this.label_stopwatch.AutoSize = true;
            this.label_stopwatch.BackColor = System.Drawing.Color.White;
            this.label_stopwatch.Font = new System.Drawing.Font("Arial Rounded MT Bold", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_stopwatch.Location = new System.Drawing.Point(49, 5);
            this.label_stopwatch.Name = "label_stopwatch";
            this.label_stopwatch.Size = new System.Drawing.Size(63, 15);
            this.label_stopwatch.TabIndex = 21;
            this.label_stopwatch.Text = "00:00:00";
            // 
            // linkLabel1
            // 
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.linkLabel1.LinkColor = System.Drawing.Color.White;
            this.linkLabel1.Location = new System.Drawing.Point(10, 439);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(151, 16);
            this.linkLabel1.TabIndex = 4;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "[Visit Creator\'s Website]";
            this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            // 
            // pictureBox9
            // 
            this.pictureBox9.Image = global::SpawnCreator.Properties.Resources.chibi_spawn_by_xxthornthevamphogxx_d9fzfhb;
            this.pictureBox9.Location = new System.Drawing.Point(3, 252);
            this.pictureBox9.Name = "pictureBox9";
            this.pictureBox9.Size = new System.Drawing.Size(161, 184);
            this.pictureBox9.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox9.TabIndex = 3;
            this.pictureBox9.TabStop = false;
            // 
            // panel6
            // 
            this.panel6.BackColor = System.Drawing.Color.Gainsboro;
            this.panel6.Controls.Add(this.label84);
            this.panel6.Cursor = System.Windows.Forms.Cursors.Default;
            this.panel6.Location = new System.Drawing.Point(0, 60);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(167, 38);
            this.panel6.TabIndex = 2;
            // 
            // label84
            // 
            this.label84.AutoSize = true;
            this.label84.BackColor = System.Drawing.Color.Transparent;
            this.label84.Cursor = System.Windows.Forms.Cursors.Default;
            this.label84.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label84.ForeColor = System.Drawing.Color.Black;
            this.label84.Location = new System.Drawing.Point(48, 9);
            this.label84.Name = "label84";
            this.label84.Size = new System.Drawing.Size(66, 20);
            this.label84.TabIndex = 1;
            this.label84.Text = " Disable";
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(58)))), ((int)(((byte)(89)))), ((int)(((byte)(114)))));
            this.panel5.Controls.Add(this.label83);
            this.panel5.Cursor = System.Windows.Forms.Cursors.Hand;
            this.panel5.Location = new System.Drawing.Point(0, 117);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(167, 38);
            this.panel5.TabIndex = 1;
            this.panel5.MouseEnter += new System.EventHandler(this.panel5_MouseEnter);
            this.panel5.MouseLeave += new System.EventHandler(this.panel5_MouseLeave);
            // 
            // label83
            // 
            this.label83.AutoSize = true;
            this.label83.BackColor = System.Drawing.Color.Transparent;
            this.label83.Cursor = System.Windows.Forms.Cursors.Hand;
            this.label83.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label83.ForeColor = System.Drawing.Color.White;
            this.label83.Location = new System.Drawing.Point(34, 9);
            this.label83.Name = "label83";
            this.label83.Size = new System.Drawing.Size(100, 20);
            this.label83.TabIndex = 1;
            this.label83.Text = "Save as *.sql";
            this.label83.Click += new System.EventHandler(this.label83_Click);
            this.label83.MouseEnter += new System.EventHandler(this.label83_MouseEnter);
            this.label83.MouseLeave += new System.EventHandler(this.label83_MouseLeave);
            // 
            // button_Execute_Query
            // 
            this.button_Execute_Query.BackColor = System.Drawing.Color.DimGray;
            this.button_Execute_Query.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button_Execute_Query.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button_Execute_Query.Font = new System.Drawing.Font("Arial Rounded MT Bold", 11.25F);
            this.button_Execute_Query.ForeColor = System.Drawing.Color.White;
            this.button_Execute_Query.Location = new System.Drawing.Point(338, 412);
            this.button_Execute_Query.Name = "button_Execute_Query";
            this.button_Execute_Query.Size = new System.Drawing.Size(148, 38);
            this.button_Execute_Query.TabIndex = 116;
            this.button_Execute_Query.Text = "Execute Query";
            this.button_Execute_Query.UseVisualStyleBackColor = false;
            this.button_Execute_Query.Click += new System.EventHandler(this.button_Execute_Query_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(274, 137);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(68, 13);
            this.label3.TabIndex = 132;
            this.label3.Text = "Source Type";
            // 
            // button_flags_dis_spell
            // 
            this.button_flags_dis_spell.BackColor = System.Drawing.Color.DimGray;
            this.button_flags_dis_spell.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button_flags_dis_spell.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button_flags_dis_spell.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_flags_dis_spell.ForeColor = System.Drawing.Color.White;
            this.button_flags_dis_spell.Location = new System.Drawing.Point(183, 192);
            this.button_flags_dis_spell.Name = "button_flags_dis_spell";
            this.button_flags_dis_spell.Size = new System.Drawing.Size(116, 43);
            this.button_flags_dis_spell.TabIndex = 134;
            this.button_flags_dis_spell.Text = "Flags Disable Type Spell";
            this.button_flags_dis_spell.UseVisualStyleBackColor = false;
            this.button_flags_dis_spell.Visible = false;
            this.button_flags_dis_spell.Click += new System.EventHandler(this.button_flags_dis_spell_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(347, 202);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 13);
            this.label5.TabIndex = 136;
            this.label5.Text = "params_0";
            // 
            // textBox_params_0
            // 
            this.textBox_params_0.Location = new System.Drawing.Point(317, 218);
            this.textBox_params_0.Name = "textBox_params_0";
            this.textBox_params_0.Size = new System.Drawing.Size(116, 20);
            this.textBox_params_0.TabIndex = 135;
            this.textBox_params_0.Text = "0";
            this.textBox_params_0.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBox_params_0.TextChanged += new System.EventHandler(this.textBox_params_0_TextChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(347, 258);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(53, 13);
            this.label6.TabIndex = 138;
            this.label6.Text = "params_1";
            // 
            // textBox_params_1
            // 
            this.textBox_params_1.Location = new System.Drawing.Point(317, 274);
            this.textBox_params_1.Name = "textBox_params_1";
            this.textBox_params_1.Size = new System.Drawing.Size(116, 20);
            this.textBox_params_1.TabIndex = 137;
            this.textBox_params_1.Text = "0";
            this.textBox_params_1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBox_params_1.TextChanged += new System.EventHandler(this.textBox_params_1_TextChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(378, 343);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(51, 13);
            this.label7.TabIndex = 139;
            this.label7.Text = "Comment";
            this.toolTip1.SetToolTip(this.label7, "A comment as to why the something was disabled, \r\nor any other text that you want" +
        "");
            // 
            // button_flags_dis_map
            // 
            this.button_flags_dis_map.BackColor = System.Drawing.Color.DimGray;
            this.button_flags_dis_map.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button_flags_dis_map.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button_flags_dis_map.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_flags_dis_map.ForeColor = System.Drawing.Color.White;
            this.button_flags_dis_map.Location = new System.Drawing.Point(183, 191);
            this.button_flags_dis_map.Name = "button_flags_dis_map";
            this.button_flags_dis_map.Size = new System.Drawing.Size(116, 43);
            this.button_flags_dis_map.TabIndex = 141;
            this.button_flags_dis_map.Text = "Flags Disable Type Map";
            this.button_flags_dis_map.UseVisualStyleBackColor = false;
            this.button_flags_dis_map.Visible = false;
            this.button_flags_dis_map.Click += new System.EventHandler(this.button_flags_dis_map_Click);
            // 
            // button_flags_dis_vmap
            // 
            this.button_flags_dis_vmap.BackColor = System.Drawing.Color.DimGray;
            this.button_flags_dis_vmap.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button_flags_dis_vmap.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button_flags_dis_vmap.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_flags_dis_vmap.ForeColor = System.Drawing.Color.White;
            this.button_flags_dis_vmap.Location = new System.Drawing.Point(183, 191);
            this.button_flags_dis_vmap.Name = "button_flags_dis_vmap";
            this.button_flags_dis_vmap.Size = new System.Drawing.Size(116, 44);
            this.button_flags_dis_vmap.TabIndex = 142;
            this.button_flags_dis_vmap.Text = "Flags Disable Type Vmap";
            this.button_flags_dis_vmap.UseVisualStyleBackColor = false;
            this.button_flags_dis_vmap.Visible = false;
            this.button_flags_dis_vmap.Click += new System.EventHandler(this.button_flags_dis_vmap_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(284, 79);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(263, 13);
            this.label8.TabIndex = 143;
            this.label8.Text = "This table is used to disable dungeons/bgs/spells/etc.";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Cursor = System.Windows.Forms.Cursors.Hand;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.label9.Location = new System.Drawing.Point(284, 54);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(267, 13);
            this.label9.TabIndex = 144;
            this.label9.Text = "https://trinitycore.atlassian.net/wiki/display/tc/disables";
            this.label9.Click += new System.EventHandler(this.label9_Click);
            // 
            // textBox1
            // 
            this.textBox1.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox1.Location = new System.Drawing.Point(439, 207);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBox1.Size = new System.Drawing.Size(211, 100);
            this.textBox1.TabIndex = 145;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(464, 191);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(35, 13);
            this.label10.TabIndex = 146;
            this.label10.Text = "Notes";
            this.toolTip1.SetToolTip(this.label10, "Entry of Spell/Quest/Map/BG/Achievement/Map");
            // 
            // linkLabel2
            // 
            this.linkLabel2.AutoSize = true;
            this.linkLabel2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.linkLabel2.Location = new System.Drawing.Point(483, 310);
            this.linkLabel2.Name = "linkLabel2";
            this.linkLabel2.Size = new System.Drawing.Size(113, 13);
            this.linkLabel2.TabIndex = 147;
            this.linkLabel2.TabStop = true;
            this.linkLabel2.Text = "Map Ids AND Area Ids";
            this.linkLabel2.Visible = false;
            this.linkLabel2.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel2_LinkClicked);
            // 
            // Disable_Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Silver;
            this.ClientSize = new System.Drawing.Size(651, 493);
            this.Controls.Add(this.linkLabel2);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.button_flags_dis_vmap);
            this.Controls.Add(this.button_flags_dis_map);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.textBox_params_1);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.textBox_params_0);
            this.Controls.Add(this.button_flags_dis_spell);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.textBox_SourceType);
            this.Controls.Add(this.textBox_comment);
            this.Controls.Add(this.label_Executed_Successfully);
            this.Controls.Add(this.comboBox_SourceType);
            this.Controls.Add(this.textBox_entry);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.button_Execute_Query);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Disable_Form";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Disable";
            this.Load += new System.EventHandler(this.Disable_Form_Load);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel7.ResumeLayout(false);
            this.panel7.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox9)).EndInit();
            this.panel6.ResumeLayout(false);
            this.panel6.PerformLayout();
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Timer timer2;
        private System.Windows.Forms.TextBox textBox_SourceType;
        private System.Windows.Forms.TextBox textBox_comment;
        private System.Windows.Forms.Label label_Executed_Successfully;
        private System.Windows.Forms.ComboBox comboBox_SourceType;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Label label78;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox_entry;
        private System.Windows.Forms.Label label89;
        private System.Windows.Forms.Label label80;
        private System.Windows.Forms.Label label81;
        private System.Windows.Forms.Panel panel2;
        internal System.Windows.Forms.Label label_mysql_status2;
        private System.Windows.Forms.Label label85;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label88;
        private System.Windows.Forms.Label label87;
        private System.Windows.Forms.Panel panel7;
        internal System.Windows.Forms.Label label86;
        private System.Windows.Forms.Label label_stopwatch;
        private System.Windows.Forms.LinkLabel linkLabel1;
        private System.Windows.Forms.PictureBox pictureBox9;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Label label84;
        private System.Windows.Forms.Panel panel5;
        internal System.Windows.Forms.Label label83;
        private System.Windows.Forms.Button button_Execute_Query;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button button_flags_dis_spell;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textBox_params_0;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox textBox_params_1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button button_flags_dis_map;
        private System.Windows.Forms.Button button_flags_dis_vmap;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.LinkLabel linkLabel2;
    }
}