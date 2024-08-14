using MySql.Data.MySqlClient;
using Mysqlx.Crud;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp1.MVVM;

namespace WpfApp1.Model
{
    internal class DichVu : ModelBase
    {
        public static readonly string Fields = "(id, tenDV, gia)";
        public static readonly Func<MySqlDataReader, DichVu> Converter = reader => new((string)reader["id"], (string)reader["tenDV"], (uint)reader["gia"]);

        private string tenDichVu = "";
        public string TenDichVu
        {
            get { return tenDichVu; }
            set
            {
                tenDichVu = value;
                OnPropertyChange();
            }
        }

        private uint gia = 0;
        public uint Gia
        {
            get { return gia; }
            set
            {
                gia = value;
                OnPropertyChange();
            }
        }

        public DichVu() : base(Guid.NewGuid().ToString())
        {
            TenDichVu = "";
            Gia = 0;
        }

        public DichVu(string id, string tenDichVu, uint gia) : base(id)
        {
            TenDichVu = tenDichVu;
            Gia = gia;
        }

        public override string ToString()
        {
            return $"('{Id}', '{TenDichVu}', {Gia})";
        }


    }
}
