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

namespace Test6
{
    /// <summary>
    /// Interaction logic for ListBoxEx.xaml
    /// </summary>
    public partial class ListBoxEx : Window
    {
        public ListBoxEx()
        {
            InitializeComponent();
            List<TodoItem> list = new List<TodoItem>();
            list.Add(new TodoItem() { Work = "Learn to speak English fluently", Completion = 30 });
            list.Add(new TodoItem() { Work = "Do homework", Completion = 30 });
            list.Add(new TodoItem() { Work = "Do housework", Completion = 10 });
            list.Add(new TodoItem() { Work = "Read book", Completion = 50 });

            toDoList.ItemsSource = list;
        }

        //Doi title cua cua so bang cong viec cua item duoc chon
        private void toDoList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (toDoList.SelectedItem != null)
                this.Title = (toDoList.SelectedItem as TodoItem).Work;
        }

        //Hien cua so thong bao cong viec duoc chon
        private void btnShowSelectedItem_Click(object sender, RoutedEventArgs e)
        {
            foreach (object o in toDoList.SelectedItems)
                MessageBox.Show((o as TodoItem).Work);
        }

        //chon item cuoi danh sach
        private void btnSelectLast_Click(object sender, RoutedEventArgs e)
        {
            toDoList.SelectedIndex = toDoList.Items.Count - 1;
        }

        //chon item tiep theo item dang chon
        private void btnSelectNext_Click(object sender, RoutedEventArgs e)
        {
            if ((toDoList.SelectedIndex >= 0) && (toDoList.SelectedIndex < (toDoList.Items.Count - 1)))
                toDoList.SelectedIndex += 1;
        }

        //chon tat ca item
        private void btnSelectAll_Click(object sender, RoutedEventArgs e)
        {
            foreach (object o in toDoList.Items)
                toDoList.SelectedItems.Add(o);
        }
    }

    public class TodoItem
    {
        public string Work { get; set; }
        public int Completion { get; set; }
    }
}
