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
using System.Diagnostics;
using System.IO;

namespace SpawnCreator
{
    public partial class Disable_Form : Form
    {
        public Disable_Form()
        {
            InitializeComponent();
        }
        Form_MainMenu mainmenu = new Form_MainMenu();
        public static string stringSQLShare;
        public static string stringEntryShare;

        private bool _mouseDown;
        private Point lastLocation;

        private void Disable_Form_Load(object sender, EventArgs e)
        {
            comboBox_SourceType.SelectedIndex = 0; //Show default
            timer1.Start(); //Check mysql connection
            timer2.Start(); //stopwatch
        }

        //private void GenerateSqlCode(object sender, EventArgs e)
        //{
        //    button_Execute_Query_Click(sender, e);
        //}

        private void label2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void label78_Click(object sender, EventArgs e)
        {
            Close();
            BackToMainMenu backtomainmenu = new BackToMainMenu();
            backtomainmenu.Show();
        }

        private void comboBox_SourceType_SelectedIndexChanged(object sender, EventArgs e)
        {
            label87.Visible = false; //Query has been copied to clipboard!
            label88.Visible = false; //File has been successfully saved!
            label_Executed_Successfully.Visible = false;
            textBox_SourceType.Text = comboBox_SourceType.Text;

            if (comboBox_SourceType.Text == "DISABLE_TYPE_SPELL") 
            {
                textBox_SourceType.Text = "0";
                button_flags_dis_spell.Visible = true;
                button_flags_dis_map.Visible = false;
                button_flags_dis_vmap.Visible = false;     
                textBox1.Text = "params_0: MapId, 0 for all maps." + Environment.NewLine +
                                "If multiple Maps, separate ids with a comma" + Environment.NewLine +
                                "Example: 30,489 (Alterac Valley,Warsong Gulch)" + Environment.NewLine +
                                "params_1: AreaId, 0 for all areas." + Environment.NewLine +
                                "If multiple Areas, separate ids with a comma";
                linkLabel2.Visible = true;
            }
            else if (comboBox_SourceType.Text == "DISABLE_TYPE_QUEST") 
            {
                textBox_SourceType.Text = "1";
                button_flags_dis_spell.Visible = false;
                button_flags_dis_map.Visible = false;
                button_flags_dis_vmap.Visible = false;
                textBox1.Clear();
                linkLabel2.Visible = false;
            }
            else if (comboBox_SourceType.Text == "DISABLE_TYPE_MAP") 
            {
                textBox_SourceType.Text = "2";
                button_flags_dis_spell.Visible = false;
                button_flags_dis_map.Visible = true;
                button_flags_dis_vmap.Visible = false;
                textBox1.Clear();
                linkLabel2.Visible = false;
            }
            else if (comboBox_SourceType.Text == "DISABLE_TYPE_BATTLEGROUND") 
            {
                textBox_SourceType.Text = "3";
                button_flags_dis_spell.Visible = false;
                button_flags_dis_map.Visible = false;
                button_flags_dis_vmap.Visible = false;
                textBox1.Clear();
                linkLabel2.Visible = false;
            }
            else if (comboBox_SourceType.Text == "DISABLE_TYPE_ACHIEVEMENT_CRITERIA") 
            {
                textBox_SourceType.Text = "4";
                button_flags_dis_spell.Visible = false;
                button_flags_dis_map.Visible = false;
                button_flags_dis_vmap.Visible = false;
                textBox1.Clear();
                linkLabel2.Visible = false;
            }
            else if (comboBox_SourceType.Text == "DISABLE_TYPE_OUTDOORPVP") 
            {
                textBox_SourceType.Text = "5";
                button_flags_dis_spell.Visible = false;
                button_flags_dis_map.Visible = false;
                button_flags_dis_vmap.Visible = false;
                textBox1.Clear();
                linkLabel2.Visible = false;
            }
            else if (comboBox_SourceType.Text == "DISABLE_TYPE_VMAP") 
            {
                textBox_SourceType.Text = "6";
                button_flags_dis_spell.Visible = false;
                button_flags_dis_map.Visible = false;
                button_flags_dis_vmap.Visible = true;
                textBox1.Clear();
                linkLabel2.Visible = false;
            }
            else if (comboBox_SourceType.Text == "DISABLE_TYPE_MMAP") 
            {
                textBox_SourceType.Text = "7";
                button_flags_dis_spell.Visible = false;
                button_flags_dis_map.Visible = false;
                button_flags_dis_vmap.Visible = false;
                textBox1.Clear();
                linkLabel2.Visible = false;
            }
            else if (comboBox_SourceType.Text == "DISABLE_TYPE_LFG_MAP") 
            {
                textBox_SourceType.Text = "8";
                button_flags_dis_spell.Visible = false;
                button_flags_dis_map.Visible = false;
                button_flags_dis_vmap.Visible = false;
                textBox1.Clear();
                linkLabel2.Visible = false;
            }
        }

