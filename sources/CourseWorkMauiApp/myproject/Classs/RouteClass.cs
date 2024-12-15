

namespace CourseWorkMauiApp
{
	public class RouteClass //класс маршрут
	{
		public string Code { get; set; } //шифр маршрута
		public string PlaceOfDeparture { get; set; } //место вылета
        public string DateOfWeek { get; set; } //дни вылета
        public string LandingPlace { get; set; } //место посадки
        
        public string IntermediateLandingSites { get; set; } //места промежуточных посадок
		public string Type { get; set; } //тип судна

        public TimeSpan TimeOfDeparture { get; set; } //время вылета
        public TimeSpan TimeOfLanding { get; set; } //время посаднки


        public RouteClass(string code, string type, string placeofdeparture, string dateofweek, TimeSpan timeofdeparture, string landingplace, TimeSpan timeoflanding, string sites)
		{
            Code = code;
            Type = type;
            PlaceOfDeparture = placeofdeparture;
            DateOfWeek = dateofweek;
            TimeOfDeparture = timeofdeparture;
            LandingPlace = landingplace;
            TimeOfLanding = timeoflanding;
            IntermediateLandingSites = sites;
            
        }
	}
}

