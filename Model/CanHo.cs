using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.RightsManagement;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1.Model
{
    internal class CanHo
    {
        public static void Add(CanHo ch)
        {
            MySqlConnection conn = Database.GetConnection();
            try
            {
                conn.Open();
                MySqlCommand command = new("INSERT INTO canho (id, tenCanHo, tang, dienTich) VALUES (@id, @ten, @tang, @dt);", conn);
                command.Parameters.AddWithValue("@id", ch.IdCanHo);
                command.Parameters.AddWithValue("@ten", ch.TenCanHo);
                command.Parameters.AddWithValue("@tang", ch.Tang);
                command.Parameters.AddWithValue("@dt", ch.DienTich);

                command.ExecuteNonQuery();
                conn.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }

        public static void Edit(CanHo ch)
        {
            MySqlConnection conn = Database.GetConnection();
            try
            {
                conn.Open();
                MySqlCommand command = new("UPDATE canho SET tenCanHo = @ten, tang = @tang, dienTich = @dt WHERE id = @id;", conn);
                command.Parameters.AddWithValue("@ten", ch.TenCanHo);
                command.Parameters.AddWithValue("@tang", ch.Tang);
                command.Parameters.AddWithValue("@id", ch.IdCanHo);
                command.Parameters.AddWithValue("@dt", ch.DienTich);

                command.ExecuteNonQuery();
                conn.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }

        public static void Delete(CanHo ch)
        {
            MySqlConnection connection = Database.GetConnection();
            try
            {
                connection.Open();
                MySqlCommand cmd = new("DELETE FROM canho WHERE id = @id", connection);
                cmd.Parameters.AddWithValue("@id", ch.IdCanHo);
                cmd.ExecuteNonQuery();
                connection.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }

        }
        public static void Delete(string id)
        {
            MySqlConnection connection = Database.GetConnection();

            connection.Open();
            MySqlCommand cmd = new("DELETE FROM canho WHERE id = @id", connection);
            cmd.Parameters.AddWithValue("@id", id);

            cmd.ExecuteNonQuery();
            connection.Close();
        }
        public static List<CanHo> Read()
        {
            List<CanHo> ch = [];
            MySqlConnection conn = Database.GetConnection();

            conn.Open();
            MySqlDataReader data = new MySqlCommand("SELECT * FROM canho ORDER BY tang ASC, tenCanHo ASC", conn).ExecuteReader();

            while (data.Read()) ch.Add(new CanHo($"{data["id"]}", (string)data["tenCanHo"], (uint)data["tang"], (double)data["dienTich"]));
            conn.Close();

            return ch;
        }
        public static List<CanHo> FindItem(string str)
        {
            if (string.IsNullOrEmpty(str)) return Read();

            List<CanHo> ch = [];
            MySqlConnection conn = Database.GetConnection();

            conn.Open();
            MySqlCommand cmd = new("SELECT * FROM canho WHERE tenCanHo LIKE @str ORDER BY tang ASC, tenCanHo ASC", conn);
            cmd.Parameters.AddWithValue("@str", $"%{str}%");

            MySqlDataReader data = cmd.ExecuteReader();
            while (data.Read()) ch.Add(new CanHo($"{data["id"]}", (string)data["tenCanHo"], (uint)data["tang"], (double)data["dienTich"]));

            conn.Close();

            return ch;
        }
        private string idCanHo;
        public string IdCanHo
        {
            get { return idCanHo; }
            set { idCanHo = value; }
        }

        private string tenCanHo;
        public string TenCanHo
        {
            get { return tenCanHo; }
            set { tenCanHo = value; }
        }

        private uint tang;
        public uint Tang
        {
            get { return tang; }
            set { tang = value; }
        }

        private double dienTich;
        public double DienTich
        {
            get { return dienTich; }
            set { dienTich = value; }
        }

        public CanHo(string idCanHo, string tenCanHo, uint tang, double dienTich)
        {
            this.idCanHo = idCanHo;
            this.tenCanHo = tenCanHo;
            this.tang = tang;
            this.dienTich = dienTich;
        }
        public CanHo()
        {
            idCanHo = Guid.NewGuid().ToString();
            tenCanHo = "";
            tang = 1;
            dienTich = 10.0;
        }

        // override object.Equals
        public override bool Equals(object? obj)
        {
            if (obj == null || GetType() != obj.GetType()) return false;
            return ((CanHo)obj).idCanHo == idCanHo;
        }
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public override string ToString()
        {
            return $"({idCanHo}, {tenCanHo}, {tang}, {dienTich})";
        }


    }
}