        private void button_flags_dis_spell_Click(object sender, EventArgs e)
        {
            Flags_Disable_Spell flags_dis_spell = new Flags_Disable_Spell();
            flags_dis_spell.ShowDialog();
        }

        private void button_flags_dis_map_Click(object sender, EventArgs e)
        {
            Flags_Disable_Map flags_dis_map = new Flags_Disable_Map();
            flags_dis_map.ShowDialog();
        }

        private void button_flags_dis_vmap_Click(object sender, EventArgs e)
        {
            Flags_Disable_Vmap flags_dis_vmap = new Flags_Disable_Vmap();
            flags_dis_vmap.ShowDialog();
        }

        private void button_Execute_Query_Click(object sender, EventArgs e)
        {
            uint flags_dis_spell_st = 0;
            uint flags_dis_map_st = 0;
            uint flags_dis_vmap_st = 0;

            string[] checkedIndicies1 = Properties.Settings.Default.FlagsDisableSpell.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
            for (int i1 = 0; i1 < checkedIndicies1.Length; i1++)
            {
                int idx;
                if ((int.TryParse(checkedIndicies1[i1], out idx)))
                {
                    switch (idx)
                    {
                        case 0: // Spell enabled
                            flags_dis_spell_st += 0;
                            break;
                        case 1: // Spell disabled for players
                            flags_dis_spell_st += 1;
                            break;
                        case 2: // Spell disabled for creatures
                            flags_dis_spell_st += 2;
                            break;
                        case 3: // Spell disabled for pets
                            flags_dis_spell_st += 4;
                            break;
                        case 4: // Spell completely disabled (used for no logner existing spells in DBCs)
                            flags_dis_spell_st += 8;
                            break;
                        case 5: // Spell disabled for MapId
                            flags_dis_spell_st += 16;
                            break;
                        case 6: // Spell disabled for AreaId
                            flags_dis_spell_st += 32;
                            break;
                        case 7: // Line of Sight (LOS) is disabled for this spell (replaces "vmap.ignoreSpellIds" config option)
                            flags_dis_spell_st += 64;
                            break;
                    }
                }
            }

            string[] checkedIndicies2 = Properties.Settings.Default.FlagsDisableMap.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
            for (int i1 = 0; i1 < checkedIndicies2.Length; i1++)
            {
                int idx;
                if ((int.TryParse(checkedIndicies2[i1], out idx)))
                {
                    switch (idx)
                    {
                        case 0: // DUNGEON_STATUSFLAG_NORMAL OR RAID_STATUSFLAG_10MAN_NORMAL
                            flags_dis_map_st += 1;
                            break;
                        case 1: // DUNGEON_STATUSFLAG_HEROIC OR RAID_STATUSFLAG_25MAN_NORMAL
                            flags_dis_map_st += 2;
                            break;
                        case 2: // RAID_STATUSFLAG_10MAN_HEROIC
                            flags_dis_map_st += 4;
                            break;
                        case 3: // RAID_STATUSFLAG_25MAN_HEROIC
                            flags_dis_map_st += 8;
                            break;
                    }
                }
            }

            string[] checkedIndicies3 = Properties.Settings.Default.FlagsDisableVmap.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
            for (int i1 = 0; i1 < checkedIndicies3.Length; i1++)
            {
                int idx;
                if ((int.TryParse(checkedIndicies3[i1], out idx)))
                {
                    switch (idx)
                    {
                        case 0: // VMAP_DISABLE_AREAFLAG
                            flags_dis_vmap_st += 1;
                            break;
                        case 1: // VMAP_DISABLE_HEIGHT
                            flags_dis_vmap_st += 2;
                            break;
                        case 2: // VMAP_DISABLE_LOS
                            flags_dis_vmap_st += 4;
                            break;
                        case 3: // VMAP_LIQUIDSTATUS
                            flags_dis_vmap_st += 8;
                            break;
                    }
                }
            }

            
            // Prepare SQL
            // select insertion columns
            string BuildSQLFile;
            BuildSQLFile = "INSERT INTO " + mainmenu.textbox_mysql_worldDB.Text + ".disables ";
            BuildSQLFile += "(sourceType, entry, flags, params_0, params_1, comment)";

            //Values
            BuildSQLFile += "VALUES\n ";
            BuildSQLFile += "(";

            if (textBox_SourceType.Text == "1"/*DISABLE_TYPE_QUEST*/) BuildSQLFile += "1, " + textBox_entry.Text + ", 0" + ", ";
            else if (textBox_SourceType.Text == "3"/*DISABLE_TYPE_BATTLEGROUND*/) BuildSQLFile += "3, " + textBox_entry.Text + ", 0" + ", ";
            else if (textBox_SourceType.Text == "4"/*DISABLE_TYPE_ACHIEVEMENT_CRITERIA*/) BuildSQLFile += "4, " + textBox_entry.Text + ", 0" + ", ";
            else if (textBox_SourceType.Text == "5"/*DISABLE_TYPE_OUTDOORPVP*/) BuildSQLFile += "5, " + textBox_entry.Text + ", 0" + ", ";
            else if (textBox_SourceType.Text == "7"/*DISABLE_TYPE_MMAP*/) BuildSQLFile += "7, " + textBox_entry.Text + ", 0" + ", ";
            else if (textBox_SourceType.Text == "8"/*DISABLE_TYPE_LFG_MAP*/) BuildSQLFile += "8, " + textBox_entry.Text + ", 0" + ", ";

            else
            {
                BuildSQLFile += textBox_SourceType.Text + ", " + textBox_entry.Text + ", "; // sourceType
            }

            //BuildSQLFile += textBox_entry.Text + ", "; // entry

            if (button_flags_dis_spell.Visible == true) BuildSQLFile += flags_dis_spell_st + ", "; // flags_disable_spell
            else if (button_flags_dis_map.Visible == true) BuildSQLFile += flags_dis_map_st + ", "; // flags_disable_map
            else if (button_flags_dis_vmap.Visible == true) BuildSQLFile += flags_dis_vmap_st + ", "; // flags_disable_vmap

            BuildSQLFile += "'" + textBox_params_0.Text + "', '"; // params_0
            BuildSQLFile += textBox_params_1.Text + "', '"; // params_1
            BuildSQLFile += textBox_comment.Text + "');"; // comment

            stringSQLShare = BuildSQLFile;

            if (textBox_entry.Text == "0")
            {
                MessageBox.Show("Entry should not be 0", "Error");
                return;
            }
            else if (textBox_entry.Text == "")
            {
                MessageBox.Show("Entry should not be empty", "Error");
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
                    label_Executed_Successfully.Visible = true;
                }
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            connection.Close();
        }

