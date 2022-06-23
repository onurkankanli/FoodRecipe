using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodRecipe.API_Handling
{
    public class FoodModel
    {
        public Dictionary<string, string> myDictionary { get; set;}
        public int idMeal { get; set; }
        public string strMeal { get; set; }
        public string strDrinkAlternate { get; set; } // TODO: what to do when null
        public string strCategory { get; set; }
        public string strArea { get; set; }
        public string strInstructions { get; set; }
        public string strMealThumb { get; set; }
        public string strTags { get; set; }
        public string strYoutube { get; set; }
        public string[] strIngredient { get; set; }
        public string[] strMeasure { get; set; }
        public string strSource { get; set; }
        public string strImageSource { get; set; }
        public bool? strCreativeCommonsConfirmed { get; set; }
        public DateTime? dateModified { get; set; }
        
    }
}
