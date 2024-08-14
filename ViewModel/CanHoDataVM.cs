using Google.Protobuf.WellKnownTypes;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp1.Model;
using WpfApp1.MVVM;

namespace WpfApp1.ViewModel
{
    class CanHoDataVM : ViewModelBase
    {
        public RelayCommand AddCommand { get; }
        public RelayCommand EditCommand { get; }
        public RelayCommand DeleteCommand { get; }
        public RelayCommand ClearCommand { get; }
        public RelayCommand FindCommand { get; }

        private ObservableCollection<CanHo> items = [];

        public ObservableCollection<CanHo> Items
        {
            get { return items; }
            set
            {
                items = value;
                OnPropertyChange();
            }
        }

        private CanHo? selectedItem = null;
        public CanHo? SelectedItem
        {
            get { return selectedItem; }
            set
            {
                selectedItem = value;
                if (value != null)
                {
                    Tang = value.Tang;
                    TenCanHo = value.TenCanHo;
                    DienTich = value.DienTich;
                }
                else
                {
                    Tang = 1;
                    TenCanHo = "";
                    DienTich = 1;
                }
                OnPropertyChange();
            }
        }

        private string tenCanHo = "";
        public string TenCanHo
        {
            get { return tenCanHo; }
            set
            {
                tenCanHo = value;
                OnPropertyChange();
            }
        }

        private uint tang = 1;
        public uint Tang
        {
            get { return tang; }
            set
            {
                tang = value;
                OnPropertyChange();
            }
        }

        private double dienTich = 1;

        public double DienTich
        {
            get { return dienTich; }
            set
            {
                dienTich = value;
                OnPropertyChange();
            }
        }


        private string findStr = "";
        public string FindStr
        {
            get { return findStr; }
            set
            {
                findStr = value;
                OnPropertyChange();
            }
        }

        public CanHoDataVM()
        {
            AddCommand = new(execute => _AddCommand(), canExecute => !_CanModifyCommand());
            EditCommand = new(execute => _EditCommand(), canExecute => _CanModifyCommand());
            DeleteCommand = new(execute => _DeleteCommand(), canExecute => _CanModifyCommand());
            ClearCommand = new(execute => Reset());
            FindCommand = new(execute => _FindCommand());

            Reset();
        }

        void _AddCommand()
        {
            Database.Query($"INSERT INTO canho {CanHo.Fields} VALUES ('{Guid.NewGuid().ToString()}', '{TenCanHo}', {Tang}, {$"{DienTich}".Replace(",", ".")});");
            Reset();
        }

        void _EditCommand()
        {
            if (SelectedItem == null) return;
            string cmd = $"UPDATE canho SET tenCanHo = '{TenCanHo}', dienTich = {$"{DienTich}".Replace(",", ".")}, tang = {Tang} WHERE id = '{SelectedItem.Id}';";
            Console.WriteLine(cmd);
            Database.Query(cmd);
            Reset();
        }
        void _DeleteCommand()
        {
            if (SelectedItem == null) return;

            Database.Query($"DELETE FROM canho WHERE id = '{SelectedItem.Id}';");
            Reset();
        }
        bool _CanModifyCommand()
        {
            return SelectedItem != null && Items.Any(i => i.Id == SelectedItem.Id);
        }
        void _FindCommand()
        {
            Items = new(Database.Query($"SELECT * FROM canho WHERE tenCanHo LIKE '%{FindStr}%'", CanHo.Converter));
        }

        void Reset()
        {
            SelectedItem = null;
            Tang = 1;
            DienTich = 1;
            TenCanHo = "";
            FindStr = "";

            Items = new(Database.Query(
                "SELECT * FROM canho ORDER BY tang ASC, tenCanHo ASC;",
                CanHo.Converter
            ));
        }
    }
}
