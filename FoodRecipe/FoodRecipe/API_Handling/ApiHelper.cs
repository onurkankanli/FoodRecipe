using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http.Headers;

namespace FoodRecipe
{
    public static class ApiHelper
    {
        public static HttpClient ApiClient { get; set; }
        public static void InitializeClient()
        {
            //initialize new instance of http client
            ApiClient = new HttpClient();
            //clears the request headers
            ApiClient.DefaultRequestHeaders.Accept.Clear();
            //it initializes the request headers for json
            ApiClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }
    }





}
