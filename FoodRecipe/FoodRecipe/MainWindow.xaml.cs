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
using FoodRecipe.API_Handling;

namespace FoodRecipe
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

        public SearchProcessor foodnamesearch = new SearchProcessor();

        private void btnSearch_Click(object sender, RoutedEventArgs e)
        {
            MealDisplay showmefood = new MealDisplay();
            showmefood.Show();

            this.Close();
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            WelcomeWindow welcome = new WelcomeWindow();
            welcome.Show();

            this.Close();
        }

        private void btnQuit_Click(object sender, RoutedEventArgs e)
        {
            //application shuts down when the button is pressed
            Application.Current.Shutdown();
        }
    }
}
