using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace SpawnCreator
{
    public partial class BackToMainMenu : Form
    {
        public BackToMainMenu()
        {
            InitializeComponent();
        }

        Form_MainMenu mainmenu = new Form_MainMenu();

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("http://emucraft.com");
        }

        private bool mouseDown;
        private Point lastLocation;

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            mouseDown = true;
            lastLocation = e.Location;
        }

        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            if (mouseDown)
            {
                Location = new Point(
                    (Location.X - lastLocation.X) + e.X, (Location.Y - lastLocation.Y) + e.Y);

                Update();
            }
        }

        private void panel1_MouseUp(object sender, MouseEventArgs e)
        {
            mouseDown = false;
        }

        private void panel2_MouseEnter(object sender, EventArgs e)
        {
            panel2.BackColor = Color.Firebrick;
            label2.ForeColor = Color.White;
        }

        private void panel2_MouseLeave(object sender, EventArgs e)
        {
            panel2.BackColor = Color.Gainsboro;
            label2.ForeColor = Color.Black;
        }

        private void panel2_Click(object sender, EventArgs e)
        {
            Form_ItemCreator form2 = new Form_ItemCreator();
            form2.Show();
            Hide();

            //same as Form_MainMenu
            //form2.timer1.Enabled = true;
        }

        private void panel3_MouseEnter(object sender, EventArgs e)
        {
            panel3.BackColor = Color.Gray;
            label_Npc_creator.ForeColor = Color.White;
            //label_Npc_creator.Text = "working..";
        }

        private void panel3_MouseLeave(object sender, EventArgs e)
        {
            panel3.BackColor = Color.Gainsboro;
            label_Npc_creator.ForeColor = Color.Black;
            //label_Npc_creator.Text = "NPC Creator";
        }

        private void label6_MouseEnter(object sender, EventArgs e)
        {
            panel4.BackColor = Color.Gray;
            label_GO_creator.ForeColor = Color.White;
            //label_GO_creator.Text = "working..";
        }

        private void label6_MouseLeave(object sender, EventArgs e)
        {
            panel4.BackColor = Color.Gainsboro;
            label_GO_creator.ForeColor = Color.Black;
            //label_GO_creator.Text = "GameObject Creator";
        }

        private void label7_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void label7_MouseEnter(object sender, EventArgs e)
        {
            label7.BackColor = Color.Firebrick;
            label7.ForeColor = Color.White;
        }

        private void label7_MouseLeave(object sender, EventArgs e)
        {
            label7.BackColor = Color.IndianRed;
            label7.ForeColor = Color.Black;
        }

        private void label8_MouseEnter(object sender, EventArgs e)
        {
            label8.BackColor = Color.Firebrick;
            label8.ForeColor = Color.White;
        }

        private void label8_MouseLeave(object sender, EventArgs e)
        {
            label8.BackColor = Color.IndianRed;
            label8.ForeColor = Color.Black;
        }

        private void label8_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        } 

        //------------------------------------]


        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label_GO_creator_Click(object sender, EventArgs e)
        {

        }

        private void panel5_MouseEnter(object sender, EventArgs e)
        {
            label_Quest_creator.BackColor = Color.Gray;
            label_Quest_creator.ForeColor = Color.White;
        }

        private void panel5_MouseLeave(object sender, EventArgs e)
        {
            label_Quest_creator.BackColor = Color.IndianRed;
            label_Quest_creator.ForeColor = Color.Black;
        }

        private void label_Quest_creator_MouseEnter(object sender, EventArgs e)
        {
            panel_Quest_Creator.BackColor = Color.Gray;
            label_Quest_creator.ForeColor = Color.White;
            //label_Quest_creator.Text = "working..";
        }

        private void label_Quest_creator_MouseLeave(object sender, EventArgs e)
        {
            panel_Quest_Creator.BackColor = Color.Gainsboro;
            label_Quest_creator.ForeColor = Color.Black;
            //label_Quest_creator.Text = "Quest Creator";
        }

        private void label_Quest_creator_Click(object sender, EventArgs e)
        {

        }

        private void button_mysql_connect_Click(object sender, EventArgs e)
        {
            
            Properties.Settings.Default.Save();
            try
            {
                string myConnection = "datasource=" + mainmenu.textbox_mysql_hostname.Text + ";port=" + mainmenu.textbox_mysql_port.Text + ";username=" + mainmenu.textbox_mysql_username.Text + ";password=" + mainmenu.textbox_mysql_pass.Text;
                MySqlConnection myConn = new MySqlConnection(myConnection);
                MySqlDataAdapter myDataAdapter = new MySqlDataAdapter();

                MySqlCommandBuilder cb = new MySqlCommandBuilder(myDataAdapter);
                myConn.Open();
                DataSet ds = new DataSet();

                label1.Visible = true;
                label2.Visible = true;
                label_Npc_creator.Visible = true;
                label_GO_creator.Visible = true;
                label_Quest_creator.Visible = true;
                panel1.Visible = true;
                panel2.Visible = true;
                panel3.Visible = true;
                panel4.Visible = true;
                panel_Quest_Creator.Visible = true;
                label_Account_Creator.Visible = true;
                panel_Account_Creator.Visible = true;

                Form_ItemCreator form_itemCreator = new Form_ItemCreator();
                form_itemCreator.label_mysql_status2.Text = "Connected!";
                form_itemCreator.label_mysql_status2.ForeColor = Color.LawnGreen;
                label_mysql_status.Text = "Connected!";
                label_mysql_status.ForeColor = Color.LawnGreen;

                //textbox_mysql_username.Visible = true;
                //textbox_mysql_pass.Visible = true;
                //tabControl1.Visible = false;

                timer1.Enabled = true;
                myConn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button_clearAll_Click(object sender, EventArgs e)
        {
            //textbox_mysql_hostname.Text = "";
            //textbox_mysql_port.Text = "";
            //textbox_mysql_username.Text = "";
            //textbox_mysql_worldDB.Text = "";
            //textbox_mysql_pass.Text = "";
            //textBox_mysql_authDB.Text = "";
            //textBox_mysql_charactersDB.Text = "";
        }

        private void button_fill_default_Click(object sender, EventArgs e)
        {
            //textbox_mysql_hostname.Text = "127.0.0.1";
            //textbox_mysql_port.Text = "3306";
            //textbox_mysql_username.Text = "root";
            //textbox_mysql_worldDB.Text = "world";
            //textBox_mysql_authDB.Text = "auth";
            //textBox_mysql_charactersDB.Text = "characters";
            //textbox_mysql_pass.Text     = "";
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            try
            {
                string myConnection = "datasource=" + mainmenu.textbox_mysql_hostname.Text + ";port=" + mainmenu.textbox_mysql_port.Text + ";username=" + mainmenu.textbox_mysql_username.Text + ";password=" + mainmenu.textbox_mysql_pass.Text;
                MySqlConnection myConn = new MySqlConnection(myConnection);
                MySqlDataAdapter myDataAdapter = new MySqlDataAdapter();
                //myDataAdapter.SelectCommand = new MySqlCommand("select * from auth.account;");
                MySqlCommandBuilder cb = new MySqlCommandBuilder(myDataAdapter);
                myConn.Open();
                DataSet ds = new DataSet();

                //Form_ItemCreator form_itemCreator = new Form_ItemCreator();
                //form_itemCreator.label_mysql_status2.Text = "Connected!";
                //form_itemCreator.label_mysql_status2.ForeColor = Color.Green;

                label_mysql_status.Text = "Connected!";
                label_mysql_status.ForeColor = Color.LawnGreen;

                myConn.Close();
            }
            catch (Exception /*ex*/)
            {
                //MessageBox.Show(ex.Message);
                label_mysql_status.Text = "Connection Lost - MySQL is not running";
                label_mysql_status.ForeColor = Color.Black;
            }
        }

        private void Form_MainMenu_Load(object sender, EventArgs e)
        {
            mainmenu.textbox_mysql_pass.Text = Properties.Settings.Default.mysql_pass;
            mainmenu.textbox_mysql_username.Text = Properties.Settings.Default.mysql_username;
            mainmenu.textbox_mysql_hostname.Text = Properties.Settings.Default.mysql_hostname;
            mainmenu.textbox_mysql_port.Text = Properties.Settings.Default.mysql_port;
            mainmenu.textbox_mysql_worldDB.Text = Properties.Settings.Default.mysql_worldDB;
            mainmenu.textBox_mysql_authDB.Text = Properties.Settings.Default.mysql_authDB;
            mainmenu.textBox_mysql_charactersDB.Text = Properties.Settings.Default.mysql_charactersDB;
        }

        private void Form_MainMenu_FormClosed(object sender, FormClosedEventArgs e)
        {
            Properties.Settings.Default.mysql_pass = mainmenu.textbox_mysql_pass.Text;
            Properties.Settings.Default.mysql_username = mainmenu.textbox_mysql_username.Text;
            Properties.Settings.Default.mysql_hostname = mainmenu.textbox_mysql_hostname.Text;
            Properties.Settings.Default.mysql_port = mainmenu.textbox_mysql_port.Text;
            Properties.Settings.Default.mysql_worldDB = mainmenu.textbox_mysql_worldDB.Text;
            Properties.Settings.Default.mysql_authDB = mainmenu.textBox_mysql_authDB.Text;
            Properties.Settings.Default.mysql_charactersDB = mainmenu.textBox_mysql_charactersDB.Text;
            Properties.Settings.Default.Save();
        }

        private void textbox_mysql_port_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            // only allow one decimal point
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }

        private void panel_Account_Creator_MouseEnter(object sender, EventArgs e)
        {

        }

        private void panel_Account_Creator_MouseLeave(object sender, EventArgs e)
        {

        }

        private void label_Account_Creator_MouseLeave(object sender, EventArgs e)
        {
            panel_Account_Creator.BackColor = Color.Gainsboro;
            label_Account_Creator.ForeColor = Color.Black;
        }

        private void label_Account_Creator_MouseEnter(object sender, EventArgs e)
        {
            panel_Account_Creator.BackColor = Color.Firebrick;
            label_Account_Creator.ForeColor = Color.White;
        }

        private void label_Account_Creator_Click(object sender, EventArgs e)
        {
            AccountCreator acc = new AccountCreator();
            acc.Show();
            Hide();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label7_Click_1(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void label2_Click(object sender, EventArgs e)
        {
            Form_ItemCreator form2 = new Form_ItemCreator();
            form2.Show();
            Close();

            //form2.timer1.Enabled = true;
        }

        private void panel2_MouseEnter_1(object sender, EventArgs e)
        {
            
        }

        private void panel2_MouseLeave_1(object sender, EventArgs e)
        {
            
        }

        private void label2_MouseEnter(object sender, EventArgs e)
        {
            panel2.BackColor = Color.Firebrick;
            label2.ForeColor = Color.White;
        }

        private void label2_MouseLeave(object sender, EventArgs e)
        {
            panel2.BackColor = Color.Gainsboro;
            label2.ForeColor = Color.Black;
        }

        private void label_Account_Creator_MouseEnter_1(object sender, EventArgs e)
        {
            panel_Account_Creator.BackColor = Color.Firebrick;
            label_Account_Creator.ForeColor = Color.White;
        }

        private void label_Account_Creator_Click_1(object sender, EventArgs e)
        {
            Close();
            AccountCreator acc = new AccountCreator();
            acc.Show();
        }

        private void label_Account_Creator_MouseLeave_1(object sender, EventArgs e)
        {
            panel_Account_Creator.BackColor = Color.Gainsboro;
            label_Account_Creator.ForeColor = Color.Black;
        }

        private void label_Npc_creator_MouseEnter(object sender, EventArgs e)
        {
            panel3.BackColor = Color.Firebrick;
            label_Npc_creator.ForeColor = Color.White;
        }

        private void label_Npc_creator_MouseLeave(object sender, EventArgs e)
        {
            panel3.BackColor = Color.Gainsboro;
            label_Npc_creator.ForeColor = Color.Black;
        }

        private void label_GO_creator_MouseEnter(object sender, EventArgs e)
        {
            panel4.BackColor = Color.Firebrick;
            label_GO_creator.ForeColor = Color.White;
        }

        private void label_GO_creator_MouseLeave(object sender, EventArgs e)
        {
            panel4.BackColor = Color.Gainsboro;
            label_GO_creator.ForeColor = Color.Black;
        }

        private void label_Quest_creator_MouseEnter_1(object sender, EventArgs e)
        {
            panel_Quest_Creator.BackColor = Color.Firebrick;
            label_Quest_creator.ForeColor = Color.White;
        }

        private void label_Quest_creator_MouseLeave_1(object sender, EventArgs e)
        {
            panel_Quest_Creator.BackColor = Color.Gainsboro;
            label_Quest_creator.ForeColor = Color.Black;
        }

        private void label8_Click_1(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private void BackToMainMenu_Load(object sender, EventArgs e)
        {
            label_version.Text = "v2.3";

            try
            {
                string myConnection = "datasource=" + mainmenu.textbox_mysql_hostname.Text + ";port=" + mainmenu.textbox_mysql_port.Text + ";username=" + mainmenu.textbox_mysql_username.Text + ";password=" + mainmenu.textbox_mysql_pass.Text;
                MySqlConnection myConn = new MySqlConnection(myConnection);
                MySqlDataAdapter myDataAdapter = new MySqlDataAdapter();

                MySqlCommandBuilder cb = new MySqlCommandBuilder(myDataAdapter);
                myConn.Open();
                DataSet ds = new DataSet();

                label1.Visible = true;
                label2.Visible = true;
                label_Npc_creator.Visible = true;
                label_GO_creator.Visible = true;
                label_Quest_creator.Visible = true;
                panel1.Visible = true;
                panel2.Visible = true;
                panel3.Visible = true;
                panel4.Visible = true;
                panel_Quest_Creator.Visible = true;
                label_Account_Creator.Visible = true;
                panel_Account_Creator.Visible = true;

                Form_ItemCreator form_itemCreator = new Form_ItemCreator();
                form_itemCreator.label_mysql_status2.Text = "Connected!";
                form_itemCreator.label_mysql_status2.ForeColor = Color.LawnGreen;
                label_mysql_status.Text = "Connected!";
                label_mysql_status.ForeColor = Color.LawnGreen;

                mainmenu.textbox_mysql_username.Visible = true;
                mainmenu.textbox_mysql_pass.Visible = true;
                //mainmenu.tabControl1.Visible = false;

                timer1.Enabled = true;
                myConn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void timer1_Tick_1(object sender, EventArgs e)
        {
            try
            {
                string myConnection = "datasource=" + mainmenu.textbox_mysql_hostname.Text + ";port=" + mainmenu.textbox_mysql_port.Text + ";username=" + mainmenu.textbox_mysql_username.Text + ";password=" + mainmenu.textbox_mysql_pass.Text;
                MySqlConnection myConn = new MySqlConnection(myConnection);
                MySqlDataAdapter myDataAdapter = new MySqlDataAdapter();
                //myDataAdapter.SelectCommand = new MySqlCommand("select * from auth.account;");
                MySqlCommandBuilder cb = new MySqlCommandBuilder(myDataAdapter);
                myConn.Open();
                DataSet ds = new DataSet();

                //Form_ItemCreator form_itemCreator = new Form_ItemCreator();
                //form_itemCreator.label_mysql_status2.Text = "Connected!";
                //form_itemCreator.label_mysql_status2.ForeColor = Color.Green;

                label_mysql_status.Text = "Connected!";
                label_mysql_status.ForeColor = Color.LawnGreen;

                myConn.Close();
            }
            catch (Exception /*ex*/)
            {
                //MessageBox.Show(ex.Message);
                label_mysql_status.Text = "Connection Lost - MySQL is not running";
                label_mysql_status.ForeColor = Color.Black;
            }
        }

        private void panel_Quest_Creator_MouseEnter(object sender, EventArgs e)
        {
            //label_Quest_creator.BackColor = Color.Gray;
            //label_Quest_creator.ForeColor = Color.White;
        }

        private void panel_Quest_Creator_MouseLeave(object sender, EventArgs e)
        {
            //label_Quest_creator.BackColor = Color.IndianRed;
            //label_Quest_creator.ForeColor = Color.Black;
        }

        private void panel4_MouseEnter(object sender, EventArgs e)
        {
            //label_GO_creator.BackColor = Color.Gainsboro;
            //label_GO_creator.ForeColor = Color.Black;

            
        }

        private void panel4_MouseLeave(object sender, EventArgs e)
        {
            //label_GO_creator.BackColor = Color.Firebrick;
            //label_GO_creator.ForeColor = Color.White;
        }

        private void label7_MouseEnter_1(object sender, EventArgs e)
        {
            label7.BackColor = Color.Firebrick;
            label7.ForeColor = Color.White;
        }

        private void label7_MouseLeave_1(object sender, EventArgs e)
        {
            label7.BackColor = Color.IndianRed;
            label7.ForeColor = Color.Black;
        }

        private void label8_MouseEnter_1(object sender, EventArgs e)
        {
            label8.BackColor = Color.Firebrick;
            label8.ForeColor = Color.White;
        }

        private void label8_MouseLeave_1(object sender, EventArgs e)
        {
            label8.BackColor = Color.IndianRed;
            label8.ForeColor = Color.Black;
        }

        private void panel3_MouseEnter_1(object sender, EventArgs e)
        {
            panel3.BackColor = Color.Gray;
            label_Npc_creator.ForeColor = Color.White;
        }

        private void panel3_MouseLeave_1(object sender, EventArgs e)
        {
            panel3.BackColor = Color.Gainsboro;
            label_Npc_creator.ForeColor = Color.Black;
        }

        private void label_Npc_creator_Click(object sender, EventArgs e)
        {
            Close();
            NPC_Creator npc = new NPC_Creator();
            npc.Show();
        }

        private void label_GO_creator_Click_1(object sender, EventArgs e)
        {
            Close();
            GameObject_Creator go = new GameObject_Creator();
            go.Show();
        }

        private void panel5_MouseEnter_1(object sender, EventArgs e)
        {
            //panel5.BackColor = Color.Firebrick;
            //label11.ForeColor = Color.White;
        }

        private void panel5_MouseLeave_1(object sender, EventArgs e)
        {
            //panel5.BackColor = Color.Gainsboro;
            //label11.ForeColor = Color.Black;
        }
        //===========================================================
        private void panel6_MouseEnter(object sender, EventArgs e)
        {
            //panel6.BackColor = Color.Firebrick;
            //label12.ForeColor = Color.White;
        }

        private void panel6_MouseLeave(object sender, EventArgs e)
        {
            //panel6.BackColor = Color.Gainsboro;
            //label12.ForeColor = Color.Black;
        }
        //=========================================================
        private void label11_MouseEnter(object sender, EventArgs e)
        {
            panel5.BackColor = Color.Firebrick;
            label11.ForeColor = Color.White;
        }

        private void label11_MouseLeave(object sender, EventArgs e)
        {
            panel5.BackColor = Color.Gainsboro;
            label11.ForeColor = Color.Black;
        }
        //==========================================================
        private void label12_MouseEnter(object sender, EventArgs e)
        {
            panel6.BackColor = Color.Firebrick;
            label12.ForeColor = Color.White;
        }

        private void label12_MouseLeave(object sender, EventArgs e)
        {
            panel6.BackColor = Color.Gainsboro;
            label12.ForeColor = Color.Black;  
        }

        private void label11_Click(object sender, EventArgs e)
        {
            //Disable - Click
            Disable_Form disable = new Disable_Form();
            disable.Show();
            Hide();
        }

        private void label12_Click(object sender, EventArgs e)
        {
            //Conditions - Click

            //Hide Main Menu Form
            Hide();

            //And then Show Conditions Form
            Conditions_Form con = new Conditions_Form();
            con.Show();
        }

        private void label9_MouseEnter(object sender, EventArgs e)
        {
            panel8.BackColor = Color.Firebrick;
            label9.ForeColor = Color.White;
        }

        private void label9_MouseLeave(object sender, EventArgs e)
        {
            panel8.BackColor = Color.Gainsboro;
            label9.ForeColor = Color.Black;
        }

        private void label9_Click(object sender, EventArgs e)
        {
            Hide();
            SmartScripts smart = new SmartScripts();
            smart.Show();
        }

        private void label10_MouseEnter(object sender, EventArgs e)
        {
            panel9.BackColor = Color.Firebrick;
            label10.ForeColor = Color.White;
        }

        private void label10_MouseLeave(object sender, EventArgs e)
        {
            panel9.BackColor = Color.Gainsboro;
            label10.ForeColor = Color.Black;
        }

        private void label10_Click(object sender, EventArgs e)
        {
            Close();

            MailSender mail = new MailSender();
            mail.Show();
        }

        private void label_Quest_creator_Click_1(object sender, EventArgs e)
        {
            Close();

            QuestTemplate quest = new QuestTemplate();
            quest.Show();
        }
    }
}
