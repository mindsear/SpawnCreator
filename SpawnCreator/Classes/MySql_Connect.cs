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
        
        //private MySqlConnection myConn;
        private static string conStr;

        public static string GetConnection
        {
            get
            {
                Form_MainMenu form_MM = new Form_MainMenu();
                conStr = $"Server={ form_MM.GetHost() };Port={ form_MM.GetPort() };Uid={ form_MM.GetUser() };Pwd={ form_MM.GetPass() };";
                return conStr;

            }
            //set { conStr = value; }
        }

        //========================================================================================================



    }
}
