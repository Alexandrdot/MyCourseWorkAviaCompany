using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
namespace CourseWorkMauiApp;

public class BuyTicketViewModel : BaseViewModel
{

    //добавить номер и название рейса
    PassportClass passport = null;
    string name = "";
    BuyTicketClass ticket = null;
    int series = 0;
    int number = 0;
    string namegiven = "";
    DateTime dategiven = DateTime.Today;
    BuyTicketClass new_ticket;

    DateTime date;
    int price = 0;
    string place = "";
    string classplace = "";
    string numberoffice = "";
    string cashier = "";
    public ICommand SetTicketSecond { get; set; }
    DepartureClass departure = null;
    public ObservableCollection<BuyTicketClass> Tickets { get; set; } = new(); //список билетов

    public ObservableCollection<DepartureClass> Departures_List { get; set; } = new();
    public override void Clear()
    {
        Name = null;
        Series = 0;
        Number = 0;
        NameGiven = null;
        DateGiven = DateTime.Today;
        Departure = null;
        DateBuyTicket = DateTime.Today;
        PriceTicket = 0;
        NumberPlace = null;
        ClassPlace = null;
        NubmerOficce = null;
        Cashier = null;
    }
    public BuyTicketViewModel()
    {

        AddCommand = new Command(async () =>
        {
            if (Series <= 0 || Number <= 0 || DateGiven > DateTime.Today)
            {
                await Application.Current.MainPage.DisplayAlert("Ошибка", "Некорректное значение данных паспорта.", "OK");
                return;
            }
            PassportClass Passport = new(Name, Series, Number, NameGiven, DateGiven);
            if (PriceTicket <= 0)
            {
                await Application.Current.MainPage.DisplayAlert("Ошибка", "Некорректная цена билета.", "OK");
                PriceTicket = 50000;
                return;
            }

            if (Name == "" || Series == 0 || Number == 0 || NameGiven == "" || Departure == null || PriceTicket == 0 || NumberPlace == "" || ClassPlace == "" || NubmerOficce == "" || Cashier == "")
            {
                await Application.Current.MainPage.DisplayAlert("Ошибка", "Введите все данные.", "OK");
                return;
            }

            Tickets.Add(new BuyTicketClass(Departure, Passport, DateBuyTicket, PriceTicket, NumberPlace, ClassPlace, NubmerOficce, Cashier));
            await App.Current.MainPage.Navigation.PopAsync();
            OnPropertyChanged();
            Clear();
        });
        SetCommand = new Command(async () =>
        {
            if (SelectedTicket == null)
            {
                await Application.Current.MainPage.DisplayAlert("Ошибка", "Выберите обьект.", "OK");
                return;
            }

            Passport = SelectedTicket.Passport;
            Name = SelectedTicket.Passport.Name;
            Series = SelectedTicket.Passport.Series;
            Number = SelectedTicket.Passport.Number;
            NameGiven = SelectedTicket.Passport.NameGiven;
            DateGiven = SelectedTicket.Passport.DateGiven;
            Departure = SelectedTicket.Departure;
            DateBuyTicket = SelectedTicket.DateBuyTicket;
            PriceTicket = SelectedTicket.PriceTicket;
            NumberPlace = SelectedTicket.NumberPlace;
            ClassPlace = SelectedTicket.ClassPlace;
            NubmerOficce = SelectedTicket.NubmerOficce;
            Cashier = SelectedTicket.Cashier;
            //также взял выбранный обьект
            New_Ticket = new BuyTicketClass(Departure, new PassportClass(SelectedTicket.Passport.Name, SelectedTicket.Passport.Series, SelectedTicket.Passport.Number, SelectedTicket.Passport.NameGiven, SelectedTicket.Passport.DateGiven), SelectedTicket.DateBuyTicket, SelectedTicket.PriceTicket, SelectedTicket.NumberPlace, SelectedTicket.ClassPlace, SelectedTicket.NubmerOficce, SelectedTicket.Cashier);
        });
        SetTicketSecond = new Command(async() =>
        {
            if (New_Ticket.Passport.Series <= 0 || New_Ticket.Passport.Number <= 0 || New_Ticket.Passport.DateGiven > DateTime.Today)
            {
                await Application.Current.MainPage.DisplayAlert("Ошибка", "Некорректное значение данных паспорта.", "OK");
                return;
            }
            if (New_Ticket.PriceTicket <= 0)
            {
                await Application.Current.MainPage.DisplayAlert("Ошибка", "Некорректная цена билета.", "OK");
                PriceTicket = 50000;
                return;
            }

            if (New_Ticket.Passport.Name == ""  || New_Ticket.Passport.NameGiven == "" || New_Ticket.Departure == null  || New_Ticket.NumberPlace == "" || New_Ticket.ClassPlace == "" || New_Ticket.NubmerOficce == "" || New_Ticket.Cashier == "")
            {
                await Application.Current.MainPage.DisplayAlert("Ошибка", "Введите все данные.", "OK");
                return;
            }
            if (New_Ticket.Departure == null)
            {
                await Application.Current.MainPage.DisplayAlert("Ошибка", "Выберите вылет.", "OK");
                return;
            }

            SelectedTicket.Passport = New_Ticket.Passport;

            SelectedTicket.Passport.Name = New_Ticket.Passport.Name;
            SelectedTicket.Passport.Series = New_Ticket.Passport.Series;
            SelectedTicket.Passport.Number = New_Ticket.Passport.Number;
            SelectedTicket.Passport.NameGiven = New_Ticket.Passport.NameGiven;
            SelectedTicket.Passport.DateGiven = New_Ticket.Passport.DateGiven;

            SelectedTicket.Departure = New_Ticket.Departure;
            SelectedTicket.DateBuyTicket = New_Ticket.DateBuyTicket;
            SelectedTicket.PriceTicket = New_Ticket.PriceTicket;
            SelectedTicket.NumberPlace = New_Ticket.NumberPlace;
            SelectedTicket.ClassPlace = New_Ticket.ClassPlace;
            SelectedTicket.NubmerOficce = New_Ticket.NubmerOficce;
            SelectedTicket.Cashier = New_Ticket.Cashier;

            

            var tempList = new ObservableCollection<BuyTicketClass>(Tickets);
            Tickets.Clear();
            foreach (var o in tempList)
                Tickets.Add(o);
            await App.Current.MainPage.Navigation.PopAsync();

            New_Ticket = null;
            SelectedTicket = null;
        });
        CancelCommandSecond = new Command(() =>
        {
            SelectedTicket = null;
        });
        RemoveCommand = new Command((object? args) =>
        {
            if (args is BuyTicketClass ticket) Tickets.Remove(ticket);
        });

    }

