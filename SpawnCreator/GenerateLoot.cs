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
    public partial class GenerateLoot : Form
    {
        public GenerateLoot()
        {
            InitializeComponent();
        }

        private readonly Form_MainMenu form_MM;
        public GenerateLoot(Form_MainMenu form_MainMenu)
        {
            InitializeComponent();
            form_MM = form_MainMenu;
        }

        private void GenerateLoot_Load(object sender, EventArgs e)
        {
            //NPC_Creator npc = new NPC_Creator();
            //textBox61.Text = npc.textBox42.Text;
            if (form_MM.CB_NoMySQL.Checked)
            {
                // If CheckBox is Checked (Start without MySQL)
                button1.Enabled = false;
                button1.Visible = false;
                label11.Visible = false;
            }
            else
            {
                button1.Enabled = true;
                button1.Visible = true;
                label11.Visible = true;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form_MainMenu mainmenu = new Form_MainMenu();

            
            if (textBox65.Text == "")
            {
                MessageBox.Show("Item ID should not be empty", "Error");
                return;
            }
            if (textBox65.Text == "0")
            {
                MessageBox.Show("Item ID should not be 0", "Error");
                return;
            }

            MySqlConnection connection = new MySqlConnection(
                "datasource=" + form_MM.GetHost() + 
                ";port=" + form_MM.GetPort() + 
                ";username=" + form_MM.GetUser() + 
                ";password=" + form_MM.GetPass() 
                );

            string insertQuery = $"INSERT INTO { form_MM.GetWorldDB() }.creature_loot_template " +
                "(Entry, Item, Reference, Chance, QuestRequired, LootMode, GroupId, MinCount, MaxCount, Comment) \n" +
                "VALUES (" +
                textBox61.Text + ", " + // Entry
                textBox65.Text + ", " + // ItemID
                textBox1.Text + ", " + // Reference
                textBox2.Text + ", " + // Chance
                textBox4.Text + ", " + // QuestRequired
                textBox3.Text + ", " + // LootMode
                textBox8.Text + ", " + // GroupId
                textBox7.Text + ", " + // MinCount
                textBox6.Text + ", " + // MaxCount
                "'" + textBox5.Text + // Comment
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
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            connection.Close();
        }

        private void textBox65_TextChanged(object sender, EventArgs e)
        {
            label9.Visible = false;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
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

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            label9.Visible = false;
        }

        private void textBox8_TextChanged(object sender, EventArgs e)
        {
            label9.Visible = false;
        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {
            label9.Visible = false;
        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {
            label9.Visible = false;
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            label9.Visible = false;
        }

        private void label10_Click(object sender, EventArgs e)
        {
            Process.Start("https://trinitycore.atlassian.net/wiki/display/tc/loot_template");
        }

        private void label76_Click(object sender, EventArgs e)
        {
            if (textBox65.Text == "0") Process.Start("http://wotlk.openwow.com/");
           else if (textBox65.Text == "") Process.Start("http://wotlk.openwow.com/");
            else Process.Start("http://wotlk.openwow.com/item=" + textBox65.Text);
        }

        private void textBox65_KeyPress(object sender, KeyPressEventArgs e)
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

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
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

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
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

        private void textBox8_KeyPress(object sender, KeyPressEventArgs e)
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

        private void textBox7_KeyPress(object sender, KeyPressEventArgs e)
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

        private void textBox6_KeyPress(object sender, KeyPressEventArgs e)
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

        private void textBox61_TextChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            Clipboard.SetText($"INSERT INTO { form_MM.GetWorldDB() }.creature_loot_template " +
                "(Entry, Item, Reference, Chance, QuestRequired, LootMode, GroupId, MinCount, MaxCount, Comment) \n" +
                "VALUES (" +
                textBox61.Text + ", " + // Entry
                textBox65.Text + ", " + // ItemID
                textBox1.Text + ", " + // Reference
                textBox2.Text + ", " + // Chance
                textBox4.Text + ", " + // QuestRequired
                textBox3.Text + ", " + // LootMode
                textBox8.Text + ", " + // GroupId
                textBox7.Text + ", " + // MinCount
                textBox6.Text + ", " + // MaxCount
                "'" + textBox5.Text + // Comment
                "');");

            label9.Text = "Query has been copied to clipboard!";
            label9.Visible = true;
        }
    }
}
