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

namespace SpawnCreator
{
    public partial class MountNPC : Form
    {
        public MountNPC()
        {
            InitializeComponent();
        }
        Form_MainMenu mainmenu = new Form_MainMenu();
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void MountNPC_Load(object sender, EventArgs e)
        {
            //textBox7.Text = "Amani War Bear - 22464\n" +
            //                "Argent Charger - 28919\n" 
            //    ;
            comboBox1.SelectedIndex = 0; // default

            string constring = "datasource=" + mainmenu.textbox_mysql_hostname.Text + ";port=" + mainmenu.textbox_mysql_port.Text + ";username=" + mainmenu.textbox_mysql_username.Text + ";password=" + mainmenu.textbox_mysql_pass.Text;
            MySqlConnection conDataBase = new MySqlConnection(constring);
            MySqlCommand com = new MySqlCommand("select name, modelid1 from " + mainmenu.textbox_mysql_worldDB.Text + ".creature_template where name LIKE '%" + textBox6.Text + "%';", conDataBase);

            //MySqlCommand com2 = new MySqlCommand("select * from mountlist.mountlist;", conDataBase);

            try
            {
                MySqlDataAdapter sda = new MySqlDataAdapter();
                sda.SelectCommand = com;
                //sda.SelectCommand = com2;
                DataTable dbdataset = new DataTable();
                sda.Fill(dbdataset);
                BindingSource bsource = new BindingSource();

                bsource.DataSource = dbdataset;
                dataGridView1.DataSource = bsource;
                //dataGridView2.DataSource = bsource;
                sda.Update(dbdataset);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //MessageBox.Show("If the name contains an apostrophe type like this example:\ncrusader\\'s black warhorse");
        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {
            //if (!System.Text.RegularExpressions.Regex.IsMatch(textBox1.Text, "^[a-zA-Z]"))
            //{
            //    //MessageBox.Show("This textbox accepts only alphabetical characters");
            //    textBox1.Text.Remove(textBox1.Text.Length - 1);
            //}

            string constring = "datasource=" + mainmenu.textbox_mysql_hostname.Text + ";port=" + mainmenu.textbox_mysql_port.Text + ";username=" + mainmenu.textbox_mysql_username.Text + ";password=" + mainmenu.textbox_mysql_pass.Text;
            MySqlConnection conDataBase = new MySqlConnection(constring);
            MySqlCommand com = new MySqlCommand("select name, modelid1 from " + mainmenu.textbox_mysql_worldDB.Text + ".creature_template where name LIKE '%" + textBox6.Text + "%';", conDataBase);
            

            try
            {
                MySqlDataAdapter sda = new MySqlDataAdapter();
                sda.SelectCommand = com;
                DataTable dbdataset = new DataTable();
                sda.Fill(dbdataset);
                BindingSource bsource = new BindingSource();

                bsource.DataSource = dbdataset;
                dataGridView1.DataSource = bsource;
                sda.Update(dbdataset);

            }
            catch (Exception /*ex*/)
            {
                //MessageBox.Show(ex.Message);
                MessageBox.Show("If the name contains an apostrophe type like this example:\ncrusader\\'s black warhorse");
            }
        }

        private void textBox6_KeyPress(object sender, KeyPressEventArgs e)
        {
            //e.Handled = !(char.IsLetter(e.KeyChar) || e.KeyChar == (char)Keys.Back && (e.KeyChar != '.'));

            //// only allow one space
            //if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -2))
            //{
            //    e.Handled = true;
            //}
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            textBox3.Text = comboBox1.Text;
            label9.Visible = false;

            if (comboBox1.Text == "EMOTE_ONESHOT_NONE") textBox3.Text = "0";
            else if (comboBox1.Text == "EMOTE_ONESHOT_TALK") textBox3.Text = "1";
            else if (comboBox1.Text == "EMOTE_ONESHOT_BOW") textBox3.Text = "2";
            else if (comboBox1.Text == "EMOTE_ONESHOT_WAVE") textBox3.Text = "3";
            else if (comboBox1.Text == "EMOTE_ONESHOT_CHEER") textBox3.Text = "4";
            else if (comboBox1.Text == "EMOTE_ONESHOT_EXCLAMATION") textBox3.Text = "5";
            else if (comboBox1.Text == "EMOTE_ONESHOT_QUESTION") textBox3.Text = "6";
            else if (comboBox1.Text == "EMOTE_ONESHOT_EAT") textBox3.Text = "7";
            else if (comboBox1.Text == "EMOTE_STATE_DANCE") textBox3.Text = "10";
            else if (comboBox1.Text == "EMOTE_ONESHOT_LAUGH") textBox3.Text = "11";
            else if (comboBox1.Text == "EMOTE_STATE_SLEEP") textBox3.Text = "12";
            else if (comboBox1.Text == "EMOTE_STATE_SIT") textBox3.Text = "13";
            else if (comboBox1.Text == "EMOTE_ONESHOT_RUDE") textBox3.Text = "14";
            else if (comboBox1.Text == "EMOTE_ONESHOT_ROAR") textBox3.Text = "15";
            else if (comboBox1.Text == "EMOTE_ONESHOT_KNEEL") textBox3.Text = "16";
            else if (comboBox1.Text == "EMOTE_ONESHOT_KISS") textBox3.Text = "17";
            else if (comboBox1.Text == "EMOTE_ONESHOT_CRY") textBox3.Text = "18";
            else if (comboBox1.Text == "EMOTE_ONESHOT_CHICKEN") textBox3.Text = "19";
            else if (comboBox1.Text == "EMOTE_ONESHOT_BEG") textBox3.Text = "20";
            else if (comboBox1.Text == "EMOTE_ONESHOT_APPLAUD") textBox3.Text = "21";
            else if (comboBox1.Text == "EMOTE_ONESHOT_SHOUT") textBox3.Text = "22";
            else if (comboBox1.Text == "EMOTE_ONESHOT_FLEX") textBox3.Text = "23";
            else if (comboBox1.Text == "EMOTE_ONESHOT_SHY") textBox3.Text = "24";
            else if (comboBox1.Text == "EMOTE_ONESHOT_POINT") textBox3.Text = "25";
            else if (comboBox1.Text == "EMOTE_STATE_STAND") textBox3.Text = "26";
            else if (comboBox1.Text == "EMOTE_STATE_READY_UNARMED") textBox3.Text = "27";
            else if (comboBox1.Text == "EMOTE_STATE_WORK_SHEATHED") textBox3.Text = "28";
            else if (comboBox1.Text == "EMOTE_STATE_POINT") textBox3.Text = "29";
            else if (comboBox1.Text == "EMOTE_STATE_NONE") textBox3.Text = "30";
            else if (comboBox1.Text == "EMOTE_ONESHOT_WOUND") textBox3.Text = "33";
            else if (comboBox1.Text == "EMOTE_ONESHOT_WOUND_CRITICAL") textBox3.Text = "34";
            else if (comboBox1.Text == "EMOTE_ONESHOT_ATTACK_UNARMED") textBox3.Text = "35";
            else if (comboBox1.Text == "EMOTE_ONESHOT_ATTACK1H") textBox3.Text = "36";
            else if (comboBox1.Text == "EMOTE_ONESHOT_ATTACK2HTIGHT") textBox3.Text = "37";
            else if (comboBox1.Text == "EMOTE_ONESHOT_ATTACK2H_LOOSE") textBox3.Text = "38";
            else if (comboBox1.Text == "EMOTE_ONESHOT_PARRY_UNARMED") textBox3.Text = "39";
            else if (comboBox1.Text == "EMOTE_ONESHOT_PARRY_SHIELD") textBox3.Text = "43";
            else if (comboBox1.Text == "EMOTE_ONESHOT_READY_UNARMED") textBox3.Text = "44";
            else if (comboBox1.Text == "EMOTE_ONESHOT_READY1H") textBox3.Text = "45";
            else if (comboBox1.Text == "EMOTE_ONESHOT_READY_BOW") textBox3.Text = "48";
            else if (comboBox1.Text == "EMOTE_ONESHOT_SPELL_PRECAST") textBox3.Text = "50";
            else if (comboBox1.Text == "EMOTE_ONESHOT_SPELL_CAST") textBox3.Text = "51";
            else if (comboBox1.Text == "EMOTE_ONESHOT_BATTLE_ROAR") textBox3.Text = "53";
            else if (comboBox1.Text == "EMOTE_ONESHOT_SPECIALATTACK1H") textBox3.Text = "54";
            else if (comboBox1.Text == "EMOTE_ONESHOT_KICK") textBox3.Text = "60";
            else if (comboBox1.Text == "EMOTE_ONESHOT_ATTACK_THROWN") textBox3.Text = "61";
            else if (comboBox1.Text == "EMOTE_STATE_STUN") textBox3.Text = "64";
            else if (comboBox1.Text == "EMOTE_STATE_DEAD") textBox3.Text = "65";
            else if (comboBox1.Text == "EMOTE_ONESHOT_SALUTE") textBox3.Text = "66";
            else if (comboBox1.Text == "EMOTE_STATE_KNEEL") textBox3.Text = "68";
            else if (comboBox1.Text == "EMOTE_STATE_USE_STANDING") textBox3.Text = "69";
            else if (comboBox1.Text == "EMOTE_ONESHOT_WAVE_NO_SHEATHE") textBox3.Text = "70";
            else if (comboBox1.Text == "EMOTE_ONESHOT_CHEER_NO_SHEATHE") textBox3.Text = "71";
            else if (comboBox1.Text == "EMOTE_ONESHOT_EAT_NO_SHEATHE") textBox3.Text = "92";
            else if (comboBox1.Text == "EMOTE_STATE_STUN_NO_SHEATHE") textBox3.Text = "93";
            else if (comboBox1.Text == "EMOTE_ONESHOT_DANCE") textBox3.Text = "94";
            else if (comboBox1.Text == "EMOTE_ONESHOT_SALUTE_NO_SHEATH") textBox3.Text = "113";
            else if (comboBox1.Text == "EMOTE_STATE_USE_STANDING_NO_SHEATHE") textBox3.Text = "133";
            else if (comboBox1.Text == "EMOTE_ONESHOT_LAUGH_NO_SHEATHE") textBox3.Text = "153";
            else if (comboBox1.Text == "EMOTE_STATE_WORK") textBox3.Text = "173";
            else if (comboBox1.Text == "EMOTE_STATE_SPELL_PRECAST") textBox3.Text = "193";
            else if (comboBox1.Text == "EMOTE_ONESHOT_READY_RIFLE") textBox3.Text = "213";
            else if (comboBox1.Text == "EMOTE_STATE_READY_RIFLE") textBox3.Text = "214";
            else if (comboBox1.Text == "EMOTE_STATE_WORK_MINING") textBox3.Text = "233";
            else if (comboBox1.Text == "EMOTE_STATE_WORK_CHOPWOOD") textBox3.Text = "234";
            else if (comboBox1.Text == "EMOTE_STATE_APPLAUD") textBox3.Text = "253";
            else if (comboBox1.Text == "EMOTE_ONESHOT_LIFTOFF") textBox3.Text = "254";
            else if (comboBox1.Text == "EMOTE_ONESHOT_YES") textBox3.Text = "273";
            else if (comboBox1.Text == "EMOTE_ONESHOT_NO") textBox3.Text = "274";
            else if (comboBox1.Text == "EMOTE_ONESHOT_TRAIN") textBox3.Text = "275";
            else if (comboBox1.Text == "EMOTE_ONESHOT_LAND") textBox3.Text = "293";
            else if (comboBox1.Text == "EMOTE_STATE_AT_EASE") textBox3.Text = "313";
            else if (comboBox1.Text == "EMOTE_STATE_READY1H") textBox3.Text = "333";
            else if (comboBox1.Text == "EMOTE_STATE_SPELL_KNEEL_START") textBox3.Text = "353";
            else if (comboBox1.Text == "EMOTE_STATE_SUBMERGED") textBox3.Text = "373";
            else if (comboBox1.Text == "EMOTE_ONESHOT_SUBMERGE") textBox3.Text = "374";
            else if (comboBox1.Text == "EMOTE_STATE_READY2H") textBox3.Text = "375";
            else if (comboBox1.Text == "EMOTE_STATE_READY_BOW") textBox3.Text = "376";
            else if (comboBox1.Text == "EMOTE_ONESHOT_MOUNT_SPECIAL") textBox3.Text = "377";
            else if (comboBox1.Text == "EMOTE_STATE_TALK") textBox3.Text = "378";
            else if (comboBox1.Text == "EMOTE_STATE_FISHING") textBox3.Text = "379";
            else if (comboBox1.Text == "EMOTE_ONESHOT_FISHING") textBox3.Text = "380";
            else if (comboBox1.Text == "EMOTE_ONESHOT_LOOT") textBox3.Text = "381";
            else if (comboBox1.Text == "EMOTE_STATE_WHIRLWIND") textBox3.Text = "382";
            else if (comboBox1.Text == "EMOTE_STATE_DROWNED") textBox3.Text = "383";
            else if (comboBox1.Text == "EMOTE_STATE_HOLD_BOW") textBox3.Text = "384";
            else if (comboBox1.Text == "EMOTE_STATE_HOLD_RIFLE") textBox3.Text = "385";
            else if (comboBox1.Text == "EMOTE_STATE_HOLD_THROWN") textBox3.Text = "386";
            else if (comboBox1.Text == "EMOTE_ONESHOT_DROWN") textBox3.Text = "387";
            else if (comboBox1.Text == "EMOTE_ONESHOT_STOMP") textBox3.Text = "388";
            else if (comboBox1.Text == "EMOTE_ONESHOT_ATTACK_OFF") textBox3.Text = "389";
            else if (comboBox1.Text == "EMOTE_ONESHOT_ATTACK_OFF_PIERCE") textBox3.Text = "390";
            else if (comboBox1.Text == "EMOTE_STATE_ROAR") textBox3.Text = "391";
            else if (comboBox1.Text == "EMOTE_STATE_LAUGH") textBox3.Text = "392";
            else if (comboBox1.Text == "EMOTE_ONESHOT_CREATURE_SPECIAL") textBox3.Text = "393";
            else if (comboBox1.Text == "EMOTE_ONESHOT_JUMPLANDRUN") textBox3.Text = "394";
            else if (comboBox1.Text == "EMOTE_ONESHOT_JUMPEND") textBox3.Text = "395";
            else if (comboBox1.Text == "EMOTE_ONESHOT_TALK_NO_SHEATHE") textBox3.Text = "396";
            else if (comboBox1.Text == "EMOTE_ONESHOT_POINT_NO_SHEATHE") textBox3.Text = "397";
            else if (comboBox1.Text == "EMOTE_STATE_CANNIBALIZE") textBox3.Text = "398";
            else if (comboBox1.Text == "EMOTE_ONESHOT_JUMPSTART") textBox3.Text = "399";
            else if (comboBox1.Text == "EMOTE_STATE_DANCESPECIAL") textBox3.Text = "400";
            else if (comboBox1.Text == "EMOTE_ONESHOT_DANCESPECIAL") textBox3.Text = "401";
            else if (comboBox1.Text == "EMOTE_ONESHOT_CUSTOM_SPELL_01") textBox3.Text = "402";
            else if (comboBox1.Text == "EMOTE_ONESHOT_CUSTOM_SPELL_02") textBox3.Text = "403";
            else if (comboBox1.Text == "EMOTE_ONESHOT_CUSTOM_SPELL_03") textBox3.Text = "404";
            else if (comboBox1.Text == "EMOTE_ONESHOT_CUSTOM_SPELL_04") textBox3.Text = "405";
            else if (comboBox1.Text == "EMOTE_ONESHOT_CUSTOM_SPELL_05") textBox3.Text = "406";
            else if (comboBox1.Text == "EMOTE_ONESHOT_CUSTOM_SPELL_06") textBox3.Text = "407";
            else if (comboBox1.Text == "EMOTE_ONESHOT_CUSTOM_SPELL_07") textBox3.Text = "408";
            else if (comboBox1.Text == "EMOTE_ONESHOT_CUSTOM_SPELL_08") textBox3.Text = "409";
            else if (comboBox1.Text == "EMOTE_ONESHOT_CUSTOM_SPELL_09") textBox3.Text = "410";
            else if (comboBox1.Text == "EMOTE_ONESHOT_CUSTOM_SPELL_10") textBox3.Text = "411";
            else if (comboBox1.Text == "EMOTE_STATE_EXCLAIM") textBox3.Text = "412";
            else if (comboBox1.Text == "EMOTE_STATE_DANCE_CUSTOM") textBox3.Text = "413";
            else if (comboBox1.Text == "EMOTE_STATE_SIT_CHAIR_MED") textBox3.Text = "415";
            else if (comboBox1.Text == "EMOTE_STATE_CUSTOM_SPELL_01") textBox3.Text = "416";
            else if (comboBox1.Text == "EMOTE_STATE_CUSTOM_SPELL_02") textBox3.Text = "417";
            else if (comboBox1.Text == "EMOTE_STATE_EAT") textBox3.Text = "418";
            else if (comboBox1.Text == "EMOTE_STATE_CUSTOM_SPELL_04") textBox3.Text = "419";
            else if (comboBox1.Text == "EMOTE_STATE_CUSTOM_SPELL_03") textBox3.Text = "420";
            else if (comboBox1.Text == "EMOTE_STATE_CUSTOM_SPELL_05") textBox3.Text = "421";
            else if (comboBox1.Text == "EMOTE_STATE_SPELLEFFECT_HOLD") textBox3.Text = "422";
            else if (comboBox1.Text == "EMOTE_STATE_EAT_NO_SHEATHE") textBox3.Text = "423";
            else if (comboBox1.Text == "EMOTE_STATE_MOUNT") textBox3.Text = "424";
            else if (comboBox1.Text == "EMOTE_STATE_READY2HL") textBox3.Text = "425";
            else if (comboBox1.Text == "EMOTE_STATE_SIT_CHAIR_HIGH") textBox3.Text = "426";
            else if (comboBox1.Text == "EMOTE_STATE_FALL") textBox3.Text = "427";
            else if (comboBox1.Text == "EMOTE_STATE_LOO") textBox3.Text = "428";
            else if (comboBox1.Text == "EMOTE_STATE_SUBMERGED_NEW") textBox3.Text = "429";
            else if (comboBox1.Text == "EMOTE_ONESHOT_COWER") textBox3.Text = "430";
            else if (comboBox1.Text == "EMOTE_STATE_COWER") textBox3.Text = "431";
            else if (comboBox1.Text == "EMOTE_ONESHOT_USE_STANDING") textBox3.Text = "432";
            else if (comboBox1.Text == "EMOTE_STATE_STEALTH_STAND") textBox3.Text = "433";
            else if (comboBox1.Text == "EMOTE_ONESHOT_OMNICAST_GHOUL") textBox3.Text = "434";
            else if (comboBox1.Text == "EMOTE_ONESHOT_ATTACK_BOW") textBox3.Text = "435";
            else if (comboBox1.Text == "EMOTE_ONESHOT_ATTACK_RIFLE") textBox3.Text = "436";
            else if (comboBox1.Text == "EMOTE_STATE_SWIM_IDLE") textBox3.Text = "437";
            else if (comboBox1.Text == "EMOTE_STATE_ATTACK_UNARMED") textBox3.Text = "438";
            else if (comboBox1.Text == "EMOTE_ONESHOT_SPELL_CAST_W_SOUND") textBox3.Text = "439";
            else if (comboBox1.Text == "EMOTE_ONESHOT_DODGE") textBox3.Text = "440";
            else if (comboBox1.Text == "EMOTE_ONESHOT_PARRY1H") textBox3.Text = "441";
            else if (comboBox1.Text == "EMOTE_ONESHOT_PARRY2H") textBox3.Text = "442";
            else if (comboBox1.Text == "EMOTE_ONESHOT_PARRY2HL") textBox3.Text = "443";
            else if (comboBox1.Text == "EMOTE_STATE_FLYFALL") textBox3.Text = "444";
            else if (comboBox1.Text == "EMOTE_ONESHOT_FLYDEATH") textBox3.Text = "445";
            else if (comboBox1.Text == "EMOTE_STATE_FLY_FALL") textBox3.Text = "446";
            else if (comboBox1.Text == "EMOTE_ONESHOT_FLY_SIT_GROUND_DOWN") textBox3.Text = "447";
            else if (comboBox1.Text == "EMOTE_ONESHOT_FLY_SIT_GROUND_UP") textBox3.Text = "448";
            else if (comboBox1.Text == "EMOTE_ONESHOT_EMERGE") textBox3.Text = "449";
            else if (comboBox1.Text == "EMOTE_ONESHOT_DRAGON_SPIT") textBox3.Text = "450";
            else if (comboBox1.Text == "EMOTE_STATE_SPECIAL_UNARMED") textBox3.Text = "451";
            else if (comboBox1.Text == "EMOTE_ONESHOT_FLYGRAB") textBox3.Text = "452";
            else if (comboBox1.Text == "EMOTE_STATE_FLYGRABCLOSED") textBox3.Text = "453";
            else if (comboBox1.Text == "EMOTE_ONESHOT_FLYGRABTHROWN") textBox3.Text = "454";
            else if (comboBox1.Text == "EMOTE_STATE_FLY_SIT_GROUND") textBox3.Text = "455";
            else if (comboBox1.Text == "EMOTE_STATE_WALK_BACKWARDS") textBox3.Text = "456";
            else if (comboBox1.Text == "EMOTE_ONESHOT_FLYTALK") textBox3.Text = "457";
            else if (comboBox1.Text == "EMOTE_ONESHOT_FLYATTACK1H") textBox3.Text = "458";
            else if (comboBox1.Text == "EMOTE_STATE_CUSTOM_SPELL_08") textBox3.Text = "459";
            else if (comboBox1.Text == "EMOTE_ONESHOT_FLY_DRAGON_SPIT") textBox3.Text = "460";
            else if (comboBox1.Text == "EMOTE_STATE_SIT_CHAIR_LOW") textBox3.Text = "461";
            else if (comboBox1.Text == "EMOTE_ONESHOT_STUN") textBox3.Text = "462";
            else if (comboBox1.Text == "EMOTE_ONESHOT_SPELL_CAST_OMNI") textBox3.Text = "463";
            else if (comboBox1.Text == "EMOTE_STATE_READY_THROWN") textBox3.Text = "465";
            else if (comboBox1.Text == "EMOTE_ONESHOT_WORK_CHOPWOOD") textBox3.Text = "466";
            else if (comboBox1.Text == "EMOTE_ONESHOT_WORK_MINING") textBox3.Text = "467";
            else if (comboBox1.Text == "EMOTE_STATE_SPELL_CHANNEL_OMNI") textBox3.Text = "468";
            else if (comboBox1.Text == "EMOTE_STATE_SPELL_CHANNEL_DIRECTED") textBox3.Text = "469";
            else if (comboBox1.Text == "EMOTE_STAND_STATE_NONE") textBox3.Text = "470";
            else if (comboBox1.Text == "EMOTE_STATE_READYJOUST") textBox3.Text = "471";
            else if (comboBox1.Text == "EMOTE_STATE_STRANGULATE") textBox3.Text = "473";
            else if (comboBox1.Text == "EMOTE_STATE_READY_SPELL_OMNI") textBox3.Text = "474";
            else if (comboBox1.Text == "EMOTE_STATE_HOLD_JOUST") textBox3.Text = "475";
        }

        private void four_textboxes_allowNumbersOnly(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form_MainMenu mainmenu = new Form_MainMenu();


            if (textBox1.Text == "")
            {
                MessageBox.Show("Mount Model ID should not be empty", "Error");
                return;
            }
            if (textBox65.Text == "")
            {
                MessageBox.Show("Path ID should not be empty", "Error");
                return;
            }
            if (textBox2.Text == "")
            {
                MessageBox.Show("Bytes1 should not be empty", "Error");
                return;
            }
            if (textBox4.Text == "")
            {
                MessageBox.Show("Bytes2 should not be empty", "Error");
                return;
            }

            MySqlConnection connection = new MySqlConnection("datasource=" + mainmenu.textbox_mysql_hostname.Text + ";port=" + mainmenu.textbox_mysql_port.Text + ";username=" + mainmenu.textbox_mysql_username.Text + ";password=" + mainmenu.textbox_mysql_pass.Text);
            string insertQuery = "REPLACE INTO " + mainmenu.textbox_mysql_worldDB.Text + ".creature_template_addon " +
                "(entry, path_id, mount, bytes1, bytes2, emote, auras) " +
                "VALUES (" +
                textBox61.Text + ", " + // entry
                textBox65.Text + ", " + // path_id
                textBox1.Text + ", " + // mount
                textBox2.Text + ", " + // bytes1
                textBox4.Text + ", " + // bytes2
                textBox3.Text + ", '" + // emote
                textBox5.Text + // auras
                "');";
            connection.Open();
            MySqlCommand command = new MySqlCommand(insertQuery, connection);

            // Test
            try
            {
                if (command.ExecuteNonQuery() == 1)
                {
                    label9.Visible = true;
                }
                else
                {
                    label9.Visible = true;
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

        private void label10_Click(object sender, EventArgs e)
        {
            Process.Start("https://trinitycore.atlassian.net/wiki/display/tc/creature_addon");
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            label9.Visible = false;
        }

        private void textBox65_TextChanged(object sender, EventArgs e)
        {
            label9.Visible = false;
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            label9.Visible = false;
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            label9.Visible = false;
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            label9.Visible = false;
        }
    }
}
