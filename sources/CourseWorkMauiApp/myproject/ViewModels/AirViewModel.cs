using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Input;
namespace CourseWorkMauiApp;

public class AirViewModel : BaseViewModel
{
    string type = null;
    DateTime date;
    AirlinerClass airliner = null;
    ImageSource imageliner;
    string numberliner = null;
    AirlinerClass new_airliner = null;

    public ICommand ChoosePhotoCommand { get; set; }
 
    public ObservableCollection<AirlinerClass> Airliners { get; set; } = new(); //список самолетов

    public AirViewModel()
    {

        AddCommand = new Command(() =>
        {
            Airliners.Add(new AirlinerClass(Type, NumberLiner, ImageLiner, DateTechnicalInspection));
            Clear();
            OnPropertyChanged();
        });

        RemoveCommand = new Command((object? args) =>
        {
            if (args is AirlinerClass airliner) Airliners.Remove(airliner);
        });
        SetCommand = new Command(async() =>
        {
            if (SelectedAirliner == null)
            {
                await Application.Current.MainPage.DisplayAlert("Ошибка", "Выберите обьект.", "OK");
                return;
            }
            ImageLiner = SelectedAirliner.ImageLiner;
            Type = SelectedAirliner.Type;
            NumberLiner = SelectedAirliner.NumberLiner;
            DateTechnicalInspection = SelectedAirliner.DateTechnicalInspection;
            New_Airliner = new AirlinerClass(SelectedAirliner.Type, SelectedAirliner.NumberLiner, SelectedAirliner.ImageLiner, SelectedAirliner.DateTechnicalInspection); //запомнили старый обьект, теперь меняем эти поля

        });
        SetCommandSecond = new Command(() =>
        {
            New_Airliner.ImageLiner = ImageLiner;
            {
                SelectedAirliner.Type = New_Airliner.Type;
                if (New_Airliner.NumberLiner != "" && New_Airliner.NumberLiner !=  null)
                    SelectedAirliner.NumberLiner = New_Airliner.NumberLiner;
                SelectedAirliner.ImageLiner = New_Airliner.ImageLiner;
                SelectedAirliner.DateTechnicalInspection = New_Airliner.DateTechnicalInspection;
            }
            New_Airliner = null;
            SelectedAirliner = null;
        });
        CancelCommandSecond = new Command(() =>
        {
            SelectedAirliner = null;
            New_Airliner = null;
        });
        ChoosePhotoCommand = new Command(async () => await ChoosePhotoAsync());
        
    }
    
    public override void Clear()
    {
        Type = null;
        NumberLiner = null;
        ImageLiner = null;
        DateTechnicalInspection = DateTime.MinValue;
    }

    private async Task ChoosePhotoAsync() //
    {
        var result = await FilePicker.PickAsync();
        if (result != null)
        {
            var fullpath = result.FullPath; //путь к фото
            ImageLiner = fullpath;
            
        }
    }
    public bool IsSaveButtonEnabled
    {
        get => !string.IsNullOrEmpty(Type) && !string.IsNullOrEmpty(NumberLiner) && ImageLiner != null && (DateTechnicalInspection <= DateTime.Today);
        set => OnPropertyChanged(nameof(IsSaveButtonEnabled));
    }

    //реализация свойств

    public AirlinerClass New_Airliner
    { get => new_airliner;
        set
        {
            if (new_airliner != value)
                new_airliner = value;
                OnPropertyChanged();
        }
    }

    public AirlinerClass SelectedAirliner //
    {
        get => airliner;
        set
        {
            if (airliner != value)
                airliner = value;
                OnPropertyChanged();
        }
    }
    public string Type
    {
        get => type;
        set
        {
            if (type != value)
            {
                type = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(IsSaveButtonEnabled));
            }
        }
    }
    public string NumberLiner
    { 
        get => numberliner;
        set
        {
            if (numberliner != value)
            {
                numberliner = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(IsSaveButtonEnabled));
            }
        }
    }
    public ImageSource ImageLiner
    {
        get => imageliner;
        set
        {
            if (imageliner != value)
            {
                imageliner = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(IsSaveButtonEnabled));
            }
        }

    }
    public DateTime DateTechnicalInspection
    {
        get => date;
        set
        {
            if (date != value)
            {
                date = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(IsSaveButtonEnabled));
            }
        }
    }
}