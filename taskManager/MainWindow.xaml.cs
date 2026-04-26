using System.Diagnostics;
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

namespace taskManager
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        private void Button_Refresh(object sender, RoutedEventArgs e)
        {
            grid.ItemsSource = Process.GetProcesses();
        }
        private void Button_Kill(object sender, RoutedEventArgs e)
        {
            Process select = (Process)grid.SelectedItem;
            select.Kill();
        }
        private void Button_Close(object sender, RoutedEventArgs e)
        {
            Process select = (Process)grid.SelectedItem;
            select.Close();
        }
        private void Button_Info(object sender, RoutedEventArgs e)
        {
            Process select = (Process)grid.SelectedItem;
            MessageBox.Show(select.ProcessName);
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string path = txtProcessPath.Text;
            Process.Start(path);
            MessageBox.Show($"{path} Started");
            txtProcessPath.Text = "";
        }
    }
}