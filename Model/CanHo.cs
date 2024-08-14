using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.RightsManagement;
using System.Text;
using System.Threading.Tasks;
using WpfApp1.MVVM;

namespace WpfApp1.Model
{
    internal class CanHo : ModelBase
    {

        public static readonly string Fields = "(id, tenCanHo, tang, dienTich)";
        public static readonly Func<MySqlDataReader, CanHo> Converter = data=> new((string)data["id"], (string)data["tenCanHo"], (uint)data["tang"], (double)data["dienTich"]);

        private string tenCanHo;
        public string TenCanHo
        {
            get { return tenCanHo; }
            set
            {
                tenCanHo = value;
                OnPropertyChange();
            }
        }

        private uint tang;
        public uint Tang
        {
            get { return tang; }
            set
            {
                tang = value;
                OnPropertyChange();
            }
        }

        private double dienTich;
        public double DienTich
        {
            get { return dienTich; }
            set
            {
                dienTich = value;
                OnPropertyChange();
            }
        }

        public CanHo(string idCanHo, string tenCanHo, uint tang, double dienTich) : base(idCanHo)
        {
            this.tenCanHo = tenCanHo;
            this.tang = tang;
            this.dienTich = dienTich;
        }
        public CanHo() : base(Guid.NewGuid().ToString())
        {
            tenCanHo = "";
            tang = 1;
            dienTich = 10.0;
        }

        public override string ToString()
        {
            return $"('{Id}', '{TenCanHo}', {Tang}, {$"{DienTich}".Replace(",", ".")})";
        }
    }
}
