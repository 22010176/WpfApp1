﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1.Model
{
    class CanHo
    {
        private string tenCanHo;

        public string TenCanHo
        {
            get { return tenCanHo; }
            set { tenCanHo = value; }
        }

        private string idCanHo;

        public string IdCanHo
        {
            get { return idCanHo; }
            set { idCanHo = value; }
        }

        private int tang;

        public int Tang
        {
            get { return tang; }
            set { tang = value; }
        }
        public CanHo(string idCanHo, string tenCanHo, int tang)
        {
            this.idCanHo = idCanHo;
            this.tenCanHo = tenCanHo;
            this.tang = tang;
        }
        public CanHo(CanHo? src = null)
        {
            if (src != null)
            {
                idCanHo = src.idCanHo;
                tenCanHo = src.tenCanHo;
                tang = src.tang;
            }
            else
            {

                idCanHo = Guid.NewGuid().ToString();
                tenCanHo = "";
                tang = 1;
            };
        }

        // override object.Equals
        public override bool Equals(object? obj)
        {
            if (obj == null || GetType() != obj.GetType()) return false;
            return ((CanHo)obj).idCanHo == idCanHo;
        }

        // override object.GetHashCode
        public override int GetHashCode()
        {
            // TODO: write your implementation of GetHashCode() here
            return base.GetHashCode();
        }

        public override string ToString()
        {
            return $"{idCanHo,10} {tenCanHo,10} {tang,5}";
        }

    }
}
