using DZ_SQL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DZ_SQL.Repositories
{
    interface IStudent_in_groupRepository
    {
        void Add(Student_in_group student_In_Group);
        void DeleteById(Student_in_group student_In_Group);
        List<Student_in_group> GetByIdStudent(int studentId);
        List<Student> GetAllByIdGroup(int groupId);
    }
}
