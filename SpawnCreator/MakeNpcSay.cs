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
    public partial class MakeNpcSay : Form
    {
        public MakeNpcSay()
        {
            InitializeComponent();
        }

        private readonly Form_MainMenu form_MM;
        public MakeNpcSay(Form_MainMenu _form_MainMenu)
        {
            InitializeComponent();
            form_MM = _form_MainMenu; 
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            textBox4.Text = comboBox1.Text;

            if      (comboBox1.Text == "Say") textBox4.Text          = "12";
            else if (comboBox1.Text == "Yell") textBox4.Text         = "14";
            else if (comboBox1.Text == "Emote") textBox4.Text        = "16";
            else if (comboBox1.Text == "Boss Emote") textBox4.Text   = "41";
            else if (comboBox1.Text == "Whisper") textBox4.Text      = "15";
            else if (comboBox1.Text == "Boss Whisper") textBox4.Text = "42";
        }

        private void textBox11_TextChanged(object sender, EventArgs e)
        {
            label9.Visible = false;
            textBox5.Text = textBox11.Text;
            textBox18.Text = textBox11.Text;
            textBox17.Text = textBox11.Text;
        }

        private void label10_Click(object sender, EventArgs e)
        {
            Process.Start("https://trinitycore.atlassian.net/wiki/display/tc/creature_text");
        }

        private void label5_Click(object sender, EventArgs e)
        {
            Process.Start("https://trinitycore.atlassian.net/wiki/display/tc/smart_scripts");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form_MainMenu mainmenu = new Form_MainMenu();


            if (textBox2.Text == "")
            {
                MessageBox.Show("Text should not be empty", "Error");
                return;
            }
           

            MySqlConnection connection = new MySqlConnection(
                "datasource=" + form_MM.GetHost() + ";" +
                "port=" + form_MM.GetPort() + ";" +
                "username=" + form_MM.GetUser() + ";" +
                "password=" + form_MM.GetPass() + ";"
                );

            string insertQuery = "INSERT INTO " + form_MM.GetWorldDB() + ".creature_text " +
                "(entry, text, type, probability, language) " +
                "VALUES (" +
                textBox61.Text + ", '" + // entry
                textBox2.Text + "', " + // text
                textBox4.Text + ", " + // type
                textBox10.Text + ", " + // probability
                textBox1.Text + ");" + // language

                "INSERT INTO " + form_MM.GetWorldDB() + ".smart_scripts " +
                "(entryorguid, event_type, action_type, event_chance, event_param1, event_param2, event_param3, event_param4) " +
                "VALUES (" +
                textBox61.Text + ", " + // entryorguid
                textBox20.Text + ", " + // event_type
                textBox16.Text + ", " + // action_type
                textBox23.Text + ", " + // event_chance
                textBox11.Text + ", " + // event_param1
                textBox5.Text + ", " + // event_param2
                textBox18.Text + ", " + // event_param3
                textBox17.Text + ");" // event_param4
                ;
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

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            label9.Visible = false;
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            label9.Visible = false;
        }

        private void textBox10_TextChanged(object sender, EventArgs e)
        {
            label9.Visible = false;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            label9.Visible = false;
        }

        private void textBox20_TextChanged(object sender, EventArgs e)
        {
            label9.Visible = false;
        }

        private void textBox16_TextChanged(object sender, EventArgs e)
        {
            label9.Visible = false;
        }

        private void textBox23_TextChanged(object sender, EventArgs e)
        {
            label9.Visible = false;
        }

        private void MakeNpcSay_Load(object sender, EventArgs e)
        {
            comboBox1.SelectedIndex = 0; //default - Say
        }
    }
}
