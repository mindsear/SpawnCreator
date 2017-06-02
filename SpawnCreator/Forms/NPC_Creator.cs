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
    public partial class NPC_Creator : Form
    {
        // This code allow the user to minimize the form by clicking the taskbar icon
        protected override CreateParams CreateParams
        {
            get
            {
                const int WS_MINIMIZEBOX = 0x00020000;
                var cp = base.CreateParams;
                cp.Style |= WS_MINIMIZEBOX;
                return cp;
            }
        }

        ControlPanel control_panel = new ControlPanel();

        public NPC_Creator()
        {
            //Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo("nn-NO");
            InitializeComponent();
        }

        private readonly Form_MainMenu form_MM;
        public NPC_Creator(Form_MainMenu form_MainMenu)
        {
            InitializeComponent();
            form_MM = form_MainMenu;
        }

        MySqlConnection connection = new MySqlConnection();
        //MySql_Connect mysql_Connect = new MySql_Connect();

        public void GetMySqlConnection()
        {
            string connStr = string.Format("Server={0};Port={1};UID={2};Pwd={3};", 
                form_MM.GetHost(), form_MM.GetPort(), form_MM.GetUser(), form_MM.GetPass());

            MySqlConnection _connection = new MySqlConnection(connStr);
            connection = _connection;
        }

        public void SelectRandomModelID()
        {
            GetMySqlConnection();

            string query = $"SELECT modelid1,name FROM {form_MM.GetWorldDB()}.creature_template ORDER BY RAND() LIMIT 1; ";
            //string query2 = $"SELECT name FROM {form_MM.GetWorldDB()}.creature_template WHERE modelid1={ textBox10.Text };";

            MySqlCommand _command = new MySqlCommand(query, connection);
           // MySqlCommand _command2 = new MySqlCommand(query2, connection);

            try
            {
                connection.Open();

                using (MySqlDataReader dr = _command.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        textBox10.Text = dr["modelid1"].ToString();
                        TXT_Name.Text = dr["name"].ToString();
                    }
                }

                //textBox10.Text = _command.ExecuteScalar().ToString();
                //TXT_Name.Text = _command2.ExecuteScalar().ToString();
                
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message, "SpawnCreator", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception _ex)
            {
                MessageBox.Show(_ex.Message, "SpawnCreator", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                connection.Close();
            }
        }

        public void SelectMaxPlus1_NPC()
        {
            GetMySqlConnection();

            string query = $"SELECT max(entry) + 1 FROM { form_MM.GetWorldDB() }.creature_template;";

            MySqlCommand _command = new MySqlCommand(query, connection);

            try
            {
                connection.Open();
                NUD_Entry.Text = _command.ExecuteScalar().ToString();

            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message, "SpawnCreator", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                connection.Close();
            }
        }

        public void DeleteNPC()
        {
            GetMySqlConnection();

            try
            {
                connection.Open();

                MySqlCommand _command = new MySqlCommand();
                _command.Connection = connection;

                _command.CommandText = $"DELETE FROM { form_MM.GetWorldDB() }.creature_template WHERE entry=@Entry;";
                _command.Prepare();
                _command.Parameters.AddWithValue("@Entry", NUD_Entry.Text);

                _command.ExecuteNonQuery();
                MessageBox.Show("Creature successfully deleted! \t", "SpawnCreator", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message, "SpawnCreator", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                connection.Close();
            }
        }

        //private void SelectMaxPlus1_FROM_creature_template()
        //{
        //    //GetMySqlConnection();

        //    string insertQuery = "SELECT max(entry)+1 FROM " + form_MM.GetWorldDB() + ".creature_template;";

        //    connection.Open();
        //    MySqlCommand command = new MySqlCommand(insertQuery, connection);
        //    try
        //    {
        //        NUD_Entry.Text = command.ExecuteScalar().ToString();
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show(ex.Message);
        //    }
        //    connection.Close();
        //}

        void onlyNumbers(object sender, KeyPressEventArgs e)
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

        private bool _mouseDown;
        private Point lastLocation;

        public static string stringSQLShare;
        public static string stringEntryShare;

        Form_MainMenu mainmenu = new Form_MainMenu();

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void _Generate_SQL_NPC(object sender, EventArgs e)
        {
            uint npcflag_st = 0;
            uint unit_flags_st = 0;
            uint unit_flags2_st = 0;
            int dynamicflags_st = 0;
            uint type_flags_st = 0;
            uint mechanic_immune_mask_st = 0;
            uint flags_extra_st = 0;
            int inhabitType_st = 0;

            string[] checkedIndicies1 = Properties.Settings.Default.NpcFlag.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
            for (int i1 = 0; i1 < checkedIndicies1.Length; i1++)
            {
                int idx;
                if ((int.TryParse(checkedIndicies1[i1], out idx)))
                {
                    switch (idx)
                    {
                        case 0: // Gossip
                            npcflag_st += 0x00000001;
                            break;
                        case 1: // Quest Giver
                            npcflag_st += 0x00000002;
                            break;
                        case 2: // Trainer
                            npcflag_st += 0x00000010;
                            break;
                        case 3: // Class Trainer
                            npcflag_st += 0x00000020;
                            break;
                        case 4: // Profession Trainer
                            npcflag_st += 0x00000040;
                            break;
                        case 5: // Vendor
                            npcflag_st += 0x00000080;
                            break;
                        case 6: // Vendor Ammo
                            npcflag_st += 0x00000100;
                            break;
                        case 7: // Vendor Food
                            npcflag_st += 0x00000200;
                            break;
                        case 8: // Vendor Poison
                            npcflag_st += 0x00000400;
                            break;
                        case 9: // Vendor Reagent
                            npcflag_st += 0x00000800;
                            break;
                        case 10: // Repairer
                            npcflag_st += 0x00001000;
                            break;
                        case 11: // Flight Master
                            npcflag_st += 0x00002000;
                            break;
                        case 12: // Spirit Healer
                            npcflag_st += 0x00004000;
                            break;
                        case 13: // Spirit Guide
                            npcflag_st += 0x00008000;
                            break;
                        case 14: // Innkeeper
                            npcflag_st += 0x00010000;
                            break;
                        case 15: // Banker
                            npcflag_st += 0x00020000;
                            break;
                        case 16: // Petitioner
                            npcflag_st += 0x00040000;
                            break;
                        case 17: // Tabard Designer
                            npcflag_st += 0x00080000;
                            break;
                        case 18: // Battlemaster
                            npcflag_st += 0x00100000;
                            break;
                        case 19: // Auctioneer
                            npcflag_st += 0x00200000;
                            break;
                        case 20: // Stable Master
                            npcflag_st += 0x00400000;
                            break;
                        case 21: // Guild Banker
                            npcflag_st += 0x00800000;
                            break;
                        case 22: // Spellclick
                            npcflag_st += 0x01000000;
                            break;
                        case 23: // Mailbox
                            npcflag_st += 0x04000000;
                            break;
                    }
                }
            }

            string[] checkedIndicies2 = Properties.Settings.Default.UnitFlags.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
            for (int i1 = 0; i1 < checkedIndicies2.Length; i1++)
            {
                int idx;
                if ((int.TryParse(checkedIndicies2[i1], out idx)))
                {
                    switch (idx)
                    {
                        case 0: // UNIT_FLAG_SERVER_CONTROLLED
                            unit_flags_st += 0x00000001;
                            break;
                        case 1: // UNIT_FLAG_NON_ATTACKABLE
                            unit_flags_st += 0x00000002;
                            break;
                        case 2: // UNIT_FLAG_REMOVE_CLIENT_CONTROL
                            unit_flags_st += 0x00000004;
                            break;
                        case 3: // UNIT_FLAG_PVP_ATTACKABLE
                            unit_flags_st += 0x00000008;
                            break;
                        case 4: // UNIT_FLAG_RENAME
                            unit_flags_st += 0x00000010;
                            break;
                        case 5: // UNIT_FLAG_PREPARATION
                            unit_flags_st += 0x00000020;
                            break;
                        case 6: // UNIT_FLAG_UNK_6
                            unit_flags_st += 0x00000040;
                            break;
                        case 7: // UNIT_FLAG_NOT_ATTACKABLE_1
                            unit_flags_st += 0x00000080;
                            break;
                        case 8: // UNIT_FLAG_IMMUNE_TO_PC
                            unit_flags_st += 0x00000100;
                            break;
                        case 9: // UNIT_FLAG_IMMUNE_TO_NPC
                            unit_flags_st += 0x00000200;
                            break;
                        case 10: // UNIT_FLAG_LOOTING
                            unit_flags_st += 0x00000400;
                            break;
                        case 11: // UNIT_FLAG_PET_IN_COMBAT
                            unit_flags_st += 0x00000800;
                            break;
                        case 12: // UNIT_FLAG_PVP
                            unit_flags_st += 0x00001000;
                            break;
                        case 13: // UNIT_FLAG_SILENCED
                            unit_flags_st += 0x00002000;
                            break;
                        case 14: // UNIT_FLAG_CANNOT_SWIM
                            unit_flags_st += 0x00004000;
                            break;
                        case 15: // UNIT_FLAG_UNK_15
                            unit_flags_st += 0x00008000;
                            break;
                        case 16: // UNIT_FLAG_UNK_16
                            unit_flags_st += 0x00010000;
                            break;
                        case 17: // UNIT_FLAG_PACIFIED
                            unit_flags_st += 0x00020000;
                            break;
                        case 18: // UNIT_FLAG_STUNNED
                            unit_flags_st += 0x00040000;
                            break;
                        case 19: // UNIT_FLAG_IN_COMBAT
                            unit_flags_st += 0x00080000;
                            break;
                        case 20: // UNIT_FLAG_TAXI_FLIGHT
                            unit_flags_st += 0x00100000;
                            break;
                        case 21: // UNIT_FLAG_DISARMED
                            unit_flags_st += 0x00200000;
                            break;
                        case 22: // UNIT_FLAG_CONFUSED
                            unit_flags_st += 0x00400000;
                            break;
                        case 23: // UNIT_FLAG_FLEEING
                            unit_flags_st += 0x00800000;
                            break;
                        case 24: // UNIT_FLAG_PLAYER_CONTROLLED
                            unit_flags_st += 0x01000000;
                            break;
                        case 25: // UNIT_FLAG_NOT_SELECTABLE
                            unit_flags_st += 0x02000000;
                            break;
                        case 26: // UNIT_FLAG_SKINNABLE
                            unit_flags_st += 0x04000000;
                            break;
                        case 27: // UNIT_FLAG_MOUNT
                            unit_flags_st += 0x08000000;
                            break;
                        case 28: // UNIT_FLAG_UNK_28
                            unit_flags_st += 0x10000000;
                            break;
                        case 29: // UNIT_FLAG_UNK_29
                            unit_flags_st += 0x20000000;
                            break;
                        case 30: // UNIT_FLAG_SHEATHE
                            unit_flags_st += 0x40000000;
                            break;
                        case 31: // UNIT_FLAG_UNK_31
                            unit_flags_st += 0x80000000;
                            break;
                    }
                }
            }

            string[] checkedIndicies3 = Properties.Settings.Default.UnitFlags2.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
            for (int i1 = 0; i1 < checkedIndicies3.Length; i1++)
            {
                int idx;
                if ((int.TryParse(checkedIndicies3[i1], out idx)))
                {
                    switch (idx)
                    {
                        case 0: // UNIT_FLAG2_FEIGN_DEATH
                            unit_flags2_st += 0x00000001;
                            break;
                        case 1: // UNIT_FLAG2_UNK1
                            unit_flags2_st += 0x00000002;
                            break;
                        case 2: // UNIT_FLAG2_IGNORE_REPUTATION
                            unit_flags2_st += 0x00000004;
                            break;
                        case 3: // UNIT_FLAG2_COMPREHEND_LANG
                            unit_flags2_st += 0x00000008;
                            break;
                        case 4: // UNIT_FLAG2_MIRROR_IMAGE
                            unit_flags2_st += 0x00000010;
                            break;
                        case 5: // UNIT_FLAG2_INSTANTLY_APPEAR_MODEL
                            unit_flags2_st += 0x00000020;
                            break;
                        case 6: // UNIT_FLAG2_FORCE_MOVEMENT
                            unit_flags2_st += 0x00000040;
                            break;
                        case 7: // UNIT_FLAG2_DISARM_OFFHAND
                            unit_flags2_st += 0x00000080;
                            break;
                        case 8: // UNIT_FLAG2_DISABLE_PRED_STATS
                            unit_flags2_st += 0x00000100;
                            break;
                        case 9: // UNIT_FLAG2_DISARM_RANGED
                            unit_flags2_st += 0x00000400;
                            break;
                        case 10: // UNIT_FLAG2_REGENERATE_POWER
                            unit_flags2_st += 0x00000800;
                            break;
                        case 11: // UNIT_FLAG2_RESTRICT_PARTY_INTERACTION
                            unit_flags2_st += 0x00001000;
                            break;
                        case 12: // UNIT_FLAG2_PREVENT_SPELL_CLICK
                            unit_flags2_st += 0x00002000;
                            break;
                        case 13: // UNIT_FLAG2_ALLOW_ENEMY_INTERACT
                            unit_flags2_st += 0x00004000;
                            break;
                        case 14: // UNIT_FLAG2_DISABLE_TURN
                            unit_flags2_st += 0x00008000;
                            break;
                        case 15: // UNIT_FLAG2_UNK2
                            unit_flags2_st += 0x00010000;
                            break;
                        case 16: // UNIT_FLAG2_PLAY_DEATH_ANIM
                            unit_flags2_st += 0x00020000;
                            break;
                        case 17: // UNIT_FLAG2_ALLOW_CHEAT_SPELLS
                            unit_flags2_st += 0x00040000;
                            break;
                    }
                }
            }

            string[] checkedIndicies4 = Properties.Settings.Default.DynamicFlags.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
            for (int i1 = 0; i1 < checkedIndicies4.Length; i1++)
            {
                int idx;
                if ((int.TryParse(checkedIndicies4[i1], out idx)))
                {
                    switch (idx)
                    {
                        case 0: // UNIT_DYNFLAG_NONE
                            dynamicflags_st += 0x00;
                            break;
                        case 1: // UNIT_DYNFLAG_NONE
                            dynamicflags_st += 0x01;
                            break;
                        case 2: // UNIT_DYNFLAG_NONE
                            dynamicflags_st += 0x02;
                            break;
                        case 3: // UNIT_DYNFLAG_NONE
                            dynamicflags_st += 0x04;
                            break;
                        case 4: // UNIT_DYNFLAG_NONE
                            dynamicflags_st += 0x08;
                            break;
                        case 5: // UNIT_DYNFLAG_NONE
                            dynamicflags_st += 0x10;
                            break;
                        case 6: // UNIT_DYNFLAG_NONE
                            dynamicflags_st += 0x20;
                            break;
                        case 7: // UNIT_DYNFLAG_NONE
                            dynamicflags_st += 0x40;
                            break;
                        case 8: // UNIT_DYNFLAG_NONE
                            dynamicflags_st += 0x80;
                            break;
                    }
                }
            }

            string[] checkedIndicies5 = Properties.Settings.Default.TypeFlags.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
            for (int i1 = 0; i1 < checkedIndicies5.Length; i1++)
            {
                int idx;
                if ((int.TryParse(checkedIndicies5[i1], out idx)))
                {
                    switch (idx)
                    {
                        case 0: // CREATURE_TYPEFLAGS_TAMEABLE
                            type_flags_st += 0x00000001;
                            break;
                        case 1: // CREATURE_TYPEFLAGS_GHOST
                            type_flags_st += 0x00000002;
                            break;
                        case 2: // CREATURE_TYPEFLAGS_BOSS
                            type_flags_st += 0x00000004;
                            break;
                        case 3: // CREATURE_TYPEFLAGS_DO_NOT_PLAY_WOUND_PARRY_ANIMATION
                            type_flags_st += 0x00000008;
                            break;
                        case 4: // CREATURE_TYPEFLAGS_HIDE_FACTION_TOOLTIP
                            type_flags_st += 0x00000010;
                            break;
                        case 5: // CREATURE_TYPEFLAGS_UNK6
                            type_flags_st += 0x00000020;
                            break;
                        case 6: // CREATURE_TYPEFLAGS_SPELL_ATTACKABLE
                            type_flags_st += 0x00000040;
                            break;
                        case 7: // CREATURE_TYPEFLAGS_DEAD_INTERACT
                            type_flags_st += 0x00000080;
                            break;
                        case 8: // CREATURE_TYPEFLAGS_HERBLOOT
                            type_flags_st += 0x00000100;
                            break;
                        case 9: // CREATURE_TYPEFLAGS_MININGLOOT
                            type_flags_st += 0x00000200;
                            break;
                        case 10: // CREATURE_TYPEFLAGS_DONT_LOG_DEATH
                            type_flags_st += 0x00000400;
                            break;
                        case 11: // CREATURE_TYPEFLAGS_MOUNTED_COMBAT
                            type_flags_st += 0x00000800;
                            break;
                        case 12: // CREATURE_TYPEFLAGS_AID_PLAYERS
                            type_flags_st += 0x00001000;
                            break;
                        case 13: // CREATURE_TYPEFLAGS_IS_PET_BAR_USED
                            type_flags_st += 0x00002000;
                            break;
                        case 14: // CREATURE_TYPEFLAGS_MASK_UID
                            type_flags_st += 0x00004000;
                            break;
                        case 15: // CREATURE_TYPEFLAGS_ENGINEERLOOT
                            type_flags_st += 0x00008000;
                            break;
                        case 16: // CREATURE_TYPEFLAGS_EXOTIC
                            type_flags_st += 0x00010000;
                            break;
                        case 17: // CREATURE_TYPEFLAGS_USE_DEFAULT_COLLISION_BOX
                            type_flags_st += 0x00020000;
                            break;
                        case 18: // CREATURE_TYPEFLAGS_IS_SIEGE_WEAPON
                            type_flags_st += 0x00040000;
                            break;
                        case 19: // CREATURE_TYPEFLAGS_PROJECTILE_COLLISION
                            type_flags_st += 0x00080000;
                            break;
                        case 20: // CREATURE_TYPEFLAGS_HIDE_NAMEPLATE
                            type_flags_st += 0x00100000;
                            break;
                        case 21: // CREATURE_TYPEFLAGS_DO_NOT_PLAY_MOUNTED_ANIMATIONS
                            type_flags_st += 0x00200000;
                            break;
                        case 22: // CREATURE_TYPEFLAGS_IS_LINK_ALL
                            type_flags_st += 0x00400000;
                            break;
                        case 23: // CREATURE_TYPEFLAGS_INTERACT_ONLY_WITH_CREATOR
                            type_flags_st += 0x00800000;
                            break;
                        case 24: // CREATURE_TYPEFLAGS_FORCE_GOSSIP
                            type_flags_st += 0x08000000;
                            break;
                    }
                }
            }

            string[] checkedIndicies6 = Properties.Settings.Default.MechanicImmuneMask.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
            for (int i1 = 0; i1 < checkedIndicies6.Length; i1++)
            {
                int idx;
                if ((int.TryParse(checkedIndicies6[i1], out idx)))
                {
                    switch (idx)
                    {
                        case 0: // MECHANIC_CHARM
                            mechanic_immune_mask_st += 0x00000001;
                            break;
                        case 1: // MECHANIC_DISORIENTED
                            mechanic_immune_mask_st += 0x00000002;
                            break;
                        case 2: // MECHANIC_DISARM
                            mechanic_immune_mask_st += 0x00000004;
                            break;
                        case 3: // MECHANIC_DISTRACT
                            mechanic_immune_mask_st += 0x00000008;
                            break;
                        case 4: // MECHANIC_FEAR
                            mechanic_immune_mask_st += 0x00000010;
                            break;
                        case 5: // MECHANIC_GRIP
                            mechanic_immune_mask_st += 0x00000020;
                            break;
                        case 6: // MECHANIC_ROOT
                            mechanic_immune_mask_st += 0x00000040;
                            break;
                        case 7: // MECHANIC_PACIFY
                            mechanic_immune_mask_st += 0x00000080;
                            break;
                        case 8: // MECHANIC_SILENCE
                            mechanic_immune_mask_st += 0x00000100;
                            break;
                        case 9: // MECHANIC_SLEEP
                            mechanic_immune_mask_st += 0x00000200;
                            break;
                        case 10: // MECHANIC_SNARE
                            mechanic_immune_mask_st += 0x00000400;
                            break;
                        case 11: // MECHANIC_STUN
                            mechanic_immune_mask_st += 0x00000800;
                            break;
                        case 12: // MECHANIC_FREEZE
                            mechanic_immune_mask_st += 0x00001000;
                            break;
                        case 13: // MECHANIC_KNOCKOUT
                            mechanic_immune_mask_st += 0x00002000;
                            break;
                        case 14: // MECHANIC_BLEED
                            mechanic_immune_mask_st += 0x00004000;
                            break;
                        case 15: // MECHANIC_BANDAGE
                            mechanic_immune_mask_st += 0x00008000;
                            break;
                        case 16: // MECHANIC_POLYMORPH
                            mechanic_immune_mask_st += 0x00010000;
                            break;
                        case 17: // MECHANIC_BANISH
                            mechanic_immune_mask_st += 0x00020000;
                            break;
                        case 18: // MECHANIC_SHIELD
                            mechanic_immune_mask_st += 0x00040000;
                            break;
                        case 19: // MECHANIC_SHACKLE
                            mechanic_immune_mask_st += 0x00080000;
                            break;
                        case 20: // MECHANIC_MOUNT
                            mechanic_immune_mask_st += 0x00100000;
                            break;
                        case 21: // MECHANIC_INFECTED
                            mechanic_immune_mask_st += 0x00200000;
                            break;
                        case 22: // MECHANIC_TURN
                            mechanic_immune_mask_st += 0x00400000;
                            break;
                        case 23: // MECHANIC_HORROR
                            mechanic_immune_mask_st += 0x00800000;
                            break;
                        case 24: // MECHANIC_INVULNERABILITY
                            mechanic_immune_mask_st += 0x01000000;
                            break;
                        case 25: // MECHANIC_INTERRUPT
                            mechanic_immune_mask_st += 0x02000000;
                            break;
                        case 26: // MECHANIC_DAZE
                            mechanic_immune_mask_st += 0x04000000;
                            break;
                        case 27: // MECHANIC_DISCOVERY
                            mechanic_immune_mask_st += 0x08000000;
                            break;
                        case 28: // MECHANIC_IMMUNE_SHIELD
                            mechanic_immune_mask_st += 0x10000000;
                            break;
                        case 29: // MECHANIC_SAPPED
                            mechanic_immune_mask_st += 0x20000000;
                            break;
                        case 30: // MECHANIC_ENRAGED
                            mechanic_immune_mask_st += 0x40000000;
                            break;
                    }
                }
            }

            string[] checkedIndicies7 = Properties.Settings.Default.FlagsExtra.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
            for (int i1 = 0; i1 < checkedIndicies7.Length; i1++)
            {
                int idx;
                if ((int.TryParse(checkedIndicies7[i1], out idx)))
                {
                    switch (idx)
                    {
                        case 0: // CREATURE_FLAG_EXTRA_INSTANCE_BIND
                            flags_extra_st += 0x00000001;
                            break;
                        case 1: // CREATURE_FLAG_EXTRA_CIVILIAN
                            flags_extra_st += 0x00000002;
                            break;
                        case 2: // CREATURE_FLAG_EXTRA_NO_PARRY
                            flags_extra_st += 0x00000004;
                            break;
                        case 3: // CREATURE_FLAG_EXTRA_NO_PARRY_HASTEN
                            flags_extra_st += 0x00000008;
                            break;
                        case 4: // CREATURE_FLAG_EXTRA_NO_BLOCK
                            flags_extra_st += 0x00000010;
                            break;
                        case 5: // CREATURE_FLAG_EXTRA_NO_CRUSH
                            flags_extra_st += 0x00000020;
                            break;
                        case 6: // CREATURE_FLAG_EXTRA_NO_XP_AT_KILL
                            flags_extra_st += 0x00000040;
                            break;
                        case 7: // CREATURE_FLAG_EXTRA_TRIGGER
                            flags_extra_st += 0x00000080;
                            break;
                        case 8: // CREATURE_FLAG_EXTRA_NO_TAUNT
                            flags_extra_st += 0x00000100;
                            break;
                        case 9: // CREATURE_FLAG_EXTRA_NO_MOVE_FLAGS_UPDATE
                            flags_extra_st += 0x00000200;
                            break;
                        case 10: // CREATURE_FLAG_EXTRA_WORLDEVENT
                            flags_extra_st += 0x00004000;
                            break;
                        case 11: // CREATURE_FLAG_EXTRA_GUARD
                            flags_extra_st += 0x00008000;
                            break;
                        case 12: // CREATURE_FLAG_EXTRA_NO_CRIT
                            flags_extra_st += 0x00020000;
                            break;
                        case 13: // CREATURE_FLAG_EXTRA_NO_SKILLGAIN
                            flags_extra_st += 0x00040000;
                            break;
                        case 14: // CREATURE_FLAG_EXTRA_TAUNT_DIMINISH
                            flags_extra_st += 0x00080000;
                            break;
                        case 15: // CREATURE_FLAG_EXTRA_ALL_DIMINISH
                            flags_extra_st += 0x00100000;
                            break;
                        case 16: // CREATURE_FLAG_EXTRA_NO_PLAYER_DAMAGE_REQ
                            flags_extra_st += 0x00200000;
                            break;
                        case 17: // CREATURE_FLAG_EXTRA_DUNGEON_BOSS
                            flags_extra_st += 0x10000000;
                            break;
                        case 18: // CREATURE_FLAG_EXTRA_IGNORE_PATHFINDING
                            flags_extra_st += 0x20000000;
                            break;
                        case 19: // CREATURE_FLAG_EXTRA_IMMUNITY_KNOCKBACK
                            flags_extra_st += 0x40000000;
                            break;
                    }
                }
            }

            string[] checkedIndicies8 = Properties.Settings.Default.InhabitType.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
            for (int i1 = 0; i1 < checkedIndicies8.Length; i1++)
            {
                int idx;
                if ((int.TryParse(checkedIndicies8[i1], out idx)))
                {
                    switch (idx)
                    {
                        case 0:
                            inhabitType_st += 1; // Ground
                            break;
                        case 1:
                            inhabitType_st += 2; // Water
                            break;
                        case 2:
                            inhabitType_st += 4; // Flying
                            break;
                        case 3:
                            inhabitType_st += 8; // Rooted
                            break;
                    }
                }
            }

            int _rank = comboBox2.SelectedIndex;
            switch (_rank)
            {
                case 0:
                    _rank = 0; // Normal
                    break;
                case 1:
                    _rank = 1; // Elite
                    break;
                case 2:
                    _rank = 2; // Rare Elite
                    break;
                case 3:
                    _rank = 3; // Boss
                    break;
                case 4:
                    _rank = 4; // Rare
                    break;
            }

            int _dmgschool = comboBox3.SelectedIndex;
            switch (_dmgschool)
            {
                case 0:
                    _dmgschool = 0; // SPELL_SCHOOL_NORMAL
                    break;
                case 1:
                    _dmgschool = 1; // SPELL_SCHOOL_HOLY
                    break;
                case 2:
                    _dmgschool = 2; // SPELL_SCHOOL_FIRE
                    break;
                case 3:
                    _dmgschool = 3; // SPELL_SCHOOL_NATURE
                    break;
                case 4:
                    _dmgschool = 4; // SPELL_SCHOOL_FROST
                    break;
                case 5:
                    _dmgschool = 5; // SPELL_SCHOOL_SHADOW
                    break;
                case 6:
                    _dmgschool = 6; // SPELL_SCHOOL_ARCANE
                    break;
            }

            int _type = comboBox7.SelectedIndex;
            switch (_type)
            {
                case 0:
                    _type = 0; // None
                    break;
                case 1:
                    _type = 1; // Beast
                    break;
                case 2:
                    _type = 2; // Dragonkin
                    break;
                case 3:
                    _type = 3; // Demon
                    break;
                case 4:
                    _type = 4; // Elemental
                    break;
                case 5:
                    _type = 5; // Giant
                    break;
                case 6:
                    _type = 6; // Undead
                    break;
                case 7:
                    _type = 7; // Humanoid
                    break;
                case 8:
                    _type = 8; // Critter
                    break;
                case 9:
                    _type = 9; // Mechanical
                    break;
                case 10:
                    _type = 10; // Not specified
                    break;
                case 11:
                    _type = 11; // Totem
                    break;
                case 12:
                    _type = 12; // Non-Combat Pet
                    break;
                case 13:
                    _type = 13; // Gas Cloud
                    break;
                case 14:
                    _type = 14; // Wild Pet
                    break;
                case 15:
                    _type = 15; // Aberration
                    break;
            }

            int _trainer_type = comboBox6.SelectedIndex;
            switch (_trainer_type)
            {
                case 0:
                    _trainer_type = 0; // TRAINER_TYPE_CLASS
                    break;
                case 1:
                    _trainer_type = 1; // TRAINER_TYPE_MOUNTS
                    break;
                case 2:
                    _trainer_type = 2; // TRAINER_TYPE_TRADESKILLS
                    break;
                case 3:
                    _trainer_type = 3; // TRAINER_TYPE_PETS	
                    break;
            }

            // Prepare SQL
            // select insertion columns
            string BuildSQLFile;
            BuildSQLFile = textBox105.Text + $" INTO { form_MM.GetWorldDB() }.creature_template (entry, difficulty_entry_1, difficulty_entry_2, difficulty_entry_3, KillCredit1, ";
            BuildSQLFile += "KillCredit2, modelid1, modelid2, modelid3, modelid4, name, subname, IconName, gossip_menu_id, minlevel, ";
            BuildSQLFile += "maxlevel, exp, faction, npcflag, speed_walk, speed_run, scale, rank, dmgschool, BaseAttackTime, ";
            BuildSQLFile += "RangeAttackTime, BaseVariance, RangeVariance, unit_class, unit_flags, unit_flags2, dynamicflags, family, ";
            BuildSQLFile += "trainer_type, trainer_spell, trainer_class, trainer_race, type, type_flags, lootid, pickpocketloot, skinloot, ";
            BuildSQLFile += "resistance1, resistance2, resistance3, resistance4, resistance5, resistance6, spell1, spell2, spell3, ";
            BuildSQLFile += "spell4, spell5, spell6, spell7, spell8, PetSpellDataId, VehicleId, mingold, maxgold, AIName, MovementType, ";
            BuildSQLFile += "InhabitType, HoverHeight, HealthModifier, ManaModifier, ArmorModifier, DamageModifier, ExperienceModifier, ";
            BuildSQLFile += "RacialLeader, movementId, RegenHealth, mechanic_immune_mask, flags_extra, ScriptName, VerifiedBuild) ";

            // values now
            BuildSQLFile += $"VALUES { Environment.NewLine }";
            BuildSQLFile += "(";
            BuildSQLFile += NUD_Entry.Value + ", "; // entry
            BuildSQLFile += textBox3.Text + ", "; // difficulty_entry_1
            BuildSQLFile += textBox2.Text + ", "; // difficulty_entry_2
            BuildSQLFile += textBox4.Text + ", "; // difficulty_entry_3
            BuildSQLFile += textBox5.Text + ", "; // KillCredit1
            BuildSQLFile += textBox6.Text + ", "; // KillCredit2

            if (textBox10.Text == "") BuildSQLFile += "0, "; else
            BuildSQLFile += textBox10.Text + ", "; // modelid1

            if (textBox11.Text == "") BuildSQLFile += "0, "; else
            BuildSQLFile += textBox11.Text + ", "; // modelid2

            if (textBox9.Text == "") BuildSQLFile += "0, "; else
            BuildSQLFile += textBox9.Text + ", "; // modelid3

            if (textBox8.Text == "") BuildSQLFile += "0, "; else
            BuildSQLFile += textBox8.Text + ", "; // modelid4

            BuildSQLFile += "'" + textBox7.Text + "', "; // name
            BuildSQLFile += "'" + textBox12.Text + "', "; // subname
            BuildSQLFile += "'" + comboBox1.Text + "', "; // IconName

            //int IconName = comboBox1.SelectedIndex;
            //switch (IconName)
            //{
            //    case 0:
            //        BuildSQLFile += "'" + "Directions" + "', ";
            //        break;
            //    case 1:
            //        BuildSQLFile += "'" + "Gunner" + "', ";
            //        break;
            //    case 2:
            //        BuildSQLFile += "'" + "vehichleCursor" + "', ";
            //        break;
            //    case 3:
            //        BuildSQLFile += "'" + "Driver" + "', ";
            //        break;
            //    case 4:
            //        BuildSQLFile += "'" + "Attack" + "', ";
            //        break;
            //    case 5:
            //        BuildSQLFile += "'" + "Buy" + "', ";
            //        break;
            //    case 6:
            //        BuildSQLFile += "'" + "Speak" + "', ";
            //        break;
            //    case 7:
            //        BuildSQLFile += "'" + "Pickup" + "', ";
            //        break;
            //    case 8:
            //        BuildSQLFile += "'" + "Interact" + "', ";
            //        break;
            //    case 9:
            //        BuildSQLFile += "'" + "Trainer" + "', ";
            //        break;
            //    case 10:
            //        BuildSQLFile += "'" + "Taxi" + "', ";
            //        break;
            //    case 11:
            //        BuildSQLFile += "'" + "Repair" + "', ";
            //        break;
            //    case 12:
            //        BuildSQLFile += "'" + "LootAll" + "', ";
            //        break;
            //    case 13:
            //        BuildSQLFile += "'" + "Quest" + "', ";
            //        break;
            //    case 14:
            //        BuildSQLFile += "'" + "PVP" + "', ";
            //        break;
            //}

            if (textBox13.Text == "") BuildSQLFile += "0, "; else
            BuildSQLFile += textBox13.Text + ", "; // gossip_menu_id

            if (textBox14.Text == "") BuildSQLFile += "1, "; else
            BuildSQLFile += textBox14.Text + ", "; // minlevel

            if (textBox15.Text == "") BuildSQLFile += "1, "; else
            BuildSQLFile += textBox15.Text + ", "; // maxlevel

            if (textBox16.Text == "") BuildSQLFile += "0, "; else
            BuildSQLFile += textBox16.Text + ", "; // exp

            if (textBox17.Text == "") BuildSQLFile += "35, "; else
            BuildSQLFile += textBox17.Text + ", "; // faction

            BuildSQLFile += npcflag_st + ", "; // npcflag
            lblNpcFlag.Text = npcflag_st.ToString();
            //button3.TextAlign = ContentAlignment.MiddleLeft;
            //button3.Text = "Npc Flag = " + npcflag_st.ToString();

            if (textBox18.Text == "") BuildSQLFile += "1, "; else
            BuildSQLFile += textBox18.Text + ", "; // speed_walk

            if (textBox19.Text == "") BuildSQLFile += "1, "; else
            BuildSQLFile += textBox19.Text + ", "; // speed_run

            if (textBox20.Text == "") BuildSQLFile += "1, "; else
            BuildSQLFile += textBox20.Text + ", "; // scale

            BuildSQLFile += comboBox2.SelectedIndex + ", "; // rank
            BuildSQLFile += comboBox3.SelectedIndex + ", "; // dmgschool

            if (textBox26.Text == "") BuildSQLFile += "0, "; else
            BuildSQLFile += textBox26.Text + ", "; // BaseAttackTime

            if (textBox25.Text == "") BuildSQLFile += "0, "; else
            BuildSQLFile += textBox25.Text + ", "; // RangeAttackTime

            if (textBox28.Text == "") BuildSQLFile += "0, "; else
            BuildSQLFile += textBox28.Text + ", "; // BaseVariance

            if (textBox27.Text == "") BuildSQLFile += "0, "; else
            BuildSQLFile += textBox27.Text + ", "; // RangeVariance

            //BuildSQLFile += comboBox4.SelectedIndex + ", "; // unit_class
            int _unit_class = comboBox4.SelectedIndex;
            switch (_unit_class)
            {
                case 0:
                    BuildSQLFile += "1" + ", "; // CLASS_WARRIOR
                    break;
                case 1:
                    BuildSQLFile += "2" + ", "; // CLASS_PALADIN
                    break;
                case 2:
                    BuildSQLFile += "4" + ", "; // CLASS_ROGUE
                    break;
                case 3:
                    BuildSQLFile += "8" + ", "; // CLASS_MAGE
                    break;
            }
            BuildSQLFile += unit_flags_st + ", "; // unit_flags
            lblUnitFlags.Text = unit_flags_st.ToString();

            BuildSQLFile += unit_flags2_st + ", "; // unit_flags2
            BuildSQLFile += dynamicflags_st + ", "; // dynamicflags
            lblDynamicFlags.Text = dynamicflags_st.ToString();

            //BuildSQLFile += comboBox5.SelectedIndex + ", "; // family
            int _family = comboBox5.SelectedIndex;
            switch (_family)
            {
                case 0:
                    BuildSQLFile += "1" + ", ";
                    // _family = 1; // Wolf
                    break;
                case 1:
                    BuildSQLFile += "2" + ", ";
                    //_family = 2; // Cat
                    break;
                case 2:
                    BuildSQLFile += "3" + ", ";
                    //_family = 3; // Spider
                    break;
                case 3:
                    BuildSQLFile += "4" + ", ";
                    // _family = 4; // Bear
                    break;
                case 4:
                    BuildSQLFile += "5" + ", ";
                    // _family = 5; // Boar
                    break;
                case 5:
                    BuildSQLFile += "6" + ", ";
                    // _family = 6; // Crocolisk
                    break;
                case 6:
                    BuildSQLFile += "7" + ", ";
                    // _family = 7; // Carrion Bird
                    break;
                case 7:
                    BuildSQLFile += "8" + ", ";
                    //_family = 8; // Crab
                    break;
                case 8:
                    BuildSQLFile += "9" + ", ";
                    //_family = 9; // Gorilla
                    break;
                case 9:
                    BuildSQLFile += "11" + ", ";
                    //_family = 11; // Raptor
                    break;
                case 10:
                    BuildSQLFile += "12" + ", ";
                    // _family = 12; // Tallstrider
                    break;
                case 11:
                    BuildSQLFile += "15" + ", ";
                    //_family = 15; // Felhunter
                    break;
                case 12:
                    BuildSQLFile += "16" + ", ";
                    // _family = 16; // Voidwalker
                    break;
                case 13:
                    BuildSQLFile += "17" + ", ";
                    // _family = 17; // Succubus
                    break;
                case 14:
                    BuildSQLFile += "19" + ", ";
                    // _family = 19; // Doomguard
                    break;
                case 15:
                    BuildSQLFile += "20" + ", ";
                    // _family = 20; // Scorpid
                    break;
                case 16:
                    BuildSQLFile += "21" + ", ";
                    //  _family = 21; // Turtle
                    break;
                case 17:
                    BuildSQLFile += "23" + ", ";
                    //  _family = 23; // Imp
                    break;
                case 18:
                    BuildSQLFile += "24" + ", ";
                    //  _family = 24; // Bat
                    break;
                case 19:
                    BuildSQLFile += "25" + ", ";
                    // _family = 25; // Hyena
                    break;
                case 20:
                    BuildSQLFile += "26" + ", ";
                    //  _family = 26; // Owl
                    break;
                case 21:
                    BuildSQLFile += "27" + ", ";
                    // _family = 27; // Wind Serpent
                    break;
                case 22:
                    BuildSQLFile += "28" + ", ";
                    // _family = 28; // Remote Control
                    break;
                case 23:
                    BuildSQLFile += "29" + ", ";
                    // _family = 29; // Felguard
                    break;
                case 24:
                    BuildSQLFile += "30" + ", ";
                    //_family = 30; // Dragonhawk
                    break;
                case 25:
                    BuildSQLFile += "31" + ", ";
                    // _family = 31; // Ravager
                    break;
                case 26:
                    BuildSQLFile += "32" + ", ";
                    //_family = 32; // Warp Stalker
                    break;
                case 27:
                    BuildSQLFile += "33" + ", ";
                    // _family = 33; // Sporebat
                    break;
                case 28:
                    BuildSQLFile += "34" + ", ";
                    // _family = 34; // Nether Ray
                    break;
                case 29:
                    BuildSQLFile += "35" + ", ";
                    // _family = 35; // Serpent
                    break;
                case 30:
                    BuildSQLFile += "37" + ", ";
                    //_family = 37; // Moth
                    break;
                case 31:
                    BuildSQLFile += "38" + ", ";
                    //_family = 38; // Chimaera
                    break;
                case 32:
                    BuildSQLFile += "39" + ", ";
                    // _family = 39; // Devilsaur
                    break;
                case 33:
                    BuildSQLFile += "40" + ", ";
                    //  _family = 40; // Ghoul
                    break;
                case 34:
                    BuildSQLFile += "41" + ", ";
                    // _family = 41; // Silithid
                    break;
                case 35:
                    BuildSQLFile += "42" + ", ";
                    // _family = 42; // Worm
                    break;
                case 36:
                    BuildSQLFile += "43" + ", ";
                    // _family = 43; // Rhino
                    break;
                case 37:
                    BuildSQLFile += "44" + ", ";
                    //_family = 44; // Wasp
                    break;
                case 38:
                    BuildSQLFile += "45" + ", ";
                    // _family = 45; // Core Hound
                    break;
                case 39:
                    BuildSQLFile += "46" + ", ";
                    //  _family = 46; // Spirit Beast
                    break;
            }
            BuildSQLFile += comboBox6.SelectedIndex + ", "; // trainer_type

            if (textBox30.Text == "") BuildSQLFile += "0, "; else
            BuildSQLFile += textBox30.Text + ", "; // trainer_spell

            if (textBox29.Text == "") BuildSQLFile += "0, "; else
            BuildSQLFile += textBox29.Text + ", "; // trainer_class

            if (textBox32.Text == "") BuildSQLFile += "0, "; else
            BuildSQLFile += textBox32.Text + ", "; // trainer_race

            BuildSQLFile += comboBox7.SelectedIndex + ", "; // type
            BuildSQLFile += type_flags_st + ", "; // type_flags

            if (textBox42.Text == "") BuildSQLFile += "0, "; else
            BuildSQLFile += textBox42.Text + ", "; // lootid

            if (textBox41.Text == "") BuildSQLFile += "0, "; else
            BuildSQLFile += textBox41.Text + ", "; // pickpocketloot

            if (textBox40.Text == "") BuildSQLFile += "0, "; else
            BuildSQLFile += textBox40.Text + ", "; // skinloot

            if (textBox39.Text == "") BuildSQLFile += "0, "; else
            BuildSQLFile += textBox39.Text + ", "; // resistance1

            if (textBox36.Text == "") BuildSQLFile += "0, "; else
            BuildSQLFile += textBox36.Text + ", "; // resistance2

            if (textBox35.Text == "") BuildSQLFile += "0, "; else
            BuildSQLFile += textBox35.Text + ", "; // resistance3

            if (textBox38.Text == "") BuildSQLFile += "0, "; else
            BuildSQLFile += textBox38.Text + ", "; // resistance4

            if (textBox37.Text == "") BuildSQLFile += "0, "; else
            BuildSQLFile += textBox37.Text + ", "; // resistance5

            if (textBox46.Text == "") BuildSQLFile += "0, "; else
            BuildSQLFile += textBox46.Text + ", "; // resistance6

            if (textBox45.Text == "") BuildSQLFile += "0, "; else
            BuildSQLFile += textBox45.Text + ", "; // spell1

            if (textBox44.Text == "") BuildSQLFile += "0, "; else
            BuildSQLFile += textBox44.Text + ", "; // spell2

            if (textBox43.Text == "") BuildSQLFile += "0, "; else
            BuildSQLFile += textBox43.Text + ", "; // spell3

            if (textBox52.Text == "") BuildSQLFile += "0, "; else
            BuildSQLFile += textBox52.Text + ", "; // spell4

            if (textBox51.Text == "") BuildSQLFile += "0, "; else
            BuildSQLFile += textBox51.Text + ", "; // spell5

            if (textBox50.Text == "") BuildSQLFile += "0, "; else
            BuildSQLFile += textBox50.Text + ", "; // spell6

            if (textBox49.Text == "") BuildSQLFile += "0, "; else
            BuildSQLFile += textBox49.Text + ", "; // spell7

            if (textBox48.Text == "") BuildSQLFile += "0, "; else
            BuildSQLFile += textBox48.Text + ", "; // spell8

            if (textBox47.Text == "") BuildSQLFile += "0, "; else
            BuildSQLFile += textBox47.Text + ", "; // PetSpellDataID

            if (textBox58.Text == "") BuildSQLFile += "0, "; else
            BuildSQLFile += textBox58.Text + ", "; // VehicleID

            if (textBox57.Text == "") BuildSQLFile += "0, "; else
            BuildSQLFile += textBox57.Text + ", "; // mingold

            if (textBox56.Text == "") BuildSQLFile += "0, "; else
            BuildSQLFile += textBox56.Text + ", "; // maxgold

            //BuildSQLFile += "'" + comboBox9.SelectedIndex + "', "; // AIName

            int AiName = comboBox9.SelectedIndex;
            switch (AiName)
            {
                case 0:
                    BuildSQLFile += "'" + "" + "', ";
                    break;
                case 1:
                    BuildSQLFile += "'" + "AggressorAI" + "', ";
                    break;
                case 2:
                    BuildSQLFile += "'" + "ReactorAI" + "', ";
                    break;
                case 3:
                    BuildSQLFile += "'" + "GuardAI" + "', ";
                    break;
                case 4:
                    BuildSQLFile += "'" + "PetAI" + "', ";
                    break;
                case 5:
                    BuildSQLFile += "'" + "TotemAI" + "', ";
                    break;
                case 6:
                    BuildSQLFile += "'" + "EventAI" + "', ";
                    break;
                case 7:
                    BuildSQLFile += "'" + "SmartAI" + "', ";
                    break;
            }

            BuildSQLFile += comboBox8.SelectedIndex + ", "; // MovementType
            //BuildSQLFile += comboBox10.SelectedIndex + ", "; // InhabitType
            InhabitType it = new InhabitType();

            //if (it.checkedListBox1.GetItemCheckState(0) == CheckState.Unchecked &&
            //    it.checkedListBox1.GetItemCheckState(1) == CheckState.Unchecked &&
            //    it.checkedListBox1.GetItemCheckState(2) == CheckState.Unchecked &&
            //    it.checkedListBox1.GetItemCheckState(3) == CheckState.Unchecked)
            //    BuildSQLFile += "1, "; // Ground
            //else
            //BuildSQLFile += inhabitType_st + ", "; // InhabitType
            int InhabitType = comboBox10.SelectedIndex;
            switch (InhabitType)
            {
                case 0:
                    BuildSQLFile += "1" + ", "; // Ground
                    break;
                case 1:
                    BuildSQLFile += "2" + ", "; // Water
                    break;
                case 2:
                    BuildSQLFile += "4" + ", "; // Flying
                    break;
                case 3:
                    BuildSQLFile += "8" + ", "; // Rooted
                    break;
            }

            if (textBox60.Text == "") BuildSQLFile += "0, "; else
            BuildSQLFile += textBox60.Text + ", "; // HoverHeight

            if (textBox54.Text == "") BuildSQLFile += "0, "; else
            BuildSQLFile += textBox54.Text + ", "; // HealthModifier

            if (textBox53.Text == "") BuildSQLFile += "0, "; else
            BuildSQLFile += textBox53.Text + ", "; // ManaModifier

            if (textBox64.Text == "") BuildSQLFile += "0, "; else
            BuildSQLFile += textBox64.Text + ", "; // ArmorModofier

            if (textBox61.Text == "") BuildSQLFile += "0, "; else
            BuildSQLFile += textBox61.Text + ", "; // DamageModifier

            if (textBox65.Text == "") BuildSQLFile += "0, "; else
            BuildSQLFile += textBox65.Text + ", "; // ExperienceModifier

            if (textBox66.Text == "") BuildSQLFile += "0, "; else
            BuildSQLFile += textBox66.Text + ", "; // RacialLeader

            if (textBox55.Text == "") BuildSQLFile += "0, "; else
            BuildSQLFile += textBox55.Text + ", "; // movementID

            if(CB_RegenHealth.SelectedIndex == 0) 
                BuildSQLFile += "0, "; // RegenHealth = False
            else
                BuildSQLFile += "1, "; // RegenHealth = True

            BuildSQLFile += mechanic_immune_mask_st + ", "; // mechanic_immune_mask
            BuildSQLFile += flags_extra_st + ", "; // flags_extra

            BuildSQLFile += "'" + textBox62.Text + "', "; // ScriptName

            if (textBox59.Text == "") BuildSQLFile += "0, "; else
            BuildSQLFile += textBox59.Text; // VerifiedBuild
            BuildSQLFile += ");";

            stringSQLShare = BuildSQLFile;
            stringEntryShare = NUD_Entry.Text;

            TXT_SQL.Text = BuildSQLFile;
        }

        private void GenerateSQLCode_NPC_Creator(object sender, EventArgs e)
        {
            if (comboBox11.SelectedIndex == 2)
                comboBox11.SelectedIndex = 0;

            _Generate_SQL_NPC(sender, e);

            if (string.IsNullOrWhiteSpace(NUD_Entry.Text))
            {
                MessageBox.Show("Entry should not be empty", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            using (var sfd = new SaveFileDialog())
            {
                sfd.Filter = "sql files (*.sql)|*.sql";
                sfd.FilterIndex = 2;
                //                                               name
                sfd.FileName = "NPC[" + stringEntryShare + "]" + textBox7.Text;

                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    File.WriteAllText(sfd.FileName, stringSQLShare);
                    timer3.Start();
                }
            }
        }

        private void label81_Click(object sender, EventArgs e)
        {
            AddVendorItems vendor = new AddVendorItems();
            vendor.Close();
            GenerateLoot gen = new GenerateLoot();
            gen.Close();
            MountNPC mount = new MountNPC();
            mount.Close();
            MakeNpcSay npcsay = new MakeNpcSay();
            npcsay.Close();
            AddGossipMenus gossip = new AddGossipMenus();
            gossip.Close();
            HowToAddWaypoints way = new HowToAddWaypoints();
            way.Close();

            Application.Exit();
        }

        private void label80_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private void label81_MouseEnter(object sender, EventArgs e)
        {
            label81.BackColor = Color.Firebrick;
        }

        private void label81_MouseLeave(object sender, EventArgs e)
        {
            label81.BackColor = Color.FromArgb(58, 89, 114);
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        void SetLightBlueColor_TextBoxActive(object sender, EventArgs e)
        {
            TextBox txt = sender as TextBox;
            NumericUpDown nud = sender as NumericUpDown;
            
            if (sender == txt)
                txt.BackColor = Color.FromArgb(179, 228, 255);               

            else
                nud.BackColor = Color.FromArgb(179, 228, 255);
        }

        void SetWhiteColor_TextBoxLeave(object sender, EventArgs e)
        {
            //TextBox txt = (TextBox)sender;
            TextBox txt = sender as TextBox;
            NumericUpDown nud = sender as NumericUpDown;
            
            if (sender == txt)
                txt.BackColor = Color.White;

            else
                nud.BackColor = Color.White;
        }

        void _textboxes()
        {

            
            NUD_Entry.Enter += SetLightBlueColor_TextBoxActive;
            NUD_Entry.Leave += SetWhiteColor_TextBoxLeave;
            textBox2.Enter += SetLightBlueColor_TextBoxActive;
            textBox2.Leave += SetWhiteColor_TextBoxLeave;
            textBox3.Enter += SetLightBlueColor_TextBoxActive;
            textBox3.Leave += SetWhiteColor_TextBoxLeave;
            textBox4.Enter += SetLightBlueColor_TextBoxActive;
            textBox4.Leave += SetWhiteColor_TextBoxLeave;
            textBox5.Enter += SetLightBlueColor_TextBoxActive;
            textBox5.Leave += SetWhiteColor_TextBoxLeave;
            textBox6.Enter += SetLightBlueColor_TextBoxActive;
            textBox6.Leave += SetWhiteColor_TextBoxLeave;
            textBox7.Enter += SetLightBlueColor_TextBoxActive;
            textBox7.Leave += SetWhiteColor_TextBoxLeave;
            textBox8.Enter += SetLightBlueColor_TextBoxActive;
            textBox8.Leave += SetWhiteColor_TextBoxLeave;
            textBox9.Enter += SetLightBlueColor_TextBoxActive;
            textBox9.Leave += SetWhiteColor_TextBoxLeave;
            textBox10.Enter += SetLightBlueColor_TextBoxActive;
            textBox10.Leave += SetWhiteColor_TextBoxLeave;
            textBox11.Enter += SetLightBlueColor_TextBoxActive;
            textBox11.Leave += SetWhiteColor_TextBoxLeave;
            textBox12.Enter += SetLightBlueColor_TextBoxActive;
            textBox12.Leave += SetWhiteColor_TextBoxLeave;
            textBox13.Enter += SetLightBlueColor_TextBoxActive;
            textBox13.Leave += SetWhiteColor_TextBoxLeave;
            textBox14.Enter += SetLightBlueColor_TextBoxActive;
            textBox14.Leave += SetWhiteColor_TextBoxLeave;
            textBox15.Enter += SetLightBlueColor_TextBoxActive;
            textBox15.Leave += SetWhiteColor_TextBoxLeave;
            textBox16.Enter += SetLightBlueColor_TextBoxActive;
            textBox16.Leave += SetWhiteColor_TextBoxLeave;
            textBox17.Enter += SetLightBlueColor_TextBoxActive;
            textBox17.Leave += SetWhiteColor_TextBoxLeave;
            textBox18.Enter += SetLightBlueColor_TextBoxActive;
            textBox18.Leave += SetWhiteColor_TextBoxLeave;
            textBox19.Enter += SetLightBlueColor_TextBoxActive;
            textBox19.Leave += SetWhiteColor_TextBoxLeave;
            textBox20.Enter += SetLightBlueColor_TextBoxActive;
            textBox20.Leave += SetWhiteColor_TextBoxLeave;
            textBox21.Enter += SetLightBlueColor_TextBoxActive;
            textBox21.Leave += SetWhiteColor_TextBoxLeave;
            textBox22.Enter += SetLightBlueColor_TextBoxActive;
            textBox22.Leave += SetWhiteColor_TextBoxLeave;
            textBox23.Enter += SetLightBlueColor_TextBoxActive;
            textBox23.Leave += SetWhiteColor_TextBoxLeave;
            textBox24.Enter += SetLightBlueColor_TextBoxActive;
            textBox24.Leave += SetWhiteColor_TextBoxLeave;
            textBox25.Enter += SetLightBlueColor_TextBoxActive;
            textBox25.Leave += SetWhiteColor_TextBoxLeave;
            textBox26.Enter += SetLightBlueColor_TextBoxActive;
            textBox26.Leave += SetWhiteColor_TextBoxLeave;
            textBox27.Enter += SetLightBlueColor_TextBoxActive;
            textBox27.Leave += SetWhiteColor_TextBoxLeave;
            textBox28.Enter += SetLightBlueColor_TextBoxActive;
            textBox28.Leave += SetWhiteColor_TextBoxLeave;
            textBox29.Enter += SetLightBlueColor_TextBoxActive;
            textBox29.Leave += SetWhiteColor_TextBoxLeave;
            textBox30.Enter += SetLightBlueColor_TextBoxActive;
            textBox30.Leave += SetWhiteColor_TextBoxLeave;
            textBox31.Enter += SetLightBlueColor_TextBoxActive;
            textBox31.Leave += SetWhiteColor_TextBoxLeave;
            textBox32.Enter += SetLightBlueColor_TextBoxActive;
            textBox32.Leave += SetWhiteColor_TextBoxLeave;
            textBox33.Enter += SetLightBlueColor_TextBoxActive;
            textBox33.Leave += SetWhiteColor_TextBoxLeave;
            textBox35.Enter += SetLightBlueColor_TextBoxActive;
            textBox35.Leave += SetWhiteColor_TextBoxLeave;
            textBox36.Enter += SetLightBlueColor_TextBoxActive;
            textBox36.Leave += SetWhiteColor_TextBoxLeave;
            textBox37.Enter += SetLightBlueColor_TextBoxActive;
            textBox37.Leave += SetWhiteColor_TextBoxLeave;
            textBox38.Enter += SetLightBlueColor_TextBoxActive;
            textBox38.Leave += SetWhiteColor_TextBoxLeave;
            textBox39.Enter += SetLightBlueColor_TextBoxActive;
            textBox39.Leave += SetWhiteColor_TextBoxLeave;
            textBox40.Enter += SetLightBlueColor_TextBoxActive;
            textBox40.Leave += SetWhiteColor_TextBoxLeave;
            textBox41.Enter += SetLightBlueColor_TextBoxActive;
            textBox41.Leave += SetWhiteColor_TextBoxLeave;
            textBox42.Enter += SetLightBlueColor_TextBoxActive;
            textBox42.Leave += SetWhiteColor_TextBoxLeave;
            textBox43.Enter += SetLightBlueColor_TextBoxActive;
            textBox43.Leave += SetWhiteColor_TextBoxLeave;
            textBox44.Enter += SetLightBlueColor_TextBoxActive;
            textBox44.Leave += SetWhiteColor_TextBoxLeave;
            textBox45.Enter += SetLightBlueColor_TextBoxActive;
            textBox45.Leave += SetWhiteColor_TextBoxLeave;
            textBox46.Enter += SetLightBlueColor_TextBoxActive;
            textBox46.Leave += SetWhiteColor_TextBoxLeave;
            textBox47.Enter += SetLightBlueColor_TextBoxActive;
            textBox47.Leave += SetWhiteColor_TextBoxLeave;
            textBox48.Enter += SetLightBlueColor_TextBoxActive;
            textBox48.Leave += SetWhiteColor_TextBoxLeave;
            textBox49.Enter += SetLightBlueColor_TextBoxActive;
            textBox49.Leave += SetWhiteColor_TextBoxLeave;
            textBox50.Enter += SetLightBlueColor_TextBoxActive;
            textBox50.Leave += SetWhiteColor_TextBoxLeave;
            textBox51.Enter += SetLightBlueColor_TextBoxActive;
            textBox51.Leave += SetWhiteColor_TextBoxLeave;
            textBox52.Enter += SetLightBlueColor_TextBoxActive;
            textBox52.Leave += SetWhiteColor_TextBoxLeave;
            textBox53.Enter += SetLightBlueColor_TextBoxActive;
            textBox53.Leave += SetWhiteColor_TextBoxLeave;
            textBox54.Enter += SetLightBlueColor_TextBoxActive;
            textBox54.Leave += SetWhiteColor_TextBoxLeave;
            textBox55.Enter += SetLightBlueColor_TextBoxActive;
            textBox55.Leave += SetWhiteColor_TextBoxLeave;
            textBox56.Enter += SetLightBlueColor_TextBoxActive;
            textBox56.Leave += SetWhiteColor_TextBoxLeave;
            textBox57.Enter += SetLightBlueColor_TextBoxActive;
            textBox57.Leave += SetWhiteColor_TextBoxLeave;
            textBox58.Enter += SetLightBlueColor_TextBoxActive;
            textBox58.Leave += SetWhiteColor_TextBoxLeave;
            textBox59.Enter += SetLightBlueColor_TextBoxActive;
            textBox59.Leave += SetWhiteColor_TextBoxLeave;
            textBox60.Enter += SetLightBlueColor_TextBoxActive;
            textBox60.Leave += SetWhiteColor_TextBoxLeave;
            textBox61.Enter += SetLightBlueColor_TextBoxActive;
            textBox61.Leave += SetWhiteColor_TextBoxLeave;
            textBox62.Enter += SetLightBlueColor_TextBoxActive;
            textBox62.Leave += SetWhiteColor_TextBoxLeave;
            //textBox63.Enter += SetLightBlueColor_TextBoxActive;
            //textBox63.Leave += SetWhiteColor_TextBoxLeave;
            textBox64.Enter += SetLightBlueColor_TextBoxActive;
            textBox64.Leave += SetWhiteColor_TextBoxLeave;
            textBox65.Enter += SetLightBlueColor_TextBoxActive;
            textBox65.Leave += SetWhiteColor_TextBoxLeave;
            textBox66.Enter += SetLightBlueColor_TextBoxActive;
            textBox66.Leave += SetWhiteColor_TextBoxLeave;
        }

        //private static MemoryStream cursorMemoryStream = new MemoryStream(Properties.Resources.Point);
        //private Cursor newCursor = new Cursor(cursorMemoryStream);

        private void SelectMySqlVersion()
        {
            GetMySqlConnection();
            try
            {
                connection.Open();
                lblMySqlVersion.Text = "MySql Version: " + connection.ServerVersion;
                connection.Close();
            }
            catch (MySqlException)
            {
                //MessageBox.Show(ex.Message, "SpawnCreator", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        private void NPC_Creator_Load(object sender, EventArgs e)
        {

            //size = 914, 533
            SelectMySqlVersion();

            textBox7.BringToFront();

            //var lines = File.ReadAllLines("ro-Language.lng");
            //string _line = File.ReadLines("ro-language.lng").Skip(1).Take(2).First();
            //label7.Text =_line ;
            

            //foreach (TextBox txtBox in groupBox2.Controls.OfType<TextBox>())
            //{
            //    txtBox.Enter += SetLightBlueColor_TextBoxActive;
            //    txtBox.Leave += SetWhiteColor_TextBoxLeave;
            //}
            //foreach (TextBox txtBox in groupBox1.Controls.OfType<TextBox>())
            //{
            //    txtBox.Enter += SetLightBlueColor_TextBoxActive;
            //    txtBox.Leave += SetWhiteColor_TextBoxLeave;
            //}
            //foreach (TextBox txtBox in groupBox3.Controls.OfType<TextBox>())
            //{
            //    txtBox.Enter += SetLightBlueColor_TextBoxActive;
            //    txtBox.Leave += SetWhiteColor_TextBoxLeave;
            //}


            //Cursor = newCursor;

            ////looping through all TextBoxes and change color to all of them
            //foreach (TextBox txtBox in groupBox2.Controls.OfType<TextBox>())
            //{
            //    txtBox.Text = "111";
            //    txtBox.ForeColor = Color.Red;
            //}


            //// This one works as well
            //foreach (Control c in groupBox1.Controls)
            //{
            //    if (c is TextBox)
            //    {
            //        c.Text = "111";
            //    }
            //}

            //_textboxes();

            timer9.Start();
            
            textBox45.KeyPress += onlyNumbers; // spell1
            textBox44.KeyPress += onlyNumbers; // spell2
            textBox45.KeyPress += onlyNumbers; // spell3
            textBox52.KeyPress += onlyNumbers; // spell4
            textBox51.KeyPress += onlyNumbers; // spell5
            textBox50.KeyPress += onlyNumbers; // spell6
            textBox49.KeyPress += onlyNumbers; // spell7
            textBox48.KeyPress += onlyNumbers; // spell8


            comboBox1.SelectedIndex = 6; // show Speak Icon
            comboBox3.SelectedIndex = 0; // show default item
            comboBox2.SelectedIndex = 2; // show default item
            comboBox5.SelectedIndex = 0; // show default item
            comboBox4.SelectedIndex = 0; // show default item
            comboBox6.SelectedIndex = 0; // show default item
            comboBox7.SelectedIndex = 7; // show Type = Humanoid
            comboBox8.SelectedIndex = 0; // show default item
            comboBox9.SelectedIndex = 0; // show default item
            comboBox10.SelectedIndex = 0; // show default item
            comboBox11.SelectedIndex = 0; // "INSERT INTO"
            CB_RegenHealth.SelectedIndex = 0; // RegenHeath = False

            timer1.Start(); //check if mysql is running
            timer2.Start(); //stopwatch


            if (form_MM.CB_NoMySQL.Checked)
            {
                label_mysql_status2.Visible = false;
                label85.Visible = false;
                timer1.Enabled = false; //check if mysql is running
                label_mysql_status2.Visible = false;
                label85.Visible = false; // MySQl Status - label
                button2.Visible = false; //max+1 button
                button25.Visible = false; //random button
                button10.Visible = false; // Execute Query - Bottom Button
                button16.Visible = false; // Max+1 Gossip Menu
                button12.Visible = false; // max+1 lootID
            }
            else
                //SelectMaxPlus1_FROM_creature_template();
                //mysql_Connect.SelectMaxPlus1_NPC(this);
                SelectMaxPlus1_NPC();
        }

        public bool IsProcessOpen(string name = "mysqld")
        {
            foreach (Process clsProcess in Process.GetProcesses())
            {
                if (clsProcess.ProcessName.Contains(name))
                {
                    label_mysql_status2.Text = "Connected!";
                    label_mysql_status2.ForeColor = Color.LawnGreen;
                    button2.Visible = true; //max+1 button
                    button10.Visible = true; // Execute Query - Bottom Button
                    button16.Visible = true; // Max+1 Gossip Menu
                    button12.Visible = true; // max+1 lootID
                    btn_DeleteQuery.Enabled = true;
                    return true;
                }
            }

            label_mysql_status2.Text = "Connection Lost - MySQL is not running";
            label_mysql_status2.ForeColor = Color.Red;
            button2.Visible = false; //max+1 button
            button10.Visible = false; // Execute Query - Bottom Button
            button16.Visible = false; // Max+1 Gossip Menu
            button12.Visible = false; // max+1 lootID
            btn_DeleteQuery.Enabled = false;
            return false;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            IsProcessOpen();
        }

        private void label80_MouseEnter(object sender, EventArgs e)
        {
            label80.BackColor = Color.Firebrick;
        }

        private void label80_MouseLeave(object sender, EventArgs e)
        {
            label80.BackColor = Color.FromArgb(58, 89, 114);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
            BackToMainMenu backtomainmenu = new BackToMainMenu(form_MM);
            backtomainmenu.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            NpcFlag npcflag = new NpcFlag();
            npcflag.ShowDialog();

            if (npcflag.checkedListBox1.GetItemCheckState(5/*Vendor*/) == CheckState.Checked)
                button13.Enabled = true;

            //else if (npcflag.checkedListBox1.GetItemCheckState(6/*Vendor Ammo*/) == CheckState.Checked)
            //    button13.Enabled = true;
            //else if (npcflag.checkedListBox1.GetItemCheckState(7/*Vendor Food*/) == CheckState.Checked)
            //    button13.Enabled = true;
            //else if (npcflag.checkedListBox1.GetItemCheckState(8/*Vendor Poison*/) == CheckState.Checked)
            //    button13.Enabled = true;
            //else if (npcflag.checkedListBox1.GetItemCheckState(9/*Vendor Reagent*/) == CheckState.Checked)
            //    button13.Enabled = true;

            else
                button13.Enabled = false;
        }

        private void panel2_MouseUp(object sender, MouseEventArgs e)
        {
            _mouseDown = false;
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

        private void panel2_MouseDown(object sender, MouseEventArgs e)
        {
            _mouseDown = true;
            lastLocation = e.Location;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex == 0) pictureBox1.Image = Properties.Resources.Directions;
            else if (comboBox1.SelectedIndex == 1) pictureBox1.Image  = Properties.Resources.Gunner;            
            else if (comboBox1.SelectedIndex == 2) pictureBox1.Image  = Properties.Resources.vehichleCursor;            
            else if (comboBox1.SelectedIndex == 3) pictureBox1.Image  = Properties.Resources.Driver;           
            else if (comboBox1.SelectedIndex == 4) pictureBox1.Image  = Properties.Resources.Attack;          
            else if (comboBox1.SelectedIndex == 5) pictureBox1.Image  = Properties.Resources.Buy;            
            else if (comboBox1.SelectedIndex == 6) pictureBox1.Image  = Properties.Resources.Speak;            
            else if (comboBox1.SelectedIndex == 7) pictureBox1.Image  = Properties.Resources.Pickup;            
            else if (comboBox1.SelectedIndex == 8) pictureBox1.Image  = Properties.Resources.Interact;            
            else if (comboBox1.SelectedIndex == 9) pictureBox1.Image  = Properties.Resources.Trainer;           
            else if (comboBox1.SelectedIndex == 10) pictureBox1.Image = Properties.Resources.Taxi;            
            else if (comboBox1.SelectedIndex == 11) pictureBox1.Image = Properties.Resources.Repair;            
            else if (comboBox1.SelectedIndex == 12) pictureBox1.Image = Properties.Resources.LootAll;            
            else if (comboBox1.SelectedIndex == 13) pictureBox1.Image = Properties.Resources.Quest;            
            else if (comboBox1.SelectedIndex == 14) pictureBox1.Image = Properties.Resources.PVP;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            unit_flags _unit_flags = new unit_flags();
            _unit_flags.ShowDialog();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            unit_flags2 _unit_flags2 = new unit_flags2();
            _unit_flags2.ShowDialog();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            dynamicflags _dynamicflags = new dynamicflags();
            _dynamicflags.ShowDialog();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            type_flags _type_flags = new type_flags();
            _type_flags.ShowDialog();


            if (comboBox2.SelectedIndex == 3 /*Boss*/ &&
                _type_flags.checkedListBox1.GetItemCheckState(2 /*CREATURE_TYPEFLAGS_BOSS*/) == CheckState.Checked)
            {
                LB_level.Visible = false;
                Skull_pic.Visible = true;
            }
            else
            {
                LB_level.Visible = true;
                Skull_pic.Visible = false;
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            mechanic_immune_mask _mec = new mechanic_immune_mask();
            _mec.ShowDialog();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            flags_extra _flags_extra = new flags_extra();
            _flags_extra.ShowDialog();
        }

        int idx = 1;
        DateTime dt = new DateTime();
        private void timer2_Tick(object sender, EventArgs e)
        {
            label_stopwatch.Text = dt.AddSeconds(idx).ToString("HH:mm:ss");
            idx++;
        }

        // Execute Query - Button
        private void button10_Click(object sender, EventArgs e)
        {
            if (comboBox11.SelectedIndex == 2)
                comboBox11.SelectedIndex = 0;

            _Generate_SQL_NPC(sender, e);

            if (string.IsNullOrWhiteSpace(NUD_Entry.Text))
            {
                MessageBox.Show("Entry should not be empty", "Error");
                return;
            }

            //GetMySqlConnection();

            string insertQuery = stringSQLShare;
            
            MySqlCommand command = new MySqlCommand(insertQuery, connection);

            try
            {
                connection.Open();
                command.ExecuteNonQuery();
                timer5.Start();
               
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message, "SpawnCreator", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                connection.Close();
            }
        }

        private void timer3_Tick(object sender, EventArgs e)
        {
            label_file_saved.Visible = true;
            timer3.Stop();

            timer4.Start();
        }

        private void timer4_Tick(object sender, EventArgs e)
        {
            label_file_saved.Visible = false;
            timer4.Stop();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("http://emucraft.com");
        }

        private void timer5_Tick(object sender, EventArgs e)
        {
            label_Success.Visible = true;
            label_query_executed_successfully2.Visible = true;
            timer5.Stop();

            timer6.Start();
        }

        private void timer6_Tick(object sender, EventArgs e)
        {
            label_Success.Visible = false;
            label_query_executed_successfully2.Visible = false;
            timer6.Stop();
        }

        //NPC Creator
        //copy to clipboard button (label)
        private void label86_Click(object sender, EventArgs e)
        {
            if (comboBox11.SelectedIndex == 2)
                comboBox11.SelectedIndex = 0;

            _Generate_SQL_NPC(sender, e);

            if (string.IsNullOrWhiteSpace(NUD_Entry.Text))
            {
                MessageBox.Show("Entry should not be empty", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            Clipboard.SetText(stringSQLShare);
            timer7.Start();
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            onlyNumbers(sender, e);
        }

        private void timer7_Tick(object sender, EventArgs e)
        {
            label_copied_to_clipboard.Visible = true;
            timer7.Stop();

            timer8.Start();
        }

        private void timer8_Tick(object sender, EventArgs e)
        {
            label_copied_to_clipboard.Visible = false;
            timer8.Stop();
        }

        private void label70_Click(object sender, EventArgs e)
        {
            Process.Start("https://trinitycore.atlassian.net/wiki/display/tc/creature_template");
            label70.ForeColor = Color.Purple;
        }

        private void label70_MouseHover(object sender, EventArgs e)
        {
            label70.ForeColor = Color.RoyalBlue;
        }

        private void label70_MouseLeave(object sender, EventArgs e)
        {
            label70.ForeColor = Color.Blue;
        }

        //max + 1 button
        private void button2_Click(object sender, EventArgs e)
        {
            SelectMaxPlus1_NPC();
            
        }

        private void NUD_Entry_LostFocus(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void button11_Click(object sender, EventArgs e)
        {
            
            GenerateLoot gen = new GenerateLoot(form_MM);
            gen.Show();
            //entry                 lootid
            gen.textBox61.Text = textBox42.Text;
            //                                 entry                   name                     subname
            gen.Text = "Generate Loot for [" + NUD_Entry.Text + "] " + textBox7.Text;
            if (textBox12.Text != "") 
            gen.Text = "Generate Loot for [" + NUD_Entry.Text + "] " + textBox7.Text + " <" +  textBox12.Text + ">";
        }

        //           loot id
        private void textBox42_TextChanged(object sender, EventArgs e)
        {
            //Generate Loot
              button11.Enabled = true;
            
            if (textBox42.Text == "0") button11.Enabled = false;
           else if (textBox42.Text == "") button11.Enabled = false;

        }

        //           lootid
        private void textBox42_KeyPress(object sender, KeyPressEventArgs e)
        {
            onlyNumbers(sender, e);
        }

        // Max+1 LootID
        private void button12_Click(object sender, EventArgs e)
        {
            //GetMySqlConnection();

            string insertQuery = $"SELECT max(entry)+1 FROM { form_MM.GetWorldDB() }.creature_loot_template; ";
            //string insertQuery = textBox_SelectMaxPlus1.Text;
            
            MySqlCommand command = new MySqlCommand(insertQuery, connection);

            try
            {
                connection.Open();
                textBox42.Text = command.ExecuteScalar().ToString();
               
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message, "SpawnCreator", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                connection.Close();
            }
        }

        private void textBox14_KeyPress(object sender, KeyPressEventArgs e)
        {
            onlyNumbers(sender, e);
        }

        private void textBox15_KeyPress(object sender, KeyPressEventArgs e)
        {
            onlyNumbers(sender, e);
        }

        private void textBox13_KeyPress(object sender, KeyPressEventArgs e)
        {
            onlyNumbers(sender, e);
        }

        private void textBox22_KeyPress(object sender, KeyPressEventArgs e)
        {
            onlyNumbers(sender, e);
        }

        private void textBox21_KeyPress(object sender, KeyPressEventArgs e)
        {
            onlyNumbers(sender, e);
        }

        private void textBox10_KeyPress(object sender, KeyPressEventArgs e)
        {
            onlyNumbers(sender, e);

            LB_CN.Visible = false;
            TXT_Name.Visible = false;
            textBox10.ForeColor = Color.Black;
            TXT_Name.ForeColor = Color.Black;
        }

        private void textBox11_KeyPress(object sender, KeyPressEventArgs e)
        {
            onlyNumbers(sender, e);
        }

        private void textBox9_KeyPress(object sender, KeyPressEventArgs e)
        {
            onlyNumbers(sender, e);
        }

        private void textBox8_KeyPress(object sender, KeyPressEventArgs e)
        {
            onlyNumbers(sender, e);
        }

        private void textBox16_KeyPress(object sender, KeyPressEventArgs e)
        {
            onlyNumbers(sender, e);
        }

        private void textBox17_KeyPress(object sender, KeyPressEventArgs e)
        {
            onlyNumbers(sender, e);
        }

        private void textBox18_KeyPress(object sender, KeyPressEventArgs e)
        {
            onlyNumbers(sender, e);
        }

        private void textBox19_KeyPress(object sender, KeyPressEventArgs e)
        {
            onlyNumbers(sender, e);
        }

        private void textBox20_KeyPress(object sender, KeyPressEventArgs e)
        {
            onlyNumbers(sender, e);
        }

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            onlyNumbers(sender, e);
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            onlyNumbers(sender, e);
        }

        private void textBox4_KeyPress(object sender, KeyPressEventArgs e)
        {
            onlyNumbers(sender, e);
        }

        private void textBox5_KeyPress(object sender, KeyPressEventArgs e)
        {
            onlyNumbers(sender, e);
        }

        private void textBox6_KeyPress(object sender, KeyPressEventArgs e)
        {
            onlyNumbers(sender, e);
        }

        private void textBox24_KeyPress(object sender, KeyPressEventArgs e)
        {
            onlyNumbers(sender, e);
        }

        private void textBox23_KeyPress(object sender, KeyPressEventArgs e)
        {
            onlyNumbers(sender, e);
        }

        private void textBox26_KeyPress(object sender, KeyPressEventArgs e)
        {
            onlyNumbers(sender, e);
        }
        
        // I'm a fucking idiot....

        // almost all
        private void textBox25_KeyPress(object sender, KeyPressEventArgs e)
        {
            onlyNumbers(sender, e);
        }

        private void button13_Click(object sender, EventArgs e)
        {
            
            AddVendorItems vendor = new AddVendorItems(form_MM);
            vendor.Show();
            //entry                 entry (NPC_Create)
            vendor.textBox61.Text = NUD_Entry.Text;
            //                                       entry                  name                       subname
            vendor.Text = "Add Vendor Items for [" + NUD_Entry.Text + "] " + textBox7.Text;
            if (textBox12.Text != "")
                vendor.Text = "Add Vendor Items for [" + NUD_Entry.Text + "] " + textBox7.Text + " <" + textBox12.Text + ">";
            
        }

        private void button13_MouseHover(object sender, EventArgs e)
        {
            
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

        private void button14_Click(object sender, EventArgs e)
        {
            MountNPC mount = new MountNPC(form_MM);
            mount.Show();

            //mount.entry          this.entry
            mount.textBox61.Text = NUD_Entry.Text;
        }

        private void textBox30_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBox9_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox9.SelectedIndex == 7) /*SmartAI*/
                button15.Enabled = true;
           else
                button15.Enabled = false;
        }

        private void button15_Click(object sender, EventArgs e)
        {
            MakeNpcSay npcsay = new MakeNpcSay(form_MM);
            npcsay.Show();

            //npcsay.entry        = this.entry
            npcsay.textBox61.Text = NUD_Entry.Text;
        }

        private void comboBox5_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox2.SelectedIndex == 0) // Normal
            {
                pictureBox3.Image = Properties.Resources._0UI_TargetingFrame_NoMana;
                pictureBox3.Location = new Point(243 + 4, 11 + 8);
            }
            else if (comboBox2.SelectedIndex == 1) // Elite
            {
                pictureBox3.Image = Properties.Resources._133_UI_TargetingFrame_Elite;
                pictureBox3.Location = new Point(243, 11);
            }
            else if (comboBox2.SelectedIndex == 2) // Rare Elite
            {
                /// 243, 11
                pictureBox3.Image = Properties.Resources._22_UI_TargetingFrame_Rare_Elite;
                pictureBox3.Location = new Point(243 - 1, 11);
            }
            else if (comboBox2.SelectedIndex == 3) // Boss
            {
                //type_flags _type_flags = new type_flags();

                //if (_type_flags.checkedListBox1.GetItemCheckState(2 /*CREATURE_TYPEFLAGS_BOSS*/) == CheckState.Checked)
                //{
                //    LB_level.Visible = false;
                //    Skull_pic.Visible = true;
                //}
                //else
                //{
                //    LB_level.Visible = true;
                //    Skull_pic.Visible = false;
                //}

                pictureBox3.Image = Properties.Resources._133_UI_TargetingFrame_Elite;
                pictureBox3.Location = new Point(243, 11);
            }
            else if (comboBox2.SelectedIndex == 4) // Rare
            {
                pictureBox3.Image = Properties.Resources._44_UI_TargetingFrame_Rare;
                pictureBox3.Location = new Point(243 - 2, 11);
            }
        }

        private void comboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox8_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox8.SelectedIndex == 2) /*Waypoint movement*/
                button_waypoints.Enabled = true;
            else
                button_waypoints.Enabled = false;
        }

        private void button_waypoints_Click(object sender, EventArgs e)
        {
            HowToAddWaypoints waypoints = new HowToAddWaypoints();
            waypoints.ShowDialog();
        }

        // Max+1 Gossip Menu ID
        private void button16_Click(object sender, EventArgs e)
        {
            //GetMySqlConnection();

            string insertQuery = "SELECT max(menu_id)+1 FROM " + form_MM.GetWorldDB() + ".gossip_menu_option;";
            //string insertQuery = textBox_SelectMaxPlus1.Text;
            connection.Open();
            MySqlCommand command = new MySqlCommand(insertQuery, connection);

            try
            {
                textBox13.Text = command.ExecuteScalar().ToString();
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message, "SpawnCreator", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            connection.Close();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            AddGossipMenus gossip = new AddGossipMenus(form_MM);
            gossip.Show();

            //menu_id               gossip_menu_id
            gossip.textBox61.Text = textBox13.Text;
        }

        private void textBox13_TextChanged(object sender, EventArgs e)
        {
            //Gossip Menu ID
            button1.Enabled = true;

            if (textBox13.Text == "0") button1.Enabled = false;
            else if (textBox13.Text == "") button1.Enabled = false;
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

        private void panel7_MouseEnter(object sender, EventArgs e)
        {
            panel7.BackColor = Color.Firebrick;
        }

        private void panel7_MouseLeave(object sender, EventArgs e)
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

        private void comboBox11_SelectedIndexChanged(object sender, EventArgs e)
        {
            button22.Visible = false;
            textBox105.ResetText();
            btn_DeleteQuery.Visible = false;
            if (comboBox11.SelectedIndex == 0)
            {
                textBox105.Text = "INSERT";
                button22.Visible = true;
            }
            else if (comboBox11.SelectedIndex == 1)
            {
                textBox105.Text = "REPLACE";
                button22.Visible = true;
            }
            else if (comboBox11.SelectedIndex == 2)
            {
                if (form_MM.CB_NoMySQL.Checked || label_mysql_status2.Text == "Connection Lost - MySQL is not running")
                {
                    btn_DeleteQuery.Enabled = false;
                }

                btn_DeleteQuery.Visible = true;
            }
        }

        private void label87_Click(object sender, EventArgs e)
        {
            // Execute Query
            button10_Click(sender, e);
        }

        private void button18_Click(object sender, EventArgs e)
        {
            control_panel.ShowDialog();
        }

        private void button18_MouseEnter(object sender, EventArgs e)
        {
            button18.BackColor = Color.Firebrick;
            button18.ForeColor = Color.White;
        }

        private void button18_MouseLeave(object sender, EventArgs e)
        {
            button18.BackColor = Color.Silver;
            button18.ForeColor = Color.Black;
        }

        private void TXT_SQL_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void TXT_SQL_MouseEnter(object sender, EventArgs e)
        {
            _Generate_SQL_NPC(sender, e);
        }

        private void timer9_Tick(object sender, EventArgs e)
        {
            TXT_SQL_MouseEnter(sender, e);
        }

        // button_SaveInTheSameFile
        private void button19_Click(object sender, EventArgs e)
        {
            if (comboBox11.SelectedIndex == 2)
                comboBox11.SelectedIndex = 0;

            _Generate_SQL_NPC(sender, e);

            if (string.IsNullOrWhiteSpace(NUD_Entry.Text))
            {
                MessageBox.Show("Entry should not be empty", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            //Save in the same file
            //using (var writer = File.AppendText("Creatures.sql"))
            //Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + @"\Screenshot.png"
            using (var writer = File.AppendText("Creatures.sql"))
            {
                writer.Write(stringSQLShare + Environment.NewLine);
                button_SaveInTheSameFile.Text = "Saved!";
                button_SaveInTheSameFile.TextAlign = ContentAlignment.MiddleCenter;
            }
        }

        // button_SaveInTheSameFile
        private void button19_MouseEnter(object sender, EventArgs e)
        {
            button_SaveInTheSameFile.BackColor = Color.Firebrick;
            toolTip1.SetToolTip(button_SaveInTheSameFile, "Or Press F2");
        }

        private void button19_MouseLeave(object sender, EventArgs e)
        {
            button_SaveInTheSameFile.BackColor = Color.FromArgb(58, 89, 114);
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

        private void All_comboBoxes_MouseEnter(object sender, EventArgs e)
        {
            ALL_textBoxes_MouseEnter(sender, e);
        }

        private void All_buttons_MouseEnter(object sender, EventArgs e)
        {
            ALL_textBoxes_MouseEnter(sender, e);
            //button2.BackColor = Color.Green;
            //button2.ForeColor = Color.White;
        }

        private void label92_MouseEnter(object sender, EventArgs e)
        {
            toolTip1.SetToolTip(label92, "A file labeled Creatures.sql will be created in the same directory as the SpawnCreator vX.X executable. \nSo you can save multiple data rows in a single .sql file.");
            toolTip1.AutoPopDelay = 32000; // 32 seconds
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            object sender = new object();
            EventArgs e = new EventArgs();

            if (keyData == Keys.F2)
            {
                button19_Click(sender, e); // Save in the same file if "F2" key is pressed
                return true;
            }

            else if (keyData == Keys.F5)
            {
                button10_Click(sender, e); // Execute Query if "F5" key is pressed
                return true;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void btn_DeleteQuery_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Are you sure you want to delete Creature " + NUD_Entry.Text + " ?", "SpawnCreator " + form_MM.version, MessageBoxButtons.YesNo);
           // NUD_Entry.ForeColor = Color.Red;
            if (dr == DialogResult.No)
                return;

            else
                DeleteNPC();
                
        }

        private void label92_Click(object sender, EventArgs e)
        {

        }

        private void textBox7_Click_DeletedEvent()
        {
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                textBox7.BackColor = colorDialog1.Color;
            }
        }

        private void button19_Click_1(object sender, EventArgs e)
        {
            //Label lbl = new Label();
            //ClearLabel(lbl);

            TextBox tbx = Controls.Find(textBox1.Text, true).FirstOrDefault() as TextBox;

            try
            {
                if (textBox1.Text == "Spell3" ||
                    textBox1.Text == "spell3" ||
                    textBox1.Text == "Spell 3" ||
                    textBox1.Text == "spell 3")
                    textBox43.Focus();
                if (textBox1.Text == "health modifier" ||
                    textBox1.Text == "Health Modifier" ||
                    textBox1.Text == "HealthModifier" ||
                    textBox1.Text == "health")
                    textBox54.Focus();

                //tbx.Focus();
                //tbx.ForeColor = Color.Red;
            }
            catch (Exception)
            {
                MessageBox.Show("Error: Label Name is Invalid");
                //throw;
            }
            //if (string.IsNullOrEmpty(tbx.Text))
            //    return;
            //else
            //tbx.Focus();
            //tbx.ForeColor = Color.Red;

            

            //// looping through all labels and change color to all of them
            //foreach (Control labelcontrol1 in this.Controls)
            //{
            //        labelcontrol1.Focus();
            //        labelcontrol1.ForeColor = Color.Red;
            //}

            
        }

        private void comboBox12_SelectedIndexChanged(object sender, EventArgs e)
        {
            label9.ForeColor = Color.Black;
            switch (comboBox12.Text)
            {
                case "entry":
                    NUD_Entry.Focus();
                    break;
                case "difficulty_entry_1":
                    textBox3.Focus();
                    break;
                case "difficulty_entry_2":
                    textBox2.Focus();
                    break;
                case "difficulty_entry_3":
                    textBox4.Focus();
                    break;
                case "KillCredit1":
                    textBox5.Focus();
                    break;
                case "KillCredit2":
                    textBox6.Focus();
                    break;
                case "modelid1":
                    textBox10.Focus();
                    break;
                case "modelid2":
                    textBox11.Focus();
                    break;
                case "modelid3":
                    textBox9.Focus();
                    break;
                case "modelid4":
                    textBox8.Focus();
                    break;
                case "name":
                    textBox7.Focus();
                    textBox7.SelectAll();
                    break;
                case "subname":
                    textBox12.Focus();
                    textBox12.SelectAll();
                    break;
                case "IconName":
                    comboBox1.Focus();
                    label9.ForeColor = Color.Red;
                    break;
                case "gossip_menu_id":
                    textBox13.Focus();
                    break;

                default:
                    label9.ForeColor = Color.Black;
                    break;
            }
        }

        private void button21_Click(object sender, EventArgs e)
        {
            timer2.Stop();
        }

        private void button20_Click(object sender, EventArgs e)
        {
            timer2.Start();
        }

        private void button22_Click(object sender, EventArgs e)
        {
            if (comboBox11.SelectedIndex == 0)
                MessageBox.Show("MySQL - INSERT Syntax: \nInserts new rows into an existing table. ", "SpawnCreator", MessageBoxButtons.OK, MessageBoxIcon.Information);

            else 
                MessageBox.Show("MySQL - REPLACE Syntax: \nREPLACE works exactly like INSERT, except that if an old row in the table has the same value as a new row for a PRIMARY KEY or a UNIQUE index, the old row is deleted before the new row is inserted.", "SpawnCreator", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void button23_Click(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                textBox4.BackColor = colorDialog1.Color;
            }
        }

        private void button24_Click(object sender, EventArgs e)
        {
            InhabitType _inhabitType = new InhabitType();
            _inhabitType.ShowDialog();
        }

        private void copyToClipboardToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void backToMainMenuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
            BackToMainMenu backtomainmenu = new BackToMainMenu(form_MM);
            backtomainmenu.Show();
        }

        private void startToolStripMenuItem_Click(object sender, EventArgs e)
        {
            timer2.Start();
        }

        private void stopToolStripMenuItem_Click(object sender, EventArgs e)
        {
            timer2.Stop();
        }

        private void hideStopwatchToolStripMenuItem_Click(object sender, EventArgs e)
        {
            label_stopwatch.Visible = false;
            label89.Visible = false;
        }

        private void showStopwatchToolStripMenuItem_Click(object sender, EventArgs e)
        {
            label_stopwatch.Visible = true;
            label89.Visible = true;
        }

        private void textBox15_TextChanged(object sender, EventArgs e)
        {
            if (textBox15.Text == "0")
                textBox15.Text = "1";

            int i;
            int.TryParse(textBox15.Text, out i);
            

            if (!(i > -1) || !(i < 256))
            {
                //if (i == 0)
                //textBox15.Clear();
                textBox15.Text = "1";
            }

            //===================================

            if (textBox14.Text == textBox15.Text)
            LB_level.Text = textBox15.Text;
            else
            {
                LB_level.ResetText();
            }

            //Skull_pic.Visible = false;
            //int maxValue;

            //if (Int32.TryParse(textBox15.Text, out maxValue))
            //{
            //    if (maxValue > 80)
            //    {
            //        LB_level.Visible = false;
            //        //Skull_pic.Visible = true;
            //    }
            //    else
            //        LB_level.Visible = true;

            //}
            //else
            //{
            //    LB_level.Visible = true;
            //}

        }

        private void textBox15_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void textBox14_TextChanged(object sender, EventArgs e)
        {
            if (textBox14.Text == "0")
                textBox14.Text = "1";

            textBox15.Text = textBox14.Text;

            int i;
            int.TryParse(textBox14.Text, out i);


            if (!(i > -1) || !(i < 256))
            {
                //if (i == 0)
                //textBox15.Clear();
                textBox14.Text = "1";
            }
            //===================


            if (textBox14.Text == textBox15.Text)
                LB_level.Text = textBox15.Text;
            else
            {
                LB_level.ResetText();
            }
        }

        private void button2_MouseLeave(object sender, EventArgs e)
        {
            button2.BackColor = Color.DimGray;
            button2.ForeColor = Color.White;
        }

        private void button25_Click(object sender, EventArgs e)
        {
            //for (int i = 1; i <= 1; i++)
            //{
            //    if (textBox10.Text == "0")
            //    {
            //        continue;
            //    }
            //}
            Color color = Color.Black;
            LB_CN.Visible = true;
            TXT_Name.Visible = true;
            textBox10.ForeColor = color;
            TXT_Name.ForeColor = color;

            SelectRandomModelID();
        }

        private void textBox10_TextChanged(object sender, EventArgs e)
        {

        }

        private void label18_Click(object sender, EventArgs e)
        {
            Process.Start("https://trinitycore.atlassian.net/wiki/display/tc/FactionTemplate");
            label18.ForeColor = Color.Purple;
        }

        private void label18_MouseLeave(object sender, EventArgs e)
        {
            
        }

        private void button26_Click(object sender, EventArgs e)
        {
            RankInfo rank = new RankInfo();
            rank.ShowDialog();
        }

        private void comboBox6_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox6.SelectedIndex == 0) // TRAINER_TYPE_CLASS
            {
                textBox30.Enabled = false; // Trainer Spell
                textBox29.Enabled = true; // Trainer Class
                textBox32.Enabled = false; // Trainer Race
            }
            else if (comboBox6.SelectedIndex == 1) // TRAINER_TYPE_MOUNTS
            {
                textBox30.Enabled = false; // Trainer Spell
                textBox29.Enabled = false; // Trainer Class
                textBox32.Enabled = true; // Trainer Race
            }
            else if (comboBox6.SelectedIndex == 2) // TRAINER_TYPE_TRADESKILLS
            {
                textBox30.Enabled = true; // Trainer Spell
                textBox29.Enabled = false; // Trainer Class
                textBox32.Enabled = false; // Trainer Race
            }
            else if (comboBox6.SelectedIndex == 3) // TRAINER_TYPE_PETS
            {
                textBox30.Enabled = false; // Trainer Spell
                textBox29.Enabled = true; // Trainer Class
                textBox32.Enabled = false; // Trainer Race
            }
        }

        private void textBox25_KeyPress_2(object sender, KeyPressEventArgs e)
        {
            var validKeys = new[] { Keys.Back, Keys.D0, Keys.D1 };

            e.Handled = !validKeys.Contains((Keys)e.KeyChar);
        }

        private void label87_Click_1(object sender, EventArgs e)
        {
           // comboBox8.SelectedIndex = 2;
           // label44.ForeColor = Color.Red;
        }

        private void button17_Click(object sender, EventArgs e)
        {
            Spawn_NPC sp = new Spawn_NPC(form_MM);
            sp.Show();

            //spawn form id   =  this.Entry
            sp.textBox65.Text = NUD_Entry.Text;

            //modelId1
             sp.txtModel.Text = textBox10.Text;

            //MovementType
            sp.txtMovementType.Text = comboBox8.SelectedIndex.ToString();

            // NPC Flags
            sp.txtNpcFlag.Text = lblNpcFlag.Text;

            // UNIt Flags
            sp.txtUnitFlags.Text = lblUnitFlags.Text;

            // Dynamic Flags
            sp.txtDynamicFlags.Text = lblDynamicFlags.Text;
        }

        private void CB_RegenHealth_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
