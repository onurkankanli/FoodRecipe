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
    /// 
    public class TableInfo
    {
        public List<Dictionary<string, string>> allCategories = new List<Dictionary<string, string>>();
        public List<Dictionary<string,string>> allAreas = new List<Dictionary<string,string>>();
        public List<Dictionary<string, string>> allIng = new List<Dictionary<string, string>>();
    }
    public class FoodModel1 {
        public string MealName { get; set; }
        public string MealId { get; set; }
        public string ImgSrc { get; set; }

    }
    public partial class MainWindow : Window
    {
        public SearchProcessor foodnamesearch = new SearchProcessor();
        public string sResult;
        public MainWindow()
        {
            InitializeComponent();
            ApiHelper.InitializeClient();
            LoadOnStart();
        }
        public TableInfo tableInfo = new TableInfo();


        public async void LoadOnStart()
        {
            List<Dictionary<string, string>> CatList = new List<Dictionary<string, string>>();

            List<Dictionary<string, string>> AreaList = new List<Dictionary<string, string>>();
            List<Dictionary<string, string>> IngList = new List<Dictionary<string, string>>();


            Task<List<Dictionary<string, string>>> CatTask = LoadAllCategories();
            Task<List<Dictionary<string, string>>> AreaTask = LoadAllAreas();
            Task<List<Dictionary<string, string>>> IngTask = LoadAllIng();

            tableInfo.allCategories = await CatTask;
            tableInfo.allAreas = await AreaTask;
            tableInfo.allIng = await IngTask;


        }
     
        public void comboBox_KeyUp(object sender, KeyEventArgs e)
        {
            SearchProcessor myCatSearch = new SearchProcessor();
            //  MealDisplay categoryDisplay = new MealDisplay();
            comboBox.Items.Clear();
            var combobox = (ComboBox)sender;
            var ctb = combobox.Template.FindName("PART_EditableTextBox", combobox) as TextBox;
            foreach (Dictionary<string, string> mitem in tableInfo.allCategories)
            {
                ComboBoxItem item = new ComboBoxItem();
                item.Content = mitem["strCategory"];
                item.Tag = "category";
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

            if (ctb == null) return;
            if (Keyboard.Modifiers.HasFlag(ModifierKeys.Shift) || Keyboard.Modifiers.HasFlag(ModifierKeys.Control) || Keyboard.Modifiers.HasFlag(ModifierKeys.Alt))
                return;
            var caretPos = ctb.CaretIndex;
            combobox.IsDropDownOpen = true;
            //tableInfo.allCategories;
            //combobox.Items.Add();

            CollectionView itemsViewOriginal = (CollectionView)CollectionViewSource.GetDefaultView(combobox.Items);
            itemsViewOriginal.Filter = ((o) =>
            {
                if (String.IsNullOrEmpty(combobox.Text))
                {
                    return true;
                }
                else
                {
                    if (((ComboBoxItem)o).Content.ToString().Contains(combobox.Text))
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            });

            itemsViewOriginal.Refresh();
            ctb.CaretIndex = caretPos;
           

        }
        private void SelectedMeal(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            ListView lv = e.OriginalSource as ListView;
            ListViewItem lvi = lv.SelectedItem as ListViewItem;
            FoodModel1 ftoselect = lv.SelectedItem as FoodModel1;
            //ftoselect = lv.SelectedItem;
          
            MealDisplay mealDisplay = new MealDisplay(ftoselect.MealName);
            mealDisplay.BeginInit();
            mealDisplay.Show();
           
            this.Close();
        }
        private async void comboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (comboBox.SelectedItem != null)
            {
                //ComboBoxItem cbi1 = (ComboBoxItem)(sender as ComboBox).SelectedItem;
                ComboBoxItem cbi = (ComboBoxItem)comboBox.SelectedItem;
                string selectedText = cbi.Content.ToString();
                List<Dictionary<string,string>> deneme= await SearchByTag(cbi);
                DisplayInList(deneme);
            }
            // I need to call something to update a table with the meal categories or areas or ingredients.

        }
        public FoodModel1 listItemObjs = new FoodModel1();
      public void DisplayInList(List<Dictionary<string, string>> deneme)
        {
            List<FoodModel1> items = new List<FoodModel1>();
            //List<User> items = new List<User>();
            foreach (Dictionary<string, string> item in deneme)
            {
                items.Add(new FoodModel1() { MealName = item["strMeal"], MealId = item["idMeal"], ImgSrc = item["strMealThumb"] });
            }
            lvUsers.ItemsSource = items;

        }
        private async Task<List<Dictionary<string, string>>> SearchByTag(ComboBoxItem cbi)
        {
            if ( (!string.IsNullOrEmpty(cbi.Content.ToString())) && (!string.IsNullOrEmpty(cbi.Tag.ToString()) ))
                {
                if (cbi.Tag.ToString() == "category")
                {
                    List<Dictionary<string, string>> sByCat = await SearchProcessor.LoadSearchByCategory(cbi);
                    return sByCat;
                    // List<Dictionary<string, string>> ListByCat = await sByCat;
                }else if (cbi.Tag.ToString() == "area")
                {
                    //List<Dictionary<string, string>> sByArea = await SearchProcessor.LoadSearchByArea(cbi.Content.ToString());
                    var sByArea = await SearchProcessor.LoadSearchByArea(cbi.Content.ToString());
                    return sByArea;
                    //  List<Dictionary<string, string>> ListByArea = await sByArea;
                } else if (cbi.Tag.ToString() == "ingredient")
                {
                    List<Dictionary<string, string>> sByIng = await SearchProcessor.LoadSearchByIng(cbi);
                    return sByIng;
                    //   List<Dictionary<string, string>> ListByIng = await sByIng;
                }
                else
                {
                    List<Dictionary<string, string>> sByIng = await SearchProcessor.LoadSearchAllAreas();
                    return sByIng;
                }
            }
            else
            {
                List<Dictionary<string, string>> sByIng = await SearchProcessor.LoadSearchAllAreas();
                return sByIng;
            }
        }



        private async Task<List<Dictionary<string, string>>> LoadAllCategories()
        {
            //creating a list of dates with a type of datamodel which is going to call LoadDate function from DateProcessor with the logged in user_id and selected date
            List<Dictionary<string, string>> categories = await SearchProcessor.LoadSearchAllCategories();

            return categories;
        }
        private async Task<List<Dictionary<string, string>>> LoadAllAreas()
        {
            //creating a list of dates with a type of datamodel which is going to call LoadDate function from DateProcessor with the logged in user_id and selected date
            List<Dictionary<string, string>> categories = await SearchProcessor.LoadSearchAllAreas();

            return categories;
        }
        private async Task<List<Dictionary<string, string>>> LoadAllIng()
        {
            List<Dictionary<string, string>> categories = await SearchProcessor.LoadSearchAllIngs();
            return categories;
        }
        private void btnSearch_Click(object sender, RoutedEventArgs e)
        {
            MealDisplay showmefood = new MealDisplay("Arabiatta");
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
