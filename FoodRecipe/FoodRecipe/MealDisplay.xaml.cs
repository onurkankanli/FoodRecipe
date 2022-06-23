using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
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
using MaterialDesignColors;
using MaterialDesignThemes;

namespace FoodRecipe
{
    /// <summary>
    /// Interaction logic for MealDisplay.xaml
    /// </summary>
    /// 
    public class OurIngredients
    {
        public string Ingredients { get; set; }
        public string Measures { get; set; }
        
    }
    public partial class MealDisplay : Window
    {
        SearchProcessor searchme = new SearchProcessor();

        public List<Dictionary<string, string>> MealList = new List<Dictionary<string, string>>();

        public MealDisplay()
        {
            InitializeComponent();

            ApiHelper.InitializeClient();

            DisplayMeal("Croatian lamb peka");
        }
        public async void DisplayMeal(string foodname)
        {
            Task<List<Dictionary<string, string>>> MealTask = DisplayMealTask(foodname);
            MealList = await MealTask;

            Dictionary<string, string> finDict = new Dictionary<string, string>();
            // Meal list currently have only 1 element because we have searched for only one meal
            finDict = MealList[0];

            List<String>  IngredList= new List<string>();
            List<String> MeasList = new List<string>();

            mealTitle.TextWrapping = TextWrapping.Wrap;
            mealTitle.Text = finDict["strMeal"];
            mealID.Text = "Meal ID: "+finDict["idMeal"];

            //findict is a dictionary. A dictionary is a list of key-value pairs. 
            // we are looping through the elements to find the ingredients and 
            // measures. if they are not null, ,we are assigning them to memebers of a list<string>
            string blah;
            foreach(KeyValuePair<string, string> kvp in finDict)
            {
                if (kvp.Key.Contains("Ingredient"))
                {
                    if ((kvp.Value is null) && (kvp.Value.Length <= 1))
                    {
                         blah = "NA";
                    }
                    else
                    {
                        blah = kvp.Value;
                    }
                    IngredList.Add(blah);
                }

                if (kvp.Key.Contains("Measure"))
                {
                    if ((kvp.Value is null) && (kvp.Value.Length <= 1))
                    {
                        blah = "NA";

                    }
                    else
                    {
                        blah=kvp.Value;
                    }
                    MeasList.Add(blah);
                }
            }

           foreach (KeyValuePair<string, string> kvp in finDict)
            {
                if (kvp.Key.Contains("Ingredient"))
                {
                    if(!(kvp.Value is null) && !(kvp.Value.Length ==0))
                    {
                        
                        IngredList.Add(kvp.Value);
                    }
                }
                if(kvp.Key.Contains("Measure"))
                {
                    if (!(kvp.Value is null) && !(kvp.Value.Length ==0))
                    {
                        MeasList.Add(kvp.Value);
                    }
                }
            }

            List<OurIngredients> in1 = new List<OurIngredients>();
            
            for(int i = 0; i < IngredList.Count; i++)
            {
                OurIngredients in2 = new OurIngredients();

                in2.Ingredients = IngredList[i];
                in2.Measures = MeasList[i];
                in1.Add(in2);
            }
          
            if (!(finDict["strDrinkAlternate"] is null) && !(finDict["strDrinkAlternate"].Length ==0))
            {
                TextBox drinkAlt = new TextBox();
                drinkAlt.FontSize = 14;                
                drinkAlt.Background= Brushes.BlanchedAlmond;
                drinkAlt.Text = "Good with : "+ finDict["strDrinkAlternate"];
                myStack.Children.Add(drinkAlt);
            }
            if (!(finDict["strCategory"] is null) && !(finDict["strCategory"].Length ==0))
            {
                TextBox drinkAlt = new TextBox();
                drinkAlt.FontSize = 14;
                drinkAlt.Background = Brushes.BlanchedAlmond;
                drinkAlt.Text = "Category : " + finDict["strCategory"];
                myStack.Children.Add(drinkAlt);
            }
            if (!(finDict["strArea"] is null) && !(finDict["strArea"].Length ==0))
            {
                TextBox drinkAlt = new TextBox();
                drinkAlt.FontSize = 14;
                drinkAlt.Background = Brushes.BlanchedAlmond;
                drinkAlt.Text = "Area : " + finDict["strArea"];
                myStack.Children.Add(drinkAlt);
            }
            if (!(finDict["strTags"] is null) && !(finDict["strTags"].Length ==0))
            {
                TextBox drinkAlt = new TextBox();
                drinkAlt.FontSize = 14;
                drinkAlt.Background = Brushes.BlanchedAlmond;
                drinkAlt.Text = "Key words : " + finDict["strTags"];
                drinkAlt.TextWrapping = TextWrapping.Wrap;
                myStack.Children.Add(drinkAlt);
            }

            BitmapImage bi3 = new BitmapImage();
            bi3.BeginInit();
            bi3.UriSource = new Uri(finDict["strMealThumb"], UriKind.Absolute);
            bi3.EndInit();
            foodIMG.Source = bi3;
            foodIMG.Height = 200;
            foodIMG.Width = 200;
            Instr.FontSize = 14;
            // textwrapping. wrap prevents overflow by wrapping the text within bounds
            Instr.TextWrapping= TextWrapping.Wrap;
            Instr.Text = finDict["strInstructions"];
            InstrGrid.ItemsSource = in1;
          
        }
        private async Task<List<Dictionary<string, string>>> DisplayMealTask(string foodname)
        {
            //creating a list of dates with a type of datamodel which is going to call LoadDate function from DateProcessor with the logged in user_id and selected date
            List<Dictionary<string, string>> dates = await SearchProcessor.LoadSearchByName(foodname);

            return dates;
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            MainWindow main = new MainWindow();
            main.Show();

            this.Close();

        }

        private void btnQuit_Click(object sender, RoutedEventArgs e)
        {
            //application shuts down when the button is pressed
            Application.Current.Shutdown();
        }
    }
}
