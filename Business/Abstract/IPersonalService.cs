using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Entities.Concrete;

namespace Business.Abstract
{
    public interface IPersonalService
    {
        void Add(Personal personel);
        void Remove(Personal personel);
        List<Personal> GetAll();
        Personal Get(int id);
        List<Personal> GetPersonalByDepartman(string departmantName);
        List<Personal> GetPersonalsByHolidayDate();

    }
}
