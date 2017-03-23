using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Windows.Forms;

namespace SpawnCreator
{
    public static class MySql_Connect
    {
        private static MySql.Data.MySqlClient.MySqlConnection _conn;
        private static MySqlCommand _command;

        private static String ConnectionString_WorldDB
        {
            get
            {
                //Form1 frm1 = new Form1();
                if (Properties.Settings.Default.mysql_hostname == ".")
                    return String.Format("Server=localhost;Pipe={0};UserID={1};Password={2};Database={3};CharacterSet=utf8;ConnectionTimeout=5;ConnectionProtocol=Pipe;",
                        Properties.Settings.Default.mysql_port, // {0}
                        Properties.Settings.Default.mysql_username, // {1}
                        Properties.Settings.Default.mysql_pass, // {2}
                        Properties.Settings.Default.mysql_worldDB // {3}

                        //frm1.TXT_Port.Text, // {0}
                        //frm1.TXT_User.Text, // {1}
                        //frm1.TXT_Pass.Text, // {2}
                        //frm1.TXT_WorldDB.Text // {3}
                        );

                return String.Format("Server={0};Port={1};UserID={2};Password={3};Database={4};CharacterSet=utf8;ConnectionTimeout=5;",
                    Properties.Settings.Default.mysql_hostname, // {0}
                    Properties.Settings.Default.mysql_port, // {1}
                    Properties.Settings.Default.mysql_username, // {2}
                    Properties.Settings.Default.mysql_pass, // {3}
                    Properties.Settings.Default.mysql_worldDB // {4}

                    //frm1.TXT_Host.Text, // {0}
                    //frm1.TXT_Port.Text, // {1}
                    //frm1.TXT_User.Text, // {2}
                    //frm1.TXT_Pass.Text, // {3}
                    //frm1.TXT_WorldDB.Text // {4}
                    );
            }
        }

        private static String ConnectionString_CharDB
        {
            get
            {
                if (Properties.Settings.Default.mysql_hostname == ".")
                    return String.Format("Server=localhost;Pipe={0};UserID={1};Password={2};Database={3};CharacterSet=utf8;ConnectionTimeout=5;ConnectionProtocol=Pipe;",
                        Properties.Settings.Default.mysql_port, // {0}
                        Properties.Settings.Default.mysql_username, // {1}
                        Properties.Settings.Default.mysql_pass, // {2}
                        Properties.Settings.Default.mysql_charactersDB // {3}
                        );

                return String.Format("Server={0};Port={1};UserID={2};Password={3};Database={4};CharacterSet=utf8;ConnectionTimeout=5;",
                    Properties.Settings.Default.mysql_hostname, // {0}
                    Properties.Settings.Default.mysql_port, // {1}
                    Properties.Settings.Default.mysql_username, // {2}
                    Properties.Settings.Default.mysql_pass, // {3}
                    Properties.Settings.Default.mysql_charactersDB // {4}
                    );
            }
        }

        private static String ConnectionString_AuthDB
        {
            get
            {
                if (Properties.Settings.Default.mysql_hostname == ".")
                    return String.Format("Server=localhost;Pipe={0};UserID={1};Password={2};Database={3};CharacterSet=utf8;ConnectionTimeout=5;ConnectionProtocol=Pipe;",
                        Properties.Settings.Default.mysql_port, // {0}
                        Properties.Settings.Default.mysql_username, // {1}
                        Properties.Settings.Default.mysql_pass, // {2}
                        Properties.Settings.Default.mysql_authDB // {3}
                        );

                return String.Format("Server={0};Port={1};UserID={2};Password={3};Database={4};CharacterSet=utf8;ConnectionTimeout=5;",
                    Properties.Settings.Default.mysql_hostname, // {0}
                    Properties.Settings.Default.mysql_port, // {1}
                    Properties.Settings.Default.mysql_username, // {2}
                    Properties.Settings.Default.mysql_pass, // {3}
                    Properties.Settings.Default.mysql_authDB // {4}
                    );
            }
        }

        //========================================================================================================

        public static void SelectMax_WorldDB_creature_template()
        {
            string query = "SELECT max(entry) + 1 FROM creature_template;";
            NPC_Creator npc = new NPC_Creator();
            _conn = new MySql.Data.MySqlClient.MySqlConnection(ConnectionString_WorldDB);
            _command = new MySqlCommand(query, _conn);

            try
            {
                _conn.Open();
                //_command.ExecuteNonQuery();
                npc.NUD_Entry.Text = _command.ExecuteScalar().ToString();
                _command.Connection.Close();
                
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public static void InsertInto_CharDB(string query)
        {
            _conn = new MySql.Data.MySqlClient.MySqlConnection(ConnectionString_CharDB);
            _command = new MySqlCommand(query, _conn);

            try
            {
                _conn.Open();
                _command.ExecuteNonQuery();
                _command.Connection.Close();
                MessageBox.Show("Query successfully executed!", "Test MySQL Connection", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        public static void InsertInto_AuthDB(string query)
        {
            _conn = new MySql.Data.MySqlClient.MySqlConnection(ConnectionString_AuthDB);
            _command = new MySqlCommand(query, _conn);

            try
            {
                _conn.Open();
                _command.ExecuteNonQuery();
                _command.Connection.Close();
                MessageBox.Show("Query successfully executed!", "Test MySQL Connection", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }



    }
}
