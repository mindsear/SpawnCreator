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
using System.Runtime.InteropServices;

namespace SpawnCreator
{
    public partial class QuestTemplate : Form
    {

        public QuestTemplate()
        {
            InitializeComponent();
            //textBox66.ForeColor = SystemColors.GrayText;
            //textBox66.Text = "Example: Slay 10 Stonetusk Boars and then report back to Smith Argus in Goldshire.";
            //this.textBox66.Leave += new System.EventHandler(this.textBox66_Leave);
            //this.textBox66.Enter += new System.EventHandler(this.textBox66_Enter);
        }

        //private void textBox66_Leave(object sender, EventArgs e)
        //{
        //    if (textBox66.Text.Length == 0)
        //    {
        //        textBox66.Text = "Example: Slay 10 Stonetusk Boars and then report back to Smith Argus in Goldshire.";
        //        textBox66.ForeColor = SystemColors.GrayText;
        //    }
        //}

        //private void textBox66_Enter(object sender, EventArgs e)
        //{
        //    if (textBox66.Text == "Example: Slay 10 Stonetusk Boars and then report back to Smith Argus in Goldshire.")
        //    {
        //        textBox66.Text = "";
        //        textBox66.ForeColor = SystemColors.WindowText;
        //    }
        //}

        private readonly Form_MainMenu form_MM;
        public QuestTemplate(Form_MainMenu form_MainMenu)
        {
            InitializeComponent();
            form_MM = form_MainMenu;
        }

        MySqlConnection connection = new MySqlConnection();
        public void GetMySqlConnection()
        {
            MySqlConnection _connection = new MySqlConnection(
                               "datasource = " + form_MM.GetHost() + "; " +
                               "port=" + form_MM.GetPort() + ";" +
                               "username=" + form_MM.GetUser() + ";" +
                               "password=" + form_MM.GetPass() + ";"
                            );
            connection = _connection;
        }

        private bool _mouseDown;
        private Point lastLocation;

        Form_MainMenu mainmenu = new Form_MainMenu();

        public static string stringSQLShare;
        public static string stringEntryShare;

        private void QuestTemplate_Load(object sender, EventArgs e)
        {
            textBox66.SelectionStart = 0;  //This keeps the text
            textBox66.SelectionLength = 0; //from being highlighted
            textBox66.ForeColor = Color.Gray;

            if (form_MM.CB_NoMySQL.Checked)
            {
                label_mysql_status2.Visible = false;
                label85.Visible = false; // MySQL Status - Top Label
                timer2.Enabled = false; //Check if MySQL is still running
                button3.Visible = false; // max+1 button
                button2.Visible = false; // execute query button
            }
            else
            {
                label_mysql_status2.Visible = true;
                label85.Visible = true; // MySQL Status - Top Label
                timer2.Enabled = true; //Check if MySQL is still running
                button3.Visible = true; // max+1 button
                button2.Visible = true; // execute query button
            }

            timer1.Start(); //Stopwatch

            comboBox1.SelectedIndex = 2; // Show default - Quest Enabled
            comboBox2.SelectedIndex = 0; /*All Races*/
            comboBox3.SelectedIndex = 0; // INSERT

            //button3_Click(sender, e); // max+1

            textBox107.Text = NUD_Entry.Text;
            textBox108.Text = NUD_Entry.Text;
        }

