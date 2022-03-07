using DZ_SQL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DZ_SQL.Repositories
{
    interface IGroupRepository
    {
        void Add(Group group);
        void DeleteById(int id);
        Group GetById(int id);
        List<Group> GetAll();
        void Update(Group group);
    }
}
