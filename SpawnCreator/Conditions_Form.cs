using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
using MySql.Data.MySqlClient;
using SpawnCreator.Definitions;
using System.Diagnostics;
using System.IO;

namespace SpawnCreator
{
    public partial class Conditions_Form : Form
    {
        public Conditions_Form()
        {
            InitializeComponent();

            SourceTypeOrReferenceIDCMB.SelectedIndex = 0;
            comboBox1.SelectedIndex = 0;

            ElseGroupTooltip.SetToolTip(ElseGroupNUD, "Allows building grouped conditions - all entries belonging to the same condition (same SourceType, SourceGroup and SourceEntry) \nthat share the same number in ElseGroup, define one group. \nThe entire condition is met when any of its groups is met (logical OR). \nThe group is met when all of its entries are met (logical AND)."
            + Environment.NewLine
            + "Example:"
            + Environment.NewLine
            + "Two conditions with the same SourceType, SourceGroup and SourceEntry but with a different Condition, the first one has ElseGroup = 1 and the second has ElseGroup = 2, this creates a Logical OR."
            + Environment.NewLine
            + "Two conditions with the same SourceType, SourceGroup and SourceEntry but with a different Condition, both has ElseGroup = 1, this creates a Logical AND.");

            NegativeConditionTooltip.SetToolTip(NegativeConditionNUD, "If set to 1, the condition will be 'inverted'\nExample: CONDITION_AURA with NegativeCondition will be true when the player does NOT have the aura.");

            ErrorTypeTooltip.SetToolTip(ErrorTypeNUD, "Id from /src/server/game/Miscellaneous/SharedDefines.h:839. Will be displayed only for the below condition CONDITION_SOURCE_TYPE_SPELL(17)");
            ErrorTextIdTooltip.SetToolTip(ErrorTextIDNUD, "Id from /src/server/game/Miscellaneous/SharedDefines.h:1033. Will be displayed only for the below condition CONDITION_SOURCE_TYPE_SPELL(17)");
            ScriptNameTooltip.SetToolTip(ScriptNameTXT, "The ScriptName this condition uses, if any.");
        }

        private readonly Form_MainMenu form_MM;
        public Conditions_Form(Form_MainMenu form_MainMenu)
        {
            InitializeComponent();
            form_MM = form_MainMenu;
        }

        Form_MainMenu mainmenu = new Form_MainMenu();
        public static string stringSQLShare;
        public static string stringEntryShare;

        private bool _mouseDown;
        private Point lastLocation;

        private void _GenerateSqlCode(object sender, EventArgs e)
        {
            // Prepare SQL
            // select insertion columns
            string BuildSQLFile;
            BuildSQLFile = "INSERT INTO " + form_MM.GetWorldDB() + ".conditions ";
            BuildSQLFile += "(SourceTypeOrReferenceId, SourceGroup, SourceEntry, SourceId, ElseGroup, ConditionTypeOrReference, "+
                "ConditionTarget, ConditionValue1, ConditionValue2, ConditionValue3, NegativeCondition, ErrorType, ErrorTextId, ScriptName, Comment)";

            //Values
            BuildSQLFile += "VALUES \n";
            BuildSQLFile += "(";

            BuildSQLFile += textBox_sourceType.Text + ", "; // SourceTypeOrReferenceId
            BuildSQLFile += SourceGroupNUD.Text + ", "; // SourceGroup
            BuildSQLFile += SourceEntryNUD.Text + ", "; // SourceEntry
            BuildSQLFile += SourceIDNUD.Text + ", "; // SourceId
            BuildSQLFile += ElseGroupNUD.Text + ", "; // ElseGroup
            BuildSQLFile += textBox_ConditionType.Text + ", "; // ConditionTypeOrReference
            BuildSQLFile += ConditionTargetNUD.Text + ", "; // ConditionTarget
            BuildSQLFile += ConditionValue1NUD.Text + ", "; // ConditionValue1
            BuildSQLFile += ConditionValue2NUD.Text + ", "; // ConditionValue2
            BuildSQLFile += ConditionValue3NUD.Text + ", "; // ConditionValue3
            BuildSQLFile += NegativeConditionNUD.Text + ", "; // NegativeCondition
            BuildSQLFile += ErrorTypeNUD.Text + ", "; // ErrorType
            BuildSQLFile += ErrorTextIDNUD.Text + ", '"; // ErrorTextId
            BuildSQLFile += ScriptNameTXT.Text + "', '"; // ScriptName
            BuildSQLFile += CommentTXT.Text + "');"; // Comment

            stringSQLShare = BuildSQLFile;
        }

        private void Conditions_Form_Load(object sender, EventArgs e)
        {
            timer1.Start(); //Check if MySql is still running
            timer2.Start(); //Stopwatch
        }

