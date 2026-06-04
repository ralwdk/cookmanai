namespace CookmanAi;

public partial class ToolSelectionPage : ContentPage
{
    // Stores every tool that can show up in the list
    private List<KitchenTool> _allTools;

    public ToolSelectionPage()
    {
        InitializeComponent();

        _allTools = new List<KitchenTool>
        {
            new KitchenTool { Name = "Oven" },
            new KitchenTool { Name = "Stovetop" },
            new KitchenTool { Name = "Microwave" },
            new KitchenTool { Name = "Air Fryer" },
            new KitchenTool { Name = "Blender" },
            new KitchenTool { Name = "Food Processor" },
            new KitchenTool { Name = "Slow Cooker" },
            new KitchenTool { Name = "Instant Pot" },
            new KitchenTool { Name = "Rice Cooker" },
            new KitchenTool { Name = "Toaster Oven" },
            new KitchenTool { Name = "Grill" },
            new KitchenTool { Name = "Wok" },
            new KitchenTool { Name = "Mixing Bowls" },
            new KitchenTool { Name = "Stand Mixer" },
            new KitchenTool { Name = "Hand Mixer" }
        };

        // Show every tool when the page first opens
        ToolCollectionView.ItemsSource = _allTools;

        // Enable the Continue button now that navigation is wired up
        BtnContinue.IsEnabled = true;
    }

    // Runs whenever the user types in the search bar
    private void OnSearchTextChanged(object sender, TextChangedEventArgs e)
    {
        string searchText = e.NewTextValue?.ToLower() ?? string.Empty;

        if (string.IsNullOrWhiteSpace(searchText))
        {
            ToolCollectionView.ItemsSource = _allTools;
            return;
        }

        var filteredTools = new List<KitchenTool>();

        foreach (KitchenTool tool in _allTools)
        {
            if (tool.Name.ToLower().Contains(searchText))
            {
                filteredTools.Add(tool);
            }
        }

        ToolCollectionView.ItemsSource = filteredTools;
    }

    // Runs whenever a checkbox is checked or unchecked
    private void OnToolCheckedChanged(object sender, CheckedChangedEventArgs e)
    {
        UpdateSelectedSummary();
    }

    // Updates the selected tools text at the bottom of the page
    private void UpdateSelectedSummary()
    {
        var selectedNames = new List<string>();

        foreach (KitchenTool tool in _allTools)
        {
            if (tool.IsSelected)
            {
                selectedNames.Add(tool.Name);
            }
        }

        if (selectedNames.Count == 0)
        {
            SelectedToolsSummary.Text = "None selected";
        }
        else
        {
            SelectedToolsSummary.Text = string.Join(", ", selectedNames);
        }
    }

    // Navigates to the Ingredients page
    private async void OnContinueClicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync(nameof(IngredientsPage));
    }
}

// Simple class for one kitchen tool/appliance
public class KitchenTool
{
    public string Name { get; set; } = string.Empty;
    public bool IsSelected { get; set; }
}