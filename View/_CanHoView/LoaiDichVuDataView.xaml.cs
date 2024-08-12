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
    /// Interaction logic for LoaiDichVuDataView.xaml
    /// </summary>
    public partial class LoaiDichVuDataView : UserControl
    {
        public LoaiDichVuDataView()
        {
            InitializeComponent();
            DataContext = new DichVuDataVM();
        }

        private void DataTable_LoadingRow(object sender, DataGridRowEventArgs e)
        {
            e.Row.Header = $"{e.Row.GetIndex() + 1,10}";
        }
    }
}
