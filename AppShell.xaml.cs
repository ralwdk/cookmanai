namespace CookmanAi;

public partial class AppShell : Shell
{
    public AppShell()
    {
        InitializeComponent();

        // Register named routes for Shell navigation
        Routing.RegisterRoute(nameof(ToolSelectionPage), typeof(ToolSelectionPage));
        Routing.RegisterRoute(nameof(IngredientsPage), typeof(IngredientsPage));
        Routing.RegisterRoute(nameof(RecipeResultsPage), typeof(RecipeResultsPage));
    }
}
