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
    class CanHoDataVM : ViewModelBase
    {
        public Command AddCommand { get; }
        public Command EditCommand { get; }
        public Command DeleteCommand { get; }
        public Command ClearCommand { get; }

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
                FormData = SelectedItem == null ? new CanHo() : new CanHo(SelectedItem);
            }
        }

        private CanHo formData;
        private Command addCommand;

        public CanHo FormData
        {
            get { return formData; }
            set
            {
                formData = value;
                OnPropertyChange();
            }
        }

        public CanHoDataVM()
        {
            AddCommand = new(execute => _AddCommand());
            EditCommand = new(execute => _EditCommand(), canExecute => _CanEditCommand());
            DeleteCommand = new(execute => _DeleteCommand(), canExecute => _CanDeleteCommand());
            ClearCommand = new(execute => _ClearCommand());

            Items = [
                new CanHo("Test1","a",3),
                new CanHo("Test2","a4",4),
                new CanHo("Test3","a44",5)
            ];

            FormData = new("", "", 1);
        }

        void _AddCommand()
        {
        }
        void _EditCommand()
        {
        }
        bool _CanEditCommand()
        {
            return true;
        }
        void _DeleteCommand() { }
        bool _CanDeleteCommand()
        {
            return true;
        }
        void _ClearCommand() { }
    }
}
