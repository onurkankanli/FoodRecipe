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
        public async static Task<List<FoodModel>> LoadSearchByName(string foodname)
        {
            //creating empty url string
            string url = "";
            List<FoodModel> myList = new List<FoodModel>();

            url = $"https://www.themealdb.com/api/json/v1/1/search.php?s={foodname}";

            using (HttpResponseMessage response = await ApiHelper.ApiClient.GetAsync(url))
            {
                //if response was successful
                if (response.IsSuccessStatusCode)
                {
                    string data = await response.Content.ReadAsStringAsync();

                    // var TemprootOject = JsonConvert.DeserializeObject<RootObject>(data);
                    var myDictionary = JsonConvert.DeserializeObject<Dictionary<string, List<FoodModel>>>(data);
                    myList = myDictionary["meals"];
                    //  myList = rootOject.Fmodel;
                    return myList;
                }
                else
                {
                    throw new Exception(response.ReasonPhrase);
                }
            }
        }
    }
}