using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1.MVVM
{
    internal abstract class ModelBase : ViewModelBase
    {
        private string id = "";
        public string Id
        {
            get { return id; }
            set
            {
                id = value;
                OnPropertyChange();
            }
        }

        public ModelBase(string? id)
        {
            Id = string.IsNullOrEmpty(id) ? Guid.NewGuid().ToString() : id;
        }

        public override bool Equals(object? obj)
        {
            if (obj == null || GetType() != obj.GetType()) return false;
            return Id == ((ModelBase)obj).Id;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public override abstract string ToString();
    }
}
