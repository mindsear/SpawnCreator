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

namespace SpawnCreator
{
    public partial class AddGossipMenus : Form
    {

        public AddGossipMenus()
        {
            InitializeComponent();
        }
        private readonly Form_MainMenu form_MM;

        public AddGossipMenus(Form_MainMenu _form_MainMenu)
        {
            InitializeComponent();
            form_MM = _form_MainMenu; 
        }

        private void AddGossipMenus_Load(object sender, EventArgs e)
        {
            comboBox_option_icon.SelectedIndex = 0; // GOSSIP_ICON_CHAT
            comboBox_option_id.SelectedIndex = 1; // GOSSIP_OPTION_GOSSIP
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            textBox_option_icon.Text = Convert.ToString(comboBox_option_icon.SelectedIndex);

            if (comboBox_option_icon.SelectedIndex == 0) pictureBox1.Image = Properties.Resources.GossipGossipIcon;
            else if (comboBox_option_icon.SelectedIndex == 1) pictureBox1.Image = Properties.Resources.VendorGossipIcon;
            else if (comboBox_option_icon.SelectedIndex == 2) pictureBox1.Image = Properties.Resources.TaxiGossipIcon;
            else if (comboBox_option_icon.SelectedIndex == 3) pictureBox1.Image = Properties.Resources.TrainerGossipIcon;
            else if (comboBox_option_icon.SelectedIndex == 4) pictureBox1.Image = Properties.Resources.BinderGossipIcon;
            else if (comboBox_option_icon.SelectedIndex == 5) pictureBox1.Image = Properties.Resources.BinderGossipIcon;
            else if (comboBox_option_icon.SelectedIndex == 6) pictureBox1.Image = Properties.Resources.BankerGossipIcon;
            else if (comboBox_option_icon.SelectedIndex == 7) pictureBox1.Image = Properties.Resources.PetitionGossipIcon;
            else if (comboBox_option_icon.SelectedIndex == 8) pictureBox1.Image = Properties.Resources.TabardGossipIcon;
            else if (comboBox_option_icon.SelectedIndex == 9) pictureBox1.Image = Properties.Resources.BattleMasterGossipIcon;
            else if (comboBox_option_icon.SelectedIndex == 10) pictureBox1.Image = Properties.Resources.yellow_dot;
        }

        private void comboBox_option_id_SelectedIndexChanged(object sender, EventArgs e)
        {
            textBox_option_id.Text = Convert.ToString(comboBox_option_id.SelectedIndex);
        }

        private void label10_Click(object sender, EventArgs e)
        {
            Process.Start("https://trinitycore.atlassian.net/wiki/display/tc/gossip_menu_option");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form_MainMenu mainmenu = new Form_MainMenu();
            var npc = new NPC_Creator();

            if (textBox5.Text == "")
            {
                MessageBox.Show("Option Text should not be empty", "Error");
                return;
            }  

            MySqlConnection connection = new MySqlConnection(
                "datasource=" + form_MM.GetHost() + ";" +
                "port=" + form_MM.GetPort() + ";" +
                "username=" + form_MM.GetUser() + ";" +
                "password=" + form_MM.GetPass()
                );

            string insertQuery = "INSERT INTO " + form_MM.GetWorldDB() + ".gossip_menu_option " +
                "(menu_id, id, option_icon, option_text, OptionBroadcastTextID, option_id, npc_option_npcflag, action_menu_id, action_poi_id, box_coded, box_money, box_text, BoxBroadcastTextID, VerifiedBuild) " +
                "VALUES (" +
                textBox61.Text + ", " + // menu_id
                numericUpDown1.Text + ", " + // id
                textBox_option_icon.Text + ", '" + // option_icon
                textBox5.Text + "', " + // option_text
                textBox4.Text + ", " + // OptionBroadcastTextID
                textBox_option_id.Text + ", " + // option_id
                textBox7.Text + ", " + // npc_option_npcflag
                textBox6.Text + ", " + // action_menu_id
                textBox3.Text + ", " + // action_poi_id
                textBox2.Text + ", " + // box_coded
                textBox10.Text + ", '" + // box_money
                textBox9.Text + "', " + // box_text
                textBox11.Text + ", " + // BoxBroadcastTextID
                textBox12.Text + ");";// VerifiedBuild

            connection.Open();
            MySqlCommand command = new MySqlCommand(insertQuery, connection);

            try
            {
                if (command.ExecuteNonQuery() == 1)
                {
                    label9.Visible = true;
                }
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            connection.Close();
        }

        private void textBox_option_icon_TextChanged(object sender, EventArgs e)
        {
            label9.Visible = false;
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            label9.Visible = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }
    }
}
