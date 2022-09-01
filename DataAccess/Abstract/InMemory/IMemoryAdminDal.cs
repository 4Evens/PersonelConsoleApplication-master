using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstract.InMemory
{
    public interface IMemoryAdminDal
    {
        bool IsExist(string username, string password);
    }
}
