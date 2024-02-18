using System.Data.SqlClient;


namespace ADANET
{
    internal class Program
    {

        public static string ConnectionString => "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=Students;Integrated Security=True;Connect Timeout=30;";
        static void Main()
        {

            string query = "SELECT * FROM Students;";

            Console.WriteLine("Connect to [Students]?(Y/N)");
            string responce = Console.ReadLine();
            if (responce == "Y")
            {
                try
                {

                    using (SqlConnection connection = new SqlConnection(ConnectionString))
                    {
                        connection.Open();
                        using (SqlCommand cmd = new SqlCommand(query, connection))
                        {
                            SqlDataReader reader = cmd.ExecuteReader();
                            while (reader.Read())
                            {
                                Console.WriteLine(reader["FirstName"]);
                                Console.WriteLine(reader["MiddleName"]);
                                Console.WriteLine(reader["LastName"]);
                                Console.WriteLine(reader["Group"]);
                                Console.WriteLine(reader["AverageGrade"]);
                                Console.WriteLine(reader["BestSubject"]);
                                Console.WriteLine(reader["WorstSubject"]);

                            }


                        }
                    }

                }catch (Exception ex)
                {
                    Console.WriteLine("Error while connecting to [Students]; Error: " + ex.Message);

                }
            }
            else
            {
                Console.WriteLine("Connection terminated");

            }

            Console.ReadKey();
        }
    }
}
