using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleDatabaseConnect
{
    class Program
    {
        const string ConnString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Vadimus\Documents\CSharpProjects\Database\Session 7\SimpleDatabaseConnect\SimpleDatabaseConnect\SimpleDatabaseConnect\simpleDatabase.mdf;Integrated Security=True;Connect Timeout=30";
        static void Main(string[] args)
        {
            try
            {
                SqlConnection conn = new SqlConnection(ConnString);
                conn.Open();
                {//insertion

                    Random random = new Random();
                    //insert to db
                    using (SqlCommand cmd = new SqlCommand("INSERT INTO People (Name, Age, Telephone) VALUES (@Name, @Age, @Tel)", conn))
                    {
                        cmd.Parameters.AddWithValue("@Name", "toto");
                        cmd.Parameters.AddWithValue("@Age", random.Next(5, 90));
                        cmd.Parameters.AddWithValue("@Tel", random.Next(5000, 80000).ToString());
                        cmd.ExecuteNonQuery();
                    }
                }
                {//Select
                    using (SqlCommand cmd = new SqlCommand("SELECT * FROM People", conn))
                    {
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                int id = reader.GetInt32(reader.GetOrdinal("Id"));
                                int age = reader.GetInt32(reader.GetOrdinal("Age"));
                                string name = reader.GetString(reader.GetOrdinal("Name"));
                                string tel = reader.GetString(reader.GetOrdinal("Telephone"));

                                Console.WriteLine($"{id} and {age} and {name} and {tel}");
                            }
                        }
                    }
                }

                { // select specific record
                    int wantId = 3; // looking for this one record
                    Console.WriteLine("Lookin for record with Id=" + wantId);
                    using (SqlCommand cmd = new SqlCommand("SELECT * FROM People WHERE Id=@Id", conn))
                    {
                        cmd.Parameters.AddWithValue("@Id", wantId);
                        using (SqlDataReader reader = cmd.ExecuteReader()) // ex
                        {
                            if (reader.Read())
                            {
                                //int id = (int)reader["Id"];
                                //int id = reader.GetInt32(0);
                                int id = reader.GetInt32(reader.GetOrdinal("Id"));
                                string name = reader.GetString(reader.GetOrdinal("Name"));
                                int age = reader.GetInt32(reader.GetOrdinal("Age"));
                                Console.WriteLine("{0}: {1} is {2} y/o", id, name, age);
                            }
                            else
                            {
                                Console.WriteLine("Record not found");
                            }
                        }
                    }
                }
            }
            catch (SqlException exception)
            {
                Console.WriteLine(exception.Message);
            }
        }
    }
}
