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

        private ObservableCollection<CanHo> items;

        public ObservableCollection<CanHo> Items
        {
            get { return items; }
            set
            {
                items = value;
                OnPropertyChange();
            }
        }

        private CanHo? selectedItem;
        public CanHo? SelectedItem
        {
            get { return selectedItem; }
            set
            {
                selectedItem = value;
                OnPropertyChange();
            }
        }

        public CanHoDataVM()
        {
            AddCommand = new(execute => _AddCommand(), canExecute => !_CanModifyCommand());
            EditCommand = new(execute => _EditCommand(), canExecute => _CanModifyCommand());
            DeleteCommand = new(execute => _DeleteCommand(), canExecute => _CanModifyCommand());
            ClearCommand = new(execute => _ClearCommand());

            Items = [
                new CanHo("Test1","a",3),
                new CanHo("Test2","a4",4),
                new CanHo("Test3","a44",5)
            ];
            selectedItem = null;
        }

        void _AddCommand()
        {
            Items.Add(new CanHo(SelectedItem));
            SelectedItem = null;
        }

        void _EditCommand()
        {
            if (SelectedItem == null) return;
            Items[Items.IndexOf(SelectedItem)] = SelectedItem;
        }
        void _DeleteCommand()
        {
            if (SelectedItem == null) return;
            Items.Remove(SelectedItem);
        }
        bool _CanModifyCommand()
        {
            return SelectedItem != null && Items.Any(i => i.IdCanHo == SelectedItem.IdCanHo);
        }
        void _ClearCommand()
        {
            SelectedItem = null;
        }
    }
}
