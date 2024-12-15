using System;
namespace CourseWorkMauiApp
{
	public class BuyTicketClass
	{
		public PassportClass Passport { get; set; } //данные паспорта
        public DepartureClass Departure { get; set; }
        public DateTime DateBuyTicket { get; set; }
        public int PriceTicket { get; set; }
        public string NumberPlace { get; set; }
        public string ClassPlace { get; set; }
        public string NubmerOficce { get; set; }
        public string Cashier { get; set; }
        public BuyTicketClass(DepartureClass departure,PassportClass passport, DateTime date, int price, string place, string classplace, string number, string cashier)
		{
            Departure = departure;
            Passport = passport;
            DateBuyTicket = date;
            PriceTicket = price;
            NumberPlace = place;
            ClassPlace = classplace;
            NubmerOficce = number;
            Cashier = cashier;
        }
	}
}

