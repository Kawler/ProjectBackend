using System.Data;
using System.Data.SqlClient;
using Project.Models;

namespace Project.Repositories
{
    public class ScheduleRepository : IScheduleRepository
    {
        private readonly string _connectionString;

        public ScheduleRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public List<Schedule> GetSchedule()
        {

        var result = new List<Schedule>();

            using var connection = new SqlConnection(_connectionString);
            connection.Open();

            using SqlCommand sqlCommand = connection.CreateCommand();
            sqlCommand.CommandText = "select ss.[ScheduleId],ss.[SubjectId],s1.[DayOfTheWeek],s1.[ScheduleId],s2.[Classroom],s2.[SubjectId],s2.[SubjectName],ss.[ScheduleSubjectId] from [ScheduleSubject] as ss inner join [Schedule] as s1 on s1.[ScheduleId] = ss.[ScheduleId]  inner join [Subjects] as s2 on s2.[SubjectId] =ss.[SubjectId] order by s1.[ScheduleId]";

            using SqlDataReader reader = sqlCommand.ExecuteReader();
            while (reader.Read())
            {
                result.Add(new Schedule(
                    Convert.ToInt32(reader["ScheduleSubjectId"]),
                    Convert.ToString(reader["DayOfTheWeek"]),
                    Convert.ToInt32(reader["Classroom"]),
                    Convert.ToString(reader["SubjectName"])
                ));
            }
            return result;
        }
        public void Delete(int id)
        {
            using var connection = new SqlConnection(_connectionString);
            connection.Open();

            using SqlCommand sqlCommand = connection.CreateCommand();
            sqlCommand.CommandText = "delete [ScheduleSubject] where [ScheduleSubjectId] = @scheduleId";
            sqlCommand.Parameters.Add("@scheduleId", SqlDbType.Int).Value = id;
            sqlCommand.ExecuteNonQuery();
        }

        public void Update(int id, Schedule schedule)
        {
            int subjectId = FindSubject(schedule);
            int scheduleId = FindDay(schedule);
            using var connection = new SqlConnection(_connectionString);
            connection.Open();
            using SqlCommand sqlCommand = connection.CreateCommand();
            sqlCommand.CommandText = "update [ScheduleSubject] set [ScheduleId] = @dayOfTheWeek,[SubjectId] = @subjectId where [ScheduleSubjectId] = @scheduleId";
            sqlCommand.Parameters.Add("@scheduleId", SqlDbType.Int).Value = id;
            sqlCommand.Parameters.Add("@dayOfTheWeek", SqlDbType.Int).Value = scheduleId;
            sqlCommand.Parameters.Add("@subjectId", SqlDbType.Int).Value = subjectId;
            sqlCommand.ExecuteNonQuery();

        }

        public void Create(Schedule schedule)
        {
            int id = FindSubject(schedule);
            int scheduleId = FindDay(schedule);
            using var connection = new SqlConnection(_connectionString);
            connection.Open();
            using SqlCommand sqlCommand = connection.CreateCommand();
            sqlCommand.CommandText = "insert into [ScheduleSubject] (ScheduleId,SubjectId) values (@dayOfTheWeek,@subjectId)";
            sqlCommand.Parameters.Add("@dayOfTheWeek", SqlDbType.Int).Value = scheduleId;
            sqlCommand.Parameters.Add("@subjectId", SqlDbType.Int).Value = id;
            sqlCommand.ExecuteNonQuery();
        }

        public int FindSubject(Schedule schedule)
        {
            using var connection = new SqlConnection(_connectionString);
            connection.Open();
            int result = 0;
            using SqlCommand sqlCommand = connection.CreateCommand();
            sqlCommand.CommandText = "select [SubjectId],[SubjectName] from [Subjects] where [SubjectName] = @subjectName";
            sqlCommand.Parameters.Add("@subjectName", SqlDbType.NVarChar, 30).Value = schedule.SubjectName;
            using SqlDataReader reader = sqlCommand.ExecuteReader();
            while (reader.Read())
            {
                result = Convert.ToInt32(reader["SubjectId"]);
            }
            return result;
        }

        public int FindDay(Schedule schedule)
        {
            using var connection = new SqlConnection(_connectionString);
            connection.Open();
            int result = 0;
            using SqlCommand sqlCommand = connection.CreateCommand();
            sqlCommand.CommandText = "select [ScheduleId],[DayOfTheWeek] from [Schedule] where [DayOfTheWeek] = @nameOfTheDay";
            sqlCommand.Parameters.Add("@nameOfTheDay", SqlDbType.NVarChar, 15).Value = schedule.NameOfTheDay;
            using SqlDataReader reader = sqlCommand.ExecuteReader();
            while (reader.Read())
            {
                result = Convert.ToInt32(reader["ScheduleId"]);
            }
            return result;
        }
    }
}
