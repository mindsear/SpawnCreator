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
    public partial class AddVendorItems : Form
    {
        public AddVendorItems()
        {
            InitializeComponent();
        }

        private void label10_Click(object sender, EventArgs e)
        {
            Process.Start("https://trinitycore.atlassian.net/wiki/display/tc/npc_vendor");
        }

        private void label1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "0") Process.Start("http://wotlk.openwow.com/");
            else if (textBox1.Text == "") Process.Start("http://wotlk.openwow.com/");
            else Process.Start("http://wotlk.openwow.com/item=" + textBox1.Text);
        }

        private void label81_Click(object sender, EventArgs e)
        {
           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form_MainMenu mainmenu = new Form_MainMenu();


            if (textBox1.Text == "")
            {
                MessageBox.Show("Item ID should not be empty", "Error");
                return;
            }
            if (textBox1.Text == "0")
            {
                MessageBox.Show("Item ID should not be 0", "Error");
                return;
            }

            MySqlConnection connection = new MySqlConnection("datasource=" + mainmenu.textbox_mysql_hostname.Text + ";port=" + mainmenu.textbox_mysql_port.Text + ";username=" + mainmenu.textbox_mysql_username.Text + ";password=" + mainmenu.textbox_mysql_pass.Text);
            string insertQuery = "INSERT INTO " + mainmenu.textbox_mysql_worldDB.Text + ".npc_vendor " +
                "(entry, slot, item, maxcount, incrtime, ExtendedCost, VerifiedBuild) " +
                "VALUES (" +
                textBox61.Text + ", " + // entry
                textBox65.Text + ", " + // slot
                textBox1.Text + ", " + // item
                textBox2.Text + ", " + // maxcount
                textBox4.Text + ", " + // incrtime
                textBox3.Text + ", " + // ExtendedCost
                textBox5.Text + // VerifiedBuild
                ");";

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

        // Only Numbers for All textBoxes
        private void textBox65_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void label6_Click(object sender, EventArgs e)
        {

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

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            label9.Visible = false;
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void textBox65_TextChanged(object sender, EventArgs e)
        {
            label9.Visible = false;
        }
    }
}
