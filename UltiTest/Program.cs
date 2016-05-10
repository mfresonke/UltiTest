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
            SqlConnection myConnection = new SqlConnection("user id=dev;" +
                                       "password=usg;server=MichaelMW7X990;" +
                                       "Database=TRAINING;" +
                                       "connection timeout=30");

            string json = "fail";
            try
            {
                myConnection.Open();
                string commandString = "Select * " +
                                        "From Employees";
                SqlCommand myCommand = new SqlCommand(commandString, myConnection);

                SqlDataReader myReader = null;
                myReader = myCommand.ExecuteReader();
                IList<Employee> list = new List<Employee>();
                while (myReader.Read())
                {
                    String ID = myReader["ID"].ToString();
                    String fname = myReader["FirstName"].ToString();
                    String lname = myReader["LastName"].ToString();
                    String addr = myReader["Address"].ToString();
                    Employee emp = new Employee(ID, fname, lname, addr);
                    list.Add(emp);
                    //Console.WriteLine(myReader["ID"].ToString());
                }
                json = Serializer.Serialize(list);
                ValuesController.json = json;

                myConnection.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }

            //Console.WriteLine(json);

            // Serializer.Test();

            string baseAddress = "http://localhost:9000/";

            // Start OWIN host 
            using (WebApp.Start<Startup>(url: baseAddress))
            {
                // Create HttpCient and make a request to api/values 
                HttpClient client = new HttpClient();

                var response = client.GetAsync(baseAddress + "api/values").Result;

                Console.WriteLine(response);
                Console.WriteLine(response.Content.ReadAsStringAsync().Result);
            }

            Console.ReadLine();
        }
    }
}
