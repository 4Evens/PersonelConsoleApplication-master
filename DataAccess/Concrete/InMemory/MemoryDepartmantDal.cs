using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Abstract.InMemory;
using Entities.Concrete;

namespace DataAccess.Concrete.InMemory
{
    public class MemoryDepartmantDal : IMemoryDepartmantDal
    {
        List<Departmant> _departmants;

        public MemoryDepartmantDal()
        {
            //Fake Data For Departmants
            _departmants = new List<Departmant>
            {
            new Departmant() { Id = 1, DepartmantName = "IT" },
            new Departmant() { Id = 2, DepartmantName = "HR" },
            new Departmant() { Id = 3, DepartmantName = "EMPLOYEE" },
            new Departmant() { Id = 4, DepartmantName = "SECURE" },
            new Departmant() { Id = 5, DepartmantName = "MENAGEMENT" }
            };
        }
        public void Add(Departmant departmant)
        {
            _departmants.Add(departmant);
        }

        public List<Departmant> GetAll()
        {
            return _departmants.ToList();
        }

        public void Remove(Departmant departmant)
        {
            _departmants.Remove(departmant);
        }
    }
}
