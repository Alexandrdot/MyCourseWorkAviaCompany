using System;
namespace CourseWorkMauiApp
{
    public class AirlinerClass //класс авиалайнер
    {
        public string Type{ get; set; } //тип судна
        public string NumberLiner { get; set; } //бортовой номер
        public ImageSource ImageLiner { get; set; } //фотография борта
        public DateTime DateTechnicalInspection { get; set; } //дата последнего то

      
        public AirlinerClass(string type, string numberliner, ImageSource imageliner, DateTime date)
		{
            Type = type;
            NumberLiner = numberliner;
            ImageLiner = imageliner;
            DateTechnicalInspection = date;
        }
	}
}

