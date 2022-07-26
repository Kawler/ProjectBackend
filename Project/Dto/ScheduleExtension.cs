using Project.Models;

namespace Project.Dto
{
    public static class ScheduleExtension
    {
        public static ScheduleDto ConvertToScheduleDto(this Schedule schedule)
        {
            return new ScheduleDto
            {
                ScheduleSubjectId = schedule.Id,
                NameOfTheDay = schedule.NameOfTheDay,
                SubjectName = schedule.SubjectName,
                Classroom = schedule.Classroom
            };
        }
    }
}
