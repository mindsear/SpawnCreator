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
using System.Reflection;
using SpawnCreator.Classes;

namespace SpawnCreator
{
    public partial class MailSender : Form
    {
        //Settings frm = new Settings();
        //Connection con = new Connection();
        //Npcs npcsfrm = new Npcs();

        List<Classes.Item> items = new List<Classes.Item>();
        Form_MainMenu mainmenu = new Form_MainMenu();

        public static List<string> attitems = new List<string>();
        public static List<string> names = new List<string>();
        public static List<string> selnames = new List<string>();
        public static string npc;
        DateTime dat;

        public MailSender()
        {
            InitializeComponent();
        }

        private void MailSender_Load(object sender, EventArgs e)
        {
            items.Clear();
            Text = Assembly.GetEntryAssembly().GetName().Name.ToString();
            ckbInstant.Checked = false; ckbInstant.Checked = true;
            MailSender_Activated(null, EventArgs.Empty);
            txtStyle.SelectedIndex = 0;
            dat = dtpExp.SelectionRange.Start;
            dat = dat.AddDays(30);

            dtpExp.SelectionRange.Start = dat;



            //timer1.Start(); // Select entry, name from item_template

            MySqlConnection connection = new MySqlConnection("datasource=" + mainmenu.textbox_mysql_hostname.Text + ";port=" + mainmenu.textbox_mysql_port.Text + ";username=" + mainmenu.textbox_mysql_username.Text + ";password=" + mainmenu.textbox_mysql_pass.Text);
            string insertQuery = "SELECT name FROM " + mainmenu.textBox_mysql_charactersDB.Text + ".characters;";
            //string insertQuery = textBox_SelectMaxPlus1.Text;
            connection.Open();
            MySqlCommand command = new MySqlCommand(insertQuery, connection);

            
                //connection.Open();
                //var insertQuery = "SELECT name FROM Customers";
                //using (var command = new MySqlCommand(insertQuery, connection))
                //{
                    using (var reader = command.ExecuteReader())
                    {
                        //Iterate through the rows and add it to the combobox's items
                        while (reader.Read())
                        {
                            txtSender.Items.Add(reader.GetString("name"));
                            lstReceivers.Items.Add(reader.GetString("name"));
                        }
                    }
                //}
            

            //try
            //{

            //    MySqlDataReader reader = command.ExecuteReader();
            //    lstReceivers.Items.Clear();
            //    lstReceivers.BeginUpdate();
            //    while (reader.Read())
            //    {
            //        Classes.Item it = new Classes.Item();
            //        //it.Entry = reader.GetInt32("guid");
            //        it.Name = reader.GetString("name");
            //        items.Add(it);
            //        ListViewItem item = lstReceivers.Items.Add(it.Entry.ToString());
            //        item.SubItems.Add(it.Name);
            //    }
            //    lstSearchItems.EndUpdate();
            //    reader.Close();


            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.Message);
            //}
            //connection.Close();

            //=========================================

            //MySqlCommand cmd = new MySqlCommand("SELECT name, entry FROM world.item_template;");
            //MySqlDataReader reader = cmd.ExecuteReader();
            //lstSearchItems.Items.Clear();
            //lstSearchItems.BeginUpdate();
            //while (reader.Read())
            //{
            //    Classes.Item it = new Classes.Item();
            //    it.Entry = reader.GetInt32("entry");
            //    it.Name = reader.GetString("name");
            //    items.Add(it);
            //    ListViewItem item = lstSearchItems.Items.Add(it.Entry.ToString());
            //    item.SubItems.Add(it.Name);
            //}
            //lstSearchItems.EndUpdate();
            //reader.Close();

            //cmd = new MySqlCommand("SELECT name FROM characters.characters;");
            //reader = cmd.ExecuteReader();
            //txtSender.Items.Clear();
            //while (reader.Read())
            //{
            //    names.Add(reader.GetString("name"));
            //    txtSender.Items.Add(reader.GetString("name"));
            //}
            //reader.Close();

            //if (con.worldconn.State != ConnectionState.Open) con.worldconn.Open();
            //cmd = new MySqlCommand("SELECT `name`, `entry` FROM `creature_template`");
            //reader = cmd.ExecuteReader();
            //while (reader.Read()) Npcs.lstnpcs.Add(reader.GetString("name") + " {" + reader.GetInt32("entry").ToString() + "}");
            //reader.Close();

            //txtSender.SelectedIndex = 0;
            //txtStyle.SelectedIndex = 0;
            //if (lstSearchItems.Items.Count > 0)
            //    lstSearchItems.Items[0].Selected = true;
        }

        private void MailSender_Activated(object sender, EventArgs e)
        {
            
        }

