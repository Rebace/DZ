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
            IGroupRepository groupRepository = new GroupRawSqlRepository(_connectionString);
            IStudent_in_groupRepository student_In_GroupRepository = new Student_in_groupRawSqlRepository(_connectionString);

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
                    List<Group> groups = groupRepository.GetAll();
                    if (groups.Count < 1)
                    {
                        Console.WriteLine("Нет ни одной группы");
                        continue;
                    }
                    foreach (Group group in groups)
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

                    groupRepository.Add(new Group
                    {
                        Name = name
                    });
                    Console.WriteLine("Успешно добавлено");
                }
                else if (command == "update-group")
                {
                    Console.WriteLine("Введите id группы");
                    if (!Int32.TryParse(Console.ReadLine(), out int groupId))
                    {
                        Console.WriteLine("Вводите id цифрами");
                        continue;
                    }
                    Group group = groupRepository.GetById(groupId);

                    if (group == null)
                    {
                        Console.WriteLine("Группа не найден");
                        continue;
                    }

                    Console.WriteLine("Введите новое имя группы");
                    group.Name = Console.ReadLine();
                    if (String.IsNullOrEmpty(group.Name))
                    {
                        Console.WriteLine("Имя не может быть пустым");
                        continue;
                    }

                    groupRepository.Update(group);
                    Console.WriteLine("Успешно обновлено");
                }
                else if (command == "delete-group")
                {
                    Console.WriteLine("Введите id группы");
                    if (!Int32.TryParse(Console.ReadLine(), out int groupId))
                    {
                        Console.WriteLine("Вводите id цифрами");
                        continue;
                    }
                    var group = groupRepository.GetById(groupId);
                    if (group == null)
                    {
                        Console.WriteLine("Группа не найден");
                        continue;
                    }

                    groupRepository.DeleteById(group.Id);
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
                    Console.WriteLine("Введите id группы в которую хотите добавить студента");
                    if (!Int32.TryParse(Console.ReadLine(), out int groupId))
                    {
                        Console.WriteLine("Вводите id цифрами");
                        continue;
                    }

                    List<Student_in_group> student_in_groups = student_In_GroupRepository.GetByIdStudent(studentId);
                    if (!((student_in_groups.Exists(x => (x.StudentId == studentId))) & (student_in_groups.Exists(x => (x.GroupId == groupId)))))
                    {
                        student_In_GroupRepository.Add(new Student_in_group
                        {
                            StudentId = studentId,
                            GroupId = groupId
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
                    if (!Int32.TryParse(Console.ReadLine(), out int groupId))
                    {
                        Console.WriteLine("Вводите id цифрами");
                        continue;
                    }

                    List<Student> students_in_group = student_In_GroupRepository.GetAllByIdGroup(groupId);
                    if (students_in_group.Count < 1)
                    {
                        Console.WriteLine("Нет ни одного студента");
                        continue;
                    }

                    var student = new Student();
                    foreach (var student_in_group in students_in_group)
                    {
                        student = studentRepository.GetById(student_in_group.Id);
                        Console.WriteLine($"Id: {student.Id}, Name: {student.Name}");
                    }
                }
                else if (command == "delete-student-in-group")
                {
                    Console.WriteLine("Введите id группы из которой хотите удалить студента");
                    if (!Int32.TryParse(Console.ReadLine(), out int groupId))
                    {
                        Console.WriteLine("Вводите id цифрами");
                        continue;
                    }
                    var group = groupRepository.GetById(groupId);
                    if (group == null)
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

                    student_In_GroupRepository.DeleteById(new Student_in_group
                    {
                        GroupId = groupId,
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

                    List<Student_in_group> student_in_groups = student_In_GroupRepository.GetByIdStudent(studentId);
                    var group = new Group();
                    foreach (var student_in_group in student_in_groups)
                    {
                        group = groupRepository.GetById(student_in_group.GroupId);
                        Console.WriteLine($"Id: {group.Id}, Name: {group.Name}");
                    }
                }
                else if (command == "report")
                {
                    List<Group> groups = groupRepository.GetAll();
                    if (groups.Count < 1)
                    {
                        Console.WriteLine("Нет ни одной группы");
                        continue;
                    }
                    foreach (Group group in groups)
                    {
                        Console.Write($"Группа: {group.Name} ");
                        List<Student> students_in_group = student_In_GroupRepository.GetAllByIdGroup(group.Id);
                        if (students_in_group.Count < 1)
                        {
                            Console.WriteLine("Нет ни одного студента");
                        }
                        else
                        {
                            Console.WriteLine($"Студентов в группе: {students_in_group.Count}");
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
