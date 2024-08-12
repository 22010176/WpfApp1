﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp1.Model;
using WpfApp1.MVVM;

namespace WpfApp1.ViewModel
{
    internal class DichVuDataVM : ViewModelBase
    {
        public RelayCommand AddCommand { get; }
        public RelayCommand EditCommand { get; }
        public RelayCommand DeleteCommand { get; }
        public RelayCommand ClearCommand { get; }
        public RelayCommand FindCommand { get; }

        private ObservableCollection<DichVu> items = [];
        public ObservableCollection<DichVu> Items
        {
            get { return items; }
            set
            {
                items = value;
                OnPropertyChange();
            }
        }

        private DichVu? selectedItem;
        public DichVu? SelectedItem
        {
            get { return selectedItem; }
            set
            {
                selectedItem = value;
                FormData = SelectedItem == null ? new() : new(SelectedItem.Id, SelectedItem.TenDichVu, SelectedItem.Gia);
                OnPropertyChange();
            }
        }

        private DichVu formData = new();
        public DichVu FormData
        {
            get { return formData; }
            set
            {
                formData = value;
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


        public DichVuDataVM()
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
            DichVu.Add(FormData);
            Reset();
        }

        void _EditCommand()
        {
            if (SelectedItem == null) return;
            DichVu.Edit(new(SelectedItem.Id, FormData.TenDichVu, FormData.Gia));
            Reset();
        }
        void _DeleteCommand()
        {
            if (SelectedItem == null) return;
            DichVu.Delete(SelectedItem);
            Reset();
        }
        bool _CanModifyCommand()
        {
            return SelectedItem != null && Items.Any(i => i.Id == SelectedItem.Id);
        }
        void _FindCommand()
        {
            Items = new(DichVu.FindItem(FindStr));
        }

        void Reset()
        {
            SelectedItem = null;
            Items = new(DichVu.FindItem(FindStr));
        }
    }
}
