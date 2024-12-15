namespace CourseWorkMauiApp;

public partial class AviaPage : ContentPage
{
	private AirViewModel _airViewModel;
    public AviaPage(AirViewModel airViewModel)
	{
		InitializeComponent();
		_airViewModel = airViewModel;
        BindingContext = _airViewModel;

    }

	async void OpenAddAirlinerPage(object sender, EventArgs e)
	{
        MainPage.AirViewModel.Clear();
        airlinersListView.SelectedItem = null;
		await Navigation.PushAsync(new AddAirlinerPage(_airViewModel));
	}
    async void OpenSetAirlinerPage(object sender, EventArgs e)
    {
        if (airlinersListView.SelectedItem != null)
            await Navigation.PushAsync(new SetAirlinerPage(_airViewModel));
    }
    public void ClearDeleteObject(object sender, EventArgs e)
    {
        airlinersListView.SelectedItem = null;
    }
    async void BackPage(object sender, EventArgs e)
    {
        airlinersListView.SelectedItem = null;
        MainPage.AirViewModel.Clear();
        await Navigation.PopAsync();
    }

}
