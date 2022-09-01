using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities.Abstract;

namespace Entities.Concrete
{
    public class Admin : IEntity
    {
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}
