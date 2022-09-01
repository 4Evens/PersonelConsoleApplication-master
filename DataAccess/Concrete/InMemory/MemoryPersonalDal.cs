using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Abstract.InMemory;
using Entities.Concrete;

namespace DataAccess.Concrete.InMemory
{
    public class MemoryPersonalDal : IMemoryPersonalDal
    {
        List<Personal> _personels;
        //Fake Data For Personels
        public MemoryPersonalDal()
        {

            _personels = new List<Personal>
            {
                new()
                {
                    Id = 1,
                    DepartmantName = "IT",
                    FirstName = "Engin1",
                    LastName = "Nacar1",
                    HolidayBeginnigTime = new DateOnly(2022, 9, 1),
                    HolidayFinishingTime = new DateOnly(2022, 09, 15)
                },
                new()
                {
                     Id = 2,
                     DepartmantName = "HR",
                     FirstName = "Engin2",
                     LastName = "Nacar2",
                     HolidayBeginnigTime = new DateOnly(2022, 08, 23),
                     HolidayFinishingTime = new DateOnly(2022, 09, 01)
                },
                new()
                {
                Id = 3,
                DepartmantName = "Employee",
                FirstName = "Engin3",
                LastName = "Nacar3",
                HolidayBeginnigTime = new DateOnly(2022, 08, 27),
                HolidayFinishingTime = new DateOnly(2022, 09, 15)
                },
                new()
                {
                Id = 4,
                DepartmantName = "Secure",
                FirstName = "Engin4",
                LastName = "Nacar4",
                HolidayBeginnigTime = new DateOnly(2022, 9, 1),
                HolidayFinishingTime = new DateOnly(2022, 09, 15)
                },
                new()
                {
                Id = 5,
                DepartmantName = "Menagement",
                FirstName = "Engin5",
                LastName = "Nacar5",
                HolidayBeginnigTime = new DateOnly(2022, 9, 1),
                HolidayFinishingTime = new DateOnly(2022, 09, 15)
                }
        };


        }
        public void Add(Personal personel)
        {
            _personels.Add(personel);
        }

        public Personal Get(int id)
        {
            return _personels.SingleOrDefault(p => p.Id == id);

        }

        public List<Personal> GetAll()
        {
            return _personels;
        }

        public void Remove(Personal personel)
        {
            _personels.Remove(personel);
        }
    }
}
