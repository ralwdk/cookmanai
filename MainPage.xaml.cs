namespace CookmanAi;

public partial class MainPage : ContentPage
{
    public MainPage()
    {
        InitializeComponent();
    }

    // Navigates to the Tool Selection page to begin the recipe flow
    private async void OnGetStartedClicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync(nameof(ToolSelectionPage));
    }
}
