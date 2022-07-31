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
using System.Net.NetworkInformation;

namespace FoodRecipe
{
    //this class is used to bind and display ingredient's and measure's datagrid
    public class OurIngredients
    {
        //fields of datagrid
        public string Ingredients { get; set; }
        public string Measures { get; set; }
    }

    public partial class MealDisplay : Window
    {
        public MealDisplay(string fname)
        {
            InitializeComponent();
            //initializes our http client
            ApiHelper.InitializeClient();
            
            DisplayMeal(fname);
        }

        //MealList is a list of dictionaries which stores the choosen food's information
        public List<Dictionary<string, string>> MealList = new List<Dictionary<string, string>>();

        //get the information of a meal by meal name and display it's details on the screen
        public async void DisplayMeal(string foodname)
        {
            //creating a task with a type of List of dictionary and waiting for the data from DisplayMealTask with passing in the foodname
            Task<List<Dictionary<string, string>>> MealTask = DisplayMealTask(foodname);
            //waiting and stroring the food data in MealList
            MealList = await MealTask;

            //declaring a new dictionary to store meal details
            Dictionary<string, string> finDict = new Dictionary<string, string>();

            //Meal list currently have only 1 element because we have searched for only one meal, so we are setting the finDict with the choosen food details
            //store first index since we have only 1 food selected
            finDict = MealList[0];

            //setting the text fields of the text blocks for title and id
            mealTitle.TextWrapping = TextWrapping.Wrap;
            mealTitle.Text = finDict["strMeal"];
            mealID.Text = "Meal ID: " + finDict["idMeal"];

            //we need list of strings for ingredients and measures to be displayed on datagrid
            List<String> IngredList = new List<string>();
            List<String> MeasList = new List<string>();

            //findict is a dictionary. A dictionary is a list of key-value pairs. 
            //we are looping through the elements to find the ingredients and measures.
            //if they are not null, we are assigning them to members of a list<string>
            foreach (KeyValuePair<string, string> kvp in finDict)
            {
                //if any of the key's contains ingredient
                if (kvp.Key.Contains("Ingredient"))
                {
                    //and if the value is not null or empty
                    if(!(kvp.Value is null) && !(kvp.Value.Length == 0))
                    {
                        //add the values to IngredList
                        IngredList.Add(kvp.Value);
                    }
                }
                //if any of the key's contains measure
                if (kvp.Key.Contains("Measure"))
                {
                    //and if the value is not null or empty
                    if (!(kvp.Value is null) && !(kvp.Value.Length ==0))
                    {
                        //add the values to MeasList
                        MeasList.Add(kvp.Value);
                    }
                }
            }

            //in1 is a list of objects to be displayed in datagtrid
            List<OurIngredients> in1 = new List<OurIngredients>();
            
            //assigning values to the list of objects to be displayed on datagrid 
            for(int i = 0; i < IngredList.Count; i++)
            {
                //creating a object of OurIngredients to be added to the list
                OurIngredients in2 = new OurIngredients();
                //adding the ingredients and measures to our object
                in2.Ingredients = IngredList[i];
                in2.Measures = MeasList[i];
                //adding our object into the list
                in1.Add(in2);
            }
            //send our list to be displayed on datagrid
            InstrGrid.ItemsSource = in1;

            //the left side of the page is assigned to a vertical stack whose children are handled below
            //checking if values of various keys and displaying them if they are not null or empty
            if (!(finDict["strDrinkAlternate"] is null) && !(finDict["strDrinkAlternate"].Length == 0))
            {
                //creating a new TextBlock for displaying the value and setting some properties
                TextBlock drinkAlt = new TextBlock();
                drinkAlt.FontSize = 14;                
                drinkAlt.Background= Brushes.BlanchedAlmond;
                drinkAlt.Text = "Good with : " + finDict["strDrinkAlternate"];

                //adding textblock to the stack,
                myStack.Children.Add(drinkAlt);
            }
            //checking if values of various keys and displaying them if they are not null or empty
            if (!(finDict["strCategory"] is null) && !(finDict["strCategory"].Length ==0))
            {
                //creating a new TextBlock for displaying the value and setting some properties
                TextBlock drinkAlt = new TextBlock();
                drinkAlt.FontSize = 14;
                drinkAlt.Background = Brushes.BlanchedAlmond;
                drinkAlt.Text = "Category : " + finDict["strCategory"];

                //adding textblock to the stack
                myStack.Children.Add(drinkAlt);
            }
            //checking if values of various keys and displaying them if they are not null or empty
            if (!(finDict["strArea"] is null) && !(finDict["strArea"].Length ==0))
            {
                //creating a new TextBlock for displaying the value and setting some properties
                TextBlock drinkAlt = new TextBlock();
                drinkAlt.FontSize = 14;
                drinkAlt.Background = Brushes.BlanchedAlmond;
                drinkAlt.Text = "Area : " + finDict["strArea"];

                //adding textblock to the stack
                myStack.Children.Add(drinkAlt);
            }
            //checking if values of various keys and displaying them if they are not null or empty
            if (!(finDict["strTags"] is null) && !(finDict["strTags"].Length ==0))
            {
                //creating a new TextBlock for displaying the value and setting some properties
                TextBlock drinkAlt = new TextBlock();
                drinkAlt.FontSize = 14;
                drinkAlt.Background = Brushes.BlanchedAlmond;
                drinkAlt.Text = "Key words : " + finDict["strTags"];
                drinkAlt.TextWrapping = TextWrapping.Wrap;

                //adding textblock to the stack
                myStack.Children.Add(drinkAlt);
            }

            //creating a new instance of a bitmapimage
            BitmapImage FoodImage = new BitmapImage();
            //initializing the image
            FoodImage.BeginInit();
            //source of the image
            FoodImage.UriSource = new Uri(finDict["strMealThumb"], UriKind.Absolute);
            FoodImage.EndInit();

            //setting properties of the image for the xaml
            //foodIMG in xaml
            foodIMG.Source = FoodImage;
            foodIMG.Height = 200;
            foodIMG.Width = 200;

            //setting fontsize for the recipe instructions area at the bottom of the page
            Recipe_Instructions.FontSize = 14;

            // textwrapping. wrap prevents overflow by wrapping the text within bounds
            Recipe_Instructions.TextWrapping= TextWrapping.Wrap;
            Recipe_Instructions.Text = finDict["strInstructions"];
        }

        //its a task that gets the information of a meal by food name
        private async Task<List<Dictionary<string, string>>> DisplayMealTask(string foodname)
        {
           
            //creating a list of dictionary called data whivh will get the food information with the taken food name
            List<Dictionary<string, string>> getmefooooood = await SearchProcessor.LoadSearchByName(foodname);

            return getmefooooood;          
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
