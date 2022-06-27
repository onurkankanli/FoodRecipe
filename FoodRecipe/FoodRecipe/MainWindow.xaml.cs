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
    
    public class TableInfo
    {
        //list of dictinoaries for storing all categories, areas, ingredients when the page starts
        public List<Dictionary<string, string>> allCategories = new List<Dictionary<string, string>>();
        public List<Dictionary<string,string>> allAreas = new List<Dictionary<string,string>>();
        public List<Dictionary<string, string>> allIng = new List<Dictionary<string, string>>();
    }
    public class FoodModel1
    {
        //fields of the live table
        public string MealName { get; set; }
        public string MealId { get; set; }
        public string ImgSrc { get; set; }
    }
    public partial class MainWindow : Window
    {
        public SearchProcessor foodnamesearch = new SearchProcessor();
       
        public MainWindow()
        {
            InitializeComponent();
            //initializes our http client
            ApiHelper.InitializeClient();

            LoadOnStart();
        }
        //creating a new instance of TableInfo class
        public TableInfo tableInfo = new TableInfo();

        public async void LoadOnStart()
        {
            //creating a task with a type: list of dictionaries
            Task<List<Dictionary<string, string>>> CatTask = LoadAllCategories();
            Task<List<Dictionary<string, string>>> AreaTask = LoadAllAreas();
            Task<List<Dictionary<string, string>>> IngTask = LoadAllIng();
            
            //waiting for the results and storing the task results in the list of dictionaries created in TableInfo class
            tableInfo.allCategories = await CatTask;
            tableInfo.allAreas = await AreaTask;
            tableInfo.allIng = await IngTask;
        }
     
        public void comboBox_KeyUp(object sender, KeyEventArgs e)
        {
            //initializing new instance of SearchProcessor class
            SearchProcessor myCatSearch = new SearchProcessor();

            var combobox = (ComboBox)sender;
            //ctb is the input from user
            var ctb = combobox.Template.FindName("PART_EditableTextBox", combobox) as TextBox;

            //if the items of combobox is empty add the contents to the combobox
            if (combobox.Items.IsEmpty)
            {
                //the items of the combobox dropdown are added, creating mitem with a type of dictionary
                foreach (Dictionary<string, string> mitem in tableInfo.allCategories)
                {
                    //intializes new item in combobox
                    ComboBoxItem item = new ComboBoxItem();
                    //setting the content of the item with the current category
                    item.Content = mitem["strCategory"];
                    //we are labeling the dropdown item with a tag, so we know where to search from when it is selected
                    item.Tag = "category";
                    //adding the item to the Items of combobox
                    combobox.Items.Add(item);
                }
                foreach (Dictionary<string, string> mitem in tableInfo.allAreas)
                {
                    ComboBoxItem item = new ComboBoxItem();
                    item.Content = mitem["strArea"];
                    item.Tag = "area";
                    combobox.Items.Add(item);
                }
                foreach (Dictionary<string, string> mitem in tableInfo.allIng)
                {
                    ComboBoxItem item = new ComboBoxItem();
                    item.Content = mitem["strIngredient"];
                    item.Tag = "ingredient";
                    combobox.Items.Add(item);
                }
            }

            //if there is no input go outside the function and wait for input
            if (ctb == null) return;

            if (Keyboard.Modifiers.HasFlag(ModifierKeys.Shift) || Keyboard.Modifiers.HasFlag(ModifierKeys.Control) || Keyboard.Modifiers.HasFlag(ModifierKeys.Alt))
                return;

            var caretPos = ctb.CaretIndex;
            combobox.IsDropDownOpen = true;
            
            //adding all the current items we have in combobox into itemsViewOriginal
            CollectionView itemsViewOriginal = (CollectionView)CollectionViewSource.GetDefaultView(combobox.Items);
            //creating o object for loop through items
            itemsViewOriginal.Filter = ((o) =>
            {
                //checks if there is no text input in combobox
                if (String.IsNullOrEmpty(combobox.Text))
                {
                    //keep the items in the list
                    return true;
                }
                else
                {
                    //if combobox item contains the combobox.Text(user input string) keep it in the dropdown list
                    //if item in my combobox contains the user input string
                    if (((ComboBoxItem)o).Content.ToString().Contains(combobox.Text))
                    {
                        //keep the items in the list
                        return true;
                    }
                    else
                    {
                        //delete the items from the list
                        return false;
                    }
                }
            });

            //refresh the items in the list
            itemsViewOriginal.Refresh();
            ctb.CaretIndex = caretPos;
        }

        //function executes when something is selected form list view
        private void SelectedMeal(object sender, SelectionChangedEventArgs e)
        {
            //takes the selected item's info from the even arguments and assigns it to instance of foodmodel1
            ListView lv = e.OriginalSource as ListView;
            
            //we are taking the SelectedItem as a instance of our class
            FoodModel1 ftoselect = lv.SelectedItem as FoodModel1;
            
            //we are passing the MealName to our MealDisplay screen
            MealDisplay mealDisplay = new MealDisplay(ftoselect.MealName);

            //we need Begin initialization to let the screen start
            //mealDisplay.BeginInit();
            mealDisplay.Show();
           
            this.Close();
        }

        private async void comboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //if the selected is not null
            if (comboBox.SelectedItem != null)
            {
                //setting cbi as our selected item
                ComboBoxItem cbi = (ComboBoxItem)comboBox.SelectedItem;

                //storing the selected items name in string
                string selectedText = cbi.Content.ToString();

                //the list in contains the meal id, thumbnail picture, and a meal name
                List<Dictionary<string,string>> deneme = await SearchByTag(cbi);
                //passing the list deneme into DisplayInList function
                DisplayInList(deneme);
            }
        }

        //function to display the meals to select from a list 
        //everytime a selection is made, this function is called to update
        public void DisplayInList(List<Dictionary<string, string>> deneme)
        {
            //created a list of food model
            List<FoodModel1> items = new List<FoodModel1>();

            //looping to add List dictionary deneme into item
            foreach (Dictionary<string, string> item in deneme)
            {
                //creating a new instance of foodmodel1 since the fields insıde this class are to be binded to xaml
                FoodModel1 foodModel = new FoodModel1();
                //setting the MealName, MealId, ImgSrc fields of the foodmodel instance to the correspondıng values in item (a dictionary)
                foodModel.MealName = item["strMeal"];
                foodModel.MealId = item["idMeal"];
                foodModel.ImgSrc = item["strMealThumb"];

                //adding all the the fields of our table into items list which is type of FoodModel
                items.Add(foodModel);
            }
            //adding list of objects(MealName, Meal) to the list
            FoodList.ItemsSource = items;
        }

        private async Task<List<Dictionary<string, string>>> SearchByTag(ComboBoxItem cbi)
        {
            //if the selected content or tag is NOT null or empty
            if ( (!string.IsNullOrEmpty(cbi.Content.ToString())) && (!string.IsNullOrEmpty(cbi.Tag.ToString()) ))
            {
                //if tag of our item is category
                if (cbi.Tag.ToString() == "category")
                {
                    //takes the data with the choosen category
                    List<Dictionary<string, string>> sByCat = await SearchProcessor.LoadSearchByCategory(cbi.Content.ToString());

                    return sByCat;
                    
                }else if (cbi.Tag.ToString() == "area")
                {
                    //takes the data with the choosen area
                    var sByArea = await SearchProcessor.LoadSearchByArea(cbi.Content.ToString());

                    return sByArea;
                    
                }else if (cbi.Tag.ToString() == "ingredient")
                {
                    //takes the data with the given ingredient
                    List<Dictionary<string, string>> sByIng = await SearchProcessor.LoadSearchByIng(cbi.Content.ToString());

                    return sByIng;
                }
                //if none of the if conditions above are true, then send empty list
                else
                {
                    //send empty list
                    List<Dictionary<string, string>> sByIng = new List<Dictionary<string, string>>();

                    return sByIng;
                }
            }
            else
            {
                //if selected item is null or empty, send an empty list 
                List<Dictionary<string, string>> sByIng = new List<Dictionary<string, string>>();
 
                return sByIng;
            }
        }

        private async Task<List<Dictionary<string, string>>> LoadAllCategories()
        {
            List<Dictionary<string, string>> categories = await SearchProcessor.LoadSearchAllCategories();

            return categories;
        }
        private async Task<List<Dictionary<string, string>>> LoadAllAreas()
        {
            List<Dictionary<string, string>> areas = await SearchProcessor.LoadSearchAllAreas();

            return areas;
        }
        private async Task<List<Dictionary<string, string>>> LoadAllIng()
        {
            List<Dictionary<string, string>> ingredients = await SearchProcessor.LoadSearchAllIngs();
            return ingredients;
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
