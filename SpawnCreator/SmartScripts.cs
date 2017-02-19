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
using System.IO;
using System.Diagnostics;

namespace SpawnCreator
{
    public partial class SmartScripts : Form
    {
        public SmartScripts()
        {
            InitializeComponent();
        }

        private bool _mouseDown;
        private Point lastLocation;

        public static string stringSQLShare;
        public static string stringEntryShare;

        Form_MainMenu mainmenu = new Form_MainMenu();

        private void _GenerateSqlCode_(object sender, EventArgs e)
        {
            uint event_phase_mask_st = 0;
            uint event_flags_st = 0;

            string[] checkedIndicies1 = Properties.Settings.Default.EventPhaseMask.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
            for (int i1 = 0; i1 < checkedIndicies1.Length; i1++)
            {
                int idx;
                if ((int.TryParse(checkedIndicies1[i1], out idx)))
                {
                    switch (idx)
                    {
                        case 0: // SMART_EVENT_PHASE_ALWAYS_BIT
                            event_phase_mask_st += 0x000;
                            break;
                        case 1: // SMART_EVENT_PHASE_1
                            event_phase_mask_st += 0x001;
                            break;
                        case 2: // SMART_EVENT_PHASE_2
                            event_phase_mask_st += 0x002;
                            break;
                        case 3: // SMART_EVENT_PHASE_3
                            event_phase_mask_st += 0x004;
                            break;
                        case 4: // SMART_EVENT_PHASE_4
                            event_phase_mask_st += 0x008;
                            break;
                        case 5: // SMART_EVENT_PHASE_5
                            event_phase_mask_st += 0x010;
                            break;
                        case 6: // SMART_EVENT_PHASE_6
                            event_phase_mask_st += 0x020;
                            break;
                        case 7: // SMART_EVENT_PHASE_7
                            event_phase_mask_st += 0x040;
                            break;
                        case 8: // SMART_EVENT_PHASE_8
                            event_phase_mask_st += 0x080;
                            break;
                        case 9: // SMART_EVENT_PHASE_9
                            event_phase_mask_st += 0x100;
                            break;
                    }
                }
            }

            string[] checkedIndicies2 = Properties.Settings.Default.EventFlags.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
            for (int i1 = 0; i1 < checkedIndicies2.Length; i1++)
            {
                int idx;
                if ((int.TryParse(checkedIndicies2[i1], out idx)))
                {
                    switch (idx)
                    {
                        case 0: // SMART_EVENT_FLAG_NOT_REPEATABLE
                            event_flags_st += 0x01;
                            break;
                        case 1: // SMART_EVENT_FLAG_DIFFICULTY_0
                            event_flags_st += 0x02;
                            break;
                        case 2: // SMART_EVENT_FLAG_DIFFICULTY_1
                            event_flags_st += 0x04;
                            break;
                        case 3: // SMART_EVENT_FLAG_DIFFICULTY_2
                            event_flags_st += 0x08;
                            break;
                        case 4: // SMART_EVENT_FLAG_DIFFICULTY_3
                            event_flags_st += 0x10;
                            break;
                        case 5: // SMART_EVENT_FLAG_DEBUG_ONLY
                            event_flags_st += 0x80;
                            break;
                        case 6: // SMART_EVENT_FLAG_DONT_RESET
                            event_flags_st += 0x100;
                            break;
                        case 7: // SMART_EVENT_FLAG_WHILE_CHARMED
                            event_flags_st += 0x200;
                            break;
                    }
                }
            }
            
                            // Prepare SQL
                            // select insertion columns
                            string BuildSQLFile;
            BuildSQLFile = "INSERT INTO " + mainmenu.textbox_mysql_worldDB.Text + ".smart_scripts";
            BuildSQLFile += "(entryorguid, source_type, id, link, event_type, event_phase_mask, event_chance, event_flags, event_param1, event_param2, event_param3, ";
            BuildSQLFile += "event_param4, action_type, action_param1, action_param2, action_param3, action_param4, action_param5, action_param6, target_type, target_param1, target_param2, target_param3, target_x, target_y, target_z, target_o, comment) ";

            // values now
            BuildSQLFile += "VALUES \n";
            BuildSQLFile += "(";
            BuildSQLFile += textBox1.Text + ", "; // entryorguid
            BuildSQLFile += textBox2.Text + ", "; // source_type
            BuildSQLFile += numericUpDown1.Text + ", "; // id
            BuildSQLFile += textBox4.Text + ", "; // link
            BuildSQLFile += textBox5.Text + ", "; // event_type
            BuildSQLFile += event_phase_mask_st + ", "; // event_phase_mask
            BuildSQLFile += numericUpDown2.Text + ", "; // event_chance
            BuildSQLFile += event_flags_st + ", "; // event_flags
            BuildSQLFile += textBox7.Text + ", "; // event_param1
            BuildSQLFile += textBox8.Text + ", "; // event_param2
            BuildSQLFile += textBox11.Text + ", "; // event_param3
            BuildSQLFile += textBox15.Text + ", "; // event_param4
            BuildSQLFile += textBox14.Text + ", "; // action_type
            BuildSQLFile += textBox12.Text + ", "; // action_param1
            BuildSQLFile += textBox13.Text + ", "; // action_param2
            BuildSQLFile += textBox16.Text + ", "; // action_param3
            BuildSQLFile += textBox20.Text + ", "; // action_param4
            BuildSQLFile += textBox19.Text + ", "; // action_param5
            BuildSQLFile += textBox17.Text + ", "; // action_param6
            BuildSQLFile += textBox18.Text + ", "; // target_type
            BuildSQLFile += textBox25.Text + ", "; // target_param1
            BuildSQLFile += textBox26.Text + ", "; // target_param2
            BuildSQLFile += textBox21.Text + ", "; // target_param3
            BuildSQLFile += textBox24.Text + ", "; // target_x
            BuildSQLFile += textBox23.Text + ", "; // target_y
            BuildSQLFile += textBox22.Text + ", "; // target_z
            BuildSQLFile += textBox28.Text + ", '"; // target_o
            BuildSQLFile += textBox27.Text; // comment
            BuildSQLFile += "');";

            stringSQLShare = BuildSQLFile;
            stringEntryShare = textBox1.Text;

            
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.Text == "SMART_SCRIPT_TYPE_CREATURE") textBox2.Text = "0";
            else if (comboBox1.Text == "SMART_SCRIPT_TYPE_GAMEOBJECT") textBox2.Text = "1";
            else if (comboBox1.Text == "SMART_SCRIPT_TYPE_AREATRIGGER") textBox2.Text = "2";
            else if (comboBox1.Text == "SMART_SCRIPT_TYPE_TIMED_ACTIONLIST") textBox2.Text = "9";
        }

