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

        private readonly Form_MainMenu form_MM;
        public AddVendorItems(Form_MainMenu form_MainMenu)
        {
            InitializeComponent();
            form_MM = form_MainMenu; 
        }

        private void label10_Click(object sender, EventArgs e)
        {
            Process.Start("https://trinitycore.atlassian.net/wiki/display/tc/npc_vendor");
        }

        private void label1_Click(object sender, EventArgs e)
        {

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

            MySqlConnection connection = new MySqlConnection(
                               $"datasource={ form_MM.GetHost() };" +
                               $"port={ form_MM.GetPort() };" +
                               $"username={ form_MM.GetUser() };" +
                               $"password={ form_MM.GetPass() };"
                            );
            string insertQuery = $"INSERT INTO { form_MM.GetWorldDB() }.npc_vendor " +
                "(entry, slot, item, maxcount, incrtime, ExtendedCost, VerifiedBuild) " + Environment.NewLine +
                "VALUES (" +
                textBox61.Text + ", " + // entry
                textBox65.Text + ", " + // slot
                textBox1.Text + ", " + // item
                textBox2.Text + ", " + // maxcount
                textBox4.Text + ", " + // incrtime
                textBox3.Text + ", " + // ExtendedCost
                textBox5.Text + // VerifiedBuild
                "); ";

            
            MySqlCommand command = new MySqlCommand(insertQuery, connection);
            
            try
            {
                connection.Open();
                command.ExecuteNonQuery();
                label9.Visible = true;
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("ERROR: " + ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                connection.Close();
            }
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

        private void button2_Click(object sender, EventArgs e)
        {
            Clipboard.SetText($"INSERT INTO { form_MM.GetWorldDB() }.npc_vendor " +
                "(entry, slot, item, maxcount, incrtime, ExtendedCost, VerifiedBuild) " + Environment.NewLine +
                "VALUES (" +
                textBox61.Text + ", " + // entry
                textBox65.Text + ", " + // slot
                textBox1.Text + ", " + // item
                textBox2.Text + ", " + // maxcount
                textBox4.Text + ", " + // incrtime
                textBox3.Text + ", " + // ExtendedCost
                textBox5.Text + // VerifiedBuild
                ");");
            label9.Text = "Query has been copied to clipboard!";
            label9.Visible = true;
        }

        private void AddVendorItems_Load(object sender, EventArgs e)
        {
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
    }
}
