using DZ_SQL.Models;

using System.Data;
using System.Data.SqlClient;

namespace DZ_SQL.Repositories
{
    public class StudentRawSqlRepository : IStudentRepository
    {
        private readonly string _connectionString;

        public StudentRawSqlRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public List<Student> GetAll()
        {
            var result = new List<Student>();

            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                using (SqlCommand command = connection.CreateCommand())
                {
                    command.CommandText = "select [Id], [Name] from [Student]";

                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            result.Add(new Student
                            {
                                Id = Convert.ToInt32(reader["Id"]),
                                Name = Convert.ToString(reader["Name"])
                            });
                        }
                    }
                }
            }

            return result;
        }

        public void Add(Student student)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                using (SqlCommand command = connection.CreateCommand())
                {
                    command.CommandText =
                        @"insert into [Student]
                            ([Name], [Age])
                        values
                            (@name, @age)
                        select SCOPE_IDENTITY()";

                    command.Parameters.Add("@name", SqlDbType.NVarChar).Value = student.Name;
                    command.Parameters.Add("@age", SqlDbType.Int).Value = student.Age;

                    student.Id = Convert.ToInt32(command.ExecuteScalar());
                }
            }
        }

        public Student GetById(int id)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                using (SqlCommand command = connection.CreateCommand())
                {
                    command.CommandText =
                        @"select [Id], [Name], [Age]
                        from [Student]
                        where [Id] = @id";

                    command.Parameters.Add("@id", SqlDbType.Int).Value = id;
                    using (var reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return new Student
                            {
                                Id = Convert.ToInt32(reader["Id"]),
                                Name = Convert.ToString(reader["Name"]),
                                Age = Convert.ToInt32(reader["Age"])
                            };
                        }
                        else
                        {
                            return null;
                        }
                    }
                }
            }
        }

        public void Update(Student student)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                using (SqlCommand command = connection.CreateCommand())
                {
                    command.CommandText =
                        @"update [Student]
                        set [Name] = @name
                        where [Id] = @id
                        update [Student]
                        set [Age] = @age
                        where [Id] = @id";

                    command.Parameters.Add("@name", SqlDbType.NVarChar).Value = student.Name;
                    command.Parameters.Add("@id", SqlDbType.Int).Value = student.Id;
                    command.Parameters.Add("@age", SqlDbType.Int).Value = student.Age;

                    command.ExecuteNonQuery();
                }
            }
        }

        public void DeleteById(int id)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                using (SqlCommand command = connection.CreateCommand())
                {
                    command.CommandText =
                        @"delete [Student]
                        where [Id] = @id";

                    command.Parameters.Add("@id", SqlDbType.Int).Value = id;

                    command.ExecuteNonQuery();
                }
            }
        }
    }
}
