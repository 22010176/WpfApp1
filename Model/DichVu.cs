using MySql.Data.MySqlClient;
using Mysqlx.Crud;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1.Model
{
    internal class DichVu
    {
        public static List<DichVu> Read()
        {
            List<DichVu> result = [];
            MySqlConnection conn = Database.GetConnection();
            try
            {
                conn.Open();
                MySqlCommand cmd = new("SELECT * FROM phidichvu ORDER BY tenDV ASC, gia ASC;", conn);
                MySqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read()) result.Add(new DichVu((string)reader["id"], (string)reader["tenDV"], (uint)reader["gia"]));
                conn.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }

            return result;
        }
        public static List<DichVu> FindItem(string? str)
        {
            if (string.IsNullOrEmpty(str)) return Read();

            List<DichVu> ch = [];
            MySqlConnection conn = Database.GetConnection();

            conn.Open();
            MySqlCommand cmd = new("SELECT * FROM phidichvu WHERE tenDV LIKE @str ORDER BY tenDV ASC, gia ASC;", conn);
            cmd.Parameters.AddWithValue("@str", $"%{str}%");

            MySqlDataReader data = cmd.ExecuteReader();
            while (data.Read()) ch.Add(new DichVu((string)data["id"], (string)data["tenDV"], (uint)data["gia"]));
            conn.Close();

            return ch;
        }
        public static void Add(DichVu dv)
        {
            MySqlConnection con = Database.GetConnection();
            try
            {
                con.Open();
                MySqlCommand cmd = new("INSERT INTO phidichvu (id, tenDV, gia) VALUES (@id, @ten, @gia);", con);
                cmd.Parameters.AddWithValue("@id", dv.Id);
                cmd.Parameters.AddWithValue("@ten", dv.TenDichVu);
                cmd.Parameters.AddWithValue("@gia", dv.Gia);
                cmd.ExecuteNonQuery();
                con.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }

        public static void Edit(DichVu dv)
        {
            MySqlConnection con = Database.GetConnection();
            try
            {
                con.Open();
                MySqlCommand cmd = new("UPDATE phidichvu SET tenDV = @ten, gia = @gia WHERE id = @id;", con);
                cmd.Parameters.AddWithValue("@ten", dv.TenDichVu);
                cmd.Parameters.AddWithValue("@gia", dv.Gia);
                cmd.Parameters.AddWithValue("@id", dv.Id);
                cmd.ExecuteNonQuery();
                con.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }

        public static void Delete(DichVu dv)
        {
            MySqlConnection con = Database.GetConnection();
            try
            {
                con.Open();
                MySqlCommand cmd = new("DELETE FROM phidichvu WHERE id = @id;", con);
                cmd.Parameters.AddWithValue("@id", dv.Id);
                cmd.ExecuteNonQuery();
                con.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }
        private string id = "";
        public string Id
        {
            get { return id; }
            set { id = value; }
        }

        private string tenDichVu = "";
        public string TenDichVu
        {
            get { return tenDichVu; }
            set { tenDichVu = value; }
        }

        private uint gia = 0;
        public uint Gia
        {
            get { return gia; }
            set { gia = value; }
        }

        public DichVu()
        {
            Id = Guid.NewGuid().ToString();
            TenDichVu = "";
            Gia = 0;
        }

        public DichVu(string id, string tenDichVu, uint gia)
        {
            Id = id;
            TenDichVu = tenDichVu;
            Gia = gia;
        }

        // override object.Equals
        public override bool Equals(object obj)
        {
            //       
            // See the full list of guidelines at
            //   http://go.microsoft.com/fwlink/?LinkID=85237  
            // and also the guidance for operator== at
            //   http://go.microsoft.com/fwlink/?LinkId=85238
            //

            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }

            // TODO: write your implementation of Equals() here
            return ((DichVu)obj).Id == Id;
        }
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
        public override string ToString()
        {
            return $"({Id}, {TenDichVu}, {Gia})";
        }


    }
}
