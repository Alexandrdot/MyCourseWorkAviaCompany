namespace CourseWorkMauiApp;

public partial class BuyTicketPage : ContentPage
{
    private BuyTicketViewModel _buyTicketViewModel;
    public BuyTicketPage(BuyTicketViewModel buyTicketViewModel)
    {
        InitializeComponent();
        _buyTicketViewModel = buyTicketViewModel;
        BindingContext = _buyTicketViewModel; 
    }
    async void OpenAddTicketPage(object sender, EventArgs e)
    {
        MainPage.BuyTicketViewModel.Clear();
        ticketsListView.SelectedItem = null;
        await Navigation.PushAsync(new AddTicketPage(_buyTicketViewModel));
    }
    async void OpenSetTicketPage(object sender, EventArgs e)
    {
        if (MainPage.BuyTicketViewModel.SelectedTicket != null)
            await Navigation.PushAsync(new SetTicketPage(_buyTicketViewModel));
    }
    public void ClearDeleteObject(object sender, EventArgs e)
    {
        ticketsListView.SelectedItem = null;
    }
    async void BackPage(object sender, EventArgs e)
    {
        ticketsListView.SelectedItem = null;
        MainPage.BuyTicketViewModel.Clear();
        await Navigation.PopAsync();
    }
}
