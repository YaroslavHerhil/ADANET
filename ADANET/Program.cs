using System.Data.SqlClient;
using System.Linq;


namespace ADANET
{
    internal class Program
    {

        public static string ConnectionString => "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=Students;Integrated Security=True;Connect Timeout=30;";
        static void Main()
        {


            Console.WriteLine("Connect to [Students]?(Y/N)");
            string responce = Console.ReadLine();
            if (responce != "N")
            {
                try
                {
                    bool exit = false;
                    string query = "";
                    while (!exit) {
                        Console.Clear();
                        Console.WriteLine("Select an option:\n\t1)Show Data\n\t2)Show full names of all students\n\t3)Show average grades\n\t4)Show studnets with average more than given\n\t5)List of student's worst average subjects\n\t6)Show minimal average grade\n\t7)Show maximum average grade\n\t8)Show students with bad average math grade\n\t9)Show students with good average math grade\n\t10)Show how many students there are in groups\n\t11)Show average grade per group\n\t0)Exit");
                        responce = Console.ReadLine();
                        switch (responce) 
                        {
                            case "1":
                                query = "SELECT * FROM Students";
                                using (SqlConnection connection = new SqlConnection(ConnectionString))
                                {
                                    connection.Open();
                                    using (SqlCommand cmd = new SqlCommand(query, connection))
                                    {
                                        SqlDataReader reader = cmd.ExecuteReader();
                                        
                                        while (reader.Read())
                                        {
                                            Console.WriteLine($"{reader["id"]}|{reader["FirstName"]}|{reader["MiddleName"]}|{reader["LastName"]}|{reader["Group"]}|{reader["AverageGrade"]}|{reader["BestSubject"]}|{reader["WorstSubject"]}\n-=-");
                                        }
                                    }
                                }
                                Console.ReadKey();
                                break;
                            case "2":
                                query = "SELECT id, FirstName, MiddleName, LastName FROM Students";
                                using (SqlConnection connection = new SqlConnection(ConnectionString))
                                {
                                    connection.Open();
                                    using (SqlCommand cmd = new SqlCommand(query, connection))
                                    {
                                        SqlDataReader reader = cmd.ExecuteReader();

                                        while (reader.Read())
                                        {
                                            Console.WriteLine($"{reader["id"]}\t|{reader["FirstName"]}|{reader["MiddleName"]}|{reader["LastName"]}");
                                        }
                                    }
                                }
                                Console.ReadKey();
                                break;
                            case "3":
                                query = "SELECT id, AverageGrade FROM Students";
                                using (SqlConnection connection = new SqlConnection(ConnectionString))
                                {
                                    connection.Open();
                                    using (SqlCommand cmd = new SqlCommand(query, connection))
                                    {
                                        SqlDataReader reader = cmd.ExecuteReader();

                                        while (reader.Read())
                                        {
                                            Console.WriteLine($"{reader["id"]}\t{reader["AverageGrade"]}");
                                        }
                                    }
                                }
                                Console.ReadKey();
                                break;
                            case "4":
                                Console.WriteLine("Enter minimal grade threshold");
                                if(!double.TryParse(Console.ReadLine(), out double bar))
                                {
                                    Console.WriteLine("Invalid input");Console.ReadLine();
                                    continue;
                                }


                                query = $"SELECT id, FirstName, MiddleName, LastName, AverageGrade FROM Students WHERE AverageGrade >= {bar}";
                                using (SqlConnection connection = new SqlConnection(ConnectionString))
                                {
                                    connection.Open();
                                    using (SqlCommand cmd = new SqlCommand(query, connection))
                                    {
                                        SqlDataReader reader = cmd.ExecuteReader();

                                        while (reader.Read())
                                        {
                                            Console.WriteLine($"{reader["id"]}\t|{reader["FirstName"]}|{reader["MiddleName"]}|{reader["LastName"]}");
                                        }
                                    }
                                }
                                Console.ReadKey();
                                break;
                            case "5":

                                query = $"SELECT DISTINCT WorstSubject FROM Students ";
                                using (SqlConnection connection = new SqlConnection(ConnectionString))
                                {
                                    connection.Open();
                                    using (SqlCommand cmd = new SqlCommand(query, connection))
                                    {
                                        SqlDataReader reader = cmd.ExecuteReader();

                                        while (reader.Read())
                                        {
                                            Console.Write($"{reader["WorstSubject"]} ");
                                        }
                                    }
                                }
                                Console.ReadKey();
                                break;
                            case "6":

                                query = $"SELECT MIN(AverageGrade) AS MinimalGrade FROM Students ";
                                using (SqlConnection connection = new SqlConnection(ConnectionString))
                                {
                                    connection.Open();
                                    using (SqlCommand cmd = new SqlCommand(query, connection))
                                    {
                                        SqlDataReader reader = cmd.ExecuteReader();

                                        while (reader.Read())
                                        {
                                            Console.Write($"{reader["MinimalGrade"]} ");
                                        }
                                    }
                                }
                                Console.ReadKey();
                                break;
                            case "7":

                                query = $"SELECT MAX(AverageGrade) AS MaximalGrade FROM Students ";
                                using (SqlConnection connection = new SqlConnection(ConnectionString))
                                {
                                    connection.Open();
                                    using (SqlCommand cmd = new SqlCommand(query, connection))
                                    {
                                        SqlDataReader reader = cmd.ExecuteReader();

                                        while (reader.Read())
                                        {
                                            Console.Write($"{reader["MaximalGrade"]} ");
                                        }
                                    }
                                }
                                Console.ReadKey();
                                break;
                            case "8":

                                query = $"SELECT COUNT(WorstSubject) AS BadMathStudents FROM Students GROUP BY WorstSubject  HAVING WorstSubject LIKE 'Math'";
                                using (SqlConnection connection = new SqlConnection(ConnectionString))
                                {
                                    connection.Open();
                                    using (SqlCommand cmd = new SqlCommand(query, connection))
                                    {
                                        SqlDataReader reader = cmd.ExecuteReader();

                                        while (reader.Read())
                                        {
                                            Console.Write($"{reader["BadMathStudents"]} ");
                                        }
                                    }
                                }
                                Console.ReadKey();
                                break;
                            case "9":

                                query = $"SELECT COUNT(BestSubject) AS GoodMathStudents FROM Students GROUP BY BestSubject  HAVING BestSubject LIKE 'Math'";
                                using (SqlConnection connection = new SqlConnection(ConnectionString))
                                {
                                    connection.Open();
                                    using (SqlCommand cmd = new SqlCommand(query, connection))
                                    {
                                        SqlDataReader reader = cmd.ExecuteReader();

                                        while (reader.Read())
                                        {
                                            Console.Write($"{reader["GoodMathStudents"]} ");
                                        }
                                    }
                                }
                                Console.ReadKey();
                                break;
                            case "10":

                                query = $"SELECT [Group], COUNT(id) AS StudentsCount FROM Students GROUP BY [Group]";
                                using (SqlConnection connection = new SqlConnection(ConnectionString))
                                {
                                    connection.Open();
                                    using (SqlCommand cmd = new SqlCommand(query, connection))
                                    {
                                        SqlDataReader reader = cmd.ExecuteReader();

                                        while (reader.Read())
                                        {
                                            Console.WriteLine($"{reader["Group"]}:\t{reader["StudentsCount"]}");
                                        }
                                    }
                                }
                                Console.ReadKey();
                                break;
                            case "11":
                                query = $"SELECT [Group], AVG(AverageGrade) AS AverageGroupGrade FROM Students GROUP BY [Group]";
                                using (SqlConnection connection = new SqlConnection(ConnectionString))
                                {
                                    connection.Open();
                                    using (SqlCommand cmd = new SqlCommand(query, connection))
                                    {
                                        SqlDataReader reader = cmd.ExecuteReader();

                                        while (reader.Read())
                                        {
                                            Console.WriteLine($"{reader["Group"]}:\t{reader["AverageGroupGrade"]}");
                                        }
                                    }
                                }
                                Console.ReadKey();
                                break;
                            case "0":
                                exit = true;
                                break;
                            default:break;
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

        }
    }
}
