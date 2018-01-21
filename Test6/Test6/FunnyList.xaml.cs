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
using System.Windows.Shapes;
using System.Collections;

namespace Test6
{
    /// <summary>
    /// Interaction logic for FunnyList.xaml
    /// </summary>
    public partial class FunnyList : Window
    {
        private ArrayList myDataList = null;
        public FunnyList()
        {
            InitializeComponent();
            myDataList = LoadListBoxData();
            LeftListBox.ItemsSource = myDataList;
        }

        private ArrayList LoadListBoxData()
        {
            ArrayList itemsList = new ArrayList();
            itemsList.Add("Coffie");
            itemsList.Add("Tea");
            itemsList.Add("Orange Juice");
            itemsList.Add("Milk");
            itemsList.Add("Mango Shake");
            itemsList.Add("Iced Tea");
            itemsList.Add("Soda");
            itemsList.Add("Water");
            return itemsList;
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            string currentItemText = LeftListBox.SelectedValue.ToString();
            int currentItemIndex = LeftListBox.SelectedIndex;

            RightListBox.Items.Add(currentItemText);
            if (myDataList != null)
                myDataList.RemoveAt(currentItemIndex);

            LeftListBox.ItemsSource = null;
            LeftListBox.ItemsSource = myDataList;
        }

        private void RemoveButton_Click(object sender, RoutedEventArgs e)
        {
            string currentItemText = RightListBox.SelectedValue.ToString();
            int currentItemIndex = RightListBox.SelectedIndex;
            myDataList.Add(currentItemText);
            RightListBox.Items.RemoveAt(RightListBox.Items.IndexOf(RightListBox.SelectedItem));

            LeftListBox.ItemsSource = null;
            LeftListBox.ItemsSource = myDataList;
        }

    }
}
