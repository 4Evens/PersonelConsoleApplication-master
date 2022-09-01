using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities.Concrete;

namespace DataAccess.Abstract.InMemory
{
    public interface IMemoryDepartmantDal
    {
        void Add(Departmant departmant);
        void Remove(Departmant departmant);
        List<Departmant> GetAll();
    }
}
