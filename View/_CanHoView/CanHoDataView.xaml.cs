using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using WpfApp1.ViewModel;

namespace WpfApp1.View._CanHoView
{
    /// <summary>
    /// Interaction logic for CanHoDataView.xaml
    /// </summary>
    public partial class CanHoDataView : UserControl
    {
        public CanHoDataView()
        {
            InitializeComponent();
            DataContext = new CanHoDataVM();
            SetBtnState(true);
        }
        void SetBtnState(bool state)
        {
            AddBtn.IsEnabled = state;
            EditBtn.IsEnabled = DeleteBtn.IsEnabled = !state;
        }

        private void DataTable_MouseDown(object sender, MouseButtonEventArgs e)
        {
            SetBtnState(false);
        }
    }
}
