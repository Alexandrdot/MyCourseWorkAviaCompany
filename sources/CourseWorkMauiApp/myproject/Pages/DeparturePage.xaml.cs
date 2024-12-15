namespace CourseWorkMauiApp;

public partial class DeparturePage : ContentPage
{

    private DepartureViewModel _departureViewModel;
    public DeparturePage(DepartureViewModel departureViewModel)
    {
        InitializeComponent();
        _departureViewModel = departureViewModel;
        BindingContext = _departureViewModel;

    }

    async void OpenAddDeparturePage(object sender, EventArgs e)
    {
        MainPage.DepartureViewModel.Clear();
        departureListView.SelectedItem = null;
        await Navigation.PushAsync(new AddDeparturePage(_departureViewModel));
    }
    public void ClearDeleteObject(object sender, EventArgs e)
    {
        departureListView.SelectedItem = null;
    }
    async void OpenSetDeparturePage(object sender, EventArgs e)
    {
        if (MainPage.DepartureViewModel.SelectedDeparture != null)
            await Navigation.PushAsync(new SetDeparturePage(_departureViewModel));
    }
    async void BackPage(object sender, EventArgs e)
    {
        MainPage.DepartureViewModel.Clear();
        departureListView.SelectedItem = null;
        await Navigation.PopAsync();
    }

}
