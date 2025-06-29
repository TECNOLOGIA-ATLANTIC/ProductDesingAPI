namespace AtlanticProductDesing.API.Dtos
{
    public class ScheduleDto
    {
        public long Id { get; set; }
        public DayOfWeek Day { get; set; }
        public TimeSpan StartTime { get; set; }
        public TimeSpan EndTime { get; set; }
    }
}
