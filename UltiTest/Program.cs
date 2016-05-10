using Microsoft.Owin.Hosting;
using System;
using System.Net.Http;
using System.Data.SqlClient;
using System.Collections.Generic;

namespace UltiTest
{
    public class Program
    {
        static void Main()
        {
            DatabaseAccess da = new DatabaseAccess();
            string json = da.GetEmployeesInJson();
            ValuesController.Json = json;

            Startup.StartOWINHost();

            Console.ReadLine();
        }
    }
}
