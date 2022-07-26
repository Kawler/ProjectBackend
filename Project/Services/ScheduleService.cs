using Project.Dto;
using Project.Models;
using Project.Repositories;

namespace Project.Services
{
    public class ScheduleService : IScheduleService
    {
        private readonly IScheduleRepository _scheduleRepository;
        public ScheduleService(IScheduleRepository scheduleRepository)
        {
            _scheduleRepository = scheduleRepository;
        }

        public void Create(Schedule schedule)
        {
            _scheduleRepository.Create(schedule);
        }

        public void Delete(int id)
        {
            _scheduleRepository.Delete(id);
        }

        public List<Schedule> GetSchedule()
        {
            return (List<Schedule>)_scheduleRepository.GetSchedule();
        }

        public void Update(int id, Schedule schedule)
        {
            _scheduleRepository.Update(id, schedule);
        }
    }
}
