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
        public NPC_Creator()
        {
            InitializeComponent();
        }

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

        private void GenerateSQLCode_NPC_Creator(object sender, EventArgs e)
        {
            UInt32 npcflag_st = 0;
            uint unit_flags_st = 0;
            uint unit_flags2_st = 0;
            int dynamicflags_st = 0;
            uint type_flags_st = 0;
            uint mechanic_immune_mask_st = 0;
            uint flags_extra_st = 0;

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

            Form_MainMenu mainmenu = new Form_MainMenu();
            // Prepare SQL
            // select insertion columns
            string BuildSQLFile;
            BuildSQLFile = "INSERT INTO " + mainmenu.textbox_mysql_worldDB.Text + ".creature_template (entry, difficulty_entry_1, difficulty_entry_2, difficulty_entry_3, KillCredit1, ";
            BuildSQLFile += "KillCredit2, modelid1, modelid2, modelid3, modelid4, name, subname, IconName, gossip_menu_id, minlevel, ";
            BuildSQLFile += "maxlevel, exp, faction, npcflag, speed_walk, speed_run, scale, rank, dmgschool, BaseAttackTime, ";
            BuildSQLFile += "RangeAttackTime, BaseVariance, RangeVariance, unit_class, unit_flags, unit_flags2, dynamicflags, family, ";
            BuildSQLFile += "trainer_type, trainer_spell, trainer_class, trainer_race, type, type_flags, lootid, pickpocketloot, skinloot, ";
            BuildSQLFile += "resistance1, resistance2, resistance3, resistance4, resistance5, resistance6, spell1, spell2, spell3, ";
            BuildSQLFile += "spell4, spell5, spell6, spell7, spell8, PetSpellDataId, VehicleId, mingold, maxgold, AIName, MovementType, ";
            BuildSQLFile += "InhabitType, HoverHeight, HealthModifier, ManaModifier, ArmorModifier, DamageModifier, ExperienceModifier, ";
            BuildSQLFile += "RacialLeader, movementId, RegenHealth, mechanic_immune_mask, flags_extra, ScriptName, VerifiedBuild)";

            // values now
            BuildSQLFile += "VALUES\n";
            BuildSQLFile += "(";
            BuildSQLFile += textBox1.Text + ", "; // entry
            BuildSQLFile += textBox3.Text + ", "; // difficulty_entry_1
            BuildSQLFile += textBox2.Text + ", "; // difficulty_entry_2
            BuildSQLFile += textBox4.Text + ", "; // difficulty_entry_3
            BuildSQLFile += textBox5.Text + ", "; // KillCredit1
            BuildSQLFile += textBox6.Text + ", "; // KillCredit2
            BuildSQLFile += textBox10.Text + ", "; // modelid1
            BuildSQLFile += textBox11.Text + ", "; // modelid2
            BuildSQLFile += textBox9.Text + ", "; // modelid3
            BuildSQLFile += textBox8.Text + ", "; // modelid4
            BuildSQLFile += "'" + textBox7.Text + "', "; // name
            BuildSQLFile += "'" + textBox12.Text + "', "; // subname
            // BuildSQLFile += "'" + comboBox1.SelectedIndex + "', "; // IconName

            int IconName = comboBox1.SelectedIndex;
            switch (IconName)
            {
                case 0:
                    BuildSQLFile += "'" + "Directions" + "', ";
                    break;
                case 1:
                    BuildSQLFile += "'" + "Gunner" + "', ";
                    break;
                case 2:
                    BuildSQLFile += "'" + "vehichleCursor" + "', ";
                    break;
                case 3:
                    BuildSQLFile += "'" + "Driver" + "', ";
                    break;
                case 4:
                    BuildSQLFile += "'" + "Attack" + "', ";
                    break;
                case 5:
                    BuildSQLFile += "'" + "Buy" + "', ";
                    break;
                case 6:
                    BuildSQLFile += "'" + "Speak" + "', ";
                    break;
                case 7:
                    BuildSQLFile += "'" + "Pickup" + "', ";
                    break;
                case 8:
                    BuildSQLFile += "'" + "Interact" + "', ";
                    break;
                case 9:
                    BuildSQLFile += "'" + "Trainer" + "', ";
                    break;
                case 10:
                    BuildSQLFile += "'" + "Taxi" + "', ";
                    break;
                case 11:
                    BuildSQLFile += "'" + "Repair" + "', ";
                    break;
                case 12:
                    BuildSQLFile += "'" + "LootAll" + "', ";
                    break;
                case 13:
                    BuildSQLFile += "'" + "Quest" + "', ";
                    break;
                case 14:
                    BuildSQLFile += "'" + "PVP" + "', ";
                    break;
            }

            BuildSQLFile += textBox13.Text + ", "; // gossip_menu_id
            BuildSQLFile += textBox14.Text + ", "; // minlevel
            BuildSQLFile += textBox15.Text + ", "; // maxlevel
            BuildSQLFile += textBox16.Text + ", "; // exp
            BuildSQLFile += textBox17.Text + ", "; // faction
            BuildSQLFile += npcflag_st + ", "; // npcflag
            BuildSQLFile += textBox18.Text + ", "; // speed_walk
            BuildSQLFile += textBox19.Text + ", "; // speed_run
            BuildSQLFile += textBox20.Text + ", "; // scale
            BuildSQLFile += comboBox2.SelectedIndex + ", "; // rank
            BuildSQLFile += comboBox3.SelectedIndex + ", "; // dmgschool
            BuildSQLFile += textBox26.Text + ", "; // BaseAttackTime
            BuildSQLFile += textBox25.Text + ", "; // RangeAttackTime
            BuildSQLFile += textBox28.Text + ", "; // BaseVariance
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
            BuildSQLFile += unit_flags2_st + ", "; // unit_flags2
            BuildSQLFile += dynamicflags_st + ", "; // dynamicflags
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
            BuildSQLFile += textBox30.Text + ", "; // trainer_spell
            BuildSQLFile += textBox29.Text + ", "; // trainer_class
            BuildSQLFile += textBox32.Text + ", "; // trainer_race
            BuildSQLFile += comboBox7.SelectedIndex + ", "; // type
            BuildSQLFile += type_flags_st + ", "; // type_flags
            BuildSQLFile += textBox42.Text + ", "; // lootid
            BuildSQLFile += textBox41.Text + ", "; // pickpocketloot
            BuildSQLFile += textBox40.Text + ", "; // skinloot
            BuildSQLFile += textBox39.Text + ", "; // resistance1
            BuildSQLFile += textBox36.Text + ", "; // resistance2
            BuildSQLFile += textBox35.Text + ", "; // resistance3
            BuildSQLFile += textBox38.Text + ", "; // resistance4
            BuildSQLFile += textBox37.Text + ", "; // resistance5
            BuildSQLFile += textBox46.Text + ", "; // resistance6
            BuildSQLFile += textBox45.Text + ", "; // spell1
            BuildSQLFile += textBox44.Text + ", "; // spell2
            BuildSQLFile += textBox43.Text + ", "; // spell3
            BuildSQLFile += textBox52.Text + ", "; // spell4
            BuildSQLFile += textBox51.Text + ", "; // spell5
            BuildSQLFile += textBox50.Text + ", "; // spell6
            BuildSQLFile += textBox49.Text + ", "; // spell7
            BuildSQLFile += textBox48.Text + ", "; // spell8
            BuildSQLFile += textBox47.Text + ", "; // PetSpellDataID
            BuildSQLFile += textBox58.Text + ", "; // VehicleID
            BuildSQLFile += textBox57.Text + ", "; // mingold
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
            BuildSQLFile += textBox60.Text + ", "; // HoverHeight
            BuildSQLFile += textBox54.Text + ", "; // HealthModifier
            BuildSQLFile += textBox53.Text + ", "; // ManaModifier
            BuildSQLFile += textBox64.Text + ", "; // ArmorModofier
            BuildSQLFile += textBox61.Text + ", "; // DamageModifier
            BuildSQLFile += textBox65.Text + ", "; // ExperienceModifier
            BuildSQLFile += textBox66.Text + ", "; // RacialLeader
            BuildSQLFile += textBox55.Text + ", "; // movementID
            BuildSQLFile += textBox63.Text + ", "; // RegenHealth
            BuildSQLFile += mechanic_immune_mask_st + ", "; // mechanic_immune_mask
            BuildSQLFile += flags_extra_st + ", "; // flags_extra
            BuildSQLFile += "'" + textBox62.Text + "', "; // ScriptName
            BuildSQLFile += textBox59.Text; // VerifiedBuild
            BuildSQLFile += ");";

            stringSQLShare = BuildSQLFile;
            stringEntryShare = textBox1.Text;


            if (textBox2.Text == "")
            {
                MessageBox.Show("Name should not be empty", "Error");
                return;
            }

            using (var sfd = new SaveFileDialog())
            {
                sfd.Filter = "sql files (*.sql)|*.sql";
                sfd.FilterIndex = 2;
                sfd.FileName = "NPC_" + NPC_Creator.stringEntryShare;

                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    File.WriteAllText(sfd.FileName, NPC_Creator.stringSQLShare);
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

            Application.Exit();
        }

        private void label80_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
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

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void NPC_Creator_Load(object sender, EventArgs e)
        {
            
          
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
            comboBox2.SelectedIndex = 0; // show default item
            comboBox5.SelectedIndex = 0; // show default item
            comboBox4.SelectedIndex = 0; // show default item
            comboBox6.SelectedIndex = 0; // show default item
            comboBox7.SelectedIndex = 7; // show Type = Humanoid
            comboBox8.SelectedIndex = 0; // show default item
            comboBox9.SelectedIndex = 0; // show default item
            comboBox10.SelectedIndex = 0; // show default item


            timer1.Start(); //check if mysql is running
            timer2.Start(); //stopwatch

            MySqlConnection connection = new MySqlConnection("datasource=" + mainmenu.textbox_mysql_hostname.Text + ";port=" + mainmenu.textbox_mysql_port.Text + ";username=" + mainmenu.textbox_mysql_username.Text + ";password=" + mainmenu.textbox_mysql_pass.Text);
            string insertQuery = "SELECT max(entry)+1 FROM " + mainmenu.textbox_mysql_worldDB.Text + ".creature_template;"
                 // Create table mountlist
                //"-- DROP TABLE " + mainmenu.textbox_mysql_worldDB.Text + ".mountlist;" +
                //"CREATE TABLE IF NOT EXISTS mountlist.mountlist (" +
                //"`Name` CHAR(100) NULL DEFAULT NULL," +
                //"`Model_ID` MEDIUMINT(8) NULL DEFAULT NULL" +
                //")" +
                //"COLLATE='latin1_swedish_ci'" +
                //"ENGINE=InnoDB" +
                //";" +
                // "INSERT INTO mountlist.mountlist (Name, Model_ID) VALUES " +
                //"('Amani War Bear', 22464), " +
                //"('Argent Charger', 28919), " +
                //"('Argent Hippogryph', 22471), " +
                //"('Argent Warhorse', 28918), " +
                //"('Armored Blue Wind Rider', 27914), " +
                //"('Armored Snowy Gryphon', 27913), " +
                //"('Ashes of Al\\'ar', 17890), " +
                //"('Big Battle Bear', 25335), " +
                //"('Big Blizzard Bear', 27567), " +
                //"('Big Love Rocket', 30989), " +
                //"('Black Battlestrider', 14372), " +
                //"('Black Hawkstrider', 19478), " +
                //"('Black Qiraji Battle Tank', 15676), " +
                //"('Black Ram', 2784), " +
                //"('Black Skeletal Horse', 29130), " +
                //"('Black Stallion', 2402), " +
                //"('Black War Kodo', 14348), " +
                //"('Black War Ram', 14577), " +
                //"('Black War Steed', 14337), " +
                //"('Blazing Hippogryph', 31803), " +
                //"('Blue Dragonhawk', 27525), " +
                //"('Blue Hawkstrider', 19480), " +
                //"('Blue Mechanostrider', 6569), " +
                //"('Blue Qiraji Battle Tank', 15672), " +
                //"('Blue Riding Nether Ray', 21156), " +
                //"('Blue Skeletal Horse', 10671), " +
                //"('Blue Skeletal Warhorse', 10718), " +
                //"('Blue Wind Rider', 17700), " +
                //"('Brewfest Kodo', 24758), " +
                //"('Brewfest Ram', 22265), " +
                //"('Brown Elekk', 17063), " +
                //"('Brown Horse', 2404), " +
                //"('Brown Kodo', 11641), " +
                //"('Brown Ram', 2785), " +
                //"('Brown Skeletal Horse', 10672), " +
                //"('Brutal Nether Drake', 27507), " +
                //"('Celestial Steed', 31958), " +
                //"('Cenarion War Hippogryph', 22473), " +
                //"('Chestnut Mare', 2405), " +
                //"('Crusader\\'s Black Warhorse', 29938), " +
                //"('Crusader\\'s White Warhorse', 29937), " +
                //"('Darkspear Raptor', 29261), " +
                //"('Darnassian Nightsaber', 29256), " +
                //"('Deadly Gladiator\\'s Frost Wyrm', 25511), " +
                //"('Rivendare\\'s Deathcharger', 10718), " +
                //"('Ebon Gryphon', 17694), " +
                //"('Exodar Elekk', 29255), " +
                //"('Fiery Warhorse', 19250), " +
                //"('Fluorescent Green Mechanostrider', 9475), " +
                //"('Flying Broom', 21939), " +
                //"('Flying Carpet', 28082), " +
                //"('Flying Machine Control', 1126), " +
                //"('Forsaken Warhorse', 29257), " +
                //"('Frost Ram', 2787), " +
                //"('Frosty Flying Carpet', 28063), " +
                //"('Furious Gladiator\\'s Frost Wyrm', 25593), " +
                //"('Gnomeregan Mechanostrider', 28571), " +
                //"('Golden Gryphon', 17697), " +
                //"('Gray Elekk', 19869), " +
                //"('Gray Kodo', 12246), " +
                //"('Gray Ram', 2736), " +
                //"('Great Blue Elekk', 19871), " +
                //"('Great Brewfest Kodo', 24757), " +
                //"('Great Brown Kodo', 14578), " +
                //"('Great Elite Elekk', 17906), " +
                //"('Great Golden Kodo', 28556), " +
                //"('Great Golden Kodo', 28556), " +
                //"('Great Gray Kodo', 14579), " +
                //"('Great Green Elekk', 19873), " +
                //"('Great Purple Elekk', 19872), " +
                //"('Great Red Elekk', 28606), " +
                //"('Great Red Elekk', 28606), " +
                //"('Great White Kodo', 14349), " +
                //"('Green Kodo', 12245), " +
                //"('Green Mechanostrider', 10661), " +
                //"('Green Qiraji Battle Tank', 15679), " +
                //"('Green Riding Nether Ray', 21152), " +
                //"('Green Skeletal Warhorse', 10720), " +
                //"('Green Wind Rider', 17701), " +
                //"('Winter Wolf', 1166), " +
                //"('Black War Wolf', 14334), " +
                //"('Black Wolf', 207), " +
                //"('Brown Wolf', 2328), " +
                //"('Dire Wolf', 17283), " +
                //"('Frostwolf Howler', 14776), " +
                //"('Red Wolf', 2326), " +
                //"('Swift Brown Wolf', 14573), " +
                //"('Swift Gray Wolf', 14574), " +
                //"('Swift Timber Wolf', 14575), " +
                //"('Timber Wolf', 247), " +
                //"('Invincible\\'s Reins', 31007), " +
                //"('Ironforge Ram', 29258), " +
                //"('Loaned Gryphon', 17697), " +
                //"('Loaned Wind Rider', 17699), " +
                //"('Magic Broom', 21939), " +
                //"('Magic Rooster', 29344), " +
                //"('Magnificent Flying Carpet', 28117), " +
                //"('Mechano-hog', 25871), " +
                //"('Mekgineer\\'s Chopper', 25870), " +
                //"('Merciless Nether Drake', 22620), " +
                //"('Mimiron\\'s Head', 28890), " +
                //"('Ochre Skeletal Warhorse', 29754), " +
                //"('Orgrimmar Wolf', 29260), " +
                //"('Palomino', 2408), " +
                //"('Pinto', 2409), " +
                //"('White Polar Bear', 28428), " +
                //"('Purple Elekk', 19870), " +
                //"('Purple Hawkstrider', 19479), " +
                //"('Purple Mechanostrider', 10662), " +
                //"('Purple Riding Nether Ray', 21155), " +
                //"('Purple Skeletal Warhorse', 10721), " +
                //"('Quel\\'dorei Steed', 28888), " +
                //"('Red and Blue Mechanostrider', 10664), " +
                //"('Red Dragonhawk', 28402), " +
                //"('Red Hawkstrider', 18696), " +
                //"('Red Mechanostrider', 9473), " +
                //"('Red Qiraji Battle Tank', 15681), " +
                //"('Red Riding Nether Ray', 21158), " +
                //"('Red Skeletal Horse', 10670), " +
                //"('Red Skeletal Warhorse', 10719), " +
                //"('Albino Drake', 25836), " +
                //"('Ancient Frostsaber', 9695), " +
                //"('Armored Brown Bear', 27820), " +
                //"('Azure Drake', 24743), " +
                //"('Azure Netherwing Drake', 21521), " +
                //"('Black Drake', 6374), " +
                //"('Black Polar Bear', 27659), " +
                //"('Black Proto-Drake', 28040), " +
                //"('Black War Bear', 27818), " +
                //"('Black War Elekk', 23928), " +
                //"('Black War Mammoth', 27247), " +
                //"('Black War Mammoth', 27245), " +
                //"('Black War Tiger', 14330), " +
                //"('Bloodbathed Frostbrood Vanquisher', 31156), " +
                //"('Blue Drake Mount', 25832), " +
                //"('Blue Proto-Drake', 28041), " +
                //"('Bronze Drake', 25852), " +
                //"('Brown Polar Bear', 27660), " +
                //"('Cobalt Netherwing Drake', 21525), " +
                //"('Cobalt Riding Talbuk', 21073), " +
                //"('Cobalt War Talbuk', 19375), " +
                //"('Crimson Deathcharger', 25279), " +
                //"('Dark Riding Talbuk', 21074), " +
                //"('Dark War Talbuk', 19303), " +
                //"('Golden Sabercat', 9714), " +
                //"('Grand Black War Mammoth', 27240), " +
                //"('Grand Black War Mammoth', 27241), " +
                //"('Grand Ice Mammoth', 27239), " +
                //"('Grand Ice Mammoth', 27242), " +
                //"('Green Proto-Drake', 28053), " +
                //"('Ice Mammoth', 27246), " +
                //"('Ice Mammoth', 27248), " +
                //"('Icebound Frostbrood Vanquisher', 31154), " +
                //"('Ironbound Proto-Drake', 28953), " +
                //"('Black Nightsaber', 9991), " +
                //"('Onyx Netherwing Drake', 21520), " +
                //"('Onyxian Drake', 6369), " +
                //"('Plagued Proto-Drake', 28042), " +
                //"('Primal Leopard', 4805), " +
                //"('Purple Netherwing Drake', 21523), " +
                //"('Raven Lord', 21473), " +
                //"('Red Drake', 25835), " +
                //"('Red Proto-Drake', 28044), " +
                //"('Rusted Proto-Drake', 28954), " +
                //"('Silver Riding Talbuk', 21075), " +
                //"('Silver War Talbuk', 19378), " +
                //"('Spectral Tiger', 21973), " +
                //"('Spotted Frostsaber', 6444), " +
                //"('Striped Dawnsaber', 29755), " +
                //"('Striped Frostsaber', 6080), " +
                //"('Striped Nightsaber', 6448), " +
                //"('Swift Dawnsaber', 14329), " +
                //"('Swift Frostsaber', 14331), " +
                //"('Swift Mistsaber', 14332), " +
                //"('Swift Spectral Tiger', 21974), " +
                //"('Swift Stormsaber', 14632), " +
                //"('Tan Riding Talbuk', 21077), " +
                //"('Tan War Talbuk', 19376), " +
                //"('Tawny Sabercat', 6442), " +
                //"('Time-Lost Proto-Drake', 28045), " +
                //"('Traveler\\'s Tundra Mammoth', 27237), " +
                //"('Traveler\\'s Tundra Mammoth', 27238), " +
                //"('Twilight Drake', 6372), " +
                //"('Veridian Netherwing Drake', 21522), " +
                //"('Violet Netherwing Drake', 21524), " +
                //"('Violet Proto-Drake', 28043), " +
                //"('White Polar Bear', 28428), " +
                //"('White Riding Talbuk', 21076), " +
                //"('White War Talbuk', 19377), " +
                //"('Winterspring Frostsaber', 10426), " +
                //"('Wooly Mammoth', 26423), " +
                //"('Wooly Mammoth', 27243), " +
                //"('Relentless Gladiator\\'s Frost Wyrm', 29794), " +
                //"('Sea Turtle', 29161), " +
                //"('Silver Covenant Hippogryph', 22474), " +
                //"('Silver Riding Nether Ray', 21157), " +
                //"('Silvermoon Hawkstrider', 29262), " +
                //"('Snowy Gryphon', 17696), " +
                //"('Stormpike Battle Charger', 14777), " +
                //"('Stormwind Steed', 28912), " +
                //"('Sunreaver Dragonhawk', 29363), " +
                //"('Sunreaver Hawkstrider', 28889), " +
                //"('Swift Alliance Steed', 29284), " +
                //"('Swift Blue Gryphon', 17759), " +
                //"('Swift Blue Raptor', 14339), " +
                //"('Swift Brewfest Ram', 22350), " +
                //"('Swift Brown Ram', 14347), " +
                //"('Swift Brown Steed', 14583), " +
                //"('Swift Burgundy Wolf', 14335), " +
                //"('Swift Flying Broom', 21939), " +
                //"('Swift Gray Ram', 14576), " +
                //"('Swift Gray Steed', 29043), " +
                //"('Swift Green Gryphon', 17703), " +
                //"('Swift Green Hawkstrider', 19484), " +
                //"('Swift Green Mechanostrider', 14374), " +
                //"('Swift Green Wind Rider', 17720), " +
                //"('Swift Horde Wolf', 30070), " +
                //"('Swift Flying Broom', 21939), " +
                //"('Swift Mooncloth Carpet', 28063), " +
                //"('Swift Moonsaber', 14333), " +
                //"('Swift Nether Drake', 20344), " +
                //"('Swift Olive Raptor', 14344), " +
                //"('Swift Orange Raptor', 14342), " +
                //"('Swift Palomino', 14582), " +
                //"('Swift Pink Hawkstrider', 18697), " +
                //"('Swift Purple Gryphon', 17717), " +
                //"('Swift Purple Hawkstrider', 19482), " +
                //"('Swift Purple Raptor', 14343), " +
                //"('Swift Purple Wind Rider', 17721), " +
                //"('Swift Razzashi Raptor', 15289), " +
                //"('Swift Red Gryphon', 17718), " +
                //"('Swift Red Hawkstrider', 28607), " +
                //"('Swift Red Wind Rider', 17719), " +
                //"('Swift Spellfire Carpet', 28064), " +
                //"('Swift Violet Ram', 28612), " +
                //"('Swift Warstrider', 20359), " +
                //"('Swift White Hawkstrider', 19483), " +
                //"('Swift White Mechanostrider', 14376), " +
                //"('Swift White Ram', 14346), " +
                //"('Swift White Steed', 14338), " +
                //"('Swift Yellow Mechanostrider', 14377), " +
                //"('Swift Yellow Wind Rider', 17722), " +
                //"('Swift Zhevra', 24745), " +
                //"('Swift Zulian Tiger', 15290), " +
                //"('Tawny Wind Rider', 17699), " +
                //"('Teal Kodo', 12242), " +
                //"('Headless Horseman\\'s Mount', 22653), " +
                //"('Thunder Bluff Kodo', 29259), " +
                //"('Turbo-Charged Flying Machine', 22720), " +
                //"('Turbostrider', 14375), " +
                //"('Vengeful Nether Drake', 24725), " +
                //"('Black War Raptor', 14388), " +
                //"('Emerald Raptor', 4806), " +
                //"('Ivory Raptor', 6471), " +
                //"('Mottled Red Raptor', 6469), " +
                //"('Turquoise Raptor', 6472), " +
                //"('Venomhide Ravasaur', 5291), " +
                //"('Violet Raptor', 6473), " +
                //"('White Kodo', 12241), " +
                //"('White Ram X', 10003), " +
                //"('White Skeletal Warhorse', 28605), " +
                //"('White Stallion', 2410), " +
                //"('Winged Steed of the Ebon Blade', 28108), " +
                //"('Wooly White Rhino', 31721), " +
                //"('Wrathful Gladiator\\'s Frost Wyrm', 31047), " +
                //"('X-51 Nether-Rocket', 23656), " +
                //"('X-51 Nether-Rocket X-TREME', 23647), " +
                //"('X-53 Touring Rocket', 31992), " +
                //"('Yellow Qiraji Battle Tank', 15680), " +
                //"('Magnificent Flying Carpet', 28060), " +
                //"('Armored Brown Bear', 27821), " +
                //"('Black Drake Mount', 25831), " +
                //"('Black War Bear', 27819), " +
                //"('Bronze Drake Mount', 25833), " +
                //"('Onyxian Drake', 30346), " +
                //"('Red Drake Mount', 25854), " +
                //"('Twilight Drake Mount', 27796), " +
                //"('Wooly Mammoth', 27244), " +
                //"('Wooly Mammoth Bull', 26425), " +
                //"('Sunreaver Dragonhawk', 29695), " +
                //"('Sunreaver Dragonhawk', 29696), " +
                //"('Swift Horde Wolf', 29283), " +
                //"('Swift Zhevra', 24693), " +
                //"('Headless Horseman\\'s Mount', 25159), " +
                //"('Headless Horseman\\'s Mount', 25958), " +
                //"('Venomhide Ravasaur', 29102), " +
                //"('White Ram', 2786);"
                ;
            connection.Open();
            MySqlCommand command = new MySqlCommand(insertQuery, connection);

            try
            {

                textBox1.Text = command.ExecuteScalar().ToString();
                //label_query_executed_successfully2.Visible = false;

                if (command.ExecuteNonQuery() == 1)
                {
                    //label7.Visible = true;
                    //label_query_executed_successfully2.Visible = false;
                }
                else
                {
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

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
            BackToMainMenu backtomainmenu = new BackToMainMenu();
            backtomainmenu.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            NpcFlag npcflag = new NpcFlag();
            npcflag.ShowDialog();

            if (npcflag.checkedListBox1.GetItemCheckState(5/*Vendor*/) == CheckState.Checked)
                button13.Enabled = true;
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
                this.Location = new Point(
                    (this.Location.X - lastLocation.X) + e.X, (this.Location.Y - lastLocation.Y) + e.Y);

                this.Update();
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

        private void button10_Click(object sender, EventArgs e)
        {
            UInt32 npcflag_st = 0;
            uint unit_flags_st = 0;
            uint unit_flags2_st = 0;
            int dynamicflags_st = 0;
            uint type_flags_st = 0;
            uint mechanic_immune_mask_st = 0;
            uint flags_extra_st = 0;

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

            Form_MainMenu mainmenu = new Form_MainMenu();
            // Prepare SQL
            // select insertion columns
            string BuildSQLFile;
            BuildSQLFile = "INSERT INTO " + mainmenu.textbox_mysql_worldDB.Text + ".creature_template (entry, difficulty_entry_1, difficulty_entry_2, difficulty_entry_3, KillCredit1, ";
            BuildSQLFile += "KillCredit2, modelid1, modelid2, modelid3, modelid4, name, subname, IconName, gossip_menu_id, minlevel, ";
            BuildSQLFile += "maxlevel, exp, faction, npcflag, speed_walk, speed_run, scale, rank, dmgschool, BaseAttackTime, ";
            BuildSQLFile += "RangeAttackTime, BaseVariance, RangeVariance, unit_class, unit_flags, unit_flags2, dynamicflags, family, ";
            BuildSQLFile += "trainer_type, trainer_spell, trainer_class, trainer_race, type, type_flags, lootid, pickpocketloot, skinloot, ";
            BuildSQLFile += "resistance1, resistance2, resistance3, resistance4, resistance5, resistance6, spell1, spell2, spell3, ";
            BuildSQLFile += "spell4, spell5, spell6, spell7, spell8, PetSpellDataId, VehicleId, mingold, maxgold, AIName, MovementType, ";
            BuildSQLFile += "InhabitType, HoverHeight, HealthModifier, ManaModifier, ArmorModifier, DamageModifier, ExperienceModifier, ";
            BuildSQLFile += "RacialLeader, movementId, RegenHealth, mechanic_immune_mask, flags_extra, ScriptName, VerifiedBuild)";

            // values now
            BuildSQLFile += "VALUES\n";
            BuildSQLFile += "(";
            BuildSQLFile += textBox1.Text + ", "; // entry
            BuildSQLFile += textBox3.Text + ", "; // difficulty_entry_1
            BuildSQLFile += textBox2.Text + ", "; // difficulty_entry_2
            BuildSQLFile += textBox4.Text + ", "; // difficulty_entry_3
            BuildSQLFile += textBox5.Text + ", "; // KillCredit1
            BuildSQLFile += textBox6.Text + ", "; // KillCredit2
            BuildSQLFile += textBox10.Text + ", "; // modelid1
            BuildSQLFile += textBox11.Text + ", "; // modelid2
            BuildSQLFile += textBox9.Text + ", "; // modelid3
            BuildSQLFile += textBox8.Text + ", "; // modelid4
            BuildSQLFile += "'" + textBox7.Text + "', "; // name
            BuildSQLFile += "'" + textBox12.Text + "', "; // subname
            // BuildSQLFile += "'" + comboBox1.SelectedIndex + "', "; // IconName

            int IconName = comboBox1.SelectedIndex;
            switch (IconName)
            {
                case 0:
                    BuildSQLFile += "'" + "Directions" + "', ";
                    break;
                case 1:
                    BuildSQLFile += "'" + "Gunner" + "', ";
                    break;
                case 2:
                    BuildSQLFile += "'" + "vehichleCursor" + "', ";
                    break;
                case 3:
                    BuildSQLFile += "'" + "Driver" + "', ";
                    break;
                case 4:
                    BuildSQLFile += "'" + "Attack" + "', ";
                    break;
                case 5:
                    BuildSQLFile += "'" + "Buy" + "', ";
                    break;
                case 6:
                    BuildSQLFile += "'" + "Speak" + "', ";
                    break;
                case 7:
                    BuildSQLFile += "'" + "Pickup" + "', ";
                    break;
                case 8:
                    BuildSQLFile += "'" + "Interact" + "', ";
                    break;
                case 9:
                    BuildSQLFile += "'" + "Trainer" + "', ";
                    break;
                case 10:
                    BuildSQLFile += "'" + "Taxi" + "', ";
                    break;
                case 11:
                    BuildSQLFile += "'" + "Repair" + "', ";
                    break;
                case 12:
                    BuildSQLFile += "'" + "LootAll" + "', ";
                    break;
                case 13:
                    BuildSQLFile += "'" + "Quest" + "', ";
                    break;
                case 14:
                    BuildSQLFile += "'" + "PVP" + "', ";
                    break;
            }

            BuildSQLFile += textBox13.Text + ", "; // gossip_menu_id
            BuildSQLFile += textBox14.Text + ", "; // minlevel
            BuildSQLFile += textBox15.Text + ", "; // maxlevel
            BuildSQLFile += textBox16.Text + ", "; // exp
            BuildSQLFile += textBox17.Text + ", "; // faction
            BuildSQLFile += npcflag_st + ", "; // npcflag
            BuildSQLFile += textBox18.Text + ", "; // speed_walk
            BuildSQLFile += textBox19.Text + ", "; // speed_run
            BuildSQLFile += textBox20.Text + ", "; // scale
            BuildSQLFile += comboBox2.SelectedIndex + ", "; // rank
            BuildSQLFile += comboBox3.SelectedIndex + ", "; // dmgschool
            BuildSQLFile += textBox26.Text + ", "; // BaseAttackTime
            BuildSQLFile += textBox25.Text + ", "; // RangeAttackTime
            BuildSQLFile += textBox28.Text + ", "; // BaseVariance
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
            BuildSQLFile += unit_flags2_st + ", "; // unit_flags2
            BuildSQLFile += dynamicflags_st + ", "; // dynamicflags
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
            BuildSQLFile += textBox30.Text + ", "; // trainer_spell
            BuildSQLFile += textBox29.Text + ", "; // trainer_class
            BuildSQLFile += textBox32.Text + ", "; // trainer_race
            BuildSQLFile += comboBox7.SelectedIndex + ", "; // type
            BuildSQLFile += type_flags_st + ", "; // type_flags
            BuildSQLFile += textBox42.Text + ", "; // lootid
            BuildSQLFile += textBox41.Text + ", "; // pickpocketloot
            BuildSQLFile += textBox40.Text + ", "; // skinloot
            BuildSQLFile += textBox39.Text + ", "; // resistance1
            BuildSQLFile += textBox36.Text + ", "; // resistance2
            BuildSQLFile += textBox35.Text + ", "; // resistance3
            BuildSQLFile += textBox38.Text + ", "; // resistance4
            BuildSQLFile += textBox37.Text + ", "; // resistance5
            BuildSQLFile += textBox46.Text + ", "; // resistance6
            BuildSQLFile += textBox45.Text + ", "; // spell1
            BuildSQLFile += textBox44.Text + ", "; // spell2
            BuildSQLFile += textBox43.Text + ", "; // spell3
            BuildSQLFile += textBox52.Text + ", "; // spell4
            BuildSQLFile += textBox51.Text + ", "; // spell5
            BuildSQLFile += textBox50.Text + ", "; // spell6
            BuildSQLFile += textBox49.Text + ", "; // spell7
            BuildSQLFile += textBox48.Text + ", "; // spell8
            BuildSQLFile += textBox47.Text + ", "; // PetSpellDataID
            BuildSQLFile += textBox58.Text + ", "; // VehicleID
            BuildSQLFile += textBox57.Text + ", "; // mingold
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
            BuildSQLFile += textBox60.Text + ", "; // HoverHeight
            BuildSQLFile += textBox54.Text + ", "; // HealthModifier
            BuildSQLFile += textBox53.Text + ", "; // ManaModifier
            BuildSQLFile += textBox64.Text + ", "; // ArmorModofier
            BuildSQLFile += textBox61.Text + ", "; // DamageModifier
            BuildSQLFile += textBox65.Text + ", "; // ExperienceModifier
            BuildSQLFile += textBox66.Text + ", "; // RacialLeader
            BuildSQLFile += textBox55.Text + ", "; // movementID
            BuildSQLFile += textBox63.Text + ", "; // RegenHealth
            BuildSQLFile += mechanic_immune_mask_st + ", "; // mechanic_immune_mask
            BuildSQLFile += flags_extra_st + ", "; // flags_extra
            BuildSQLFile += "'" + textBox62.Text + "', "; // ScriptName
            BuildSQLFile += textBox59.Text; // VerifiedBuild
            BuildSQLFile += ");";

            stringSQLShare = BuildSQLFile;
            stringEntryShare = textBox1.Text;

            if (textBox1.Text == "")
            {
                MessageBox.Show("Entry should not be empty", "Error");
                return;
            }
            else if (textBox7.Text == "")
            {
                MessageBox.Show("Name should not be empty", "Error");
                return;
            }

            MySqlConnection connection = new MySqlConnection("datasource=" + mainmenu.textbox_mysql_hostname.Text + ";port=" + mainmenu.textbox_mysql_port.Text + ";username=" + mainmenu.textbox_mysql_username.Text + ";password=" + mainmenu.textbox_mysql_pass.Text);
            string insertQuery = stringSQLShare;
            connection.Open();
            MySqlCommand command = new MySqlCommand(insertQuery, connection);

            // Test
            try
            {
                //frm.label_query_executed_successfully.Visible = true;
                if (command.ExecuteNonQuery() == 1)
                {
                    // this.Close();
                    //frm.label83.ForeColor = Color.GreenYellow;
                    //label_query_executed_successfully2.Visible = true;
                    timer5.Start();
                }
                else
                {
                    //label_query_executed_successfully2.Visible = true;
                    timer5.Start();
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
            label_query_executed_successfully2.Visible = true;
            timer5.Stop();

            timer6.Start();
        }

        private void timer6_Tick(object sender, EventArgs e)
        {
            label_query_executed_successfully2.Visible = false;
            timer6.Stop();
        }

        //NPC Creator
        //copy to clipboard button (label)
        private void label86_Click(object sender, EventArgs e)
        {        
            UInt32 npcflag_st = 0;
            uint unit_flags_st = 0;
            uint unit_flags2_st = 0;
            int dynamicflags_st = 0;
            uint type_flags_st = 0;
            uint mechanic_immune_mask_st = 0;
            uint flags_extra_st = 0;

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

            Form_MainMenu mainmenu = new Form_MainMenu();
            // Prepare SQL
            // select insertion columns
            string BuildSQLFile;
            BuildSQLFile = "INSERT INTO " + mainmenu.textbox_mysql_worldDB.Text + ".creature_template (entry, difficulty_entry_1, difficulty_entry_2, difficulty_entry_3, KillCredit1, ";
            BuildSQLFile += "KillCredit2, modelid1, modelid2, modelid3, modelid4, name, subname, IconName, gossip_menu_id, minlevel, ";
            BuildSQLFile += "maxlevel, exp, faction, npcflag, speed_walk, speed_run, scale, rank, dmgschool, BaseAttackTime, ";
            BuildSQLFile += "RangeAttackTime, BaseVariance, RangeVariance, unit_class, unit_flags, unit_flags2, dynamicflags, family, ";
            BuildSQLFile += "trainer_type, trainer_spell, trainer_class, trainer_race, type, type_flags, lootid, pickpocketloot, skinloot, ";
            BuildSQLFile += "resistance1, resistance2, resistance3, resistance4, resistance5, resistance6, spell1, spell2, spell3, ";
            BuildSQLFile += "spell4, spell5, spell6, spell7, spell8, PetSpellDataId, VehicleId, mingold, maxgold, AIName, MovementType, ";
            BuildSQLFile += "InhabitType, HoverHeight, HealthModifier, ManaModifier, ArmorModifier, DamageModifier, ExperienceModifier, ";
            BuildSQLFile += "RacialLeader, movementId, RegenHealth, mechanic_immune_mask, flags_extra, ScriptName, VerifiedBuild)";

            // values now
            BuildSQLFile += "VALUES\n";
            BuildSQLFile += "(";
            BuildSQLFile += textBox1.Text + ", "; // entry
            BuildSQLFile += textBox3.Text + ", "; // difficulty_entry_1
            BuildSQLFile += textBox2.Text + ", "; // difficulty_entry_2
            BuildSQLFile += textBox4.Text + ", "; // difficulty_entry_3
            BuildSQLFile += textBox5.Text + ", "; // KillCredit1
            BuildSQLFile += textBox6.Text + ", "; // KillCredit2
            BuildSQLFile += textBox10.Text + ", "; // modelid1
            BuildSQLFile += textBox11.Text + ", "; // modelid2
            BuildSQLFile += textBox9.Text + ", "; // modelid3
            BuildSQLFile += textBox8.Text + ", "; // modelid4
            BuildSQLFile += "'" + textBox7.Text + "', "; // name
            BuildSQLFile += "'" + textBox12.Text + "', "; // subname
            // BuildSQLFile += "'" + comboBox1.SelectedIndex + "', "; // IconName

            int IconName = comboBox1.SelectedIndex;
            switch (IconName)
            {
                case 0:
                    BuildSQLFile += "'" + "Directions" + "', ";
                    break;
                case 1:
                    BuildSQLFile += "'" + "Gunner" + "', ";
                    break;
                case 2:
                    BuildSQLFile += "'" + "vehichleCursor" + "', ";
                    break;
                case 3:
                    BuildSQLFile += "'" + "Driver" + "', ";
                    break;
                case 4:
                    BuildSQLFile += "'" + "Attack" + "', ";
                    break;
                case 5:
                    BuildSQLFile += "'" + "Buy" + "', ";
                    break;
                case 6:
                    BuildSQLFile += "'" + "Speak" + "', ";
                    break;
                case 7:
                    BuildSQLFile += "'" + "Pickup" + "', ";
                    break;
                case 8:
                    BuildSQLFile += "'" + "Interact" + "', ";
                    break;
                case 9:
                    BuildSQLFile += "'" + "Trainer" + "', ";
                    break;
                case 10:
                    BuildSQLFile += "'" + "Taxi" + "', ";
                    break;
                case 11:
                    BuildSQLFile += "'" + "Repair" + "', ";
                    break;
                case 12:
                    BuildSQLFile += "'" + "LootAll" + "', ";
                    break;
                case 13:
                    BuildSQLFile += "'" + "Quest" + "', ";
                    break;
                case 14:
                    BuildSQLFile += "'" + "PVP" + "', ";
                    break;
            }

            BuildSQLFile += textBox13.Text + ", "; // gossip_menu_id
            BuildSQLFile += textBox14.Text + ", "; // minlevel
            BuildSQLFile += textBox15.Text + ", "; // maxlevel
            BuildSQLFile += textBox16.Text + ", "; // exp
            BuildSQLFile += textBox17.Text + ", "; // faction
            BuildSQLFile += npcflag_st + ", "; // npcflag
            BuildSQLFile += textBox18.Text + ", "; // speed_walk
            BuildSQLFile += textBox19.Text + ", "; // speed_run
            BuildSQLFile += textBox20.Text + ", "; // scale
            BuildSQLFile += comboBox2.SelectedIndex + ", "; // rank
            BuildSQLFile += comboBox3.SelectedIndex + ", "; // dmgschool
            BuildSQLFile += textBox26.Text + ", "; // BaseAttackTime
            BuildSQLFile += textBox25.Text + ", "; // RangeAttackTime
            BuildSQLFile += textBox28.Text + ", "; // BaseVariance
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
            BuildSQLFile += unit_flags2_st + ", "; // unit_flags2
            BuildSQLFile += dynamicflags_st + ", "; // dynamicflags
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
            BuildSQLFile += textBox30.Text + ", "; // trainer_spell
            BuildSQLFile += textBox29.Text + ", "; // trainer_class
            BuildSQLFile += textBox32.Text + ", "; // trainer_race
            BuildSQLFile += comboBox7.SelectedIndex + ", "; // type
            BuildSQLFile += type_flags_st + ", "; // type_flags
            BuildSQLFile += textBox42.Text + ", "; // lootid
            BuildSQLFile += textBox41.Text + ", "; // pickpocketloot
            BuildSQLFile += textBox40.Text + ", "; // skinloot
            BuildSQLFile += textBox39.Text + ", "; // resistance1
            BuildSQLFile += textBox36.Text + ", "; // resistance2
            BuildSQLFile += textBox35.Text + ", "; // resistance3
            BuildSQLFile += textBox38.Text + ", "; // resistance4
            BuildSQLFile += textBox37.Text + ", "; // resistance5
            BuildSQLFile += textBox46.Text + ", "; // resistance6
            BuildSQLFile += textBox45.Text + ", "; // spell1
            BuildSQLFile += textBox44.Text + ", "; // spell2
            BuildSQLFile += textBox43.Text + ", "; // spell3
            BuildSQLFile += textBox52.Text + ", "; // spell4
            BuildSQLFile += textBox51.Text + ", "; // spell5
            BuildSQLFile += textBox50.Text + ", "; // spell6
            BuildSQLFile += textBox49.Text + ", "; // spell7
            BuildSQLFile += textBox48.Text + ", "; // spell8
            BuildSQLFile += textBox47.Text + ", "; // PetSpellDataID
            BuildSQLFile += textBox58.Text + ", "; // VehicleID
            BuildSQLFile += textBox57.Text + ", "; // mingold
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
            BuildSQLFile += textBox60.Text + ", "; // HoverHeight
            BuildSQLFile += textBox54.Text + ", "; // HealthModifier
            BuildSQLFile += textBox53.Text + ", "; // ManaModifier
            BuildSQLFile += textBox64.Text + ", "; // ArmorModofier
            BuildSQLFile += textBox61.Text + ", "; // DamageModifier
            BuildSQLFile += textBox65.Text + ", "; // ExperienceModifier
            BuildSQLFile += textBox66.Text + ", "; // RacialLeader
            BuildSQLFile += textBox55.Text + ", "; // movementID
            BuildSQLFile += textBox63.Text + ", "; // RegenHealth
            BuildSQLFile += mechanic_immune_mask_st + ", "; // mechanic_immune_mask
            BuildSQLFile += flags_extra_st + ", "; // flags_extra
            BuildSQLFile += "'" + textBox62.Text + "', "; // ScriptName
            BuildSQLFile += textBox59.Text; // VerifiedBuild
            BuildSQLFile += ");";

            stringSQLShare = BuildSQLFile;
            stringEntryShare = textBox1.Text;

            if (textBox2.Text == "")
            {
                MessageBox.Show("Name should not be empty", "Error");
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
        }

        private void label70_MouseHover(object sender, EventArgs e)
        {
            label70.ForeColor = Color.RoyalBlue;
        }

        private void label70_MouseLeave(object sender, EventArgs e)
        {
            label70.ForeColor = Color.Blue;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            MySqlConnection connection = new MySqlConnection("datasource=" + mainmenu.textbox_mysql_hostname.Text + ";port=" + mainmenu.textbox_mysql_port.Text + ";username=" + mainmenu.textbox_mysql_username.Text + ";password=" + mainmenu.textbox_mysql_pass.Text);
            string insertQuery = "SELECT max(entry)+1 FROM " + mainmenu.textbox_mysql_worldDB.Text + ".creature_template;";
            //string insertQuery = textBox_SelectMaxPlus1.Text;
            connection.Open();
            MySqlCommand command = new MySqlCommand(insertQuery, connection);

            try
            {

                textBox1.Text = command.ExecuteScalar().ToString();
                //label_query_executed_successfully2.Visible = false;

                if (command.ExecuteNonQuery() == 1)
                {
                    textBox1.Text = command.ExecuteScalar().ToString();
                    //label7.Visible = true;
                    //label_query_executed_successfully2.Visible = false;
                }
                else
                {
                    textBox1.Text = command.ExecuteScalar().ToString();
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

        private void button11_Click(object sender, EventArgs e)
        {
            

            GenerateLoot gen = new GenerateLoot();
            gen.Show();
            //entry                 lootid
            gen.textBox61.Text = textBox42.Text;
            //                                 entry                   name                     subname
            gen.Text = "Generate Loot for [" + textBox1.Text + "] " + textBox7.Text;
            if (textBox12.Text != "") 
            gen.Text = "Generate Loot for [" + textBox1.Text + "] " + textBox7.Text + " <" +  textBox12.Text + ">";
        }

        private void textBox42_TextChanged(object sender, EventArgs e)
        {
            
              button11.Enabled = true;
            
            if (textBox42.Text == "0") button11.Enabled = false;
           else if (textBox42.Text == "") button11.Enabled = false;

        }

        //           lootid
        private void textBox42_KeyPress(object sender, KeyPressEventArgs e)
        {
            onlyNumbers(sender, e);
        }

        private void button12_Click(object sender, EventArgs e)
        {
            // Max+1 LootID

            MySqlConnection connection = new MySqlConnection("datasource=" + mainmenu.textbox_mysql_hostname.Text + ";port=" + mainmenu.textbox_mysql_port.Text + ";username=" + mainmenu.textbox_mysql_username.Text + ";password=" + mainmenu.textbox_mysql_pass.Text);
            string insertQuery = "SELECT max(entry)+1 FROM " + mainmenu.textbox_mysql_worldDB.Text + ".creature_loot_template;";
            //string insertQuery = textBox_SelectMaxPlus1.Text;
            connection.Open();
            MySqlCommand command = new MySqlCommand(insertQuery, connection);

            try
            {

                textBox42.Text = command.ExecuteScalar().ToString();
                //label_query_executed_successfully2.Visible = false;

                if (command.ExecuteNonQuery() == 1)
                {
                    textBox42.Text = command.ExecuteScalar().ToString();
                    //label7.Visible = true;
                    //label_query_executed_successfully2.Visible = false;
                }
                else
                {
                    textBox42.Text = command.ExecuteScalar().ToString();
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

        // almost all
        private void textBox25_KeyPress(object sender, KeyPressEventArgs e)
        {
            onlyNumbers(sender, e);
        }

        private void button13_Click(object sender, EventArgs e)
        {
            

            AddVendorItems vendor = new AddVendorItems();
            vendor.Show();
            //entry                 entry (NPC_Create)
            vendor.textBox61.Text = textBox1.Text;
            //                                       entry                  name                    subname
            vendor.Text = "Add Vendor Items for [" + textBox1.Text + "] " + textBox7.Text;
            if (textBox12.Text != "")
                vendor.Text = "Add Vendor Items for [" + textBox1.Text + "] " + textBox7.Text + " <" + textBox12.Text + ">";
            
        }

        private void button13_MouseHover(object sender, EventArgs e)
        {
            
        }

        private void label78_Click(object sender, EventArgs e)
        {
            Close();
            BackToMainMenu backtomainmenu = new BackToMainMenu();
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

        private void button14_Click(object sender, EventArgs e)
        {
            MountNPC mount = new MountNPC();
            mount.Show();

            //entry                 entry
            mount.textBox61.Text = textBox1.Text;
        }

        private void textBox30_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBox9_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox9.SelectedIndex == 7)
                button15.Enabled = true;
        }

        private void button15_Click(object sender, EventArgs e)
        {
            MakeNpcSay npcsay = new MakeNpcSay();
            npcsay.Show();

            //MakeNpcSay entry = NPC_creator entry
            npcsay.textBox61.Text = textBox1.Text;
        }
    }
}
