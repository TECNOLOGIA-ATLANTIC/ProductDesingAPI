using AtlanticProductDesing.API.Dtos.Instructor;

namespace AtlanticProductDesing.API.Dtos.Course
{
    public class CourseDto
    {
        public long Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        //public DanceStyle DanceStyle { get; set; }
        //public Level Level { get; set; }
        // public IEnumerable<ScheduleDto> Schedules { get; set; }
        public IEnumerable<InstructorDto> Instructors { get; set; }
    }
}
