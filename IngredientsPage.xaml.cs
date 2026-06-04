using System.Collections.ObjectModel;
using System.Windows.Input;

namespace CookmanAi;

public partial class IngredientsPage : ContentPage
{
    // Tracks the active list of items
    public ObservableCollection<IngredientItem> Ingredients { get; set; }

    // Command utilized by the layout UI elements to delete an item
    public ICommand DeleteCommand { get; private set; }

    public IngredientsPage()
    {
        InitializeComponent();

        // Placeholder ingredient data for Sprint 1
        Ingredients = new ObservableCollection<IngredientItem>
        {
            new IngredientItem { Name = "Chicken Breast" },
            new IngredientItem { Name = "White Rice" },
            new IngredientItem { Name = "Eggs" },
            new IngredientItem { Name = "Broccoli" },
            new IngredientItem { Name = "Garlic" }
        };

        // Display ingredients in the CollectionView
        IngredientsCollectionView.ItemsSource = Ingredients;

        // Hook up delete processing context loop
        DeleteCommand = new Command<IngredientItem>((item) =>
        {
            if (item != null && Ingredients.Contains(item))
            {
                Ingredients.Remove(item);
            }
        });

        // BindingContext ensures the CollectionView data loops find the DeleteCommand
        BindingContext = this;
    }

    // Adds a new ingredient to the list
    private void OnAddIngredientClicked(object sender, EventArgs e)
    {
        string text = IngredientInput.Text?.Trim();

        if (!string.IsNullOrWhiteSpace(text))
        {
            // Add item to dynamic collection container loop
            Ingredients.Add(new IngredientItem { Name = text });

            // Reset UI state fields
            IngredientInput.Text = string.Empty;
            IngredientInput.Focus();
        }
    }

    // Navigates to the Recipe Results page
    private async void OnContinueClicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync(nameof(RecipeResultsPage));
    }
}

// Data record matching architecture definitions of your project data models
public class IngredientItem
{
    public string Name { get; set; } = string.Empty;
}
