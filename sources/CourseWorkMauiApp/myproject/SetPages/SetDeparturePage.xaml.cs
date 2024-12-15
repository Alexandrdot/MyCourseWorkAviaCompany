namespace CourseWorkMauiApp;

public partial class SetDeparturePage : ContentPage
{
    private DepartureViewModel _departureViewModel;
    public SetDeparturePage(DepartureViewModel departureViewModel)
    {
        InitializeComponent();
        _departureViewModel = departureViewModel;
        BindingContext = _departureViewModel;

    }
    async void BackPage(object sender, EventArgs e)
    {
        await Navigation.PopAsync();
    }
}