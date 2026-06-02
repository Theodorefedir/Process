using Microsoft.Win32;
using Microsoft.WindowsAPICodePack.Dialogs;
using System.IO;
using System.Text;
using System.Windows;


namespace CopyApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public string Source { get; set; }
        public string Destination { get; set; }
        public MainWindow()
        {
            InitializeComponent();
            Source = src.Text = @"C:\Users\korol\Downloads\9.rar";
            Destination = dest.Text = @"C:\Users\korol\Desktop\step\test";
        }

        private void SourceButton_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            if (dialog.ShowDialog() == true) { 
                src.Text = Source = dialog.FileName;
            }
        }

        private void ToButton_Click_1(object sender, RoutedEventArgs e)
        {
            CommonOpenFileDialog fileDialog = new CommonOpenFileDialog();
            fileDialog.IsFolderPicker = true;
            if (fileDialog.ShowDialog() == CommonFileDialogResult.Ok) { 
                dest.Text = Destination = fileDialog.FileName;
            }
            

        }

        private void CopyButton_Click(object sender, RoutedEventArgs e)
        {
            string fileName = Path.GetFileName(Source);
            string destPath = Path.Combine(Destination, fileName);
            FileCopyAsync(Source, destPath);
        }
        private Task FileCopyAsync(string src, string dest) {
            return Task.Run(() => {
                File.Copy(src, dest, true);
            });
        }
    }
}