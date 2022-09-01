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
    public class PersonalManager : IPersonalService
    {
        private readonly IMemoryPersonalDal _memoryPersonalDal;

        public PersonalManager(IMemoryPersonalDal memoryPersonalDal)
        {
            _memoryPersonalDal = memoryPersonalDal;
        }

        public void Add(Personal personel)
        {
            _memoryPersonalDal.Add(personel);
        }

        public Personal Get(int id)
        {
            return _memoryPersonalDal.Get(id);
        }

        public List<Personal> GetAll()
        {
           return _memoryPersonalDal.GetAll();
        }

        public List<Personal> GetPersonalByDepartman(string departmantName)
        {
            return _memoryPersonalDal.GetAll().Where(p => p.DepartmantName == departmantName).ToList();
        }

        public List<Personal> GetPersonalsByHolidayDate()
        {
            return _memoryPersonalDal.GetAll().Where(p=>p.HolidayBeginnigTime < DateOnly.FromDateTime(DateTime.UtcNow.AddDays(10)) && p.HolidayFinishingTime >DateOnly.FromDateTime(DateTime.UtcNow)).ToList();
        }

        public void Remove(Personal personel)
        {
            _memoryPersonalDal.Remove(personel);
        }
    }
}
