namespace CourseWorkMauiApp;

public partial class CrewPage : ContentPage
{
    private CrewViewModel _crewViewModel;
    public CrewPage(CrewViewModel crewViewModel)
    {
        InitializeComponent();
        _crewViewModel = crewViewModel;
        BindingContext = _crewViewModel;

    }

    async void OpenAddCrewPage(object sender, EventArgs e)
    {
        MainPage.CrewViewModel.Clear();
        crewListView.SelectedItem = null;
        await Navigation.PushAsync(new AddCrewPage(_crewViewModel));
    }
    public void ClearDeleteObject(object sender, EventArgs e)
    {
        crewListView.SelectedItem = null;
    }
    async void OpenSetCrewPage(object sender, EventArgs e)
    {
        if (crewListView.SelectedItem != null)
            await Navigation.PushAsync(new SetCrewPage(_crewViewModel));
        
    }
    async void BackPage(object sender, EventArgs e)
    {
        crewListView.SelectedItem = null;
        MainPage.CrewViewModel.Clear();
        await Navigation.PopAsync();
    }
}
