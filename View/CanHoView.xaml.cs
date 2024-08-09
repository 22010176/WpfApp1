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
using WpfApp1.View._CanHoView;

namespace WpfApp1.View
{
    /// <summary>
    /// Interaction logic for CanHoView.xaml
    /// </summary>
    public partial class CanHoView : UserControl
    {
        public CanHoView()
        {
            InitializeComponent();
            CanHoControl.Content = new CanHoDataView();
            chBtn.IsEnabled = false;

        }
        private void StackPanel_Click(object sender, RoutedEventArgs e)
        {
            if (e.Source == null) return;
            FrameworkElement? frameworkElement = e.Source as FrameworkElement;

            chBtn.IsEnabled = dvBtn.IsEnabled = ptBtn.IsEnabled = true;
            switch (frameworkElement?.Name)
            {
                case "chBtn":
                    CanHoControl.Content = new CanHoDataView();
                    chBtn.IsEnabled = false;
                    break;
                case "dvBtn":
                    CanHoControl.Content = new LoaiDichVuDataView();
                    dvBtn.IsEnabled = false;
                    break;
                case "ptBtn":
                    CanHoControl.Content = new PhuongTienDataView();
                    ptBtn.IsEnabled = false;
                    break;
            }
        }
    }
}
