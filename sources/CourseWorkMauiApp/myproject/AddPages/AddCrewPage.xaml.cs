namespace CourseWorkMauiApp;

public partial class AddCrewPage : ContentPage
{
    private CrewViewModel _crewViewModel;
    public AddCrewPage(CrewViewModel crewViewModel)
    {
        InitializeComponent();
        _crewViewModel = crewViewModel;
        BindingContext = _crewViewModel;

    }

    async void BackPage(object sender, EventArgs e)
    {
        MainPage.CrewViewModel.Clear();
        await Navigation.PopAsync();
    }

    private void TextToChanged(object sender, TextChangedEventArgs e)
    {
        var entry = sender as Entry;
        if (entry == null || string.IsNullOrEmpty(e.NewTextValue))
            return;
        // Фильтруем только буквы (и пробелы между ними)
        string filteredText = new string(e.NewTextValue.Where(c => char.IsLetter(c) || c == ' ').ToArray());
        // Если текст изменился, обновляем текст в поле
        if (e.NewTextValue != filteredText)
            entry.Text = filteredText;
    }
}
