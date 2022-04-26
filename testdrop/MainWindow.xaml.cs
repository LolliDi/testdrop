using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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

namespace testdrop
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void dragOver(object sender, DragEventArgs e)
        {
            object info = e.Data.GetData("FileName");
            if (info != null)
            {
                e.Effects = DragDropEffects.Copy;
            }
        }

        private void dragDrop(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
                foreach (string file in files)
                {
                    string docType = file.Substring(file.Length - 5, 5);
                    Regex regexDocType = new Regex(@"(\.csv)|(\.xlsx)|(\.xls)");
                    if (regexDocType.IsMatch(docType))
                    {
                        ListViewPa.Items.Add(new FileSource() { Path = file, FileName = file});
                    }
                    else
                    {
                        MessageBox.Show("Ошибка");
                    }
                    
                }
                    
            }
        }

        struct FileSource
        {
            public string Path;
            string fileName;

            public string FileName { get => fileName; set => fileName = value; }

        }

    }
}
