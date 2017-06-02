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
    public partial class Spawn_NPC : Form
    {
        public Spawn_NPC()
        {
            InitializeComponent();
        }

        private readonly Form_MainMenu form_MM;
        public Spawn_NPC(Form_MainMenu form_MainMenu)
        {
            InitializeComponent();
            form_MM = form_MainMenu;
        }

        MySqlConnection connection = new MySqlConnection();
        public void GetMySqlConnection()
        {
            string connStr = string.Format("Server={0};Port={1};UID={2};Pwd={3};",
                form_MM.GetHost(), form_MM.GetPort(), form_MM.GetUser(), form_MM.GetPass());

            MySqlConnection _connection = new MySqlConnection(connStr);
            connection = _connection;
        }

        private void SelectMaxPlus1()
        {
            GetMySqlConnection();

            string query = $"SELECT max(guid) + 1 FROM { form_MM.GetWorldDB() }.creature;";

            MySqlCommand _command = new MySqlCommand(query, connection);

            try
            {
                connection.Open();
                textBox61.Text = _command.ExecuteScalar().ToString();
                _command.Connection.Close();

            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message, "SpawnCreator" + form_MM.version, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ShowTeleNames()
        {
            GetMySqlConnection();
            //NPC_Creator npc = new NPC_Creator();
            //npc.GetMySqlConnection();

            string query = $"SELECT name FROM {form_MM.GetWorldDB()}.game_tele; ";

            MySqlCommand _command = new MySqlCommand(query, connection);
            try
            {
                connection.Open();

                using (MySqlDataReader dr = _command.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        listBox1.Items.Add(dr["name"].ToString());
                       // TXT_Name.Text = dr["name"].ToString();
                    }
                }
                _command.Connection.Close();
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message, "SpawnCreator", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ShowNameInfo()
        {
            GetMySqlConnection();
            //NPC_Creator npc = new NPC_Creator();
            //npc.GetMySqlConnection();

            string query = $"SELECT * FROM {form_MM.GetWorldDB()}.game_tele WHERE name=\"" + listBox1.Text + "\"; ";

            MySqlCommand _command = new MySqlCommand(query, connection);
            try
            {
                connection.Open();

                using (MySqlDataReader dr = _command.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        txtMap.Text = dr["map"].ToString();
                        txtPosX.Text = dr["position_x"].ToString();
                        txtPosY.Text = dr["position_y"].ToString();
                        txtPosZ.Text = dr["position_z"].ToString();
                        txtOrientation.Text = dr["orientation"].ToString();

                        Color c = Color.PaleGreen;
                        txtMap.BackColor = c;
                        txtPosX.BackColor = c;
                        txtPosY.BackColor = c;
                        txtPosZ.BackColor = c;
                        txtOrientation.BackColor = c;
                    }
                }
               // _command.Connection.Close();
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

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            ShowNameInfo();
        }

        private void Spawn_NPC_Load(object sender, EventArgs e)
        {
            SelectMaxPlus1();
            ShowTeleNames();
            Size = new Size(674, 442);
            CenterToScreen();
        }

        private void SearchName()
        {
            GetMySqlConnection();
            string query = $"SELECT name FROM { form_MM.GetWorldDB() }.game_tele WHERE name LIKE @name";

            try
            {
                using (MySqlCommand cmd = new MySqlCommand(query, connection))
                {
                    cmd.Parameters.Add("@name", MySqlDbType.VarChar).Value = txtSearch.Text + "%";
                    MySqlDataAdapter sda = new MySqlDataAdapter();
                    sda.SelectCommand = cmd;
                    DataTable dbdataset = new DataTable();
                    sda.Fill(dbdataset);
                    listBox1.DataSource = dbdataset;
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(this, "ERROR " + ex.Number + ": " + ex.Message, 
                    "SpawnCreator" + form_MM.version, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            // SearchName();
            FindMyString(txtSearch.Text);
        }

        private void FindMyString(string searchString)
        {
            if (searchString != string.Empty)
            {
                int index = listBox1.FindString(searchString);

                if (index != -1)
                    listBox1.SetSelected(index, true);
                else
                    //MessageBox.Show("The search string did not match any items in the ListBox");
                    return;
            }
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            if (button3.Text == ">>")
            {
                Size = new Size(890, 442); // Open/Expand panel
                button3.Text = "<<";
            }
            else if (button3.Text == "<<") 
            {
                Size = new Size(674, 442); // Close Panel
                button3.Text = ">>";
            }
           // CenterToScreen();
        }

        private void label10_Click(object sender, EventArgs e)
        {
            Process.Start("https://trinitycore.atlassian.net/wiki/display/tc/creature");
            label10.ForeColor = Color.Purple;
        }
    }
}
