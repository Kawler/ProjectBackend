namespace Project.Models
{
    public class Schedule
    {
        public Schedule(int id,string nameOfTheDay, int classroom, string subjectName)
        {
            Id = id;
            NameOfTheDay = nameOfTheDay;
            Classroom = classroom;
            SubjectName = subjectName;
        }
        public int Id { get; set; }
        public string NameOfTheDay { get; set; }
        public int Classroom { get; set; }
        public string SubjectName { get; set; }
    }
}
