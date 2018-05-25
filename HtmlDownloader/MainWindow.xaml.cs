using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
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

namespace HtmlDownloader
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

        private void OnGetHtmlButton(object sender, RoutedEventArgs e)
        {
            progressBar.IsEnabled = true;
            progressBar.Value = 0;
            using (var webClient = new System.Net.WebClient())
            {
                progressBar.Value = progressBar.Maximum;
                HtmlTextBlock.Text = webClient.DownloadString(UrlTextBox.Text);
            }
        }

        private void OnSaveButton(object sender, RoutedEventArgs e)
        {
            progressBar.Value = 0;
            var saveFileDialog = new SaveFileDialog();

            saveFileDialog.FileName = "Content";
            saveFileDialog.FilterIndex = 1;
            saveFileDialog.Filter = "All files (*.*)|*.*";
            saveFileDialog.DefaultExt = "txt";

            saveFileDialog.ShowDialog();

            using (var binaryWriter = new BinaryWriter(File.Create(saveFileDialog.FileName)))
            {
                binaryWriter.Write(HtmlTextBlock.Text);
            }

        }
    }
}
