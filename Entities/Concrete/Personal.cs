using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities.Abstract;

namespace Entities.Concrete
{
    public class Personal : IEntity
    {
        public int Id { get; set; }
        public string DepartmantName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public DateOnly HolidayBeginnigTime { get; set; }
        public DateOnly HolidayFinishingTime { get; set; }

    }
}
