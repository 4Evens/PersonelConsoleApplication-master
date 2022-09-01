using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Abstract;
using DataAccess.Abstract.InMemory;

namespace Business.Concrete
{
    public class AuthManager : IAuthService
    {
        private readonly IMemoryAdminDal _memoryAdminDal;

        public AuthManager(IMemoryAdminDal memoryAdminDal)
        {
            _memoryAdminDal = memoryAdminDal;
        }

        public bool IsAdmin(string username, string password)
        {
            return _memoryAdminDal.IsExist(username,password);
        }
    }
}