    public BuyTicketClass SelectedTicket //
    {
        get => ticket;
        set
        {
            if (ticket != value)
                ticket = value;
            OnPropertyChanged();
        }
    }
    public BuyTicketClass New_Ticket //
    {
        get => new_ticket;
        set
        {
            if (new_ticket != value)
                new_ticket = value;
            OnPropertyChanged();
        }
    }

    public PassportClass Passport
    {
        get => passport;
        set
        {
            if (passport != value)
                passport = value;
            OnPropertyChanged();
        }
    }

    public DepartureClass Departure
    {
        get => departure;
        set
        {
            if (departure != value)
                departure = value;
            OnPropertyChanged();
        }
    }

    public DateTime DateGiven
    {
        get => dategiven;
        set
        {

            dategiven = value;
            OnPropertyChanged();
        }
    }

    public string Name
    {
        get => name;
        set
        {
            if (name != value)
                name = value;
            OnPropertyChanged();
        }
    }

    public int Series
    {
        get => series;
        set
        {
            if (series != value)
                series = value;
            OnPropertyChanged();
        }
    }
    public int Number
    {
        get => number;
        set
        {
            if (number != value)
                number = value;
            OnPropertyChanged();
        }
    }
    public string NameGiven
    {
        get => namegiven;
        set
        {
            if (namegiven != value)
                namegiven = value;
            OnPropertyChanged();
        }
    }
    public DateTime DateBuyTicket
    {
        get => date;
        set
        {
            date = value;
            OnPropertyChanged();
        }
    }
    public int PriceTicket
    {
        get => price;
        set
        {
            if (price != value)
                price = value;
            OnPropertyChanged();
        }
    }
    public string NumberPlace
    {
        get => place;
        set
        {
            if (place != value)
                place = value;
            OnPropertyChanged();
        }
    }
    public string ClassPlace
    {
        get => classplace;
        set
        {
            if (classplace != value)
                classplace = value;
            OnPropertyChanged();
        }
    }
    public string NubmerOficce
    {
        get => numberoffice;
        set
        {
            if (numberoffice != value)
                numberoffice = value;
            OnPropertyChanged();
        }
    }
    public string Cashier
    {
        get => cashier;
        set
        {
            if (cashier != value)
                cashier = value;
            OnPropertyChanged();
        }
    }
}
