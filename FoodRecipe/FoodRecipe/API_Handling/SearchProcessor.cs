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
        //searches for a meal by name
        public async static Task<List<Dictionary<string, string>>> LoadSearchByName(string foodname)
        {
            //creating empty url string
            string url = "";

            url = $"https://www.themealdb.com/api/json/v1/1/search.php?s={foodname}";

            using (HttpResponseMessage response = await ApiHelper.ApiClient.GetAsync(url))
            {
                //if response was successful
                if (response.IsSuccessStatusCode)
                {
                    //store the response in a string called data
                    string data = await response.Content.ReadAsStringAsync();

                    //initializing a new list of dictionaries called hisDictionary
                    List<Dictionary<string, string>> hisDictionary = new List<Dictionary<string, string>>();

                    //we receive a dictionary with a key "meals" and list of dictionaries as a value associated with the key "meals"
                    var herDictionary = JsonConvert.DeserializeObject<Dictionary<string,List<Dictionary<string , string>>>>(data);
                    
                    //we obtain values for the key meals
                    hisDictionary = herDictionary["meals"];
                  
                    //returning hisDictionary
                    return hisDictionary;
                }
                else
                {
                    throw new Exception(response.ReasonPhrase);
                }
            }
        }

        //load data by category
        public async static Task<List<Dictionary<string, string>>> LoadSearchByCategory(string ing)
        {
            //creating empty url string
            string url1;

            url1 = $"https://www.themealdb.com/api/json/v1/1/filter.php?c={ing}";
            
            using (HttpResponseMessage response = await ApiHelper.ApiClient.GetAsync(url1))
            {
                //if response was successful
                if (response.IsSuccessStatusCode)
                {
                    //store the response in a string called data
                    string data = await response.Content.ReadAsStringAsync();

                    //initializing a new list of dictionaries called hisDictionary
                    List<Dictionary<string, string>> hisDictionary = new List<Dictionary<string, string>>();

                    //we receive a dictionary with a key "meals" and list of dictionaries as a value associated with the key "meals"
                    var herDictionary = JsonConvert.DeserializeObject<Dictionary<string, List<Dictionary<string, string>>>>(data);

                    //we obtain values for the key meals
                    hisDictionary = herDictionary["meals"];

                    //returning hisDictionary
                    return hisDictionary;
                }
                else
                {
                    throw new Exception(response.ReasonPhrase);
                }
            }
        }

        //load data by area
        public async static Task<List<Dictionary<string, string>>> LoadSearchByArea(string ing)
        {
            
            //creating empty url string
            string url1;
            ;
            url1 = $"https://www.themealdb.com/api/json/v1/1/filter.php?a={ing}";
            
            using (HttpResponseMessage response = await ApiHelper.ApiClient.GetAsync(url1))
            {
                //if response was successful
                if (response.IsSuccessStatusCode)
                {
                    //store the response in a string called data
                    string data = await response.Content.ReadAsStringAsync();

                    //initializing a new list of dictionaries called hisDictionary
                    List<Dictionary<string, string>> hisDictionary = new List<Dictionary<string, string>>();

                    //we receive a dictionary with a key "meals" and list of dictionaries as a value associated with the key "meals"
                    var herDictionary = JsonConvert.DeserializeObject<Dictionary<string, List<Dictionary<string, string>>>>(data);

                    //we obtain values for the key meals
                    hisDictionary = herDictionary["meals"];

                    //returning hisDictionary
                    return hisDictionary;
                }
                else
                {
                    throw new Exception(response.ReasonPhrase);
                }
            }
        }

        //load data by ingredients
        public async static Task<List<Dictionary<string, string>>> LoadSearchByIng(string ing)
        {
            
            //creating empty url string
            string url1;

            url1 = $"https://www.themealdb.com/api/json/v1/1/filter.php?i={ing}";
            
            using (HttpResponseMessage response = await ApiHelper.ApiClient.GetAsync(url1))
            {
                //if response was successful
                if (response.IsSuccessStatusCode)
                {
                    //store the response in a string called data
                    string data = await response.Content.ReadAsStringAsync();

                    //initializing a new list of dictionaries called hisDictionary
                    List<Dictionary<string, string>> hisDictionary = new List<Dictionary<string, string>>();

                    //we receive a dictionary with a key "meals" and list of dictionaries as a value associated with the key "meals"
                    var herDictionary = JsonConvert.DeserializeObject<Dictionary<string, List<Dictionary<string, string>>>>(data);

                    //we obtain values for the key meals
                    hisDictionary = herDictionary["meals"];

                    //returning hisDictionary
                    return hisDictionary;
                }
                else
                {
                    throw new Exception(response.ReasonPhrase);
                }
            }
        }

        //load all categorie names
        public async static Task<List<Dictionary<string, string>>> LoadSearchAllCategories()
        {
            //creating empty url string
            string url1;

            url1 = $"https://www.themealdb.com/api/json/v1/1/list.php?c=list";

            using (HttpResponseMessage response = await ApiHelper.ApiClient.GetAsync(url1))
            {
                //if response was successful
                if (response.IsSuccessStatusCode)
                {
                    //store the response in a string called data
                    string data = await response.Content.ReadAsStringAsync();

                    //initializing a new list of dictionaries called hisDictionary
                    List<Dictionary<string, string>> hisDictionary = new List<Dictionary<string, string>>();

                    //we receive a dictionary with a key "meals" and list of dictionaries as a value associated with the key "meals"
                    var herDictionary = JsonConvert.DeserializeObject<Dictionary<string, List<Dictionary<string, string>>>>(data);

                    //we obtain values for the key meals
                    hisDictionary = herDictionary["meals"];

                    //returning hisDictionary
                    return hisDictionary;
                }
                else
                {
                    throw new Exception(response.ReasonPhrase);
                }
            }
        }

        //load all ingredient names
        public async static Task<List<Dictionary<string, string>>> LoadSearchAllIngs()
        {
            //creating empty url string
            string url1;

            url1 = $"https://www.themealdb.com/api/json/v1/1/list.php?i=list";
         
            using (HttpResponseMessage response = await ApiHelper.ApiClient.GetAsync(url1))
            {
                //if response was successful
                if (response.IsSuccessStatusCode)
                {
                    //store the response in a string called data
                    string data = await response.Content.ReadAsStringAsync();

                    //initializing a new list of dictionaries called hisDictionary
                    List<Dictionary<string, string>> hisDictionary = new List<Dictionary<string, string>>();

                    //we receive a dictionary with a key "meals" and list of dictionaries as a value associated with the key "meals"
                    var herDictionary = JsonConvert.DeserializeObject<Dictionary<string, List<Dictionary<string, string>>>>(data);
                    
                    //we obtain values for the key meals
                    hisDictionary = herDictionary["meals"];
                    
                    //returning hisDictionary
                    return hisDictionary;
                }
                else
                {
                    throw new Exception(response.ReasonPhrase);
                }
            }
        }

        //load all area names
        public async static Task<List<Dictionary<string, string>>> LoadSearchAllAreas()
        {
            //creating empty url string
            string url1;

            url1 = $"https://www.themealdb.com/api/json/v1/1/list.php?a=list";
            
            using (HttpResponseMessage response = await ApiHelper.ApiClient.GetAsync(url1))
            {
                //if response was successful
                if (response.IsSuccessStatusCode)
                {
                    //store the response in a string called data
                    string data = await response.Content.ReadAsStringAsync();
                    
                    //initializing a new list of dictionaries called hisDictionary
                    List<Dictionary<string, string>> hisDictionary = new List<Dictionary<string, string>>();

                    //we receive a dictionary with a key "meals" and list of dictionaries as a value associated with the key "meals"
                    var herDictionary = JsonConvert.DeserializeObject<Dictionary<string, List<Dictionary<string, string>>>>(data);
                    
                    //we obtain values for the key meals
                    hisDictionary = herDictionary["meals"];

                    //returning hisDictionary
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




