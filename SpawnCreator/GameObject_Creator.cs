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
using System.IO;

namespace SpawnCreator
{
    public partial class GameObject_Creator : Form
    {
        public GameObject_Creator()
        {
            InitializeComponent();
        }

        private readonly Form_MainMenu form_MM;
        public GameObject_Creator(Form_MainMenu form_MainMenu)
        {
            InitializeComponent();
            form_MM = form_MainMenu;
        }

        private bool _mouseDown;
        private Point lastLocation;

        Form_MainMenu mainmenu = new Form_MainMenu();

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex      == 0) pictureBox1.Image = Properties.Resources.Taxi;
            else if (comboBox1.SelectedIndex == 1) pictureBox1.Image = Properties.Resources.Speak;
            else if (comboBox1.SelectedIndex == 2) pictureBox1.Image = Properties.Resources.Attack;
            else if (comboBox1.SelectedIndex == 3) pictureBox1.Image = Properties.Resources.Directions;
            else if (comboBox1.SelectedIndex == 4) pictureBox1.Image = Properties.Resources.Quest;
        }

        private void GameObject_Creator_Load(object sender, EventArgs e)
        {
            comboBox1.SelectedIndex = 1; // Speak
            comboBox2.SelectedIndex = 0; // GAMEOBJECT_TYPE_DOOR
            comboBox11.SelectedIndex = 0; // INSERT
            timer1.Start(); // check if mysql is running
            timer2.Start(); // stopwatch

            MySqlConnection connection = new MySqlConnection(
                               "datasource = " + form_MM.GetHost() + "; " +
                               "port=" + form_MM.GetPort() + ";" +
                               "username=" + form_MM.GetUser() + ";" +
                               "password=" + form_MM.GetPass() + ";" 
                               );
            string insertQuery = "SELECT max(entry)+1 FROM " + form_MM.GetWorldDB() + ".gameobject_template;";
            //string insertQuery = textBox_SelectMaxPlus1.Text;
            connection.Open();
            MySqlCommand command = new MySqlCommand(insertQuery, connection);

            try
            {

                textBox1.Text = command.ExecuteScalar().ToString();
               
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            connection.Close();
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            textBox33.Text = comboBox2.Text;

            if (comboBox2.Text      == "GAMEOBJECT_TYPE_DOOR") textBox33.Text  = "0";
            else if (comboBox2.Text == "GAMEOBJECT_TYPE_BUTTON") textBox33.Text = "1";
            else if (comboBox2.Text == "GAMEOBJECT_TYPE_QUESTGIVER") textBox33.Text = "2";
            else if (comboBox2.Text == "GAMEOBJECT_TYPE_CHEST") textBox33.Text = "3";
            else if (comboBox2.Text == "GAMEOBJECT_TYPE_BINDER") textBox33.Text = "4";
            else if (comboBox2.Text == "GAMEOBJECT_TYPE_GENERIC") textBox33.Text = "5";
            else if (comboBox2.Text == "GAMEOBJECT_TYPE_TRAP") textBox33.Text = "6";
            else if (comboBox2.Text == "GAMEOBJECT_TYPE_CHAIR") textBox33.Text = "7";
            else if (comboBox2.Text == "GAMEOBJECT_TYPE_SPELL_FOCUS") textBox33.Text = "8";
            else if (comboBox2.Text == "GAMEOBJECT_TYPE_TEXT") textBox33.Text = "9";
            else if (comboBox2.Text == "GAMEOBJECT_TYPE_GOOBER") textBox33.Text = "10";
            else if (comboBox2.Text == "GAMEOBJECT_TYPE_TRANSPORT") textBox33.Text = "11";
            else if (comboBox2.Text == "GAMEOBJECT_TYPE_AREADAMAGE") textBox33.Text = "12";
            else if (comboBox2.Text == "GAMEOBJECT_TYPE_CAMERA") textBox33.Text = "13";
            else if (comboBox2.Text == "GAMEOBJECT_TYPE_MAP_OBJECT") textBox33.Text = "14";
            else if (comboBox2.Text == "GAMEOBJECT_TYPE_MO_TRANSPORT") textBox33.Text = "15";
            else if (comboBox2.Text == "GAMEOBJECT_TYPE_DUEL_ARBITER") textBox33.Text = "16";
            else if (comboBox2.Text == "GAMEOBJECT_TYPE_DUEL_ARBITER") textBox33.Text = "17";
            else if (comboBox2.Text == "GAMEOBJECT_TYPE_RITUAL") textBox33.Text = "18";
            else if (comboBox2.Text == "GAMEOBJECT_TYPE_MAILBOX") textBox33.Text = "19";
            else if (comboBox2.Text == "GAMEOBJECT_TYPE_AUCTIONHOUSE") textBox33.Text = "20";
            else if (comboBox2.Text == "GAMEOBJECT_TYPE_GUARDPOST") textBox33.Text = "21";
            else if (comboBox2.Text == "GAMEOBJECT_TYPE_SPELLCASTER") textBox33.Text = "22";
            else if (comboBox2.Text == "GAMEOBJECT_TYPE_MEETINGSTONE") textBox33.Text = "23";
            else if (comboBox2.Text == "GAMEOBJECT_TYPE_FLAGSTAND") textBox33.Text = "24";
            else if (comboBox2.Text == "GAMEOBJECT_TYPE_FISHINGHOLE") textBox33.Text = "25";
            else if (comboBox2.Text == "GAMEOBJECT_TYPE_FLAGDROP") textBox33.Text = "26";
            else if (comboBox2.Text == "GAMEOBJECT_TYPE_MINI_GAME") textBox33.Text = "27";
            else if (comboBox2.Text == "GAMEOBJECT_TYPE_LOTTERY_KIOSK") textBox33.Text = "28";
            else if (comboBox2.Text == "GAMEOBJECT_TYPE_CAPTURE_POINT") textBox33.Text = "29";
            else if (comboBox2.Text == "GAMEOBJECT_TYPE_AURA_GENERATOR") textBox33.Text = "30";
            else if (comboBox2.Text == "GAMEOBJECT_TYPE_DUNGEON_DIFFICULTY") textBox33.Text = "31";
            else if (comboBox2.Text == "GAMEOBJECT_TYPE_BARBER_CHAIR") textBox33.Text = "32";
            else if (comboBox2.Text == "GAMEOBJECT_TYPE_DESTRUCTIBLE_BUILDING") textBox33.Text = "33";
            else if (comboBox2.Text == "GAMEOBJECT_TYPE_GUILD_BANK") textBox33.Text = "34";
            else if (comboBox2.Text == "GAMEOBJECT_TYPE_TRAPDOOR") textBox33.Text = "35";
        }

        private void label35_Click(object sender, EventArgs e)
        {
            Process.Start("https://trinitycore.atlassian.net/wiki/display/tc/gameobject_template");
        }

        private void button_execute_query_Click(object sender, EventArgs e)
        {
            if (textBox2.Text == "")
            {
                MessageBox.Show("Game Object Name should not be empty", "Error");
                return;
            }
            if (textBox1.Text == "")
            {
                MessageBox.Show("Entry should not be empty", "Error");
                return;
            }

            MySqlConnection connection = new MySqlConnection(
                               "datasource=" + form_MM.GetHost() + ";" +
                               "port=" + form_MM.GetPort() + ";" +
                               "username=" + form_MM.GetUser() + ";" +
                               "password=" + form_MM.GetPass() + ";"
                               );
            string insertQuery = textBox105.Text + " INTO " + form_MM.GetWorldDB() + ".gameobject_template " +
                "(entry, type, displayId, name, IconName, castBarCaption, unk1, " +
                "size, Data0, Data1, Data2, Data3, Data4, Data5, Data6, Data7, Data8, Data9, Data10, Data11, Data12, Data13, Data14, Data15, " +
                "Data16, Data17, Data18, Data19, Data20, Data21, Data22, Data23, AIName, ScriptName, VerifiedBuild) " +
                "VALUES " + 
                "(" + textBox1.Text + ", " + // Entry
                textBox33.Text + ", " + // Type
                textBox3.Text + ", " + // displayId
                "'" + textBox2.Text + "', " + // name
                "'" + comboBox1.Text + "', " + // IconName
                "'" + textBox4.Text + "', '" + // castBarCaption
                textBox28.Text + "', " + // unk1
                textBox34.Text + ", " + // size
                textBox26.Text + ", " + // Data0
                textBox7.Text + ", " + // Data1
                textBox18.Text + ", " + // Data2
                textBox29.Text + ", " + // Data3
                textBox5.Text + ", " + // Data4
                textBox20.Text + ", " + // Data5
                textBox27.Text + ", " + // Data6
                textBox6.Text + ", " + // Data7
                textBox19.Text + ", " + // Data8
                textBox25.Text + ", " + // Data9
                textBox8.Text + ", " + // Data10
                textBox17.Text + ", " + // Data11
                textBox22.Text + ", " + // Data12
                textBox10.Text + ", " + // Data13
                textBox14.Text + ", " + // Data14
                textBox24.Text + ", " + // Data15
                textBox12.Text + ", " + // Data16
                textBox16.Text + ", " + // Data17
                textBox23.Text + ", " + // Data18
                textBox11.Text + ", " + // Data19
                textBox15.Text + ", " + // Data20
                textBox21.Text + ", " + // Data21
                textBox9.Text + ", " + // Data22
                textBox13.Text + ", " + // Data23
                "'" + textBox31.Text + "', " + // AiName
                "'" + textBox30.Text + "', " + // ScriptName
                textBox32.Text + // VerifiedBuild
                ");";
            connection.Open();
            MySqlCommand command = new MySqlCommand(insertQuery, connection);

            try
            {
                if (command.ExecuteNonQuery() == 1)
                {
                    timer3.Start();
                }
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            connection.Close();
        }

        private void button_maxPlus1fromDB_Click(object sender, EventArgs e)
        {
            MySqlConnection connection = new MySqlConnection(
                               "datasource=" + form_MM.GetHost() + ";" +
                               "port=" + form_MM.GetPort() + ";" +
                               "username=" + form_MM.GetUser() + ";" +
                               "password=" + form_MM.GetPass() + ";"
                );
            string insertQuery = "SELECT max(entry)+1 FROM " + form_MM.GetWorldDB() + ".gameobject_template;";
            //string insertQuery = textBox_SelectMaxPlus1.Text;
            connection.Open();
            MySqlCommand command = new MySqlCommand(insertQuery, connection);

            try
            {
                textBox1.Text = command.ExecuteScalar().ToString();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            connection.Close();
        }

        private void label80_MouseEnter(object sender, EventArgs e)
        {
            label80.BackColor = Color.Firebrick;
            label80.ForeColor = Color.White;
        }

        private void label80_MouseLeave(object sender, EventArgs e)
        {
            label80.BackColor = Color.FromArgb(58, 89, 114);
            label80.ForeColor = Color.Black;
        }

        private void label81_MouseEnter(object sender, EventArgs e)
        {
            label81.BackColor = Color.Firebrick;
            label81.ForeColor = Color.White;
        }

        private void label81_MouseLeave(object sender, EventArgs e)
        {
            label81.BackColor = Color.FromArgb(58, 89, 114);
            label81.ForeColor = Color.Black;
        }

        private void panel2_MouseMove(object sender, MouseEventArgs e)
        {
            if (_mouseDown)
            {
                this.Location = new Point(
                    (this.Location.X - lastLocation.X) + e.X, (this.Location.Y - lastLocation.Y) + e.Y);

                this.Update();
            }
        }

        private void panel2_MouseUp(object sender, MouseEventArgs e)
        {
            _mouseDown = false;
        }

        private void panel2_MouseDown(object sender, MouseEventArgs e)
        {
            _mouseDown = true;
            lastLocation = e.Location;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            Process[] mysql = Process.GetProcessesByName("mysqld");
            if (mysql.Length == 0)
            {
                label_mysql_status2.Text = "Connection Lost - MySQL is not running";
                label_mysql_status2.ForeColor = Color.Red;
            }
            else
            {
                label_mysql_status2.Text = "Connected!";
                label_mysql_status2.ForeColor = Color.LawnGreen;
            }
        }

        int i = 1;
        DateTime dt = new DateTime();
        private void timer2_Tick(object sender, EventArgs e)
        {
            label_stopwatch.Text = dt.AddSeconds(i).ToString("HH:mm:ss");
            i++;
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
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

        private void button8_Click(object sender, EventArgs e)
        {
            Close();
            BackToMainMenu backtomainmenu = new BackToMainMenu();
            backtomainmenu.Show();
        }

        private void label83_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                MessageBox.Show("Entry should not be empty", "Error");
                return;
            }
            if (textBox2.Text == "")
            {
                MessageBox.Show("Name should not be empty", "Error");
                return;
            }

            using (var sfd = new SaveFileDialog())
            {
                sfd.Filter = "sql files (*.sql)|*.sql";
                sfd.FilterIndex = 2;
                                            // [entry]       &       Name
                sfd.FileName = "GameObject[" + textBox1.Text + "]" + textBox2.Text;

                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    File.WriteAllText(sfd.FileName, textBox105.Text + " INTO " + mainmenu.textbox_mysql_worldDB.Text + ".gameobject_template " +
                "(entry, type, displayId, name, IconName, castBarCaption, unk1, " +
                "size, Data0, Data1, Data2, Data3, Data4, Data5, Data6, Data7, Data8, Data9, Data10, Data11, Data12, Data13, Data14, Data15, " +
                "Data16, Data17, Data18, Data19, Data20, Data21, Data22, Data23, AIName, ScriptName, VerifiedBuild) " +
                "VALUES " +
                "(" + textBox1.Text + ", " + // Entry
                textBox33.Text + ", " + // Type
                textBox3.Text + ", " + // displayId
                "'" + textBox2.Text + "', " + // name
                "'" + comboBox1.Text + "', " + // IconName
                "'" + textBox4.Text + "', '" + // castBarCaption
                textBox28.Text + "', " + // unk1
                textBox34.Text + ", " + // size
                textBox26.Text + ", " + // Data0
                textBox7.Text + ", " + // Data1
                textBox18.Text + ", " + // Data2
                textBox29.Text + ", " + // Data3
                textBox5.Text + ", " + // Data4
                textBox20.Text + ", " + // Data5
                textBox27.Text + ", " + // Data6
                textBox6.Text + ", " + // Data7
                textBox19.Text + ", " + // Data8
                textBox25.Text + ", " + // Data9
                textBox8.Text + ", " + // Data10
                textBox17.Text + ", " + // Data11
                textBox22.Text + ", " + // Data12
                textBox10.Text + ", " + // Data13
                textBox14.Text + ", " + // Data14
                textBox24.Text + ", " + // Data15
                textBox12.Text + ", " + // Data16
                textBox16.Text + ", " + // Data17
                textBox23.Text + ", " + // Data18
                textBox11.Text + ", " + // Data19
                textBox15.Text + ", " + // Data20
                textBox21.Text + ", " + // Data21
                textBox9.Text + ", " + // Data22
                textBox13.Text + ", " + // Data23
                "'" + textBox31.Text + "', " + // AiName
                "'" + textBox30.Text + "', " + // ScriptName
                textBox32.Text + // VerifiedBuild
                ");");

                    timer7.Start();
                }
            }
        }

        private void label86_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                MessageBox.Show("Entry should not be empty", "Error");
                return;
            }
            if (textBox2.Text == "")
            {
                MessageBox.Show("Name should not be empty", "Error");
                return;
            }
            Clipboard.SetText(textBox105.Text + " INTO " + mainmenu.textbox_mysql_worldDB.Text + ".gameobject_template " +
                "(entry, type, displayId, name, IconName, castBarCaption, unk1, " + "\n" +
                "size, Data0, Data1, Data2, Data3, Data4, Data5, Data6, Data7, Data8, Data9, Data10, Data11, Data12, Data13, Data14, Data15, " + "\n" +
                "Data16, Data17, Data18, Data19, Data20, Data21, Data22, Data23, AIName, ScriptName, VerifiedBuild) " + "\n" +
                "VALUES " + "\n" +
                "(" + textBox1.Text + ", " + // Entry
                textBox33.Text + ", " + // Type
                textBox3.Text + ", " + // displayId
                "'" + textBox2.Text + "', " + // name
                "'" + comboBox1.Text + "', " + // IconName
                "'" + textBox4.Text + "', '" + // castBarCaption
                textBox28.Text + "', " + // unk1
                textBox34.Text + ", " + // size
                textBox26.Text + ", " + // Data0
                textBox7.Text + ", " + // Data1
                textBox18.Text + ", " + // Data2
                textBox29.Text + ", " + // Data3
                textBox5.Text + ", " + // Data4
                textBox20.Text + ", " + // Data5
                textBox27.Text + ", " + // Data6
                textBox6.Text + ", " + // Data7
                textBox19.Text + ", " + // Data8
                textBox25.Text + ", " + // Data9
                textBox8.Text + ", " + // Data10
                textBox17.Text + ", " + // Data11
                textBox22.Text + ", " + // Data12
                textBox10.Text + ", " + // Data13
                textBox14.Text + ", " + // Data14
                textBox24.Text + ", " + // Data15
                textBox12.Text + ", " + // Data16
                textBox16.Text + ", " + // Data17
                textBox23.Text + ", " + // Data18
                textBox11.Text + ", " + // Data19
                textBox15.Text + ", " + // Data20
                textBox21.Text + ", " + // Data21
                textBox9.Text + ", " + // Data22
                textBox13.Text + ", " + // Data23
                "'" + textBox31.Text + "', " + // AiName
                "'" + textBox30.Text + "', " + // ScriptName
                textBox32.Text + // VerifiedBuild
                ");");

            //label87.Visible = true;
            timer5.Start();
        }

        private void timer3_Tick(object sender, EventArgs e)
        {
            label_query_executed_successfully2.Visible = true;
            timer3.Stop();

            timer4.Start();
        }

        private void timer4_Tick(object sender, EventArgs e)
        {
            label_query_executed_successfully2.Visible = false;
            timer4.Stop();
        }

        private void timer5_Tick(object sender, EventArgs e)
        {
            label_query_copied_to_clipboard.Visible = true;
            timer5.Stop();

            timer6.Start();

        }

        private void timer6_Tick(object sender, EventArgs e)
        {
            label_query_copied_to_clipboard.Visible = false;
            timer6.Stop();
        }

        private void timer7_Tick(object sender, EventArgs e)
        {
            label_saved_successfully.Visible = true;
            timer7.Stop();

            timer8.Start();
        }

        private void timer8_Tick(object sender, EventArgs e)
        {
            label_saved_successfully.Visible = false;
            timer8.Stop();
        }

        private void label81_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void label80_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("http://emucraft.com");
        }

        private void label35_MouseHover(object sender, EventArgs e)
        {
            label35.ForeColor = Color.RoyalBlue;
        }

        private void label35_MouseLeave(object sender, EventArgs e)
        {
            label35.ForeColor = Color.Blue;
        }

        private void textBox28_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) /*&& (e.KeyChar != '.')*/)
            {
                e.Handled = true;
            }

            //// only allow one decimal point
            //if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            //{
            //    e.Handled = true;
            //}
        }

        private void label78_Click(object sender, EventArgs e)
        {
            Close();
            BackToMainMenu backtomainmenu = new BackToMainMenu(form_MM);
            backtomainmenu.Show();
        }

        private void label78_MouseEnter(object sender, EventArgs e)
        {
            label78.BackColor = Color.Firebrick;
            label78.ForeColor = Color.White;
        }

        private void label78_MouseLeave(object sender, EventArgs e)
        {
            label78.BackColor = Color.FromArgb(58, 89, 114);
            label78.ForeColor = Color.Black;
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void label83_MouseEnter(object sender, EventArgs e)
        {
            panel5.BackColor = Color.Firebrick;
        }

        private void label83_MouseLeave(object sender, EventArgs e)
        {
            panel5.BackColor = Color.FromArgb(58, 89, 114);
        }
        //==========================================================
        private void label86_MouseEnter(object sender, EventArgs e)
        {
            panel7.BackColor = Color.Firebrick;
        }

        private void label86_MouseLeave(object sender, EventArgs e)
        {
            panel7.BackColor = Color.FromArgb(58, 89, 114);
        }

        private void panel5_MouseEnter(object sender, EventArgs e)
        {
            panel5.BackColor = Color.Firebrick;
        }

        private void panel5_MouseLeave(object sender, EventArgs e)
        {
            panel5.BackColor = Color.FromArgb(58, 89, 114);
        }

        private void panel7_MouseEnter(object sender, EventArgs e)
        {
            panel7.BackColor = Color.Firebrick;
        }

        private void panel7_MouseLeave(object sender, EventArgs e)
        {
            panel7.BackColor = Color.FromArgb(58, 89, 114);
        }

        private void comboBox11_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox11.SelectedIndex == 0) textBox105.Text = "INSERT";
            else if (comboBox11.SelectedIndex == 1) textBox105.Text = "REPLACE";
        }
    }
}