        private void SourceTypeOrReferenceIDCMB_SelectedIndexChanged(object sender, EventArgs e)
        {
            textBox_sourceType.Text = SourceTypeOrReferenceIDCMB.Text;

            switch ((ConditionSourceType)SourceTypeOrReferenceIDCMB.SelectedIndex)
            {
                case ConditionSourceType.CONDITION_SOURCE_TYPE_NONE:
                    textBox_sourceType.Text = "0";
                    break;

                case ConditionSourceType.CONDITION_SOURCE_TYPE_CREATURE_LOOT_TEMPLATE:
                    SourceGroupTooltip.SetToolTip(SourceGroupNUD, "creature_loot_template.Entry or reference_loot_template.Entry");
                    SourceEntryTooltip.SetToolTip(SourceEntryNUD, "item id (_loot_template.Item or reference_loot_template.Item)");
                    SourceIDTooltip.SetToolTip(SourceIDNUD, "Always 0");
                    ConditionTargetTooltip.SetToolTip(ConditionTargetNUD, "Always 0");
                    NotesRTB.Text = "";
                    textBox_sourceType.Text = "1";
                    break;
                case ConditionSourceType.CONDITION_SOURCE_TYPE_DISENCHANT_LOOT_TEMPLATE:
                    SourceGroupTooltip.SetToolTip(SourceGroupNUD, "disenchant_loot_template.Entry or reference_loot_template.Entry");
                    SourceEntryTooltip.SetToolTip(SourceEntryNUD, "item id (_loot_template.Item or reference_loot_template.Item)");
                    SourceIDTooltip.SetToolTip(SourceIDNUD, "Always 0");
                    ConditionTargetTooltip.SetToolTip(ConditionTargetNUD, "Always 0");
                    NotesRTB.Text = "";
                    textBox_sourceType.Text = "2";
                    break;
                case ConditionSourceType.CONDITION_SOURCE_TYPE_FISHING_LOOT_TEMPLATE:
                    SourceGroupTooltip.SetToolTip(SourceGroupNUD, "fishing_loot_template.Entry or reference_loot_template.Entry");
                    SourceEntryTooltip.SetToolTip(SourceEntryNUD, "item id (_loot_template.Item or reference_loot_template.Item)");
                    SourceIDTooltip.SetToolTip(SourceIDNUD, "Always 0");
                    ConditionTargetTooltip.SetToolTip(ConditionTargetNUD, "Always 0");
                    NotesRTB.Text = "";
                    textBox_sourceType.Text = "3";
                    break;
                case ConditionSourceType.CONDITION_SOURCE_TYPE_GAMEOBJECT_LOOT_TEMPLATE:
                    SourceGroupTooltip.SetToolTip(SourceGroupNUD, "gameobject_loot_template.Entry or reference_loot_template.Entry");
                    SourceEntryTooltip.SetToolTip(SourceEntryNUD, "item id (_loot_template.Item or reference_loot_template.Item)");
                    SourceIDTooltip.SetToolTip(SourceIDNUD, "Always 0");
                    ConditionTargetTooltip.SetToolTip(ConditionTargetNUD, "Always 0");
                    NotesRTB.Text = "";
                    textBox_sourceType.Text = "4";
                    break;
                case ConditionSourceType.CONDITION_SOURCE_TYPE_ITEM_LOOT_TEMPLATE:
                    SourceGroupTooltip.SetToolTip(SourceGroupNUD, "item_loot_template.Entry or reference_loot_template.Entry");
                    SourceEntryTooltip.SetToolTip(SourceEntryNUD, "item id (_loot_template.Item or reference_loot_template.Item)");
                    SourceIDTooltip.SetToolTip(SourceIDNUD, "Always 0");
                    ConditionTargetTooltip.SetToolTip(ConditionTargetNUD, "Always 0");
                    NotesRTB.Text = "";
                    textBox_sourceType.Text = "5";
                    break;
                case ConditionSourceType.CONDITION_SOURCE_TYPE_MAIL_LOOT_TEMPLATE:
                    SourceGroupTooltip.SetToolTip(SourceGroupNUD, "mail_loot_template.Entry or reference_loot_template.Entry");
                    SourceEntryTooltip.SetToolTip(SourceEntryNUD, "item id (_loot_template.Item or reference_loot_template.Item)");
                    SourceIDTooltip.SetToolTip(SourceIDNUD, "Always 0");
                    ConditionTargetTooltip.SetToolTip(ConditionTargetNUD, "Always 0");
                    NotesRTB.Text = "";
                    textBox_sourceType.Text = "6";
                    break;
                case ConditionSourceType.CONDITION_SOURCE_TYPE_MILLING_LOOT_TEMPLATE:
                    SourceGroupTooltip.SetToolTip(SourceGroupNUD, "milling_loot_template.Entry or reference_loot_template.Entry");
                    SourceEntryTooltip.SetToolTip(SourceEntryNUD, "item id (_loot_template.Item or reference_loot_template.Item)");
                    SourceIDTooltip.SetToolTip(SourceIDNUD, "Always 0");
                    ConditionTargetTooltip.SetToolTip(ConditionTargetNUD, "Always 0");
                    NotesRTB.Text = "";
                    textBox_sourceType.Text = "7";
                    break;
                case ConditionSourceType.CONDITION_SOURCE_TYPE_PICKPOCKETING_LOOT_TEMPLATE:
                    SourceGroupTooltip.SetToolTip(SourceGroupNUD, "pickpocketing_loot_template.Entry or reference_loot_template.Entry");
                    SourceEntryTooltip.SetToolTip(SourceEntryNUD, "item id (_loot_template.Item or reference_loot_template.Item)");
                    SourceIDTooltip.SetToolTip(SourceIDNUD, "Always 0");
                    ConditionTargetTooltip.SetToolTip(ConditionTargetNUD, "Always 0");
                    NotesRTB.Text = "";
                    textBox_sourceType.Text = "8";
                    break;
                case ConditionSourceType.CONDITION_SOURCE_TYPE_PROSPECTING_LOOT_TEMPLATE:
                    SourceGroupTooltip.SetToolTip(SourceGroupNUD, "prospecting_loot_template.Entry or reference_loot_template.Entry");
                    SourceEntryTooltip.SetToolTip(SourceEntryNUD, "item id (_loot_template.Item or reference_loot_template.Item)");
                    SourceIDTooltip.SetToolTip(SourceIDNUD, "Always 0");
                    ConditionTargetTooltip.SetToolTip(ConditionTargetNUD, "Always 0");
                    NotesRTB.Text = "";
                    textBox_sourceType.Text = "9";
                    break;
                case ConditionSourceType.CONDITION_SOURCE_TYPE_REFERENCE_LOOT_TEMPLATE:
                    SourceGroupTooltip.SetToolTip(SourceGroupNUD, "reference_loot_template.Entry");
                    SourceEntryTooltip.SetToolTip(SourceEntryNUD, "item id (_loot_template.Item or reference_loot_template.Item)");
                    SourceIDTooltip.SetToolTip(SourceIDNUD, "Always 0");
                    ConditionTargetTooltip.SetToolTip(ConditionTargetNUD, "Always 0");
                    NotesRTB.Text = "";
                    textBox_sourceType.Text = "10";
                    break;
                case ConditionSourceType.CONDITION_SOURCE_TYPE_SKINNING_LOOT_TEMPLATE:
                    SourceGroupTooltip.SetToolTip(SourceGroupNUD, "skinning_loot_template.Entry or reference_loot_template.Entry");
                    SourceEntryTooltip.SetToolTip(SourceEntryNUD, "item id (_loot_template.Item or reference_loot_template.Item)");
                    SourceIDTooltip.SetToolTip(SourceIDNUD, "Always 0");
                    ConditionTargetTooltip.SetToolTip(ConditionTargetNUD, "Always 0");
                    NotesRTB.Text = "";
                    textBox_sourceType.Text = "11";
                    break;
                case ConditionSourceType.CONDITION_SOURCE_TYPE_SPELL_LOOT_TEMPLATE:
                    SourceGroupTooltip.SetToolTip(SourceGroupNUD, "spell_loot_template.Entry or reference_loot_template.Entry");
                    SourceEntryTooltip.SetToolTip(SourceEntryNUD, "item id (_loot_template.Item or reference_loot_template.Item)");
                    SourceIDTooltip.SetToolTip(SourceIDNUD, "Always 0");
                    ConditionTargetTooltip.SetToolTip(ConditionTargetNUD, "Always 0");
                    NotesRTB.Text = "";
                    textBox_sourceType.Text = "12";
                    break;
                case ConditionSourceType.CONDITION_SOURCE_TYPE_SPELL_IMPLICIT_TARGET:
                    SourceGroupTooltip.SetToolTip(SourceGroupNUD, "Mask of effects to be affected by condition: \n1 = EFFECT_0\n2 = EFFECT_1\n4 = EFFECT_2");
                    SourceEntryTooltip.SetToolTip(SourceEntryNUD, "Spell Id from  Spell DBC file");
                    SourceIDTooltip.SetToolTip(SourceIDNUD, "Always 0");
                    ConditionTargetTooltip.SetToolTip(ConditionTargetNUD, "0 : Potential spell Target\n1 : spell Caster");
                    NotesRTB.Text = "Don't use wowhead to get number of effects, data from wowhead sometimes doesn't match real effect number.";
                    textBox_sourceType.Text = "13";
                    break;
                case ConditionSourceType.CONDITION_SOURCE_TYPE_GOSSIP_MENU:
                    SourceGroupTooltip.SetToolTip(SourceGroupNUD, "gossip_menu.entry (gossip menu entry)");
                    SourceEntryTooltip.SetToolTip(SourceEntryNUD, "gossip_menu.text_id (points to npc_text.ID)");
                    SourceIDTooltip.SetToolTip(SourceIDNUD, "Always 0");
                    ConditionTargetTooltip.SetToolTip(ConditionTargetNUD, "0 = Player\n1 = WorldObject");
                    NotesRTB.Text = "";
                    textBox_sourceType.Text = "14";
                    break;
                case ConditionSourceType.CONDITION_SOURCE_TYPE_GOSSIP_MENU_OPTION:
                    SourceGroupTooltip.SetToolTip(SourceGroupNUD, "gossip_menu_option.menu_id (menu entry)");
                    SourceEntryTooltip.SetToolTip(SourceEntryNUD, "gossip_menu_option.id");
                    SourceIDTooltip.SetToolTip(SourceIDNUD, "Always 0");
                    ConditionTargetTooltip.SetToolTip(ConditionTargetNUD, "0 = Player\n1 = WorldObject");
                    NotesRTB.Text = "";
                    textBox_sourceType.Text = "15";
                    break;
                case ConditionSourceType.CONDITION_SOURCE_TYPE_CREATURE_TEMPLATE_VEHICLE:
                    SourceGroupTooltip.SetToolTip(SourceGroupNUD, "Always 0");
                    SourceEntryTooltip.SetToolTip(SourceEntryNUD, "creature entry (creature_template.entry)");
                    SourceIDTooltip.SetToolTip(SourceIDNUD, "Always 0");
                    ConditionTargetTooltip.SetToolTip(ConditionTargetNUD, "0 = Player riding vehicle\n1 = Vehicle creature");
                    NotesRTB.Text = "";
                    textBox_sourceType.Text = "16";
                    break;
                case ConditionSourceType.CONDITION_SOURCE_TYPE_SPELL:
                    SourceGroupTooltip.SetToolTip(SourceGroupNUD, "Always 0");
                    SourceEntryTooltip.SetToolTip(SourceEntryNUD, "Spell ID from Spell.dbc");
                    SourceIDTooltip.SetToolTip(SourceIDNUD, "Always 0");
                    ConditionTargetTooltip.SetToolTip(ConditionTargetNUD, "0 = spell Caster\n1 =  Explicit Target of the spell (only for spells which take the object selected by caster into account)");
                    NotesRTB.Text = "- This source type allows you to define caster/explicit target requirements for spell to be cast."
                    + Environment.NewLine
                    + "- Explicit target of the spell is the target which is selected by player during cast, not all spells take that target into account. non-explicit targets of the spell (the ones which are selected by spell like area or nearby targets for example) are not affected by this condition source type, if you want to affect those use CONDITION_SOURCE_TYPE_SPELL_IMPLICIT_TARGET instead."
                    + Environment.NewLine
                    + "- If you are looking for old CONDITION_SOURCE_TYPE_ITEM_REQUIRED_TARGET, use this condition source type instead (ConditionTarget = 1 allows you to set requirements for a given spell, so to use this condition type you need spellid of the spell cast on item use)."
                    + Environment.NewLine
                    + "- Remember that conditions with the same ElseGroup value will be used to make logical AND check, so to allow different targets for the same spell effect you have to set ElseGroup respectively.";
                    textBox_sourceType.Text = "17";
                    break;
                case ConditionSourceType.CONDITION_SOURCE_TYPE_SPELL_CLICK_EVENT:
                    SourceGroupTooltip.SetToolTip(SourceGroupNUD, "creature entry (npc_spellclick_spells.npc_entry)");
                    SourceEntryTooltip.SetToolTip(SourceEntryNUD, "Spell (npc_spellclick_spells.spell_id)");
                    SourceIDTooltip.SetToolTip(SourceIDNUD, "Always 0");
                    ConditionTargetTooltip.SetToolTip(ConditionTargetNUD, "0 = Clicker\n1 =  Spellclick target (clickee)");
                    NotesRTB.Text = "";
                    textBox_sourceType.Text = "18";
                    break;
                case ConditionSourceType.CONDITION_SOURCE_TYPE_QUEST_ACCEPT:
                    SourceGroupTooltip.SetToolTip(SourceGroupNUD, "? Always 0");
                    SourceEntryTooltip.SetToolTip(SourceEntryNUD, "Quest ID");
                    SourceIDTooltip.SetToolTip(SourceIDNUD, "Always 0");
                    ConditionTargetTooltip.SetToolTip(ConditionTargetNUD, "Always 0");
                    NotesRTB.Text = "";
                    textBox_sourceType.Text = "19";
                    break;
                case ConditionSourceType.CONDITION_SOURCE_TYPE_QUEST_SHOW_MARK:
                    SourceGroupTooltip.SetToolTip(SourceGroupNUD, "? Always 0");
                    SourceEntryTooltip.SetToolTip(SourceEntryNUD, "Quest ID");
                    SourceIDTooltip.SetToolTip(SourceIDNUD, "Always 0");
                    ConditionTargetTooltip.SetToolTip(ConditionTargetNUD, "Always 0");
                    NotesRTB.Text = "";
                    textBox_sourceType.Text = "20";
                    break;
                case ConditionSourceType.CONDITION_SOURCE_TYPE_VEHICLE_SPELL:
                    SourceGroupTooltip.SetToolTip(SourceGroupNUD, "creature entry (creature_template.entry)");
                    SourceEntryTooltip.SetToolTip(SourceEntryNUD, "Spell ID from Spell.dbc");
                    SourceIDTooltip.SetToolTip(SourceIDNUD, "Always 0");
                    ConditionTargetTooltip.SetToolTip(ConditionTargetNUD, "0 = Player for whom spell bar is shown\n1 =  Vehicle creature");
                    NotesRTB.Text = "This will show or hide spells in vehicle spell bar.";
                    textBox_sourceType.Text = "21";
                    break;
                case ConditionSourceType.CONDITION_SOURCE_TYPE_SMART_EVENT:
                    SourceGroupTooltip.SetToolTip(SourceGroupNUD, "ID (smart_scripts.id) + 1");
                    SourceEntryTooltip.SetToolTip(SourceEntryNUD, "EntryOrGuid (smart_scripts.entryorguid)");
                    SourceIDTooltip.SetToolTip(SourceIDNUD, "SourceType (smart_scripts.source_type)");
                    ConditionTargetTooltip.SetToolTip(ConditionTargetNUD, "0 = Invoker\n1 = Object");
                    NotesRTB.Text = "";
                    textBox_sourceType.Text = "22";
                    break;
                case ConditionSourceType.CONDITION_SOURCE_TYPE_NPC_VENDOR:
                    SourceGroupTooltip.SetToolTip(SourceGroupNUD, "vendor entry (npc_vendor.entry)");
                    SourceEntryTooltip.SetToolTip(SourceEntryNUD, "item entry (npc_vendor.item)");
                    SourceIDTooltip.SetToolTip(SourceIDNUD, "Always 0");
                    ConditionTargetTooltip.SetToolTip(ConditionTargetNUD, "Always 0");
                    NotesRTB.Text = "";
                    textBox_sourceType.Text = "23";
                    break;
                case ConditionSourceType.CONDITION_SOURCE_TYPE_SPELL_PROC:
                    SourceGroupTooltip.SetToolTip(SourceGroupNUD, "Always 0");
                    SourceEntryTooltip.SetToolTip(SourceEntryNUD, "Spell ID of aura which triggers the proc");
                    SourceIDTooltip.SetToolTip(SourceIDNUD, "Always 0");
                    ConditionTargetTooltip.SetToolTip(ConditionTargetNUD, "0 = Actor\n1 = ActionTarget");
                    NotesRTB.Text = "";
                    textBox_sourceType.Text = "24";
                    break;
                case ConditionSourceType.CONDITION_SOURCE_TYPE_TERRAIN_SWAP:
                    SourceGroupTooltip.SetToolTip(SourceGroupNUD, "terrainSwap - object in terrainswap [ 6.x / 7.x only ]");
                    SourceEntryTooltip.SetToolTip(SourceEntryNUD, "See sourcecode ConditionMGR.h");
                    SourceIDTooltip.SetToolTip(SourceIDNUD, "Always 0");
                    ConditionTargetTooltip.SetToolTip(ConditionTargetNUD, "(source code / new description here)");
                    NotesRTB.Text = "";
                    textBox_sourceType.Text = "25";
                    break;
                case ConditionSourceType.CONDITION_SOURCE_TYPE_PHASE:
                    SourceGroupTooltip.SetToolTip(SourceGroupNUD, "See sourcecode ConditionMGR.h");
                    SourceEntryTooltip.SetToolTip(SourceEntryNUD, "See sourcecode ConditionMGR.h");
                    SourceIDTooltip.SetToolTip(SourceIDNUD, "Always 0");
                    ConditionTargetTooltip.SetToolTip(ConditionTargetNUD, "(source code / new description here)");
                    NotesRTB.Text = "";
                    textBox_sourceType.Text = "26";
                    break;
                default:
                    SourceGroupTooltip.SetToolTip(SourceGroupNUD, "");
                    SourceEntryTooltip.SetToolTip(SourceEntryNUD, "");
                    SourceIDTooltip.SetToolTip(SourceIDNUD, "");
                    ConditionTargetTooltip.SetToolTip(ConditionTargetNUD, "");
                    NotesRTB.Text = "";
                    textBox_sourceType.Text = "27";
                    break;
            }
        }

