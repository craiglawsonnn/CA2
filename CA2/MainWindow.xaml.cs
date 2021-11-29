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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace CA2
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

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            List<Activity> FillList = new List<Activity>();
            Activity A1 = new Activity() { Name = "Cycling", Cost = 39.99m, ActivityDate = new DateTime(2021, 5, 21), Description="Cycling is QUICK" };
            Activity A2 = new Activity() { Name = "Running", Cost = 20.00m, ActivityDate = new DateTime(2021, 5, 28), Description = "Running is healthy" };
            Activity A3 = new Activity() { Name = "Walking", Cost = 10.00m, ActivityDate = new DateTime(2021, 6, 1), Description = "Walking can be fun on occasion" };

            FillList.Add(A1);
            FillList.Add(A2);
            FillList.Add(A3);
            foreach (Activity activity in FillList)
            {
                lbxAllActivities.ItemsSource = FillList;
            }
        }

        private void lbxAllActivities_GotFocus(object sender, RoutedEventArgs e)
        {
            tblkDescription.Text = lbxAllActivities.SelectedItem.ToString();
        }
    }
}
