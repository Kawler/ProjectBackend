using Project.Models;

namespace Project.Services
{
    public interface IScheduleService
    {
        List<Schedule> GetSchedule();
        void Delete(int id);
        void Create(Schedule schedule);
        void Update(int id, Schedule schedule);
    }
}
