using AutoMapper;
using System;

namespace Scz.AutoMapper
{
    class Program
    {
        static void Main(string[] args)
        {

            CalendarEvent calendar = new CalendarEvent()
            {
                Date = DateTime.Now,
                Title = "Demo Event"
            };

            //AutoMapperConfiguration.Configure();
            //CalendarEventForm calendarEventForm = Mapper.Map<CalendarEventForm>(calendar);
            //Console.WriteLine(calendarEventForm);

            Console.WriteLine("Hello World!");
        }
    }

    public class CalendarEventProfile : Profile
    {
        public CalendarEventProfile()
        {
            CreateMap<CalendarEvent, CalendarEventForm>()
           .ForMember(dest => dest.EventDate, opt => opt.MapFrom(src => src.Date.Date))
           .ForMember(dest => dest.EventHour, opt => opt.MapFrom(src => src.Date.Hour))
           .ForMember(dest => dest.EventMinute, opt => opt.MapFrom(src => src.Date.Minute))
           .ForMember(dest => dest.DisplayTitle, opt => opt.MapFrom(src => src.Title));
        }
    }

    public class CalendarEvent
    {
        public DateTime Date { get; set; }
        public string Title { get; set; }
    }

    public class CalendarEventForm
    {
        public DateTime EventDate { get; set; }
        public int EventHour { get; set; }
        public int EventMinute { get; set; }
        public string DisplayTitle { get; set; }
    }

}
