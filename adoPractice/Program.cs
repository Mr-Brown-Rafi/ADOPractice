using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Configuration;

namespace adoPractice
{
    class Program
    {
        static void Main(string[] args)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["rafidb"].ConnectionString;

            SqlConnection connection = new SqlConnection(connectionString);

            string query = "SELECT * FROM Student;";

            SqlCommand commmand = new SqlCommand(query, connection);

            try
            {
                connection.Open();
                SqlDataReader Result = commmand.ExecuteReader();


                while (Result.Read())
                {
                    int id = int.Parse(Result[0].ToString());
                    string name = Result[1].ToString();
                    int age = int.Parse(Result[2].ToString());
                    DateTime DOB = DateTime.Parse(Result[3].ToString());
                    float marks = float.Parse(Result[4].ToString());

                    Console.WriteLine($"{id}    {name}  {age}   {DOB}   {marks}");
                    Console.ReadKey();

                }
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
                Console.ReadKey();
            }
            finally
            {
                connection.Close();
            }


        }
    }
}
