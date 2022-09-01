using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Abstract.InMemory;
using Entities.Concrete;

namespace DataAccess.Concrete.InMemory
{
    public class MemoryAdminDal : IMemoryAdminDal
    {
        List<Admin> _admin;

        public MemoryAdminDal()
        {
            //Fake Data For Admins
            _admin = new List<Admin>
            {
            new Admin() { UserName="admin1",Password ="1234"},
            new Admin() { UserName="admin2",Password ="1234"}
            };
        }
        public bool IsExist(string username, string password)
        {
            return _admin.Where(a => a.UserName == username && a.Password == password).Any();
        }
    }
}
