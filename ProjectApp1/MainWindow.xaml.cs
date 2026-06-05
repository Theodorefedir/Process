using Microsoft.Win32;
using System.IO;
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

namespace ProjectApp1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public  string MyDirectory { get; set; }
        public MainWindow()
        {
            InitializeComponent();
        }
        //private void BrowseButton_Click(object sender, RoutedEventArgs e)
        //{
        //    OpenFileDialog dialog = new OpenFileDialog();
        //    if (dialog.ShowDialog() == true)
        //    {
        //        DirectoryTextBox.Text = Directory = dialog.FileName;
        //    }
        //}
        private void BrowseButton_Click(object sender, RoutedEventArgs e)
        {
            OpenFolderDialog dialog = new OpenFolderDialog();
            if (dialog.ShowDialog() == true)
            {
                DirectoryTextBox.Text = MyDirectory = dialog.FolderName;
            }
        }
        private void SearchButton_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(MyDirectory))
            {
                MessageBox.Show("Please select a directory to search!","Error", MessageBoxButton.OK);
                return;
            }
            if (string.IsNullOrWhiteSpace(WordTextBox.Text))
            {
                MessageBox.Show("Please enter a word to search!","Error", MessageBoxButton.OK);
                return;
            }
            string[] files = Directory.GetFiles(DirectoryTextBox.Text, "*.txt", SearchOption.AllDirectories);
            foreach (string file in files) {
                SearchWordInDirectoryAsync(file, WordTextBox.Text);
            }
            

        }
        private string[] ReadFileToArray(string filePath)
        {
            string content = File.ReadAllText(filePath);
            return content.Split(' ');
        }
        private int SearchWordInArray(string[] words, string searchWord)
        {
            int count = 0;

            for (int i = 0; i < words.Length; i++)
            {
                if (words[i] == searchWord)
                {
                    count++;
                }
            }        
            return count;
        }
        private Task SearchWordInDirectoryAsync(string directoryPath, string searchWord) {
            return Task.Run(() => {
                string[] array = ReadFileToArray(directoryPath);
                int count = SearchWordInArray(array, searchWord);
                Dispatcher.Invoke(() =>
                {
                    if (count == 0)
                    {
                        ResultsListBox.Items.Add($"word {searchWord} wasnt found in this directory");
                    }
                    else
                    {
                        ResultsListBox.Items.Add($"word {searchWord} was found {count} times in this directory");
                    }
                });
            });  
        }
    }
}