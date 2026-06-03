namespace CookmanAi;

public partial class RecipeResultsPage : ContentPage
{
    public RecipeResultsPage()
    {
        InitializeComponent();

        // Placeholder recipe data for Sprint 1
        var recipes = new List<RecipeResult>
        {
            new RecipeResult { Name = "Spaghetti Carbonara",     Category = "Quick & Easy",  CardColor = "#FFE0B2" },
            new RecipeResult { Name = "Veggie Stir Fry",         Category = "Quick & Easy",  CardColor = "#FFE0B2" },
            new RecipeResult { Name = "Scrambled Eggs & Toast",  Category = "Quick & Easy",  CardColor = "#FFE0B2" },
            new RecipeResult { Name = "Chicken & Rice Soup",     Category = "One-Pot Meals", CardColor = "#B2DFDB" },
            new RecipeResult { Name = "Lentil Dal",              Category = "One-Pot Meals", CardColor = "#B2DFDB" },
            new RecipeResult { Name = "Beef Stew",               Category = "One-Pot Meals", CardColor = "#B2DFDB" },
            new RecipeResult { Name = "Banana Bread",            Category = "Baking",        CardColor = "#F8BBD0" },
            new RecipeResult { Name = "Blueberry Muffins",       Category = "Baking",        CardColor = "#F8BBD0" },
            new RecipeResult { Name = "Slow Cooker Pulled Pork", Category = "Slow & Low",    CardColor = "#D1C4E9" },
            new RecipeResult { Name = "Overnight Oats",          Category = "No Cook",       CardColor = "#C8E6C9" },
        };

        // Display recipes in the CollectionView
        RecipeCollectionView.ItemsSource = recipes;
    }
}

// Represents a recipe displayed on the results page
public class RecipeResult
{
    public string Name { get; set; } = string.Empty;
    public string Category { get; set; } = string.Empty;

    // Used to give each recipe card a category color
    public string CardColor { get; set; } = "#E0E0E0";
}