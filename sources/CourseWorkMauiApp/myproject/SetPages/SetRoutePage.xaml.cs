namespace CourseWorkMauiApp;

public partial class SetRoutePage : ContentPage
{
    private RouteViewModel _routeViewModel;
    public SetRoutePage(RouteViewModel routeViewModel)
    {
        InitializeComponent();
        _routeViewModel = routeViewModel;
        BindingContext = _routeViewModel;

    }
   
    async void BackPage(object sender, EventArgs e)
    {
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
