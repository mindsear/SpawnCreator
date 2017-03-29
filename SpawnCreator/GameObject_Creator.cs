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

        public static string stringSqlShare;

        private void GenerateQuery()
        {
            string BuildSqlFile;
            BuildSqlFile = textBox105.Text + " INTO " + form_MM.GetWorldDB() + ".gameobject_template ";
            BuildSqlFile += "(entry, type, displayId, name, IconName, castBarCaption, unk1, ";
            BuildSqlFile += "size, Data0, Data1, Data2, Data3, Data4, Data5, Data6, Data7, Data8, Data9, Data10, Data11, Data12, Data13, Data14, Data15, ";
            BuildSqlFile += "Data16, Data17, Data18, Data19, Data20, Data21, Data22, Data23, AIName, ScriptName, VerifiedBuild) ";
            BuildSqlFile += "VALUES \n";
            
            BuildSqlFile += "(" + NUD_Entry.Value + ", "; // Entry
            BuildSqlFile += textBox33.Text + ", "; // Type
            if (textBox3.Text == "") BuildSqlFile += "0, "; else
            BuildSqlFile += textBox3.Text + ", "; // displayId
            BuildSqlFile += "'" + textBox2.Text + "', "; // name
            BuildSqlFile += "'" + comboBox1.Text + "', "; // IconName
            BuildSqlFile += "'" + textBox4.Text + "', '"; // castBarCaption
            BuildSqlFile += textBox28.Text + "', ";// unk1
            if (textBox34.Text == "") BuildSqlFile += "1, "; else
            BuildSqlFile += textBox34.Text + ", "; // size
            if (textBox26.Text == "") BuildSqlFile += "0, "; else
            BuildSqlFile += textBox26.Text + ", "; // Data0
            if (textBox7.Text == "") BuildSqlFile += "0, "; else
            BuildSqlFile += textBox7.Text + ", "; // Data1
            if (textBox18.Text == "") BuildSqlFile += "0, "; else
            BuildSqlFile += textBox18.Text + ", "; // Data2
            if (textBox29.Text == "") BuildSqlFile += "0, "; else
            BuildSqlFile += textBox29.Text + ", "; // Data3
            if (textBox5.Text == "") BuildSqlFile += "0, "; else
            BuildSqlFile += textBox5.Text + ", "; // Data4
            if (textBox20.Text == "") BuildSqlFile += "0, "; else
            BuildSqlFile += textBox20.Text + ", "; // Data5
            if (textBox27.Text == "") BuildSqlFile += "0, "; else
            BuildSqlFile += textBox27.Text + ", "; // Data6
            if (textBox6.Text == "") BuildSqlFile += "0, "; else
            BuildSqlFile += textBox6.Text + ", "; // Data7
            if (textBox19.Text == "") BuildSqlFile += "0, "; else
            BuildSqlFile += textBox19.Text + ", "; // Data8
            if (textBox25.Text == "") BuildSqlFile += "0, "; else
            BuildSqlFile += textBox25.Text + ", "; // Data9
            if (textBox8.Text == "") BuildSqlFile += "0, "; else
            BuildSqlFile += textBox8.Text + ", "; // Data10
            if (textBox17.Text == "") BuildSqlFile += "0, "; else
            BuildSqlFile += textBox17.Text + ", "; // Data11
            if (textBox22.Text == "") BuildSqlFile += "0, "; else
            BuildSqlFile += textBox22.Text + ", "; // Data12
            if (textBox10.Text == "") BuildSqlFile += "0, "; else
            BuildSqlFile += textBox10.Text + ", "; // Data13
            if (textBox14.Text == "") BuildSqlFile += "0, "; else
            BuildSqlFile += textBox14.Text + ", "; // Data14
            if (textBox24.Text == "") BuildSqlFile += "0, "; else
            BuildSqlFile += textBox24.Text + ", "; // Data15
            if (textBox12.Text == "") BuildSqlFile += "0, "; else
            BuildSqlFile += textBox12.Text + ", "; // Data16
            if (textBox16.Text == "") BuildSqlFile += "0, "; else
            BuildSqlFile += textBox16.Text + ", "; // Data17
            if (textBox23.Text == "") BuildSqlFile += "0, "; else
            BuildSqlFile += textBox23.Text + ", "; // Data18
            if (textBox11.Text == "") BuildSqlFile += "0, "; else
            BuildSqlFile += textBox11.Text + ", "; // Data19
            if (textBox15.Text == "") BuildSqlFile += "0, "; else
            BuildSqlFile += textBox15.Text + ", "; // Data20
            if (textBox21.Text == "") BuildSqlFile += "0, "; else
            BuildSqlFile += textBox21.Text + ", "; // Data21
            if (textBox9.Text == "") BuildSqlFile += "0, "; else
            BuildSqlFile += textBox9.Text + ", "; // Data22
            if (textBox13.Text == "") BuildSqlFile += "0, "; else
            BuildSqlFile += textBox13.Text + ", "; // Data23
            BuildSqlFile += "'" + comboBox3.Text + "', "; // AiName
            BuildSqlFile += "'" + textBox30.Text + "', "; // ScriptName
            if (textBox32.Text == "") BuildSqlFile += "0, "; else
            BuildSqlFile += textBox32.Text; // VerifiedBuild
            BuildSqlFile += "); \n"; // \n = new line

            stringSqlShare = BuildSqlFile;
        }

        public bool IsProcessOpen(string name = "mysqld")
        {
            foreach (Process clsProcess in Process.GetProcesses())
            {
                if (clsProcess.ProcessName.Contains(name))
                {
                    label_mysql_status2.Text = "Connected!";
                    label_mysql_status2.ForeColor = Color.LawnGreen;
                    button_maxPlus1fromDB.Visible = true;
                    button_execute_query.Visible = true;
                    btn_DeleteQuery.Enabled = true;

                    // Start with mysql
                    label_mysql_status2.Visible = true;
                    label85.Visible = true;
                    timer1.Enabled = true;
                    return true;
                }
            }

            label_mysql_status2.Text = "Connection Lost - MySQL is not running";
            label_mysql_status2.ForeColor = Color.Red;
            button_maxPlus1fromDB.Visible = false;
            button_execute_query.Visible = false;
            btn_DeleteQuery.Enabled = false;
            return false;
        }

        private bool _mouseDown;
        private Point lastLocation;

        Form_MainMenu mainmenu = new Form_MainMenu();

        private void SelectMaxPlusOne()
        {
            GetMySqlConnection();

            string insertQuery = "SELECT max(entry)+1 FROM " + form_MM.GetWorldDB() + ".gameobject_template;";
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


            if (form_MM.CB_NoMySQL.Checked)
            {
                label_mysql_status2.Visible = false;
                label85.Visible = false;
                timer1.Enabled = false;
                button_maxPlus1fromDB.Visible = false;
                button_execute_query.Visible = false;
            }
            else
                SelectMaxPlusOne();
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            textBox33.Text = comboBox2.Text;

            if (comboBox2.Text == "GAMEOBJECT_TYPE_DOOR")
            {
                textBox33.Text = "0";
                RTB_Notes.Text = "data0: startOpen(Boolean flag)" + Environment.NewLine +
                                 "data1: open(LockId from Lock.dbc)" + Environment.NewLine +
                                 "data2: autoClose(Time in milliseconds)" + Environment.NewLine +
                                 "data3: noDamageImmune(Boolean flag)" + Environment.NewLine +
                                 "data4: openTextID(Unknown Text ID)" + Environment.NewLine +
                                 "data5: closeTextID(Unknown Text ID)" + Environment.NewLine +
                                 "data6: Ignored by pathfinding" + Environment.NewLine +
                                 "data7: Conditionid1" + Environment.NewLine +
                                 "data8: Door is opaque" + Environment.NewLine +
                                 "data9: Gigantic AOI" + Environment.NewLine +
                                 "data10: Infinite AOI";
            }
            else if (comboBox2.Text == "GAMEOBJECT_TYPE_BUTTON")
            {
                textBox33.Text = "1";
                RTB_Notes.Text = "data0: startOpen (State)" + Environment.NewLine +
                                 "data1: open(LockId from Lock.dbc)" + Environment.NewLine +
                                 "data2: autoClose(long unknown flag)" + Environment.NewLine +
                                 "data3: linkedTrap(gameobject_template.entry(Spawned GO type 6))" + Environment.NewLine +
                                 "data4: noDamageImmune(Boolean flag)" + Environment.NewLine +
                                 "data5: large ? (Boolean flag)" + Environment.NewLine +
                                 "data6: openTextID(Unknown Text ID)" + Environment.NewLine +
                                 "data7: closeTextID(Unknown Text ID)" + Environment.NewLine +
                                 "data8: losOK(Boolean flag)" + Environment.NewLine +
                                 "data9: Conditionid1";
            }
            else if (comboBox2.Text == "GAMEOBJECT_TYPE_QUESTGIVER")
            {
                textBox33.Text = "2";
                RTB_Notes.Text = "data0: open (LockId from Lock.dbc)" + Environment.NewLine +
                                 "data1: questList (unknown ID)" + Environment.NewLine +
                                 "data2: pageMaterial (PageTextMaterial.dbc)" + Environment.NewLine +
                                 "data3: gossipID (gossip_menu_option.menu_id)" + Environment.NewLine +
                                 "data4: customAnim (unknown value from 1 to 4)" + Environment.NewLine +
                                 "data5: noDamageImmune (Boolean flag)" + Environment.NewLine +
                                 "data6: openTextID (broadcast_text ID)" + Environment.NewLine +
                                 "data7: losOK (Boolean flag)" + Environment.NewLine +
                                 "data8: allowMounted (Boolean flag)" + Environment.NewLine +
                                 "data9: large? (Boolean flag)" + Environment.NewLine +
                                 "data10: Conditionid1" + Environment.NewLine +
                                 "data11: Never usable while mounted";
            }
            else if (comboBox2.Text == "GAMEOBJECT_TYPE_CHEST")
            {
                textBox33.Text = "3";
                RTB_Notes.Text = "data0: open (LockId from Lock.dbc)" + Environment.NewLine +
                                 "data1: chestLoot (gameobject_loot_template.entry) WDB-fields" + Environment.NewLine +
                                 "data2: chestRestockTime (time in seconds)" + Environment.NewLine +
                                 "data3: consumable (State: Boolean flag)" + Environment.NewLine +
                                 "data4: minRestock (Min successful loot attempts for Mining, Herbalism etc)" + Environment.NewLine +
                                 "data5: maxRestock (Max successful loot attempts for Mining, Herbalism etc)" + Environment.NewLine +
                                 "data6: lootedEvent (unknown ID)" + Environment.NewLine +
                                 "data7: linkedTrap (gameobject_template.entry (Spawned GO type 6))" + Environment.NewLine +
                                 "data8: questID (quest_template.id of completed quest)" + Environment.NewLine +
                                 "data9: level (minimal level required to open this gameobject)" + Environment.NewLine +
                                 "data10: losOK (Boolean flag)" + Environment.NewLine +
                                 "data11: leaveLoot (Boolean flag)" + Environment.NewLine +
                                 "data12: notInCombat (Boolean flag)" + Environment.NewLine +
                                 "data13: log loot (Boolean flag)" + Environment.NewLine +
                                 "data14: openTextID (Unknown ID)" + Environment.NewLine +
                                 "data15: use group loot rules (Boolean flag)" + Environment.NewLine +
                                 "data16: floating tooltip" + Environment.NewLine +
                                 "data17: conditionid1" + Environment.NewLine +
                                 "data18: xplevel" + Environment.NewLine +
                                 "data19: xpDifficulty" + Environment.NewLine +
                                 "data20: lootlevel" + Environment.NewLine +
                                 "data21: Group Xp" + Environment.NewLine +
                                 "data22: Damage Immune" + Environment.NewLine +
                                 "data23: trivialSkillLow";
            }
            else if (comboBox2.Text == "GAMEOBJECT_TYPE_BINDER")
            {
                textBox33.Text = "4";
                RTB_Notes.Text = "Object type not used";
            }
            else if (comboBox2.Text == "GAMEOBJECT_TYPE_GENERIC")
            {
                textBox33.Text = "5";
                RTB_Notes.Text = "data0: floatingTooltip(Boolean flag)" + Environment.NewLine +
                                 "data1: highlight (Boolean flag)" + Environment.NewLine +
                                 "data2: serverOnly? (Always 0)" + Environment.NewLine +
                                 "data3: large? (Boolean flag)" + Environment.NewLine +
                                 "data4: floatOnWater (Boolean flag)" + Environment.NewLine +
                                 "data5: questID (Required active quest_template.id to work)" + Environment.NewLine +
                                 "data6: conditionID1" + Environment.NewLine +
                                 "data7: LargeAOI" + Environment.NewLine +
                                 "data8: UseGarrisonOwnerGuildColors";
            }
            else if (comboBox2.Text == "GAMEOBJECT_TYPE_TRAP")
            {
                textBox33.Text = "6";
                RTB_Notes.Text = "data0: open (LockId from Lock.dbc )" + Environment.NewLine +
                                 "data1: level (npc equivalent level for casted spell)" + Environment.NewLine +
                                 "data2: diameter (so radius * 2)" + Environment.NewLine +
                                 "data3: spell (Spell Id from Spell.dbc)" + Environment.NewLine +
                                 "data4: type (0 trap with no despawn after cast. 1 trap despawns after cast. 2 bomb casts on spawn)" + Environment.NewLine +
                                 "data5: cooldown (time in seconds)" + Environment.NewLine +
                                 "data6:  ? (unknown flag)" + Environment.NewLine +
                                 "data7: startDelay? (time in seconds)" + Environment.NewLine +
                                 "data8: serverOnly? (always 0)" + Environment.NewLine +
                                 "data9: stealthed (Boolean flag)" + Environment.NewLine +
                                 "data10: large? (Boolean flag)" + Environment.NewLine +
                                 "data11: stealthAffected (Boolean flag)" + Environment.NewLine +
                                 "data12: openTextID (Unknown ID)" + Environment.NewLine +
                                 "data13: closeTextID" + Environment.NewLine +
                                 "data14: IgnoreTotems" + Environment.NewLine +
                                 "data15: conditionID1" + Environment.NewLine +
                                 "data16: playerCast" + Environment.NewLine +
                                 "data17: SummonerTriggered" + Environment.NewLine +
                                 "data18: requireLOS";
            }
            else if (comboBox2.Text == "GAMEOBJECT_TYPE_CHAIR")
            {
                textBox33.Text = "7";
                RTB_Notes.Text = "data0: chairslots(number of players that can sit down on it)" + Environment.NewLine +
                                 "data1: chairorientation? (number of usable side?)" + Environment.NewLine +
                                 "data2: onlyCreatorUse" + Environment.NewLine +
                                 "data3: triggeredEvent" + Environment.NewLine +
                                 "data4: conditionID1";
            }
            else if (comboBox2.Text == "GAMEOBJECT_TYPE_SPELL_FOCUS")
            {
                textBox33.Text = "8";
                RTB_Notes.Text = "data0: spellFocusType (from SpellFocusObject.dbc; value also appears as RequiresSpellFocus in Spell.dbc)" + Environment.NewLine +
                                 "data1: diameter (so radius*2)" + Environment.NewLine +
                                 "data2: linkedTrap (gameobject_template.entry (Spawned GO type 6))" + Environment.NewLine +
                                 "data3: serverOnly? (Always 0)" + Environment.NewLine +
                                 "data4: questID (Required active quest_template.id to work)" + Environment.NewLine +
                                 "data5: large? (Boolean flag)" + Environment.NewLine +
                                 "data6: floatingTooltip (Boolean flag)" + Environment.NewLine +
                                 "data7: floatOnWater" + Environment.NewLine +
                                 "data8: conditionID1";
            }
            else if (comboBox2.Text == "GAMEOBJECT_TYPE_TEXT")
            {
                textBox33.Text = "9";
                RTB_Notes.Text = "data0: pageID (page_text.entry)" + Environment.NewLine +
                                 "data1: language (from  Languages.dbc)" + Environment.NewLine +
                                 "data2: pageMaterial (PageTextMaterial.dbc)" + Environment.NewLine +
                                 "data3: allowMounted" + Environment.NewLine +
                                 "data4: conditionID1" + Environment.NewLine +
                                 "data5: NeverUsableWhileMounted";
            }
            else if (comboBox2.Text == "GAMEOBJECT_TYPE_GOOBER")
            {
                textBox33.Text = "10";
                RTB_Notes.Text = "data0: open (LockId from Lock.dbc)" + Environment.NewLine +
                                 "data1: questID (Required active quest_template.id to work)" + Environment.NewLine +
                                 "data2: eventID (event_script id)" + Environment.NewLine +
                                 "data3:  Time in ms before the initial state is restored" + Environment.NewLine +
                                 "data4: customAnim (unknown)" + Environment.NewLine +
                                 "data5: consumable (Boolean flag controling if gameobject will despawn or not)" + Environment.NewLine +
                                 "data6: cooldown (time is seconds)" + Environment.NewLine +
                                 "data7: pageID (page_text.entry)" + Environment.NewLine +
                                 "data8: language (from Languages.dbc)" + Environment.NewLine +
                                 "data9: pageMaterial (PageTextMaterial.dbc)" + Environment.NewLine +
                                 "data10: spell (Spell Id from Spell.dbc)" + Environment.NewLine +
                                 "data11: noDamageImmune (Boolean flag)" + Environment.NewLine +
                                 "data12: linkedTrap (gameobject_template.entry (Spawned GO type 6))" + Environment.NewLine +
                                 "data13: large? (Boolean flag)" + Environment.NewLine +
                                 "data14: openTextID (Unknown ID)" + Environment.NewLine +
                                 "data15: closeTextID (Unknown ID)" + Environment.NewLine +
                                 "data16: losOK (Boolean flag) (somewhat related to battlegrounds)" + Environment.NewLine +
                                 "data19: gossipID - casts the spell when used" + Environment.NewLine +
                                 "data20: AllowMultiInteract" + Environment.NewLine +
                                 "data21: floatOnWater" + Environment.NewLine +
                                 "data22: conditionID1" + Environment.NewLine +
                                 "data23: playerCast";
            }
            else if (comboBox2.Text == "GAMEOBJECT_TYPE_TRANSPORT")
            {
                textBox33.Text = "11";
                RTB_Notes.Text = "data0: Timeto2ndfloor" + Environment.NewLine +
                                 "data1: startOpen" + Environment.NewLine +
                                 "data2: autoClose" + Environment.NewLine +
                                 "data3: Reached1stfloor" + Environment.NewLine +
                                 "data4: Reached2ndfloor" + Environment.NewLine +
                                 "data5: SpawnMap" + Environment.NewLine +
                                 "data6: Timeto3rdfloor" + Environment.NewLine +
                                 "data7: Reached3rdfloor" + Environment.NewLine +
                                 "data8: Timeto4rdfloor" + Environment.NewLine +
                                 "data9: Reached4rdfloor" + Environment.NewLine +
                                 "data10: Timeto5rdfloor" + Environment.NewLine +
                                 "data11: Reached5rdfloor" + Environment.NewLine +
                                 "data12: Timeto6rdfloor" + Environment.NewLine +
                                 "data13: Reached6rdfloor" + Environment.NewLine +
                                 "data14: Timeto7rdfloor" + Environment.NewLine +
                                 "data15: Reached7rdfloor" + Environment.NewLine +
                                 "data16: Timeto8rdfloor" + Environment.NewLine +
                                 "data17: Reached8rdfloor" + Environment.NewLine +
                                 "data18: Timeto9rdfloor" + Environment.NewLine +
                                 "data19: Reached9rdfloor" + Environment.NewLine +
                                 "data20: Timeto10rdfloor" + Environment.NewLine +
                                 "data21: Reached10rdfloor" + Environment.NewLine +
                                 "data22: onlychargeheightcheck" + Environment.NewLine +
                                 "data23: onlychargetimecheck";
            }
            else if (comboBox2.Text == "GAMEOBJECT_TYPE_AREADAMAGE")
            {
                textBox33.Text = "12";
                RTB_Notes.Text = "data0: open" + Environment.NewLine +
                                 "data1: radius" + Environment.NewLine +
                                 "data2: damageMin" + Environment.NewLine +
                                 "data3: damageMax" + Environment.NewLine +
                                 "data4: damageSchool" + Environment.NewLine +
                                 "data5: autoClose" + Environment.NewLine +
                                 "data6: openTextID" + Environment.NewLine +
                                 "data7: closeTextID";
            }
            else if (comboBox2.Text == "GAMEOBJECT_TYPE_CAMERA")
            {
                textBox33.Text = "13";
                RTB_Notes.Text = "data0: open (LockId from Lock.dbc)" + Environment.NewLine +
                                 "data1: camera (Cinematic entry from CinematicCamera.dbc)" + Environment.NewLine +
                                 "data2: eventID" + Environment.NewLine +
                                 "data3: openTextID" + Environment.NewLine +
                                 "data4: conditionID1";
            }
            else if (comboBox2.Text == "GAMEOBJECT_TYPE_MAP_OBJECT")
            {
                textBox33.Text = "14";
                RTB_Notes.Text = "No data used, all are always 0";
            }
            else if (comboBox2.Text == "GAMEOBJECT_TYPE_MO_TRANSPORT")
            {
                textBox33.Text = "15";
                RTB_Notes.Text = "data0: taxiPathID (Id from TaxiPath.dbc)" + Environment.NewLine +
                                 "data1: moveSpeed" + Environment.NewLine +
                                 "data2: accelRate" + Environment.NewLine +
                                 "data3: startEventID" + Environment.NewLine +
                                 "data4: stopEventID" + Environment.NewLine +
                                 "data5: transportPhysics" + Environment.NewLine +
                                 "data6: SpawnMap" + Environment.NewLine +
                                 "data7: worldState1" + Environment.NewLine +
                                 "data8: allowstopping" + Environment.NewLine +
                                 "data9: InitStopped" + Environment.NewLine +
                                 "data10: TrueInfiniteAOI";
            }
            else if (comboBox2.Text == "GAMEOBJECT_TYPE_DUEL_ARBITER")
            {
                textBox33.Text = "16";
                RTB_Notes.Text = "Only one Gameobject with this type (21680) and no data";
            }
            else if (comboBox2.Text == "GAMEOBJECT_TYPE_FISHINGNODE")
            {
                textBox33.Text = "17";
                RTB_Notes.Text = "Only one Gameobject with this type (35591) and no data";
            }
            else if (comboBox2.Text == "GAMEOBJECT_TYPE_RITUAL")
            {
                textBox33.Text = "18";
                RTB_Notes.Text = "data0: casters?" + Environment.NewLine +
                                 "data1: spell (Spell Id from Spell.dbc)" + Environment.NewLine +
                                 "data2: animSpell (Spell Id from Spell.dbc)" + Environment.NewLine +
                                 "data3: ritualPersistent (Boolean flag)" + Environment.NewLine +
                                 "data4: casterTargetSpell (Spell Id from Spell.dbc)" + Environment.NewLine +
                                 "data5: casterTargetSpellTargets (Boolean flag)" + Environment.NewLine +
                                 "data6: castersGrouped (Boolean flag)" + Environment.NewLine +
                                 "data7: ritualNoTargetCheck" + Environment.NewLine +
                                 "data8: conditionID1";
            }
            else if (comboBox2.Text == "GAMEOBJECT_TYPE_MAILBOX")
            {
                textBox33.Text = "19";
                RTB_Notes.Text = "No data used, all are always 0";
            }
            else if (comboBox2.Text == "GAMEOBJECT_TYPE_AUCTIONHOUSE")
            {
                textBox33.Text = "20";
                RTB_Notes.Text = "data0: actionHouseID (From AuctionHouse.dbc ?)";
            }
            else if (comboBox2.Text == "GAMEOBJECT_TYPE_GUARDPOST")
            {
                textBox33.Text = "21";
                RTB_Notes.Text = "data0: CreatureID" + Environment.NewLine +
                                 "data1: unk";
            }
            else if (comboBox2.Text == "GAMEOBJECT_TYPE_SPELLCASTER")
            {
                textBox33.Text = "22";
                RTB_Notes.Text = "data0: spell (Spell Id from Spell.dbc)" + Environment.NewLine +
                                 "data1: charges" + Environment.NewLine +
                                 "data2: partyOnly (Boolean flag, need to be in group to use it)" + Environment.NewLine +
                                 "data3: allowMounted" + Environment.NewLine +
                                 "data4: GiganticAOI" + Environment.NewLine +
                                 "data5: conditionID1" + Environment.NewLine +
                                 "data6: playerCast" + Environment.NewLine +
                                 "data7: NeverUsableWhileMounted";
            }
            else if (comboBox2.Text == "GAMEOBJECT_TYPE_MEETINGSTONE")
            {
                textBox33.Text = "23";
                RTB_Notes.Text = "data0: minLevel" + Environment.NewLine +
                                 "data1: maxLevel" + Environment.NewLine +
                                 "data2: areaID (From AreaTable.dbc)";
            }
            else if (comboBox2.Text == "GAMEOBJECT_TYPE_FLAGSTAND")
            {
                textBox33.Text = "24";
                RTB_Notes.Text = "data0: open (LockId from Lock.dbc)" + Environment.NewLine +
                                 "data1: pickupSpell (Spell Id from Spell.dbc)" + Environment.NewLine +
                                 "data2: radius (distance)" + Environment.NewLine +
                                 "data3: returnAura (Spell Id from Spell.dbc)" + Environment.NewLine +
                                 "data4: returnSpell (Spell Id from Spell.dbc)" + Environment.NewLine +
                                 "data5: noDamageImmune (Boolean flag)" + Environment.NewLine +
                                 "data6: openTextID" + Environment.NewLine +
                                 "data7: losOK (Boolean flag)" + Environment.NewLine +
                                 "data8: conditionID1" + Environment.NewLine +
                                 "data9: playerCast" + Environment.NewLine +
                                 "data10: GiganticAOI" + Environment.NewLine +
                                 "data11: InfiniteAOI" + Environment.NewLine +
                                 "data12: cooldown";
            }
            else if (comboBox2.Text == "GAMEOBJECT_TYPE_FISHINGHOLE")
            {
                textBox33.Text = "25";
                RTB_Notes.Text = "data0: radius (distance)" + Environment.NewLine +
                                 "data1: chestLoot (gameobject_loot_template.entry)" + Environment.NewLine +
                                 "data2: minRestock" + Environment.NewLine +
                                 "data3: maxRestock" + Environment.NewLine +
                                 "data4: open";
            }
            else if (comboBox2.Text == "GAMEOBJECT_TYPE_FLAGDROP")
            {
                textBox33.Text = "26";
                RTB_Notes.Text = "data0: open (LockId from Lock.dbc)" + Environment.NewLine +
                                 "data1: eventID (Unknown Event ID)" + Environment.NewLine +
                                 "data2: pickupSpell (Spell Id from Spell.dbc)" + Environment.NewLine +
                                 "data3: noDamageImmune (Boolean flag)" + Environment.NewLine +
                                 "data4: openTextID" + Environment.NewLine +
                                 "data5: playerCast" + Environment.NewLine +
                                 "data6: ExpireDuration" + Environment.NewLine +
                                 "data7: GiganticAOI" + Environment.NewLine +
                                 "data8: InfiniteAOI" + Environment.NewLine +
                                 "data9: cooldown";
            }
            else if (comboBox2.Text == "GAMEOBJECT_TYPE_MINI_GAME")
            {
                textBox33.Text = "27";
                RTB_Notes.Text = "Object type not used. Reused in core for CUSTOM_TELEPORT" + Environment.NewLine +
                                 "data0: areatrigger_teleport.id";
            }
            else if (comboBox2.Text == "GAMEOBJECT_TYPE_LOTTERY_KIOSK")
            {
                textBox33.Text = "28";
                RTB_Notes.Text = "Object type not used";
            }
            else if (comboBox2.Text == "GAMEOBJECT_TYPE_CAPTURE_POINT")
            {
                textBox33.Text = "29";
                RTB_Notes.Text = "data0: radius (Distance)" + Environment.NewLine +
                                 "data1: spell (Unknown ID, not a spell id in dbc file, maybe server only side spell)" + Environment.NewLine +
                                 "data2: worldState1" + Environment.NewLine +
                                 "data3: worldstate2" + Environment.NewLine +
                                 "data4: winEventID1 (Unknown Event ID)" + Environment.NewLine +
                                 "data5: winEventID2 (Unknown Event ID)" + Environment.NewLine +
                                 "data6: contestedEventID1 (Unknown Event ID)" + Environment.NewLine +
                                 "data7: contestedEventID2 (Unknown Event ID)" + Environment.NewLine +
                                 "data8: progressEventID1 (Unknown Event ID)" + Environment.NewLine +
                                 "data9: progressEventID2 (Unknown Event ID)" + Environment.NewLine +
                                 "data10: neutralEventID1 (Unknown Event ID)" + Environment.NewLine +
                                 "data11: neutralEventID2 (Unknown Event ID)" + Environment.NewLine +
                                 "data12: neutralPercent" + Environment.NewLine +
                                 "data13: worldstate3" + Environment.NewLine +
                                 "data14: minSuperiority" + Environment.NewLine +
                                 "data15: maxSuperiority" + Environment.NewLine +
                                 "data16: minTime (in seconds)" + Environment.NewLine +
                                 "data17: maxTime (in seconds)" + Environment.NewLine +
                                 "data18: large? (Boolean flag)" + Environment.NewLine +
                                 "data19: highlight" + Environment.NewLine +
                                 "data20: startingValue" + Environment.NewLine +
                                 "data21: unidirectional" + Environment.NewLine +
                                 "data22: killbonustime" + Environment.NewLine +
                                 "data23: speedWorldState1";
            }
            else if (comboBox2.Text == "GAMEOBJECT_TYPE_AURA_GENERATOR")
            {
                textBox33.Text = "30";
                RTB_Notes.Text = "data0: startOpen (Boolean flag)" + Environment.NewLine +
                                 "data1: radius (Distance)" + Environment.NewLine +
                                 "data2: auraID1 (Spell Id from Spell.dbc)" + Environment.NewLine +
                                 "data3: conditionID1 (Unknown ID)" + Environment.NewLine +
                                 "data4: auraID2" + Environment.NewLine +
                                 "data5: conditionID2" + Environment.NewLine +
                                 "data6: serverOnly";
            }
            else if (comboBox2.Text == "GAMEOBJECT_TYPE_DUNGEON_DIFFICULTY")
            {
                textBox33.Text = "31";
                RTB_Notes.Text = "data0: mapID (From Map.dbc)" + Environment.NewLine +
                                 "data1: difficulty" + Environment.NewLine +
                                 "data2: DifficultyHeroic" + Environment.NewLine +
                                 "data3: DifficultyEpic" + Environment.NewLine +
                                 "data4: DifficultyLegendary" + Environment.NewLine +
                                 "data5: HeroicAttachment" + Environment.NewLine +
                                 "data6: ChallengeAttachment" + Environment.NewLine +
                                 "data7: DifficultyAnimations" + Environment.NewLine +
                                 "data8: LargeAOI" + Environment.NewLine +
                                 "data9: GiganticAOI" + Environment.NewLine +
                                 "data10: Legacy" + Environment.NewLine + Environment.NewLine +
                                 "-----------------------------------------------------------" + Environment.NewLine +
                                 "Value   |   Comment" + Environment.NewLine +
                                 "-----------------------------------------------------------" + Environment.NewLine +
                                 "0           |   5 man normal, 10 man normal" + Environment.NewLine +
                                 "1           |   5 man heroic, 25 normal" + Environment.NewLine +
                                 "2           |   10 man heroic" + Environment.NewLine +
                                 "3           |   25 man heroic"
                                 ;
            }
            else if (comboBox2.Text == "GAMEOBJECT_TYPE_BARBER_CHAIR")
            {
                textBox33.Text = "32";
                RTB_Notes.Text = "data0: chairheight" + Environment.NewLine +
                                 "data1: HeightOffset" + Environment.NewLine +
                                 "data2: SitAnimKit";
            }
            else if (comboBox2.Text == "GAMEOBJECT_TYPE_DESTRUCTIBLE_BUILDING")
            {
                textBox33.Text = "33";
                RTB_Notes.Text = "data0: intactNumHits" + Environment.NewLine +
                                 "data1: creditProxyCreature" + Environment.NewLine +
                                 "data2: state1Name" + Environment.NewLine +
                                 "data3: intactEvent" + Environment.NewLine +
                                 "data4: damagedDisplayId" + Environment.NewLine +
                                 "data5: damagedNumHits" + Environment.NewLine +
                                 "data6: empty3" + Environment.NewLine +
                                 "data7: empty4" + Environment.NewLine +
                                 "data8: empty5" + Environment.NewLine +
                                 "data9: damagedEvent" + Environment.NewLine +
                                 "data10: destroyedDisplayId" + Environment.NewLine +
                                 "data11: empty7" + Environment.NewLine +
                                 "data12: empty8" + Environment.NewLine +
                                 "data13: empty9" + Environment.NewLine +
                                 "data14: destroyedEvent" + Environment.NewLine +
                                 "data15: empty10" + Environment.NewLine +
                                 "data16: debuildingTimeSecs" + Environment.NewLine +
                                 "data17: empty11" + Environment.NewLine +
                                 "data18: destructibleData" + Environment.NewLine +
                                 "data19: rebuildingEvent" + Environment.NewLine +
                                 "data20: empty12" + Environment.NewLine +
                                 "data21: empty13" + Environment.NewLine +
                                 "data22: damageEvent" + Environment.NewLine +
                                 "data23: empty14";
            }
            else if (comboBox2.Text == "GAMEOBJECT_TYPE_GUILD_BANK")
            {
                textBox33.Text = "34";
                RTB_Notes.Text = "No data data used, all are always 0";
            }
            else if (comboBox2.Text == "GAMEOBJECT_TYPE_TRAPDOOR")
            {
                textBox33.Text = "35";
                RTB_Notes.Text = "data0: whenToPause" + Environment.NewLine +
                                 "data1: startOpen" + Environment.NewLine +
                                 "data2: autoClose" + Environment.NewLine +
                                 "data3: BlocksPathsDown" + Environment.NewLine +
                                 "data4: PathBlockerBump";
            }
        }

        private void label35_Click(object sender, EventArgs e)
        {
            Process.Start("https://trinitycore.atlassian.net/wiki/display/tc/gameobject_template");
        }

        private void button_execute_query_Click(object sender, EventArgs e)
        {
            GenerateQuery();

            if (textBox2.Text == "")
            {
                MessageBox.Show("Game Object Name should not be empty", "Error");
                return;
            }
            if (NUD_Entry.Text == "0")
            {
                MessageBox.Show("Entry should not be 0", "Error");
                return;
            }
            if (NUD_Entry.Text == "")
            {
                MessageBox.Show("Entry should not be empty", "Error");
                return;
            }

            GetMySqlConnection();
            
            connection.Open();
            MySqlCommand command = new MySqlCommand(stringSqlShare, connection);

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
            SelectMaxPlusOne();
        }

        private void label80_MouseEnter(object sender, EventArgs e)
        {
            label80.BackColor = Color.Firebrick;
        }

        private void label80_MouseLeave(object sender, EventArgs e)
        {
            label80.BackColor = Color.FromArgb(58, 89, 114);
        }

        private void label81_MouseEnter(object sender, EventArgs e)
        {
            label81.BackColor = Color.Firebrick;
        }

        private void label81_MouseLeave(object sender, EventArgs e)
        {
            label81.BackColor = Color.FromArgb(58, 89, 114);
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
            IsProcessOpen(); 
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

        // Save *.sql file
        private void label83_Click(object sender, EventArgs e)
        {
            GenerateQuery();

            if (NUD_Entry.Text == "0")
            {
                MessageBox.Show("Entry should not be 0", "Error");
                return;
            }
            if (NUD_Entry.Text == "")
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
                sfd.FileName = "GameObject[" + NUD_Entry.Value + "]" + textBox2.Text;

                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    File.WriteAllText(sfd.FileName, stringSqlShare);

                    timer7.Start();
                }
            }
        }
        
        // COPY TO CLIPBOARD label
        private void label86_Click(object sender, EventArgs e)
        {
            GenerateQuery();

            if (NUD_Entry.Text == "0")
            {
                MessageBox.Show("Entry should not be 0", "Error");
                return;
            }
            if (NUD_Entry.Text == "")
            {
                MessageBox.Show("Entry should not be empty", "Error");
                return;
            }
            if (textBox2.Text == "")
            {
                MessageBox.Show("Name should not be empty", "Error");
                return;
            }
            Clipboard.SetText(stringSqlShare);

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
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
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
        }

        private void label78_MouseLeave(object sender, EventArgs e)
        {
            label78.BackColor = Color.FromArgb(58, 89, 114);
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
            btn_DeleteQuery.Visible = false;
            if (comboBox11.SelectedIndex == 0) textBox105.Text = "INSERT";
            else if (comboBox11.SelectedIndex == 1) textBox105.Text = "REPLACE";
            else if (comboBox11.SelectedIndex == 2) // Delete 
            {
                if (form_MM.CB_NoMySQL.Checked || label_mysql_status2.Text == "Connection Lost - MySQL is not running")
                {
                    btn_DeleteQuery.Enabled = false;
                }

                btn_DeleteQuery.Visible = true;
            }
        }

        private void label92_MouseEnter(object sender, EventArgs e)
        {
            // MessageBox.Show("A file labled GameObjects.sql will be created in the same directory as the SpawnCreator vX.X executable. \nSo you can save multiple data rows in a single .sql file.", "SpawnCreator", MessageBoxButtons.OK, MessageBoxIcon.Information);
            toolTip1.SetToolTip(label92, "A file labeled GameObjects.sql will be created in the same directory as the SpawnCreator vX.X executable. \nSo you can save multiple data rows in a single .sql file.");
            toolTip1.AutoPopDelay = 10000; // 10 seconds
        }

        private void button_SaveInTheSameFile_Click(object sender, EventArgs e)
        {
            GenerateQuery();

            if (NUD_Entry.Text == "0")
            {
                MessageBox.Show("Entry should not be 0", "Error");
                return;
            }
            if (NUD_Entry.Text == "")
            {
                MessageBox.Show("Entry should not be empty", "Error");
                return;
            }
            if (textBox2.Text == "")
            {
                MessageBox.Show("Name should not be empty", "Error");
                return;
            }

            using (var writer = File.AppendText("GameObjects.sql"))
            {
                writer.Write(stringSqlShare);
                button_SaveInTheSameFile.Text = "Saved!";
                button_SaveInTheSameFile.TextAlign = ContentAlignment.MiddleCenter;
            }
        }

        private void button_SaveInTheSameFile_MouseEnter(object sender, EventArgs e)
        {
            button_SaveInTheSameFile.BackColor = Color.Firebrick;
        }

        private void button_SaveInTheSameFile_MouseLeave(object sender, EventArgs e)
        {
            button_SaveInTheSameFile.BackColor = Color.FromArgb(58, 89, 114);
        }

        private void comboBox3_MouseEnter(object sender, EventArgs e)
        {
            toolTip1.SetToolTip(comboBox3, "This field is overridden by ScriptName field if both are set. \nOnly 'SmartGameObjectAI' can be used.");
            toolTip1.AutoPopDelay = 8000;
        }

        private void ALL_textBoxes_MouseEnter(object sender, EventArgs e)
        {
            button_SaveInTheSameFile.Text = "Save in the same file";
            button_SaveInTheSameFile.TextAlign = ContentAlignment.MiddleRight;
        }

        private void NUD_Entry_ValueChanged(object sender, EventArgs e)
        {
            ALL_textBoxes_MouseEnter(sender, e);
        }

        private void All_ComboBoxes_MouseEnter(object sender, EventArgs e)
        {
            ALL_textBoxes_MouseEnter(sender, e);
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
                button_execute_query_Click(sender, e); // Execute Query if "F5" key is pressed
                return true;
            }

            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void btn_DeleteQuery_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Are you sure you want to delete GameObject " + NUD_Entry.Text + " ?", "SpawnCreator " + form_MM.version, MessageBoxButtons.YesNo);
            if (dr == DialogResult.No)
                return;

            else
            {
                GetMySqlConnection();

                string insertQuery = "DELETE FROM " + form_MM.GetWorldDB() + ".gameobject_template WHERE entry=" + NUD_Entry.Text + ";" ;

                connection.Open();
                MySqlCommand command = new MySqlCommand(insertQuery, connection);

                try
                {
                    command.ExecuteNonQuery();
                    MessageBox.Show("GameObject Deleted!", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                connection.Close();
            }


        }
    }
}
