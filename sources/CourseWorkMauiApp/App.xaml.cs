namespace CourseWorkMauiApp;

public partial class App : Application
{
    public App()
    {
        InitializeComponent();
        MainPage = new NavigationPage(new MainPage());
        
    }
    protected override void OnSleep()
    {
        SaveInfo.SaveViewModels();
        base.OnSleep();
    }


}