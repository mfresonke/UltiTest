using Microsoft.Owin.Hosting;
using System;
using System.Net.Http;
using System.Data.SqlClient;

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

            try
            {
                myConnection.Open();
                string commandString = "Select * " +
                                        "From Employees";
                SqlCommand myCommand = new SqlCommand(commandString, myConnection);

                SqlDataReader myReader = null;
                myReader = myCommand.ExecuteReader();
                while (myReader.Read())
                {
                    Console.WriteLine(myReader["ID"].ToString());
                }

            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }

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
