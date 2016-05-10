using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace UltiTest
{
    public static class Serializer
    {
        public static string Serialize(object obj)
        {
            string json = JsonConvert.SerializeObject(obj);
            return json;
        }

        public static void Test()
        {
            Employee emp = new Employee("1", "Bob", "Steve", "123 Tehran Alaska");
            Employee emp2 = new Employee("2", "Ray", "Jim", "Mars street");
            IList<Employee> list = new List<Employee>();
            list.Add(emp);
            list.Add(emp2);
            string json = Serialize(list);
            Console.WriteLine(json);
        }
    }
}
