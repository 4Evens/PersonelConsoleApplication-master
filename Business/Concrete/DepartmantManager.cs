using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Business.Abstract;
using DataAccess.Abstract.InMemory;
using Entities.Concrete;

namespace Business.Concrete
{
    public class DepartmantManager : IDepartmantService
    {
        private readonly IMemoryDepartmantDal _memoryDepartmantDal;

        public DepartmantManager(IMemoryDepartmantDal memoryDepartmantDal)
        {
            _memoryDepartmantDal = memoryDepartmantDal;
        }

        public void Add(Departmant departmant)
        {
            _memoryDepartmantDal.Add(departmant);
        }

        public List<Departmant> GetAll()
        {
            return _memoryDepartmantDal.GetAll();
        }

        public Departmant GetDepartmant(string departmantName)
        {
            return _memoryDepartmantDal.GetAll().SingleOrDefault(p => p.DepartmantName == departmantName.ToUpper());
        }

        public void Remove(Departmant departmant)
        {
            _memoryDepartmantDal.Remove(departmant);
        }
    }
}