        private void GenerateSqlCode(object sender, EventArgs e)
        {
            uint quest_flags_st = 0;

            string[] checkedIndicies1 = Properties.Settings.Default.QuestFlags.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
            for (int i1 = 0; i1 < checkedIndicies1.Length; i1++)
            {
                int idx;
                if ((int.TryParse(checkedIndicies1[i1], out idx)))
                {
                    switch (idx)
                    {
                        case 0: quest_flags_st += 0; break; // QUEST_FLAGS_NONE
                        case 1: quest_flags_st += 1; break; // QUEST_FLAGS_STAY_ALIVE
                        case 2: quest_flags_st += 2; break; // QUEST_FLAGS_PARTY_ACCEPT
                        case 3: quest_flags_st += 4; break; // QUEST_FLAGS_EXPLORATION
                        case 4: quest_flags_st += 8; break; // QUEST_FLAGS_SHARABLE
                        case 5: quest_flags_st += 16; break; // QUEST_FLAGS_NONE2
                        case 6: quest_flags_st += 32; break; // QUEST_FLAGS_EPIC
                        case 7: quest_flags_st += 64; break; // QUEST_FLAGS_RAID
                        case 8: quest_flags_st += 128; break; // QUEST_FLAGS_TBC
                        case 9: quest_flags_st += 256; break; // QUEST_FLAGS_DELIVER_MORE
                        case 10: quest_flags_st += 512; break; // QUEST_FLAGS_HIDDEN_REWARDS
                        case 11: quest_flags_st += 1024; break; // QUEST_FLAGS__AUTO_REWARDED
                        case 12: quest_flags_st += 2048; break; // QUEST_FLAGS_TBC_RACES
                        case 13: quest_flags_st += 4096; break; // QUEST_FLAGS_DAILY
                        case 14: quest_flags_st += 8192; break; // QUEST_FLAGS_REPEATABLE
                        case 15: quest_flags_st += 16384; break; // QUEST_FLAGS_UNAVAILABLE
                        case 16: quest_flags_st += 32768; break; // QUEST_FLAGS_WEEKLY
                        case 17: quest_flags_st += 65536; break; // QUEST_FLAGS_AUTOCOMPLETE
                        case 18: quest_flags_st += 131072; break; // QUEST_FLAGS_SPECIAL_ITEM
                        case 19: quest_flags_st += 262144; break; // QUEST_FLAGS_OBJ_TEXT
                        case 20: quest_flags_st += 524288; break; // QUEST_FLAGS_AUTO_ACCEPT
                        case 21: quest_flags_st += 1048576; break; // QUEST_FLAGS_AUTO_SUBMIT
                        case 22: quest_flags_st += 2097152; break; // QUEST_FLAGS_AUTO_TAKE
                    }
                }
            }
            
            // Prepare SQL
            // select insertion columns
            string BuildSQLFile;
            BuildSQLFile = textBox105.Text + " INTO " + form_MM.GetWorldDB() + ".quest_template ";
            BuildSQLFile += "(ID, QuestType, QuestLevel, MinLevel, QuestSortID, QuestInfoID, SuggestedGroupNum, RequiredFactionId1, RequiredFactionId2, RequiredFactionValue1, ";
            BuildSQLFile += "RequiredFactionValue2, RewardNextQuest, RewardXPDifficulty, RewardMoney, RewardBonusMoney, RewardDisplaySpell, RewardSpell, RewardHonor, ";
            BuildSQLFile += "RewardKillHonor, StartItem, Flags, RequiredPlayerKills, RewardItem1, RewardAmount1, RewardItem2, RewardAmount2, RewardItem3, RewardAmount3, RewardItem4, ";
            BuildSQLFile += "RewardAmount4, ItemDrop1, ItemDropQuantity1, ItemDrop2, ItemDropQuantity2, ItemDrop3, ItemDropQuantity3, ItemDrop4, ";
            BuildSQLFile += "ItemDropQuantity4, RewardChoiceItemID1, RewardChoiceItemQuantity1, RewardChoiceItemID2, RewardChoiceItemQuantity2, RewardChoiceItemID3, ";
            BuildSQLFile += "RewardChoiceItemQuantity3, RewardChoiceItemID4, RewardChoiceItemQuantity4, RewardChoiceItemID5, RewardChoiceItemQuantity5, RewardChoiceItemID6, RewardChoiceItemQuantity6, ";
            BuildSQLFile += "POIContinent, POIx, POIy, POIPriority, RewardTitle, RewardTalents, RewardArenaPoints, RewardFactionID1, RewardFactionValue1, RewardFactionOverride1, ";
            BuildSQLFile += "RewardFactionID2, RewardFactionValue2, RewardFactionOverride2, RewardFactionID3, RewardFactionValue3, RewardFactionOverride3, RewardFactionID4, ";
            BuildSQLFile += "RewardFactionValue4, RewardFactionOverride4, RewardFactionID5, RewardFactionValue5, RewardFactionOverride5, TimeAllowed, AllowableRaces, LogTitle, LogDescription, ";
            BuildSQLFile += "QuestDescription, AreaDescription, QuestCompletionLog, RequiredNpcOrGo1, RequiredNpcOrGo2, RequiredNpcOrGo3, RequiredNpcOrGo4, RequiredNpcOrGoCount1, ";
            BuildSQLFile += "RequiredNpcOrGoCount2, RequiredNpcOrGoCount3, RequiredNpcOrGoCount4, RequiredItemId1, RequiredItemId2, RequiredItemId3, RequiredItemId4, RequiredItemId5, RequiredItemId6, ";
            BuildSQLFile += "RequiredItemCount1, RequiredItemCount2, RequiredItemCount3, RequiredItemCount4, RequiredItemCount5, ";
            BuildSQLFile += "RequiredItemCount6, Unknown0, ObjectiveText1, ObjectiveText2, ObjectiveText3, ObjectiveText4, VerifiedBuild) ";

            // values now
            BuildSQLFile += "VALUES \n";
            BuildSQLFile += "(";
            BuildSQLFile += NUD_Entry.Value + ", "; // ID
            BuildSQLFile += textBox2.Text + ", "; // QuestType
            BuildSQLFile += textBox3.Text + ", "; // QuestLevel
            BuildSQLFile += textBox4.Text + ", "; // MinLevel
            BuildSQLFile += textBox8.Text + ", "; // QuestSortID
            BuildSQLFile += textBox7.Text + ", "; // QuestInfoID
            BuildSQLFile += textBox6.Text + ", "; // SuggestedGroupNum
            BuildSQLFile += textBox5.Text + ", "; // RequiredFactionId1
            BuildSQLFile += textBox12.Text + ", "; // RequiredFactionId2
            BuildSQLFile += textBox11.Text + ", "; // RequiredFactionValue1
            BuildSQLFile += textBox10.Text + ", "; // RequiredFactionValue2
            BuildSQLFile += textBox9.Text + ", "; // RewardNextQuest
            BuildSQLFile += textBox20.Text + ", "; // RewardXPDifficulty
            BuildSQLFile += textBox19.Text + ", "; // RewardMoney
            BuildSQLFile += textBox18.Text + ", "; // RewardBonusMoney
            BuildSQLFile += textBox17.Text + ", "; // RewardDisplaySpell
            BuildSQLFile += textBox16.Text + ", "; // RewardSpell
            BuildSQLFile += textBox15.Text + ", "; // RewardHonor
            BuildSQLFile += textBox14.Text + ", "; // RewardKillHonor
            BuildSQLFile += textBox13.Text + ", "; // StartItem
            BuildSQLFile += quest_flags_st + ", "; // Flags
            BuildSQLFile += textBox40.Text + ", "; // RequiredPlayerKills
            BuildSQLFile += textBox39.Text + ", "; // RewardItem1
            BuildSQLFile += textBox38.Text + ", "; // RewardAmount1
            BuildSQLFile += textBox37.Text + ", "; // RewardItem2
            BuildSQLFile += textBox36.Text + ", "; // RewardAmount2
            BuildSQLFile += textBox35.Text + ", "; // RewardItem3
            BuildSQLFile += textBox34.Text + ", "; // RewardAmount3
            BuildSQLFile += textBox33.Text + ", "; // RewardItem4
            BuildSQLFile += textBox32.Text + ", "; // RewardAmount4
            BuildSQLFile += textBox31.Text + ", "; // ItemDrop1
            BuildSQLFile += textBox30.Text + ", "; // ItemDropQuantity1
            BuildSQLFile += textBox29.Text + ", "; // ItemDrop2
            BuildSQLFile += textBox28.Text + ", "; // ItemDropQuantity2
            BuildSQLFile += textBox27.Text + ", "; // ItemDrop3
            BuildSQLFile += textBox26.Text + ", "; // ItemDropQuantity3
            BuildSQLFile += textBox25.Text + ", "; // ItemDrop4
            BuildSQLFile += textBox24.Text + ", "; // ItemDropQuantity4
            BuildSQLFile += textBox23.Text + ", "; // RewardChoiceItemID1
            BuildSQLFile += textBox22.Text + ", "; // RewardChoiceItemQuantity1
            BuildSQLFile += textBox21.Text + ", "; // RewardChoiceItemID2
            BuildSQLFile += textBox60.Text + ", "; // RewardChoiceItemQuantity2
            BuildSQLFile += textBox59.Text + ", "; // RewardChoiceItemID3
            BuildSQLFile += textBox58.Text + ", "; // RewardChoiceItemQuantity3
            BuildSQLFile += textBox57.Text + ", "; // RewardChoiceItemID4
            BuildSQLFile += textBox56.Text + ", "; // RewardChoiceItemQuantity4
            BuildSQLFile += textBox55.Text + ", "; // RewardChoiceItemID5
            BuildSQLFile += textBox54.Text + ", "; // RewardChoiceItemQuantity5
            BuildSQLFile += textBox53.Text + ", "; // RewardChoiceItemID6
            BuildSQLFile += textBox52.Text + ", "; // RewardChoiceItemQuantity6
            BuildSQLFile += textBox51.Text + ", "; // POIContinent
            BuildSQLFile += textBox50.Text + ", "; // POIx
            BuildSQLFile += textBox49.Text + ", "; // POIy
            BuildSQLFile += textBox48.Text + ", "; // POIPriority
            BuildSQLFile += textBox47.Text + ", "; // RewardTitle
            BuildSQLFile += textBox46.Text + ", "; // RewardTalents
            BuildSQLFile += textBox45.Text + ", "; // RewardArenaPoints
            BuildSQLFile += textBox44.Text + ", "; // RewardFactionID1
            BuildSQLFile += textBox43.Text + ", "; // RewardFactionValue1
            BuildSQLFile += textBox42.Text + ", "; // RewardFactionOverride1
            BuildSQLFile += textBox41.Text + ", "; // RewardFactionID2
            BuildSQLFile += textBox80.Text + ", "; // RewardFactionValue2
            BuildSQLFile += textBox79.Text + ", "; // RewardFactionOverride2
            BuildSQLFile += textBox78.Text + ", "; // RewardFactionID3
            BuildSQLFile += textBox77.Text + ", "; // RewardFactionValue3
            BuildSQLFile += textBox76.Text + ", "; // RewardFactionOverride3
            BuildSQLFile += textBox75.Text + ", "; // RewardFactionID4
            BuildSQLFile += textBox74.Text + ", "; // RewardFactionValue4
            BuildSQLFile += textBox73.Text + ", "; // RewardFactionOverride4
            BuildSQLFile += textBox72.Text + ", "; // RewardFactionID5
            BuildSQLFile += textBox71.Text + ", "; // RewardFactionValue5
            BuildSQLFile += textBox70.Text + ", "; // RewardFactionOverride5
            BuildSQLFile += textBox69.Text + ", "; // TimeAllowed
            BuildSQLFile += textBox68.Text + ", "; // AllowableRaces 
            BuildSQLFile += "'" + textBox67.Text + "', "; // LogTitle
            BuildSQLFile += "'" + textBox66.Text + "', "; // LogDescription
            BuildSQLFile += "'" + textBox65.Text + "', "; // QuestDescription
            BuildSQLFile += "'" + textBox64.Text + "', "; // AreaDescription
            BuildSQLFile += "'" + textBox63.Text + "', "; // QuestCompletionLog
            BuildSQLFile += textBox62.Text + ", "; // RequiredNpcOrGo1
            BuildSQLFile += textBox61.Text + ", "; // RequiredNpcOrGo2
            BuildSQLFile += textBox83.Text + ", "; // RequiredNpcOrGo3
            BuildSQLFile += textBox81.Text + ", "; // RequiredNpcOrGo4
            BuildSQLFile += textBox86.Text + ", "; // RequiredNpcOrGoCount1
            BuildSQLFile += textBox85.Text + ", "; // RequiredNpcOrGoCount2
            BuildSQLFile += textBox84.Text + ", "; // RequiredNpcOrGoCount3
            BuildSQLFile += textBox83.Text + ", "; // RequiredNpcOrGoCount4
            BuildSQLFile += textBox90.Text + ", "; // RequiredItemId1
            BuildSQLFile += textBox87.Text + ", "; // RequiredItemId2
            BuildSQLFile += textBox99.Text + ", "; // RequiredItemId3
            BuildSQLFile += textBox96.Text + ", "; // RequiredItemId4
            BuildSQLFile += textBox93.Text + ", "; // RequiredItemId5
            BuildSQLFile += textBox102.Text + ", "; // RequiredItemId6
            BuildSQLFile += textBox89.Text + ", "; // RequiredItemCount1
            BuildSQLFile += textBox101.Text + ", "; // RequiredItemCount2
            BuildSQLFile += textBox98.Text + ", "; // RequiredItemCount3
            BuildSQLFile += textBox95.Text + ", "; // RequiredItemCount4
            BuildSQLFile += textBox92.Text + ", "; // RequiredItemCount5
            BuildSQLFile += textBox103.Text + ", "; // RequiredItemCount6
            BuildSQLFile += textBox88.Text + ", "; // Unknown0
            BuildSQLFile += "'" + textBox97.Text + "', "; // ObjectiveText1
            BuildSQLFile += "'" + textBox94.Text + "', "; // ObjectiveText2
            BuildSQLFile += "'" + textBox91.Text + "', "; // ObjectiveText3
            BuildSQLFile += "'" + textBox104.Text + "', "; // ObjectiveText4
            BuildSQLFile += textBox100.Text; // VerifiedBuild
            BuildSQLFile += "); \n";

            //Creature Quest Starter
            BuildSQLFile += textBox105.Text + " INTO " + form_MM.GetWorldDB() + ".creature_queststarter ";
            BuildSQLFile += "(id, quest) ";
            BuildSQLFile += "VALUES \n";
            BuildSQLFile += "(";
            BuildSQLFile += textBox106.Text + ", "; // Creature Entry
            BuildSQLFile += textBox107.Text; // Quest ID
            BuildSQLFile += "); \n";

            //Creature Quest Ender
            BuildSQLFile += textBox105.Text + " INTO " + form_MM.GetWorldDB() + ".creature_questender ";
            BuildSQLFile += "(id, quest) ";
            BuildSQLFile += "VALUES \n";
            BuildSQLFile += "(";
            BuildSQLFile += textBox109.Text + ", "; // Creature Entry
            BuildSQLFile += textBox108.Text; // Quest ID
            BuildSQLFile += "); \n";

            stringSQLShare = BuildSQLFile;
            stringEntryShare = NUD_Entry.Text;
        }

