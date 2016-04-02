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
using System.Data.SqlClient;

namespace IH_Restaurant_POS
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

        

        private void fillSideBar(string[] txtFile, ListBox sideBar)
        {
            foreach (string s in txtFile)
            {
                sideBar.Items.Add(s);
            }            
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {            

            fillSideBar(Properties.Resources.Menu_Bev_lbSideBarItems.Split('_'), Menu_Bev_lbSideBar);

            fillSideBar(Properties.Resources.Menu_App_lbSideBarItems.Split('_'), Menu_App_lbSideBar);

            fillSideBar(Properties.Resources.Menu_Dessert_lbSideBarItems.Split('_'), Menu_Dessert_lbSideBar);

            fillSideBar(Properties.Resources.Menu_Entree_lbSideBarItems.Split('_'), Menu_Entree_lbSideBar);


            FoodItem burger = new FoodItem("Burger", 7.99);
            FoodOption newOption = new FoodOption("Cheese", .15);
            burger.AddFoodOption(newOption);
            newOption = new FoodOption("Onions", 0);
            burger.AddFoodOption(newOption);
            FoodItem soda = new FoodItem("Soda", 1.50);
            FoodItem cheesecake = new FoodItem("Cheese Cake", 5.25);
            newOption = new FoodOption("Cherries", 0);
            cheesecake.AddFoodOption(newOption);
            FoodItem steak = new FoodItem("Steak", 12.75);
            newOption = new FoodOption("Medium", 0);
            steak.AddFoodOption(newOption);

            Bill cust1 = new Bill(1);
            cust1.AddFoodToBill(burger);
            cust1.AddFoodToBill(soda);
            cust1.AddFoodToBill(cheesecake);

            Bill cust2 = new Bill(2);
            cust2.AddFoodToBill(steak);
            cust2.AddFoodToBill(soda);

            Table table11 = new Table(11);
            table11.AddGuest(cust1);
            table11.AddGuest(cust2);

            foreach (String s in table11.PrintRecipt(new int[] { 1, 2 }))
            {
                lbBill.Items.Add(s);
            }

            Server Bryan = new Server("Bryan", 12345);
            Bryan.AddTable(table11);

            statusBar.Content = Bryan.Name + " - Table: " + table11.Number + " - Bill: " + table11.TotalBill.ToString("c") + " - Recipt Number: " + table11.BillNumber;

        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            Properties.Settings.Default.Save();
        }

        ///////////////////////////////////////////////////////////////////////////////////////
        /// <summary>
        /// Set Z Index for Menu Window
        /// </summary>
        /// <param name="aw">App Window</param>
        /// <param name="ew">Entree Window</param>
        /// <param name="dw">Dessert Window</param>
        /// <param name="bw">Bev Window</param>
        private void setZIndex(int aw, int ew, int dw, int bw)
        {
            Canvas.SetZIndex(App_Window, aw);
            Canvas.SetZIndex(Entree_Window, ew);
            Canvas.SetZIndex(Dessert_Window, dw);
            Canvas.SetZIndex(Bev_Window, bw);
        }

        /// <summary>
        /// App Tap Selected
        /// User Presses the Appitizer Tab
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void App_Tab_MouseDown(object sender, MouseButtonEventArgs e)
        {
            setZIndex(1, 0, 0, 0);  //Call setZIndex Method        
        }

        /// <summary>
        /// Entree Tab Selected
        /// User Presses the Entree Tab
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Entree_Tab_MouseDown(object sender, MouseButtonEventArgs e)
        {
            setZIndex(0, 1, 0, 0); //Call setZIndex Method
        }

        /// <summary>
        /// Dessert Tap Selected
        /// User Presses the Dessert Tab
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Dessert_Tab_MouseDown(object sender, MouseButtonEventArgs e)
        {
            setZIndex(0, 0, 1, 0); //Call setZIndex Method
        }

        /// <summary>
        /// Beverage Tap Selected
        /// User Presses the Beverage Tab
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Bev_Tab_MouseDown(object sender, MouseButtonEventArgs e)
        {
            setZIndex(0, 0, 0, 1); //Call setZIndex Method

        }

        ///////////////////////////////////////////////////////////////////////////////////////
        /// <summary>
        /// Sidebar Select Change Method
        /// Changes the Menu Label to the Selected Sidebar text
        /// </summary>
        /// <param name="winLabel">Menu Window Label</param>
        /// <param name="sideBar">Menu Sidebar</param>
        private void sideBarSelectionChange(Label winLabel, ListBox sideBar)
        {
            winLabel.Content = sideBar.Items.GetItemAt(sideBar.SelectedIndex);
        }

        /// <summary>
        /// Beverage Menu SideBar Change Event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Menu_Bev_lbSideBar_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            sideBarSelectionChange(Menu_Bev_labelWindow, Menu_Bev_lbSideBar);
        }

        /// <summary>
        /// Dessert Menu SideBar Change Event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Menu_Dessert_lbSideBar_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            sideBarSelectionChange(Menu_Dessert_labelWindow, Menu_Dessert_lbSideBar);
        }

        /// <summary>
        /// Entree Menu Sidebar Change
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Menu_Entree_lbSideBar_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            sideBarSelectionChange(Menu_Entree_labelWindow, Menu_Entree_lbSideBar);
        }

        /// <summary>
        /// Appitzer Menu Sidebar Change Event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Menu_App_lbSideBar_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            sideBarSelectionChange(Menu_App_labelWindow, Menu_App_lbSideBar);
        }
        
    }

}