        private void label86_Click(object sender, EventArgs e)
        {
            uint flags_dis_spell_st = 0;
            uint flags_dis_map_st = 0;
            uint flags_dis_vmap_st = 0;

            string[] checkedIndicies1 = Properties.Settings.Default.FlagsDisableSpell.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
            for (int i1 = 0; i1 < checkedIndicies1.Length; i1++)
            {
                int idx;
                if ((int.TryParse(checkedIndicies1[i1], out idx)))
                {
                    switch (idx)
                    {
                        case 0: // Spell enabled
                            flags_dis_spell_st += 0;
                            break;
                        case 1: // Spell disabled for players
                            flags_dis_spell_st += 1;
                            break;
                        case 2: // Spell disabled for creatures
                            flags_dis_spell_st += 2;
                            break;
                        case 3: // Spell disabled for pets
                            flags_dis_spell_st += 4;
                            break;
                        case 4: // Spell completely disabled (used for no logner existing spells in DBCs)
                            flags_dis_spell_st += 8;
                            break;
                        case 5: // Spell disabled for MapId
                            flags_dis_spell_st += 16;
                            break;
                        case 6: // Spell disabled for AreaId
                            flags_dis_spell_st += 32;
                            break;
                        case 7: // Line of Sight (LOS) is disabled for this spell (replaces "vmap.ignoreSpellIds" config option)
                            flags_dis_spell_st += 64;
                            break;
                    }
                }
            }

            string[] checkedIndicies2 = Properties.Settings.Default.FlagsDisableMap.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
            for (int i1 = 0; i1 < checkedIndicies2.Length; i1++)
            {
                int idx;
                if ((int.TryParse(checkedIndicies2[i1], out idx)))
                {
                    switch (idx)
                    {
                        case 0: // DUNGEON_STATUSFLAG_NORMAL OR RAID_STATUSFLAG_10MAN_NORMAL
                            flags_dis_map_st += 1;
                            break;
                        case 1: // DUNGEON_STATUSFLAG_HEROIC OR RAID_STATUSFLAG_25MAN_NORMAL
                            flags_dis_map_st += 2;
                            break;
                        case 2: // RAID_STATUSFLAG_10MAN_HEROIC
                            flags_dis_map_st += 4;
                            break;
                        case 3: // RAID_STATUSFLAG_25MAN_HEROIC
                            flags_dis_map_st += 8;
                            break;
                    }
                }
            }

            string[] checkedIndicies3 = Properties.Settings.Default.FlagsDisableVmap.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
            for (int i1 = 0; i1 < checkedIndicies3.Length; i1++)
            {
                int idx;
                if ((int.TryParse(checkedIndicies3[i1], out idx)))
                {
                    switch (idx)
                    {
                        case 0: // VMAP_DISABLE_AREAFLAG
                            flags_dis_vmap_st += 1;
                            break;
                        case 1: // VMAP_DISABLE_HEIGHT
                            flags_dis_vmap_st += 2;
                            break;
                        case 2: // VMAP_DISABLE_LOS
                            flags_dis_vmap_st += 4;
                            break;
                        case 3: // VMAP_LIQUIDSTATUS
                            flags_dis_vmap_st += 8;
                            break;
                    }
                }
            }

            Form_MainMenu mainmenu = new Form_MainMenu();
            // Prepare SQL
            // select insertion columns
            string BuildSQLFile;
            BuildSQLFile = "INSERT INTO " + mainmenu.textbox_mysql_worldDB.Text + ".disables ";
            BuildSQLFile += "(sourceType, entry, flags, params_0, params_1, comment)";

            //Values
            BuildSQLFile += "VALUES\n ";
            BuildSQLFile += "(";

            if (textBox_SourceType.Text == "1"/*DISABLE_TYPE_QUEST*/) BuildSQLFile += "1, " + textBox_entry.Text + ", 0" + ", ";
            else if (textBox_SourceType.Text == "3"/*DISABLE_TYPE_BATTLEGROUND*/) BuildSQLFile += "3, " + textBox_entry.Text + ", 0" + ", ";
            else if (textBox_SourceType.Text == "4"/*DISABLE_TYPE_ACHIEVEMENT_CRITERIA*/) BuildSQLFile += "4, " + textBox_entry.Text + ", 0" + ", ";
            else if (textBox_SourceType.Text == "5"/*DISABLE_TYPE_OUTDOORPVP*/) BuildSQLFile += "5, " + textBox_entry.Text + ", 0" + ", ";
            else if (textBox_SourceType.Text == "7"/*DISABLE_TYPE_MMAP*/) BuildSQLFile += "7, " + textBox_entry.Text + ", 0" + ", ";
            else if (textBox_SourceType.Text == "8"/*DISABLE_TYPE_LFG_MAP*/) BuildSQLFile += "8, " + textBox_entry.Text + ", 0" + ", ";

            else
            {
                BuildSQLFile += textBox_SourceType.Text + ", " + textBox_entry.Text + ", "; // sourceType
            }
            
            //BuildSQLFile += textBox_entry.Text + ", "; // entry

            if (button_flags_dis_spell.Visible == true) BuildSQLFile += flags_dis_spell_st + ", "; // flags_disable_spell
            else if (button_flags_dis_map.Visible == true) BuildSQLFile += flags_dis_map_st + ", "; // flags_disable_map
            else if (button_flags_dis_vmap.Visible == true) BuildSQLFile += flags_dis_vmap_st + ", "; // flags_disable_vmap

            BuildSQLFile += "'" + textBox_params_0.Text + "', '"; // params_0
            BuildSQLFile += textBox_params_1.Text + "', '"; // params_1
            BuildSQLFile += textBox_comment.Text + "');"; // comment

            stringSQLShare = BuildSQLFile;

            if (textBox_entry.Text == "0")
            {
                MessageBox.Show("Entry should not be 0", "Error");
                return;
            }
            else if (textBox_entry.Text == "")
            {
                MessageBox.Show("Entry should not be empty", "Error");
                return;
            }

            Clipboard.SetText(stringSQLShare);
            label87.Visible = true;

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

        private void label1_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
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

        private void label9_Click(object sender, EventArgs e)
        {
            Process.Start("https://trinitycore.atlassian.net/wiki/display/tc/disables");
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

        int idx = 1;
        DateTime dt = new DateTime();
        private void timer2_Tick(object sender, EventArgs e)
        {
            label_stopwatch.Text = dt.AddSeconds(idx).ToString("HH:mm:ss");
            idx++;
        }

        private void label83_Click(object sender, EventArgs e)
        {

            uint flags_dis_spell_st = 0;
            uint flags_dis_map_st = 0;
            uint flags_dis_vmap_st = 0;

            string[] checkedIndicies1 = Properties.Settings.Default.FlagsDisableSpell.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
            for (int i1 = 0; i1 < checkedIndicies1.Length; i1++)
            {
                int idx;
                if ((int.TryParse(checkedIndicies1[i1], out idx)))
                {
                    switch (idx)
                    {
                        case 0: // Spell enabled
                            flags_dis_spell_st += 0;
                            break;
                        case 1: // Spell disabled for players
                            flags_dis_spell_st += 1;
                            break;
                        case 2: // Spell disabled for creatures
                            flags_dis_spell_st += 2;
                            break;
                        case 3: // Spell disabled for pets
                            flags_dis_spell_st += 4;
                            break;
                        case 4: // Spell completely disabled (used for no logner existing spells in DBCs)
                            flags_dis_spell_st += 8;
                            break;
                        case 5: // Spell disabled for MapId
                            flags_dis_spell_st += 16;
                            break;
                        case 6: // Spell disabled for AreaId
                            flags_dis_spell_st += 32;
                            break;
                        case 7: // Line of Sight (LOS) is disabled for this spell (replaces "vmap.ignoreSpellIds" config option)
                            flags_dis_spell_st += 64;
                            break;
                    }
                }
            }

            string[] checkedIndicies2 = Properties.Settings.Default.FlagsDisableMap.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
            for (int i1 = 0; i1 < checkedIndicies2.Length; i1++)
            {
                int idx;
                if ((int.TryParse(checkedIndicies2[i1], out idx)))
                {
                    switch (idx)
                    {
                        case 0: // DUNGEON_STATUSFLAG_NORMAL OR RAID_STATUSFLAG_10MAN_NORMAL
                            flags_dis_map_st += 1;
                            break;
                        case 1: // DUNGEON_STATUSFLAG_HEROIC OR RAID_STATUSFLAG_25MAN_NORMAL
                            flags_dis_map_st += 2;
                            break;
                        case 2: // RAID_STATUSFLAG_10MAN_HEROIC
                            flags_dis_map_st += 4;
                            break;
                        case 3: // RAID_STATUSFLAG_25MAN_HEROIC
                            flags_dis_map_st += 8;
                            break;
                    }
                }
            }

            string[] checkedIndicies3 = Properties.Settings.Default.FlagsDisableVmap.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
            for (int i1 = 0; i1 < checkedIndicies3.Length; i1++)
            {
                int idx;
                if ((int.TryParse(checkedIndicies3[i1], out idx)))
                {
                    switch (idx)
                    {
                        case 0: // VMAP_DISABLE_AREAFLAG
                            flags_dis_vmap_st += 1;
                            break;
                        case 1: // VMAP_DISABLE_HEIGHT
                            flags_dis_vmap_st += 2;
                            break;
                        case 2: // VMAP_DISABLE_LOS
                            flags_dis_vmap_st += 4;
                            break;
                        case 3: // VMAP_LIQUIDSTATUS
                            flags_dis_vmap_st += 8;
                            break;
                    }
                }
            }

            Form_MainMenu mainmenu = new Form_MainMenu();
            // Prepare SQL
            // select insertion columns
            string BuildSQLFile;
            BuildSQLFile = "INSERT INTO " + mainmenu.textbox_mysql_worldDB.Text + ".disables ";
            BuildSQLFile += "(sourceType, entry, flags, params_0, params_1, comment)";

            //Values
            BuildSQLFile += "VALUES\n ";
            BuildSQLFile += "(";

            if (textBox_SourceType.Text == "1"/*DISABLE_TYPE_QUEST*/) BuildSQLFile += "1, " + textBox_entry.Text + ", 0" + ", ";
            else if (textBox_SourceType.Text == "3"/*DISABLE_TYPE_BATTLEGROUND*/) BuildSQLFile += "3, " + textBox_entry.Text + ", 0" + ", ";
            else if (textBox_SourceType.Text == "4"/*DISABLE_TYPE_ACHIEVEMENT_CRITERIA*/) BuildSQLFile += "4, " + textBox_entry.Text + ", 0" + ", ";
            else if (textBox_SourceType.Text == "5"/*DISABLE_TYPE_OUTDOORPVP*/) BuildSQLFile += "5, " + textBox_entry.Text + ", 0" + ", ";
            else if (textBox_SourceType.Text == "7"/*DISABLE_TYPE_MMAP*/) BuildSQLFile += "7, " + textBox_entry.Text + ", 0" + ", ";
            else if (textBox_SourceType.Text == "8"/*DISABLE_TYPE_LFG_MAP*/) BuildSQLFile += "8, " + textBox_entry.Text + ", 0" + ", ";

            else
            {
                BuildSQLFile += textBox_SourceType.Text + ", " + textBox_entry.Text + ", "; // sourceType
            }

            //BuildSQLFile += textBox_entry.Text + ", "; // entry

            if (button_flags_dis_spell.Visible == true) BuildSQLFile += flags_dis_spell_st + ", "; // flags_disable_spell
            else if (button_flags_dis_map.Visible == true) BuildSQLFile += flags_dis_map_st + ", "; // flags_disable_map
            else if (button_flags_dis_vmap.Visible == true) BuildSQLFile += flags_dis_vmap_st + ", "; // flags_disable_vmap

            BuildSQLFile += "'" + textBox_params_0.Text + "', '"; // params_0
            BuildSQLFile += textBox_params_1.Text + "', '"; // params_1
            BuildSQLFile += textBox_comment.Text + "');"; // comment

            stringSQLShare = BuildSQLFile;
            stringEntryShare = textBox_entry.Text;

            if (textBox_entry.Text == "0")
            {
                MessageBox.Show("Entry should not be 0", "Error");
                return;
            }
            else if (textBox_entry.Text == "")
            {
                MessageBox.Show("Entry should not be empty", "Error");
                return;
            }

            using (var sfd = new SaveFileDialog())
            {
                sfd.Filter = "sql files (*.sql)|*.sql";
                sfd.FilterIndex = 2;
                sfd.FileName = "Disable_" + stringEntryShare;

                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    File.WriteAllText(sfd.FileName, stringSQLShare);
                    label88.Visible = true;
                }
            }
        }

        private void timer3_Tick(object sender, EventArgs e)
        {
            //label87.
        }

        private void textBox_entry_TextChanged(object sender, EventArgs e)
        {
            label87.Visible = false; //Query has been copied to clipboard!
            label88.Visible = false; //File has been successfully saved!
            label_Executed_Successfully.Visible = false;
        }

        private void textBox_params_0_TextChanged(object sender, EventArgs e)
        {
            label87.Visible = false; //Query has been copied to clipboard!
            label88.Visible = false; //File has been successfully saved!
            label_Executed_Successfully.Visible = false;
        }

        private void textBox_params_1_TextChanged(object sender, EventArgs e)
        {
            label87.Visible = false; //Query has been copied to clipboard!
            label88.Visible = false; //File has been successfully saved!
            label_Executed_Successfully.Visible = false;
        }

        private void textBox_comment_TextChanged(object sender, EventArgs e)
        {
            label87.Visible = false; //Query has been copied to clipboard!
            label88.Visible = false; //File has been successfully saved!
            label_Executed_Successfully.Visible = false;
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("http://emucraft.com");
        }

        private void textBox_entry_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void label83_MouseEnter(object sender, EventArgs e)
        {
            panel5.BackColor = Color.Firebrick;
        }

        private void label83_MouseLeave(object sender, EventArgs e)
        {
            panel5.BackColor = Color.FromArgb(58, 89, 114);
        }
        //=========================================================
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

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("https://trinitycore.atlassian.net/wiki/display/tc/AreaTable");
        }
    }
}
