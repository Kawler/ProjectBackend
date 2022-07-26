using Project.Models;

namespace Project.Repositories
{
    public interface ISubjectsRepository
    {
        List<Subjects> GetAll();
        void Update(Subjects subjects, int id);
        void Delete(int id);
        void Create(Subjects subjects);
    }
}
