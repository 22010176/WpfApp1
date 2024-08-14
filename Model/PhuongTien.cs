using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp1.MVVM;

namespace WpfApp1.Model
{
    internal class PhuongTien : ModelBase
    {
        public static readonly string Fields = "(id, tenPhuongTien)";
        public static readonly Func<MySqlDataReader, PhuongTien> Converter = data => new PhuongTien((string)data["id"], (string)data["tenPhuongTien"]);

        private string tenPhuongTien = "";
        public string TenPhuongTien
        {
            get { return tenPhuongTien; }
            set
            {
                tenPhuongTien = value;
                OnPropertyChange();
            }
        }

        public PhuongTien(string id, string tenPhuongTien) : base(id)
        {
            TenPhuongTien = tenPhuongTien;
        }

        public override string ToString()
        {
            return $"('{Id}', '{TenPhuongTien}')";
        }
    }
}