        private void comboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox4.Text == "SMART_EVENT_UPDATE_IC") textBox5.Text = "0";
            else if (comboBox4.Text == "SMART_EVENT_UPDATE_OOC") textBox5.Text = "1";
            else if (comboBox4.Text == "SMART_EVENT_HEALT_PCT") textBox5.Text = "2";
            else if (comboBox4.Text == "SMART_EVENT_MANA_PCT") textBox5.Text = "3";
            else if (comboBox4.Text == "SMART_EVENT_AGGRO") textBox5.Text = "4";
            else if (comboBox4.Text == "SMART_EVENT_KILL") textBox5.Text = "5";
            else if (comboBox4.Text == "SMART_EVENT_DEATH") textBox5.Text = "6";
            else if (comboBox4.Text == "SMART_EVENT_EVADE") textBox5.Text = "7";
            else if (comboBox4.Text == "SMART_EVENT_SPELLHIT") textBox5.Text = "8";
            else if (comboBox4.Text == "SMART_EVENT_RANGE") textBox5.Text = "9";
            else if (comboBox4.Text == "SMART_EVENT_OOC_LOS") textBox5.Text = "10";
            else if (comboBox4.Text == "SMART_EVENT_RESPAWN") textBox5.Text = "11";
            else if (comboBox4.Text == "SMART_EVENT_TARGET_HEALTH_PCT") textBox5.Text = "12";
            else if (comboBox4.Text == "SMART_EVENT_VICTIM_CASTING") textBox5.Text = "13";
            else if (comboBox4.Text == "SMART_EVENT_FRIENDLY_HEALTH") textBox5.Text = "14";
            else if (comboBox4.Text == "SMART_EVENT_FRIENDLY_IS_CC") textBox5.Text = "15";
            else if (comboBox4.Text == "SMART_EVENT_FRIENDLY_MISSING_BUFF") textBox5.Text = "16";
            else if (comboBox4.Text == "SMART_EVENT_SUMMONED_UNIT") textBox5.Text = "17";
            else if (comboBox4.Text == "SMART_EVENT_TARGET_MANA_PCT") textBox5.Text = "18";
            else if (comboBox4.Text == "SMART_EVENT_ACCEPTED_QUEST") textBox5.Text = "19";
            else if (comboBox4.Text == "SMART_EVENT_REWARD_QUEST") textBox5.Text = "20";
            else if (comboBox4.Text == "SMART_EVENT_REACHED_HOME") textBox5.Text = "21";
            else if (comboBox4.Text == "SMART_EVENT_RECEIVE_EMOTE") textBox5.Text = "22";
            else if (comboBox4.Text == "SMART_EVENT_HAS_AURA") textBox5.Text = "23";
            else if (comboBox4.Text == "SMART_EVENT_TARGET_BUFFED") textBox5.Text = "24";
            else if (comboBox4.Text == "SMART_EVENT_RESET") textBox5.Text = "25";
            else if (comboBox4.Text == "SMART_EVENT_IC_LOS") textBox5.Text = "26";
            else if (comboBox4.Text == "SMART_EVENT_PASSENGER_BOARDED") textBox5.Text = "27";
            else if (comboBox4.Text == "SMART_EVENT_PASSENGER_REMOVED") textBox5.Text = "28";
            else if (comboBox4.Text == "SMART_EVENT_CHARMED") textBox5.Text = "29";
            else if (comboBox4.Text == "SMART_EVENT_CHARMED_TARGET") textBox5.Text = "30";
            else if (comboBox4.Text == "SMART_EVENT_SPELLHIT_TARGET") textBox5.Text = "31";
            else if (comboBox4.Text == "SMART_EVENT_DAMAGED") textBox5.Text = "32";
            else if (comboBox4.Text == "SMART_EVENT_DAMAGED_TARGET") textBox5.Text = "33";
            else if (comboBox4.Text == "SMART_EVENT_MOVEMENTINFORM") textBox5.Text = "34";
            else if (comboBox4.Text == "SMART_EVENT_SUMMON_DESPAWNED") textBox5.Text = "35";
            else if (comboBox4.Text == "SMART_EVENT_CORPSE_REMOVED") textBox5.Text = "36";
            else if (comboBox4.Text == "SMART_EVENT_AI_INIT") textBox5.Text = "37";
            else if (comboBox4.Text == "SMART_EVENT_DATA_SET") textBox5.Text = "38";
            else if (comboBox4.Text == "SMART_EVENT_WAYPOINT_START") textBox5.Text = "39";
            else if (comboBox4.Text == "SMART_EVENT_WAYPOINT_REACHED") textBox5.Text = "40";
            else if (comboBox4.Text == "SMART_EVENT_AREATRIGGER_ONTRIGGER") textBox5.Text = "46";
            else if (comboBox4.Text == "SMART_EVENT_TEXT_OVER") textBox5.Text = "52";
            else if (comboBox4.Text == "SMART_EVENT_RECEIVE_HEAL") textBox5.Text = "53";
            else if (comboBox4.Text == "SMART_EVENT_JUST_SUMMONED") textBox5.Text = "54";
            else if (comboBox4.Text == "SMART_EVENT_WAYPOINT_PAUSED") textBox5.Text = "55";
            else if (comboBox4.Text == "SMART_EVENT_WAYPOINT_RESUMED") textBox5.Text = "56";
            else if (comboBox4.Text == "SMART_EVENT_WAYPOINT_STOPPED") textBox5.Text = "57";
            else if (comboBox4.Text == "SMART_EVENT_WAYPOINT_ENDED") textBox5.Text = "58";
            else if (comboBox4.Text == "SMART_EVENT_TIMED_EVENT_TRIGGERED") textBox5.Text = "59";
            else if (comboBox4.Text == "SMART_EVENT_UPDATE") textBox5.Text = "60";
            else if (comboBox4.Text == "SMART_EVENT_LINK") textBox5.Text = "61";
            else if (comboBox4.Text == "SMART_EVENT_GOSSIP_SELECT") textBox5.Text = "62";
            else if (comboBox4.Text == "SMART_EVENT_JUST_CREATED") textBox5.Text = "63";
            else if (comboBox4.Text == "SMART_EVENT_GOSSIP_HELLO") textBox5.Text = "64";
            else if (comboBox4.Text == "SMART_EVENT_FOLLOW_COMPLETED") textBox5.Text = "65";
            else if (comboBox4.Text == "SMART_EVENT_IS_BEHIND_TARGET") textBox5.Text = "67";
            else if (comboBox4.Text == "SMART_EVENT_GAME_EVENT_START") textBox5.Text = "68";
            else if (comboBox4.Text == "SMART_EVENT_GAME_EVENT_END") textBox5.Text = "69";
            else if (comboBox4.Text == "SMART_EVENT_GO_STATE_CHANGED") textBox5.Text = "70";
            else if (comboBox4.Text == "SMART_EVENT_GO_EVENT_INFORM") textBox5.Text = "71";
            else if (comboBox4.Text == "SMART_EVENT_ACTION_DONE") textBox5.Text = "72";
            else if (comboBox4.Text == "SMART_EVENT_ON_SPELLCLICK") textBox5.Text = "73";
            else if (comboBox4.Text == "SMART_EVENT_FRIENDLY_HEALTH_PCT") textBox5.Text = "74";
            else if (comboBox4.Text == "SMART_EVENT_DISTANCE_CREATURE") textBox5.Text = "75";
            else if (comboBox4.Text == "SMART_EVENT_DISTANCE_GAMEOBJECT") textBox5.Text = "76";
            else if (comboBox4.Text == "SMART_EVENT_COUNTER_SET") textBox5.Text = "77";
        }

        private void comboBox5_SelectedIndexChanged(object sender, EventArgs e)
        {
            textBox14.Text = Convert.ToString(comboBox5.SelectedIndex);
        }

        private void comboBox6_SelectedIndexChanged(object sender, EventArgs e)
        {
            textBox18.Text = Convert.ToString(comboBox6.SelectedIndex);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            event_phase_mask _event_phase_mask = new event_phase_mask();
            _event_phase_mask.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            event_flags _event_flags = new event_flags();
            _event_flags.ShowDialog();
        }

        private void SmartScripts_Load(object sender, EventArgs e)
        {
            comboBox1.SelectedIndex = 0; 
            comboBox4.SelectedIndex = 0;
            comboBox5.SelectedIndex = 0;
            comboBox6.SelectedIndex = 0;

            timer1.Start(); //Check if mysql is still running
            timer2.Start(); // Stopwatch
        }

        private void label2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void panel2_MouseDown(object sender, MouseEventArgs e)
        {
            _mouseDown = true;
            lastLocation = e.Location;
        }

        private void panel2_MouseMove(object sender, MouseEventArgs e)
        {
            if (_mouseDown)
            {
                Location = new Point(
                    (Location.X - lastLocation.X) + e.X, (Location.Y - lastLocation.Y) + e.Y);

                Update();
            }
        }

        private void panel2_MouseUp(object sender, MouseEventArgs e)
        {
            _mouseDown = false;
        }

        private void label1_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private void label78_Click(object sender, EventArgs e)
        {
            Close();
            BackToMainMenu backtomainmenu = new BackToMainMenu();
            backtomainmenu.Show();
        }

        private void label86_Click(object sender, EventArgs e)
        {
            _GenerateSqlCode_(sender, e);

            if (textBox1.Text == "")
            {
                MessageBox.Show("EntryOrGuid should not be empty", "Error");
                return;
            }
            if (textBox1.Text == "0")
            {
                MessageBox.Show("EntryOrGuid should not be zero", "Error");
                return;
            }

            Clipboard.SetText(stringSQLShare);
            label87.Visible = true;
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("https://trinitycore.atlassian.net/wiki/display/tc/smart_scripts");
        }

        // All textboxes
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            // Succesfully Copied to clipboard
            label87.Visible = false;

            label_query_executed_successfully2.Visible = false;

            //File has been successfully saved !
            label88.Visible = false;
        }

        // All numericUpDown boxes
        private void numericUpDown2_ValueChanged(object sender, EventArgs e)
        {
            // Succesfully Copied to clipboard
            label87.Visible = false;

            label_query_executed_successfully2.Visible = false;

            //File has been successfully saved !
            label88.Visible = false;
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
        //=======================================================
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
        //=======================================================
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

        int i = 1;
        DateTime dt = new DateTime();
        private void timer2_Tick(object sender, EventArgs e)
        {
            label_stopwatch.Text = dt.AddSeconds(i).ToString("HH:mm:ss");
            i++;
        }

        // Execute query - Button
        private void button10_Click(object sender, EventArgs e)
        {
            _GenerateSqlCode_(sender, e);

            if (textBox1.Text == "")
            {
                MessageBox.Show("EntryOrGuid should not be empty", "Error");
                return;
            }
            if (textBox1.Text == "0")
            {
                MessageBox.Show("EntryOrGuid should not be zero", "Error");
                return;
            }

            MySqlConnection connection = new MySqlConnection("datasource=" + mainmenu.textbox_mysql_hostname.Text + ";port=" + mainmenu.textbox_mysql_port.Text + ";username=" + mainmenu.textbox_mysql_username.Text + ";password=" + mainmenu.textbox_mysql_pass.Text);
            string insertQuery = stringSQLShare;
            connection.Open();
            MySqlCommand command = new MySqlCommand(insertQuery, connection);

            try
            {
                if (command.ExecuteNonQuery() == 1)
                {
                    //timer5.Start();
                    label_query_executed_successfully2.Visible = true;
                }
                else
                {
                    MessageBox.Show("Error");
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            connection.Close();
        }

        private void label83_Click(object sender, EventArgs e)
        {
            _GenerateSqlCode_(sender, e);

            if (textBox1.Text == "")
            {
                MessageBox.Show("EntryOrGuid should not be empty", "Error");
                return;
            }
            if (textBox1.Text == "0")
            {
                MessageBox.Show("EntryOrGuid should not be zero", "Error");
                return;
            }

            using (var sfd = new SaveFileDialog())
            {
                sfd.Filter = "sql files (*.sql)|*.sql";
                sfd.FilterIndex = 2;
                sfd.FileName = "SmartScript_" + stringEntryShare;

                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    File.WriteAllText(sfd.FileName, stringSQLShare);
                    label88.Visible = true;
                }
            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("http://emucraft.com");
        }
    }
}
