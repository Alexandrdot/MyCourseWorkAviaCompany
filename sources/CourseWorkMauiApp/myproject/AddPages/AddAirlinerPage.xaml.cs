namespace CourseWorkMauiApp;

public partial class AddAirlinerPage : ContentPage
{
	private AirViewModel _airViewModel;
	public AddAirlinerPage(AirViewModel airViewModel)
	{
		InitializeComponent();
		_airViewModel = airViewModel;
        BindingContext = _airViewModel;

    }

	async void SaveAirliner(object sender, EventArgs e)
	{
        await Navigation.PopAsync();
    }
    async void BackPage(object sender, EventArgs e)
    {
        MainPage.AirViewModel.Clear();
        await Navigation.PopAsync();
    }
}
