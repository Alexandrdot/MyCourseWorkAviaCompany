using System.Collections.ObjectModel;

namespace CourseWorkMauiApp;

public partial class AddDeparturePage : ContentPage
{
    private DepartureViewModel _departureViewModel;

    public AddDeparturePage(DepartureViewModel departureViewModel)
    {
        InitializeComponent();
        _departureViewModel = departureViewModel;
        BindingContext = _departureViewModel;  
    }
    async void BackPage(object sender, EventArgs e)
    {
        MainPage.DepartureViewModel.Clear();
        await Navigation.PopAsync();
    }
}
