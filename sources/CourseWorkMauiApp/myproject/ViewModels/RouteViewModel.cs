using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;

namespace CourseWorkMauiApp;

public class RouteViewModel : BaseViewModel
{
    string code = ""; //шифр маршрута
    string placeofdeparture = ""; //место вылета
    string dateofweek = ""; //дни вылета
    public ObservableCollection<string> ListOfSelectedDays { get; set; } = new();
    string landingplace = ""; //место посадки
    string intermediatelandingsites = ""; //места промежуточных посадок
    string type = ""; //тип судна
    string selectedday = "";
    RouteClass selectedroute;
    RouteClass new_route;
    public ICommand AddDay { get; set; }
    public ObservableCollection<string> ListOfDays { get; private set; } = new ObservableCollection<string> { "пн", "вт", "ср", "чт", "пт", "сб", "вс" };
    public ObservableCollection<RouteClass> Routes { get; set; } = new(); //список
    public RouteViewModel()
    {
        AddCommand = new Command(async() =>
        {
            if(Code == null || PlaceOfDeparture == null || DateOfWeek == null || LandingPlace == null || Type == null)
            {
                await Application.Current.MainPage.DisplayAlert("Ошибка", "Введите все данные.", "OK");
                return;
            }
            Routes.Add(new RouteClass(Code, Type, PlaceOfDeparture, DateOfWeek, TimeOfDeparture,  LandingPlace, TimeOfLanding, IntermediateLandingSites));
            await App.Current.MainPage.Navigation.PopAsync();
            Clear();
            OnPropertyChanged();
        });
        
        RemoveCommand = new Command((object? args) =>
        {
            if (args is RouteClass route) Routes.Remove(route);
        });
        SetCommand = new Command(async () =>
        {
            if (SelectedRoute == null)
            {
                await Application.Current.MainPage.DisplayAlert("Ошибка", "Выберите обьект.", "OK");
                return;
            }

            Code = SelectedRoute.Code;
            Type = SelectedRoute.Type;
            PlaceOfDeparture = SelectedRoute.PlaceOfDeparture;
            DateOfWeek = SelectedRoute.DateOfWeek;
            TimeOfDeparture = SelectedRoute.TimeOfDeparture;
            LandingPlace = SelectedRoute.LandingPlace;
            TimeOfLanding = SelectedRoute.TimeOfLanding;
            IntermediateLandingSites = SelectedRoute.IntermediateLandingSites;

            //также взял выбранный обьект
            New_Route = new RouteClass(SelectedRoute.Code, SelectedRoute.Type, SelectedRoute.PlaceOfDeparture, SelectedRoute.DateOfWeek, SelectedRoute.TimeOfDeparture, SelectedRoute.LandingPlace, SelectedRoute.TimeOfLanding, SelectedRoute.IntermediateLandingSites);
        });
        SetCommandSecond = new Command(async() =>
        {
            if (New_Route.Code == "" || New_Route.PlaceOfDeparture == "" || New_Route.DateOfWeek == "" || New_Route.LandingPlace == "")
            {
                await App.Current.MainPage.DisplayAlert("Ошибка", "Введите все данные.", "OK");
                return;
            }
 
            SelectedRoute.Code = New_Route.Code;
            SelectedRoute.Type = New_Route.Type;
            SelectedRoute.PlaceOfDeparture = New_Route.PlaceOfDeparture;
            SelectedRoute.DateOfWeek = New_Route.DateOfWeek;
            SelectedRoute.TimeOfDeparture = New_Route.TimeOfDeparture;
            SelectedRoute.LandingPlace = New_Route.LandingPlace;
            SelectedRoute.TimeOfLanding = New_Route.TimeOfLanding;
            SelectedRoute.IntermediateLandingSites = New_Route.IntermediateLandingSites;

            SelectedRoute = null;
            New_Route = null;
            var tempList = new ObservableCollection<RouteClass>(Routes);
            Routes.Clear();
            foreach (var o in tempList)
                Routes.Add(o);
            await App.Current.MainPage.Navigation.PopAsync();
        });
        AddDay = new Command(async () =>
        {
            if (SelectedDay == "" || SelectedDay == null)
            {
                await App.Current.MainPage.DisplayAlert("Ошибка", "Выберите день.", "OK");
                return;
            }
            if (DateOfWeek != null && DateOfWeek.Contains(SelectedDay))
            {
                await App.Current.MainPage.DisplayAlert("Ошибка", "День уже был добавлен.", "OK");
                return;
            }
            DateOfWeek += SelectedDay + " ";
        });
        CancelCommandSecond = new Command(() =>
        {
            SelectedRoute = null;
        });
    }
    public override void Clear()
    {
        Type = null;
        Code = null;
        PlaceOfDeparture = null;
        DateOfWeek = null;
        LandingPlace = null;
        IntermediateLandingSites = null;
        TimeOfDeparture = TimeSpan.Zero;
        TimeOfLanding = TimeSpan.Zero;
    }
    public RouteClass SelectedRoute
    {
        get => selectedroute;
        set
        {
            if (selectedroute != value)
                selectedroute = value;
                OnPropertyChanged();
        }
    }


    public string SelectedDay
    {
        get => selectedday;
        set
        {
            selectedday = value;
            OnPropertyChanged();
        }
    }

    public RouteClass New_Route
    {
        get => new_route;
        set
        {
            if (new_route != value)
                new_route = value;
                OnPropertyChanged();
        }
    }

    private TimeSpan _timeOfDeparture = TimeSpan.Zero;
    public TimeSpan TimeOfDeparture
    {
        get => _timeOfDeparture;
        set { _timeOfDeparture = value; OnPropertyChanged(); }
    }

    private TimeSpan _timeOfLanding = TimeSpan.Zero;
    public TimeSpan TimeOfLanding
    {
        get => _timeOfLanding;
        set
        {
            _timeOfLanding = value;
            OnPropertyChanged();
        }
    }
    public string DateOfWeek
    {
        get => dateofweek;
        set
        {
            if (dateofweek != value)
                dateofweek = value;
            OnPropertyChanged();
        }
    }
    public string Code
    {
        get => code;
        set
        {
            if (code != value)
                code = value;
            OnPropertyChanged();
        }
    }
    public string Type
    {
        get => type;
        set
        {
            if (type != value)
                type = value;
            OnPropertyChanged();
        }
    }
    public string PlaceOfDeparture
    {
        get => placeofdeparture;
        set
        {
            if (placeofdeparture != value)
                placeofdeparture = value;
            OnPropertyChanged();
        }
    }
   
    public string LandingPlace
    {
        get => landingplace;
        set
        {
            if (landingplace != value)
                landingplace = value;
            OnPropertyChanged();
        }
    }
    
    public string IntermediateLandingSites
    {
        get => intermediatelandingsites;
        set
        {
            if (intermediatelandingsites != value)
                intermediatelandingsites = value;
            OnPropertyChanged();
        }
    }
}
