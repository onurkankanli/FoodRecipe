# FoodRecipe
C# .NET WPF Application for food recipes with filtering the food for all Categories, Area, Ingredients

I am using the MealDB API for gathering the data into my project, Link of API: https://www.themealdb.com/api.php

API Methods using the developer test key '1' as the API key

Search meal by name
www.themealdb.com/api/json/v1/1/search.php?s=Arrabiata

List all meals by first letter
www.themealdb.com/api/json/v1/1/search.php?f=a

Lookup full meal details by id
www.themealdb.com/api/json/v1/1/lookup.php?i=52772

Lookup a single random meal
www.themealdb.com/api/json/v1/1/random.php

Lookup a selection of 10 random meals (only available to $2+ Paypal supporters)
www.themealdb.com/api/json/v1/1/randomselection.php

List all meal categories
www.themealdb.com/api/json/v1/1/categories.php

Latest Meals (only available to $2+ Paypal supporters)
www.themealdb.com/api/json/v1/1/latest.php

List all Categories, Area, Ingredients
www.themealdb.com/api/json/v1/1/list.php?c=list
www.themealdb.com/api/json/v1/1/list.php?a=list
www.themealdb.com/api/json/v1/1/list.php?i=list

Filter by main ingredient
www.themealdb.com/api/json/v1/1/filter.php?i=chicken_breast

Filter by multi-ingredient (only available to $2+ Paypal supporters)
www.themealdb.com/api/json/v1/1/filter.php?i=chicken_breast,garlic,salt

Filter by Category
www.themealdb.com/api/json/v1/1/filter.php?c=Seafood

Filter by Area
www.themealdb.com/api/json/v1/1/filter.php?a=Canadian

 Images
Meal Thumbnail Images
Add /preview to the end of the meal image URL
/images/media/meals/llcbn01574260722.jpg/preview

Ingredient Thumbnail Images
www.themealdb.com/images/ingredients/Lime.png
www.themealdb.com/images/ingredients/Lime-Small.png
