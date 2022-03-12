using DZ_SQL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DZ_SQL.Repositories
{
    interface IGroupsRepository
    {
        void Add(Groups groups);
        void DeleteById(int id);
        Groups GetById(int id);
        List<Groups> GetAll();
        void Update(Groups groups);
    }
}
