using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Org.BouncyCastle.Bcpg.Attr.ImageAttrib;
using WpfApp1.Model;
using System.Collections.ObjectModel;

namespace WpfApp1.MVVM
{
    internal abstract class ViewModelData<T> : ViewModelBase where T : ModelBase
    {
        public abstract RelayCommand AddCommand { get; }
        public abstract RelayCommand EditCommand { get; }
        public abstract RelayCommand DeleteCommand { get; }
        public abstract RelayCommand ClearCommand { get; }
        public abstract RelayCommand FindCommand { get; }

        public abstract ObservableCollection<T> Items { get; set; }
        public abstract T? SelectedItem { get; set; }
        public abstract T FormData { get; set; }
        public abstract string FindStr { get; set; }

        public abstract void _AddCommand();
        public abstract void _EditCommand();
        public abstract void _DeleteCommand();
        public abstract void _FindCommand();
        public abstract void Reset();
    }
}
