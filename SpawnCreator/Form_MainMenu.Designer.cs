namespace SpawnCreator
{
    partial class Form_MainMenu
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_MainMenu));
            this.panel1 = new System.Windows.Forms.Panel();
            this.label_mysql_status = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.lbl_MySQL_Status = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label_Npc_creator = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.label_GO_creator = new System.Windows.Forms.Label();
            this.label_Quest_creator = new System.Windows.Forms.Label();
            this.panel_Quest_Creator = new System.Windows.Forms.Panel();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.label6 = new System.Windows.Forms.Label();
            this.button_clearAll = new System.Windows.Forms.Button();
            this.button_fill_default = new System.Windows.Forms.Button();
            this.textBox_mysql_charactersDB = new System.Windows.Forms.TextBox();
            this.label_mysql_worldDB = new System.Windows.Forms.Label();
            this.textbox_mysql_worldDB = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.textBox_mysql_authDB = new System.Windows.Forms.TextBox();
            this.label_mysql_password = new System.Windows.Forms.Label();
            this.label_mysql_username = new System.Windows.Forms.Label();
            this.label_mysql_port = new System.Windows.Forms.Label();
            this.label_mysql_hostname = new System.Windows.Forms.Label();
            this.textbox_mysql_pass = new System.Windows.Forms.TextBox();
            this.textbox_mysql_username = new System.Windows.Forms.TextBox();
            this.textbox_mysql_port = new System.Windows.Forms.TextBox();
            this.textbox_mysql_hostname = new System.Windows.Forms.TextBox();
            this.button_mysql_connect = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.panel_Account_Creator = new System.Windows.Forms.Panel();
            this.label_Account_Creator = new System.Windows.Forms.Label();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.panel5 = new System.Windows.Forms.Panel();
            this.label11 = new System.Windows.Forms.Label();
            this.panel6 = new System.Windows.Forms.Panel();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.panel7 = new System.Windows.Forms.Panel();
            this.label14 = new System.Windows.Forms.Label();
            this.label_version = new System.Windows.Forms.Label();
            this.panel8 = new System.Windows.Forms.Panel();
            this.label15 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.CB_NoMySQL = new System.Windows.Forms.CheckBox();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel_Quest_Creator.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.panel_Account_Creator.SuspendLayout();
            this.panel5.SuspendLayout();
            this.panel6.SuspendLayout();
            this.panel7.SuspendLayout();
            this.panel8.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.IndianRed;
            this.panel1.Controls.Add(this.label_mysql_status);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.lbl_MySQL_Status);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(491, 26);
            this.panel1.TabIndex = 3;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            this.panel1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panel1_MouseDown);
            this.panel1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.panel1_MouseMove);
            this.panel1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.panel1_MouseUp);
            // 
            // label_mysql_status
            // 
            this.label_mysql_status.AutoSize = true;
            this.label_mysql_status.BackColor = System.Drawing.Color.Transparent;
            this.label_mysql_status.Font = new System.Drawing.Font("Arial Rounded MT Bold", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_mysql_status.ForeColor = System.Drawing.Color.Black;
            this.label_mysql_status.Location = new System.Drawing.Point(114, 7);
            this.label_mysql_status.Name = "label_mysql_status";
            this.label_mysql_status.Size = new System.Drawing.Size(116, 15);
            this.label_mysql_status.TabIndex = 22;
            this.label_mysql_status.Text = "Not Connected...";
            // 
            // label8
            // 
            this.label8.BackColor = System.Drawing.Color.IndianRed;
            this.label8.Cursor = System.Windows.Forms.Cursors.Hand;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(439, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(26, 26);
            this.label8.TabIndex = 1;
            this.label8.Text = "--";
            this.toolTip1.SetToolTip(this.label8, "Minimize");
            this.label8.Click += new System.EventHandler(this.label8_Click);
            this.label8.MouseEnter += new System.EventHandler(this.label8_MouseEnter);
            this.label8.MouseLeave += new System.EventHandler(this.label8_MouseLeave);
            // 
            // lbl_MySQL_Status
            // 
            this.lbl_MySQL_Status.AutoSize = true;
            this.lbl_MySQL_Status.BackColor = System.Drawing.Color.Transparent;
            this.lbl_MySQL_Status.Font = new System.Drawing.Font("Arial Rounded MT Bold", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_MySQL_Status.ForeColor = System.Drawing.Color.White;
            this.lbl_MySQL_Status.Location = new System.Drawing.Point(12, 7);
            this.lbl_MySQL_Status.Name = "lbl_MySQL_Status";
            this.lbl_MySQL_Status.Size = new System.Drawing.Size(101, 15);
            this.lbl_MySQL_Status.TabIndex = 21;
            this.lbl_MySQL_Status.Text = "MySQL Status:";
            // 
            // label7
            // 
            this.label7.BackColor = System.Drawing.Color.IndianRed;
            this.label7.Cursor = System.Windows.Forms.Cursors.Hand;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(465, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(26, 26);
            this.label7.TabIndex = 0;
            this.label7.Text = "X";
            this.toolTip1.SetToolTip(this.label7, "Close");
            this.label7.Click += new System.EventHandler(this.label7_Click);
            this.label7.MouseEnter += new System.EventHandler(this.label7_MouseEnter);
            this.label7.MouseLeave += new System.EventHandler(this.label7_MouseLeave);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(259, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(134, 24);
            this.label1.TabIndex = 5;
            this.label1.Text = "Spawn Creator";
            this.label1.Visible = false;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Gainsboro;
            this.panel2.Controls.Add(this.label2);
            this.panel2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.panel2.Location = new System.Drawing.Point(237, 56);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(177, 30);
            this.panel2.TabIndex = 6;
            this.panel2.Visible = false;
            this.panel2.Click += new System.EventHandler(this.panel2_Click);
            this.panel2.MouseEnter += new System.EventHandler(this.panel2_MouseEnter);
            this.panel2.MouseLeave += new System.EventHandler(this.panel2_MouseLeave);
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(3, 1);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(171, 29);
            this.label2.TabIndex = 0;
            this.label2.Text = "Item Creator";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label2.Click += new System.EventHandler(this.panel2_Click);
            this.label2.MouseEnter += new System.EventHandler(this.panel2_MouseEnter);
            this.label2.MouseLeave += new System.EventHandler(this.panel2_MouseLeave);
            // 
            // linkLabel1
            // 
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.linkLabel1.LinkColor = System.Drawing.Color.Firebrick;
            this.linkLabel1.Location = new System.Drawing.Point(195, 376);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(111, 13);
            this.linkLabel1.TabIndex = 8;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "artister.hd@gmail.com";
            this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(310, 376);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(16, 13);
            this.label4.TabIndex = 9;
            this.label4.Text = "<]";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(173, 376);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(16, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "[>";
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.Gainsboro;
            this.panel3.Controls.Add(this.label_Npc_creator);
            this.panel3.Cursor = System.Windows.Forms.Cursors.Hand;
            this.panel3.Location = new System.Drawing.Point(237, 89);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(177, 30);
            this.panel3.TabIndex = 10;
            this.panel3.Visible = false;
            this.panel3.Paint += new System.Windows.Forms.PaintEventHandler(this.panel3_Paint);
            this.panel3.MouseEnter += new System.EventHandler(this.panel3_MouseEnter);
            this.panel3.MouseLeave += new System.EventHandler(this.panel3_MouseLeave);
            // 
            // label_Npc_creator
            // 
            this.label_Npc_creator.BackColor = System.Drawing.Color.Transparent;
            this.label_Npc_creator.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_Npc_creator.ForeColor = System.Drawing.Color.Black;
            this.label_Npc_creator.Location = new System.Drawing.Point(0, -1);
            this.label_Npc_creator.Name = "label_Npc_creator";
            this.label_Npc_creator.Size = new System.Drawing.Size(174, 32);
            this.label_Npc_creator.TabIndex = 0;
            this.label_Npc_creator.Text = "NPC Creator";
            this.label_Npc_creator.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label_Npc_creator.Click += new System.EventHandler(this.label5_Click);
            this.label_Npc_creator.MouseEnter += new System.EventHandler(this.panel3_MouseEnter);
            this.label_Npc_creator.MouseLeave += new System.EventHandler(this.panel3_MouseLeave);
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.Gainsboro;
            this.panel4.Controls.Add(this.label_GO_creator);
            this.panel4.Cursor = System.Windows.Forms.Cursors.Hand;
            this.panel4.Location = new System.Drawing.Point(237, 123);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(177, 30);
            this.panel4.TabIndex = 11;
            this.panel4.Visible = false;
            // 
            // label_GO_creator
            // 
            this.label_GO_creator.BackColor = System.Drawing.Color.Transparent;
            this.label_GO_creator.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_GO_creator.ForeColor = System.Drawing.Color.Black;
            this.label_GO_creator.Location = new System.Drawing.Point(0, 1);
            this.label_GO_creator.Name = "label_GO_creator";
            this.label_GO_creator.Size = new System.Drawing.Size(174, 29);
            this.label_GO_creator.TabIndex = 0;
            this.label_GO_creator.Text = "GameObject Creator";
            this.label_GO_creator.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label_GO_creator.Click += new System.EventHandler(this.label_GO_creator_Click);
            this.label_GO_creator.MouseEnter += new System.EventHandler(this.label6_MouseEnter);
            this.label_GO_creator.MouseLeave += new System.EventHandler(this.label6_MouseLeave);
            // 
            // label_Quest_creator
            // 
            this.label_Quest_creator.BackColor = System.Drawing.Color.Transparent;
            this.label_Quest_creator.Cursor = System.Windows.Forms.Cursors.Hand;
            this.label_Quest_creator.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_Quest_creator.ForeColor = System.Drawing.Color.Black;
            this.label_Quest_creator.Location = new System.Drawing.Point(0, 0);
            this.label_Quest_creator.Name = "label_Quest_creator";
            this.label_Quest_creator.Size = new System.Drawing.Size(177, 30);
            this.label_Quest_creator.TabIndex = 0;
            this.label_Quest_creator.Text = "Quest Creator";
            this.label_Quest_creator.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label_Quest_creator.Click += new System.EventHandler(this.label_Quest_creator_Click);
            this.label_Quest_creator.MouseEnter += new System.EventHandler(this.label_Quest_creator_MouseEnter);
            this.label_Quest_creator.MouseLeave += new System.EventHandler(this.label_Quest_creator_MouseLeave);
            // 
            // panel_Quest_Creator
            // 
            this.panel_Quest_Creator.BackColor = System.Drawing.Color.Gainsboro;
            this.panel_Quest_Creator.Controls.Add(this.label_Quest_creator);
            this.panel_Quest_Creator.Cursor = System.Windows.Forms.Cursors.Hand;
            this.panel_Quest_Creator.Location = new System.Drawing.Point(237, 156);
            this.panel_Quest_Creator.Name = "panel_Quest_Creator";
            this.panel_Quest_Creator.Size = new System.Drawing.Size(177, 30);
            this.panel_Quest_Creator.TabIndex = 12;
            this.panel_Quest_Creator.Visible = false;
            this.panel_Quest_Creator.MouseEnter += new System.EventHandler(this.panel5_MouseEnter);
            this.panel_Quest_Creator.MouseLeave += new System.EventHandler(this.panel5_MouseLeave);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Location = new System.Drawing.Point(156, 57);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(335, 262);
            this.tabControl1.TabIndex = 13;
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.Color.Gainsboro;
            this.tabPage1.Controls.Add(this.label6);
            this.tabPage1.Controls.Add(this.button_clearAll);
            this.tabPage1.Controls.Add(this.button_fill_default);
            this.tabPage1.Controls.Add(this.textBox_mysql_charactersDB);
            this.tabPage1.Controls.Add(this.label_mysql_worldDB);
            this.tabPage1.Controls.Add(this.textbox_mysql_worldDB);
            this.tabPage1.Controls.Add(this.label5);
            this.tabPage1.Controls.Add(this.textBox_mysql_authDB);
            this.tabPage1.Controls.Add(this.label_mysql_password);
            this.tabPage1.Controls.Add(this.label_mysql_username);
            this.tabPage1.Controls.Add(this.label_mysql_port);
            this.tabPage1.Controls.Add(this.label_mysql_hostname);
            this.tabPage1.Controls.Add(this.textbox_mysql_pass);
            this.tabPage1.Controls.Add(this.textbox_mysql_username);
            this.tabPage1.Controls.Add(this.textbox_mysql_port);
            this.tabPage1.Controls.Add(this.textbox_mysql_hostname);
            this.tabPage1.Controls.Add(this.button_mysql_connect);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(327, 236);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "                                       Enter MySQL Info                          " +
    "               ";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(21, 144);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(78, 13);
            this.label6.TabIndex = 18;
            this.label6.Text = "characters DB:";
            // 
            // button_clearAll
            // 
            this.button_clearAll.BackColor = System.Drawing.Color.Silver;
            this.button_clearAll.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button_clearAll.Location = new System.Drawing.Point(273, 195);
            this.button_clearAll.Name = "button_clearAll";
            this.button_clearAll.Size = new System.Drawing.Size(54, 23);
            this.button_clearAll.TabIndex = 14;
            this.button_clearAll.Text = "Clear All";
            this.button_clearAll.UseVisualStyleBackColor = false;
            this.button_clearAll.Click += new System.EventHandler(this.button_clearAll_Click);
            // 
            // button_fill_default
            // 
            this.button_fill_default.BackColor = System.Drawing.Color.Silver;
            this.button_fill_default.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button_fill_default.Location = new System.Drawing.Point(285, 8);
            this.button_fill_default.Name = "button_fill_default";
            this.button_fill_default.Size = new System.Drawing.Size(25, 185);
            this.button_fill_default.TabIndex = 13;
            this.button_fill_default.Text = "fill";
            this.toolTip1.SetToolTip(this.button_fill_default, "Fill default values");
            this.button_fill_default.UseVisualStyleBackColor = false;
            this.button_fill_default.Click += new System.EventHandler(this.button_fill_default_Click);
            // 
            // textBox_mysql_charactersDB
            // 
            this.textBox_mysql_charactersDB.Location = new System.Drawing.Point(100, 143);
            this.textBox_mysql_charactersDB.Name = "textBox_mysql_charactersDB";
            this.textBox_mysql_charactersDB.Size = new System.Drawing.Size(179, 20);
            this.textBox_mysql_charactersDB.TabIndex = 17;
            this.textBox_mysql_charactersDB.Text = "characters";
            // 
            // label_mysql_worldDB
            // 
            this.label_mysql_worldDB.AutoSize = true;
            this.label_mysql_worldDB.Location = new System.Drawing.Point(15, 170);
            this.label_mysql_worldDB.Name = "label_mysql_worldDB";
            this.label_mysql_worldDB.Size = new System.Drawing.Size(84, 13);
            this.label_mysql_worldDB.TabIndex = 12;
            this.label_mysql_worldDB.Text = "world Database:";
            // 
            // textbox_mysql_worldDB
            // 
            this.textbox_mysql_worldDB.Location = new System.Drawing.Point(100, 169);
            this.textbox_mysql_worldDB.Name = "textbox_mysql_worldDB";
            this.textbox_mysql_worldDB.Size = new System.Drawing.Size(179, 20);
            this.textbox_mysql_worldDB.TabIndex = 11;
            this.textbox_mysql_worldDB.Text = "world";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(18, 120);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(80, 13);
            this.label5.TabIndex = 16;
            this.label5.Text = "auth Database:";
            // 
            // textBox_mysql_authDB
            // 
            this.textBox_mysql_authDB.Location = new System.Drawing.Point(100, 117);
            this.textBox_mysql_authDB.Name = "textBox_mysql_authDB";
            this.textBox_mysql_authDB.Size = new System.Drawing.Size(179, 20);
            this.textBox_mysql_authDB.TabIndex = 15;
            this.textBox_mysql_authDB.Text = "auth";
            // 
            // label_mysql_password
            // 
            this.label_mysql_password.AutoSize = true;
            this.label_mysql_password.Location = new System.Drawing.Point(43, 91);
            this.label_mysql_password.Name = "label_mysql_password";
            this.label_mysql_password.Size = new System.Drawing.Size(54, 13);
            this.label_mysql_password.TabIndex = 9;
            this.label_mysql_password.Text = "Pasword: ";
            // 
            // label_mysql_username
            // 
            this.label_mysql_username.AutoSize = true;
            this.label_mysql_username.Location = new System.Drawing.Point(36, 65);
            this.label_mysql_username.Name = "label_mysql_username";
            this.label_mysql_username.Size = new System.Drawing.Size(58, 13);
            this.label_mysql_username.TabIndex = 8;
            this.label_mysql_username.Text = "Username:";
            // 
            // label_mysql_port
            // 
            this.label_mysql_port.AutoSize = true;
            this.label_mysql_port.Location = new System.Drawing.Point(65, 37);
            this.label_mysql_port.Name = "label_mysql_port";
            this.label_mysql_port.Size = new System.Drawing.Size(29, 13);
            this.label_mysql_port.TabIndex = 7;
            this.label_mysql_port.Text = "Port:";
            this.label_mysql_port.Click += new System.EventHandler(this.label_mysql_port_Click);
            // 
            // label_mysql_hostname
            // 
            this.label_mysql_hostname.AutoSize = true;
            this.label_mysql_hostname.Location = new System.Drawing.Point(18, 11);
            this.label_mysql_hostname.Name = "label_mysql_hostname";
            this.label_mysql_hostname.Size = new System.Drawing.Size(76, 13);
            this.label_mysql_hostname.TabIndex = 6;
            this.label_mysql_hostname.Text = "Hostname /IP:";
            // 
            // textbox_mysql_pass
            // 
            this.textbox_mysql_pass.AutoCompleteCustomSource.AddRange(new string[] {
            "ascent"});
            this.textbox_mysql_pass.Location = new System.Drawing.Point(100, 88);
            this.textbox_mysql_pass.Name = "textbox_mysql_pass";
            this.textbox_mysql_pass.Size = new System.Drawing.Size(179, 20);
            this.textbox_mysql_pass.TabIndex = 4;
            this.textbox_mysql_pass.TextChanged += new System.EventHandler(this.textbox_mysql_pass_TextChanged);
            // 
            // textbox_mysql_username
            // 
            this.textbox_mysql_username.Location = new System.Drawing.Point(100, 62);
            this.textbox_mysql_username.Name = "textbox_mysql_username";
            this.textbox_mysql_username.Size = new System.Drawing.Size(179, 20);
            this.textbox_mysql_username.TabIndex = 3;
            this.textbox_mysql_username.Text = "root";
            // 
            // textbox_mysql_port
            // 
            this.textbox_mysql_port.Location = new System.Drawing.Point(100, 34);
            this.textbox_mysql_port.Name = "textbox_mysql_port";
            this.textbox_mysql_port.Size = new System.Drawing.Size(179, 20);
            this.textbox_mysql_port.TabIndex = 2;
            this.textbox_mysql_port.Text = "3306";
            this.textbox_mysql_port.TextChanged += new System.EventHandler(this.textbox_mysql_port_TextChanged);
            this.textbox_mysql_port.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textbox_mysql_port_KeyPress);
            // 
            // textbox_mysql_hostname
            // 
            this.textbox_mysql_hostname.Location = new System.Drawing.Point(100, 8);
            this.textbox_mysql_hostname.Name = "textbox_mysql_hostname";
            this.textbox_mysql_hostname.Size = new System.Drawing.Size(179, 20);
            this.textbox_mysql_hostname.TabIndex = 1;
            this.textbox_mysql_hostname.Text = "127.0.0.1";
            this.textbox_mysql_hostname.TextChanged += new System.EventHandler(this.textbox_mysql_hostname_TextChanged);
            // 
            // button_mysql_connect
            // 
            this.button_mysql_connect.BackColor = System.Drawing.Color.DimGray;
            this.button_mysql_connect.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button_mysql_connect.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button_mysql_connect.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_mysql_connect.ForeColor = System.Drawing.Color.White;
            this.button_mysql_connect.Location = new System.Drawing.Point(100, 195);
            this.button_mysql_connect.Name = "button_mysql_connect";
            this.button_mysql_connect.Size = new System.Drawing.Size(145, 35);
            this.button_mysql_connect.TabIndex = 0;
            this.button_mysql_connect.Text = "Connect";
            this.button_mysql_connect.UseVisualStyleBackColor = false;
            this.button_mysql_connect.Click += new System.EventHandler(this.button_mysql_connect_Click);
            // 
            // timer1
            // 
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // panel_Account_Creator
            // 
            this.panel_Account_Creator.BackColor = System.Drawing.Color.Gainsboro;
            this.panel_Account_Creator.Controls.Add(this.label_Account_Creator);
            this.panel_Account_Creator.Cursor = System.Windows.Forms.Cursors.Hand;
            this.panel_Account_Creator.Location = new System.Drawing.Point(237, 189);
            this.panel_Account_Creator.Name = "panel_Account_Creator";
            this.panel_Account_Creator.Size = new System.Drawing.Size(177, 30);
            this.panel_Account_Creator.TabIndex = 15;
            this.panel_Account_Creator.Visible = false;
            this.panel_Account_Creator.MouseEnter += new System.EventHandler(this.panel_Account_Creator_MouseEnter);
            this.panel_Account_Creator.MouseLeave += new System.EventHandler(this.panel_Account_Creator_MouseLeave);
            // 
            // label_Account_Creator
            // 
            this.label_Account_Creator.BackColor = System.Drawing.Color.Transparent;
            this.label_Account_Creator.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_Account_Creator.ForeColor = System.Drawing.Color.Black;
            this.label_Account_Creator.Location = new System.Drawing.Point(0, 0);
            this.label_Account_Creator.Name = "label_Account_Creator";
            this.label_Account_Creator.Size = new System.Drawing.Size(174, 29);
            this.label_Account_Creator.TabIndex = 0;
            this.label_Account_Creator.Text = "Account Creator";
            this.label_Account_Creator.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label_Account_Creator.Visible = false;
            this.label_Account_Creator.Click += new System.EventHandler(this.label_Account_Creator_Click);
            this.label_Account_Creator.MouseEnter += new System.EventHandler(this.label_Account_Creator_MouseEnter);
            this.label_Account_Creator.MouseLeave += new System.EventHandler(this.label_Account_Creator_MouseLeave);
            // 
            // toolTip1
            // 
            this.toolTip1.Tag = "";
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.Color.Gainsboro;
            this.panel5.Controls.Add(this.label11);
            this.panel5.Cursor = System.Windows.Forms.Cursors.Hand;
            this.panel5.Location = new System.Drawing.Point(237, 221);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(177, 30);
            this.panel5.TabIndex = 117;
            this.panel5.Visible = false;
            this.panel5.MouseEnter += new System.EventHandler(this.panel5_MouseEnter_1);
            this.panel5.MouseLeave += new System.EventHandler(this.panel5_MouseLeave_1);
            // 
            // label11
            // 
            this.label11.BackColor = System.Drawing.Color.Transparent;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.Color.Black;
            this.label11.Location = new System.Drawing.Point(0, -1);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(174, 32);
            this.label11.TabIndex = 0;
            this.label11.Text = "Disable";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label11.Click += new System.EventHandler(this.label11_Click);
            this.label11.MouseEnter += new System.EventHandler(this.label11_MouseEnter);
            this.label11.MouseLeave += new System.EventHandler(this.label11_MouseLeave);
            // 
            // panel6
            // 
            this.panel6.BackColor = System.Drawing.Color.Gainsboro;
            this.panel6.Controls.Add(this.label12);
            this.panel6.Cursor = System.Windows.Forms.Cursors.Hand;
            this.panel6.Location = new System.Drawing.Point(237, 255);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(177, 30);
            this.panel6.TabIndex = 118;
            this.panel6.Visible = false;
            this.panel6.Click += new System.EventHandler(this.panel6_Click);
            this.panel6.MouseEnter += new System.EventHandler(this.panel6_MouseEnter);
            this.panel6.MouseLeave += new System.EventHandler(this.panel6_MouseLeave);
            // 
            // label12
            // 
            this.label12.BackColor = System.Drawing.Color.Transparent;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.ForeColor = System.Drawing.Color.Black;
            this.label12.Location = new System.Drawing.Point(0, -1);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(174, 32);
            this.label12.TabIndex = 0;
            this.label12.Text = "Conditions";
            this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label12.Click += new System.EventHandler(this.label12_Click);
            this.label12.MouseEnter += new System.EventHandler(this.label12_MouseEnter);
            this.label12.MouseLeave += new System.EventHandler(this.label12_MouseLeave);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(12, 256);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(135, 30);
            this.label13.TabIndex = 119;
            this.label13.Text = "Database Editor for \r\nTrinityCore TDB 335.62";
            // 
            // panel7
            // 
            this.panel7.BackColor = System.Drawing.Color.Gainsboro;
            this.panel7.Controls.Add(this.label14);
            this.panel7.Cursor = System.Windows.Forms.Cursors.Hand;
            this.panel7.Location = new System.Drawing.Point(237, 289);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(177, 30);
            this.panel7.TabIndex = 120;
            this.panel7.Visible = false;
            // 
            // label14
            // 
            this.label14.BackColor = System.Drawing.Color.Transparent;
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.ForeColor = System.Drawing.Color.Black;
            this.label14.Location = new System.Drawing.Point(0, -1);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(174, 32);
            this.label14.TabIndex = 0;
            this.label14.Text = "Smart Scripts";
            this.label14.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label14.Click += new System.EventHandler(this.label14_Click);
            this.label14.MouseEnter += new System.EventHandler(this.label14_MouseEnter);
            this.label14.MouseLeave += new System.EventHandler(this.label14_MouseLeave);
            // 
            // label_version
            // 
            this.label_version.AutoSize = true;
            this.label_version.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_version.ForeColor = System.Drawing.Color.Maroon;
            this.label_version.Location = new System.Drawing.Point(399, 35);
            this.label_version.Name = "label_version";
            this.label_version.Size = new System.Drawing.Size(54, 16);
            this.label_version.TabIndex = 121;
            this.label_version.Text = "version";
            this.label_version.Visible = false;
            this.label_version.Click += new System.EventHandler(this.label15_Click);
            // 
            // panel8
            // 
            this.panel8.BackColor = System.Drawing.Color.Gainsboro;
            this.panel8.Controls.Add(this.label15);
            this.panel8.Cursor = System.Windows.Forms.Cursors.Hand;
            this.panel8.Location = new System.Drawing.Point(237, 323);
            this.panel8.Name = "panel8";
            this.panel8.Size = new System.Drawing.Size(177, 30);
            this.panel8.TabIndex = 122;
            this.panel8.Visible = false;
            // 
            // label15
            // 
            this.label15.BackColor = System.Drawing.Color.Transparent;
            this.label15.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.ForeColor = System.Drawing.Color.Black;
            this.label15.Location = new System.Drawing.Point(0, -2);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(174, 32);
            this.label15.TabIndex = 0;
            this.label15.Text = "Mail Sender";
            this.label15.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label15.Click += new System.EventHandler(this.label15_Click_1);
            this.label15.MouseEnter += new System.EventHandler(this.label15_MouseEnter);
            this.label15.MouseLeave += new System.EventHandler(this.label15_MouseLeave);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Silver;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(0, 84);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(155, 157);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 4;
            this.pictureBox1.TabStop = false;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.DimGray;
            this.button1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button1.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.Color.White;
            this.button1.Location = new System.Drawing.Point(0, 321);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(155, 43);
            this.button1.TabIndex = 123;
            this.button1.Text = "Start without MySQL Connection";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.DimGray;
            this.button2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button2.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.ForeColor = System.Drawing.Color.White;
            this.button2.Location = new System.Drawing.Point(15, 370);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(120, 25);
            this.button2.TabIndex = 124;
            this.button2.Text = "Control Panel";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Visible = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // CB_NoMySQL
            // 
            this.CB_NoMySQL.AutoSize = true;
            this.CB_NoMySQL.BackColor = System.Drawing.Color.DimGray;
            this.CB_NoMySQL.Font = new System.Drawing.Font("Maiandra GD", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CB_NoMySQL.ForeColor = System.Drawing.Color.White;
            this.CB_NoMySQL.Location = new System.Drawing.Point(0, 35);
            this.CB_NoMySQL.Name = "CB_NoMySQL";
            this.CB_NoMySQL.Size = new System.Drawing.Size(120, 32);
            this.CB_NoMySQL.TabIndex = 125;
            this.CB_NoMySQL.Text = "Start without\r\nMySQL Connection";
            this.CB_NoMySQL.UseVisualStyleBackColor = false;
            this.CB_NoMySQL.Visible = false;
            this.CB_NoMySQL.CheckedChanged += new System.EventHandler(this.CB_NoMySQL_CheckedChanged);
            this.CB_NoMySQL.MouseEnter += new System.EventHandler(this.CB_NoMySQL_MouseEnter);
            this.CB_NoMySQL.MouseLeave += new System.EventHandler(this.CB_NoMySQL_MouseLeave);
            // 
            // Form_MainMenu
            // 
            this.AcceptButton = this.button_mysql_connect;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Silver;
            this.ClientSize = new System.Drawing.Size(491, 398);
            this.Controls.Add(this.CB_NoMySQL);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.panel8);
            this.Controls.Add(this.label_version);
            this.Controls.Add(this.panel7);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.panel6);
            this.Controls.Add(this.panel5);
            this.Controls.Add(this.panel_Account_Creator);
            this.Controls.Add(this.panel_Quest_Creator);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.linkLabel1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Form_MainMenu";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Trinity Creator";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form_MainMenu_FormClosed);
            this.Load += new System.EventHandler(this.Form_MainMenu_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel_Quest_Creator.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.panel_Account_Creator.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            this.panel6.ResumeLayout(false);
            this.panel7.ResumeLayout(false);
            this.panel8.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.LinkLabel linkLabel1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label_Npc_creator;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Label label_GO_creator;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label_Quest_creator;
        private System.Windows.Forms.Panel panel_Quest_Creator;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.Button button_clearAll;
        private System.Windows.Forms.Button button_fill_default;
        private System.Windows.Forms.Label label_mysql_worldDB;
        private System.Windows.Forms.Label label_mysql_password;
        private System.Windows.Forms.Label label_mysql_username;
        private System.Windows.Forms.Label label_mysql_port;
        private System.Windows.Forms.Label label_mysql_hostname;
        private System.Windows.Forms.Button button_mysql_connect;
        internal System.Windows.Forms.Label label_mysql_status;
        private System.Windows.Forms.Label lbl_MySQL_Status;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Panel panel_Account_Creator;
        private System.Windows.Forms.Label label_Account_Creator;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Panel panel7;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label_version;
        private System.Windows.Forms.Panel panel8;
        private System.Windows.Forms.Label label15;
        internal System.Windows.Forms.Button button1;
        internal System.Windows.Forms.Button button2;
        internal System.Windows.Forms.CheckBox CB_NoMySQL;
        internal System.Windows.Forms.TextBox textbox_mysql_worldDB;
        internal System.Windows.Forms.TextBox textbox_mysql_username;
        internal System.Windows.Forms.TextBox textbox_mysql_port;
        internal System.Windows.Forms.TextBox textbox_mysql_hostname;
        internal System.Windows.Forms.TextBox textBox_mysql_charactersDB;
        internal System.Windows.Forms.TextBox textBox_mysql_authDB;
        internal System.Windows.Forms.TextBox textbox_mysql_pass;
    }
}

