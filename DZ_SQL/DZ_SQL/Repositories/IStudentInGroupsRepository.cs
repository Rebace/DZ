using DZ_SQL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DZ_SQL.Repositories
{
    interface IStudentInGroupsRepository
    {
        void Add(StudentInGroups studentInGroups);
        void DeleteById(StudentInGroups studentInGroups);
        List<StudentInGroups> GetByStudentIdAndGroupsId();
        List<Student> GetAllByIdGroups(int groupsId);
    }
}
