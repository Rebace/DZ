using DZ_SQL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DZ_SQL.Repositories
{
    interface IStudentRepository
    {
        void Add(Student student);
        void DeleteById(int id);
        Student GetById(int id);
        List<Student> GetAll();
        void Update(Student student);
    }
}