        private void label2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            
        }
        private void txtSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                lstSearchItems.Items.Clear();
                if (txtSearch.Text == "")
                {
                    foreach (Classes.Item it in items)
                    {
                        ListViewItem item = lstSearchItems.Items.Add(it.Entry.ToString());
                        item.SubItems.Add(it.Name);
                    }
                }
                else
                {
                    foreach (Classes.Item it in items)
                    {
                        if (it.Name.Contains(txtSearch.Text))
                        {
                            ListViewItem item = lstSearchItems.Items.Add(it.Entry.ToString());
                            item.SubItems.Add(it.Name);
                        }
                    }
                }
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            MySqlConnection connection = new MySqlConnection("datasource=" + mainmenu.textbox_mysql_hostname.Text + ";port=" + mainmenu.textbox_mysql_port.Text + ";username=" + mainmenu.textbox_mysql_username.Text + ";password=" + mainmenu.textbox_mysql_pass.Text);
            string insertQuery_2 = "SELECT name, entry FROM " + mainmenu.textbox_mysql_worldDB.Text + ".item_template;";
            //string insertQuery = textBox_SelectMaxPlus1.Text;
            connection.Open();
            MySqlCommand command = new MySqlCommand(insertQuery_2, connection);

            try
            {

                MySqlDataReader reader = command.ExecuteReader();
                lstSearchItems.Items.Clear();
                lstSearchItems.BeginUpdate();
                while (reader.Read())
                {
                    Classes.Item it = new Classes.Item();
                    it.Entry = reader.GetInt32("entry");
                    it.Name = reader.GetString("name");
                    items.Add(it);
                    ListViewItem item = lstSearchItems.Items.Add(it.Entry.ToString());
                    item.SubItems.Add(it.Name);
                }
                lstSearchItems.EndUpdate();
                reader.Close();


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            connection.Close();

            timer1.Stop();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (lstSelectedItems.Items.Count >= 12) return;
            if (lstSelectedItems.Items.Count < 12)
            {
                if (lstSearchItems.SelectedItems.Count == 1)
                {
                    ListViewItem item = (ListViewItem)lstSearchItems.SelectedItems[0].Clone();
                    item.SubItems.Add(numCount.Value.ToString());
                    lstSelectedItems.Items.Add(item);
                    UpdateCapacity();
                }
                numCount.Value = 1;
            }
            if (lstSelectedItems.Items.Count < 1) { rdbMoney.Checked = true; rdbCOD.Enabled = false; }
            else rdbCOD.Enabled = true;
        }
        private void UpdateCapacity()
        {
            lblCapacity.Text = "Attached items (" + lstSelectedItems.Items.Count.ToString() + " of 12)";
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            if (lstSelectedItems.SelectedItems.Count == 1)
                lstSelectedItems.Items.RemoveAt(lstSelectedItems.SelectedItems[0].Index);

            if (lstSelectedItems.Items.Count > 0)
            {
                lstSelectedItems.Items[0].Selected = true;
                rdbMoney.Checked = true;
                rdbCOD.Enabled = false;
            }
            else
                rdbCOD.Enabled = true;
            UpdateCapacity();
        }

        private void txtStyle_SelectedIndexChanged(object sender, EventArgs e)
        {
            //textBox1.Text = Convert.ToString(txtStyle.SelectedIndex);

            if (txtStyle.SelectedIndex      == 0) textBox1.Text = "41"; // Default
            else if (txtStyle.SelectedIndex == 1) textBox1.Text = "61"; // Blizzard
            else if (txtStyle.SelectedIndex == 2) textBox1.Text = "62"; // Auction House
            else if (txtStyle.SelectedIndex == 3) textBox1.Text = "64"; // Valentine's Day
            else if (txtStyle.SelectedIndex == 4) textBox1.Text = "65"; // The Orphanage
            else if (txtStyle.SelectedIndex == 5) textBox1.Text = "1";  // Magic Scroll
        }

        class Item
        {
            public int Quantity { get; set; }
            public int Entry { get; set; }
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            
        }

        private void button_search_Click(object sender, EventArgs e)
        {

            MySqlConnection connection = new MySqlConnection("datasource=" + mainmenu.textbox_mysql_hostname.Text + ";port=" + mainmenu.textbox_mysql_port.Text + ";username=" + mainmenu.textbox_mysql_username.Text + ";password=" + mainmenu.textbox_mysql_pass.Text);
            string insertQuery = "SELECT name, entry FROM " + mainmenu.textbox_mysql_worldDB.Text + ".item_template WHERE name LIKE '%" + txtSearch.Text + "%';";
            //string insertQuery = textBox_SelectMaxPlus1.Text;
            connection.Open();
            MySqlCommand command = new MySqlCommand(insertQuery, connection);

            try
            {

                MySqlDataReader reader = command.ExecuteReader();
                lstSearchItems.Items.Clear();
                lstSearchItems.BeginUpdate();
                while (reader.Read())
                {
                    Classes.Item it = new Classes.Item();
                    it.Entry = reader.GetInt32("entry");
                    it.Name = reader.GetString("name");
                    items.Add(it);
                    ListViewItem item = lstSearchItems.Items.Add(it.Entry.ToString());
                    item.SubItems.Add(it.Name);
                }
                lstSearchItems.EndUpdate();
                reader.Close();


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            connection.Close();
        }
    }
}
