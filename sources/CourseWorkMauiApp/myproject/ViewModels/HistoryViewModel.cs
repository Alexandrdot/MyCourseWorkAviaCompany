using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;

namespace CourseWorkMauiApp;
public class HistoryViewModel : BaseViewModel
{
    public ObservableCollection<DepartureClass> History_Departures { get; set; } = new(); //список 

    public HistoryViewModel()
    {
        RemoveCommand = new Command((object? args) =>
        {
            if (args is DepartureClass departure) History_Departures.Remove(departure);
        });
    } 
}