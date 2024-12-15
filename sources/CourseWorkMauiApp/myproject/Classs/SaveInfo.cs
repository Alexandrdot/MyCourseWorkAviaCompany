using System;
using Newtonsoft.Json;
using System.Collections.ObjectModel;

namespace CourseWorkMauiApp
{
    public class SavedData
{
    public List<AirlinerClass> AirSave { get; set; }
    public List<CrewClass> CrewSave { get; set; }
    public List<RouteClass> RouteSave { get; set; }
    public List<DepartureClass> DepartureSave { get; set; }
    public List<BuyTicketClass> BuyTicketSave { get; set; }
    public List<DepartureClass> HistorySave { get; set; }
}

    public class SaveInfo
    {
        private static readonly string filePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Data.json");
        public static void SaveViewModels()
        {
            

            try
            {
                var dataToSave = new SavedData
                {
                    AirSave = new List<AirlinerClass>(MainPage.AirViewModel.Airliners),
                    CrewSave = new List<CrewClass>(MainPage.CrewViewModel.Crews),
                    RouteSave = new List<RouteClass>(MainPage.RouteViewModel.Routes),
                    DepartureSave = new List<DepartureClass>(MainPage.DepartureViewModel.Departures),
                    BuyTicketSave = new List<BuyTicketClass>(MainPage.BuyTicketViewModel.Tickets),
                    HistorySave = new List<DepartureClass>(MainPage.HistoryViewModel.History_Departures)
                };


                string jsonData = JsonConvert.SerializeObject(dataToSave, Formatting.Indented);
                File.WriteAllText(filePath, jsonData);
                
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка сохранения ViewModel: {ex.Message}");
            }
        }

        public static void LoadViewModels()
        {
            
            if (File.Exists(filePath))
            {
                string jsonData = File.ReadAllText(filePath);
                var loadedData = JsonConvert.DeserializeObject<SavedData>(jsonData);

                if (loadedData != null)
                {
                    MainPage.AirViewModel.Airliners = new ObservableCollection<AirlinerClass>(loadedData.AirSave);
                    MainPage.CrewViewModel.Crews = new ObservableCollection<CrewClass>(loadedData.CrewSave);
                    MainPage.RouteViewModel.Routes = new ObservableCollection<RouteClass>(loadedData.RouteSave);

                    MainPage.DepartureViewModel.Departures = new ObservableCollection<DepartureClass>(loadedData.DepartureSave);
                    MainPage.BuyTicketViewModel.Tickets = new ObservableCollection<BuyTicketClass>(loadedData.BuyTicketSave);
                    MainPage.HistoryViewModel.History_Departures = new ObservableCollection<DepartureClass>(loadedData.HistorySave);

                    CheckDate(MainPage.DepartureViewModel.Departures, MainPage.HistoryViewModel.History_Departures);
                }
                    
            }
            
        }
        public static void CheckDate(ObservableCollection<DepartureClass> Departures, ObservableCollection<DepartureClass> History_Departures)
        {
            foreach (DepartureClass o in Departures)
            {
                if (o.DayOfDeparture < DateTime.Today)
                {
                    History_Departures.Add(o);
                    Departures.Remove(o);
                }
            }
        }
    }
}

