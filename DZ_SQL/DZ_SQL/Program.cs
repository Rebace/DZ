using DZ_SQL.Models;
using DZ_SQL.Repositories;
using System;
using System.Collections.Generic;

namespace DZ_SQL
{
    class Program
    {
        private static string _connectionString = @"Data Source=LAPTOP-SKV4LIGT\SQLEXPRESS;Initial Catalog=university;Pooling=true;Integrated Security=SSPI";

        static void Main(string[] args)
        {
            IStudentRepository studentRepository = new StudentRawSqlRepository(_connectionString);
            IGroupsRepository groupsRepository = new GroupsRawSqlRepository(_connectionString);
            IStudentInGroupsRepository studentInGroupsRepository = new StudentInGroupsRawSqlRepository(_connectionString);

            Console.WriteLine("Доступные команды:");
            Console.WriteLine("get-students - показать список студентов");
            Console.WriteLine("add-student - добавить студента");
            Console.WriteLine("update-student - изменить студента");
            Console.WriteLine("delete-student - удалить студента");
            Console.WriteLine("get-groups - показать список групп");
            Console.WriteLine("add-group - добавить группу");
            Console.WriteLine("update-group - изменить группу");
            Console.WriteLine("delete-group - удалить группу");
            Console.WriteLine("add-student-in-group - добавить студента в группу");
            Console.WriteLine("delete-student-in-group - удалить студента из группы");
            Console.WriteLine("get-students-in-group - показать список студентов в группе");
            Console.WriteLine("get-student-in-group - показать группы у студента");
            Console.WriteLine("report - отчёт");
            Console.WriteLine("exit - выйти из приложения");

            while (true)
            {
                string command = Console.ReadLine();

                if (command == "get-students")
                {
                    List<Student> students = studentRepository.GetAll();
                    if (students.Count < 1)
                    {
                        Console.WriteLine("Нет ни одного студента");
                        continue;
                    }
                    foreach (Student student in students)
                    {
                        Console.WriteLine($"Id: {student.Id}, Name: {student.Name}");
                    }
                }
                else if (command == "add-student")
                {
                    Console.WriteLine("Введите имя студента");
                    string name = Console.ReadLine();
                    if (String.IsNullOrEmpty(name))
                    {
                        Console.WriteLine("Имя не может быть пустым");
                        continue;
                    }
                    Console.WriteLine("Введите возраст студента");
                    if (!Int32.TryParse(Console.ReadLine(), out int age))
                    {
                        Console.WriteLine("Вводите возраст цифрами");
                        continue;
                    }

                    studentRepository.Add(new Student
                    {
                        Name = name,
                        Age = age
                    });
                    Console.WriteLine("Успешно добавлено");
                }
                else if (command == "update-student")
                {
                    Console.WriteLine("Введите id студента");
                    if (!Int32.TryParse(Console.ReadLine(), out int studentId))
                    {
                        Console.WriteLine("Вводите Id цифрами");
                        return;
                    }

                    Student student = studentRepository.GetById(studentId);

                    if (student == null)
                    {
                        Console.WriteLine("Студент не найден");
                        continue;
                    }

                    Console.WriteLine("Введите новое имя студента");
                    student.Name = Console.ReadLine();
                    if (String.IsNullOrEmpty(student.Name))
                    {
                        Console.WriteLine("Имя не может быть пустым");
                        continue;
                    }

                    Console.WriteLine("Введите новый возраст студента");

                    if (!Int32.TryParse(Console.ReadLine(), out int age))
                    {
                        Console.WriteLine("Вводите возраст цифрами");
                        continue;
                    }
                    student.Age = age;

                    studentRepository.Update(student);
                    Console.WriteLine("Успешно обновлено");
                }
                else if (command == "delete-student")
                {
                    Console.WriteLine("Введите id студента");
                    if (!Int32.TryParse(Console.ReadLine(), out int studentId))
                    {
                        Console.WriteLine("Вводите id цифрами");
                        continue;
                    }
                    var student = studentRepository.GetById(studentId);
                    if (student == null)
                    {
                        Console.WriteLine("Студент не найден");
                        continue;
                    }

                    studentRepository.DeleteById(student.Id);
                    Console.WriteLine("Успешно удалено");
                }
                else if (command == "get-groups")
                {
                    List<Groups> groups = groupsRepository.GetAll();
                    if (groups.Count < 1)
                    {
                        Console.WriteLine("Нет ни одной группы");
                        continue;
                    }
                    foreach (Groups group in groups)
                    {
                        Console.WriteLine($"Id: {group.Id}, Name: {group.Name}");
                    }
                }
                else if (command == "add-group")
                {
                    Console.WriteLine("Введите имя группы");
                    string name = Console.ReadLine();
                    if (String.IsNullOrEmpty(name))
                    {
                        Console.WriteLine("Имя не может быть пустым");
                        continue;
                    }

                    groupsRepository.Add(new Groups
                    {
                        Name = name
                    });
                    Console.WriteLine("Успешно добавлено");
                }
                else if (command == "update-group")
                {
                    Console.WriteLine("Введите id группы");
                    if (!Int32.TryParse(Console.ReadLine(), out int groupsId))
                    {
                        Console.WriteLine("Вводите id цифрами");
                        continue;
                    }
                    Groups groups = groupsRepository.GetById(groupsId);

                    if (groups == null)
                    {
                        Console.WriteLine("Группа не найден");
                        continue;
                    }

                    Console.WriteLine("Введите новое имя группы");
                    groups.Name = Console.ReadLine();
                    if (String.IsNullOrEmpty(groups.Name))
                    {
                        Console.WriteLine("Имя не может быть пустым");
                        continue;
                    }

                    groupsRepository.Update(groups);
                    Console.WriteLine("Успешно обновлено");
                }
                else if (command == "delete-group")
                {
                    Console.WriteLine("Введите id группы");
                    if (!Int32.TryParse(Console.ReadLine(), out int groupsId))
                    {
                        Console.WriteLine("Вводите id цифрами");
                        continue;
                    }
                    var groups = groupsRepository.GetById(groupsId);
                    if (groups == null)
                    {
                        Console.WriteLine("Группа не найден");
                        continue;
                    }

                    groupsRepository.DeleteById(groups.Id);
                    Console.WriteLine("Успешно удалено");
                }
                else if (command == "add-student-in-group")
                {
                    Console.WriteLine("Введите id студента которого хотите добавить в группу");
                    if (!Int32.TryParse(Console.ReadLine(), out int studentId))
                    {
                        Console.WriteLine("Вводите id цифрами");
                        continue;
                    }
                    Student student = studentRepository.GetById(studentId);

                    if (student == null)
                    {
                        Console.WriteLine("Студент не найден");
                        continue;
                    }
                    Console.WriteLine("Введите id группы в которую хотите добавить студента");
                    if (!Int32.TryParse(Console.ReadLine(), out int groupsId))
                    {
                        Console.WriteLine("Вводите id цифрами");
                        continue;
                    }
                    Groups groups = groupsRepository.GetById(groupsId);

                    if (groups == null)
                    {
                        Console.WriteLine("Группа не найден");
                        continue;
                    }

                    List<StudentInGroups> studentInGroups = studentInGroupsRepository.GetByStudentIdAndGroupsId();
                    if (!((studentInGroups.Exists(x => (x.StudentId == studentId))) && (studentInGroups.Exists(x => (x.GroupsId == groupsId)))))
                    {
                        studentInGroupsRepository.Add(new StudentInGroups
                        {
                            StudentId = studentId,
                            GroupsId = groupsId
                        });
                        Console.WriteLine("Успешно добавлено");
                    }
                    else
                    {
                        Console.WriteLine("Студент уже есть в группе");
                    }
                }
                else if (command == "get-students-in-group")
                {
                    Console.WriteLine("Введите id группы в которой хотите узнать студентов");
                    if (!Int32.TryParse(Console.ReadLine(), out int groupsId))
                    {
                        Console.WriteLine("Вводите id цифрами");
                        continue;
                    }
                    if (groupsRepository.GetById(groupsId) == null)
                    {
                        Console.WriteLine("Группа не найден");
                        continue;
                    }

                    List<StudentInGroups> studentsInGroups = studentInGroupsRepository.GetByStudentIdAndGroupsId();
                    var student = new Student();
                    foreach (var studentInGroups in studentsInGroups)
                    {
                        if (studentInGroups.GroupsId == groupsId)
                        {
                            student = studentRepository.GetById(studentInGroups.StudentId);
                            Console.WriteLine($"Id: {student.Id}, Name: {student.Name}");
                        }
                    }

                    if (student.Id < 1)
                    {
                        Console.WriteLine($"Нет ни одного студента");
                    }
                }
                else if (command == "delete-student-in-group")
                {
                    Console.WriteLine("Введите id группы из которой хотите удалить студента");
                    if (!Int32.TryParse(Console.ReadLine(), out int groupsId))
                    {
                        Console.WriteLine("Вводите id цифрами");
                        continue;
                    }
                    var groups = groupsRepository.GetById(groupsId);
                    if (groups == null)
                    {
                        Console.WriteLine("Группа не найден");
                        continue;
                    }

                    Console.WriteLine("Введите id студента которого хотите удалить");
                    if (!Int32.TryParse(Console.ReadLine(), out int studentId))
                    {
                        Console.WriteLine("Вводите id цифрами");
                        continue;
                    }
                    var student = studentRepository.GetById(studentId);
                    if (student == null)
                    {
                        Console.WriteLine("Студент не найден");
                        continue;
                    }

                    studentInGroupsRepository.DeleteById(new StudentInGroups
                    {
                        GroupsId = groupsId,
                        StudentId = studentId
                    });
                    Console.WriteLine("Успешно удалено");
                }
                else if (command == "get-student-in-group")
                {
                    Console.WriteLine("Введите id студента у которого хотите узнать группы");
                    if (!Int32.TryParse(Console.ReadLine(), out int studentId))
                    {
                        Console.WriteLine("Вводите id цифрами");
                        continue;
                    }
                    Student student = studentRepository.GetById(studentId);
                    if (student == null)
                    {
                        Console.WriteLine("Студент не найден");
                        continue;
                    }

                    List<StudentInGroups> studentsInGroups = studentInGroupsRepository.GetByStudentIdAndGroupsId();
                    var groups = new Groups();
                    foreach (var studentInGroup in studentsInGroups)
                    {
                        if (studentInGroup.StudentId == studentId)
                        {
                            groups = groupsRepository.GetById(studentInGroup.GroupsId);
                            Console.WriteLine($"Id: {groups.Id}, Name: {groups.Name}");
                        }
                    }
                    if (groups.Id < 1)
                    {
                        Console.WriteLine($"Нет ни одной группы");
                    }
                }
                else if (command == "report")
                {
                    List<Groups> groups = groupsRepository.GetAll();
                    if (groups.Count < 1)
                    {
                        Console.WriteLine("Нет ни одной группы");
                        continue;
                    }
                    foreach (Groups group in groups)
                    {
                        Console.Write($"Группа: {group.Name} ");
                        List<Student> studentsInGroups = studentInGroupsRepository.GetAllByIdGroups(group.Id);
                        if (studentsInGroups.Count < 1)
                        {
                            Console.WriteLine("Нет ни одного студента");
                        }
                        else
                        {
                            Console.WriteLine($"Студентов в группе: {studentsInGroups.Count}");
                        }

                    }
                }
                else if (command == "exit")
                {
                    return;
                }
                else
                {
                    Console.WriteLine("Команда не найдена");
                }
            }
        }
    }
}
