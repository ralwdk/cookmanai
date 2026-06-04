using System;
using System.Collections.ObjectModel;
using System.Windows.Input;
using Microsoft.Maui.Controls;

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

        // BindingContext ensures the collection view data loops find the DeleteCommand
        BindingContext = this;
    }

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

    private async void OnFindRecipesClicked(object sender, EventArgs e)
    {
        // Transitions natively to your RecipeResultsPage definition block
        await Navigation.PushAsync(new RecipeResultsPage());
    }
}

// Data record matching architecture definitions of your project data models
public class IngredientItem
{
    public string Name { get; set; } = string.Empty;
}