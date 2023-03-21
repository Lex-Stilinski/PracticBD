using PracticWPF.PracticDataSetTableAdapters;
using System;
using System.Collections.Generic;
using System.Data;
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

namespace PracticWPF
{
    /// <summary>
    /// Логика взаимодействия для SecondPage.xaml
    /// </summary>
    public partial class SecondPage : Page
    {
        humanTableAdapter humans = new humanTableAdapter();
        colorTableAdapter colour = new colorTableAdapter();
        int s;

        public SecondPage()
        {
            InitializeComponent();
            HumanList.ItemsSource = humans.GetData();
            IdTxt.ItemsSource = colour.GetData();
            IdTxt.DisplayMemberPath = "color_name";
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            object id = (HumanList.SelectedItem as DataRowView).Row[0];
            humans.UpdateQuery(NameTxt.Text, s, Convert.ToInt32(id));
            HumanList.ItemsSource = humans.GetData();
        }

        private void IdTxt_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            object cell = (IdTxt.SelectedItem as DataRowView).Row[0];
            s = (int)cell;
        }
    }
}
