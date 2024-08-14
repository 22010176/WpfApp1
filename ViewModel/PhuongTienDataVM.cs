using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp1.Model;
using WpfApp1.MVVM;

namespace WpfApp1.ViewModel
{
    internal class PhuongTienDataVM : ViewModelData<PhuongTien>
    {
        public override RelayCommand AddCommand => new(e => _AddCommand(), e => !_CanModifyCommand());
        public override RelayCommand EditCommand => new(e => _EditCommand(), e => _CanModifyCommand());
        public override RelayCommand DeleteCommand => new(e => _DeleteCommand(), e => _CanModifyCommand());
        public override RelayCommand ClearCommand => new(e => Reset());
        public override RelayCommand FindCommand => new(e => _FindCommand());

        ObservableCollection<PhuongTien> items = [];
        public override ObservableCollection<PhuongTien> Items
        {
            get { return items; }
            set
            {
                items = value;
                OnPropertyChange();
            }
        }

        PhuongTien? selectedItem;
        public override PhuongTien? SelectedItem
        {
            get => selectedItem;
            set
            {
                selectedItem = value;
                FormData = SelectedItem == null ? new("", "") : new(SelectedItem.Id, SelectedItem.TenPhuongTien);
                OnPropertyChange();
            }
        }

        PhuongTien formData = new("", "");
        public override PhuongTien FormData
        {
            get => formData;
            set
            {
                formData = value;
                OnPropertyChange();
            }
        }

        string findStr = "";
        public override string FindStr
        {
            get => findStr;
            set
            {
                findStr = value;
                OnPropertyChange();
            }
        }

        public PhuongTienDataVM()
        {
            Reset();
        }

        public override void Reset()
        {
            SelectedItem = null;
            FindStr = "";
            Items = new(Database.Query("SELECT * FROM phuongtien ORDER BY tenPhuongTien;", PhuongTien.Converter));
        }

        public override void _AddCommand()
        {
            Database.Query($"INSERT INTO phuongtien {PhuongTien.Fields} VALUES {FormData}");
            Reset();
        }

        public override void _DeleteCommand()
        {
            if (SelectedItem == null) return;

            Database.Query($"DELETE FROM phuongtien WHERE ID = '{SelectedItem.Id}';");
            Reset();
        }

        public override void _EditCommand()
        {
            if (SelectedItem == null) return;

            Database.Query($"UPDATE phuongtien SET tenPhuongTien = '{FormData.TenPhuongTien}' WHERE id = '{SelectedItem.Id}'");
            Reset();
        }

        public override void _FindCommand()
        {
            Items = new(Database.Query($"SELECT * FROM phuongtien WHERE tenPhuongTien LIKE '%{FindStr}%' ORDER BY tenPhuongTien ASC;", PhuongTien.Converter));
        }
        bool _CanModifyCommand()
        {
            return SelectedItem != null && Items.Any(i => i.Id == SelectedItem.Id);
        }
    }
}
