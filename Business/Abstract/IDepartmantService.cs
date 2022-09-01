using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Entities.Concrete;

namespace Business.Abstract
{
    public interface IDepartmantService
    {
        void Add(Departmant departmant);
        void Remove(Departmant departmant);
        List<Departmant> GetAll();
        Departmant GetDepartmant(string departmantName);
    }
}
