using System;
using System.Net.Http;
using System.Data.SqlClient;
using System.Collections.Generic;

namespace UltiTest
{
    public class DatabaseAccess
    {
        public string GetEmployeesInJson()
        {
            SqlConnection myConnection = CreateConnection("dev", "usg", "MichaelMW7X990", "TRAINING");
            IList<Employee> employees = GetEmployees(myConnection);
            string json = Serializer.Serialize(employees);
            return json;
        }

        private SqlConnection CreateConnection(String username, String password, String servername, String database, int connectionTimeout=30)
        {
            string connectionString = String.Format("user id={0};" +
                                                    "password={1};" +
                                                    "server={2};" +
                                                    "Database={3};" +
                                                    "connection timeout={4}", 
                                                    username, password, servername, database, connectionTimeout);
            SqlConnection myConnection = new SqlConnection(connectionString);
            return myConnection;
        }

        private IList<Employee> GetEmployees(SqlConnection myConnection)
        {
            try
            {
                myConnection.Open();
                string commandString = "Select * " +
                                        "From Employees";
                SqlCommand myCommand = new SqlCommand(commandString, myConnection);

                SqlDataReader myReader = myCommand.ExecuteReader();
                IList<Employee> list = new List<Employee>();
                while (myReader.Read())
                {
                    String ID = myReader["ID"].ToString();
                    String fname = myReader["FirstName"].ToString();
                    String lname = myReader["LastName"].ToString();
                    String addr = myReader["Address"].ToString();
                    Employee emp = new Employee(ID, fname, lname, addr);
                    list.Add(emp);
                }
                myConnection.Close();
                return list;
            }
            catch (Exception e)
            {
                //Console.WriteLine(e.ToString());
                throw e; // crash for easier debugging
            }
        }
    }
}
