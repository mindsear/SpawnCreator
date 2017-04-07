using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Windows.Forms;
using System.Data;
using System.Drawing;

namespace SpawnCreator
{
    public class MySql_Connect
    {
        //private static MySqlConnection _conn;
        //private static MySqlCommand _command;
        Form_MainMenu form_MM = new Form_MainMenu();

        public static string ConnectionString
        {
            get
            {
                Form_MainMenu form_MM = new Form_MainMenu();
                return string.Format("Server={0};Port={1};Uid={2};Pwd={3};CharacterSet=utf8;ConnectionTimeout=5;",
                                    form_MM.GetHost(), form_MM.GetPort(), form_MM.GetUser(), form_MM.GetPass() );
            }
        }

        
        //========================================================================================================




    }
}
