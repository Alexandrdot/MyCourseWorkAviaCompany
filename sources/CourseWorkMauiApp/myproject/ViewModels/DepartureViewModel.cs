using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;

namespace CourseWorkMauiApp;

public class DepartureViewModel : BaseViewModel
{
    AirlinerClass _airliner = null;
    CrewClass _crew = null;
    RouteClass _route = null;
    
    DepartureClass selecteddeparture = null;
    DepartureClass new_departure;
    DateTime dayofdeparture = DateTime.Today;
    public ICommand SetDepartureSecond { get; set; }
    public ObservableCollection<DepartureClass> Departures { get; set; } = new(); //список
    public ObservableCollection<DepartureClass> History_Departures { get; set; } = new(); //список 
    public ObservableCollection<AirlinerClass> Airliner_List { get; set; } = new();
    public ObservableCollection<CrewClass> Crew_List { get; set; } = new();
    public ObservableCollection<RouteClass> Route_List { get; set; } = new();
    
    

    public DepartureViewModel()
    {
        AddCommand = new Command(async () =>
        {

            if (Crew == null || Route == null || Airliner == null)
            {
                await Application.Current.MainPage.DisplayAlert("Ошибка", "Выберите все параметры (экипаж, маршрут, самолет).", "OK");
                return; 
            }
            if (Route.Type != Airliner.Type)
            {
                await Application.Current.MainPage.DisplayAlert("Ошибка", "Типы судна для вылета разные", "OK");
                return;
            }
            var o = new DepartureClass(Crew, Route, Airliner, DayOfDeparture);

            if (o.DayOfDeparture < DateTime.Today)//если дата вылета меньше сегодня, добавляем в историю
            {
                History_Departures.Add(o);
                await Application.Current.MainPage.DisplayAlert("Вылет добавлен в историю", "Дата вылета меньше текущей", "OK");
            }

            else
            {
                Departures.Add(o);
            }
            await App.Current.MainPage.Navigation.PopAsync();    
            Clear();
            OnPropertyChanged();
        });
        SetCommand = new Command(async () =>
        {

            if (SelectedDeparture == null)
            {
                await Application.Current.MainPage.DisplayAlert("Ошибка", "Выберите обьект.", "OK");
                return;
            }

            Airliner = SelectedDeparture.Airliner;
            Crew = SelectedDeparture.Crew;
            Route = SelectedDeparture.Route;
            DayOfDeparture = SelectedDeparture.DayOfDeparture;
            //записал в поля текущие значения выбранного обьекта
            New_Departure = new DepartureClass(SelectedDeparture.Crew, SelectedDeparture.Route, SelectedDeparture.Airliner, SelectedDeparture.DayOfDeparture);
        });
        SetDepartureSecond = new Command(async () =>
        {
            if (New_Departure.Crew == null || New_Departure.Airliner == null || New_Departure.Route == null)
            {
                await App.Current.MainPage.DisplayAlert("Ошибка", "Введите все данные.", "OK");
                return;
            }
            if (New_Departure.Route.Type != New_Departure.Airliner.Type)
            {
                await App.Current.MainPage.DisplayAlert("Ошибка", "Типы судна для вылета разные.", "OK");
                return;
            }
            SelectedDeparture.Crew = New_Departure.Crew;
            SelectedDeparture.Airliner = New_Departure.Airliner;
            SelectedDeparture.Route = New_Departure.Route; 
            SelectedDeparture.DayOfDeparture = New_Departure.DayOfDeparture;

            if (SelectedDeparture.DayOfDeparture < DateTime.Today)
            {
                History_Departures.Add(SelectedDeparture);
                Departures.Remove(SelectedDeparture);
                await App.Current.MainPage.DisplayAlert("Уведомление", "Вылет добавлен в историю.", "OK");
            }

            var tempList = new ObservableCollection<DepartureClass>(Departures);
            Departures.Clear();
            foreach (var o in tempList)
                Departures.Add(o);
            await App.Current.MainPage.Navigation.PopAsync();

            SelectedDeparture = null;
            New_Departure = null;

            
        });

        RemoveCommand = new Command((object? args) =>
        {
            if (args is DepartureClass departure) Departures.Remove(departure);
        });
        CancelCommandSecond = new Command(() =>
        {
            SelectedDeparture = null;
        });

    }
    public override void Clear()
    {
        Airliner = null;
        Crew = null;
        Route = null;
        DayOfDeparture = DateTime.MinValue;
    }
    public DateTime DayOfDeparture
    {
        get => dayofdeparture;
        set
        {
            if (dayofdeparture != value)
                dayofdeparture = value;
            OnPropertyChanged();
        }
    }
    public AirlinerClass Airliner
    {
        get => _airliner;
        set
        {
            if (_airliner != value)
                _airliner = value;
            OnPropertyChanged();
        }
    }
    public CrewClass Crew
    {
        get => _crew;
        set
        {
            if (_crew != value)
                _crew = value;
            OnPropertyChanged();
        }
    }
    public RouteClass Route
    {
        get => _route;
        set
        {
            if (_route != value)
                _route = value;
            OnPropertyChanged();
        }
    }
    public DepartureClass SelectedDeparture //
    {
        get => selecteddeparture;
        set
        {
            if (selecteddeparture != value)
                selecteddeparture = value;
            OnPropertyChanged();
        }
    }
    public DepartureClass New_Departure //
    {
        get => new_departure;
        set
        {
            if (new_departure != value)
                new_departure = value;
            OnPropertyChanged();
        }
    }
}
