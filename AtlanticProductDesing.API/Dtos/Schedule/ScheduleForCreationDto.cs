namespace AtlanticProductDesing.API.Dtos
{
    public class ScheduleForCreationDto
    {
        public DayOfWeek Day { get; set; }
        public TimeSpan StartTime { get; set; }
        public TimeSpan EndTime { get; set; }
    }
}
