using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

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
    }
}