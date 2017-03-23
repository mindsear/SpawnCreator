namespace SpawnCreator
{
    partial class ControlPanel
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ControlPanel));
            this.textBox_auth_and_world_path = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox_mysql_path = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.dot_authserver = new System.Windows.Forms.Label();
            this.label_authserver = new System.Windows.Forms.Label();
            this.label_worldserver = new System.Windows.Forms.Label();
            this.dot_worldserver = new System.Windows.Forms.Label();
            this.label_mysql = new System.Windows.Forms.Label();
            this.dot_mysql = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.panel1 = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.button3 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.button4 = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.checkBox2 = new System.Windows.Forms.CheckBox();
            this.button7 = new System.Windows.Forms.Button();
            this.TB_BTN = new System.Windows.Forms.TextBox();
            this.BTN_Close = new System.Windows.Forms.Button();
            this.timer2 = new System.Windows.Forms.Timer(this.components);
            this.button8 = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // textBox_auth_and_world_path
            // 
            this.textBox_auth_and_world_path.Location = new System.Drawing.Point(15, 25);
            this.textBox_auth_and_world_path.Name = "textBox_auth_and_world_path";
            this.textBox_auth_and_world_path.Size = new System.Drawing.Size(276, 20);
            this.textBox_auth_and_world_path.TabIndex = 3;
            this.textBox_auth_and_world_path.Text = "E:\\TrinityCore335\\build\\bin\\Release";
            this.textBox_auth_and_world_path.Click += new System.EventHandler(this.textBox_auth_path_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(164, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Authserver and Worldserver Path";
            // 
            // textBox_mysql_path
            // 
            this.textBox_mysql_path.Location = new System.Drawing.Point(15, 73);
            this.textBox_mysql_path.Name = "textBox_mysql_path";
            this.textBox_mysql_path.Size = new System.Drawing.Size(276, 20);
            this.textBox_mysql_path.TabIndex = 5;
            this.textBox_mysql_path.Text = "C:\\_Server";
            this.textBox_mysql_path.Click += new System.EventHandler(this.textBox_mysql_path_Click);
            this.textBox_mysql_path.TextChanged += new System.EventHandler(this.textBox_mysql_path_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 57);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(85, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "MySQL.bat Path";
            this.toolTip1.SetToolTip(this.label3, "Point to your MySql.bat file or MySql_Start.bat");
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(48, 239);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(154, 23);
            this.button1.TabIndex = 7;
            this.button1.Text = "Start Server";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(48, 277);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(154, 23);
            this.button2.TabIndex = 8;
            this.button2.Text = "Close Server";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // dot_authserver
            // 
            this.dot_authserver.AutoSize = true;
            this.dot_authserver.Font = new System.Drawing.Font("Arial Rounded MT Bold", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dot_authserver.ForeColor = System.Drawing.Color.Gray;
            this.dot_authserver.Location = new System.Drawing.Point(67, 142);
            this.dot_authserver.Name = "dot_authserver";
            this.dot_authserver.Size = new System.Drawing.Size(41, 55);
            this.dot_authserver.TabIndex = 9;
            this.dot_authserver.Text = "•\r\n";
            // 
            // label_authserver
            // 
            this.label_authserver.AutoSize = true;
            this.label_authserver.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_authserver.Location = new System.Drawing.Point(53, 181);
            this.label_authserver.Name = "label_authserver";
            this.label_authserver.Size = new System.Drawing.Size(67, 16);
            this.label_authserver.TabIndex = 10;
            this.label_authserver.Text = "authserver";
            // 
            // label_worldserver
            // 
            this.label_worldserver.AutoSize = true;
            this.label_worldserver.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.label_worldserver.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_worldserver.Location = new System.Drawing.Point(130, 181);
            this.label_worldserver.Name = "label_worldserver";
            this.label_worldserver.Size = new System.Drawing.Size(72, 16);
            this.label_worldserver.TabIndex = 12;
            this.label_worldserver.Text = "worldserver";
            this.label_worldserver.Click += new System.EventHandler(this.label_worldserver_Click);
            this.label_worldserver.MouseEnter += new System.EventHandler(this.label_worldserver_MouseEnter);
            this.label_worldserver.MouseLeave += new System.EventHandler(this.label_worldserver_MouseLeave);
            // 
            // dot_worldserver
            // 
            this.dot_worldserver.AutoSize = true;
            this.dot_worldserver.Font = new System.Drawing.Font("Arial Rounded MT Bold", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dot_worldserver.ForeColor = System.Drawing.Color.Gray;
            this.dot_worldserver.Location = new System.Drawing.Point(144, 142);
            this.dot_worldserver.Name = "dot_worldserver";
            this.dot_worldserver.Size = new System.Drawing.Size(41, 55);
            this.dot_worldserver.TabIndex = 11;
            this.dot_worldserver.Text = "•\r\n";
            // 
            // label_mysql
            // 
            this.label_mysql.AutoSize = true;
            this.label_mysql.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_mysql.Location = new System.Drawing.Point(214, 181);
            this.label_mysql.Name = "label_mysql";
            this.label_mysql.Size = new System.Drawing.Size(60, 16);
            this.label_mysql.TabIndex = 14;
            this.label_mysql.Text = "  MySQL";
            // 
            // dot_mysql
            // 
            this.dot_mysql.AutoSize = true;
            this.dot_mysql.Font = new System.Drawing.Font("Arial Rounded MT Bold", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dot_mysql.ForeColor = System.Drawing.Color.Gray;
            this.dot_mysql.Location = new System.Drawing.Point(224, 142);
            this.dot_mysql.Name = "dot_mysql";
            this.dot_mysql.Size = new System.Drawing.Size(41, 55);
            this.dot_mysql.TabIndex = 13;
            this.dot_mysql.Text = "•\r\n";
            // 
            // timer1
            // 
            this.timer1.Interval = 200;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Gray;
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.button3);
            this.panel1.Controls.Add(this.button5);
            this.panel1.ForeColor = System.Drawing.Color.Black;
            this.panel1.Location = new System.Drawing.Point(711, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(154, 397);
            this.panel1.TabIndex = 15;
            this.panel1.Visible = false;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(49, 99);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(35, 13);
            this.label4.TabIndex = 1;
            this.label4.Text = "label4";
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.Color.SkyBlue;
            this.button3.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button3.Location = new System.Drawing.Point(0, 0);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(11, 394);
            this.button3.TabIndex = 16;
            this.button3.Text = "|||";
            this.button3.UseVisualStyleBackColor = false;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            this.button3.MouseEnter += new System.EventHandler(this.button3_MouseEnter);
            this.button3.MouseLeave += new System.EventHandler(this.button3_MouseLeave);
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(46, 142);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(75, 23);
            this.button5.TabIndex = 0;
            this.button5.Text = "button5";
            this.button5.UseVisualStyleBackColor = true;
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(28, 129);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(139, 17);
            this.checkBox1.TabIndex = 16;
            this.checkBox1.Text = "Start Authserver Hidden";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(217, 239);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(75, 23);
            this.button4.TabIndex = 17;
            this.button4.Text = "Start MySql";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // button6
            // 
            this.button6.Location = new System.Drawing.Point(217, 277);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(75, 23);
            this.button6.TabIndex = 18;
            this.button6.Text = "Close MySql";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // checkBox2
            // 
            this.checkBox2.AutoSize = true;
            this.checkBox2.Location = new System.Drawing.Point(189, 129);
            this.checkBox2.Name = "checkBox2";
            this.checkBox2.Size = new System.Drawing.Size(123, 17);
            this.checkBox2.TabIndex = 19;
            this.checkBox2.Text = "Start MySQL Hidden";
            this.checkBox2.UseVisualStyleBackColor = true;
            // 
            // button7
            // 
            this.button7.Location = new System.Drawing.Point(30, 350);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(123, 23);
            this.button7.TabIndex = 20;
            this.button7.Text = "<- Back to Main Menu";
            this.button7.UseVisualStyleBackColor = true;
            this.button7.Click += new System.EventHandler(this.button7_Click);
            // 
            // TB_BTN
            // 
            this.TB_BTN.Location = new System.Drawing.Point(682, 374);
            this.TB_BTN.Name = "TB_BTN";
            this.TB_BTN.Size = new System.Drawing.Size(23, 20);
            this.TB_BTN.TabIndex = 21;
            this.TB_BTN.Text = "0";
            this.TB_BTN.Visible = false;
            // 
            // BTN_Close
            // 
            this.BTN_Close.Location = new System.Drawing.Point(216, 350);
            this.BTN_Close.Name = "BTN_Close";
            this.BTN_Close.Size = new System.Drawing.Size(75, 23);
            this.BTN_Close.TabIndex = 22;
            this.BTN_Close.Text = "Close";
            this.BTN_Close.UseVisualStyleBackColor = true;
            this.BTN_Close.Click += new System.EventHandler(this.BTN_Close_Click);
            // 
            // timer2
            // 
            this.timer2.Tick += new System.EventHandler(this.timer2_Tick);
            // 
            // button8
            // 
            this.button8.BackColor = System.Drawing.Color.Gainsboro;
            this.button8.Location = new System.Drawing.Point(125, 200);
            this.button8.Name = "button8";
            this.button8.Size = new System.Drawing.Size(77, 23);
            this.button8.TabIndex = 23;
            this.button8.Text = "Restart";
            this.button8.UseVisualStyleBackColor = false;
            this.button8.Click += new System.EventHandler(this.button8_Click);
            this.button8.MouseEnter += new System.EventHandler(this.button8_MouseEnter);
            this.button8.MouseLeave += new System.EventHandler(this.button8_MouseLeave);
            // 
            // ControlPanel
            // 
            this.AcceptButton = this.BTN_Close;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(335, 394);
            this.Controls.Add(this.button8);
            this.Controls.Add(this.BTN_Close);
            this.Controls.Add(this.TB_BTN);
            this.Controls.Add(this.button7);
            this.Controls.Add(this.checkBox2);
            this.Controls.Add(this.button6);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label_mysql);
            this.Controls.Add(this.dot_mysql);
            this.Controls.Add(this.label_worldserver);
            this.Controls.Add(this.dot_worldserver);
            this.Controls.Add(this.label_authserver);
            this.Controls.Add(this.dot_authserver);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.textBox_mysql_path);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.textBox_auth_and_world_path);
            this.Controls.Add(this.label2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ControlPanel";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Control Panel";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ControlPanel_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.ControlPanel_FormClosed);
            this.Load += new System.EventHandler(this.ControlPanel_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox textBox_auth_and_world_path;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox_mysql_path;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label dot_authserver;
        private System.Windows.Forms.Label label_authserver;
        private System.Windows.Forms.Label label_worldserver;
        private System.Windows.Forms.Label dot_worldserver;
        private System.Windows.Forms.Label label_mysql;
        private System.Windows.Forms.Label dot_mysql;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.CheckBox checkBox2;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.TextBox TB_BTN;
        private System.Windows.Forms.Button BTN_Close;
        private System.Windows.Forms.Timer timer2;
        private System.Windows.Forms.Button button8;
    }
}