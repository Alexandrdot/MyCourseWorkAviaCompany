namespace CourseWorkMauiApp;

public partial class SetAirlinerPage : ContentPage
{
    private AirViewModel _airViewModel;
    public SetAirlinerPage(AirViewModel airViewModel)
    {
        InitializeComponent();
        _airViewModel = airViewModel;
        BindingContext = _airViewModel;

    }

    async void SaveAirliner(object sender, EventArgs e)
    {
        await Navigation.PopToRootAsync();
    }

    
    async void BackPage(object sender, EventArgs e)
    {
        MainPage.AirViewModel.Clear();
        await Navigation.PopAsync();
    }
}
