using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
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

namespace CustomListBox
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        ObservableCollection<DataEntry> items = new ObservableCollection<DataEntry>();

        string date = DateTime.Now.ToShortDateString();
        string imgPath = "C:\\Users\\Haadii\\Desktop\\Images\\cancel.png";
        string imgPath1 = "C:\\Users\\Haadii\\Desktop\\Images\\add.png";
        string imgPath2 = "C:\\Users\\Haadii\\Desktop\\Images\\checked.png";
        string info = "Looking for a wpf listbox control to be styled to look like attached image. List box needs to be bound to observable collection of objects that have string properties for title and message, a date property and image property for an icon. Should look like attached where the items are grouped by day.";
        public MainWindow()
        {
            InitializeComponent();
          //  MessageBox.Show(info.Length.ToString());
            items.Add(new DataEntry() { Title = "Mail", Date = date, Heading1 = "Message", Heading2 = "Where are you", Details = "jaldi aao yr sab intzaar kr rhy hn.", ImgPath = imgPath, BelongsTo = "Yesterday" });
            items.Add(new DataEntry() { Title = "Mail", Date = date, Heading1 = "Call", Heading2 = "Where are you", Details = info, ImgPath = imgPath1, BelongsTo = "Yesterday" });
            items.Add(new DataEntry() { Title = "Mail", Date = date, Heading1 = "University", Heading2 = "Where are you", Details = info, ImgPath = imgPath1, BelongsTo = "Yesterday" });
            items.Add(new DataEntry() { Title = "Mail", Date = date, Heading1 = "Information", Heading2 = "Where are you", Details = info, ImgPath = imgPath2, BelongsTo = "Recent" });
            items.Add(new DataEntry() { Title = "Mail", Date = date, Heading1 = "Emergency", Heading2 = "Where are you", Details = info, ImgPath = imgPath2, BelongsTo = "Recent" });
            //     items.Add(new DataEntry() { Name = "Learn C#", Description = "Complete this WPF tutorial" });

            ICollectionView view = CollectionViewSource.GetDefaultView(items);
            view.GroupDescriptions.Add(new PropertyGroupDescription("BelongsTo"));
            view.SortDescriptions.Add(new SortDescription("BelongsTo", ListSortDirection.Ascending));


            listBox1.ItemsSource = view;
        }

        private void CancelBtn_Click(object sender, RoutedEventArgs e)
        {
            int index = listBox1.SelectedIndex;
            if (index > -1)
            {
                items.RemoveAt(index);
                listBox1.Items.Refresh();
            }
            else
            {
                MessageBox.Show("kindly Select the Message First");            
            }


        }
    }

    public class DataEntry
    {
        public string Title { get; set; }
        public string Date { get; set; }
        public string Heading1 { get; set; }
        public string Heading2 { get; set; }
        public string Details { get; set; }
        public string ImgPath { get; set; }
        public string BelongsTo { get; set; }
    }
}
