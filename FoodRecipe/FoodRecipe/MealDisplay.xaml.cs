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
using FoodRecipe.API_Handling;

namespace FoodRecipe
{
    /// <summary>
    /// Interaction logic for MealDisplay.xaml
    /// </summary>
    public partial class MealDisplay : Window
    {
        SearchProcessor searchme = new SearchProcessor();

        public List<FoodModel> MealList = new List<FoodModel>();

        public MealDisplay()
        {
            InitializeComponent();

            ApiHelper.InitializeClient();

            DisplayMeal("Arrabiata");
        }
        public async void DisplayMeal(string foodname)
        {
            Task<List<FoodModel>> MealTask = DisplayMealTask(foodname);

            MealList = await MealTask;
        }
        private async Task<List<FoodModel>> DisplayMealTask(string foodname)
        {
            //creating a list of dates with a type of datamodel which is going to call LoadDate function from DateProcessor with the logged in user_id and selected date
            List<FoodModel> dates = await SearchProcessor.LoadSearchByName(foodname);

            return dates;
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            MainWindow main = new MainWindow();
            main.Show();

            this.Close();

        }
    }
}
