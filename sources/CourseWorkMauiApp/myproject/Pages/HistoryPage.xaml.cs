namespace CourseWorkMauiApp;

public partial class HistoryPage : ContentPage
{

    private HistoryViewModel _historyViewModel;
    public HistoryPage(HistoryViewModel historyViewModel)
    {
        InitializeComponent();
        _historyViewModel = historyViewModel;
        BindingContext = _historyViewModel;

    }
    async void BackPage(object sender, EventArgs e)
    {
        await Navigation.PopAsync();
    }
}