        //private bool CheckTextBoxes( /*TextBox textbox, bool true*/)
        //{          
        //    return true;
        //}

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void groupBox3_Enter(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void label78_Click(object sender, EventArgs e)
        {
            Close();

            BackToMainMenu back = new BackToMainMenu(form_MM);
            back.Show();
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
                this.Location = new Point(
                    (this.Location.X - lastLocation.X) + e.X, (this.Location.Y - lastLocation.Y) + e.Y);

                this.Update();
            }
        }

        private void panel2_MouseUp(object sender, MouseEventArgs e)
        {
            _mouseDown = false;
        }

        private void label2_MouseEnter(object sender, EventArgs e)
        {
            label2.BackColor = Color.Firebrick;
        }

        private void label2_MouseLeave(object sender, EventArgs e)
        {
            label2.BackColor = Color.FromArgb(58, 89, 114);
        }

        private void label1_MouseEnter(object sender, EventArgs e)
        {
            label1.BackColor = Color.Firebrick;
        }

        private void label1_MouseLeave(object sender, EventArgs e)
        {
            label1.BackColor = Color.FromArgb(58, 89, 114);
        }

        private void label78_MouseEnter(object sender, EventArgs e)
        {
            label78.BackColor = Color.Firebrick;
        }

        private void label78_MouseLeave(object sender, EventArgs e)
        {
            label78.BackColor = Color.FromArgb(58, 89, 114);
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("http://emucraft.com");
        }

