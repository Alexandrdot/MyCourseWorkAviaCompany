using System;
namespace CourseWorkMauiApp
{
	public class DepartureClass //класс вылет
	{
		public CrewClass Crew { get; set; } //команда
		public RouteClass Route { get; set; } //маршрут
		public AirlinerClass Airliner { get; set; } //самолет
		public DateTime DayOfDeparture { get; set; }

		public DepartureClass(CrewClass crew, RouteClass route, AirlinerClass airliner, DateTime dayofdeparture)
		{
			Crew = crew;
			Route = route;
			Airliner = airliner;
			DayOfDeparture = dayofdeparture;
        }
	}
}