        private void ResetBTN_Click(object sender, EventArgs e)
        {
            SourceTypeOrReferenceIDCMB.SelectedIndex = 0;
            SourceGroupNUD.Value = 0;
            SourceEntryNUD.Value = 0;
            SourceIDNUD.Value = 0;
            ConditionTargetNUD.Value = 0;

            ElseGroupNUD.Value = 0;

            comboBox1.SelectedIndex = 0;
            ConditionValue1NUD.Value = 0;
            ConditionValue2NUD.Value = 0;
            ConditionValue3NUD.Value = 0;

            NegativeConditionNUD.Value = 0;
            ErrorTypeNUD.Value = 0;
            ErrorTextIDNUD.Value = 0;
            ScriptNameTXT.Text = "";
            CommentTXT.Text = "";
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch ((ConditionType)comboBox1.SelectedIndex)
            {
                case ConditionType.CONDITION_NONE:             
                    textBox_ConditionType.Text = "0";
                    break;
                case ConditionType.CONDITION_AURA:
                    ConditionValue1Tooltip.SetToolTip(ConditionValue1NUD, "Spell ID from Spell.dbc");
                    ConditionValue2Tooltip.SetToolTip(ConditionValue2NUD, "Effect index (0-2)");
                    ConditionValue3Tooltip.SetToolTip(ConditionValue3NUD, "Always 0");
                    textBox_ConditionType.Text = "1";
                    break;
                case ConditionType.CONDITION_ITEM:
                    ConditionValue1Tooltip.SetToolTip(ConditionValue1NUD, "item entry (item_template.entry)");
                    ConditionValue2Tooltip.SetToolTip(ConditionValue2NUD, "Item Count");
                    ConditionValue3Tooltip.SetToolTip(ConditionValue3NUD, "0 = not in bank\n1 = in bank");
                    textBox_ConditionType.Text = "2";
                    break;
                case ConditionType.CONDITION_ITEM_EQUIPPED:
                    ConditionValue1Tooltip.SetToolTip(ConditionValue1NUD, "item entry (item_template.entry)");
                    ConditionValue2Tooltip.SetToolTip(ConditionValue2NUD, "Always 0");
                    ConditionValue3Tooltip.SetToolTip(ConditionValue3NUD, "Always 0");
                    textBox_ConditionType.Text = "3";
                    break;
                case ConditionType.CONDITION_ZONEID:
                    ConditionValue1Tooltip.SetToolTip(ConditionValue1NUD, "Zone ID where this condition will be true.");
                    ConditionValue2Tooltip.SetToolTip(ConditionValue2NUD, "Always 0");
                    ConditionValue3Tooltip.SetToolTip(ConditionValue3NUD, "Always 0");
                    textBox_ConditionType.Text = "4";
                    break;
                case ConditionType.CONDITION_REPUTATION_RANK:
                    ConditionValue1Tooltip.SetToolTip(ConditionValue1NUD, "Faction template ID from Faction.dbc");
                    ConditionValue2Tooltip.SetToolTip(ConditionValue2NUD, "1 = Hated"
                    + Environment.NewLine
                    + "2 = Hostile"
                    + Environment.NewLine
                    + "4 = Unfriendly"
                    + Environment.NewLine
                    + "8 = Neutral"
                    + Environment.NewLine
                    + "16 = Friendly"
                    + Environment.NewLine
                    + "32 = Honored"
                    + Environment.NewLine
                    + "64 = Revered"
                    + Environment.NewLine
                    + "128 = Exalted"
                    + Environment.NewLine
                    + "Add the target ranks together for the condition to be true for all those ranks.");
                    ConditionValue3Tooltip.SetToolTip(ConditionValue3NUD, "Always 0");
                    textBox_ConditionType.Text = "5";
                    break;
                case ConditionType.CONDITION_TEAM:
                    ConditionValue1Tooltip.SetToolTip(ConditionValue1NUD, "Team id :Alliance = 469 / Horde = 67");
                    ConditionValue2Tooltip.SetToolTip(ConditionValue2NUD, "Always 0");
                    ConditionValue3Tooltip.SetToolTip(ConditionValue3NUD, "Always 0");
                    textBox_ConditionType.Text = "6";
                    break;
                case ConditionType.CONDITION_SKILL:
                    ConditionValue1Tooltip.SetToolTip(ConditionValue1NUD, "Required skill. See SkillLine.dbc .");
                    ConditionValue2Tooltip.SetToolTip(ConditionValue2NUD, "Skill rank value (e.g. from 1 to 450 for the 3.3.5 branch)");
                    ConditionValue3Tooltip.SetToolTip(ConditionValue3NUD, "Always 0");
                    textBox_ConditionType.Text = "7";
                    break;
                case ConditionType.CONDITION_QUESTREWARDED:
                    ConditionValue1Tooltip.SetToolTip(ConditionValue1NUD, "Quest ID - see quest_template.id");
                    ConditionValue2Tooltip.SetToolTip(ConditionValue2NUD, "Always 0");
                    ConditionValue3Tooltip.SetToolTip(ConditionValue3NUD, "Always 0");
                    textBox_ConditionType.Text = "8";
                    break;
                case ConditionType.CONDITION_QUESTTAKEN:
                    ConditionValue1Tooltip.SetToolTip(ConditionValue1NUD, "Quest ID - see quest_template.id");
                    ConditionValue2Tooltip.SetToolTip(ConditionValue2NUD, "Always 0");
                    ConditionValue3Tooltip.SetToolTip(ConditionValue3NUD, "Always 0");
                    textBox_ConditionType.Text = "9";
                    break;
                case ConditionType.CONDITION_DRUNKENSTATE:
                    ConditionValue1Tooltip.SetToolTip(ConditionValue1NUD, "Sober=0; Tipsy=1, Drunk=2, Smashed=3");
                    ConditionValue2Tooltip.SetToolTip(ConditionValue2NUD, "Always 0");
                    ConditionValue3Tooltip.SetToolTip(ConditionValue3NUD, "Always 0");
                    textBox_ConditionType.Text = "10";
                    break;
                case ConditionType.CONDITION_WORLD_STATE:
                    ConditionValue1Tooltip.SetToolTip(ConditionValue1NUD, "World state index");
                    ConditionValue2Tooltip.SetToolTip(ConditionValue2NUD, "World state value");
                    ConditionValue3Tooltip.SetToolTip(ConditionValue3NUD, "Always 0");
                    textBox_ConditionType.Text = "11";
                    break;
                case ConditionType.CONDITION_ACTIVE_EVENT:
                    ConditionValue1Tooltip.SetToolTip(ConditionValue1NUD, "Event entry (game_event.eventEntry)");
                    ConditionValue2Tooltip.SetToolTip(ConditionValue2NUD, "Always 0");
                    ConditionValue3Tooltip.SetToolTip(ConditionValue3NUD, "Always 0");
                    textBox_ConditionType.Text = "12";
                    break;
                case ConditionType.CONDITION_INSTANCE_INFO:
                    ConditionValue1Tooltip.SetToolTip(ConditionValue1NUD, "entry (see corresponding source script files for info)");
                    ConditionValue2Tooltip.SetToolTip(ConditionValue2NUD, "data (see corresponding script source files for more info)");
                    ConditionValue3Tooltip.SetToolTip(ConditionValue3NUD, "0 = INSTANCE_INFO_DATA\n1 = INSTANCE_INFO_DATA64\n2 = INSTANCE_INFO_BOSS_STATE");
                    textBox_ConditionType.Text = "13";
                    break;
                case ConditionType.CONDITION_QUEST_NONE:
                    ConditionValue1Tooltip.SetToolTip(ConditionValue1NUD, "Quest ID - see quest_template.id");
                    ConditionValue2Tooltip.SetToolTip(ConditionValue2NUD, "Always 0");
                    ConditionValue3Tooltip.SetToolTip(ConditionValue3NUD, "Always 0");
                    textBox_ConditionType.Text = "14";
                    break;
                case ConditionType.CONDITION_CLASS:
                    ConditionValue1Tooltip.SetToolTip(ConditionValue1NUD, "Class mask from ChrClasses.dbc\nAdd flags together for all classes where condition is true.");
                    ConditionValue2Tooltip.SetToolTip(ConditionValue2NUD, "Always 0");
                    ConditionValue3Tooltip.SetToolTip(ConditionValue3NUD, "Always 0");
                    textBox_ConditionType.Text = "15";
                    break;
                case ConditionType.CONDITION_RACE:
                    ConditionValue1Tooltip.SetToolTip(ConditionValue1NUD, "Player must be this race. See ChrRaces.dbc .\nAdd flags together for all races where condition is true.");
                    ConditionValue2Tooltip.SetToolTip(ConditionValue2NUD, "Always 0");
                    ConditionValue3Tooltip.SetToolTip(ConditionValue3NUD, "Always 0");
                    textBox_ConditionType.Text = "16";
                    break;
                case ConditionType.CONDITION_ACHIEVEMENT:
                    ConditionValue1Tooltip.SetToolTip(ConditionValue1NUD, "Achievement ID from Achievement.dbc");
                    ConditionValue2Tooltip.SetToolTip(ConditionValue2NUD, "Always 0");
                    ConditionValue3Tooltip.SetToolTip(ConditionValue3NUD, "Always 0");
                    textBox_ConditionType.Text = "17";
                    break;
                case ConditionType.CONDITION_TITLE:
                    ConditionValue1Tooltip.SetToolTip(ConditionValue1NUD, "Title ID from CharTitles.dbc");
                    ConditionValue2Tooltip.SetToolTip(ConditionValue2NUD, "Always 0");
                    ConditionValue3Tooltip.SetToolTip(ConditionValue3NUD, "Always 0");
                    textBox_ConditionType.Text = "18";
                    break;
                case ConditionType.CONDITION_SPAWNMASK:
                    ConditionValue1Tooltip.SetToolTip(ConditionValue1NUD, "spawnMask from\nCreature.spawnMask / Gameobject.spawnMask");
                    ConditionValue2Tooltip.SetToolTip(ConditionValue2NUD, "Always 0");
                    ConditionValue3Tooltip.SetToolTip(ConditionValue3NUD, "Always 0");
                    textBox_ConditionType.Text = "19";
                    break;
                case ConditionType.CONDITION_GENDER:
                    ConditionValue1Tooltip.SetToolTip(ConditionValue1NUD, "0 = Male, 1 = Female, 2 = None");
                    ConditionValue2Tooltip.SetToolTip(ConditionValue2NUD, "Always 0");
                    ConditionValue3Tooltip.SetToolTip(ConditionValue3NUD, "Always 0");
                    textBox_ConditionType.Text = "20";
                    break;
                case ConditionType.CONDITION_UNIT_STATE:
                    ConditionValue1Tooltip.SetToolTip(ConditionValue1NUD, "UnitState (enum from Unit.h)");
                    ConditionValue2Tooltip.SetToolTip(ConditionValue2NUD, "Always 0");
                    ConditionValue3Tooltip.SetToolTip(ConditionValue3NUD, "Always 0");
                    textBox_ConditionType.Text = "21";
                    break;
                case ConditionType.CONDITION_MAPID:
                    ConditionValue1Tooltip.SetToolTip(ConditionValue1NUD, "Map entry from Map.dbc\n(0=Eastern Kingdoms, 1=Kalimdor, - and so on.)");
                    ConditionValue2Tooltip.SetToolTip(ConditionValue2NUD, "Always 0");
                    ConditionValue3Tooltip.SetToolTip(ConditionValue3NUD, "Always 0");
                    textBox_ConditionType.Text = "22";
                    break;
                case ConditionType.CONDITION_AREAID:
                    ConditionValue1Tooltip.SetToolTip(ConditionValue1NUD, "Area ID from AreaTable.dbc");
                    ConditionValue2Tooltip.SetToolTip(ConditionValue2NUD, "Always 0");
                    ConditionValue3Tooltip.SetToolTip(ConditionValue3NUD, "Always 0");
                    textBox_ConditionType.Text = "23";
                    break;
                case ConditionType.CONDITION_CREATURE_TYPE:
                    ConditionValue1Tooltip.SetToolTip(ConditionValue1NUD, "Creature type from creature_template.type\nTrue if creature_template.type == ConditionValue1");
                    ConditionValue2Tooltip.SetToolTip(ConditionValue2NUD, "Always 0");
                    ConditionValue3Tooltip.SetToolTip(ConditionValue3NUD, "Always 0");
                    textBox_ConditionType.Text = "24";
                    break;
                case ConditionType.CONDITION_SPELL:
                    ConditionValue1Tooltip.SetToolTip(ConditionValue1NUD, "Spell ID from Spell.dbc");
                    ConditionValue2Tooltip.SetToolTip(ConditionValue2NUD, "Always 0");
                    ConditionValue3Tooltip.SetToolTip(ConditionValue3NUD, "Always 0");
                    textBox_ConditionType.Text = "25";
                    break;
                case ConditionType.CONDITION_PHASEID:
                    ConditionValue1Tooltip.SetToolTip(ConditionValue1NUD, "PhaseID value");
                    ConditionValue2Tooltip.SetToolTip(ConditionValue2NUD, "Always 0");
                    ConditionValue3Tooltip.SetToolTip(ConditionValue3NUD, "Always 0");
                    textBox_ConditionType.Text = "26";
                    break;
                case ConditionType.CONDITION_LEVEL:
                    ConditionValue1Tooltip.SetToolTip(ConditionValue1NUD, "Player level (1-80 in 3.3.5 || 1-110 in 7.x)");
                    ConditionValue2Tooltip.SetToolTip(ConditionValue2NUD, "Optional: 0 = Level must be equal, 1 = Level must be higher, 2 = Level must be lower,\n3 = Level must be higher or equal, 4 = Level must be lower or equal.");
                    ConditionValue3Tooltip.SetToolTip(ConditionValue3NUD, "Always 0");
                    textBox_ConditionType.Text = "27";
                    break;
                case ConditionType.CONDITION_QUEST_COMPLETE:
                    ConditionValue1Tooltip.SetToolTip(ConditionValue1NUD, "Quest ID - see quest_template.id");
                    ConditionValue2Tooltip.SetToolTip(ConditionValue2NUD, "Always 0");
                    ConditionValue3Tooltip.SetToolTip(ConditionValue3NUD, "Always 0");
                    textBox_ConditionType.Text = "28";
                    break;
                case ConditionType.CONDITION_NEAR_CREATURE:
                    ConditionValue1Tooltip.SetToolTip(ConditionValue1NUD, "Creature entry from creature_template.entry");
                    ConditionValue2Tooltip.SetToolTip(ConditionValue2NUD, "distance in yards");
                    ConditionValue3Tooltip.SetToolTip(ConditionValue3NUD, "Always 0");
                    textBox_ConditionType.Text = "29";
                    break;
                case ConditionType.CONDITION_NEAR_GAMEOBJECT:
                    ConditionValue1Tooltip.SetToolTip(ConditionValue1NUD, "Gameobject entry from gameobject_template.entry");
                    ConditionValue2Tooltip.SetToolTip(ConditionValue2NUD, "distance in yards");
                    ConditionValue3Tooltip.SetToolTip(ConditionValue3NUD, "Always 0");
                    textBox_ConditionType.Text = "30";
                    break;
                case ConditionType.CONDITION_OBJECT_ENTRY_GUID:
                    ConditionValue1Tooltip.SetToolTip(ConditionValue1NUD, "TypeID. Available object types:"
                    + "\n3 : TYPEID_UNIT"
                    + "\n4 : TYPEID_PLAYER"
                    + "\n5 : TYPEID_GAMEOBJECT"
                    + "\n7 : TYPEID_CORPSE (player corpse, after spirit release)");
                    ConditionValue2Tooltip.SetToolTip(ConditionValue2NUD, "0 = Any object of given TypeID"
                    + "\nif TypeID = TYPEID_UNIT => Creature entry from creature_template.entry"
                    + "\nif TypeID = TYPEID_GAMEOBJECT => Gameobject entry from gameobject_template.entry");
                    ConditionValue3Tooltip.SetToolTip(ConditionValue3NUD, "Always 0");
                    textBox_ConditionType.Text = "31";
                    break;
                case ConditionType.CONDITION_TYPE_MASK:
                    ConditionValue1Tooltip.SetToolTip(ConditionValue1NUD, "TypeMask - a bitmask of following object types:"
                    + "\n0x0008 - TYPEMASK_UNIT (8)"
                    + "\n0x0010 - TYPEMASK_PLAYER (16)"
                    + "\n0x0020 - TYPEMASK_GAMEOBJECT (32)"
                    + "\n0x0080 - TYPEMASK_CORPSE (player corpse after spirit release) (128)");
                    ConditionValue2Tooltip.SetToolTip(ConditionValue2NUD, "Always 0");
                    ConditionValue3Tooltip.SetToolTip(ConditionValue3NUD, "Always 0");
                    textBox_ConditionType.Text = "32";
                    break;
                case ConditionType.CONDITION_RELATION_TO:
                    ConditionValue1Tooltip.SetToolTip(ConditionValue1NUD, "Target to which relation is checked.\n- one of the ConditionTargets available in current SourceType");
                    ConditionValue2Tooltip.SetToolTip(ConditionValue2NUD, "RelationType - defines relation of current ConditionTarget to target specified in ConditionValue1."
                    + "\n0 - RELATION_SELF"
                    + "\n1 - RELATION_IN_PARTY"
                    + "\n2 - RELATION_IN_RAID_OR_PARTY"
                    + "\n3 - RELATION_OWNED_BY (ConditionTarget is owned by ConditionValue1)"
                    + "\n4 - RELATION_PASSENGER_OF (ConditionTarget is passenger of ConditionValue1)"
                    + "\n5 - RELATION_CREATED_BY (ConditionTarget is summoned by ConditionValue1)");
                    ConditionValue3Tooltip.SetToolTip(ConditionValue3NUD, "Always 0");
                    textBox_ConditionType.Text = "33";
                    break;
                case ConditionType.CONDITION_REACTION_TO:
                    ConditionValue1Tooltip.SetToolTip(ConditionValue1NUD, "Target to which reaction is checked.\n- one of the ConditionTargets available in current SourceType");
                    ConditionValue2Tooltip.SetToolTip(ConditionValue2NUD, "rankMask: This bitmask defines the reaction(s) of the current ConditionTarget"
                    + "\nto the target specified in ConditionValue1 (which are allowed)."
                    + "\nFlags for the reactions are:"
                    + "\n  1 = Hated"
                    + "\n  2 = Hostile"
                    + "\n  4 = Unfriendly"
                    + "\n  8 = Neutral"
                    + "\n 16 = Friendly"
                    + "\n 32 = Honored"
                    + "\n 64 = Revered"
                    + "\n128 = Exalted");
                    ConditionValue3Tooltip.SetToolTip(ConditionValue3NUD, "Always 0");
                    textBox_ConditionType.Text = "34";
                    break;
                case ConditionType.CONDITION_DISTANCE_TO:
                    ConditionValue1Tooltip.SetToolTip(ConditionValue1NUD, "Target to which distance is checked\n- one of ConditionTargets available in current SourceType");
                    ConditionValue2Tooltip.SetToolTip(ConditionValue2NUD, "Distance.\nDefines distance between current ConditionTarget and target specified in ConditionValue1");
                    ConditionValue3Tooltip.SetToolTip(ConditionValue3NUD, "ComparisionType:"
                    + "\n0 = distance must be equal to ConditionValue2"
                    + "\n1 = distance must be higher than ConditionValue2"
                    + "\n2 = distance must be lower than ConditionValue2"
                    + "\n3 = distance must be equal to or higher than ConditionValue2"
                    + "\n4 = distance must be equal to or lower than ConditionValue2");
                    textBox_ConditionType.Text = "35";
                    break;
                case ConditionType.CONDITION_ALIVE:
                    ConditionValue1Tooltip.SetToolTip(ConditionValue1NUD, "Always 0 - Use NegativeCondition and the following settings:"
                    + "\nNegativeCondition = 0 if target needs to be ALIVE."
                    + "\nNegativeCondition = 1 if target needs to be DEAD."
                    + "\nNOTE: A creature corpse and a creature that_looks_dead"
                    + "\nare two different things. One is actually dead"
                    + "\nand the other is just using an emote to appear dead. ");
                    ConditionValue2Tooltip.SetToolTip(ConditionValue2NUD, "Always 0");
                    ConditionValue3Tooltip.SetToolTip(ConditionValue3NUD, "Always 0");
                    textBox_ConditionType.Text = "36";
                    break;
                case ConditionType.CONDITION_HP_VAL:
                    ConditionValue1Tooltip.SetToolTip(ConditionValue1NUD, "HP Value");
                    ConditionValue2Tooltip.SetToolTip(ConditionValue2NUD, "ComparisionType:"
                    + "\n0 = HP must be equal"
                    + "\n1 = HP must be higher"
                    + "\n2 = HP must be lesser"
                    + "\n3 = HP must be equal or higher"
                    + "\n4 = HP must be equal or lower");
                    ConditionValue3Tooltip.SetToolTip(ConditionValue3NUD, "Always 0");
                    textBox_ConditionType.Text = "37";
                    break;
                case ConditionType.CONDITION_HP_PCT:
                    ConditionValue1Tooltip.SetToolTip(ConditionValue1NUD, "Percentage of MAX HP");
                    ConditionValue2Tooltip.SetToolTip(ConditionValue2NUD, "ComparisionType:"
                    + "\n0 = HP must be equal"
                    + "\n1 = HP must be higher"
                    + "\n2 = HP must be lesser"
                    + "\n3 = HP must be equal or higher"
                    + "\n4 = HP must be equal or lower");
                    ConditionValue3Tooltip.SetToolTip(ConditionValue3NUD, "Always 0");
                    textBox_ConditionType.Text = "38";
                    break;
                case ConditionType.CONDITION_REALM_ACHIEVEMENT:
                    ConditionValue1Tooltip.SetToolTip(ConditionValue1NUD, "Achievement ID from Achievement.dbc");
                    ConditionValue2Tooltip.SetToolTip(ConditionValue2NUD, "Always 0");
                    ConditionValue3Tooltip.SetToolTip(ConditionValue3NUD, "Always 0");
                    textBox_ConditionType.Text = "39";
                    break;
                case ConditionType.CONDITION_IN_WATER:
                    ConditionValue1Tooltip.SetToolTip(ConditionValue1NUD, "Always 0 - Use NegativeCondition and the following settings:"
                    + "\nNegativeCondition = 0 If target needs to be on land"
                    + "\nNegativeCondition = 1 If target needs to be in water");
                    ConditionValue2Tooltip.SetToolTip(ConditionValue2NUD, "Always 0");
                    ConditionValue3Tooltip.SetToolTip(ConditionValue3NUD, "Always 0");
                    textBox_ConditionType.Text = "40";
                    break;
                case ConditionType.CONDITION_TERRAIN_SWAP:
                    ConditionValue1Tooltip.SetToolTip(ConditionValue1NUD, "terrainSwap - true if object is in terrainswap [ 6.x only ]");
                    ConditionValue2Tooltip.SetToolTip(ConditionValue2NUD, "Always 0");
                    ConditionValue3Tooltip.SetToolTip(ConditionValue3NUD, "Always 0");
                    textBox_ConditionType.Text = "41";
                    break;
                case ConditionType.CONDITION_STAND_STATE:
                    ConditionValue1Tooltip.SetToolTip(ConditionValue1NUD, "stateType (exact or any): 0 = Exact state used in ConditionValue2 1 = Any type of state in ConditionValue2");
                    ConditionValue2Tooltip.SetToolTip(ConditionValue2NUD, "Exact stand state, or generic state (stand / sit), depending on value 1\n0 = Standing 1 = Sitting");
                    ConditionValue3Tooltip.SetToolTip(ConditionValue3NUD, "Always 0");
                    textBox_ConditionType.Text = "42";
                    break;
                case ConditionType.CONDITION_MAX:           
                    textBox_ConditionType.Text = "43";
                    break;
                default:
                    ConditionValue1Tooltip.SetToolTip(ConditionValue1NUD, "");
                    ConditionValue2Tooltip.SetToolTip(ConditionValue2NUD, "");
                    ConditionValue3Tooltip.SetToolTip(ConditionValue3NUD, "");
                    break;
            }
        }

