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

        private readonly Form_MainMenu form_MM;
        public SmartScripts(Form_MainMenu form_MainMenu)
        {
            InitializeComponent();
            form_MM = form_MainMenu;
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
            BuildSQLFile = "INSERT INTO " + form_MM.GetWorldDB() + ".smart_scripts";
            BuildSQLFile += "(entryorguid, source_type, id, link, event_type, event_phase_mask, event_chance, event_flags, event_param1, event_param2, event_param3, ";
            BuildSQLFile += "event_param4, action_type, action_param1, action_param2, action_param3, action_param4, action_param5, action_param6, target_type, target_param1, target_param2, target_param3, target_x, target_y, target_z, target_o, comment) ";

            // values now
            BuildSQLFile += "VALUES \n";
            BuildSQLFile += "(";
            BuildSQLFile += textBox1.Text + ", "; // entryorguid
            BuildSQLFile += textBox2.Text + ", "; // source_type

            if (numericUpDown1.Text == "") BuildSQLFile += "0, "; else
            BuildSQLFile += numericUpDown1.Text + ", "; // id

            if (textBox4.Text == "") BuildSQLFile += "0, "; else
            BuildSQLFile += textBox4.Text + ", "; // link

            if (textBox5.Text == "") BuildSQLFile += "0, "; else
            BuildSQLFile += textBox5.Text + ", "; // event_type

            BuildSQLFile += event_phase_mask_st + ", "; // event_phase_mask

            if (numericUpDown2.Text == "") BuildSQLFile += "100, "; else
            BuildSQLFile += numericUpDown2.Text + ", "; // event_chance

            BuildSQLFile += event_flags_st + ", "; // event_flags

            if (textBox7.Text == "") BuildSQLFile += "0, "; else
            BuildSQLFile += textBox7.Text + ", "; // event_param1

            if (textBox8.Text == "") BuildSQLFile += "0, "; else
            BuildSQLFile += textBox8.Text + ", "; // event_param2

            if (textBox11.Text == "") BuildSQLFile += "0, "; else
            BuildSQLFile += textBox11.Text + ", "; // event_param3

            if (textBox15.Text == "") BuildSQLFile += "0, "; else
            BuildSQLFile += textBox15.Text + ", "; // event_param4

            if (textBox14.Text == "") BuildSQLFile += "0, "; else
            BuildSQLFile += textBox14.Text + ", "; // action_type

            if (textBox12.Text == "") BuildSQLFile += "0, "; else
            BuildSQLFile += textBox12.Text + ", "; // action_param1

            if (textBox13.Text == "") BuildSQLFile += "0, "; else
            BuildSQLFile += textBox13.Text + ", "; // action_param2

            if (textBox16.Text == "") BuildSQLFile += "0, "; else
            BuildSQLFile += textBox16.Text + ", "; // action_param3

            if (textBox20.Text == "") BuildSQLFile += "0, "; else
            BuildSQLFile += textBox20.Text + ", "; // action_param4

            if (textBox19.Text == "") BuildSQLFile += "0, "; else
            BuildSQLFile += textBox19.Text + ", "; // action_param5

            if (textBox17.Text == "") BuildSQLFile += "0, "; else
            BuildSQLFile += textBox17.Text + ", "; // action_param6

            if (textBox18.Text == "") BuildSQLFile += "0, "; else
            BuildSQLFile += textBox18.Text + ", "; // target_type

            if (textBox25.Text == "") BuildSQLFile += "0, "; else
            BuildSQLFile += textBox25.Text + ", "; // target_param1

            if (textBox26.Text == "") BuildSQLFile += "0, "; else
            BuildSQLFile += textBox26.Text + ", "; // target_param2

            if (textBox21.Text == "") BuildSQLFile += "0, "; else
            BuildSQLFile += textBox21.Text + ", "; // target_param3

            if (textBox24.Text == "") BuildSQLFile += "0, "; else
            BuildSQLFile += textBox24.Text + ", "; // target_x

            if (textBox23.Text == "") BuildSQLFile += "0, "; else
            BuildSQLFile += textBox23.Text + ", "; // target_y

            if (textBox22.Text == "") BuildSQLFile += "0, "; else
            BuildSQLFile += textBox22.Text + ", "; // target_z

            if (textBox28.Text == "") BuildSQLFile += "0, "; else
            BuildSQLFile += textBox28.Text + ", '"; // target_o

            BuildSQLFile += textBox27.Text + "'); \n"; // comment

            stringSQLShare = BuildSQLFile;
            stringEntryShare = textBox1.Text;
  
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
                 if (comboBox1.Text == "0 - SMART_SCRIPT_TYPE_CREATURE")         textBox2.Text = "0";
            else if (comboBox1.Text == "1 - SMART_SCRIPT_TYPE_GAMEOBJECT")       textBox2.Text = "1";
            else if (comboBox1.Text == "2 - SMART_SCRIPT_TYPE_AREATRIGGER")      textBox2.Text = "2";
            else if (comboBox1.Text == "9 - SMART_SCRIPT_TYPE_TIMED_ACTIONLIST") textBox2.Text = "9";
        }

        private void comboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {
            linkLabel6.Visible = false; // Map IDs
            linkLabel7.Visible = false; // Emote IDs
 
            if (comboBox4.Text == "0 - SMART_EVENT_UPDATE_IC")
            {
                textBox5.Text = "0";
                textBox3.Text = "event_param1: InitialMin" + Environment.NewLine +
                                "event_param2: InitialMax" + Environment.NewLine +
                                "event_param3: RepeatMin" + Environment.NewLine +
                                "event_param4: RepeatMax" + Environment.NewLine +
                                "Comment: In combat.";
            }
            else if (comboBox4.Text == "1 - SMART_EVENT_UPDATE_OOC")
            {
                textBox5.Text = "1";
                textBox3.Text = "event_param1: InitialMin" + Environment.NewLine +
                                "event_param2: InitialMax" + Environment.NewLine +
                                "event_param3: RepeatMin" + Environment.NewLine +
                                "event_param4: RepeatMax" + Environment.NewLine +
                                "Comment: Out of combat.";
            }
            else if (comboBox4.Text == "2 - SMART_EVENT_HEALT_PCT")
            {
                textBox5.Text = "2";
                textBox3.Text = "event_param1: HPMin%" + Environment.NewLine +
                                "event_param2: HPMax%" + Environment.NewLine +
                                "event_param3: RepeatMin" + Environment.NewLine +
                                "event_param4: RepeatMax" + Environment.NewLine +
                                "Comment: Health Percentage";
            }
            else if (comboBox4.Text == "3 - SMART_EVENT_MANA_PCT")
            {
                textBox5.Text = "3";
                textBox3.Text = "event_param1: ManaMin%" + Environment.NewLine +
                                "event_param2: ManaMax%" + Environment.NewLine +
                                "event_param3: RepeatMin" + Environment.NewLine +
                                "event_param4: RepeatMax" + Environment.NewLine +
                                "Comment: Mana Percentage";
            }
            else if (comboBox4.Text == "4 - SMART_EVENT_AGGRO")
            {
                textBox5.Text = "4";
                textBox3.Text = "Comment: On Creature Aggro";
            }
            else if (comboBox4.Text == "5 - SMART_EVENT_KILL")
            {
                textBox5.Text = "5";
                textBox3.Text = "event_param1: CooldownMin" + Environment.NewLine +
                                "event_param2: CooldownMax" + Environment.NewLine +
                                "event_param3: Player only (0/1)" + Environment.NewLine +
                                "event_param4: Creature entry (if param3 is 0)" + Environment.NewLine +
                                "Comment: On Creature Kill";
            }
            else if (comboBox4.Text == "6 - SMART_EVENT_DEATH")
            {
                textBox5.Text = "6";
                textBox3.Text = "Comment: On Creature Death";
            }
            else if (comboBox4.Text == "7 - SMART_EVENT_EVADE")
            {
                textBox5.Text = "7";
                textBox3.Text = "Comment: On Creature Evade Attack";
            }
            else if (comboBox4.Text == "8 - SMART_EVENT_SPELLHIT")
            {
                textBox5.Text = "8";
                textBox3.Text = "event_param1: SpellID" + Environment.NewLine +
                                "event_param2: School" + Environment.NewLine +
                                "event_param3: CooldownMin" + Environment.NewLine +
                                "event_param4: CooldownMax" + Environment.NewLine +
                                "Comment: On Creature/Gameobject Spell Hit";
            }
            else if (comboBox4.Text == "9 - SMART_EVENT_RANGE")
            {
                textBox5.Text = "9";
                textBox3.Text = "event_param1: MinDist" + Environment.NewLine +
                                "event_param2: MaxDist" + Environment.NewLine +
                                "event_param3: RepeatMin" + Environment.NewLine +
                                "event_param4: RepeatMax" + Environment.NewLine +
                                "Comment: On Target In Range";
            }
            else if (comboBox4.Text == "10 - SMART_EVENT_OOC_LOS")
            {
                textBox5.Text = "10";
                textBox3.Text = "event_param1: NoHostile" + Environment.NewLine +
                                "event_param2: MaxRange" + Environment.NewLine +
                                "event_param3: CooldownMin" + Environment.NewLine +
                                "event_param4: CooldownMax" + Environment.NewLine +
                                "Comment: On Target In Distance Out of Combat";
            }
            else if (comboBox4.Text == "11 - SMART_EVENT_RESPAWN")
            {
                linkLabel6.Visible = true;
                textBox5.Text = "11";
                textBox3.Text = "event_param1: type" + Environment.NewLine +
                                "event_param2: MapId" + Environment.NewLine +
                                "event_param3: ZoneId" + Environment.NewLine +
                                "Comment: On Creature/Gameobject Respawn";
            }
            else if (comboBox4.Text == "12 - SMART_EVENT_TARGET_HEALTH_PCT")
            {
                textBox5.Text = "12";
                textBox3.Text = "event_param1: HPMin%" + Environment.NewLine +
                                "event_param2: HPMax%" + Environment.NewLine +
                                "event_param3: RepeatMin" + Environment.NewLine +
                                "event_param4: RepeatMax" + Environment.NewLine +
                                "Comment: On Target Health Percentage";
            }
            else if (comboBox4.Text == "13 - SMART_EVENT_VICTIM_CASTING")
            {
                textBox5.Text = "13";
                textBox3.Text = "event_param1: RepeatMin" + Environment.NewLine +
                                "event_param2: RepeatMax" + Environment.NewLine +
                                "event_param3: Spell id (0 any)" + Environment.NewLine +
                                "Comment: On Target Casting Spell";
            }
            else if (comboBox4.Text == "14 - SMART_EVENT_FRIENDLY_HEALTH")
            {
                textBox5.Text = "14";
                textBox3.Text = "event_param1: HPDeficit" + Environment.NewLine +
                                "event_param2: Radius" + Environment.NewLine +
                                "event_param3: RepeatMin" + Environment.NewLine +
                                "event_param4: RepeatMax" + Environment.NewLine +
                                "Comment: On Friendly Health Deficit";
            }
            else if (comboBox4.Text == "15 - SMART_EVENT_FRIENDLY_IS_CC")
            {
                textBox5.Text = "15";
                textBox3.Text = "event_param1: Radius" + Environment.NewLine +
                                "event_param2: RepeatMin" + Environment.NewLine +
                                "event_param3: RepeatMax";
            }
            else if (comboBox4.Text == "16 - SMART_EVENT_FRIENDLY_MISSING_BUFF")
            {
                textBox5.Text = "16";
                textBox3.Text = "event_param1: SpellId" + Environment.NewLine +
                                "event_param2: Radius" + Environment.NewLine +
                                "event_param3: RepeatMin" + Environment.NewLine +
                                "event_param4: RepeatMax" + Environment.NewLine +
                                "Comment: On Friendly Lost Buff";
            }
            else if (comboBox4.Text == "17 - SMART_EVENT_SUMMONED_UNIT")
            {
                textBox5.Text = "17";
                textBox3.Text = "event_param1: CretureId (0 all)" + Environment.NewLine +
                                "event_param2: CooldownMin" + Environment.NewLine +
                                "event_param3: CooldownMax" + Environment.NewLine +
                                "Comment: On Creature/Gameobject Summoned Unit";
            }
            else if (comboBox4.Text == "18 - SMART_EVENT_TARGET_MANA_PCT")
            {
                textBox5.Text = "18";
                textBox3.Text = "event_param1: ManaMin%" + Environment.NewLine +
                                "event_param2: ManaMax%" + Environment.NewLine +
                                "event_param3: RepeatMin" + Environment.NewLine +
                                "event_param4: RepeatMax" + Environment.NewLine +
                                "Comment: On Target Mana Percentage";
            }
            else if (comboBox4.Text == "19 - SMART_EVENT_ACCEPTED_QUEST")
            {
                textBox5.Text = "19";
                textBox3.Text = "event_param1: QuestID (0 any)" + Environment.NewLine +
                                "Comment: On Target Accepted Quest";
            }
            else if (comboBox4.Text == "20 - SMART_EVENT_REWARD_QUEST")
            {
                textBox5.Text = "20";
                textBox3.Text = "event_param1: QuestID (0 any)" + Environment.NewLine +
                                "Comment: On Target Rewarded Quest";
            }
            else if (comboBox4.Text == "21 - SMART_EVENT_REACHED_HOME")
            {
                textBox5.Text = "21";
                textBox3.Text = "Comment: On Creature Reached Home";
            }
            else if (comboBox4.Text == "22 - SMART_EVENT_RECEIVE_EMOTE")
            {
                linkLabel7.Visible = true;
                textBox5.Text = "22";
                textBox3.Text = "event_param1: EmoteId" + Environment.NewLine +
                                "event_param2: CooldownMin" + Environment.NewLine +
                                "event_param3: CooldownMax" + Environment.NewLine +
                                "event_param4: condition" + Environment.NewLine +
                                "Comment: On Receive Emote.";
            }
            else if (comboBox4.Text == "23 - SMART_EVENT_HAS_AURA")
            {
                textBox5.Text = "23";
                textBox3.Text = "event_param1: SpellID" + Environment.NewLine +
                                "event_param2: Stacks" + Environment.NewLine +
                                "event_param3: RepeatMin" + Environment.NewLine +
                                "event_param4: RepeatMax" + Environment.NewLine +
                                "Comment: On Creature Has Aura";
            }
            else if (comboBox4.Text == "24 - SMART_EVENT_TARGET_BUFFED")
            {
                textBox5.Text = "24";
                textBox3.Text = "event_param1: SpellID" + Environment.NewLine +
                                "event_param2: Stacks" + Environment.NewLine +
                                "event_param3: RepeatMin" + Environment.NewLine +
                                "event_param4: RepeatMax" + Environment.NewLine +
                                "Comment: On Target Buffed With Spell";
            }
            else if (comboBox4.Text == "25 - SMART_EVENT_RESET")
            {
                textBox5.Text = "25";
                textBox3.Text = "Comment: After Combat, On Respawn or Spawn";
            }
            else if (comboBox4.Text == "26 - SMART_EVENT_IC_LOS")
            {
                textBox5.Text = "26";
                textBox3.Text = "event_param1: NoHostile" + Environment.NewLine +
                                "event_param2: MaxRange" + Environment.NewLine +
                                "event_param3: CooldownMin" + Environment.NewLine +
                                "event_param4: CooldownMax" + Environment.NewLine +
                                "Comment: On Target In Distance In Combat";
            }
            else if (comboBox4.Text == "27 - SMART_EVENT_PASSENGER_BOARDED")
            {
                textBox5.Text = "27";
                textBox3.Text = "event_param1: CooldownMin" + Environment.NewLine +
                                "event_param2: CooldownMax";
            }
            else if (comboBox4.Text == "28 - SMART_EVENT_PASSENGER_REMOVED")
            {
                textBox5.Text = "28";
                textBox3.Text = "event_param1: CooldownMin" + Environment.NewLine +
                                "event_param2: CooldownMax";
            }
            else if (comboBox4.Text == "29 - SMART_EVENT_CHARMED")
            {
                textBox5.Text = "29";
                textBox3.Text = "event_param1: 0 (on charm apply) / 1 (on charm remove)" + Environment.NewLine +
                                "Comment: On Creature Charmed";
            }
            else if (comboBox4.Text == "30 - SMART_EVENT_CHARMED_TARGET")
            {
                textBox5.Text = "30";
                textBox3.Text = "Comment: On Target Charmed";
            }
            else if (comboBox4.Text == "31 - SMART_EVENT_SPELLHIT_TARGET")
            {
                textBox5.Text = "31";
                textBox3.Text = "event_param1: SpellId" + Environment.NewLine +
                                "event_param2: School" + Environment.NewLine +
                                "event_param3: RepeatMin" + Environment.NewLine +
                                "event_param4: RepeatMax" + Environment.NewLine +
                                "Comment: On Target Spell Hit";
            }
            else if (comboBox4.Text == "32 - SMART_EVENT_DAMAGED")
            {
                textBox5.Text = "32";
                textBox3.Text = "event_param1: MinDmg" + Environment.NewLine +
                                "event_param2: MaxDmg" + Environment.NewLine +
                                "event_param3: RepeatMin" + Environment.NewLine +
                                "event_param4: RepeatMax" + Environment.NewLine +
                                "Comment: On Creature Damaged";
            }
            else if (comboBox4.Text == "33 - SMART_EVENT_DAMAGED_TARGET")
            {
                textBox5.Text = "33";
                textBox3.Text = "event_param1: MinDmg" + Environment.NewLine +
                                "event_param2: MaxDmg" + Environment.NewLine +
                                "event_param3: RepeatMin" + Environment.NewLine +
                                "event_param4: RepeatMax" + Environment.NewLine +
                                "Comment: On Target Damaged";
            }
            else if (comboBox4.Text == "34 - SMART_EVENT_MOVEMENTINFORM")
            {
                textBox5.Text = "34";
                textBox3.Text = "event_param1: MovementType (any)" + Environment.NewLine +
                                "event_param2: PointID";
            }
            else if (comboBox4.Text == "35 - SMART_EVENT_SUMMON_DESPAWNED")
            {
                textBox5.Text = "35";
                textBox3.Text = "event_param1: Entry" + Environment.NewLine +
                                "event_param2: CooldownMin" + Environment.NewLine +
                                "event_param3: CooldownMax" + Environment.NewLine +
                                "Comment: On Summoned Unit Despawned";
            }
            else if (comboBox4.Text == "36 - SMART_EVENT_CORPSE_REMOVED")
            {
                textBox5.Text = "36";
                textBox3.Text = "Comment: On Creature Corpse Removed";
            }
            else if (comboBox4.Text == "37 - SMART_EVENT_AI_INIT")
            {
                textBox5.Text = "37";
                textBox3.Text = "";
            }
            else if (comboBox4.Text == "38 - SMART_EVENT_DATA_SET")
            {
                textBox5.Text = "38";
                textBox3.Text = "event_param1: Field" + Environment.NewLine +
                                "event_param2: Value" + Environment.NewLine +
                                "event_param3: CooldownMin" + Environment.NewLine +
                                "event_param4: CooldownMax" + Environment.NewLine +
                                "Comment: On Creature/Gameobject Data Set, Can be used with SMART_ACTION_SET_DATA";
            }
            else if (comboBox4.Text == "39 - SMART_EVENT_WAYPOINT_START")
            {
                textBox5.Text = "39";
                textBox3.Text = "event_param1: PointId (0 any)" + Environment.NewLine +
                                "event_param2: PathId (0 any)" + Environment.NewLine +
                                "Comment: On Creature Waypoint ID Started";
            }
            else if (comboBox4.Text == "40 - SMART_EVENT_WAYPOINT_REACHED")
            {
                textBox5.Text = "40";
                textBox3.Text = "event_param1: PointId (0 any)" + Environment.NewLine +
                                "event_param2: PathId (0 any)" + Environment.NewLine +
                                "Comment: On Creature Waypoint ID Reached";
            }
            else if (comboBox4.Text == "46 - SMART_EVENT_AREATRIGGER_ONTRIGGER")
            {
                textBox5.Text = "46";
                textBox3.Text = "event_param1: TriggerId (0 any)";
            }
            else if (comboBox4.Text == "52 - SMART_EVENT_TEXT_OVER")
            {
                textBox5.Text = "52";
                textBox3.Text = "event_param1: GroupId (from creatue_text)" + Environment.NewLine +
                                "event_param2: CreatureId (0 any)" + Environment.NewLine +
                                "Comment: On TEXT_OVER Event Triggered After SMART_ACTION_TALK";
            }
            else if (comboBox4.Text == "53 - SMART_EVENT_RECEIVE_HEAL")
            {
                textBox5.Text = "53";
                textBox3.Text = "event_param1: MinHeal" + Environment.NewLine +
                                "event_param2: MaxHeal" + Environment.NewLine +
                                "event_param3: CooldownMin" + Environment.NewLine +
                                "event_param4: CooldownMax" + Environment.NewLine +
                                "Comment: On Creature Received Healing";
            }
            else if (comboBox4.Text == "54 - SMART_EVENT_JUST_SUMMONED")
            {
                textBox5.Text = "54";
                textBox3.Text = "Comment: On Creature Just spawned";
            }
            else if (comboBox4.Text == "55 - SMART_EVENT_WAYPOINT_PAUSED")
            {
                textBox5.Text = "55";
                textBox3.Text = "event_param1: PointId (0 any)" + Environment.NewLine +
                                "event_param2: PathID (0 any)" + Environment.NewLine +
                                "Comment: On Creature Paused at Waypoint ID";
            }
            else if (comboBox4.Text == "56 - SMART_EVENT_WAYPOINT_RESUMED")
            {
                textBox5.Text = "56";
                textBox3.Text = "event_param1: PointId (0 any)" + Environment.NewLine +
                                "event_param2: PathID (0 any)" + Environment.NewLine +
                                "Comment: On Creature Resumed after Waypoint ID";
            }
            else if (comboBox4.Text == "57 - SMART_EVENT_WAYPOINT_STOPPED")
            {
                textBox5.Text = "57";
                textBox3.Text = "event_param1: PointId (0 any)" + Environment.NewLine +
                                "event_param2: PathID (0 any)" + Environment.NewLine +
                                "Comment: On Creature Stopped On Waypoint ID";
            }
            else if (comboBox4.Text == "58 - SMART_EVENT_WAYPOINT_ENDED")
            {
                textBox5.Text = "58";
                textBox3.Text = "event_param1: PointId (0 any)" + Environment.NewLine +
                                "event_param2: PathID (0 any)" + Environment.NewLine +
                                "Comment: On Creature Waypoint Path Ended";
            }
            else if (comboBox4.Text == "59 - SMART_EVENT_TIMED_EVENT_TRIGGERED")
            {
                textBox5.Text = "59";
                textBox3.Text = "event_param1: Id";
            }
            else if (comboBox4.Text == "60 - SMART_EVENT_UPDATE")
            {
                textBox5.Text = "60";
                textBox3.Text = "event_param1: InitialMin" + Environment.NewLine +
                                "event_param2: InitialMax" + Environment.NewLine +
                                "event_param3: RepeatMin" + Environment.NewLine +
                                "event_param4: RepeatMax";
            }
            else if (comboBox4.Text == "61 - SMART_EVENT_LINK")
            {
                textBox5.Text = "61";
                textBox3.Text = "Comment: Used to link together multiple events as a chain of events.";
            }
            else if (comboBox4.Text == "62 - SMART_EVENT_GOSSIP_SELECT")
            {
                textBox5.Text = "62";
                textBox3.Text = "event_param1: menu_id" + Environment.NewLine +
                                "event_param2: id" + Environment.NewLine +
                                "Comment: On gossip clicked (gossip_menu_option).";
            }
            else if (comboBox4.Text == "63 - SMART_EVENT_JUST_CREATED")
            {
                textBox5.Text = "63";
                textBox3.Text = "";
            }
            else if (comboBox4.Text == "64 - SMART_EVENT_GOSSIP_HELLO")
            {
                textBox5.Text = "64";
                textBox3.Text = "Comment: On Right-Click Creature/Gameobject that have gossip enabled.";
            }
            else if (comboBox4.Text == "65 - SMART_EVENT_FOLLOW_COMPLETED")
            {
                textBox5.Text = "65";
                textBox3.Text = "";
            }
            else if (comboBox4.Text == "67 - SMART_EVENT_IS_BEHIND_TARGET")
            {
                textBox5.Text = "67";
                textBox3.Text = "event_param1: CooldownMin" + Environment.NewLine +
                                "event_param2: CooldownMax" + Environment.NewLine +
                                "Comment: On Creature is behind target.";
            }
            else if (comboBox4.Text == "68 - SMART_EVENT_GAME_EVENT_START")
            {
                textBox5.Text = "68";
                textBox3.Text = "event_param1: game_event.eventEntry" + Environment.NewLine +
                                "Comment: On game_event started.";
            }
            else if (comboBox4.Text == "69 - SMART_EVENT_GAME_EVENT_END")
            {
                textBox5.Text = "69";
                textBox3.Text = "event_param1: game_event.eventEntry" + Environment.NewLine +
                                "Comment: On game_event ended.";
            }
            else if (comboBox4.Text == "70 - SMART_EVENT_GO_STATE_CHANGED")
            {
                textBox5.Text = "70";
                textBox3.Text = "event_param1: State (0 - Active, 1 - Ready, 2 - Active alternative)";
            }
            else if (comboBox4.Text == "71 - SMART_EVENT_GO_EVENT_INFORM")
            {
                textBox5.Text = "71";
                textBox3.Text = "event_param1: EventId";
            }
            else if (comboBox4.Text == "72 - SMART_EVENT_ACTION_DONE")
            {
                textBox5.Text = "72";
                textBox3.Text = "event_param1: EventId";
            }
            else if (comboBox4.Text == "73 - SMART_EVENT_ON_SPELLCLICK")
            {
                textBox5.Text = "73";
                textBox3.Text = "";
            }
            else if (comboBox4.Text == "74 - SMART_EVENT_FRIENDLY_HEALTH_PCT")
            {
                textBox5.Text = "74";
                textBox3.Text = "event_param1: minHpPct" + Environment.NewLine +
                                "event_param2: maxHpPct" + Environment.NewLine +
                                "event_param3: repeatMin" + Environment.NewLine +
                                "event_param4: repeatMax" + Environment.NewLine +
                                "Comment: ";
            }
            else if (comboBox4.Text == "75 - SMART_EVENT_DISTANCE_CREATURE")
            {
                textBox5.Text = "75";
                textBox3.Text = "event_param1: database guid" + Environment.NewLine +
                                "event_param2: database entry" + Environment.NewLine +
                                "event_param3: distance" + Environment.NewLine +
                                "event_param4: repeat interval (ms)" + Environment.NewLine +
                                "Comment: On creature guid OR any instance of creature entry is within distance.";
            }
            else if (comboBox4.Text == "76 - SMART_EVENT_DISTANCE_GAMEOBJECT")
            {
                textBox5.Text = "76";
                textBox3.Text = "event_param1: database guid" + Environment.NewLine +
                                "event_param2: database entry" + Environment.NewLine +
                                "event_param3: distance" + Environment.NewLine +
                                "event_param4: repeat interval (ms)" + Environment.NewLine +
                                "Comment: On gameobject guid OR any instance of gameobject entry is within distance.";
            }
            else if (comboBox4.Text == "77 - SMART_EVENT_COUNTER_SET")
            {
                textBox5.Text = "77";
                textBox3.Text = "event_param1: counterID" + Environment.NewLine +
                                "event_param2: value" + Environment.NewLine +
                                "event_param3: cooldownMin" + Environment.NewLine +
                                "event_param4: cooldownMax" + Environment.NewLine +
                                "Comment: If the value of specified counterID is equal to a specified value";
            }
        }

        private void comboBox5_SelectedIndexChanged(object sender, EventArgs e)
        {
            textBox14.Text = Convert.ToString(comboBox5.SelectedIndex);
            button2.Visible = false; //Predefined SAI Templates
            linkLabel3.Visible = false; //Cast Flags
            linkLabel4.Visible = false; //Emote IDs
            linkLabel5.Visible = false; // Map IDs

            if (comboBox5.SelectedIndex == 0)
            {
                //RichTextBox _RichTextBox = new RichTextBox(); //Initialize a new RichTextBox of name _RichTextBox
                //_RichTextBox.Select(0, 8); //Select text within 0 and 8
                //_RichTextBox.SelectionColor = Color.Red; //Set the selected text color to Red
                //_RichTextBox.Select(8, 16); //Select text within 8 and 16
                //_RichTextBox.SelectionColor = Color.Green; //Set the selected text color to Green
                //_RichTextBox.Select(0, 0); //Select text within 0 and 0

                textBox6.Text = "Comment: Do nothing";
            }
           else if (comboBox5.SelectedIndex == 1)
            {
                textBox6.Text = "action_param1: Creature_text.groupid" + Environment.NewLine +
                                    "action_param2: Duration to wait before TEXT_OVER event is triggered." + Environment.NewLine +
                                    "Comment: Param2 in Milliseconds.";
            }
            else if (comboBox5.SelectedIndex == 2)
            {
                textBox6.Text = "action_param1: FactionID (or 0 for default)" + Environment.NewLine +
                                "Comment: Sets faction to creature." + Environment.NewLine +
                                "All players (and pets) = 0" + Environment.NewLine +
                                "Alliance players (and their pets) = 1" + Environment.NewLine +
                                "Horde players (and their pets) = 2" + Environment.NewLine +
                                "Monster (Not a player nor a pet) = 3";
            }
            else if (comboBox5.SelectedIndex == 3)
            {
                textBox6.Text = "action_param1: Creature_template.entry" + Environment.NewLine +
                                "action_param2: Creature_template.modelID" + Environment.NewLine +
                                "Comment: Take DisplayID of creature (param1) OR Turn to DisplayID (param2) OR Both = 0 for Demorph";
            }
            else if (comboBox5.SelectedIndex == 4)
            {
                textBox6.Text = "action_param1: SoundId" + Environment.NewLine +
                                "action_param2: onlySelf" + Environment.NewLine +
                                "Comment: Play Sound; TextRange = 0 only sends sound to self, TextRange = 1 sends sound to everyone in visibility range";
            }
            else if (comboBox5.SelectedIndex == 5)
            {
                linkLabel4.Visible = true;
                textBox6.Text = "action_param1: EmoteId" + Environment.NewLine +
                                "Comment: Play Emote";
            }
            else if (comboBox5.SelectedIndex == 6)
            {
                textBox6.Text = "action_param1: QuestID" + Environment.NewLine +
                                "Comment: Fail Quest of Target";
            }
            else if (comboBox5.SelectedIndex == 7)
            {
                textBox6.Text = "action_param1: QuestID" + Environment.NewLine +
                                "action_param2: directAdd (0/1)" + Environment.NewLine +
                                "Comment: Add Quest to Target";
            }
            else if (comboBox5.SelectedIndex == 8)
            {
                textBox6.Text = "action_param1: State" + Environment.NewLine +
                                "Comment: React State. Can be " + Environment.NewLine +
                                "Passive = 0 " + Environment.NewLine +
                                "Defensive = 1" + Environment.NewLine +
                                "Aggressive = 2" + Environment.NewLine + 
                                "Assist = 3";
            }
            else if (comboBox5.SelectedIndex == 9)
            {
                textBox6.Text = "Comment: Activate Object";
            }
            else if (comboBox5.SelectedIndex == 10)
            {
                linkLabel4.Visible = true;
                textBox6.Text = "action_param1: EmoteId1" + Environment.NewLine +
                                "action_param2: EmoteId2" + Environment.NewLine +
                                "action_param3: EmoteId3" + Environment.NewLine +
                                "Comment: Play Random Emote";
            }
            else if (comboBox5.SelectedIndex == 11)
            {
                linkLabel3.Visible = true;
                textBox6.Text = "action_param1: SpellId" + Environment.NewLine +
                                "action_param2: castFlags" + Environment.NewLine +
                                "action_param3: triggeredFlags" + Environment.NewLine +
                                "Comment: Cast Spell ID at Target";
            }
            else if (comboBox5.SelectedIndex == 12)
            {
                textBox6.Text = "action_param1: creature_template.entry" + Environment.NewLine +
                                "action_param2: Summon type" + Environment.NewLine +
                                "action_param3: duration in ms" + Environment.NewLine +
                                "action_param4: attackInvoker" + Environment.NewLine +
                                "Comment: Summon Unit";
            }
            else if (comboBox5.SelectedIndex == 13)
            {
                textBox6.Text = "action_param1: Threat% inc" + Environment.NewLine +
                                "action_param2: Threat% dec" + Environment.NewLine +
                                "Comment: Change Threat Percentage for Single Target";
            }
            else if (comboBox5.SelectedIndex == 14)
            {
                textBox6.Text = "action_param1: Threat% inc" + Environment.NewLine +
                                "action_param2: Threat% dec" + Environment.NewLine +
                                "Comment: Change Threat Percentage for All Enemies";
            }
            else if (comboBox5.SelectedIndex == 15)
            {
                textBox6.Text = "action_param1: QuestID";
            }
            else if (comboBox5.SelectedIndex == 16)
            {
                textBox6.Text = "";
            }
            else if (comboBox5.SelectedIndex == 17)
            {
                linkLabel4.Visible = true;
                textBox6.Text = "action_param1: EmoteId" + Environment.NewLine +
                                "Comment: Play Emote Continuously";
            }
            else if (comboBox5.SelectedIndex == 18)
            {
                textBox6.Text = "action_param1: (may be more than one field OR together)" + Environment.NewLine +
                                "action_param2: type - If FALSE set creature_template.unit_flags / If TRUE set creature_template.unit_flags2" + Environment.NewLine +
                                "Comment: Can set Multiple flags at once";
            }
            else if (comboBox5.SelectedIndex == 19)
            {
                textBox6.Text = "action_param1: (may be more than one field OR together)" + Environment.NewLine +
                                "action_param2: type - If FALSE set creature_template.unit_flags / If TRUE set creature_template.unit_flags2" + Environment.NewLine +
                                "Comment: Can Remove Multiple flags at once";
            }
            else if (comboBox5.SelectedIndex == 20)
            {
                textBox6.Text = "action_param1: AllowAttackState (0 = Stop attack, anything else means continue attacking)" + Environment.NewLine +
                                "Comment: Stop or Continue Automatic Attack.";
            }
            else if (comboBox5.SelectedIndex == 21)
            {
                textBox6.Text = "action_param1: AllowCombatMovement (0 = Stop combat based movement, anything else continue attacking)" + Environment.NewLine +
                                "Comment: Allow or Disable Combat Movement";
            }
            else if (comboBox5.SelectedIndex == 22)
            {
                textBox6.Text = "action_param1: smart_scripts.event_phase_mask";
            }
            else if (comboBox5.SelectedIndex == 23)
            {
                textBox6.Text = "action_param1: Increment" + Environment.NewLine +
                                "action_param2: Decrement" + Environment.NewLine +
                                "Comment: Set param1 OR param2 (not both). Value 0 has no effect.";
            }
            else if (comboBox5.SelectedIndex == 24)
            {
                textBox6.Text = "Comment: Evade Incoming Attack";
            }
            else if (comboBox5.SelectedIndex == 25)
            {
                textBox6.Text = "action_param1: 0/1 (If you want the fleeing NPC to say attempts to flee text on flee, use 1 on param1. For no message use 0.)" + Environment.NewLine +
                                "Comment: If you want the fleeing NPC to say '%s attempts to run away in fear' on flee, use 1 on param1. 0 for no message.";
            }
            else if (comboBox5.SelectedIndex == 26)
            {
                textBox6.Text = "action_param1: QuestID";
            }
            else if (comboBox5.SelectedIndex == 27)
            {
                textBox6.Text = "action_param1: Creature_template.entry" + Environment.NewLine +
                                "action_param2: SpellId";
            }
            else if (comboBox5.SelectedIndex == 28)
            {
                textBox6.Text = "action_param1: Spellid" + Environment.NewLine +
                                "Comment: 0 removes all auras";
            }
            else if (comboBox5.SelectedIndex == 29)
            {
                textBox6.Text = "action_param1: Distance (0 = Default value)" + Environment.NewLine +
                                "action_param2: Angle (0 = Default value)" + Environment.NewLine +
                                "action_param3: End creature_template.entry" + Environment.NewLine +
                                "action_param4: credit" + Environment.NewLine +
                                "action_param5: creditType (0monsterkill, 1event)" + Environment.NewLine +
                                "Comment: Follow Target";
            }
            else if (comboBox5.SelectedIndex == 30)
            {
                textBox6.Text = "action_param1: smart_scripts.event_phase_mask 1" + Environment.NewLine +
                                "action_param2: smart_scripts.event_phase_mask 2" + Environment.NewLine +
                                "action_param3: smart_scripts.event_phase_mask 3" + Environment.NewLine +
                                "action_param4: smart_scripts.event_phase_mask 4" + Environment.NewLine +
                                "action_param5: smart_scripts.event_phase_mask 5" + Environment.NewLine +
                                "action_param6: smart_scripts.event_phase_mask 6";
            }
            else if (comboBox5.SelectedIndex == 31)
            {
                textBox6.Text = "action_param1: smart_scripts.event_phase_mask minimum" + Environment.NewLine +
                                "action_param2: smart_scripts.event_phase_mask maximum";
            }
            else if (comboBox5.SelectedIndex == 32)
            {
                textBox6.Text = "Comment: Reset Gameobject";
            }
            else if (comboBox5.SelectedIndex == 33)
            {
                textBox6.Text = "action_param1: Creature_template.entry" + Environment.NewLine +
                                "Comment: This is the ID from quest_template.RequiredNpcOrGo";
            }
            else if (comboBox5.SelectedIndex == 34)
            {
                textBox6.Text = "action_param1: Field" + Environment.NewLine +
                                "action_param2: Data" + Environment.NewLine +
                                "Comment: Set Instance Data";
            }
            else if (comboBox5.SelectedIndex == 35)
            {
                textBox6.Text = "action_param1: Field" + Environment.NewLine +
                                "Comment: Set Instance Data uint64";
            }
            else if (comboBox5.SelectedIndex == 36)
            {
                textBox6.Text = "action_param1: Creature_template.entry" + Environment.NewLine +
                                "action_param2: Team (updates creature_template to given entry)";
            }
            else if (comboBox5.SelectedIndex == 37)
            {
                textBox6.Text = "Comment: Kill Target";
            }
            else if (comboBox5.SelectedIndex == 38)
            {
                textBox6.Text = "";
            }
            else if (comboBox5.SelectedIndex == 39)
            {
                textBox6.Text = "action_param1: Radius in yards that other creatures must be to acknowledge the cry for help." + Environment.NewLine +
                                "action_param2: 0/1 (say calls for help text)" + Environment.NewLine +
                                "Comment: If you want the NPC to say '%s calls for help!'. Use 1 on param1, 0 for no message.";
            }
            else if (comboBox5.SelectedIndex == 40)
            {
                textBox6.Text = "action_param1: Sheath (0-unarmed, 1-melee, 2-ranged)";
            }
            else if (comboBox5.SelectedIndex == 41)
            {
                textBox6.Text = "action_param1: timer" + Environment.NewLine +
                                "Comment: Despawn Target after param1 Milliseconds";
            }
            else if (comboBox5.SelectedIndex == 42)
            {
                textBox6.Text = "action_param1: flat hp value" + Environment.NewLine +
                                "action_param2: percent hp value" + Environment.NewLine +
                                "Comment: If you use both params, only percent will be used.";
            }
            else if (comboBox5.SelectedIndex == 43)
            {
                textBox6.Text = "action_param1: creature_template.entry" + Environment.NewLine +
                                "action_param2: creature_template.modelID" + Environment.NewLine +
                                "Comment: Mount to Creature Entry (param1) OR Mount to Creature Display (param2) Or both = 0 for Unmount";
            }
            else if (comboBox5.SelectedIndex == 44)
            {
                textBox6.Text = "action_param1: creature.phasemask" + Environment.NewLine +
                                "action_param2: 0 = remove / 1 = add";
            }
            else if (comboBox5.SelectedIndex == 45)
            {
                textBox6.Text = "action_param1: Field" + Environment.NewLine +
                                "action_param2: Data" + Environment.NewLine +
                                "Comment: Set Data For Target, can be used with SMART_EVENT_DATA_SET";
            }
            else if (comboBox5.SelectedIndex == 46)
            {
                textBox6.Text = "action_param1: Distance in yards" + Environment.NewLine +
                                "Comment: Sends creature forward.";
            }
            else if (comboBox5.SelectedIndex == 47)
            {
                textBox6.Text = "action_param1: 0/1" + Environment.NewLine +
                                "Comment: Makes creature Visible = 1  or  Invisible = 0";
            }
            else if (comboBox5.SelectedIndex == 48)
            {
                textBox6.Text = "action_param1: 0/1";
            }
            else if (comboBox5.SelectedIndex == 49)
            {
                textBox6.Text = "Comment: Allows basic melee swings to creature.";
            }
            else if (comboBox5.SelectedIndex == 50)
            {
                textBox6.Text = "action_param1: gameobject_template.entry" + Environment.NewLine +
                                "action_param2: De-spawn time in seconds." + Environment.NewLine +
                                "Comment: Spawns Gameobject, use target_type to set spawn position.";
            }
            else if (comboBox5.SelectedIndex == 51)
            {
                textBox6.Text = "Comment: Kills Creature.";
            }
            else if (comboBox5.SelectedIndex == 52)
            {
                textBox6.Text = "action_param1: TaxiID" + Environment.NewLine +
                                "Comment: Sends player to flight path. You have to be close to Flight Master, which gives Taxi ID you need.";
            }
            else if (comboBox5.SelectedIndex == 53)
            {
                textBox6.Text = "action_param1: 0 = walk / 1 = run" + Environment.NewLine +
                                "action_param2: waypoints.entry" + Environment.NewLine +
                                "action_param3: canRepeat" + Environment.NewLine +
                                "action_param4: quest_template.id" + Environment.NewLine +
                                "action_param5: despawntime" + Environment.NewLine +
                                "action_param6: reactState" + Environment.NewLine +
                                "Comment: Creature starts Waypoint Movement. Use waypoints table to create movement.";
            }
            else if (comboBox5.SelectedIndex == 54)
            {
                textBox6.Text = "action_param1: time (in ms)" + Environment.NewLine +
                                "Comment: Creature pauses its Waypoint Movement for given time.";
            }
            else if (comboBox5.SelectedIndex == 55)
            {
                textBox6.Text = "action_param1: despawnTime" + Environment.NewLine +
                                "action_param2: quest_template.id" + Environment.NewLine +
                                "action_param3: fail (0/1)" + Environment.NewLine +
                                "Comment: Creature stops its Waypoint Movement.";
            }
            else if (comboBox5.SelectedIndex == 56)
            {
                textBox6.Text = "action_param1: item_template.entry" + Environment.NewLine +
                                "action_param2: count" + Environment.NewLine +
                                "Comment: Adds item(s) to player.";
            }
            else if (comboBox5.SelectedIndex == 57)
            {
                textBox6.Text = "action_param1: item_template.entry" + Environment.NewLine +
                                "action_param2: count" + Environment.NewLine +
                                "Comment: Removes item(s) from player.";
            }
            else if (comboBox5.SelectedIndex == 58)
            {
                textBox6.Text = "action_param1: TemplateID (see Predefined SAI templates below)";
                button2.Visible = true;
            }
            else if (comboBox5.SelectedIndex == 59)
            {
                textBox6.Text = "action_param1: 0 = Off / 1 = On";
            }
            else if (comboBox5.SelectedIndex == 60)
            {
                textBox6.Text = "action_param1: 0 = On / 1 = Off" + Environment.NewLine +
                                "Comment: Only works for creatures with inhabit air.";
            }
            else if (comboBox5.SelectedIndex == 61)
            {
                textBox6.Text = "action_param1: 0 = On / 1 = Off";
            }
            else if (comboBox5.SelectedIndex == 62)
            {
                linkLabel5.Visible = true;
                textBox6.Text = "action_param1: MapID" + Environment.NewLine +
                                "Comment: Continue this action with the TARGET_TYPE column. Use any target_type (except 0), and use target_x, target_y, target_z, target_o as the coordinates";
            }
            else if (comboBox5.SelectedIndex == 63)
            {
                textBox6.Text = "action_param1: counterID" + Environment.NewLine +
                                "action_param2: value" + Environment.NewLine +
                                "action_param3: reset (0/1)";
            }
            else if (comboBox5.SelectedIndex == 64)
            {
                textBox6.Text = "action_param1: varID";
            }
            else if (comboBox5.SelectedIndex == 65)
            {
                textBox6.Text = "Comment: Creature continues in its Waypoint Movement.";
            }
            else if (comboBox5.SelectedIndex == 66)
            {
                textBox6.Text = "action_param1: Depends on the script target. if SMART_TARGET_SELF, facing will be the same as in HomePosition, For SMART_TARGET_POSITION you need to set target_o: 0 = North, West = 1.5, South = 3, East = 4.5";
            }
            else if (comboBox5.SelectedIndex == 67)
            {
                textBox6.Text = "action_param1: id" + Environment.NewLine +
                                "action_param2: InitialMin" + Environment.NewLine +
                                "action_param3: InitialMax" + Environment.NewLine +
                                "action_param4: RepeatMin(only if it repeats)" + Environment.NewLine +
                                "action_param5: RepeatMax(only if it repeats)" + Environment.NewLine +
                                "action_param6: chance";
            }
            else if (comboBox5.SelectedIndex == 68)
            {
                textBox6.Text = "action_param1: entry";
            }
            else if (comboBox5.SelectedIndex == 69)
            {
                textBox6.Text = "action_param1: PointId" + Environment.NewLine +
                                "action_param2: isTransport (0 or 1)" + Environment.NewLine +
                                "action_param3: disablePathfinding (0 or 1)" + Environment.NewLine +
                                "Comment: PointId is called by SMART_EVENT_MOVEMENTINFORM. Continue this action with the TARGET_TYPE column. Use any target_type, and use target_x, target_y, target_z, target_o as the coordinates";
            }
            else if (comboBox5.SelectedIndex == 70)
            {
                textBox6.Text = "action_param1: Respawntime in seconds for gameobjects (parameter for gameobjects only)";
            }
            else if (comboBox5.SelectedIndex == 71)
            {
                textBox6.Text = "action_param1: creature_equip_template.CreatureID" + Environment.NewLine +
                                "action_param2: Slotmask" + Environment.NewLine +
                                "action_param3: Slot1 (item_template.entry)" + Environment.NewLine +
                                "action_param4: Slot2 (item_template.entry)" + Environment.NewLine +
                                "action_param5: Slot3 (item_template.entry)" + Environment.NewLine +
                                "Comment: only slots with mask set will be sent to client, bits are 1, 2, 4, leaving mask 0 is defaulted to mask 7 (send all), Slots1-3 are only used if no Param1 is set";
            }
            else if (comboBox5.SelectedIndex == 72)
            {
                textBox6.Text = "Comment: Closes gossip window.";
            }
            else if (comboBox5.SelectedIndex == 73)
            {
                textBox6.Text = "action_param1: id(>1)";
            }
            else if (comboBox5.SelectedIndex == 74)
            {
                textBox6.Text = "action_param1: id(>1)";
            }
            else if (comboBox5.SelectedIndex == 75)
            {
                textBox6.Text = "action_param1: SpellId" +Environment.NewLine +
                                "Comment: Adds aura to player(s). Use target_type SMART_TARGET_PLAYER_RANGE to make AoE aura.";
            }
            else if (comboBox5.SelectedIndex == 76)
            {
                textBox6.Text = "Comment: WARNING: CAN CRASH CORE, do not use if you dont know what you are doing";
            }
            else if (comboBox5.SelectedIndex == 77)
            {
                textBox6.Text = "";
            }
            else if (comboBox5.SelectedIndex == 78)
            {
                textBox6.Text = "";
            }
            else if (comboBox5.SelectedIndex == 79)
            {
                textBox6.Text = "action_param1: attackDistance" + Environment.NewLine +
                                "action_param2: attackAngle" + Environment.NewLine +
                                "Comment: Sets movement to follow at a specific range to the target.";
            }
            else if (comboBox5.SelectedIndex == 80)
            {
                textBox6.Text = "action_param1: EntryOrGuid * 100 (smart_scripts.entryorguid with 00 added after the entry, or 01, 02, 03 etc. for multiple action lists)" + Environment.NewLine +
                                "action_param2: timer update type(0 OOC, 1 IC, 2 ALWAYS)";
            }
            else if (comboBox5.SelectedIndex == 81)
            {
                textBox6.Text = "action_param1: Creature_template.npcflag";
            }
            else if (comboBox5.SelectedIndex == 82)
            {
                textBox6.Text = "action_param1: Creature_template.npcflag";
            }
            else if (comboBox5.SelectedIndex == 83)
            {
                textBox6.Text = "action_param1: Creature_template.npcflag";
            }
            else if (comboBox5.SelectedIndex == 84)
            {
                textBox6.Text = "action_param1: creature_text.groupid" + Environment.NewLine +
                                "Comment: Makes a player say text. SMART_EVENT_TEXT_OVER is not triggered and whispers can not be used.";
            }
            else if (comboBox5.SelectedIndex == 85)
            {
                textBox6.Text = "action_param1: SpellID" + Environment.NewLine +
                                "action_param2: castFlags" + Environment.NewLine +
                                "action_param3: triggeredFlags" + Environment.NewLine +
                                "Comment: if avaliable, last used invoker will cast spellId with castFlags on targets";
            }
            else if (comboBox5.SelectedIndex == 86)
            {
                textBox6.Text = "action_param1: SpellID" + Environment.NewLine +
                                "action_param2: castFlags" + Environment.NewLine +
                                "action_param3: CasterTargetType (caster is selected here, use it as target_type)" + Environment.NewLine +
                                "action_param4: CasterTarget (target_param1)" + Environment.NewLine +
                                "action_param5: CasterTarget (target_param2)" + Environment.NewLine +
                                "action_param6: CasterTarget (target_param3)" + Environment.NewLine +
                                "Comment: This action is used to make selected caster (in CasterTargetType) to cast spell. Actual target is entered in target_type as normally.";
            }
            else if (comboBox5.SelectedIndex == 87)
            {
                textBox6.Text = "action_param1: EntryOrGuid 1 (smart_scripts.entryorguid * 100 + n)" + Environment.NewLine +
                                "action_param2: EntryOrGuid 2 (smart_scripts.entryorguid * 100 + n)" + Environment.NewLine +
                                "action_param3: EntryOrGuid 3 (smart_scripts.entryorguid * 100 + n)" + Environment.NewLine +
                                "action_param4: EntryOrGuid 4 (smart_scripts.entryorguid * 100 + n)" + Environment.NewLine +
                                "action_param5: EntryOrGuid 5 (smart_scripts.entryorguid * 100 + n)" + Environment.NewLine +
                                "action_param6: EntryOrGuid 6 (smart_scripts.entryorguid * 100 + n)" + Environment.NewLine +
                                "Comment: Will select one entry from the ones provided. 0 is ignored.";
            }
            else if (comboBox5.SelectedIndex == 88)
            {
                textBox6.Text = "action_param1: EntryOrGuid 1 (smart_scripts.entryorguid * 100 + n)" + Environment.NewLine +
                                "action_param2: EntryOrGuid 2 (smart_scripts.entryorguid * 100 + n)" + Environment.NewLine +
                                "Comment: 0 is ignored.";
            }
            else if (comboBox5.SelectedIndex == 89)
            {
                textBox6.Text = "action_param1: Radius" + Environment.NewLine +
                                "Comment: Creature moves to random position in given radius.";
            }
            else if (comboBox5.SelectedIndex == 90)
            {
                textBox6.Text = "action_param1: Value" + Environment.NewLine +
                                "action_param2: Type";
            }
            else if (comboBox5.SelectedIndex == 91)
            {
                textBox6.Text = "action_param1: Value" + Environment.NewLine +
                                "action_param2: Type";
            }
            else if (comboBox5.SelectedIndex == 92)
            {
                textBox6.Text = "action_param1: With delay (0/1)" + Environment.NewLine +
                                "action_param2: SpellId" + Environment.NewLine +
                                "action_param3: Instant (0/1)" + Environment.NewLine +
                                "Comment: This action allows you to interrupt the current spell being cast. If you do not set the spellId, the core will find the current spell depending on the withDelay and the withInstant values.";
            }
            else if (comboBox5.SelectedIndex == 93)
            {
                textBox6.Text = "action_param1: animprogress (0-255)";
            }
            else if (comboBox5.SelectedIndex == 94)
            {
                textBox6.Text = "action_param1: creature.dynamicflags";
            }
            else if (comboBox5.SelectedIndex == 95)
            {
                textBox6.Text = "action_param1: creature.dynamicflags";
            }
            else if (comboBox5.SelectedIndex == 96)
            {
                textBox6.Text = "action_param1: creature.dynamicflags";
            }
            else if (comboBox5.SelectedIndex == 97)
            {
                textBox6.Text = "action_param1: Speed XY" + Environment.NewLine +
                                "action_param2: Speed Z";
            }
            else if (comboBox5.SelectedIndex == 98)
            {
                textBox6.Text = "action_param1: gossip_menu.entry" + Environment.NewLine +
                                "action_param2: gossip_menu.text_id (same value as npc_text.ID)" + Environment.NewLine +
                                "Comment: Can be used together with 'SMART_EVENT_GOSSIP_HELLO' to set custom gossip.";
            }
            else if (comboBox5.SelectedIndex == 99)
            {
                textBox6.Text = "action_param1: LootState (0 - Not ready, 1 - Ready, 2 - Activated, 3 - Just deactivated)";
            }
            else if (comboBox5.SelectedIndex == 100)
            {
                textBox6.Text = "action_param1: id" + Environment.NewLine +
                                "Comment: Send targets previously stored with SMART_ACTION_STORE_TARGET, to another npc/go, the other npc/go can then access them as if it was its own stored list";
            }
            else if (comboBox5.SelectedIndex == 101)
            {
                textBox6.Text = "Comment: Use with SMART_TARGET_SELF or SMART_TARGET_POSITION";
            }
            else if (comboBox5.SelectedIndex == 102)
            {
                textBox6.Text = "action_param1: 0/1" + Environment.NewLine +
                                "Comment: Sets the current creatures health regen on or off.";
            }
            else if (comboBox5.SelectedIndex == 103)
            {
                textBox6.Text = "action_param1: 0/1" + Environment.NewLine +
                                "Comment: Enables or disables creature movement";
            }
            else if (comboBox5.SelectedIndex == 104)
            {
                textBox6.Text = "action_param1: gameobject_template_addon.flags" + Environment.NewLine +
                                "Comment: oldFlag = newFlag";
            }
            else if (comboBox5.SelectedIndex == 105)
            {
                textBox6.Text = "action_param1: gameobject_template_addon.flags" + Environment.NewLine +
                                "Comment: oldFlag |= newFlag";
            }
            else if (comboBox5.SelectedIndex == 106)
            {
                textBox6.Text = "action_param1: gameobject_template_addon.flags" + Environment.NewLine +
                                "Comment: oldFlag &= ~newFlag";
            }
            else if (comboBox5.SelectedIndex == 107)
            {
                textBox6.Text = "action_param1: creature_summon_groups.groupId" + Environment.NewLine +
                                "action_param2: Attack invoker (0/1)" + Environment.NewLine +
                                "Comment: Use creature_summon_groups table. SAI target has no effect, use 0";
            }
            else if (comboBox5.SelectedIndex == 108)
            {
                textBox6.Text = "action_param1: Power type" + Environment.NewLine +
                                "action_param2: New power";
            }
            else if (comboBox5.SelectedIndex == 109)
            {
                textBox6.Text = "action_param1: Power type" + Environment.NewLine +
                                "action_param2: Power to add";
            }
            else if (comboBox5.SelectedIndex == 110)
            {
                textBox6.Text = "action_param1: Power type" + Environment.NewLine +
                                "action_param2: Power to remove";
            }
            else if (comboBox5.SelectedIndex == 111)
            {
                textBox6.Text = "action_param1: GameEventId";
            }
            else if (comboBox5.SelectedIndex == 112)
            {
                textBox6.Text = "action_param1: GameEventId";
            }
            else if (comboBox5.SelectedIndex == 113)
            {
                textBox6.Text = "action_param1: wp1" + Environment.NewLine +
                                "action_param2: wp2" + Environment.NewLine +
                                "action_param3: wp3" + Environment.NewLine +
                                "action_param4: wp4" + Environment.NewLine +
                                "action_param5: wp5" + Environment.NewLine +
                                "action_param6: wp6" + Environment.NewLine +
                                "Comment: Make target follow closest waypoint to its location";
            }
            else if (comboBox5.SelectedIndex == 114)
            {
                textBox6.Text = "Coment: Makes the creature to fly up xx yards up to the sky (from current position)";
            }
            else if (comboBox5.SelectedIndex == 115)
            {
                textBox6.Text = "action_param1: soundId1" + Environment.NewLine +
                                "action_param2: soundId2" + Environment.NewLine +
                                "action_param3: soundId3" + Environment.NewLine +
                                "action_param4: soundId4" + Environment.NewLine +
                                "action_param5: soundId5" + Environment.NewLine +
                                "action_param6: onlySelf";
            }
            else if (comboBox5.SelectedIndex == 116)
            {
                textBox6.Text = "action_param1: timer";
            }
            else if (comboBox5.SelectedIndex == 117)
            {
                textBox6.Text = "action_param1: disable evade (1) / re-enable (0)";
            }
            else if (comboBox5.SelectedIndex == 118)
            {
                textBox6.Text = "action_param1: state";
            }
            
        }

        private void comboBox6_SelectedIndexChanged(object sender, EventArgs e)
        {
            textBox18.Text = Convert.ToString(comboBox6.SelectedIndex);

            if (comboBox6.SelectedIndex == 0)
            {
                textBox9.Text = "Comment: None";
            }
            else if (comboBox6.SelectedIndex == 1)
            {
                textBox9.Text = "Comment: Self cast.";
            }
            else if (comboBox6.SelectedIndex == 2)
            {
                textBox9.Text = "Comment: Our current target. (ie: highest aggro)";
            }
            else if (comboBox6.SelectedIndex == 3)
            {
                textBox9.Text = "Comment: Second highest aggro.";
            }
            else if (comboBox6.SelectedIndex == 4)
            {
                textBox9.Text = "Comment: Dead last on aggro.";
            }
            else if (comboBox6.SelectedIndex == 5)
            {
                textBox9.Text = "Comment: Just any random target on our threat list.";
            }
            else if (comboBox6.SelectedIndex == 6)
            {
                textBox9.Text = "Comment: Any random target except top threat.";
            }
            else if (comboBox6.SelectedIndex == 7)
            {
                textBox9.Text = "Comment: Unit who caused this Event to occur.";
            }
            else if (comboBox6.SelectedIndex == 8)
            {
                textBox9.Text = "target_x: x" + Environment.NewLine +
                                "target_y: y" + Environment.NewLine +
                                "target_z: z" + Environment.NewLine +
                                "target_o: o" + Environment.NewLine +
                                "Comment: Use xyz from event params.";
            }
            else if (comboBox6.SelectedIndex == 9)
            {
                textBox9.Text = "target_param1: creature Entry (0 any)" + Environment.NewLine +
                                "target_param2: minDist" + Environment.NewLine +
                                "target_param3: maxDist" + Environment.NewLine +
                                "Comment: (Random?) creature with specified ID within specified range.";
            }
            else if (comboBox6.SelectedIndex == 10)
            {
                textBox9.Text = "target_param1: guid" + Environment.NewLine +
                                "target_param2: entry" + Environment.NewLine +
                                "Comment: Creature with specified GUID.";
            }
            else if (comboBox6.SelectedIndex == 11)
            {
                textBox9.Text = "target_param1: creature Entry (0 any)" + Environment.NewLine +
                                "target_param2: maxDist" + Environment.NewLine +
                                "Comment: Creature with specified ID within distance. (Different from #9?)";
            }
            else if (comboBox6.SelectedIndex == 12)
            {
                textBox9.Text = "target_param1: id" + Environment.NewLine +
                                "Comment: Uses pre-stored target(list)";
            }
            else if (comboBox6.SelectedIndex == 13)
            {
                textBox9.Text = "target_param1: GO Entry (0 any)" + Environment.NewLine +
                                "target_param2: minDist" + Environment.NewLine +
                                "target_param3: maxDist" + Environment.NewLine +
                                "Comment: (Random?) object with specified ID within specified range.";
            }
            else if (comboBox6.SelectedIndex == 14)
            {
                textBox9.Text = "target_param1: guid" + Environment.NewLine +
                                "target_param2: entry" + Environment.NewLine +
                                "Comment: Object with specified GUID.";
            }
            else if (comboBox6.SelectedIndex == 15)
            {
                textBox9.Text = "target_param1: GO Entry (0 any)" + Environment.NewLine +
                                "target_param2: maxDist" + Environment.NewLine +
                                "Comment: Object with specified ID within distance. (Different from #13?)";
            }
            else if (comboBox6.SelectedIndex == 16)
            {
                textBox9.Text = "Comment: Invoker's party members";
            }
            else if (comboBox6.SelectedIndex == 17)
            {
                textBox9.Text = "target_param1: minDist" + Environment.NewLine +
                                "target_param2: maxDist" + Environment.NewLine +
                                "Comment: (Random?) player within specified range.";
            }
            else if (comboBox6.SelectedIndex == 18)
            {
                textBox9.Text = "target_param1: maxDist" + Environment.NewLine +
                                "Comment: (Random?) player within specified distance. (Different from #17?)";
            }
            else if (comboBox6.SelectedIndex == 19)
            {
                textBox9.Text = "target_param1: creature Entry (0 any)" + Environment.NewLine +
                                "target_param2: maxDist (Can be from 0-100 yards)" + Environment.NewLine +
                                "target_param3: dead? (0/1)" + Environment.NewLine +
                                "Comment: Closest creature with specified ID within specified range.";
            }
            else if (comboBox6.SelectedIndex == 20)
            {
                textBox9.Text = "target_param1: GO Entry (0 any)" + Environment.NewLine +
                                "target_param2: maxDist (Can be from 0-100 yards)" + Environment.NewLine +
                                "Comment: Closest object with specified ID within specified range.";
            }
            else if (comboBox6.SelectedIndex == 21)
            {
                textBox9.Text = "target_param1: maxDist" + Environment.NewLine +
                                "Comment: Closest player within specified range.";
            }
            else if (comboBox6.SelectedIndex == 22)
            {
                textBox9.Text = "Comment: Unit's vehicle who caused this Event to occur";
            }
            else if (comboBox6.SelectedIndex == 23)
            {
                textBox9.Text = "Comment: Unit's owner or summoner";
            }
            else if (comboBox6.SelectedIndex == 24)
            {
                textBox9.Text = "Comment: All units on creature's threat list";
            }
            else if (comboBox6.SelectedIndex == 25)
            {
                textBox9.Text = "target_param1: maxDist" + Environment.NewLine +
                                "target_param2: playerOnly (0/1)" + Environment.NewLine +
                                "Comment: Any attackable target (creature or player) within maxDist";
            }
            else if (comboBox6.SelectedIndex == 26)
            {
                textBox9.Text = "target_param1: maxDist" + Environment.NewLine +
                                "target_param2: playerOnly (0/1)" + Environment.NewLine +
                                "Comment: Any friendly unit (creature, player or pet) within maxDist";
            }
            else if (comboBox6.SelectedIndex == 27)
            {
                textBox9.Text = "Comment: All tagging players";
            }
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
            timer2.Start(); // Stopwatch

            if (form_MM.CB_NoMySQL.Checked)
            {
                label_mysql_status2.Visible = false;
                label85.Visible = false;
                timer1.Enabled = false; //Check if mysql is still running
                button10.Visible = false; // Execute Query
                timer1.Enabled = false;
            }
            else
                timer1.Enabled = true; //Check mysql connection

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
            BackToMainMenu backtomainmenu = new BackToMainMenu(form_MM);
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
            //label2.ForeColor = Color.White;
        }

        private void label2_MouseLeave(object sender, EventArgs e)
        {
            label2.BackColor = Color.FromArgb(58, 89, 114);
            //label2.ForeColor = Color.Black;
        }
        //=======================================================
        private void label1_MouseEnter(object sender, EventArgs e)
        {
            label1.BackColor = Color.Firebrick;
            //label1.ForeColor = Color.White;
        }

        private void label1_MouseLeave(object sender, EventArgs e)
        {
            label1.BackColor = Color.FromArgb(58, 89, 114);
            //label1.ForeColor = Color.Black;
        }
        //=======================================================
        private void label78_MouseEnter(object sender, EventArgs e)
        {
            label78.BackColor = Color.Firebrick;
            //label78.ForeColor = Color.White;
        }

        private void label78_MouseLeave(object sender, EventArgs e)
        {
            label78.BackColor = Color.FromArgb(58, 89, 114);
            //label78.ForeColor = Color.Black;
        }

        public bool IsProcessOpen(string name = "mysqld")
        {
            foreach (Process clsProcess in Process.GetProcesses())
            {
                if (clsProcess.ProcessName.Contains(name))
                {
                    label_mysql_status2.Text = "Connected!";
                    label_mysql_status2.ForeColor = Color.LawnGreen;
                    button10.Visible = true; // Execute Query
                    return true;
                }
            }

            label_mysql_status2.Text = "Connection Lost - MySQL is not running";
            label_mysql_status2.ForeColor = Color.Red;
            button10.Visible = false; // Execute Query
            return false;
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

            MySqlConnection connection = new MySqlConnection(
                "datasource=" + form_MM.GetHost() + ";" +
                "port=" + form_MM.GetPort() + ";" +
                "username=" + form_MM.GetUser() + ";" +
                "password=" + form_MM.GetPass() + ";"
                );
            string insertQuery = stringSQLShare;
            connection.Open();
            MySqlCommand command = new MySqlCommand(insertQuery, connection);

            try
            {
                if (command.ExecuteNonQuery() >= 1)
                {
                    //timer5.Start();
                    label_query_executed_successfully2.Visible = true;
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

        private void button2_Click(object sender, EventArgs e)
        {
            Predefined_SAI_Templates pre = new Predefined_SAI_Templates();
            pre.Show();
        }

        private void linkLabel3_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("https://trinitycore.atlassian.net/wiki/display/tc/smart_scripts#smart_scripts-CastFlags");
        }

        private void linkLabel4_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("https://trinitycore.atlassian.net/wiki/display/tc/Emotes");
        }

        private void linkLabel5_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("https://trinitycore.atlassian.net/wiki/display/tc/Map");
        }

        // Almost All textboxes - Exclude target_x, y, z, o textboxes
        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        // target_x, y, z, o textboxes
        private void textBox24_KeyPress(object sender, KeyPressEventArgs e)
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

            if ((e.KeyChar == '-') && ((sender as TextBox).Text.IndexOf('-') > -1))
            {
                e.Handled = true;
            }
        }

        private void linkLabel6_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("https://trinitycore.atlassian.net/wiki/display/tc/Map");
        }

        private void linkLabel7_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("https://trinitycore.atlassian.net/wiki/display/tc/Emotes");
        }

        private void label83_MouseEnter(object sender, EventArgs e)
        {
            panel5.BackColor = Color.Firebrick;
        }

        private void label83_MouseLeave(object sender, EventArgs e)
        {
            panel5.BackColor = Color.FromArgb(58, 89, 114);
        }

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

        private void button_SaveInTheSameFile_MouseEnter(object sender, EventArgs e)
        {
            button_SaveInTheSameFile.BackColor = Color.Firebrick;
        }

        private void button_SaveInTheSameFile_MouseLeave(object sender, EventArgs e)
        {
            button_SaveInTheSameFile.BackColor = Color.FromArgb(58, 89, 114);
        }

        private void label92_MouseEnter(object sender, EventArgs e)
        {
            toolTip1.SetToolTip(label92, "A file labeled SmartScripts.sql will be created in the same directory as the SpawnCreator vX.X executable. \nSo you can save multiple data rows in a single .sql file.");
            toolTip1.AutoPopDelay = 10000; // 10 seconds
        }

        private void button_SaveInTheSameFile_Click(object sender, EventArgs e)
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

            using (var writer = File.AppendText("SmartScripts.sql"))
            {
                writer.Write(stringSQLShare);
                button_SaveInTheSameFile.Text = "Saved!";
                button_SaveInTheSameFile.TextAlign = ContentAlignment.MiddleCenter;
            }
        }

        private void All_textBoxes_MouseEnter(object sender, EventArgs e)
        {
            button_SaveInTheSameFile.Text = "Save in the same file";
            button_SaveInTheSameFile.TextAlign = ContentAlignment.MiddleRight;
        }

        private void All_ComboBoxes_MouseEnter(object sender, EventArgs e)
        {
            All_textBoxes_MouseEnter(sender, e);
        }

        private void button3_MouseEnter(object sender, EventArgs e)
        {
            All_textBoxes_MouseEnter(sender, e);
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
                button10_Click(sender, e); // Execute Query if "F5" key is pressed
                return true;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }
    }
}
