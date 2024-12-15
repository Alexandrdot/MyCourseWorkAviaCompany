namespace CourseWorkMauiApp;

public partial class SetTicketPage : ContentPage
{
    private BuyTicketViewModel _ticketViewModel;
    public SetTicketPage(BuyTicketViewModel ticketViewModel)
    {
        InitializeComponent();
        _ticketViewModel = ticketViewModel;
        BindingContext = _ticketViewModel;

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
    private void OnEntryTextChanged(object sender, TextChangedEventArgs e)
    {
        if (e.NewTextValue != null)
        {
            var entry = sender as Entry;

            // Оставляем только цифры
            string filteredText = new string(e.NewTextValue.Where(char.IsDigit).ToArray());

            // Если текст изменился после фильтрации, обновляем поле ввода
            if (e.NewTextValue != filteredText)
            {
                entry.Text = filteredText;
            }
        }
    }
}