        //===================================================================
        int idx = 1;
        DateTime dt = new DateTime();
        private void timer1_Tick(object sender, EventArgs e)
        {
            label_stopwatch.Text = dt.AddSeconds(idx).ToString("HH:mm:ss");
            idx++;
        }
        //===================================================================

        private void label83_MouseEnter(object sender, EventArgs e)
        {
            panel5.BackColor = Color.Firebrick;
        }

        private void label83_MouseLeave(object sender, EventArgs e)
        {
            panel5.BackColor = Color.FromArgb(58, 89, 114);
        }
        //===================================================================
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

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            textBox2.Text = Convert.ToString(comboBox1.SelectedIndex);
        }

        public bool IsProcessOpen(string name = "mysqld")
        {
            foreach (Process clsProcess in Process.GetProcesses())
            {
                if (clsProcess.ProcessName.Contains(name))
                {
                    label_mysql_status2.Text = "Connected!";
                    label_mysql_status2.ForeColor = Color.LawnGreen;
                    button3.Visible = true; // max+1
                    button2.Visible = true; // Execute Query
                    label85.Visible = true; // MySQL Status
                    btn_DeleteQuery.Enabled = true;
                    //// Start with mysql
                    //label_mysql_status2.Visible = true;
                    //label85.Visible = true;
                    //timer1.Enabled = true;
                    return true;

                }
            }

            label_mysql_status2.Text = "Connection Lost - MySQL is not running";
            label_mysql_status2.ForeColor = Color.Red;
            button3.Visible = false; // max+1
            button2.Visible = false; // Execute Query
            btn_DeleteQuery.Enabled = false;
            return false;
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            IsProcessOpen();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //--------------------------------\\
            //  Max + 1 from Database - Button  \\
            //------------------------------------\\

            GetMySqlConnection();

            string insertQuery = "SELECT max(ID)+1 FROM " + form_MM.GetWorldDB() + ".quest_template;";
            //string insertQuery = textBox_SelectMaxPlus1.Text;
            connection.Open();
            MySqlCommand command = new MySqlCommand(insertQuery, connection);

            try
            {
                NUD_Entry.Value = Convert.ToDecimal(command.ExecuteScalar());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            connection.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            QuestFlags_Form questFlags = new QuestFlags_Form();
            questFlags.ShowDialog();
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("https://trinitycore.atlassian.net/wiki/display/tc/quest_template");
        }

        private void label83_Click(object sender, EventArgs e)
        {
            GenerateSqlCode(sender, e);

            if (NUD_Entry.Text == "")
            {
                MessageBox.Show("ID should not be empty", "Error");
                return;
            }
            if (NUD_Entry.Text == "0")
            {
                MessageBox.Show("ID should not be 0", "Error");
                return;
            }
            if (textBox67.Text == "")
            {
                MessageBox.Show("Quest Title should not be empty", "Error");
                return;
            }
            if (textBox106.Text == "")
            {
                MessageBox.Show("Creature Quest Starter Entry should not be empty", "Error");
                return;
            }
            if (textBox109.Text == "")
            {
                MessageBox.Show("Creature Quest Ender Entry should not be empty", "Error");
                return;
            }

            using (var sfd = new SaveFileDialog())
            {
                sfd.Filter = "sql files (*.sql)|*.sql";
                sfd.FilterIndex = 2;
                //                                                 LogTitle
                sfd.FileName = "Quest[" + stringEntryShare + "]" + textBox67.Text;

                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    File.WriteAllText(sfd.FileName, stringSQLShare);
                    label_saved.Visible = true;
                }
            }
        }

