using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
            CanHo.Add(new CanHo(Guid.NewGuid().ToString(), TenCanHo, Tang, DienTich));
            Reset();
        }

        void _EditCommand()
        {
            if (SelectedItem == null) return;

            CanHo.Edit(new CanHo(SelectedItem.IdCanHo, TenCanHo, Tang, DienTich));
            Reset();
        }
        void _DeleteCommand()
        {
            if (SelectedItem == null) return;
            CanHo.Delete(SelectedItem.IdCanHo);
            Reset();
        }
        bool _CanModifyCommand()
        {
            return SelectedItem != null && Items.Any(i => i.IdCanHo == SelectedItem.IdCanHo);
        }
        void _FindCommand()
        {
            Items = new(CanHo.FindItem(FindStr));
        }

        void Reset()
        {
            SelectedItem = null;
            Tang = 1;
            DienTich = 1;
            TenCanHo = "";
            FindStr = "";
            Items = new(CanHo.Read());
        }
    }
}
