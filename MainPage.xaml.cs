namespace CookmanAi;

public partial class MainPage : ContentPage
{
	int count = 0;

	public MainPage()
	{
		InitializeComponent();
	}

    private async void OnIngredientsClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new IngredientsPage());
    }

    private async void OnRecipeResultsClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new RecipeResultsPage());
    }

    private async void OnToolSelectionClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new ToolSelectionPage());
    }
}