        private void label86_Click(object sender, EventArgs e)
        {
            GenerateSqlCode(sender, e);

            if (NUD_Entry.Text == "")
            {
                MessageBox.Show("ID should not be empty", "Error");
                return;
            }
            if (NUD_Entry.Text == "0")
            {
                MessageBox.Show("ID should not be 0", "Error");
                return;
            }
            if (textBox67.Text == "")
            {
                MessageBox.Show("Quest Title should not be empty", "Error");
                return;
            }
            if (textBox106.Text == "")
            {
                MessageBox.Show("Creature Quest Starter Entry should not be empty", "Error");
                return;
            }
            if (textBox109.Text == "")
            {
                MessageBox.Show("Creature Quest Ender Entry should not be empty", "Error");
                return;
            }

            Clipboard.SetText(stringSQLShare);
            label_copied_to_clipboard.Visible = true;
        }

        // Execut Query - button
        private void button2_Click(object sender, EventArgs e)
        {
            GenerateSqlCode(sender, e);

            if (NUD_Entry.Text == "")
            {
                MessageBox.Show("ID should not be empty", "Error");
                return;
            }
            if (NUD_Entry.Text == "0")
            {
                MessageBox.Show("ID should not be 0", "Error");
                return;
            }
            if (textBox67.Text == "")
            {
                MessageBox.Show("Quest Title should not be empty", "Error");
                return;
            }
            if (textBox106.Text == "")
            {
                MessageBox.Show("Creature Quest Starter Entry should not be empty", "Error");
                return;
            }
            if (textBox109.Text == "")
            {
                MessageBox.Show("Creature Quest Ender Entry should not be empty", "Error");
                return;
            }

            GetMySqlConnection();

            string insertQuery = stringSQLShare;
            connection.Open();
            MySqlCommand command = new MySqlCommand(insertQuery, connection);

            try
            {
                
                if (command.ExecuteNonQuery() >= 1)
                {
                    label_query_executed_successfully.Visible = true;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            connection.Close();
        }

        //All textBoxes
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            

            label_query_executed_successfully.Visible = false;
            label_copied_to_clipboard.Visible = false;
            label_saved.Visible = false;
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            //textBox68.Text = comboBox2.Text;

            if (comboBox2.SelectedIndex == 0/*All Races*/) textBox68.Text = "0";
           else if (comboBox2.SelectedIndex == 1/*Horde Quest*/) textBox68.Text = "690";
            else if (comboBox2.SelectedIndex == 2/*Alliance Quest*/) textBox68.Text = "1101";
            else if (comboBox2.SelectedIndex == 3/*Human*/) textBox68.Text = "1";
            else if (comboBox2.SelectedIndex == 4/*Orc*/) textBox68.Text = "2";
            else if (comboBox2.SelectedIndex == 5/*Dwarf*/) textBox68.Text = "4";
            else if (comboBox2.SelectedIndex == 6/*Night Elf*/) textBox68.Text = "8";
            else if (comboBox2.SelectedIndex == 7/*Undead*/) textBox68.Text = "16";
            else if (comboBox2.SelectedIndex == 8/*Tauren*/) textBox68.Text = "32";
            else if (comboBox2.SelectedIndex == 9/*Gnome*/) textBox68.Text = "64";
            else if (comboBox2.SelectedIndex == 10/*Troll*/) textBox68.Text = "128";
            else if (comboBox2.SelectedIndex == 11/*Blood Elf*/) textBox68.Text = "512";
            else if (comboBox2.SelectedIndex == 12/*Draenei*/) textBox68.Text = "1024";
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            btn_DeleteQuery.Visible = false;
            if (comboBox3.SelectedIndex == 0)
            {
                textBox105.Text = "INSERT";

            }
            else if (comboBox3.SelectedIndex == 1)
            {
                textBox105.Text = "REPLACE";

            }
            else if (comboBox3.SelectedIndex == 2)
            {
                if(form_MM.CB_NoMySQL.Checked || label_mysql_status2.Text == "Connection Lost - MySQL is not running")
                {
                    btn_DeleteQuery.Enabled = false;
                }

                btn_DeleteQuery.Visible = true;
            }
        }


        // All Numbers textBoxes
        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.') && (e.KeyChar != '-'))
            {
                e.Handled = true;
            }

            // only allow one decimal point
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }

