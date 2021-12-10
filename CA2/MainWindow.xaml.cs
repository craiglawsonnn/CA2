using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    /// Name: Craig Lawson
    /// Date: 10/12/21
    /// Desc:CA2
    /// </summary>
    public partial class MainWindow : Window
    {
        //creating observable collections so they update as they are altered in the wpf
        ObservableCollection<Activity> FillList;
        ObservableCollection<Activity> filteredActivities = new ObservableCollection<Activity>();
        ObservableCollection<Activity> filteredSecondaryActivities = new ObservableCollection<Activity>();
        //creating public variables
        decimal TotalCost;
        List<DateTime> ReservedDates = new List<DateTime>();
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            #region Filling list
            Activity A1 = new Activity("Cycling", 39.99m, new DateTime(2021, 5, 21), "Cycling is QUICK and lets you explore large areas", TypeOfActivity.Land);
            Activity A2 = new Activity("Running", 20.00m, new DateTime(2021, 5, 28), "Running is healthy and good for the heart", TypeOfActivity.Land);
            Activity A3 = new Activity("Walking", 10.00m, new DateTime(2021, 6, 1), "Walking can be fun on occasion", TypeOfActivity.Land);

            Activity A4 = new Activity("Kayaking", 45.99m, new DateTime(2021, 5, 21), "Try and kayak down the Garavogue river", TypeOfActivity.Water);
            Activity A5 = new Activity("SUPing", 35.99m, new DateTime(2021, 5, 21), "Stand up paddleboarding can be a relaxing time", TypeOfActivity.Water);
            Activity A6 = new Activity("Canoeing", 54.99m, new DateTime(2021, 5, 21), "Traverse the water in a canoe", TypeOfActivity.Water);

            Activity A7 = new Activity("Parachuting", 90.99m, new DateTime(2021, 5, 21), "Parachuting is a high octane", TypeOfActivity.Air);
            Activity A8 = new Activity("Bungie Jumping", 69.99m, new DateTime(2021, 5, 21), "Bungie Jumping is an exhilerating activity", TypeOfActivity.Air);
            Activity A9 = new Activity("Plane Lesson", 109.99m, new DateTime(2021, 5, 21), "Learn to fly and do lessons", TypeOfActivity.Air);

            FillList = new ObservableCollection<Activity>();
            FillList.Add(A1);
            FillList.Add(A2);
            FillList.Add(A3);
            FillList.Add(A4);
            FillList.Add(A5);
            FillList.Add(A6);
            FillList.Add(A7);
            FillList.Add(A8);
            FillList.Add(A9);
            #endregion

            #region Outputting to listbox
            /*Filllist = FillList.OrderBy(a => a.ActivityDate).ToList();
            filteredSecondaryActivities = filteredSecondaryActivities.OrderBy(a => a.ActivityDate).ToArray();*/

            lbxAllActivities.ItemsSource = FillList;
            lbxSelectedActivities.ItemsSource = filteredSecondaryActivities;

            #endregion
        }

        #region Radio buttons
        private void rdoAll_Checked(object sender, RoutedEventArgs e)
        {
            //reset the filter
            filteredActivities.Clear();

            //if all checked, display all
            if (rdoAll.IsChecked == true)
            {
                lbxAllActivities.ItemsSource = FillList;
            }

            //else if 1 checked display 1
            else if (rdoLand.IsChecked == true)
            {
                foreach (Activity activity in FillList)
                {
                    if (activity.ActivityType == TypeOfActivity.Land)
                        //add to my filtered collection
                        filteredActivities.Add(activity);
                }

                lbxAllActivities.ItemsSource = filteredActivities;
            }

            else if (rdoAir.IsChecked == true)
            {
                foreach (Activity activity in FillList)
                {
                    if (activity.ActivityType == TypeOfActivity.Air)
                        //add to my filtered collection
                        filteredActivities.Add(activity);
                }

                lbxAllActivities.ItemsSource = filteredActivities;
            }

            else if (rdoWater.IsChecked == true)
            {
                foreach (Activity activity in FillList)
                {
                    if (activity.ActivityType == TypeOfActivity.Water)
                        //add to my filtered collection
                        filteredActivities.Add(activity);
                }

                lbxAllActivities.ItemsSource = filteredActivities;
            }
        }
        #endregion

        #region Moving objects buttons

        private void btnMoveRight_Click(object sender, RoutedEventArgs e)
        {
            //referencing the selected object in the listbox
            Activity selected = lbxAllActivities.SelectedItem as Activity;
            //this is run if nothing is selected and the button is clicked
            if (selected == null)
            {
                //creating an error message
                string messageBoxText = "You must select an activity";
                string caption = "Error";
                MessageBox.Show(messageBoxText, caption, MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            else
            {
                //creating if statement to check if date matches a date within the selected listbox
                if(ReservedDates.Contains(selected.ActivityDate))
                {
                    string messageBoxText = "Activity date has been reserved";
                    string caption = "Error";

                    MessageBox.Show(messageBoxText, caption, MessageBoxButton.OK, MessageBoxImage.Warning);
                }
                else
                {
                    //then we add the dates to the new list box and remove from the original list box
                    ReservedDates.Add(selected.ActivityDate);
                    filteredSecondaryActivities.Add(selected);
                    FillList.Remove(selected);

                    //the total cost is updated
                    TotalCost += selected.Cost;
                    tblkTotalCost.Text = Convert.ToString(TotalCost);
                }
            }
            
        }
    
        private void btnMoveLeft_Click(object sender, RoutedEventArgs e)
        {
            Activity selected = lbxSelectedActivities.SelectedItem as Activity;
            if (selected == null)
            {
                string messageBoxText = "You must select an activity";
                string caption = "Error";
                MessageBox.Show(messageBoxText, caption, MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            else
            {
                
                FillList.Add(selected);
                filteredSecondaryActivities.Remove(selected);

                TotalCost -= selected.Cost;
                tblkTotalCost.Text = Convert.ToString(TotalCost);
            }
        }
        #endregion

        private void lbxAllActivities_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            #region Activity description
            //Selected object is named 
            Activity selected = lbxAllActivities.SelectedItem as Activity;

            //As long as null was not selected the description is outputted to the description textblock
            if (selected != null) tblkDescription.Text = selected.Description;
            #endregion
        }
    }
}
