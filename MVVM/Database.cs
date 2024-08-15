using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp1.MVVM;

namespace WpfApp1
{
    internal class Database
    {
        private static string connectString = "server=localhost;user=root;database=cs_dev;port=3306;password=admin";
        public static MySqlConnection GetConnection() => new(connectString);
        public static List<T> Query<T>(string query, Func<MySqlDataReader, T> func)
        {
            MySqlConnection conn = GetConnection();
            try
            {
                conn.Open();
                List<T> result = [];
                MySqlDataReader reader = new MySqlCommand(query, conn).ExecuteReader();

                while (reader.Read()) result.Add(func(reader));
                conn.Close();

                return result;
            }
            catch (Exception e) { Console.WriteLine(e); }
            return [];
        }
        public static void Query(string query)
        {
            MySqlConnection conn = GetConnection();
            try
            {
                conn.Open();
                new MySqlCommand(query, conn).ExecuteNonQuery();
                conn.Close();
            }
            catch (Exception e) { Console.WriteLine(e); }
        }
    }
}
