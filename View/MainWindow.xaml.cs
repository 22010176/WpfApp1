using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using WpfApp1.View;
using WpfApp1.ViewModel;

namespace WpfApp1
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            DataContext = new MainWindowVM();

            PageControl.Content = new CuDanView();
            CuDanBtn.IsEnabled = false;
        }

        private void StackPanel_Click(object sender, RoutedEventArgs e)
        {
            if (e.Source == null) return;
            FrameworkElement? frameworkElement = e.Source as FrameworkElement;

            CuDanBtn.IsEnabled = CanHoBtn.IsEnabled = ThongKeBtn.IsEnabled = true;
            switch (frameworkElement?.Name)
            {
                case "CuDanBtn":
                    PageControl.Content = new CuDanView();
                    CuDanBtn.IsEnabled = false;
                    break;
                case "CanHoBtn":
                    PageControl.Content = new CanHoView();
                    CanHoBtn.IsEnabled = false;
                    break;
                case "ThongKeBtn":
                    PageControl.Content = new ThongKeView();
                    ThongKeBtn.IsEnabled = false;
                    break;
            }
        }
    }
}