            // allow one minus symbol
            if ((e.KeyChar == '-') && ((sender as TextBox).Text.IndexOf('-') > -1))
            {
                e.Handled = true;
            }
        }

        private void label119_MouseEnter(object sender, EventArgs e)
        {
            toolTip1.SetToolTip(label119, "A file labeled Quests.sql will be created in the same directory as the SpawnCreator vX.X executable. \nSo you can save multiple data rows in a single .sql file.");
            toolTip1.AutoPopDelay = 10000; // 10 seconds
        }

        private void button_SaveInTheSameFile_Click(object sender, EventArgs e)
        {
            GenerateSqlCode(sender, e);

            if (NUD_Entry.Text == "")
            {
                MessageBox.Show("ID should not be empty", "Error");
                return;
            }
            if (NUD_Entry.Text == "0")
            {
                MessageBox.Show("ID should not be 0", "Error");
                return;
            }
            if (textBox67.Text == "")
            {
                MessageBox.Show("Quest Title should not be empty", "Error");
                return;
            }
            if (textBox106.Text == "")
            {
                MessageBox.Show("Creature Quest Starter Entry should not be empty", "Error");
                return;
            }
            if (textBox109.Text == "")
            {
                MessageBox.Show("Creature Quest Ender Entry should not be empty", "Error");
                return;
            }

            using (var writer = File.AppendText("Quests.sql"))
            {
                writer.Write(stringSQLShare);
                button_SaveInTheSameFile.Text = "Saved!";
                button_SaveInTheSameFile.TextAlign = ContentAlignment.MiddleCenter;
            }
        }

        private void NUD_Entry_ValueChanged(object sender, EventArgs e)
        {
            button_SaveInTheSameFile.Text = "Save in the same file";
            button_SaveInTheSameFile.TextAlign = ContentAlignment.MiddleRight;

            textBox107.Text = NUD_Entry.Text;
            textBox108.Text = NUD_Entry.Text;
        }

        private void All_textBoxes_MouseEnter(object sender, EventArgs e)
        {
            NUD_Entry_ValueChanged(sender, e);
        }

        private void All_ComboBoxes_MouseEnter(object sender, EventArgs e)
        {
            NUD_Entry_ValueChanged(sender, e);
        }

        private void button_SaveInTheSameFile_MouseEnter(object sender, EventArgs e)
        {
            button_SaveInTheSameFile.BackColor = Color.Firebrick;
        }

        private void button_SaveInTheSameFile_MouseLeave(object sender, EventArgs e)
        {
            button_SaveInTheSameFile.BackColor = Color.FromArgb(58, 89, 114);
        }

        private void btn_DeleteItem_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Are you sure you want to delete Quest " + NUD_Entry.Text + " ?", "SpawnCreator " + form_MM.version, MessageBoxButtons.YesNo);
            if (dr == DialogResult.No)
                return;

            else
            {
                GetMySqlConnection();

                string insertQuery = "DELETE FROM " + form_MM.GetWorldDB() + ".quest_template WHERE ID=" + NUD_Entry.Text + ";" +
                                     "DELETE FROM " + form_MM.GetWorldDB() + ".creature_queststarter WHERE quest=" + NUD_Entry.Text + ";" +
                                     "DELETE FROM " + form_MM.GetWorldDB() + ".creature_questender WHERE quest=" + NUD_Entry.Text + ";" ;

                connection.Open();
                MySqlCommand command = new MySqlCommand(insertQuery, connection);

                try
                {
                    command.ExecuteNonQuery();
                    MessageBox.Show("Quest Deleted!", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                connection.Close();
            }
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            object sender = new object();
            EventArgs e = new EventArgs();

            if (keyData == Keys.F2)
            {
                button_SaveInTheSameFile_Click(sender, e); // Save in the same file if "F2" key is pressed
                return true;
            }

            else if (keyData == Keys.F5)
            {
                button2_Click(sender, e); // Execute Query if "F5" key is pressed
                return true;
            }

            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void textBox66_KeyDown(object sender, KeyEventArgs e)
        {
            if (textBox66.Text.Equals("Example: Slay 10 Stonetusk Boars and then report back to Smith Argus in Goldshire.") == true)
            {
                textBox66.Text = "";
                textBox66.ForeColor = Color.Black;
            }
        }

        private void textBox66_KeyUp(object sender, KeyEventArgs e)
        {
            if (textBox66.Text.Equals(null) == true || textBox66.Text.Equals("") == true)
            {
                textBox66.Text = "Example: Slay 10 Stonetusk Boars and then report back to Smith Argus in Goldshire.";
                textBox66.ForeColor = Color.Gray;
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Value > 0: required creature_template ID the player needs to kill/cast on in order to complete the quest. \n" +
                "Value < 0: required gameobject_template ID the player needs to cast on in order to complete the quest. \n" +
                "If*RequiredSpellCast*is != 0, the objective is to cast on target, else kill. \n" +
                "NOTE: If RequiredSpellCast is != 0 and the spell has effects Send Event or Quest Complete, this field may be left empty." 
                 , "RequiredNpcOrGo", MessageBoxButtons.OK
                );
        }
    }
}
