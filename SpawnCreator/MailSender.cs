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
using System.IO;
using System.Diagnostics;

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

        public static string stringSQLShare;
        public static string stringEntryShare;

        public static string _stringSQLShare;
        public static string _stringEntryShare;

        

        int unixTimestamp = (int)(DateTime.UtcNow.Subtract(new DateTime(1970, 1, 1))).TotalSeconds;

        public MailSender()
        {
            InitializeComponent();
        }

        private readonly Form_MainMenu form_MM;
        public MailSender(Form_MainMenu form_MainMenu)
        {
            InitializeComponent();
            form_MM = form_MainMenu;
        }
        
        MySqlConnection connection = new MySqlConnection();
        public void GetMySqlConnection()
        {
            MySqlConnection _connection = new MySqlConnection(
                               "datasource = " + form_MM.GetHost() + "; " +
                               "port=" + form_MM.GetPort() + ";" +
                               "username=" + form_MM.GetUser() + ";" +
                               "password=" + form_MM.GetPass() + ";"
                            );
            connection = _connection;
        }
        

        private void SelectOnline_lblDots_Sender()
        {
            GetMySqlConnection();

            string insertQuery_3 = "select guid from " + form_MM.GetCharDB() + ".characters where name='" +
                                    comboBox_sender.Text + "'";

            connection.Open();


            MySqlCommand command_3 = new MySqlCommand(insertQuery_3, connection);
            try
            {
                textBox_sender.Text = command_3.ExecuteScalar().ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            connection.Close();

            //======================================

            string insertQuery_78 = "select online from " + form_MM.GetCharDB() + ".characters where name='" +
                                        comboBox_sender.Text + "';";
            connection.Open();

            MySqlCommand command_78 = new MySqlCommand(insertQuery_78, connection);
            try
            {

                if (comboBox_sender.Text == "")
                    return;

                textBox11.Text = command_78.ExecuteScalar().ToString();
                if (textBox11.Text == "1")
                {
                    label_dot.Visible = true;
                    label_dot.ForeColor = Color.LimeGreen;
                    toolTip1.SetToolTip(label_dot, "Online");
                }
                else
                {
                    label_dot.Visible = true;
                    label_dot.ForeColor = Color.Gray;
                    toolTip1.SetToolTip(label_dot, "Offline");
                }

            }
            catch (Exception /*ex*/)
            {
                //MessageBox.Show(ex.Message);

                // If entry does not exist in the Database
                //textBox10.Text = "0";
            }
            connection.Close();
        }

        private void SelectOnline_lblDots_Receiver()
        {
            GetMySqlConnection();

            string insertQuery_4 = "select guid from " + form_MM.GetCharDB() + ".characters where name='" +
                                    comboBox_receiver.Text + "';";

            connection.Open();


            MySqlCommand command_4 = new MySqlCommand(insertQuery_4, connection);
            try
            {
                textBox_receiver.Text = command_4.ExecuteScalar().ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            connection.Close();

            //======================================

            string insertQuery_78 = "select online from " + form_MM.GetCharDB() + ".characters where name='" +
                                        comboBox_receiver.Text + "';";
            connection.Open();

            MySqlCommand command_78 = new MySqlCommand(insertQuery_78, connection);
            try
            {

                if (comboBox_receiver.Text == "")
                    return;

                textBox12.Text = command_78.ExecuteScalar().ToString();
                if (textBox12.Text == "1")
                {
                    label_dot_receiver.Visible = true;
                    label_dot_receiver.ForeColor = Color.LimeGreen;
                    toolTip1.SetToolTip(label_dot_receiver, "Online");
                }
                else
                {
                    label_dot_receiver.Visible = true;
                    label_dot_receiver.ForeColor = Color.Gray;
                    toolTip1.SetToolTip(label_dot_receiver, "Offline");
                }

            }
            catch (Exception /*ex*/)
            {
                //MessageBox.Show(ex.Message);
            }
            connection.Close();
        }

        private void Query_FormLoad()
        {
            GetMySqlConnection();

            string insertQuery = "SELECT name FROM " + form_MM.GetCharDB() + ".characters;";

            connection.Open();
            MySqlCommand command = new MySqlCommand(insertQuery, connection);

            using (var reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    //comboBox_sender.Items.Add(reader.GetString("name"));
                    comboBox_receiver.Items.Add(reader.GetString("name"));
                }
            }

            //==========================================================================================================

            //string insertQuery_23 = "SELECT name FROM " + mainmenu.textbox_mysql_worldDB.Text + ".creature_template;";

            ////string insertQuery = textBox_SelectMaxPlus1.Text;
            //MySqlCommand command_23 = new MySqlCommand(insertQuery_23, connection);

            //using (var reader = command_23.ExecuteReader())
            //{
            //    //Iterate through the rows and add it to the combobox's items
            //    while (reader.Read())
            //    {
            //        comboBox_sender_creature.Items.Add(reader.GetString("name"));
            //    }
            //}

            //==========================================================================================================

            //string insertQuery_ = "select max(id)+1 from " + form_MM.GetCharDB() + ".mail;";
            //MySqlCommand command_ = new MySqlCommand(insertQuery_, connection);
            //try
            //{
            //    textBox2.Text = command_.ExecuteScalar().ToString();
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.Message);
            //}
            //connection.Close();

            //==========================================================================================

            //string insertQuery_2 = "select max(guid)+1 from " + form_MM.GetCharDB() + ".item_instance;";
            ////string insertQuery = textBox_SelectMaxPlus1.Text;
            //connection.Open();


            //MySqlCommand command_2 = new MySqlCommand(insertQuery_2, connection);
            //try
            //{
            //    textBox_item_guid.Text = command_2.ExecuteScalar().ToString();
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.Message);
            //}
            //connection.Close();
        }

        private void GenerateSqlCode_MailSender(object sender, EventArgs e)
        {
            long money = 0;

            string BuildSQLFile;
            BuildSQLFile = "INSERT INTO " + form_MM.GetCharDB() + ".mail ";
            BuildSQLFile += "(id, messageType, stationery, mailTemplateId, sender, receiver, subject, body, has_items, expire_time, deliver_time, money, cod, checked) ";

            BuildSQLFile += "VALUES \n";
            BuildSQLFile += "(";
            BuildSQLFile += textBox2.Text + ", "; // id
            BuildSQLFile += textBox_message_type.Text + ", "; // messageType
            BuildSQLFile += textBox1.Text + ", "; // stationery
            BuildSQLFile += /*textBox4.Text +*/ "0, "; // mailTemplateId
            //Fixed!
            BuildSQLFile += textBox_sender.Text + ", "; // sender
            BuildSQLFile += textBox_receiver.Text + ", "; // receiver
            BuildSQLFile += "\"" + txtSubject.Text + "\", "; // subject
            BuildSQLFile += "\"" + txtBody.Text + "\", "; // body
            BuildSQLFile += comboBox_has_items.Text + ", "; // has_items
            BuildSQLFile += unixTimestamp + 2550000 + ", "; // expire_time // default = 29 days
            BuildSQLFile += unixTimestamp + ", "; // deliver_time // instant

            money = Convert.ToInt64(copper.Value);
            money += Convert.ToInt64(silver.Value * 100);
            money += Convert.ToInt64(gold.Value * 10000);
            BuildSQLFile += money + ", "; // money
            BuildSQLFile += /*textBox20.Text +*/ "0, "; // cod
            BuildSQLFile += /*textBox19.Text +*/ "0"; // checked      
            BuildSQLFile += "); \n";

            //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~

            BuildSQLFile += "INSERT INTO " + form_MM.GetCharDB() + ".mail_items (mail_id, item_guid, receiver) ";
            BuildSQLFile += "VALUES \n";

            BuildSQLFile += "(";
            BuildSQLFile += textBox2.Text + ", "; // mail_id
            // select max(id)+1 from characters.mail;
            BuildSQLFile += textBox_item_guid.Text + ", "; // item_guid
            //FIXED!!
            BuildSQLFile += textBox_receiver.Text + "); \n"; // receiver

            //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~

            BuildSQLFile += "INSERT INTO " + form_MM.GetCharDB() + ".item_instance ";
            BuildSQLFile += "(guid, itemEntry, owner_guid, creatorGuid, giftCreatorGuid, count, duration, charges, flags, enchantments, randomPropertyId, durability, playedTime, text) ";

            BuildSQLFile += "VALUES \n";
            BuildSQLFile += "(";
            BuildSQLFile += textBox_item_guid.Text + ", "; // guid
            BuildSQLFile += textBox3.Text + ", "; // itemEntry
            BuildSQLFile += textBox_sender.Text + ", "; // owner_guid
            BuildSQLFile += /*textBox9.Text +*/ "0, "; // creatorGuid
            BuildSQLFile += /*textBox20.Text +*/ "0, "; // giftCreatorGuid
            BuildSQLFile += numericUpDown1.Text + ", "; // count
            BuildSQLFile += /*textBox9.Text +*/ "0, '"; // duration
            BuildSQLFile += /*textBox20.Text +*/ "0 0 0 0 0 ', "; // charges
            BuildSQLFile += /*textBox19.Text +*/ "0, '"; // flags
            BuildSQLFile += "0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0', "; // enchantments
            BuildSQLFile += /*textBox20.Text +*/ "0, "; // randomPropertyId
            if (comboBox_has_items.SelectedIndex == 1)
                BuildSQLFile += "(select MaxDurability from world.item_template where entry=" + textBox3.Text + "), ";
            else
                BuildSQLFile += textBox10.Text + ", "; // durability
            BuildSQLFile += /*textBox20.Text +*/ "0, '"; // playedTime
            BuildSQLFile += /*NULL*/ "');"; // text

            stringSQLShare = BuildSQLFile;
            stringEntryShare = txtSubject.Text;
        }

        private void GenerateSqlCode_NoMySQL(object sender, EventArgs e)
        {
            long money = 0;

            string BuildSQLFile;
            BuildSQLFile = "SET \n" +
                    "@MaxPlusOne_mail = (select max(id) + 1 from characters.mail), \n" +
                    "@MaxPlusOne_item_instance = (select max(guid) + 1 from characters.item_instance), \n" +
                    "@senderGUID = (select guid from characters.characters where name = '" + comboBox_sender.Text + "'), \n" +
                    "@receiver_GUID = (select guid from characters.characters where name = '" + comboBox_receiver.Text + "'); \n\n";

            BuildSQLFile += "INSERT INTO characters.mail ";
            BuildSQLFile += "(id, messageType, stationery, mailTemplateId, sender, receiver, subject, body, " +
                            "has_items, expire_time, deliver_time, money, cod, checked) ";

            BuildSQLFile += "VALUES \n";
            BuildSQLFile += "(";
            BuildSQLFile += "@MaxPlusOne_mail, "; // id
            BuildSQLFile += textBox_message_type.Text + ", "; // messageType
            BuildSQLFile += textBox1.Text + ", "; // stationery
            BuildSQLFile += /*textBox4.Text +*/ "0, "; // mailTemplateId
            //Fixed!
            BuildSQLFile += "@senderGUID, "; // sender
            BuildSQLFile += "@receiver_GUID, "; // receiver
            BuildSQLFile += "\"" + txtSubject.Text + "\", "; // subject
            BuildSQLFile += "\"" + txtBody.Text + "\", "; // body
            
            BuildSQLFile += comboBox_has_items.Text + ", "; // has_items
            BuildSQLFile += unixTimestamp + 2550000 + ", "; // expire_time // default = 29 days
            BuildSQLFile += unixTimestamp + ", "; // deliver_time // instant

            money = Convert.ToInt64(copper.Value);
            money += Convert.ToInt64(silver.Value * 100);
            money += Convert.ToInt64(gold.Value * 10000);
            BuildSQLFile += money + ", "; // money
            BuildSQLFile += /*textBox20.Text +*/ "0, "; // cod
            BuildSQLFile += /*textBox19.Text +*/ "0"; // checked      
            BuildSQLFile += "); \n";

            //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~

            BuildSQLFile += "INSERT INTO characters.mail_items (mail_id, item_guid, receiver) ";
            BuildSQLFile += "VALUES \n";

            BuildSQLFile += "(";
            BuildSQLFile += "@MaxPlusOne_mail, "; // mail_id
            // select max(id)+1 from characters.mail;
            BuildSQLFile += "@MaxPlusOne_item_instance, "; // item_guid
            //FIXED!!
            BuildSQLFile += "@receiver_GUID); \n"; // receiver

            //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~

            BuildSQLFile += "INSERT INTO characters.item_instance ";
            BuildSQLFile += "(guid, itemEntry, owner_guid, creatorGuid, giftCreatorGuid, count, duration, " +
                            "charges, flags, enchantments, randomPropertyId, durability, playedTime, text) ";

            BuildSQLFile += "VALUES \n";
            BuildSQLFile += "(";
            BuildSQLFile += "@MaxPlusOne_item_instance, "; // guid
            BuildSQLFile += textBox3.Text + ", "; // itemEntry
            BuildSQLFile += "@senderGUID, "; // owner_guid
            BuildSQLFile += /*textBox9.Text +*/ "0, "; // creatorGuid
            BuildSQLFile += /*textBox20.Text +*/ "0, "; // giftCreatorGuid
            BuildSQLFile += numericUpDown1.Text + ", "; // count
            BuildSQLFile += /*textBox9.Text +*/ "0, '"; // duration
            BuildSQLFile += /*textBox20.Text +*/ "0 0 0 0 0 ', "; // charges
            BuildSQLFile += /*textBox19.Text +*/ "0, '"; // flags
            BuildSQLFile += "0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0', "; // enchantments
            BuildSQLFile += /*textBox20.Text +*/ "0, "; // randomPropertyId
            if(comboBox_has_items.SelectedIndex == 1)
                BuildSQLFile += "(select MaxDurability from world.item_template where entry=" + textBox3.Text + "), ";
            else
                BuildSQLFile += textBox10.Text + ", "; // durability
            BuildSQLFile += /*textBox20.Text +*/ "0, '"; // playedTime
            BuildSQLFile += /*NULL*/ "');"; // text

            _stringSQLShare = BuildSQLFile;
            _stringEntryShare = txtSubject.Text;
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
            comboBox_has_items.SelectedIndex = 0; // default 0 (mail has NO Item)
            comboBox_message_type.SelectedIndex = 0; // Normal
            comboBox_select_sender.SelectedIndex = 0; // Sender = Player

            timer9.Start(); //Stopwatch
            if (form_MM.CB_NoMySQL.Checked)
            {
                timer10.Enabled = false; // Check if MySQL is running
                label_mysql_status2.Visible = false;
                label85.Visible = false;
                timer2.Enabled = false; //Refresh Mail ID, item_instance textBox
                btnSend.Visible = false; // Execute Query
                comboBox_sender.DropDownStyle = ComboBoxStyle.DropDown;
                comboBox_receiver.DropDownStyle = ComboBoxStyle.DropDown;
                label6.Enabled = false; // Item Search label
                txtSearch.Enabled = false; // Item Search textbox
                button_search.Enabled = false; // Item Search button
                label19.Enabled = false; // npc search label
                textBox_search_npc.Enabled = false;
                button_search_npc.Enabled = false;
                textBox_sender.Visible = true;

                //label20.Visible = true;
                //label20.Text = "Sender (Character GUID)";
                //textBox_receiver.Visible = true;
                //label9.Text = "Receiver (Character GUID)";
                comboBox_receiver.Visible = true;
                comboBox_sender.Visible = true;
                comboBox_sender.DropDownStyle = ComboBoxStyle.Simple;
                comboBox_receiver.DropDownStyle = ComboBoxStyle.Simple;
                //label8.Visible = false; 
                comboBox_select_sender.Visible = false;
                label17.Visible = false;
                textBox_sender.Visible = false;
                //label13.Visible = true;
                //comboBox_has_items.Visible = true;
                //label25.Visible = true; // MaxDurability
                //textBox10.Visible = true;
                //textBox2.Text = "@MaxPlusOne_mail";
                //textBox_item_guid.Text = "@MaxPlusOne_item_instance";
                groupBox4.Size = new Size(660, 222);
            }
            else
            {
                timer10.Enabled = true; // Check if MySQL is running
                timer2.Enabled = true; //Refresh Mail ID textBox
                btnSend.Visible = true; // Execute Query
                comboBox_sender.DropDownStyle = ComboBoxStyle.DropDownList;
                comboBox_receiver.DropDownStyle = ComboBoxStyle.DropDownList;
                Query_FormLoad();
            }
       
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
            //if (e.KeyCode == Keys.Enter)
            //{
            //    lstSearchItems.Items.Clear();
            //    if (txtSearch.Text == "")
            //    {
            //        foreach (Classes.Item it in items)
            //        {
            //            ListViewItem item = lstSearchItems.Items.Add(it.Entry.ToString());
            //            item.SubItems.Add(it.Name);
            //        }
            //    }
            //    else
            //    {
            //        foreach (Classes.Item it in items)
            //        {
            //            if (it.Name.Contains(txtSearch.Text))
            //            {
            //                ListViewItem item = lstSearchItems.Items.Add(it.Entry.ToString());
            //                item.SubItems.Add(it.Name);
            //            }
            //        }
            //    }
            //}
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            GetMySqlConnection();

            string insertQuery_190 = "select online from " + form_MM.GetCharDB() + ".characters where name='" +
                                        comboBox_receiver.Text + "';";
            connection.Open();

            MySqlCommand command_190 = new MySqlCommand(insertQuery_190, connection);
            try
            {

                if (comboBox_receiver.Text == "")
                    return;

                textBox12.Text = command_190.ExecuteScalar().ToString();
                if (textBox12.Text == "1")
                {
                    label_dot_receiver.Visible = true;
                    label_dot_receiver.ForeColor = Color.LimeGreen;
                    toolTip1.SetToolTip(label_dot_receiver, "Online");
                }
                else
                {
                    label_dot_receiver.Visible = true;
                    label_dot_receiver.ForeColor = Color.Gray;
                    toolTip1.SetToolTip(label_dot_receiver, "Offline");
                }

            }
            catch (Exception /*ex*/)
            {
                //MessageBox.Show(ex.Message);
            }
            connection.Close();

            ///====================================================================

            string insertQuery_78 = "select online from " + form_MM.GetCharDB() + ".characters where name='" +
                                        comboBox_sender.Text + "';";
            connection.Open();

            MySqlCommand command_78 = new MySqlCommand(insertQuery_78, connection);
            try
            {

                if (comboBox_sender.Text == "")
                    return;

                textBox11.Text = command_78.ExecuteScalar().ToString();
                if (textBox11.Text == "1")
                {
                    label_dot.Visible = true;
                    label_dot.ForeColor = Color.LimeGreen;
                    toolTip1.SetToolTip(label_dot, "Online");
                }
                else
                {
                    label_dot.Visible = true;
                    label_dot.ForeColor = Color.Gray;
                    toolTip1.SetToolTip(label_dot, "Offline");
                }

            }
            catch (Exception /*ex*/)
            {
                //MessageBox.Show(ex.Message);

                // If entry does not exist in the Database
                //textBox10.Text = "0";
            }
            connection.Close();


            //MySqlConnection connection = new MySqlConnection("datasource=" + mainmenu.textbox_mysql_hostname.Text + ";port=" + mainmenu.textbox_mysql_port.Text + ";username=" + mainmenu.textbox_mysql_username.Text + ";password=" + mainmenu.textbox_mysql_pass.Text);
            //string insertQuery_2 = "SELECT name, entry FROM " + mainmenu.textbox_mysql_worldDB.Text + ".item_template;";
            ////string insertQuery = textBox_SelectMaxPlus1.Text;
            //connection.Open();
            //MySqlCommand command = new MySqlCommand(insertQuery_2, connection);

            //try
            //{

            //    MySqlDataReader reader = command.ExecuteReader();
            //    lstSearchItems.Items.Clear();
            //    lstSearchItems.BeginUpdate();
            //    while (reader.Read())
            //    {
            //        Classes.Item it = new Classes.Item();
            //        it.Entry = reader.GetInt32("entry");
            //        it.Name = reader.GetString("name");
            //        items.Add(it);
            //        ListViewItem item = lstSearchItems.Items.Add(it.Entry.ToString());
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

            //timer1.Stop();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            //if (lstSelectedItems.Items.Count >= 12) return;
            //if (lstSelectedItems.Items.Count < 12)
            //{
            //    if (lstSearchItems.SelectedItems.Count == 1)
            //    {
            //        ListViewItem item = (ListViewItem)lstSearchItems.SelectedItems[0].Clone();
            //        item.SubItems.Add(numCount.Value.ToString());
            //        lstSelectedItems.Items.Add(item);
            //        UpdateCapacity();
            //    }
            //    numCount.Value = 1;
            //}
            //if (lstSelectedItems.Items.Count < 1) { rdbMoney.Checked = true; rdbCOD.Enabled = false; }
            //else rdbCOD.Enabled = true;
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

        // Send Mail - Execute Query
        private void btnSend_Click(object sender, EventArgs e)
        {
            GenerateSqlCode_MailSender(sender, e);

            //if Npc Entry = Empty
            if (textBox_sender.Text == "")
            {
                MessageBox.Show("NPC Entry or Player should not be empty", "Error!");
                return;
            }
            if (textBox_sender.Text == "0")
            {
                MessageBox.Show("NPC Entry should not be 0 (zero)", "Error!");
                return;
            }
            if (textBox_receiver.Text == "")
            {
                MessageBox.Show("Please select a Receiver!", "Error!");
                return;
            }

            GetMySqlConnection();

            string insertQuery = stringSQLShare;
            connection.Open();
            MySqlCommand command = new MySqlCommand(insertQuery, connection);

            //command.Parameters.AddWithValue("", )

            try
            {
                if (command.ExecuteNonQuery() >= 1)
                {
                    timer3.Start();
                }

                //if (textBox12.Text == "1")
                //{
                //    label27.Visible = true;
                //    label27.Text = "Relog " + comboBox_receiver.Text + " so you can see the mail.";
                //}
                //else if (textBox12.Text == "0")
                //{
                //    label27.Visible = false;
                //}

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            connection.Close();
        }

        private void button_search_Click(object sender, EventArgs e)
        {

            
        }


        //Copy to Clipboard - Button
        private void label86_Click(object sender, EventArgs e)
        {
            if (form_MM.CB_NoMySQL.Checked)
            {
                GenerateSqlCode_NoMySQL(sender, e);

                if(comboBox_sender.Text == "")
                {
                    MessageBox.Show("Sender (Player Name) should not be empty", "Error!");
                    return;
                }
                if (comboBox_sender.Text == "0")
                {
                    MessageBox.Show("Sender (Player Name) should not be 0", "Error!");
                    return;
                }
                if (comboBox_receiver.Text == "")
                {
                    MessageBox.Show("Receiver (Player Name) should not be empty", "Error!");
                    return;
                }
                if (comboBox_receiver.Text == "0")
                {
                    MessageBox.Show("Receiver (Player Name) should not be 0", "Error!");
                    return;
                }

                Clipboard.SetText(_stringSQLShare);
            }
                
            else
            {
                GenerateSqlCode_MailSender(sender, e);

                if (textBox_sender.Text == "")
                {
                    MessageBox.Show("Sender (NPC Entry or Player Name) should not be empty", "Error!");
                    return;
                }
                if (textBox_sender.Text == "0")
                {
                    MessageBox.Show("NPC Entry should not be 0 (zero)", "Error!");
                    return;
                }
                if (textBox_receiver.Text == "")
                {
                    MessageBox.Show("Please select a Receiver!", "Error!");
                    return;
                }
                Clipboard.SetText(stringSQLShare);
            }
            
            timer5.Start();
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            comboBox_has_items.SelectedIndex = 1; // Mail Has Item

            if (textBox3.Text == "") comboBox_has_items.SelectedIndex = 0;
            else if (textBox3.Text == "0") comboBox_has_items.SelectedIndex = 0;

            
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            GetMySqlConnection();

            //Refresh max(guid)+1 from item_instance
            string insertQuery_2 = "select max(guid)+1 from " + form_MM.GetCharDB() + ".item_instance;";
            //string insertQuery = textBox_SelectMaxPlus1.Text;
            connection.Open();


            MySqlCommand command_2 = new MySqlCommand(insertQuery_2, connection);
            try
            {
                textBox_item_guid.Text = command_2.ExecuteScalar().ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            //connection.Close();


            ////===============================================================================================

            //Refresh max (Mail ID) + 1 
            string _insertQuery = "select max(id)+1 from " + form_MM.GetCharDB() + ".mail;";
            //string insertQuery = textBox_SelectMaxPlus1.Text;
            //connection.Open();


            MySqlCommand _command = new MySqlCommand(_insertQuery, connection);
            try
            {
                // Mail ID
                textBox2.Text = _command.ExecuteScalar().ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            //connection.Close();

            //========================================================================================================

            //select MaxDurability from world.item_template where entry=textBox3.text;

            //string insertQuery_3 = "select MaxDurability from " + mainmenu.textbox_mysql_worldDB.Text + ".item_template where entry=" +
            //                        textBox3.Text + ";";
            ////connection.Open();

            //MySqlCommand command_3 = new MySqlCommand(insertQuery_3, connection);
            //try
            //{

            //    if (textBox3.Text == "" || textBox3.Text == "0")
            //    {
            //        textBox10.Text = "0";
            //        return;
            //    }     

            //    textBox10.Text = command_3.ExecuteScalar().ToString();
            //}
            //catch (Exception /*ex*/)
            //{
            //    //MessageBox.Show(ex.Message);

            //    // If entry does not exist in the Database
            //    textBox10.Text = "0";
            //}
            //connection.Close();

        }

        //     comboBox_sender
        private void txtSender_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (label_mysql_status2.Text == "Connection Lost - MySQL is not running")
                return;

            else
                SelectOnline_lblDots_Sender();
        }

        private void comboBox_receiver_SelectedIndexChanged(object sender, EventArgs e)
        {
            label27.Visible = false;


            if (label_mysql_status2.Text == "Connection Lost - MySQL is not running")
                return;
            else
                SelectOnline_lblDots_Receiver();

        }

        private void txtBody_TextChanged(object sender, EventArgs e)
        {
            //if (txtBody.Text == "'") txtBody.Text = "\'";
        }

        private void comboBox_message_type_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (comboBox_message_type.SelectedIndex)
            {
                case 0:
                    textBox_message_type.Text = "0";
                    break;
                case 1:
                    textBox_message_type.Text = "2";
                    break;
                case 2:
                    textBox_message_type.Text = "3";
                    break;
                case 3:
                    textBox_message_type.Text = "4";
                    break;
                case 4:
                    textBox_message_type.Text = "5";
                    break;
            }
        }

        private void Query_ComboboxSender()
        {
            GetMySqlConnection();

            string insertQuery = "SELECT name FROM " + form_MM.GetCharDB() + ".characters;";

            connection.Open();
            MySqlCommand command = new MySqlCommand(insertQuery, connection);

            using (var reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    comboBox_sender.Items.Add(reader.GetString("name"));
                }
            }
        }

        // comboBox Select Sender
        private void comboBox_sender_creature_SelectedIndexChanged(object sender, EventArgs e)
        {     
            switch (comboBox_select_sender.SelectedIndex)
            {
                case 0: // Select Sender = Player
                    label8.Visible = true;
                    comboBox_sender.Visible = true;
                    textBox_sender.Clear();
                    label20.Visible = false;
                    textBox_sender.Visible = false;
                    comboBox_message_type.SelectedIndex = 0; // Message Type 0 = Normal (player)
                    comboBox_sender.Items.Clear();
                    label19.Visible = false;
                    textBox_search_npc.Visible = false;
                    button_search_npc.Visible = false;
                    dataGridView1.Visible = false;

                    if (form_MM.CB_NoMySQL.Checked || label_mysql_status2.Text == "Connection Lost - MySQL is not running")
                        return;
                    else
                        Query_ComboboxSender();
                    break;

                case 1: // Select Sender = NPC
                    label_dot.Visible = false;
                    label20.Visible = true;
                    textBox_sender.Visible = true;
                    //comboBox_receiver.Location = new Point(218, 306);
                    //label9.Location = new Point(226, 286);
                    label8.Visible = false;
                    comboBox_sender.Visible = false;
                    comboBox_message_type.SelectedIndex = 2; // Message Type 3 = Creature
                    textBox_sender.Clear();
                    label19.Visible = true;
                    textBox_search_npc.Visible = true;
                    button_search_npc.Visible = true;
                    dataGridView1.Visible = true;
                    break;
            }
        }

        private void SearchNPC()
        {
            string constring = "datasource=" + form_MM.GetHost() + ";" +
                               "port=" + form_MM.GetPort() + ";" +
                               "username=" + form_MM.GetUser() + ";" +
                               "password=" + form_MM.GetPass() + ";"
                                ;

            MySqlConnection conDataBase = new MySqlConnection(constring);

            MySqlCommand com = new MySqlCommand("SELECT entry,name from " + form_MM.GetWorldDB() + ".creature_template WHERE name LIKE \"" + textBox_search_npc.Text + "\";", conDataBase);

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
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        // Search NPC
        private void button1_Click(object sender, EventArgs e)
        {
            if (label_mysql_status2.Text == "Connection Lost - MySQL is not running")
                return;

            else
                SearchNPC();
        }

        // Allow only Numbers
        private void textBox_sender_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void pictureBox5_Paint(object sender, PaintEventArgs e)
        {
            //using (Font myFont = new Font("Arial", 9))
            //{
            //    e.Graphics.DrawString(txtBody.Text, myFont, Brushes.Black, new Point(1, 1));
            //}

        }

        decimal recentVal = 0;
        private void silver_KeyUp(object sender, KeyEventArgs e)
        {
           // printChars(silver.Value);

            if (silver.Value > silver.Maximum)
            {
                silver.Value = silver.Maximum;
                
            }
            recentVal = silver.Value;
        }

        private void silver_ValueChanged(object sender, EventArgs e)
        {
            //if (silver.Value > silver.Maximum)
            //{
            //    silver.Value = silver.Maximum;
            //}
            //System.Diagnostics.Debug.WriteLine("~~~ silver_ValueChanged");
        }

        private void silver_MouseUp(object sender, MouseEventArgs e)
        {
            //if (silver.Value > silver.Maximum)
            //{
            //    silver.Value = silver.Maximum;
            //}
            //System.Diagnostics.Debug.WriteLine("~~~ silver_MouseUp");
        }
        
        private void silver_KeyDown(object sender, KeyEventArgs e)
        {

        }

        decimal recentVal2 = 0;
        private void copper_KeyUp(object sender, KeyEventArgs e)
        {
            if (copper.Value > copper.Maximum)
            {
                copper.Value = copper.Maximum;

            }
            recentVal2 = copper.Value;
        }

        decimal recentVal3 = 0;
        private void gold_KeyUp(object sender, KeyEventArgs e)
        {
            if (gold.Value > gold.Maximum)
            {
                gold.Value = gold.Maximum;

            }
            recentVal3 = gold.Value;
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        // Save as .sql
        private void label83_Click(object sender, EventArgs e)
        {
            if (form_MM.CB_NoMySQL.Checked)
            {
                GenerateSqlCode_NoMySQL(sender, e);

                if (comboBox_sender.Text == "")
                {
                    MessageBox.Show("Sender (Player Name) should not be empty", "Error!");
                    return;
                }
                if (comboBox_sender.Text == "0")
                {
                    MessageBox.Show("Sender (Player Name) should not be 0", "Error!");
                    return;
                }
                if (comboBox_receiver.Text == "")
                {
                    MessageBox.Show("Receiver (Player Name) should not be empty", "Error!");
                    return;
                }
                if (comboBox_receiver.Text == "0")
                {
                    MessageBox.Show("Receiver (Player Name) should not be 0", "Error!");
                    return;
                }

                using (var sfd = new SaveFileDialog())
                {
                    sfd.Filter = "sql files (*.sql)|*.sql";
                    sfd.FilterIndex = 2;
                    sfd.FileName = "Mail_To_" + comboBox_receiver.Text;

                    if (sfd.ShowDialog() == DialogResult.OK)
                    { 
                        File.WriteAllText(sfd.FileName, _stringSQLShare);
                        timer7.Start();
                        //label88.Visible = true;
                    }
                }
            }
            else
            {
                GenerateSqlCode_MailSender(sender, e);

                //if Npc Entry = Empty
                if (textBox_sender.Text == "")
                {
                    MessageBox.Show("Sender (NPC Entry or Player Name) should not be empty!", "Error!");
                    return;
                }
                if (textBox_sender.Text == "0")
                {
                    MessageBox.Show("NPC Entry should not be 0 (zero)", "Error!");
                    return;
                }
                if (textBox_receiver.Text == "")
                {
                    MessageBox.Show("Please select a Receiver!", "Error!");
                    return;
                }

                using (var sfd = new SaveFileDialog())
                {
                    sfd.Filter = "sql files (*.sql)|*.sql";
                    sfd.FilterIndex = 2;
                    sfd.FileName = "Mail_To_" + comboBox_receiver.Text;

                    if (sfd.ShowDialog() == DialogResult.OK)
                    {
                        File.WriteAllText(sfd.FileName, stringSQLShare);
                        timer7.Start();
                        //label88.Visible = true;
                    }
                }
            }
            
        }

        private void SearchItem()
        {
            GetMySqlConnection();

            string insertQuery = "SELECT entry,name FROM " + form_MM.GetWorldDB() + ".item_template WHERE name LIKE \"%" + txtSearch.Text + "%\";";
            connection.Open();
            MySqlCommand command = new MySqlCommand(insertQuery, connection);

            try
            {
                MySqlDataAdapter sda = new MySqlDataAdapter();
                sda.SelectCommand = command;
                DataTable dbdataset = new DataTable();
                sda.Fill(dbdataset);
                BindingSource bsource = new BindingSource();

                bsource.DataSource = dbdataset;
                dataGridView2.DataSource = bsource;
                sda.Update(dbdataset);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            connection.Close();
        }

        // Item Search BUTTON
        private void button_search_Click_1(object sender, EventArgs e)
        {
            if (label_mysql_status2.Text == "Connection Lost - MySQL is not running")
                return;

            else
                SearchItem();
        }

        private void txtSearch_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private bool mouseDown;
        private Point lastLocation;

        private void panel2_MouseUp(object sender, MouseEventArgs e)
        {
            mouseDown = false;
        }

        private void panel2_MouseMove(object sender, MouseEventArgs e)
        {
            if (mouseDown)
            {
                Location = new Point(
                    (Location.X - lastLocation.X) + e.X, (Location.Y - lastLocation.Y) + e.Y);

                Update();
            }
        }

        private void panel2_MouseDown(object sender, MouseEventArgs e)
        {
            mouseDown = true;
            lastLocation = e.Location;
        }

        private void label78_Click(object sender, EventArgs e)
        {
            Close();
            BackToMainMenu backtomainmenu = new BackToMainMenu(form_MM);
            backtomainmenu.Show();
        }

        private void label2_MouseEnter(object sender, EventArgs e)
        {
            label2.BackColor = Color.Firebrick;
        }

        private void label2_MouseLeave(object sender, EventArgs e)
        {
            label2.BackColor = Color.FromArgb(58, 89, 114);
        }
        //============================================================
        private void label1_MouseEnter(object sender, EventArgs e)
        {
            label1.BackColor = Color.Firebrick;
        }

        private void label1_MouseLeave(object sender, EventArgs e)
        {
            label1.BackColor = Color.FromArgb(58, 89, 114);
        }
        //============================================================
        private void label78_MouseEnter(object sender, EventArgs e)
        {
            label78.BackColor = Color.Firebrick;
        }

        private void label78_MouseLeave(object sender, EventArgs e)
        {
            label78.BackColor = Color.FromArgb(58, 89, 114);
        }

        private void panel5_MouseEnter(object sender, EventArgs e)
        {
            panel5.BackColor = Color.Firebrick;
        }

        private void panel5_MouseLeave(object sender, EventArgs e)
        {
            panel5.BackColor = Color.FromArgb(58, 89, 114);
        }

        private void label83_MouseEnter(object sender, EventArgs e)
        {
            panel5.BackColor = Color.Firebrick;
        }

        private void label83_MouseLeave(object sender, EventArgs e)
        {
            panel5.BackColor = Color.FromArgb(58, 89, 114);
        }

        private void panel7_MouseEnter(object sender, EventArgs e)
        {
            panel7.BackColor = Color.Firebrick;
        }

        private void panel7_MouseLeave(object sender, EventArgs e)
        {
            panel7.BackColor = Color.FromArgb(58, 89, 114);
        }

        private void label86_MouseEnter(object sender, EventArgs e)
        {
            panel7.BackColor = Color.Firebrick;
        }

        private void label86_MouseLeave(object sender, EventArgs e)
        {
            panel7.BackColor = Color.FromArgb(58, 89, 114);
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("http://emucraft.com");
        }

        private void timer3_Tick(object sender, EventArgs e)
        {
            label_mail_sent.Visible = true;
            timer3.Stop();

            timer4.Start();
        }

        private void timer4_Tick(object sender, EventArgs e)
        {
            label_mail_sent.Visible = false;
            timer4.Stop();
        }

        private void timer5_Tick(object sender, EventArgs e)
        {
            //Query has been copied to clipboard!
            label87.Visible = true;
            timer5.Stop();

            timer6.Start();
        }

        private void timer6_Tick(object sender, EventArgs e)
        {
            label87.Visible = false;
            timer6.Stop();
        }

        private void timer7_Tick(object sender, EventArgs e)
        {
            // File has been saved successfully!
            label88.Visible = true;
            timer7.Stop();

            timer8.Start();
        }

        private void timer8_Tick(object sender, EventArgs e)
        {
            label88.Visible = false;
            timer8.Stop();
        }

        //          Item Entry
        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        int i = 1;
        DateTime dt = new DateTime();
        private void timer9_Tick(object sender, EventArgs e)
        {
            label_stopwatch.Text = dt.AddSeconds(i).ToString("HH:mm:ss");
            i++;
        }

        private void btnSend_MouseEnter(object sender, EventArgs e)
        {
            btnSend.BackColor = Color.Green;
        }

        private void btnSend_MouseLeave(object sender, EventArgs e)
        {
            btnSend.BackColor = Color.DimGray;
        }

        public bool IsProcessOpen(string name = "mysqld")
        {
            foreach (Process clsProcess in Process.GetProcesses())
            {
                if (clsProcess.ProcessName.Contains(name))
                {
                    label_mysql_status2.Text = "Connected!";
                    label_mysql_status2.ForeColor = Color.LawnGreen;
                    btnSend.Visible = true;
                    timer2.Enabled = true; //Refresh Mail ID, item_instance textBox
                    return true;
                }
            }

            label_mysql_status2.Text = "Connection Lost - MySQL is not running";
            label_mysql_status2.ForeColor = Color.Red;
            btnSend.Visible = false;
            label_dot.Visible = false;
            label_dot_receiver.Visible = false;
            timer2.Enabled = false; //Refresh Mail ID, item_instance textBox
            return false;
        }

        private void timer10_Tick(object sender, EventArgs e)
        {
            IsProcessOpen();
        }

        private void groupBox4_Enter(object sender, EventArgs e)
        {

        }
    }
}
