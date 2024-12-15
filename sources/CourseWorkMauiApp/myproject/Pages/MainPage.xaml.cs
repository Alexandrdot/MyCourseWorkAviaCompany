using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;

namespace CourseWorkMauiApp;

public partial class MainPage : ContentPage, INotifyPropertyChanged
{
    public static AirViewModel AirViewModel { get; set; } = new();
    public static CrewViewModel CrewViewModel { get; set; } = new();
    public static RouteViewModel RouteViewModel { get; set; } = new();
    public static DepartureViewModel DepartureViewModel { get; set; } = new();
    public static BuyTicketViewModel BuyTicketViewModel { get; set; } = new();
    public static HistoryViewModel HistoryViewModel { get; set; } = new();
    
    public MainPage()
	{
		InitializeComponent();
        SaveInfo.LoadViewModels(); 
    }
    async void OpenAvialinersPage(object sender, EventArgs e)
	{
        
        await Navigation.PushAsync(new AviaPage(AirViewModel));
    }

    async void OpenRoutePage(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new RoutePage(RouteViewModel));
    }

    async void OpenCrewPage(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new CrewPage(CrewViewModel));
    }

    async void SaveData(object sender, EventArgs e)
    {
        SaveInfo.SaveViewModels();
        await Application.Current.MainPage.DisplayAlert("Уведомление", "Данные успешно сохранены.", "OK");

    }

    async void OpenADeparturePage(object sender, EventArgs e)
    {

        DepartureViewModel.Airliner_List = AirViewModel.Airliners;
        DepartureViewModel.Crew_List = CrewViewModel.Crews;
        DepartureViewModel.Route_List = RouteViewModel.Routes;

        await Navigation.PushAsync(new DeparturePage(DepartureViewModel));
    }

    async void OpenBuyticketPage(object sender, EventArgs e)
    {
        BuyTicketViewModel.Departures_List = DepartureViewModel.Departures;
        await Navigation.PushAsync(new BuyTicketPage(BuyTicketViewModel));
    }

    async void OpenHistoryPage(object sender, EventArgs e)
    {
        HistoryViewModel.History_Departures = DepartureViewModel.History_Departures;
        await Navigation.PushAsync(new HistoryPage(HistoryViewModel));
    }
    

}


