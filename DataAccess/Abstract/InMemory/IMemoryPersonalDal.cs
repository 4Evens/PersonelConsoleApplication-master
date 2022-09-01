using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities.Concrete;

namespace DataAccess.Abstract.InMemory
{
    public interface IMemoryPersonalDal
    {

        void Add(Personal personal);
        void Remove(Personal personal);
        List<Personal> GetAll();
        Personal Get(int id);
    }
}
