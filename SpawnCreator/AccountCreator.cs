using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.Threading;
using System.IO;
using System.Diagnostics;

namespace SpawnCreator
{
    public partial class AccountCreator : Form
    {
        public AccountCreator()
        {
            InitializeComponent();
        }

        private bool _mouseDown;
        private Point lastLocation;

        private void panel2_MouseDown(object sender, MouseEventArgs e)
        {
            _mouseDown = true;
            lastLocation = e.Location;
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

        private void label2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void panel2_MouseUp(object sender, MouseEventArgs e)
        {
            _mouseDown = false;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            Form_MainMenu mainmenu = new Form_MainMenu();

            try
            {
                string myConnection = "datasource=" + mainmenu.textbox_mysql_hostname.Text + ";port=" + mainmenu.textbox_mysql_port.Text + ";username=" + mainmenu.textbox_mysql_username.Text + ";password=" + mainmenu.textbox_mysql_pass.Text;
                MySqlConnection myConn = new MySqlConnection(myConnection);
                MySqlDataAdapter myDataAdapter = new MySqlDataAdapter();
                //myDataAdapter.SelectCommand = new MySqlCommand("select * from auth.account;");
                MySqlCommandBuilder cb = new MySqlCommandBuilder(myDataAdapter);
                myConn.Open();
                DataSet ds = new DataSet();

                label_mysql_status2.Text = "Connected!";
                label_mysql_status2.ForeColor = Color.LawnGreen;

                myConn.Close();
            }
            catch (Exception /*ex*/)
            {
                //MessageBox.Show(ex.Message);
                label_mysql_status2.Text = "Connection Lost - MySQL is not running";
                label_mysql_status2.ForeColor = Color.Red;
            }
        }

        private void AccountCreator_Load(object sender, EventArgs e)
        {
            timer1.Start();
            comboBox_Account_Access_level.SelectedIndex = 3; // 3 (Admin)
            comboBox_Expansion.SelectedIndex = 2; // 2 (WOTLK)
            timer6.Start();
        }
        Form_MainMenu mainmenu = new Form_MainMenu();
        private void label86_Click(object sender, EventArgs e)
        {
            if (textBox_username.Text == "")
            {
                MessageBox.Show("Username should not be empty", "Error");
                return;
            }
            if (textBox_pass.Text == "")
            {
                MessageBox.Show("Password should not be empty", "Error");
                return;
            }
            Clipboard.SetText("INSERT INTO " + mainmenu.textBox_mysql_authDB.Text + ".account(username, sha_pass_hash, expansion, email) " + "\n" +
                "VALUES(UPPER('" + textBox_username.Text + "'), (SHA1(CONCAT(UPPER('" + textBox_username.Text + "'), ':', UPPER('" + textBox_pass.Text + "')))), " + textBox_Expansion.Text + ", '" + textBox_email.Text + "'); " + "\n" +
                "INSERT INTO " + mainmenu.textBox_mysql_authDB.Text + ".account_access(id, gmlevel, RealmID) " + "\n" +
                "VALUES((SELECT id FROM " + mainmenu.textBox_mysql_authDB.Text + ".account WHERE username = '" + textBox_username.Text + "'), " + textBox_Account_Access_Level.Text + ", " + textBox_realmID.Text + ");");
            //label87.Visible = true;
            timer4.Start();
        }

        private void label86_MouseEnter(object sender, EventArgs e)
        {
            panel7.BackColor = Color.Firebrick;
        }

        private void label86_MouseLeave(object sender, EventArgs e)
        {
            panel7.BackColor = Color.FromArgb(58, 89, 114);
        }

        private void label83_MouseEnter(object sender, EventArgs e)
        {
            panel5.BackColor = Color.Firebrick;
        }

        private void label83_MouseLeave(object sender, EventArgs e)
        {
            panel5.BackColor = Color.FromArgb(58, 89, 114);
        }

        private void comboBox_Account_Access_level_SelectedIndexChanged(object sender, EventArgs e)
        {
            textBox_Account_Access_Level.Text = comboBox_Account_Access_level.Text;

            if (comboBox_Account_Access_level.Text      == "0 (Player)") textBox_Account_Access_Level.Text    = "0";
            else if (comboBox_Account_Access_level.Text == "1 (GM)") textBox_Account_Access_Level.Text        = "1";
            else if (comboBox_Account_Access_level.Text == "2 (Moderator)") textBox_Account_Access_Level.Text = "2";
            else if (comboBox_Account_Access_level.Text == "3 (Admin)") textBox_Account_Access_Level.Text     = "3";
            else if (comboBox_Account_Access_level.Text == "4 (Console)") textBox_Account_Access_Level.Text   = "4";
        }

        private void button_Execute_Query_Click(object sender, EventArgs e)
        {
            Form_MainMenu mainmenu = new Form_MainMenu();

            if (textBox_username.Text == "")
            {
                MessageBox.Show("Username should not be empty", "Error");
                return;
            }
            if (textBox_pass.Text == "")
            {
                MessageBox.Show("Password should not be empty", "Error");
                return;
            }

            MySqlConnection connection = new MySqlConnection("datasource=" + mainmenu.textbox_mysql_hostname.Text + ";port=" + mainmenu.textbox_mysql_port.Text + ";username=" + mainmenu.textbox_mysql_username.Text + ";password=" + mainmenu.textbox_mysql_pass.Text);
            string insertQuery = "INSERT INTO " + mainmenu.textBox_mysql_authDB.Text + ".account(username, sha_pass_hash, expansion, email) " + "\n" +
                "VALUES(UPPER('" + textBox_username.Text + "'), (SHA1(CONCAT(UPPER('" + textBox_username.Text + "'), ':', UPPER('" + textBox_pass.Text + "')))), " + textBox_Expansion.Text + ", '" + textBox_email.Text + "'); " + "\n" +
                "INSERT INTO " + mainmenu.textBox_mysql_authDB.Text + ".account_access(id, gmlevel, RealmID) VALUES((SELECT id FROM " + mainmenu.textBox_mysql_authDB.Text + ".account WHERE username = '" + textBox_username.Text + "'), " + textBox_Account_Access_Level.Text + ", " + textBox_realmID.Text + ");";
            connection.Open();
            MySqlCommand command = new MySqlCommand(insertQuery, connection);

            // Test
            try
            {
                if (command.ExecuteNonQuery() == 1)
                {
                    label_Executed_Successfully.Visible = true;
                }
                else
                {
                    label_Executed_Successfully.Visible = true;
                    //MessageBox.Show("Data Not Inserted");
                    //label2.ForeColor = Color.Red;
                    //label2.Text = "Eroare!";
                    //MessageBox.Show("Unable to connect to any of the specified MySQL hosts.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            connection.Close();
        }

        private void textBox_username_TextChanged(object sender, EventArgs e)
        {
            label_Executed_Successfully.Visible = false;
        }

        private void textBox_pass_TextChanged(object sender, EventArgs e)
        {
            label_Executed_Successfully.Visible = false;
        }

        private void textBox_Account_Access_Level_TextChanged(object sender, EventArgs e)
        {
            label_Executed_Successfully.Visible = false;
        }

        private void label83_Click(object sender, EventArgs e)
        {
            if (textBox_username.Text == "")
            {
                MessageBox.Show("Username should not be empty", "Error");
                return;
            }
            if (textBox_pass.Text == "")
            {
                MessageBox.Show("Password should not be empty", "Error");
                return;
            }
            using (var sfd = new SaveFileDialog())
            {
                sfd.Filter = "sql files (*.sql)|*.sql";
                sfd.FilterIndex = 2;
                sfd.FileName = "Account_" + textBox_username.Text;

                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    File.WriteAllText(sfd.FileName, "INSERT INTO " + mainmenu.textBox_mysql_authDB.Text + ".account(username, sha_pass_hash, expansion, email) " + "\n" +
                "VALUES(UPPER('" + textBox_username.Text + "'), (SHA1(CONCAT(UPPER('" + textBox_username.Text + "'), ':', UPPER('" + textBox_pass.Text + "')))), " + textBox_Expansion.Text + ", '" + textBox_email.Text + "'); " + "\n" +
                "INSERT INTO " + mainmenu.textBox_mysql_authDB.Text + ".account_access(id, gmlevel, RealmID) " + "\n" +
                "VALUES((SELECT id FROM " + mainmenu.textBox_mysql_authDB.Text + ".account WHERE username = '" + textBox_username.Text + "'), " + textBox_Account_Access_Level.Text + ", " + textBox_realmID.Text + ");");
                    //label88.Visible = true;
                    //label87.Visible = false;
                    timer2.Start();
                }
            }
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            label88.Visible = true;
            timer2.Stop();

            timer3.Start();
        }

        private void timer3_Tick(object sender, EventArgs e)
        {
            label88.Visible = false;
            timer3.Stop();
        }

        private void timer4_Tick(object sender, EventArgs e)
        {
            label87.Visible = true;
            timer4.Stop();

            timer5.Start();
        }

        private void timer5_Tick(object sender, EventArgs e)
        {
            label87.Visible = false;
            timer5.Stop();
        }
        int i = 1;
        DateTime dt = new DateTime();
        private void timer6_Tick(object sender, EventArgs e)
        {
            label_stopwatch.Text = dt.AddSeconds(i).ToString("HH:mm:ss");
            i++;
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("http://emucraft.com");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
            BackToMainMenu backtomainmenu = new BackToMainMenu();
            backtomainmenu.Show();

        }

        private void label2_MouseEnter(object sender, EventArgs e)
        {
            label2.BackColor = Color.Firebrick;
            label2.ForeColor = Color.White;
        }

        private void label2_MouseLeave(object sender, EventArgs e)
        {
            label2.BackColor = Color.FromArgb(58, 89, 114);
            label2.ForeColor = Color.Black;
        }

        private void label1_MouseEnter(object sender, EventArgs e)
        {
            label1.BackColor = Color.Firebrick;
            label1.ForeColor = Color.White;
        }

        private void label1_MouseLeave(object sender, EventArgs e)
        {
            label1.BackColor = Color.FromArgb(58, 89, 114);
            label1.ForeColor = Color.Black;
        }

        private void comboBox_Expansion_SelectedIndexChanged(object sender, EventArgs e)
        {
            textBox_Expansion.Text = comboBox_Expansion.Text;

            if (comboBox_Expansion.Text      == "0 (Vanilla)") textBox_Expansion.Text   = "0";
            else if (comboBox_Expansion.Text == "1 (TBC)") textBox_Expansion.Text       = "1";
            else if (comboBox_Expansion.Text == "2 (WOTLK)") textBox_Expansion.Text     = "2";
            else if (comboBox_Expansion.Text == "3 (Cataclysm)") textBox_Expansion.Text = "3";
            else if (comboBox_Expansion.Text == "4 (MoP)") textBox_Expansion.Text       = "4";
            else if (comboBox_Expansion.Text == "5 (WoD)") textBox_Expansion.Text       = "5";
        }

        private void textBox_realmID_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox_realmID_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '-'))
            {
                e.Handled = true;
            }

            // only allow one minus
            if ((e.KeyChar == '-') && ((sender as TextBox).Text.IndexOf('-') > -1))
            {
                e.Handled = true;
            }
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

        private void label78_Click(object sender, EventArgs e)
        {
            Close();
            BackToMainMenu backtomainmenu = new BackToMainMenu();
            backtomainmenu.Show();
        }
    }
}