        private void GenerateConditionBTN_Click(object sender, EventArgs e)
        {
            _GenerateSqlCode(sender, e);

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

        // This is for all textBoxes
        private void textBox_sourceType_TextChanged(object sender, EventArgs e)
        {
            label_Executed_Successfully.Visible = false;
            label87.Visible = false;
            label88.Visible = false;
        }

        // This is for all NumericUpDown textBoxes
        private void SourceEntryNUD_ValueChanged(object sender, EventArgs e)
        {
            label_Executed_Successfully.Visible = false;
            label87.Visible = false;
            label88.Visible = false;
        }

        // Close Application
        private void label2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        // X button (Close)
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
        //==========================================================

            // Minimize button
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

        private void label1_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }
        //==========================================================

            //Back to Main Menu button
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
            BackToMainMenu backtomainmenu = new BackToMainMenu(form_MM);
            backtomainmenu.Show();
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

        int idx = 1;
        DateTime dt = new DateTime();
        private void timer2_Tick(object sender, EventArgs e)
        {
            label_stopwatch.Text = dt.AddSeconds(idx).ToString("HH:mm:ss");
            idx++;
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

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("http://emucraft.com");
        }

        private void label86_Click(object sender, EventArgs e)
        {
            _GenerateSqlCode(sender, e);
            Clipboard.SetText(stringSQLShare);
            label87.Visible = true;
        }

        private void label83_Click(object sender, EventArgs e)
        {
            _GenerateSqlCode(sender, e);

            using (var sfd = new SaveFileDialog())
            {
                sfd.Filter = "sql files (*.sql)|*.sql";
                sfd.FilterIndex = 2;
                sfd.FileName = "Condition_" + SourceTypeOrReferenceIDCMB.Text;

                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    File.WriteAllText(sfd.FileName, stringSQLShare);
                    label88.Visible = true;
                }
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
    }
}
