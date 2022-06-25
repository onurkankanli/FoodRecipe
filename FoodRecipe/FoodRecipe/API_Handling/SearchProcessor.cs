using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace FoodRecipe.API_Handling
{

    public class SearchProcessor
    {
        public async static Task<List<Dictionary<string, string>>> LoadSearchByName(string foodname)
        {
            //creating empty url string
            string url = "";

          //  List<FoodModel> myList = new List<FoodModel>();

            url = $"https://www.themealdb.com/api/json/v1/1/search.php?s={foodname}";

            using (HttpResponseMessage response = await ApiHelper.ApiClient.GetAsync(url))
            {
                //if response was successful
                if (response.IsSuccessStatusCode)
                {
                    string data = await response.Content.ReadAsStringAsync();
                    List<Dictionary<string, string>> hisDictionary = new List<Dictionary<string, string>>();
                    // we are receiving our response in a dictionary with key "meals" and value as a list of dictionaries (also called key-value pairs)

                    var herDictionary = JsonConvert.DeserializeObject<Dictionary<string,List<Dictionary<string , string>>>>(data);
                    // we are assigning hisDictionary to a list of dicitonaries obtained from JSon. This dictionary has the keys such as ingredients, food name
                    // and corresponding values. This is because the value of the key "meals", was a list of { key: value} type of structures. 
                    hisDictionary = herDictionary["meals"];
                  // we are returning a list of dictionaries (key value pairs)
                    return hisDictionary;
                }
                else
                {
                    throw new Exception(response.ReasonPhrase);
                }
            }
        }
        public async static Task<List<Dictionary<string, string>>> LoadSearchAllCategories()
        {
            //creating empty url string
            string url1;//,url2,url3;
            url1 = $"https://www.themealdb.com/api/json/v1/1/list.php?c=list";
       //     url2 = $"https://www.themealdb.com/api/json/v1/1/list.php?a=list";
         //   url3 = $"https://www.themealdb.com/api/json/v1/1/list.php?i=list";
            using (HttpResponseMessage response = await ApiHelper.ApiClient.GetAsync(url1))
            {
                //if response was successful
                if (response.IsSuccessStatusCode)
                {
                    string data = await response.Content.ReadAsStringAsync();
                    List<Dictionary<string, string>> hisDictionary = new List<Dictionary<string, string>>();
                    // we are receiving our response in a dictionary with key "meals" and value as a list of dictionaries (also called key-value pairs)
                    var herDictionary = JsonConvert.DeserializeObject<Dictionary<string, List<Dictionary<string, string>>>>(data);
                    // we are assigning hisDictionary to a list of dicitonaries obtained from JSon. This dictionary has the keys such as ingredients, food name
                    // and corresponding values. This is because the value of the key "meals", was a list of { key: value} type of structures. 
                    hisDictionary = herDictionary["meals"];
                    // we are returning a list of dictionaries (key value pairs)
                    return hisDictionary;
                }
                else
                {
                    throw new Exception(response.ReasonPhrase);
                }
            }
        }
        public async static Task<List<Dictionary<string, string>>> LoadSearchAllIngs()
        {
            //creating empty url string
            string url1;
            url1 = $"https://www.themealdb.com/api/json/v1/1/list.php?i=list";
            //    url2 = $"www.themealdb.com / api / json / v1 / 1 / list.php ? a = list";
            //   url3 = $"www.themealdb.com / api / json / v1 / 1 / list.php ? i = list";
            using (HttpResponseMessage response = await ApiHelper.ApiClient.GetAsync(url1))
            {
                //if response was successful
                if (response.IsSuccessStatusCode)
                {
                    string data = await response.Content.ReadAsStringAsync();
                    List<Dictionary<string, string>> hisDictionary = new List<Dictionary<string, string>>();
                    // we are receiving our response in a dictionary with key "meals" and value as a list of dictionaries (also called key-value pairs)
                    var herDictionary = JsonConvert.DeserializeObject<Dictionary<string, List<Dictionary<string, string>>>>(data);
                    // we are assigning hisDictionary to a list of dicitonaries obtained from JSon. This dictionary has the keys such as ingredients, food name
                    // and corresponding values. This is because the value of the key "meals", was a list of { key: value} type of structures. 
                    hisDictionary = herDictionary["meals"];
                    // we are returning a list of dictionaries (key value pairs)
                    return hisDictionary;
                }
                else
                {
                    throw new Exception(response.ReasonPhrase);
                }
            }
        }
        public async static Task<List<Dictionary<string, string>>> LoadSearchAllAreas()
        {
            //creating empty url string
            string url1;
            url1 = $"https://www.themealdb.com/api/json/v1/1/list.php?a=list";
            //   url3 = $"www.themealdb.com / api / json / v1 / 1 / list.php ? i = list";
            using (HttpResponseMessage response = await ApiHelper.ApiClient.GetAsync(url1))
            {
                //if response was successful
                if (response.IsSuccessStatusCode)
                {
                    string data = await response.Content.ReadAsStringAsync();
                    List<Dictionary<string, string>> hisDictionary = new List<Dictionary<string, string>>();
                    // we are receiving our response in a dictionary with key "meals" and value as a list of dictionaries (also called key-value pairs)
                    var herDictionary = JsonConvert.DeserializeObject<Dictionary<string, List<Dictionary<string, string>>>>(data);
                    // we are assigning hisDictionary to a list of dicitonaries obtained from JSon. This dictionary has the keys such as ingredients, food name
                    // and corresponding values. This is because the value of the key "meals", was a list of { key: value} type of structures. 
                    hisDictionary = herDictionary["meals"];
                    // we are returning a list of dictionaries (key value pairs)
                    return hisDictionary;
                }
                else
                {
                    throw new Exception(response.ReasonPhrase);
                }
            }
        }


        public async static Task<List<Dictionary<string, string>>> LoadSearchByCategory(ComboBoxItem ing)
        {
            ;
            //creating empty url string
            string url1;
            url1 = $"https://www.themealdb.com/api/json/v1/1/filter.php?c={ing.Content.ToString()}";
            //   url3 = $"www.themealdb.com / api / json / v1 / 1 / list.php ? i = list";
            using (HttpResponseMessage response = await ApiHelper.ApiClient.GetAsync(url1))
            {
                //if response was successful
                if (response.IsSuccessStatusCode)
                {
                    string data = await response.Content.ReadAsStringAsync();
                    List<Dictionary<string, string>> hisDictionary = new List<Dictionary<string, string>>();
                    // we are receiving our response in a dictionary with key "meals" and value as a list of dictionaries (also called key-value pairs)
                    var herDictionary = JsonConvert.DeserializeObject<Dictionary<string, List<Dictionary<string, string>>>>(data);
                    // we are assigning hisDictionary to a list of dicitonaries obtained from JSon. This dictionary has the keys such as ingredients, food name
                    // and corresponding values. This is because the value of the key "meals", was a list of { key: value} type of structures. 
                    hisDictionary = herDictionary["meals"];
                    // we are returning a list of dictionaries (key value pairs)
                    return hisDictionary;
                }
                else
                {
                    throw new Exception(response.ReasonPhrase);
                }
            }
        }


        //LoadSearchByArea
        public async static Task<List<Dictionary<string, string>>> LoadSearchByArea(string ing)
        {
            ;
            //creating empty url string
            string url1;
            //string area = ing.Content.ToString();
            url1 = $"https://www.themealdb.com/api/json/v1/1/filter.php?a={ing}";
            //   url3 = $"www.themealdb.com / api / json / v1 / 1 / list.php ? i = list";
            using (HttpResponseMessage response = await ApiHelper.ApiClient.GetAsync(url1))
            {
                //if response was successful
                if (response.IsSuccessStatusCode)
                {
                    string data = await response.Content.ReadAsStringAsync();
                    List<Dictionary<string, string>> hisDictionary = new List<Dictionary<string, string>>();
                    // we are receiving our response in a dictionary with key "meals" and value as a list of dictionaries (also called key-value pairs)
                    var herDictionary = JsonConvert.DeserializeObject<Dictionary<string, List<Dictionary<string, string>>>>(data);
                    // we are assigning hisDictionary to a list of dicitonaries obtained from JSon. This dictionary has the keys such as ingredients, food name
                    // and corresponding values. This is because the value of the key "meals", was a list of { key: value} type of structures. 
                    hisDictionary = herDictionary["meals"];
                    // we are returning a list of dictionaries (key value pairs)
                    return hisDictionary;
                }
                else
                {
                    throw new Exception(response.ReasonPhrase);
                }
            }
        }
        //LoadSearchByIng
        public async static Task<List<Dictionary<string, string>>> LoadSearchByIng(ComboBoxItem ing)
        {
            ;
            //creating empty url string
            string url1;
            url1 = $"https://www.themealdb.com/api/json/v1/1/filter.php?i={ing.Content.ToString()}";
            //   url3 = $"www.themealdb.com / api / json / v1 / 1 / list.php ? i = list";
            using (HttpResponseMessage response = await ApiHelper.ApiClient.GetAsync(url1))
            {
                //if response was successful
                if (response.IsSuccessStatusCode)
                {
                    string data = await response.Content.ReadAsStringAsync();
                    List<Dictionary<string, string>> hisDictionary = new List<Dictionary<string, string>>();
                    // we are receiving our response in a dictionary with key "meals" and value as a list of dictionaries (also called key-value pairs)
                    var herDictionary = JsonConvert.DeserializeObject<Dictionary<string, List<Dictionary<string, string>>>>(data);
                    // we are assigning hisDictionary to a list of dicitonaries obtained from JSon. This dictionary has the keys such as ingredients, food name
                    // and corresponding values. This is because the value of the key "meals", was a list of { key: value} type of structures. 
                    hisDictionary = herDictionary["meals"];
                    // we are returning a list of dictionaries (key value pairs)
                    return hisDictionary;
                }
                else
                {
                    throw new Exception(response.ReasonPhrase);
                }
            }
        }
    }



}




