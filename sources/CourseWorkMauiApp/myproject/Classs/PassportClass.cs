using System;
namespace CourseWorkMauiApp
{
	public class PassportClass
	{
        public string Name { get; set; }
        public DateTime DateGiven { get; set; }
        public int Series { get; set; }
        public int Number { get; set; }
        public string NameGiven { get; set; }

		public PassportClass(string name, int series, int number, string namegiven, DateTime dategiven)
		{
            Name = name;
            Series = series;
            Number = number;
            NameGiven = namegiven;
            DateGiven = dategiven;
        }
	}
}

