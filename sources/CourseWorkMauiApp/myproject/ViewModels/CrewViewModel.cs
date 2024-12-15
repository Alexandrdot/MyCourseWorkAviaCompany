using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;


namespace CourseWorkMauiApp;

public class CrewViewModel: BaseViewModel
{
    public ObservableCollection<CrewClass> Crews { get; set; } = new();
    string namepilotone = "";
    string namepilottwo = "";
    string nameattendantone = "";
    string nameattendanttwo = "";
    public CrewClass selectedcrew;
    public CrewClass new_crew;
    public CrewViewModel()
    {
        AddCommand = new Command(async () =>
        {
            if (NamePilotOne == null || NamePilotTwo == null || NameAttendantOne == null || NameAttendantTwo == null)
            {
                await Application.Current.MainPage.DisplayAlert("Ошибка", "Введите все данные.", "OK");
                return;
            }
            Crews.Add(new CrewClass(NamePilotOne, NamePilotTwo, NameAttendantOne, NameAttendantTwo));
            await App.Current.MainPage.Navigation.PopAsync();
            Clear();
            OnPropertyChanged();
        });
        RemoveCommand = new Command((object? args) =>
        {
            if (args is CrewClass crew) Crews.Remove(crew);
        });
        SetCommand = new Command(async () =>
        {
            if (SelectedCrew == null)
            {
                await Application.Current.MainPage.DisplayAlert("Ошибка", "Выберите обьект.", "OK");
                return;
            }

            NamePilotOne = SelectedCrew.NamePilotOne;
            NamePilotTwo = SelectedCrew.NamePilotTwo;
            NameAttendantOne = SelectedCrew.NameAttendantOne;
            NameAttendantTwo = SelectedCrew.NameAttendantTwo;

            //также взял выбранный обьект
            New_Crew = new CrewClass(SelectedCrew.NamePilotOne, SelectedCrew.NamePilotTwo, SelectedCrew.NameAttendantOne, SelectedCrew.NameAttendantTwo);
        });
        SetCommandSecond = new Command(async() =>{await SetCrew();});
        CancelCommandSecond = new Command(() =>
        {
            SelectedCrew = null;
        });

    }
    async Task SetCrew()
    {
        if (New_Crew.NamePilotOne == "" || New_Crew.NamePilotTwo == "" || New_Crew.NameAttendantOne == "" || New_Crew.NameAttendantTwo == "")
        {
            await App.Current.MainPage.DisplayAlert("Ошибка", "Введите все данные.", "OK");
            return;
        }
        
        SelectedCrew.NamePilotOne = New_Crew.NamePilotOne;
        SelectedCrew.NamePilotTwo = New_Crew.NamePilotTwo;
        SelectedCrew.NameAttendantOne = New_Crew.NameAttendantOne;
        SelectedCrew.NameAttendantTwo = New_Crew.NameAttendantTwo;
        OnPropertyChanged(nameof(Crews));
        SelectedCrew = null;
        New_Crew = null;
        var tempList = new ObservableCollection<CrewClass>(Crews);
        Crews.Clear();
        foreach(var o in tempList)
            Crews.Add(o);
        await App.Current.MainPage.Navigation.PopAsync();

    }

    public override void Clear()
    {
        NamePilotOne = null;
        NamePilotTwo = null;
        NameAttendantOne = null;
        NameAttendantTwo = null;
    }
    public CrewClass SelectedCrew
    {
        get => selectedcrew;
        set
        {
            if (selectedcrew != value)
                selectedcrew = value;
            OnPropertyChanged();
        }
    }
    public CrewClass New_Crew
    {
        get => new_crew;
        set
        {
            if (new_crew != value)
                new_crew = value;
            OnPropertyChanged();
        }
    }
    public string NamePilotOne
    {
        get => namepilotone;
        set
        {
            if (namepilotone != value)
                namepilotone = value;
            OnPropertyChanged();
        }
    }
    public string NamePilotTwo
    {
        get => namepilottwo;
        set
        {
            if (namepilottwo != value)
                namepilottwo = value;
            OnPropertyChanged();
        }
    }
    public string NameAttendantOne
    {
        get => nameattendantone;
        set
        {
            if (nameattendantone != value)
                nameattendantone = value;
            OnPropertyChanged();
        }
    }
    public string NameAttendantTwo
    {
        get => nameattendanttwo;
        set
        {
            if (nameattendanttwo != value)
                nameattendanttwo = value;
            OnPropertyChanged();
        }
    }
}


