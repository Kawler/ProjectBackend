using Project.Models;

namespace Project.Repositories
{
    public interface IScheduleRepository
    {
        List<Schedule> GetSchedule();
        void Delete(int id);
        void Create(Schedule schedule);
        void Update(int id, Schedule schedule);
        int FindSubject(Schedule schedule);
        int FindDay(Schedule schedule);
    }
}
