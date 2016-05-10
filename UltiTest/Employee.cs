using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UltiTest
{
    class Employee
    {
        public String ID { get; set; }
        public String FirstName { get; set; }
        public String LastName { get; set; }
        public String Address { get; set; }

        public Employee(String id, String fname, String lname, String addr)
        {
            this.ID = id;
            this.FirstName = fname;
            this.LastName = lname;
            this.Address = addr;
        }
    }
}
