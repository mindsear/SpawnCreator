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

        private void GenerateLoot_Load(object sender, EventArgs e)
        {
            //NPC_Creator npc = new NPC_Creator();
            //textBox61.Text = npc.textBox42.Text;
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

            MySqlConnection connection = new MySqlConnection("datasource=" + mainmenu.textbox_mysql_hostname.Text + ";port=" + mainmenu.textbox_mysql_port.Text + ";username=" + mainmenu.textbox_mysql_username.Text + ";password=" + mainmenu.textbox_mysql_pass.Text);
            string insertQuery = "INSERT INTO " + mainmenu.textbox_mysql_worldDB.Text + ".creature_loot_template " +
                "(Entry, Item, Reference, Chance, QuestRequired, LootMode, GroupId, MinCount, MaxCount, Comment) " +
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
    }
}
