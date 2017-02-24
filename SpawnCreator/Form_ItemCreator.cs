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
using System.Threading;
using System.IO;

namespace SpawnCreator
{
    public partial class Form_ItemCreator : Form
    {
        public Form_ItemCreator()
        {
            InitializeComponent();
        }
        Form_MainMenu mainmenu = new Form_MainMenu();
        // Fix flickering .. still showing a flicker at the top left corner, wtf? really?
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.ExStyle |= 0x02000000;  // Turn on WS_EX_COMPOSITED
                return cp;
            }
        }

        // Used to get values from SocketBonus Form
        public void GetSocketBonusData(int o_sC1, int o_sCC1, int o_sC2, int o_sCC2, int o_sC3, int o_sCC3, int o_sB)
        {
            InitializeComponent();
            output_socketColor1 = o_sC1;
            output_socketContent1 = o_sCC1;
            output_socketColor2 = o_sC2;
            output_socketContent2 = o_sCC2;
            output_socketColor3 = o_sC3;
            output_socketContent3 = o_sCC3;
            output_socketBonus = o_sB;
        }
        
        public static int output_socketColor1;
        public static int output_socketContent1;
        public static int output_socketColor2;
        public static int output_socketContent2;
        public static int output_socketColor3;
        public static int output_socketContent3;
        public static int output_socketBonus;

        public static string stringSQLShare;
        public static string stringEntryShare;

        private void Form2_Load(object sender, EventArgs e)
        {
            
            timer1.Start(); //Check if MySQL is still running
            timer2.Start(); //Stopwatch
            comboBox29.SelectedIndex = 0; // INSERT

            //MySqlConnection connection = new MySqlConnection("datasource=" + mainmenu.textbox_mysql_hostname.Text + ";port=" + mainmenu.textbox_mysql_port.Text + ";username=" + mainmenu.textbox_mysql_username.Text + ";password=" + mainmenu.textbox_mysql_pass.Text);
            //string insertQuery = "SELECT max(entry)+1 FROM " + mainmenu.textbox_mysql_worldDB.Text + ".item_template;";
            ////string insertQuery = textBox_SelectMaxPlus1.Text;
            //connection.Open();
            //MySqlCommand command = new MySqlCommand(insertQuery, connection);

            //try
            //{

            //    textBox1.Text = command.ExecuteScalar().ToString();
            //    //label_query_executed_successfully2.Visible = false;

            //    if (command.ExecuteNonQuery() >= 1)
            //    {
            //        textBox1.Text = command.ExecuteScalar().ToString();
            //        //label7.Visible = true;
            //        //label_query_executed_successfully2.Visible = false;
            //    }
            //    else
            //    {
            //        textBox1.Text = command.ExecuteScalar().ToString();
            //        //MessageBox.Show("Data Not Inserted");
            //        //label2.ForeColor = Color.Red;
            //        //label2.Text = "Eroare!";
            //        //MessageBox.Show("Unable to connect to any of the specified MySQL hosts.");
            //    }
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.Message);
            //}
            //connection.Close();

            comboBox1.SelectedIndex = 2; // show default 'Uncommon (green)
            comboBox2.SelectedIndex = 0; // show default first item
            comboBox3.SelectedIndex = 0; // show default first item
            comboBox4.SelectedIndex = 0; // show default first item
            comboBox5.SelectedIndex = 0; // show default first item
            comboBox6.SelectedIndex = 0; // show default first item
            comboBox7.SelectedIndex = 1; // show default 'not defined'
            comboBox8.SelectedIndex = 0; // show default first item
            comboBox9.SelectedIndex = 0; // show default first item
            comboBox10.SelectedIndex = 0; // show default first item
            comboBox11.SelectedIndex = 0; // show default first item
            comboBox12.SelectedIndex = 0; // show default first item
            comboBox13.SelectedIndex = 0; // show default first item
            comboBox14.SelectedIndex = 0; // show default first item
            comboBox15.SelectedIndex = 0; // show default first item
            comboBox16.SelectedIndex = 0; // show default first item
            comboBox17.SelectedIndex = 0; // show default first item
            comboBox18.SelectedIndex = 0; // show default first item
            comboBox19.SelectedIndex = 0; // show default first item
            comboBox20.SelectedIndex = 0; // show default first item
            comboBox21.SelectedIndex = 0; // show default first item
            comboBox22.SelectedIndex = 0; // show default first item
            comboBox23.SelectedIndex = 0; // show default first item
            comboBox24.SelectedIndex = 0; // show default first item
            comboBox25.SelectedIndex = 0; // show default first item
            comboBox26.SelectedIndex = 0; // show default first item
            comboBox27.SelectedIndex = 0; // show default first item
            comboBox28.SelectedIndex = 0; // show default first item
            SpawnFunctions.LoadIndexes();
        }

        private void _Generate(object sender, EventArgs e)
        {
            int socketColor1;
            switch (output_socketColor1)
            {
                case 0:
                    socketColor1 = 0; // No Socket
                    break;
                case 1:
                    socketColor1 = 1; // Meta
                    break;
                case 2:
                    socketColor1 = 2; // Red
                    break;
                case 3:
                    socketColor1 = 4; // Yellow
                    break;
                case 4:
                    socketColor1 = 8; // Blue
                    break;
                default:
                    socketColor1 = 0; // No Socket
                    break;
            }

            int socketColor2;
            switch (output_socketColor2)
            {
                case 0:
                    socketColor2 = 0; // No Socket
                    break;
                case 1:
                    socketColor2 = 1; // Meta
                    break;
                case 2:
                    socketColor2 = 2; // Red
                    break;
                case 3:
                    socketColor2 = 4; // Yellow
                    break;
                case 4:
                    socketColor2 = 8; // Blue
                    break;
                default:
                    socketColor2 = 0; // No Socket
                    break;
            }

            int socketColor3;
            switch (output_socketColor3)
            {
                case 0:
                    socketColor3 = 0; // No Socket
                    break;
                case 1:
                    socketColor3 = 1; // Meta
                    break;
                case 2:
                    socketColor3 = 2; // Red
                    break;
                case 3:
                    socketColor3 = 4; // Yellow
                    break;
                case 4:
                    socketColor3 = 8; // Blue
                    break;
                default:
                    socketColor3 = 0; // No Socket
                    break;
            }

            int totemCategory;
            switch (comboBox8.SelectedIndex)
            {
                case 0:
                    totemCategory = 0; // none
                    break;
                case 1:
                    totemCategory = 1; // Skinning Knife (OLD)
                    break;
                case 2:
                    totemCategory = 2; // Earth Totem
                    break;
                case 3:
                    totemCategory = 3; // Air Totem
                    break;
                case 4:
                    totemCategory = 4; // Fire Totem
                    break;
                case 5:
                    totemCategory = 5; // Water Totem
                    break;
                case 6:
                    totemCategory = 6; // Runed Copper Rod
                    break;
                case 7:
                    totemCategory = 7; // Runed Silver Rod
                    break;
                case 8:
                    totemCategory = 8; // Runed Golden Rod
                    break;
                case 9:
                    totemCategory = 9; // Runed Truesilver Rod
                    break;
                case 10:
                    totemCategory = 10; // Runed Arcanite Rod
                    break;
                case 11:
                    totemCategory = 11; // Mining Pick (OLD)
                    break;
                case 12:
                    totemCategory = 12; // Philosopher's Stone
                    break;
                case 13:
                    totemCategory = 13; // Blacksmith Hammer (OLD
                    break;
                case 14:
                    totemCategory = 14; // Arclight Spanner
                    break;
                case 15:
                    totemCategory = 15; // Gyromatic Micro-Adjustor
                    break;
                case 16:
                    totemCategory = 21; // Master Totem
                    break;
                case 17:
                    totemCategory = 41; // Runed Fel Iron Rod
                    break;
                case 18:
                    totemCategory = 62; // Runed Adamantite Rod
                    break;
                case 19:
                    totemCategory = 63; // Runed Eternium Rod
                    break;
                case 20:
                    totemCategory = 81; // Hollow Quill
                    break;
                case 21:
                    totemCategory = 101; // Runed Azurite Rod
                    break;
                case 22:
                    totemCategory = 121; // Virtuoso Inking Set
                    break;
                case 23:
                    totemCategory = 141; // Drums
                    break;
                case 24:
                    totemCategory = 161; // Gnomish Army Knife
                    break;
                case 25:
                    totemCategory = 162; // Blacksmith Hammer
                    break;
                case 26:
                    totemCategory = 165; // Mining Pick
                    break;
                case 27:
                    totemCategory = 166; // Skinning Knife
                    break;
                case 28:
                    totemCategory = 167; // Hammer Pick
                    break;
                case 29:
                    totemCategory = 168; // Bladed Pickaxe
                    break;
                case 30:
                    totemCategory = 169; // Flint and Tinder
                    break;
                case 31:
                    totemCategory = 189; // Runed Cobalt Rod
                    break;
                case 32:
                    totemCategory = 190; // Runed Titanium Rod
                    break;
                default:
                    totemCategory = 0;
                    break;
            }

            int classMaskE = -1;
            UInt32 flagMasksE = 0;
            int raceMaskE = -1;
            int flagExtraMaskE = 0;
            int BagFamilyMasksE = 0;
            int flagCustomE = 0;

            string[] checkedIndicies1 = Properties.Settings.Default.ClassMasks.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
            for (int i1 = 0; i1 < checkedIndicies1.Length; i1++)
            {
                int idx;
                if ((int.TryParse(checkedIndicies1[i1], out idx)))
                {
                    // fix issue with class mask
                    if (idx >= 0)
                        classMaskE = 0;

                    switch (idx)
                    {
                        case 0: // warrior
                            classMaskE += 1;
                            break;
                        case 1: // paladin
                            classMaskE += 2;
                            break;
                        case 2: // hunter
                            classMaskE += 4;
                            break;
                        case 3: // rogue
                            classMaskE += 8;
                            break;
                        case 4: // priest
                            classMaskE += 16;
                            break;
                        case 5: // deathknight
                            classMaskE += 32;
                            break;
                        case 6: // shaman
                            classMaskE += 64;
                            break;
                        case 7: // mage
                            classMaskE += 128;
                            break;
                        case 8: // warlock
                            classMaskE += 256;
                            break;
                        case 9: // druid
                            classMaskE += 1024;
                            break;
                    }
                }
            }

            string[] checkedIndicies2 = Properties.Settings.Default.FlagMasks.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
            for (int i1 = 0; i1 < checkedIndicies2.Length; i1++)
            {
                int idx;
                if ((int.TryParse(checkedIndicies2[i1], out idx)))
                {
                    switch (idx)
                    {
                        case 0: // UNK1
                            flagMasksE += 0x01;
                            break;
                        case 1: // conjured item
                            flagMasksE += 0x02;
                            break;
                        case 2: // Openable (can be opened by right-click)
                            flagMasksE += 0x04;
                            break;
                        case 3: // Makes green "Heroic" text appear on item
                            flagMasksE += 0x08;
                            break;
                        case 4: // Deprecated Item
                            flagMasksE += 0x010;
                            break;
                        case 5: // Item can not be destroyed, except by using spell (item can be reagent for spell)
                            flagMasksE += 0x020;
                            break;
                        case 6: // UNK2
                            flagMasksE += 0x040;
                            break;
                        case 7: // No default 30 seconds cooldown when equipped
                            flagMasksE += 0x080;
                            break;
                        case 8: // UNK3
                            flagMasksE += 0x0100;
                            break;
                        case 9: // Wrapper : Item can wrap other items
                            flagMasksE += 0x0200;
                            break;
                        case 10: // UNK4
                            flagMasksE += 0x0400;
                            break;
                        case 11: // Item is party loot and can be looted by all
                            flagMasksE += 0x0800;
                            break;
                        case 12: // Item is refundable
                            flagMasksE += 0x01000;
                            break;
                        case 13: // Charter (Arena or Guild)
                            flagMasksE += 0x02000;
                            break;
                        case 14: // UNK5 // comment in code : Only readable items have this (but not all)
                            flagMasksE += 0x04000;
                            break;
                        case 15: // UNK6
                            flagMasksE += 0x08000;
                            break;
                        case 16: // UNK7
                            flagMasksE += 0x010000;
                            break;
                        case 17: // UNK8
                            flagMasksE += 0x020000;
                            break;
                        case 18: // Item can be prospected
                            flagMasksE += 0x040000;
                            break;
                        case 19: // Unique equipped (player can only have one equipped at the same time)
                            flagMasksE += 0x080000;
                            break;
                        case 20: // UNK9
                            flagMasksE += 0x0100000;
                            break;
                        case 21: // Item can be used during arena match
                            flagMasksE += 0x0200000;
                            break;
                        case 22: // Throwable (for tooltip ingame)
                            flagMasksE += 0x0400000;
                            break;
                        case 23: // Item can be used in shapeshift forms
                            flagMasksE += 0x0800000;
                            break;
                        case 24: // UNK10
                            flagMasksE += 0x01000000;
                            break;
                        case 25: // Profession recipes: can only be looted if you meet requirements and don't already know it
                            flagMasksE += 0x02000000;
                            break;
                        case 26: //  Item cannot be used in arena
                            flagMasksE += 0x04000000;
                            break;
                        case 27: // Bind to Account (Also needs Quality = 7 set)
                            flagMasksE += 0x08000000;
                            break;
                        case 28: // Spell is cast with triggered flag
                            flagMasksE += 0x010000000;
                            break;
                        case 29: // Millable
                            flagMasksE += 0x020000000;
                            break;
                        case 30: // UNK11
                            flagMasksE += 0x040000000;
                            break;
                        case 31: // Bind on Pickup tradeable
                            flagMasksE += 2147483648;
                            break;
                    }
                }
            }

            string[] checkedIndicies3 = Properties.Settings.Default.RaceMasks.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
            for (int i1 = 0; i1 < checkedIndicies3.Length; i1++)
            {
                int idx;
                if ((int.TryParse(checkedIndicies3[i1], out idx)))
                {
                    switch (idx)
                    {
                        case 0: // human
                            raceMaskE += 1;
                            break;
                        case 1: // orc
                            raceMaskE += 2;
                            break;
                        case 2: // dwarf
                            raceMaskE += 4;
                            break;
                        case 3: // nightelf
                            raceMaskE += 8;
                            break;
                        case 4: // undead
                            raceMaskE += 16;
                            break;
                        case 5: // tauren
                            raceMaskE += 32;
                            break;
                        case 6: // gnome
                            raceMaskE += 64;
                            break;
                        case 7: // troll
                            raceMaskE += 128;
                            break;
                        case 8: // bloodelf
                            raceMaskE += 512;
                            break;
                        case 9: // draenei
                            raceMaskE += 1024;
                            break;
                    }
                }
            }

            string[] checkedIndicies4 = Properties.Settings.Default.FlagExtraMasks.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
            for (int i1 = 0; i1 < checkedIndicies4.Length; i1++)
            {
                int idx;
                if ((int.TryParse(checkedIndicies4[i1], out idx)))
                {
                    switch (idx)
                    {
                        case 0: // Horde Only
                            flagExtraMaskE += 0x01;
                            break;
                        case 1: // Alliance Only
                            flagExtraMaskE += 0x02;
                            break;
                        case 2: // When item uses ExtendedCost in npc_vendor, gold is also required
                            flagExtraMaskE += 0x04;
                            break;
                        case 3: // Makes need roll for this item disabled
                            flagExtraMaskE += 0x0100;
                            break;
                        case 4: // NEED_ROLL_DISABLED
                            flagExtraMaskE += 0x0200;
                            break;
                    }
                }
            }

            string[] checkedIndicies5 = Properties.Settings.Default.BagFamilyMasks.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
            for (int i1 = 0; i1 < checkedIndicies5.Length; i1++)
            {
                int idx;
                if ((int.TryParse(checkedIndicies5[i1], out idx)))
                {
                    switch (idx)
                    {
                        case 0: // none
                            BagFamilyMasksE += 0;
                            break;
                        case 1: // Arrows
                            BagFamilyMasksE += 1;
                            break;
                        case 2: // bullets
                            BagFamilyMasksE += 2;
                            break;
                        case 3: // Soul Shards
                            BagFamilyMasksE += 4;
                            break;
                        case 4: // Leatherworking Supplies
                            BagFamilyMasksE += 8;
                            break;
                        case 5: // Inscription Supplies
                            BagFamilyMasksE += 16;
                            break;
                        case 6: // Herbs
                            BagFamilyMasksE += 32;
                            break;
                        case 7: // Enchanting Supplies
                            BagFamilyMasksE += 64;
                            break;
                        case 8: // Engineering Supplies
                            BagFamilyMasksE += 128;
                            break;
                        case 9: // Keys
                            BagFamilyMasksE += 256;
                            break;
                        case 10: // Gems
                            BagFamilyMasksE += 512;
                            break;
                        case 11: // Mining Supplies
                            BagFamilyMasksE += 1024;
                            break;
                        case 12: // Soulbound Equipment
                            BagFamilyMasksE += 2048;
                            break;
                        case 13: // Vanity Pets
                            BagFamilyMasksE += 4096;
                            break;
                        case 14: // Currency Tokens
                            BagFamilyMasksE += 8192;
                            break;
                        case 15: // Quest Items
                            BagFamilyMasksE += 16384;
                            break;
                    }
                }
            }

            string[] checkedIndicies6 = Properties.Settings.Default.FlagCustom.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
            for (int i1 = 0; i1 < checkedIndicies6.Length; i1++)
            {
                int idx;
                if ((int.TryParse(checkedIndicies6[i1], out idx)))
                {
                    switch (idx)
                    {
                        case 0: // Item duration will tick even if player is offline
                            flagCustomE += 1;
                            break;
                        case 1: // No quest status will be checked when this item drops
                            flagCustomE += 2;
                            break;
                        case 2: // Item will always follow group/master/need before greed looting rules
                            flagCustomE += 4;
                            break;
                    }
                }
            }
            Form_MainMenu mainmenu = new Form_MainMenu();
            // Prepare SQL
            // select insertion columns
            string BuildSQLFile;
            BuildSQLFile = textBox105.Text + " INTO " + mainmenu.textbox_mysql_worldDB.Text + ".item_template (entry, quality, class, subclass, name, description, ";
            BuildSQLFile += "displayid, inventorytype, bonding, buycount, buyprice, sellprice, stackable, maxcount, ";
            BuildSQLFile += "sheath, material, itemlevel, itemset, randomproperty, randomsuffix, gemproperties, ";
            BuildSQLFile += "socketColor_1, socketContent_1, socketColor_2, socketContent_2, socketColor_3, socketContent_3, ";
            BuildSQLFile += "socketbonus, totemcategory, foodtype, scriptname, statsCount, stat_type1, stat_type2, stat_type3, stat_type4, ";
            BuildSQLFile += "stat_type5, stat_type6, stat_type7, stat_type8, stat_type9, stat_type10, stat_value1, ";
            BuildSQLFile += "stat_value2, stat_value3, stat_value4, stat_value5, stat_value6, stat_value7, stat_value8, ";
            BuildSQLFile += "stat_value9, stat_value10, scalingStatDistribution, scalingStatValue, AllowableClass, ";
            BuildSQLFile += "AllowableRace, flags, flagsExtra, bagFamily, flagsCustom, armor, block, armorDamageModifier, ";
            BuildSQLFile += "MaxDurability, holy_res, frost_res, fire_res, shadow_res, nature_res, arcane_res, rangedModRange, ";
            BuildSQLFile += "ammo_type, dmg_type1, dmg_min1, dmg_max1, dmg_type2, dmg_min2, dmg_max2, requiredLevel, ";
            BuildSQLFile += "requiredReputationFaction, requiredReputationRank, requiredSkill, requiredSkillRank, ";
            BuildSQLFile += "requiredSpell, requiredCityRank, requiredHonorRank, delay, duration, requiredDisenchantSkill, ";
            BuildSQLFile += "disenchantID, containerSlots, itemLimitCategory, SoundOverrideSubclass, holidayID, map, `area`, ";
            BuildSQLFile += "minMoneyLoot, maxMoneyLoot, pageMaterial, pageText, languageID, lockID, startQuest, verifiedBuild, ";
            BuildSQLFile += "spellID_1, spellTrigger_1, spellCharges_1, spellppmRate_1, spellCooldown_1, spellcategory_1, spellcategorycooldown_1, ";
            BuildSQLFile += "spellID_2, spellTrigger_2, spellCharges_2, spellppmRate_2, spellCooldown_2, spellcategory_2, spellcategorycooldown_2, ";
            BuildSQLFile += "spellID_3, spellTrigger_3, spellCharges_3, spellppmRate_3, spellCooldown_3, spellcategory_3, spellcategorycooldown_3, ";
            BuildSQLFile += "spellID_4, spellTrigger_4, spellCharges_4, spellppmRate_4, spellCooldown_4, spellcategory_4, spellcategorycooldown_4, ";
            BuildSQLFile += "spellID_5, spellTrigger_5, spellCharges_5, spellppmRate_5, spellCooldown_5, spellcategory_5, spellcategorycooldown_5) ";
            BuildSQLFile += "VALUES\n";
            BuildSQLFile += "(";

            // values now
            BuildSQLFile += textBox1.Text + ", "; // entry
            BuildSQLFile += comboBox1.SelectedIndex + ", "; // quality
            BuildSQLFile += comboBox2.SelectedIndex + ", "; // class
            BuildSQLFile += comboBox3.SelectedIndex + ", "; // subclass
            BuildSQLFile += "'" + textBox2.Text + "', "; // name
            BuildSQLFile += "'" + textBox3.Text + "', "; // description
            BuildSQLFile += textBox4.Text + ", "; // displayid

            // another fix for inventoryType if weapon is two handed
            if (comboBox2.SelectedIndex == 2) // classID: weapon
            {
                // check if subclass is two handed x...
                switch (comboBox3.SelectedIndex)
                {
                    case 1: // subclassid 1 two handed axes
                        BuildSQLFile += 17 + ", "; // inventorytype two handed
                        break;
                    case 5: // subclassid 5 two handed maces
                        BuildSQLFile += 17 + ", "; // inventorytype two handed
                        break;
                    case 6: // subclassid 6 polearm
                        BuildSQLFile += 17 + ", "; // inventorytype two handed
                        break;
                    case 8: // subclassid 7 two handed swords
                        BuildSQLFile += 17 + ", "; // inventorytype two handed
                        break;
                    case 10: // subclassid 10 staff
                        BuildSQLFile += 17 + ", "; // inventorytype two handed
                        break;
                    case 17: // subclassid 17 spear
                        BuildSQLFile += 17 + ", "; // inventorytype two handed
                        break;
                    default:
                        BuildSQLFile += comboBox4.SelectedIndex + ", "; // inventorytype
                        break;
                }
            }
            else
                BuildSQLFile += comboBox4.SelectedIndex + ", "; // inventorytype

            BuildSQLFile += comboBox5.SelectedIndex + ", "; // bonding
            BuildSQLFile += textBox5.Text + ", "; // buycount
            BuildSQLFile += textBox6.Text + ", "; // buyprice
            BuildSQLFile += textBox7.Text + ", "; // sellprice
            BuildSQLFile += textBox8.Text + ", "; // stackable
            BuildSQLFile += textBox9.Text + ", "; // maxcount
            BuildSQLFile += comboBox6.SelectedIndex + ", "; // sheath
            BuildSQLFile += comboBox7.SelectedIndex + ", "; // material
            BuildSQLFile += textBox10.Text + ", "; // itemlevel
            BuildSQLFile += textBox11.Text + ", "; // itemset
            BuildSQLFile += textBox12.Text + ", "; // randomProperty
            BuildSQLFile += textBox13.Text + ", "; // randomSuffix
            BuildSQLFile += textBox14.Text + ", "; // gemProperties
            BuildSQLFile += socketColor1 + ", "; // socketColor1
            BuildSQLFile += output_socketContent1 + ", "; // socketContent1
            BuildSQLFile += socketColor2 + ", "; // socketColor2
            BuildSQLFile += output_socketContent2 + ", "; // socketContent2
            BuildSQLFile += socketColor3 + ", "; // socketColor3
            BuildSQLFile += output_socketContent3 + ", "; // socketContent3
            BuildSQLFile += output_socketBonus + ", "; // socketBonus
            BuildSQLFile += totemCategory + ", "; // totemCategory
            BuildSQLFile += comboBox9.SelectedIndex + ", "; // foodtype
            BuildSQLFile += "'" + textBox15.Text + "', "; // scriptName
            BuildSQLFile += "10, ";

            // blame wiki
            int stat_type1 = comboBox10.SelectedIndex;
            switch (stat_type1)
            {
                case 2:
                    stat_type1 = 3; // agility
                    break;
                case 3:
                    stat_type1 = 4; // strength
                    break;
                case 4:
                    stat_type1 = 5; // intellect
                    break;
                case 5:
                    stat_type1 = 6; // spirit
                    break;
                case 6:
                    stat_type1 = 7; // stamina
                    break;
            }
            // blame wiki
            int stat_type2 = comboBox11.SelectedIndex;
            switch (stat_type2)
            {
                case 2:
                    stat_type2 = 3; // agility
                    break;
                case 3:
                    stat_type2 = 4; // strength
                    break;
                case 4:
                    stat_type2 = 5; // intellect
                    break;
                case 5:
                    stat_type2 = 6; // spirit
                    break;
                case 6:
                    stat_type2 = 7; // stamina
                    break;
            }
            // blame wiki
            int stat_type3 = comboBox12.SelectedIndex;
            switch (stat_type3)
            {
                case 2:
                    stat_type3 = 3; // agility
                    break;
                case 3:
                    stat_type3 = 4; // strength
                    break;
                case 4:
                    stat_type3 = 5; // intellect
                    break;
                case 5:
                    stat_type3 = 6; // spirit
                    break;
                case 6:
                    stat_type3 = 7; // stamina
                    break;
            }
            // blame wiki
            int stat_type4 = comboBox13.SelectedIndex;
            switch (stat_type4)
            {
                case 2:
                    stat_type4 = 3; // agility
                    break;
                case 3:
                    stat_type4 = 4; // strength
                    break;
                case 4:
                    stat_type4 = 5; // intellect
                    break;
                case 5:
                    stat_type4 = 6; // spirit
                    break;
                case 6:
                    stat_type4 = 7; // stamina
                    break;
            }
            // blame wiki
            int stat_type5 = comboBox14.SelectedIndex;
            switch (stat_type5)
            {
                case 2:
                    stat_type5 = 3; // agility
                    break;
                case 3:
                    stat_type5 = 4; // strength
                    break;
                case 4:
                    stat_type5 = 5; // intellect
                    break;
                case 5:
                    stat_type5 = 6; // spirit
                    break;
                case 6:
                    stat_type5 = 7; // stamina
                    break;
            }
            // blame wiki
            int stat_type6 = comboBox15.SelectedIndex;
            switch (stat_type6)
            {
                case 2:
                    stat_type6 = 3; // agility
                    break;
                case 3:
                    stat_type6 = 4; // strength
                    break;
                case 4:
                    stat_type6 = 5; // intellect
                    break;
                case 5:
                    stat_type6 = 6; // spirit
                    break;
                case 6:
                    stat_type6 = 7; // stamina
                    break;
            }
            // blame wiki
            int stat_type7 = comboBox16.SelectedIndex;
            switch (stat_type7)
            {
                case 2:
                    stat_type7 = 3; // agility
                    break;
                case 3:
                    stat_type7 = 4; // strength
                    break;
                case 4:
                    stat_type7 = 5; // intellect
                    break;
                case 5:
                    stat_type7 = 6; // spirit
                    break;
                case 6:
                    stat_type7 = 7; // stamina
                    break;
            }
            // blame wiki
            int stat_type8 = comboBox17.SelectedIndex;
            switch (stat_type8)
            {
                case 2:
                    stat_type8 = 3; // agility
                    break;
                case 3:
                    stat_type8 = 4; // strength
                    break;
                case 4:
                    stat_type8 = 5; // intellect
                    break;
                case 5:
                    stat_type8 = 6; // spirit
                    break;
                case 6:
                    stat_type8 = 7; // stamina
                    break;
            }
            // blame wiki
            int stat_type9 = comboBox18.SelectedIndex;
            switch (stat_type9)
            {
                case 2:
                    stat_type9 = 3; // agility
                    break;
                case 3:
                    stat_type9 = 4; // strength
                    break;
                case 4:
                    stat_type9 = 5; // intellect
                    break;
                case 5:
                    stat_type9 = 6; // spirit
                    break;
                case 6:
                    stat_type9 = 7; // stamina
                    break;
            }
            // blame wiki
            int stat_type10 = comboBox19.SelectedIndex;
            switch (stat_type10)
            {
                case 2:
                    stat_type10 = 3; // agility
                    break;
                case 3:
                    stat_type10 = 4; // strength
                    break;
                case 4:
                    stat_type10 = 5; // intellect
                    break;
                case 5:
                    stat_type10 = 6; // spirit
                    break;
                case 6:
                    stat_type10 = 7; // stamina
                    break;
            }

            if (comboBox10.SelectedIndex > 6) // stat_type1
                BuildSQLFile += Convert.ToInt32(comboBox10.SelectedIndex + 5) + ", ";
            else
                BuildSQLFile += stat_type1 + ", ";

            if (comboBox11.SelectedIndex > 6) // stat_type2
                BuildSQLFile += Convert.ToInt32(comboBox11.SelectedIndex + 5) + ", ";
            else
                BuildSQLFile += stat_type2 + ", ";

            if (comboBox12.SelectedIndex > 6) // stat_type3
                BuildSQLFile += Convert.ToInt32(comboBox12.SelectedIndex + 5) + ", ";
            else
                BuildSQLFile += stat_type3 + ", ";

            if (comboBox13.SelectedIndex > 6) // stat_type4
                BuildSQLFile += Convert.ToInt32(comboBox13.SelectedIndex + 5) + ", ";
            else
                BuildSQLFile += stat_type4 + ", ";

            if (comboBox14.SelectedIndex > 6) // stat_type5
                BuildSQLFile += Convert.ToInt32(comboBox14.SelectedIndex + 5) + ", ";
            else
                BuildSQLFile += stat_type5 + ", ";

            if (comboBox15.SelectedIndex > 6) // stat_type6
                BuildSQLFile += Convert.ToInt32(comboBox15.SelectedIndex + 5) + ", ";
            else
                BuildSQLFile += stat_type6 + ", ";

            if (comboBox16.SelectedIndex > 6) // stat_type7
                BuildSQLFile += Convert.ToInt32(comboBox16.SelectedIndex + 5) + ", ";
            else
                BuildSQLFile += stat_type7 + ", ";

            if (comboBox17.SelectedIndex > 6) // stat_type8
                BuildSQLFile += Convert.ToInt32(comboBox17.SelectedIndex + 5) + ", ";
            else
                BuildSQLFile += stat_type8 + ", ";

            if (comboBox18.SelectedIndex > 6) // stat_type9
                BuildSQLFile += Convert.ToInt32(comboBox18.SelectedIndex + 5) + ", ";
            else
                BuildSQLFile += stat_type9 + ", ";

            if (comboBox19.SelectedIndex > 6) // stat_type10
                BuildSQLFile += Convert.ToInt32(comboBox19.SelectedIndex + 5) + ", ";
            else
                BuildSQLFile += stat_type10 + ", ";

            BuildSQLFile += textBox16.Text + ", "; // stat_value1
            BuildSQLFile += textBox17.Text + ", "; // stat_value2
            BuildSQLFile += textBox18.Text + ", "; // stat_value3
            BuildSQLFile += textBox19.Text + ", "; // stat_value4
            BuildSQLFile += textBox20.Text + ", "; // stat_value5
            BuildSQLFile += textBox21.Text + ", "; // stat_value6
            BuildSQLFile += textBox22.Text + ", "; // stat_value7
            BuildSQLFile += textBox23.Text + ", "; // stat_value8
            BuildSQLFile += textBox24.Text + ", "; // stat_value9
            BuildSQLFile += textBox25.Text + ", "; // stat_value10
            BuildSQLFile += textBox26.Text + ", "; // scalingStatDistribution
            BuildSQLFile += textBox27.Text + ", "; // scalingStatValue

            if (classMaskE == 0) // fix 
                BuildSQLFile += "-1" + ", "; // allowableClass
            else
                BuildSQLFile += classMaskE + ", "; // allowableClass

            if (raceMaskE == 0) // fix 
                BuildSQLFile += "-1" + ", "; // allowableRace
            else
                BuildSQLFile += raceMaskE + ", "; // allowableRace

            BuildSQLFile += flagMasksE + ", "; // flags
            BuildSQLFile += flagExtraMaskE + ", "; // flagsExtra
            BuildSQLFile += BagFamilyMasksE + ", "; // bagFamily
            BuildSQLFile += flagCustomE + ", "; // flagCustom
            BuildSQLFile += textBox29.Text + ", "; // armor
            BuildSQLFile += textBox28.Text + ", "; // block
            BuildSQLFile += textBox30.Text + ", "; // armorDamageModifier
            BuildSQLFile += textBox31.Text + ", "; // maxDurability
            BuildSQLFile += textBox32.Text + ", "; // holy_res
            BuildSQLFile += textBox33.Text + ", "; // frost_res
            BuildSQLFile += textBox34.Text + ", "; // fire_res
            BuildSQLFile += textBox35.Text + ", "; // shadow_res
            BuildSQLFile += textBox36.Text + ", "; // nature_res
            BuildSQLFile += textBox37.Text + ", "; // arcane_res
            BuildSQLFile += textBox38.Text + ", "; // rangedModRange
            BuildSQLFile += comboBox20.SelectedIndex + ", "; // ammoType
            BuildSQLFile += comboBox21.SelectedIndex + ", "; // dmg_type1
            BuildSQLFile += textBox39.Text + ", "; // dmg_min1
            BuildSQLFile += textBox40.Text + ", "; // dmg_max1
            BuildSQLFile += comboBox22.SelectedIndex + ", "; // dmg_type2
            BuildSQLFile += textBox41.Text + ", "; // dmg_min2
            BuildSQLFile += textBox42.Text + ", "; // dmg_max2
            BuildSQLFile += textBox43.Text + ", "; // requiredLevel
            BuildSQLFile += textBox49.Text + ", "; // requiredReputationFaction
            BuildSQLFile += comboBox23.SelectedIndex + ", "; // requiredReputationRank
            BuildSQLFile += textBox45.Text + ", "; // requiredSkill
            BuildSQLFile += textBox46.Text + ", "; // requiredSkillRank
            BuildSQLFile += textBox47.Text + ", "; // requiredSpell
            BuildSQLFile += textBox48.Text + ", "; // requiredCityRank
            BuildSQLFile += textBox44.Text + ", "; // requiredHonorRank
            BuildSQLFile += textBox50.Text + ", "; // delay
            BuildSQLFile += textBox51.Text + ", "; // duration
            BuildSQLFile += textBox52.Text + ", "; // requiredDisenchantSkill
            BuildSQLFile += textBox53.Text + ", "; // disenchantID
            BuildSQLFile += textBox54.Text + ", "; // containerSlots
            BuildSQLFile += textBox55.Text + ", "; // itemLimitCategory
            BuildSQLFile += textBox56.Text + ", "; // SoundOverrideSubclass
            BuildSQLFile += textBox57.Text + ", "; // holidayID
            BuildSQLFile += textBox58.Text + ", "; // map
            BuildSQLFile += textBox59.Text + ", "; // area
            BuildSQLFile += textBox60.Text + ", "; // minMoneyLoot
            BuildSQLFile += textBox61.Text + ", "; // maxMoneyLoot
            BuildSQLFile += textBox62.Text + ", "; // pageMaterial
            BuildSQLFile += textBox63.Text + ", "; // pageText
            BuildSQLFile += textBox64.Text + ", "; // languageID
            BuildSQLFile += textBox65.Text + ", "; // lockID
            BuildSQLFile += textBox66.Text + ", "; // startQuest
            BuildSQLFile += textBox67.Text + ", "; // verifiedBuild
            BuildSQLFile += textBox68.Text + ", "; // spellID_1
            BuildSQLFile += comboBox24.SelectedIndex + ", "; // spellTrigger_1
            BuildSQLFile += textBox69.Text + ", "; // spellCharges_1
            BuildSQLFile += textBox70.Text + ", "; // spellppmRate_1
            BuildSQLFile += textBox71.Text + ", "; // spellCooldown_1
            BuildSQLFile += textBox72.Text + ", "; // spellCategory_1
            BuildSQLFile += textBox73.Text + ", "; // spellCategoryCooldown_1
            BuildSQLFile += textBox74.Text + ", "; // spellID_2
            BuildSQLFile += comboBox25.SelectedIndex + ", "; // spellTrigger_2
            BuildSQLFile += textBox75.Text + ", "; // spellCharges_2
            BuildSQLFile += textBox76.Text + ", "; // spellppmRate_2
            BuildSQLFile += textBox77.Text + ", "; // spellCooldown_2
            BuildSQLFile += textBox78.Text + ", "; // spellCategory_2
            BuildSQLFile += textBox79.Text + ", "; // spellCategoryCooldown_2
            BuildSQLFile += textBox85.Text + ", "; // spellID_3
            BuildSQLFile += comboBox26.SelectedIndex + ", "; // spellTrigger_3
            BuildSQLFile += textBox84.Text + ", "; // spellCharges_3
            BuildSQLFile += textBox83.Text + ", "; // spellppmRate_3
            BuildSQLFile += textBox82.Text + ", "; // spellCooldown_3
            BuildSQLFile += textBox81.Text + ", "; // spellCategory_3
            BuildSQLFile += textBox80.Text + ", "; // spellCategoryCooldown_3
            BuildSQLFile += textBox91.Text + ", "; // spellID_4
            BuildSQLFile += comboBox27.SelectedIndex + ", "; // spellTrigger_4
            BuildSQLFile += textBox90.Text + ", "; // spellCharges_4
            BuildSQLFile += textBox89.Text + ", "; // spellppmRate_4
            BuildSQLFile += textBox88.Text + ", "; // spellCooldown_4
            BuildSQLFile += textBox87.Text + ", "; // spellCategory_4
            BuildSQLFile += textBox86.Text + ", "; // spellCategoryCooldown_4
            BuildSQLFile += textBox97.Text + ", "; // spellID_5
            BuildSQLFile += comboBox28.SelectedIndex + ", "; // spellTrigger_5
            BuildSQLFile += textBox96.Text + ", "; // spellCharges_5
            BuildSQLFile += textBox95.Text + ", "; // spellppmRate_5
            BuildSQLFile += textBox94.Text + ", "; // spellCooldown_5
            BuildSQLFile += textBox93.Text + ", "; // spellCategory_5
            BuildSQLFile += textBox92.Text; // spellCategoryCooldown_5
            BuildSQLFile += ");";

            stringSQLShare = BuildSQLFile;
            stringEntryShare = textBox1.Text;

            // End of _Generate method
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            label_query_executed_successfully2.Visible = false;
            label4.BackColor = Color.Transparent;
            label4.ForeColor = Color.Black;

            comboBox3.Items.Clear();
            switch (comboBox2.SelectedIndex)
            {
                case 0: // menu class: consumables -> SUBCLASS:
                    comboBox3.Items.AddRange(new object[]
                    {
                        "Consumable",
                        "Potion",
                        "Elixir",
                        "Flask",
                        "Scroll",
                        "Food & Drink",
                        "Item Enhancement",
                        "Bandage",
                        "Other",
                    });
                    break;
                case 1: // menu class: container -> SUBCLASS:
                    comboBox3.Items.AddRange(new object[]
                    {
                        "Bag",
                        "Soul Bag",
                        "Herb Bag",
                        "Enchanting Bag",
                        "Engineering Bag",
                        "Gem Bag",
                        "Mining Bag",
                        "Leatherworking Bag",
                        "Inscription Bag",
                    });
                    break;
                case 2: // menu class: weapon -> SUBCLASS:
                    comboBox3.Items.AddRange(new object[]
                    {
                        "Axe One-Handed",
                        "Axe Two-Handed",
                        "Bow",
                        "Gun",
                        "Mace One-Handed",
                        "Mace Two-Handed",
                        "Polearm",
                        "Sword One-Handed",
                        "Sword Two-Handed",
                        "Obsolete",
                        "Staff",
                        "Exotic 1",
                        "Exotic 2",
                        "Fist Weapon",
                        "Miscellaneous",
                        "Dagger",
                        "Thrown",
                        "Spear",
                        "Crossbow",
                        "Wand",
                        "Fishing Pole",
                    });
                    break;
                case 3: // menu class: gem -> SUBCLASS:
                    comboBox3.Items.AddRange(new object[]
                    {
                        "Red",
                        "Purple",
                        "Yellow",
                        "Green",
                        "Orange",
                        "Meta",
                        "Simple",
                        "Prismatic",
                    });
              break;
                case 4: // menu class: armor -> SUBCLASS:
                    comboBox3.Items.AddRange(new object[]
                    {
                        "Miscellaneous",
                        "Cloth",
                        "Leather",
                        "Mail",
                        "Plate",
                        "Blucker (OBSOLETE)",
                        "Shield",
                        "Libram",
                        "Idol",
                        "Totem",
                        "Sigil",
                    });
                    break;
                case 5: // menu class: reagent -> SUBCLASS:
                    comboBox3.Items.AddRange(new object[]
                    {
                        "Reagent",
                    });
                    break;
                case 6: // menu class: projectile -> SUBCLASS:
                    comboBox3.Items.AddRange(new object[]
                    {
                        "Wand (OBSOLETE)",
                        "Bolt (OBSOLETE)",
                        "Arrow",
                        "Bullet",
                        "Thrown (oBSOLETE)",
                    });
                    break;
                case 7: // menu class: trade goods -> SUBCLASS:
                    comboBox3.Items.AddRange(new object[]
                    {
                        "Trade Goods",
                        "Parts",
                        "Explosives",
                        "Devices",
                        "Jewelcrafting",
                        "Cloth",
                        "Leather",
                        "Metal & Stone",
                        "Meat",
                        "Herb",
                        "Elemental",
                        "Other",
                        "Enchantment",
                        "Materials",
                        "Armor Enchantment",
                        "Weapon Enchantment",
                    });
                    break;
                case 8: // menu class: generic (obsolete) -> SUBCLASS:
                    comboBox3.Items.AddRange(new object[]
                    {
                        "Generic (OBSOLETE)",
                    });
                    break;
                case 9: // menu class: recipe -> SUBCLASS:
                    comboBox3.Items.AddRange(new object[]
                    {
                        "Book",
                        "Leatherworking",
                        "Tailoring",
                        "Engineering",
                        "Blacksmithing",
                        "Cooking",
                        "Alchemy",
                        "First Aid",
                        "Enchanting",
                        "Fishing",
                        "Jewelcrafting",
                    });
                    break;
                case 10: // menu class: money (obsolete) -> SUBCLASS:
                    comboBox3.Items.AddRange(new object[]
                    {
                        "Money (OBSOLETE)",
                    });
                    break;
                case 11: // menu class: quiver -> SUBCLASS:
                    comboBox3.Items.AddRange(new object[]
                    {
                        "Quiver (OBSOLETE)",
                        "Quiver (OBSOLETE)",
                        "Quiver",
                        "Money Pouch",
                    });
                    break;
                case 12: // menu class: quest -> SUBCLASS:
                    comboBox3.Items.AddRange(new object[]
                    {
                        "Quest",
                    });
                    break;
                case 13: // menu class: key -> SUBCLASS:
                    comboBox3.Items.AddRange(new object[]
                    {
                        "Key",
                        "Lockpick",
                    });
                    break;
                case 14: // menu class: permanent (obsolete) -> SUBCLASS:
                    comboBox3.Items.AddRange(new object[]
                    {
                        "Permanent",
                    });
                    break;
                case 15: // menu class: Miscellaneous -> SUBCLASS:
                    comboBox3.Items.AddRange(new object[]
                    {
                        "Junk",
                        "Reagent",
                        "Pet",
                        "Holiday",
                        "Other",
                        "Mount",
                    });
                    break;
                case 16: // menu class: glyph -> SUBCLASS:
                    comboBox3.Items.AddRange(new object[]
                    {
                        "Warrior",
                        "Paladin",
                        "Hunter",
                        "Rogue",
                        "Priest",
                        "Death Knight",
                        "Shaman",
                        "Mage",
                        "Warlock",
                        "Druid",
                    });
                    break;
            }
            comboBox3.SelectedIndex = 0; // always show the first item
            // -- End of the code, empty divide
        }

        private void textBox2_MouseEnter(object sender, EventArgs e)
        {
            toolTip1.SetToolTip(this.textBox2, this.textBox2.Text);
            Definers.output_itemName = textBox2.Text;

            label_query_executed_successfully2.Visible = false;
        }

        private void textBox3_MouseEnter(object sender, EventArgs e)
        {
            toolTip1.SetToolTip(this.textBox3, this.textBox3.Text);
            Definers.output_itemDescription = textBox3.Text;

            label_query_executed_successfully2.Visible = false;
        }

        private void Form2_FormClosing(object sender, FormClosingEventArgs e)
        {
            //In case windows is trying to shut down, don't hold the process up
            //if (e.CloseReason == CloseReason.WindowsShutDown) return;

            //DialogResult dr = MessageBox.Show("Are you sure you want to exit application?", "Exit", MessageBoxButtons.YesNo);
            //if (dr == DialogResult.No)
            //{
            //    // Confirm form close action
            //    e.Cancel = true;
            //}
            //else
            //{
            //    // Reset settings after application closes
            //    Properties.Settings.Default.Reset();
            //}
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            Form_SocketOptions form_SocketOptions = new Form_SocketOptions();
            form_SocketOptions.ShowDialog();
            label_query_executed_successfully2.Visible = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            label_query_executed_successfully2.Visible = false;
            Form_ClassMasksDialog form_ClassMasksDialog = new Form_ClassMasksDialog();
            form_ClassMasksDialog.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            label_query_executed_successfully2.Visible = false;
            Form_FlagMasksDialog form_FlagMasksDialog = new Form_FlagMasksDialog();
            form_FlagMasksDialog.ShowDialog();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            label_query_executed_successfully2.Visible = false;
            Form_RaceMasksDialog form_RaceMasksDialog = new Form_RaceMasksDialog();
            form_RaceMasksDialog.ShowDialog();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            label_query_executed_successfully2.Visible = false;
            Form_FlagExtraMasksDialog form_FlagExtraMasksDialog = new Form_FlagExtraMasksDialog();
            form_FlagExtraMasksDialog.ShowDialog();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            label_query_executed_successfully2.Visible = false;
            Form_BagFamilyMasksDialog form_BagFamilyMasksDialog = new Form_BagFamilyMasksDialog();
            form_BagFamilyMasksDialog.ShowDialog();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            label_query_executed_successfully2.Visible = false;
            Form_FlagCustomDialog form_FlagCustomDialog = new Form_FlagCustomDialog();
            form_FlagCustomDialog.ShowDialog();
        }

        private void PopUPSaveOptionsDialog()
        {
            SaveOptionsDialog frmDialog = new SaveOptionsDialog();
            frmDialog.ShowDialog();
        }

        // Save as .sql - Button
        private void GenerateSQLCode(object sender, EventArgs e)
        {
            _Generate(sender, e);

            //PopUPSaveOptionsDialog();

            if (textBox2.Text == "")
            {
                MessageBox.Show("Name should not be empty", "Error");
                return;
            }

            using (var sfd = new SaveFileDialog())
            {
                sfd.Filter = "sql files (*.sql)|*.sql";
                sfd.FilterIndex = 2;
                sfd.FileName = "Item_" + Form_ItemCreator.stringEntryShare;

                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    File.WriteAllText(sfd.FileName, Form_ItemCreator.stringSQLShare);
                    timer3.Start();
                }
            }
        }

        private bool mouseDown;
        private Point lastLocation;

        private void panel2_MouseDown(object sender, MouseEventArgs e)
        {
            mouseDown = true;
            lastLocation = e.Location;
        }

        private void panel2_MouseMove(object sender, MouseEventArgs e)
        {
            if (mouseDown)
            {
                this.Location = new Point(
                    (this.Location.X - lastLocation.X) + e.X, (this.Location.Y - lastLocation.Y) + e.Y);

                this.Update();
            }
        }

        private void panel2_MouseUp(object sender, MouseEventArgs e)
        {
            mouseDown = false;
        }

        private void label81_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void label80_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
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

        private void panel4_MouseEnter(object sender, EventArgs e)
        {
            panel4.BackColor = Color.Firebrick;
        }

        private void panel4_MouseLeave(object sender, EventArgs e)
        {
            panel4.BackColor = Color.FromArgb(58, 89, 114);
        }

        private void panel5_MouseEnter(object sender, EventArgs e)
        {
            panel5.BackColor = Color.Firebrick;
        }

        private void panel5_MouseLeave(object sender, EventArgs e)
        {
            panel5.BackColor = Color.FromArgb(58, 89, 114);
        }

        private void panel4_Click(object sender, EventArgs e)
        {
            Form_ItemPreview frm_itempreview = new Form_ItemPreview();
            frm_itempreview.ShowDialog();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            int x = 0;
            if (Int32.TryParse(textBox1.Text, out x))
            {
                Definers.output_itemEntry = x;
            }

            label_query_executed_successfully2.Visible = false;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            label_query_executed_successfully2.Visible = false;
            Definers.output_itemQuality = comboBox1.SelectedIndex;

            if (comboBox1.Text == ("Poor (grey)"))
            {
                label3.BackColor = Color.Gray;
                label3.ForeColor = Color.White;
            }
            else if (comboBox1.Text == ("Common (white)"))
            {
                label3.BackColor = Color.White;
                label3.ForeColor = Color.Black;
            }
            else if (comboBox1.Text == ("Uncommon (green)"))
            {
                label3.ForeColor = Color.White;
                label3.BackColor = Color.Green;
            }
            else if (comboBox1.Text == ("Rare (blue)"))
            {
                label3.BackColor = Color.Blue;
                label3.ForeColor = Color.White;
            }
            else if (comboBox1.Text == ("Epic (purple)"))
            {
                label3.BackColor = Color.Purple;
                label3.ForeColor = Color.White;
            }
            else if (comboBox1.Text == ("Legendary (orange)"))
            {
                label3.BackColor = Color.Orange;
                label3.ForeColor = Color.Black;
            }
            else if (comboBox1.Text == ("Artifact (heirbloom)"))
            {
                label3.BackColor = Color.BurlyWood;
                label3.ForeColor = Color.Black;
            }
            else if (comboBox1.Text == ("Bind to Account (gold)"))
            {
                label3.BackColor = Color.Gold;
                label3.ForeColor = Color.Black;
            }
        }

        private void textBox10_TextChanged(object sender, EventArgs e)
        {
            int x = 0;
            if (Int32.TryParse(textBox10.Text, out x))
            {
                Definers.output_itemlevel = x;
            }
            label_query_executed_successfully2.Visible = false;
        }

        private void comboBox5_SelectedIndexChanged(object sender, EventArgs e)
        {
            Definers.output_itembinding = comboBox5.SelectedIndex;
            label_query_executed_successfully2.Visible = false;
        }

        private void comboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {
            label_query_executed_successfully2.Visible = false;
            Definers.output_iteminvetorytype = comboBox4.SelectedIndex;
        }

        private void comboBox7_SelectedIndexChanged(object sender, EventArgs e)
        {
            label_query_executed_successfully2.Visible = false;
            Definers.output_itemmaterial = comboBox7.SelectedIndex;
        }

        private void textBox29_TextChanged(object sender, EventArgs e)
        {
            int x = 0;
            if (Int32.TryParse(textBox29.Text, out x))
            {
                Definers.output_itemarmor = x;
            }

            label_query_executed_successfully2.Visible = false;
        }

        private void textBox16_TextChanged(object sender, EventArgs e)
        {
            int x = 0;
            if (Int32.TryParse(textBox16.Text, out x))
            {
                Definers.output_itemstatvalue1 = x;
            }
            label_query_executed_successfully2.Visible = false;
        }

        private void textBox17_TextChanged(object sender, EventArgs e)
        {
            int x = 0;
            if (Int32.TryParse(textBox17.Text, out x))
            {
                Definers.output_itemstatvalue2 = x;
            }
            label_query_executed_successfully2.Visible = false;
        }

        private void textBox18_TextChanged(object sender, EventArgs e)
        {
            int x = 0;
            if (Int32.TryParse(textBox18.Text, out x))
            {
                Definers.output_itemstatvalue3 = x;
            }
            label_query_executed_successfully2.Visible = false;
        }

        private void textBox19_TextChanged(object sender, EventArgs e)
        {
            int x = 0;
            if (Int32.TryParse(textBox19.Text, out x))
            {
                Definers.output_itemstatvalue4 = x;
            }
            label_query_executed_successfully2.Visible = false;
        }

        private void textBox20_TextChanged(object sender, EventArgs e)
        {
            int x = 0;
            if (Int32.TryParse(textBox20.Text, out x))
            {
                Definers.output_itemstatvalue5 = x;
            }
            label_query_executed_successfully2.Visible = false;
        }

        private void textBox21_TextChanged(object sender, EventArgs e)
        {
            int x = 0;
            if (Int32.TryParse(textBox21.Text, out x))
            {
                Definers.output_itemstatvalue6 = x;
            }
            label_query_executed_successfully2.Visible = false;
        }

        private void textBox22_TextChanged(object sender, EventArgs e)
        {
            int x = 0;
            if (Int32.TryParse(textBox22.Text, out x))
            {
                Definers.output_itemstatvalue7 = x;
            }
            label_query_executed_successfully2.Visible = false;
        }

        private void textBox23_TextChanged(object sender, EventArgs e)
        {
            int x = 0;
            if (Int32.TryParse(textBox23.Text, out x))
            {
                Definers.output_itemstatvalue8 = x;
            }
            label_query_executed_successfully2.Visible = false;
        }

        private void textBox24_TextChanged(object sender, EventArgs e)
        {
            int x = 0;
            if (Int32.TryParse(textBox24.Text, out x))
            {
                Definers.output_itemstatvalue9 = x;
            }
            label_query_executed_successfully2.Visible = false;
        }

        private void textBox25_TextChanged(object sender, EventArgs e)
        {
            int x = 0;
            if (Int32.TryParse(textBox25.Text, out x))
            {
                Definers.output_itemstatvalue10 = x;
            }
            label_query_executed_successfully2.Visible = false;
        }

        private void comboBox10_SelectedIndexChanged(object sender, EventArgs e)
        {
            label_query_executed_successfully2.Visible = false;
            Definers.output_itemtype1 = comboBox10.SelectedIndex;
        }

        private void comboBox11_SelectedIndexChanged(object sender, EventArgs e)
        {
            label_query_executed_successfully2.Visible = false;
            Definers.output_itemtype2 = comboBox11.SelectedIndex;
        }

        private void comboBox12_SelectedIndexChanged(object sender, EventArgs e)
        {
            label_query_executed_successfully2.Visible = false;
            Definers.output_itemtype3 = comboBox12.SelectedIndex;
        }

        private void comboBox13_SelectedIndexChanged(object sender, EventArgs e)
        {
            label_query_executed_successfully2.Visible = false;
            Definers.output_itemtype4 = comboBox13.SelectedIndex;
        }

        private void comboBox14_SelectedIndexChanged(object sender, EventArgs e)
        {
            label_query_executed_successfully2.Visible = false;
            Definers.output_itemtype5 = comboBox14.SelectedIndex;
        }

        private void comboBox15_SelectedIndexChanged(object sender, EventArgs e)
        {
            label_query_executed_successfully2.Visible = false;
            Definers.output_itemtype6 = comboBox15.SelectedIndex;
        }

        private void comboBox16_SelectedIndexChanged(object sender, EventArgs e)
        {
            label_query_executed_successfully2.Visible = false;
            Definers.output_itemtype7 = comboBox16.SelectedIndex;
        }

        private void comboBox17_SelectedIndexChanged(object sender, EventArgs e)
        {
            label_query_executed_successfully2.Visible = false;
            Definers.output_itemtype8 = comboBox17.SelectedIndex;
        }

        private void comboBox18_SelectedIndexChanged(object sender, EventArgs e)
        {
            label_query_executed_successfully2.Visible = false;
            Definers.output_itemtype9 = comboBox18.SelectedIndex;
        }

        private void comboBox19_SelectedIndexChanged(object sender, EventArgs e)
        {
            label_query_executed_successfully2.Visible = false;
            Definers.output_itemtype10 = comboBox19.SelectedIndex;
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Escape)
            {
                Application.Exit();
                return true;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void textBox31_TextChanged(object sender, EventArgs e)
        {
            int x = 0;
            if (Int32.TryParse(textBox31.Text, out x))
            {
                Definers.output_itemdurability = x;
            }

            label_query_executed_successfully2.Visible = false;
        }
        
        int i = 1;
        DateTime dt = new DateTime();

        private void timer2_Tick(object sender, EventArgs e)
        {
            label_stopwatch.Text = dt.AddSeconds(i).ToString("HH:mm:ss");
            i++;
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("http://emucraft.com");
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

        private void label86_Click(object sender, EventArgs e)
        {

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

        private void textBox4_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void button_maxPlus1fromDB_Click(object sender, EventArgs e)
        {
            MySqlConnection connection = new MySqlConnection("datasource=" + mainmenu.textbox_mysql_hostname.Text + ";port=" + mainmenu.textbox_mysql_port.Text + ";username=" + mainmenu.textbox_mysql_username.Text + ";password=" + mainmenu.textbox_mysql_pass.Text);
            string insertQuery = "SELECT max(entry)+1 FROM " + mainmenu.textbox_mysql_worldDB.Text + ".item_template;";
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

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            label_query_executed_successfully2.Visible = false;
            if (comboBox3.Text == "Red")
            {
                label4.ForeColor = Color.White;
                label4.BackColor = Color.Red;
            }
            else if (comboBox3.Text == "Blue")
            {
                label4.ForeColor = Color.White;
                label4.BackColor = Color.Blue;
            }
            else if (comboBox3.Text == "Yellow")
            {
                label4.ForeColor = Color.Black;
                label4.BackColor = Color.Yellow;
            }
            else if (comboBox3.Text == "Purple")
            {
                label4.ForeColor = Color.White;
                label4.BackColor = Color.Purple;
            }
            else if (comboBox3.Text == "Green")
            {
                label4.ForeColor = Color.White;
                label4.BackColor = Color.Green;
            }
            else if (comboBox3.Text == "Orange")
            {
                label4.ForeColor = Color.Black;
                label4.BackColor = Color.Orange;
            }
            else if (comboBox3.Text == "Meta")
            {
                label4.ForeColor = Color.White;
                label4.BackColor = Color.Maroon;
            }
            else if (comboBox3.Text == "Simple")
            {
                label4.ForeColor = Color.White;
                label4.BackColor = Color.Gray;
            }
            else if (comboBox3.Text == "Prismatic")
            {
                label4.ForeColor = Color.Black;
                label4.BackColor = Color.DarkSalmon;
            }
        }

        private void button_execute_query_Click(object sender, EventArgs e)
        {
            _Generate(sender, e);

            if (textBox1.Text == "")
            {
                MessageBox.Show("Entry should not be empty", "Error");
                return;
            }
            else if (textBox2.Text == "")
            {
                MessageBox.Show("Name should not be empty", "Error");
                return;
            }

            MySqlConnection connection = new MySqlConnection("datasource=" + mainmenu.textbox_mysql_hostname.Text + ";port=" + mainmenu.textbox_mysql_port.Text + ";username=" + mainmenu.textbox_mysql_username.Text + ";password=" + mainmenu.textbox_mysql_pass.Text);
            string insertQuery = stringSQLShare;
            connection.Open();
            MySqlCommand command = new MySqlCommand(insertQuery, connection);

            try
            {
                if (command.ExecuteNonQuery() >= 1)
                {
                    
                    label_query_executed_successfully2.Visible = true;
                }
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            connection.Close();
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            label_query_executed_successfully2.Visible = false;
        }

        private void textBox28_TextChanged(object sender, EventArgs e)
        {
            label_query_executed_successfully2.Visible = false;
        }

        private void textBox30_TextChanged(object sender, EventArgs e)
        {
            label_query_executed_successfully2.Visible = false;
        }

        private void textBox32_TextChanged(object sender, EventArgs e)
        {
            label_query_executed_successfully2.Visible = false;
        }

        private void textBox33_TextChanged(object sender, EventArgs e)
        {
            label_query_executed_successfully2.Visible = false;
        }

        private void textBox34_TextChanged(object sender, EventArgs e)
        {
            label_query_executed_successfully2.Visible = false;
        }

        private void textBox35_TextChanged(object sender, EventArgs e)
        {
            label_query_executed_successfully2.Visible = false;
        }

        private void textBox36_TextChanged(object sender, EventArgs e)
        {
            label_query_executed_successfully2.Visible = false;
        }

        private void textBox37_TextChanged(object sender, EventArgs e)
        {
            label_query_executed_successfully2.Visible = false;
        }

        private void textBox38_TextChanged(object sender, EventArgs e)
        {
            label_query_executed_successfully2.Visible = false;
        }

        private void comboBox20_SelectedIndexChanged(object sender, EventArgs e)
        {
            label_query_executed_successfully2.Visible = false;
        }

        private void comboBox6_SelectedIndexChanged(object sender, EventArgs e)
        {
            label_query_executed_successfully2.Visible = false;
        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {
            label_query_executed_successfully2.Visible = false;
        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {
            label_query_executed_successfully2.Visible = false;
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            label_query_executed_successfully2.Visible = false;
        }

        private void textBox8_TextChanged(object sender, EventArgs e)
        {
            label_query_executed_successfully2.Visible = false;
        }

        private void textBox9_TextChanged(object sender, EventArgs e)
        {
            label_query_executed_successfully2.Visible = false;
        }

        private void textBox11_TextChanged(object sender, EventArgs e)
        {
            label_query_executed_successfully2.Visible = false;
        }

        private void comboBox9_SelectedIndexChanged(object sender, EventArgs e)
        {
            label_query_executed_successfully2.Visible = false;
        }

        private void textBox39_TextChanged(object sender, EventArgs e)
        {
            label_query_executed_successfully2.Visible = false;
        }

        private void textBox40_TextChanged(object sender, EventArgs e)
        {
            label_query_executed_successfully2.Visible = false;
        }

        private void textBox50_TextChanged(object sender, EventArgs e)
        {
            label_query_executed_successfully2.Visible = false;
        }

        private void textBox41_TextChanged(object sender, EventArgs e)
        {
            label_query_executed_successfully2.Visible = false;
        }

        private void textBox42_TextChanged(object sender, EventArgs e)
        {
            label_query_executed_successfully2.Visible = false;
        }

        private void comboBox21_SelectedIndexChanged(object sender, EventArgs e)
        {
            label_query_executed_successfully2.Visible = false;
        }

        private void comboBox22_SelectedIndexChanged(object sender, EventArgs e)
        {
            label_query_executed_successfully2.Visible = false;
        }

        private void comboBox8_SelectedIndexChanged(object sender, EventArgs e)
        {
            label_query_executed_successfully2.Visible = false;
        }

        private void textBox12_TextChanged(object sender, EventArgs e)
        {
            label_query_executed_successfully2.Visible = false;
        }

        private void textBox13_TextChanged(object sender, EventArgs e)
        {
            label_query_executed_successfully2.Visible = false;
        }

        private void textBox14_TextChanged(object sender, EventArgs e)
        {
            label_query_executed_successfully2.Visible = false;
        }

        private void textBox15_TextChanged(object sender, EventArgs e)
        {
            label_query_executed_successfully2.Visible = false;
        }

        private void textBox43_TextChanged(object sender, EventArgs e)
        {
            label_query_executed_successfully2.Visible = false;
        }

        private void comboBox23_SelectedIndexChanged(object sender, EventArgs e)
        {
            label_query_executed_successfully2.Visible = false;
        }

        private void textBox45_TextChanged(object sender, EventArgs e)
        {
            label_query_executed_successfully2.Visible = false;
        }

        private void textBox46_TextChanged(object sender, EventArgs e)
        {
            label_query_executed_successfully2.Visible = false;
        }

        private void textBox47_TextChanged(object sender, EventArgs e)
        {
            label_query_executed_successfully2.Visible = false;
        }

        private void textBox48_TextChanged(object sender, EventArgs e)
        {
            label_query_executed_successfully2.Visible = false;
        }

        private void textBox49_TextChanged(object sender, EventArgs e)
        {
            label_query_executed_successfully2.Visible = false;
        }

        private void textBox44_TextChanged(object sender, EventArgs e)
        {
            label_query_executed_successfully2.Visible = false;
        }

        private void textBox51_TextChanged(object sender, EventArgs e)
        {
            label_query_executed_successfully2.Visible = false;
        }

        private void textBox66_TextChanged(object sender, EventArgs e)
        {
            label_query_executed_successfully2.Visible = false;
        }

        private void textBox52_TextChanged(object sender, EventArgs e)
        {
            label_query_executed_successfully2.Visible = false;
        }

        private void textBox53_TextChanged(object sender, EventArgs e)
        {
            label_query_executed_successfully2.Visible = false;
        }

        private void textBox54_TextChanged(object sender, EventArgs e)
        {
            label_query_executed_successfully2.Visible = false;
        }

        private void textBox55_TextChanged(object sender, EventArgs e)
        {
            label_query_executed_successfully2.Visible = false;
        }

        private void textBox56_TextChanged(object sender, EventArgs e)
        {
            label_query_executed_successfully2.Visible = false;
        }

        private void textBox57_TextChanged(object sender, EventArgs e)
        {
            label_query_executed_successfully2.Visible = false;
        }

        private void textBox58_TextChanged(object sender, EventArgs e)
        {
            label_query_executed_successfully2.Visible = false;
        }

        private void label64_Click(object sender, EventArgs e)
        {

        }

        private void textBox59_TextChanged(object sender, EventArgs e)
        {
            label_query_executed_successfully2.Visible = false;
        }

        private void textBox26_TextChanged(object sender, EventArgs e)
        {
            label_query_executed_successfully2.Visible = false;
        }

        private void textBox27_TextChanged(object sender, EventArgs e)
        {
            label_query_executed_successfully2.Visible = false;
        }

        private void textBox60_TextChanged(object sender, EventArgs e)
        {
            label_query_executed_successfully2.Visible = false;
        }

        private void textBox61_TextChanged(object sender, EventArgs e)
        {
            label_query_executed_successfully2.Visible = false;
        }

        private void textBox62_TextChanged(object sender, EventArgs e)
        {
            label_query_executed_successfully2.Visible = false;
        }

        private void textBox63_TextChanged(object sender, EventArgs e)
        {
            label_query_executed_successfully2.Visible = false;
        }

        private void textBox64_TextChanged(object sender, EventArgs e)
        {
            label_query_executed_successfully2.Visible = false;
        }

        private void textBox65_TextChanged(object sender, EventArgs e)
        {
            label_query_executed_successfully2.Visible = false;
        }

        private void textBox67_TextChanged(object sender, EventArgs e)
        {
            label_query_executed_successfully2.Visible = false;
        }

        private void textBox68_TextChanged(object sender, EventArgs e)
        {
            label_query_executed_successfully2.Visible = false;
        }

        private void textBox74_TextChanged(object sender, EventArgs e)
        {
            label_query_executed_successfully2.Visible = false;
        }

        private void textBox85_TextChanged(object sender, EventArgs e)
        {
            label_query_executed_successfully2.Visible = false;
        }

        private void textBox91_TextChanged(object sender, EventArgs e)
        {
            label_query_executed_successfully2.Visible = false;
        }

        private void textBox97_TextChanged(object sender, EventArgs e)
        {
            label_query_executed_successfully2.Visible = false;
        }

        private void comboBox24_SelectedIndexChanged(object sender, EventArgs e)
        {
            label_query_executed_successfully2.Visible = false;
        }

        private void comboBox25_SelectedIndexChanged(object sender, EventArgs e)
        {
            label_query_executed_successfully2.Visible = false;
        }

        private void comboBox26_SelectedIndexChanged(object sender, EventArgs e)
        {
            label_query_executed_successfully2.Visible = false;
        }

        private void comboBox27_SelectedIndexChanged(object sender, EventArgs e)
        {
            label_query_executed_successfully2.Visible = false;
        }

        private void comboBox28_SelectedIndexChanged(object sender, EventArgs e)
        {
            label_query_executed_successfully2.Visible = false;
        }

        private void textBox69_TextChanged(object sender, EventArgs e)
        {
            label_query_executed_successfully2.Visible = false;
        }

        private void textBox75_TextChanged(object sender, EventArgs e)
        {
            label_query_executed_successfully2.Visible = false;
        }

        private void textBox84_TextChanged(object sender, EventArgs e)
        {
            label_query_executed_successfully2.Visible = false;
        }

        private void textBox90_TextChanged(object sender, EventArgs e)
        {
            label_query_executed_successfully2.Visible = false;
        }

        private void textBox96_TextChanged(object sender, EventArgs e)
        {
            label_query_executed_successfully2.Visible = false;
        }

        private void textBox70_TextChanged(object sender, EventArgs e)
        {
            label_query_executed_successfully2.Visible = false;
        }

        private void textBox76_TextChanged(object sender, EventArgs e)
        {
            label_query_executed_successfully2.Visible = false;
        }

        private void textBox83_TextChanged(object sender, EventArgs e)
        {
            label_query_executed_successfully2.Visible = false;
        }

        private void textBox78_TextChanged(object sender, EventArgs e)
        {
            label_query_executed_successfully2.Visible = false;
        }

        private void textBox95_TextChanged(object sender, EventArgs e)
        {
            label_query_executed_successfully2.Visible = false;
        }

        private void textBox71_TextChanged(object sender, EventArgs e)
        {
            label_query_executed_successfully2.Visible = false;
        }

        private void textBox77_TextChanged(object sender, EventArgs e)
        {
            label_query_executed_successfully2.Visible = false;
        }

        private void textBox82_TextChanged(object sender, EventArgs e)
        {
            label_query_executed_successfully2.Visible = false;
        }

        private void textBox88_TextChanged(object sender, EventArgs e)
        {
            label_query_executed_successfully2.Visible = false;
        }

        private void textBox94_TextChanged(object sender, EventArgs e)
        {
            label_query_executed_successfully2.Visible = false;
        }

        private void textBox93_TextChanged(object sender, EventArgs e)
        {
            label_query_executed_successfully2.Visible = false;
        }

        private void textBox87_TextChanged(object sender, EventArgs e)
        {
            label_query_executed_successfully2.Visible = false;
        }

        private void textBox81_TextChanged(object sender, EventArgs e)
        {
            label_query_executed_successfully2.Visible = false;
        }

        private void textBox89_TextChanged(object sender, EventArgs e)
        {
            label_query_executed_successfully2.Visible = false;
        }

        private void textBox72_TextChanged(object sender, EventArgs e)
        {
            label_query_executed_successfully2.Visible = false;
        }

        private void textBox73_TextChanged(object sender, EventArgs e)
        {
            label_query_executed_successfully2.Visible = false;
        }

        private void textBox79_TextChanged(object sender, EventArgs e)
        {
            label_query_executed_successfully2.Visible = false;
        }

        private void textBox80_TextChanged(object sender, EventArgs e)
        {
            label_query_executed_successfully2.Visible = false;
        }

        private void textBox86_TextChanged(object sender, EventArgs e)
        {
            label_query_executed_successfully2.Visible = false;
        }

        private void textBox92_TextChanged(object sender, EventArgs e)
        {
            label_query_executed_successfully2.Visible = false;
        }


        //Copy to Clipboard - Button
        private void label86_Click_1(object sender, EventArgs e)
        {
            _Generate(sender, e);

            if (textBox2.Text == "")
            {
                MessageBox.Show("Name should not be empty", "Error");
                return;
            }

            Clipboard.SetText(stringSQLShare);
            //label87.Visible = true;
            timer5.Start();
        }

        private void label86_MouseHover(object sender, EventArgs e)
        {
            //label87.Visible = false;
        }

        private void panel5_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel7_MouseHover(object sender, EventArgs e)
        {
            //label87.Visible = false;
        }

        private void label83_MouseHover(object sender, EventArgs e)
        {
            //label87.Visible = false;
        }

        private void panel5_MouseHover(object sender, EventArgs e)
        {
           // label87.Visible = false;
        }

        private void textBox2_MouseHover(object sender, EventArgs e)
        {
            //label87.Visible = false;
        }

        private void label86_MouseEnter(object sender, EventArgs e)
        {
            panel7.BackColor = Color.Firebrick;
        }

        private void label86_MouseLeave(object sender, EventArgs e)
        {
            panel7.BackColor = Color.FromArgb(58, 89, 114);
        }

        private void panel7_MouseEnter(object sender, EventArgs e)
        {
            panel7.BackColor = Color.Firebrick;
        }

        private void panel7_MouseLeave(object sender, EventArgs e)
        {
            panel7.BackColor = Color.FromArgb(58, 89, 114);
        }

        private void timer3_Tick(object sender, EventArgs e)
        {
            label88.Visible = true;
            timer3.Stop();

            timer4.Start();
        }

        private void timer4_Tick(object sender, EventArgs e)
        {
            label88.Visible = false;
            timer4.Stop();
        }

        private void timer5_Tick(object sender, EventArgs e)
        {
            label87.Visible = true;
            timer5.Stop();

            timer6.Start();
        }

        private void timer6_Tick(object sender, EventArgs e)
        {
            label87.Visible = false;
            timer6.Stop();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button8_Click(object sender, EventArgs e)
        {
            //Close();
            //BackToMainMenu backtomainmenu = new BackToMainMenu();
            //backtomainmenu.Show();
        }

        private void button8_Click_1(object sender, EventArgs e)
        {
            Close();
            BackToMainMenu backtomainmenu = new BackToMainMenu();
            backtomainmenu.Show();
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label22_Click(object sender, EventArgs e)
        {
            Process.Start("https://trinitycore.atlassian.net/wiki/display/tc/item_template");
        }

        private void label22_MouseHover(object sender, EventArgs e)
        {
            label22.ForeColor = Color.RoyalBlue;
        }

        private void label22_MouseLeave(object sender, EventArgs e)
        {
            label22.ForeColor = Color.Blue;
        }

        private void textBox4_KeyPress_1(object sender, KeyPressEventArgs e)
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

        private void textBox_all_minus_one_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '-'))
            {
                e.Handled = true;
            }

            // only allow one decimal point
            if ((e.KeyChar == '-') && ((sender as TextBox).Text.IndexOf('-') > -1))
            {
                e.Handled = true;
            }
        }

        private void label90_Click(object sender, EventArgs e)
        {
            Close();
            BackToMainMenu backtomainmenu = new BackToMainMenu();
            backtomainmenu.Show();

            
        }

        private void label90_MouseEnter(object sender, EventArgs e)
        {
            label90.BackColor = Color.Firebrick;
            label90.ForeColor = Color.White;
        }

        private void label90_MouseLeave(object sender, EventArgs e)
        {
            label90.BackColor = Color.FromArgb(58, 89, 114);
            label90.ForeColor = Color.Black;
        }

        private void comboBox29_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox29.SelectedIndex == 0) textBox105.Text = "INSERT";
            else if (comboBox29.SelectedIndex == 1) textBox105.Text = "REPLACE";
        }
    }
}
