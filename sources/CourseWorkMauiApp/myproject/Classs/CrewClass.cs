using System;
namespace CourseWorkMauiApp
{
	public class CrewClass //класс экипаж
	{
        public string NamePilotOne { get; set; }
        public string NamePilotTwo { get; set; }
        public string NameAttendantOne { get; set; }
        public string NameAttendantTwo { get; set; }
        public CrewClass(string namepilotone, string namepilottwo, string nameattendantone, string nameattendanttwo)
        {
            NamePilotOne = namepilotone;
            NamePilotTwo = namepilottwo;
            NameAttendantOne = nameattendantone;
            NameAttendantTwo = nameattendanttwo;
        }

    }
}

