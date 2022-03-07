using DZ_SQL.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DZ_SQL.Repositories
{
    public class Student_in_groupRawSqlRepository : IStudent_in_groupRepository
    {
        private readonly string _connectionString;

        public Student_in_groupRawSqlRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public void Add(Student_in_group student_in_group)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                using (SqlCommand command = connection.CreateCommand())
                {
                    command.CommandText =
                        @"insert into [Student_in_group]
                        values
                            (@studentid, @groupid)
                        select SCOPE_IDENTITY()";

                    command.Parameters.Add("@studentid", SqlDbType.Int).Value = student_in_group.StudentId;
                    command.Parameters.Add("@groupid", SqlDbType.Int).Value = student_in_group.GroupId;

                    command.ExecuteNonQuery();
                }
            }
        }
        public List<Student_in_group> GetByIdStudent(int studentId)
        {
            var result = new List<Student_in_group>();
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                using (SqlCommand command = connection.CreateCommand())
                {
                    command.CommandText =
                        @"select [StudentId], [GroupsId]
                        from [Student_in_group]
                        where [StudentId] = @studentId";

                    command.Parameters.Add("@studentId", SqlDbType.Int).Value = studentId;
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            result.Add(new Student_in_group
                            {
                                GroupId = Convert.ToInt32(reader["StudentId"]),
                                StudentId = Convert.ToInt32(reader["GroupsId"])
                            });
                        }
                    }
                }
            }
            return result;
        }
        public void DeleteById(Student_in_group student_In_Group)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                using (SqlCommand command = connection.CreateCommand())
                {
                    command.CommandText =
                        @"delete [Student_in_group]
                        where [StudentId] = @studentId and [GroupsId] = @groupId";

                    command.Parameters.Add("@studentId", SqlDbType.Int).Value = student_In_Group.StudentId;
                    command.Parameters.Add("@groupId", SqlDbType.Int).Value = student_In_Group.GroupId;

                    command.ExecuteNonQuery();
                }
            }
        }
        public void Update(Student_in_group student_In_Group)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                using (SqlCommand command = connection.CreateCommand())
                {
                    command.CommandText =
                        @"update [Student_in_group]
                        set [GroupsId] = @groupId
                        where [StudentId] = @studentId";

                    command.Parameters.Add("@groupId", SqlDbType.Int).Value = student_In_Group.StudentId;
                    command.Parameters.Add("@studentId", SqlDbType.Int).Value = student_In_Group.GroupId;

                    command.ExecuteNonQuery();
                }
            }
        }
        public List<Student> GetAllByIdGroup(int groupId)
        {
            var students_in_group = new List<Student_in_group>();
            var result = new List<Student>();

            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                using (SqlCommand command = connection.CreateCommand())
                {
                    command.CommandText =
                        @"select [StudentId], [GroupsId] from [Student_in_group]
                        where [GroupsId] = @groupId";
                    command.Parameters.Add("@groupId", SqlDbType.Int).Value = groupId;

                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            result.Add(new Student
                            {
                                Id = Convert.ToInt32(reader["StudentId"])
                                /*GroupId = Convert.ToInt32(reader["StudentId"]),
                                StudentId = Convert.ToInt32(reader["GroupsId"])*/
                            });
                        }
                    }
                }
            }
            /*using (var connections = new SqlConnection(_connectionString))
            {
                connections.Open();
                using (SqlCommand command = connections.CreateCommand())
                {
                    foreach (var student_in_group in students_in_group)
                    {
                        command.CommandText =
                        @"select [Id], [Name]
                        from [Student]
                        where [Id] = @id";
                        command.Parameters.Add("@id", SqlDbType.Int).Value = student_in_group.StudentId;
                        using (var reader = command.ExecuteReader())
                        {
                            if (reader.Read())
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
            }*/        

            return result;
        }
    }
}
