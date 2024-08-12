using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1
{
    internal class Database
    {
        private static string connectString = "server=localhost;user=root;database=cs_dev;port=3306;password=admin";
        public static MySqlConnection GetConnection()
        {
            return new MySqlConnection(connectString);
        }
    }
}
