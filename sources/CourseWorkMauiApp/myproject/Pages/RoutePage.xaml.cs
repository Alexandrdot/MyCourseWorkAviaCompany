namespace CourseWorkMauiApp;

public partial class RoutePage : ContentPage
{
    private RouteViewModel _routeViewModel;
    public RoutePage(RouteViewModel routeViewModel)
    {
        InitializeComponent();
        _routeViewModel = routeViewModel;
        BindingContext = _routeViewModel;

    }

    async void OpenAddRoutePage(object sender, EventArgs e)
    {
        MainPage.RouteViewModel.Clear();
        ClearSelectedItem();
        await Navigation.PushAsync(new AddRoutePage(_routeViewModel));
    }
    async void OpenSetRoutePage(object sender, EventArgs e)
    {
        if (routeListView.SelectedItem != null)
            await Navigation.PushAsync(new SetRoutePage(_routeViewModel));
        
    }
    public void ClearDeleteObject(object sender, EventArgs e)
    {
        ClearSelectedItem();
    }
    public void ClearSelectedItem()
    {
        routeListView.SelectedItem = null;
    }
    async void BackPage(object sender, EventArgs e)
    {
        ClearSelectedItem();
        MainPage.RouteViewModel.Clear();
        await Navigation.PopAsync();
    }
}
