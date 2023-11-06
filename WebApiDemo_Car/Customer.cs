using Microsoft.Data.SqlClient;
using System.ComponentModel.DataAnnotations;
using System.Data;

namespace WebApiDemo_Car
{
    public class Customer
    {
        [Key]
        public int CustomerId { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 3)]
        public string Name { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 3)]
        public string Surname { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 3)]
        public string PhoneNumber { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 3)]
        public string Email { get; set; }

        [Required]
        [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[@$!%*?&])[A-Za-z\d@$!%*?&]{8,}$",
            ErrorMessage = "Password must be at least 8 characters long and contain at least one uppercase letter, one lowercase letter, one digit, and one special character.")]
        public string Password { get; set; }



        //public static List<Car> GetAll()
        //    {
        //        List<Car> list = new List<Car>();

        //        SqlConnection con = new SqlConnection();

        //        con.ConnectionString = @"Data Source=(localdb)\ProjectModels;Initial Catalog=CarRental;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False";

        //        try
        //        {
        //            con.Open();
        //            SqlCommand cmd = new SqlCommand();
        //            cmd.Connection = con;
        //            cmd.CommandType = CommandType.Text;
        //            cmd.CommandText = "Select * from Car";

        //            SqlDataReader dr = cmd.ExecuteReader();
        //            while (dr.Read())
        //            {
        //                Customer  cust = new Customer();
        //                cust.CustomerId = dr.GetInt32("CustomerId");
        //                cust.Name = dr.GetString("Name");
        //                cust.Surname = dr.GetString("Surname");
        //                cust.PhoneNumber = dr.GetString("PhoneNumber");
        //                cust.Email = dr.GetString("Email");
        //                cust.Password = dr.GetString("Password");

        //                list.Add(cust);


        //            }
        //            dr.Close();
        //        }
        //        catch (Exception ex)
        //        {
        //            Console.WriteLine("Error : " + ex.Message);
        //        }
        //        finally
        //        {
        //            con.Close();
        //        }

        //        return list;
        //    }

        public static List<Customer> GetAllCustomers()
        {
            List<Customer> list = new List<Customer>();

            SqlConnection con = new SqlConnection();
            con.ConnectionString = @"Data Source=(localdb)\ProjectModels;Initial Catalog=CarRental;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False";

            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "SELECT * FROM Customer"; // Make sure this matches your table name

                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    Customer cust = new Customer();
                    cust.CustomerId = dr.GetInt32(dr.GetOrdinal("CustomerId"));
                    cust.Name = dr.GetString(dr.GetOrdinal("Name"));
                    cust.Surname = dr.GetString(dr.GetOrdinal("Surname"));
                    cust.PhoneNumber = dr.GetString(dr.GetOrdinal("PhoneNumber"));
                    cust.Email = dr.GetString(dr.GetOrdinal("Email"));
                    cust.Password = dr.GetString(dr.GetOrdinal("Password"));

                    list.Add(cust);
                }
                dr.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
            finally
            {
                con.Close();
            }

            return list;
        }
        //public static Customer GetSingleCustomer(int CarId)
        //{
        //    Customer cust = new Customer();

        //    SqlConnection con = new SqlConnection();

        //    con.ConnectionString = @"Data Source=(localdb)\ProjectModels;Initial Catalog=CarRental;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False";

        //    con.Open();

        //    try
        //    {
        //        SqlCommand cmd = new SqlCommand();
        //        cmd.Connection = con;
        //        cmd.CommandType = CommandType.Text;
        //        cmd.CommandText = "Select * from Customer where CustomerId = @CustomerId";

        //        cmd.Parameters.AddWithValue("@CustomerId", CustomerId);

        //        SqlDataReader dr = cmd.ExecuteReader();

        //        if (dr.Read())
        //        {
        //            cust.Name = dr.GetString(dr.GetOrdinal("Name"));
        //            cust.Surname = dr.GetString(dr.GetOrdinal("Surname"));
        //            cust.PhoneNumber = dr.GetString(dr.GetOrdinal("PhoneNumber"));
        //            cust.Email = dr.GetString(dr.GetOrdinal("Email"));
        //            cust.Password = dr.GetString(dr.GetOrdinal("Password"));
        //        }
        //        else
        //        {
        //            cust = null;
        //        }
        //        dr.Close();
        //        cmd.ExecuteNonQuery();
        //    }
        //    catch (Exception ex)
        //    {
        //        throw;
        //    }
        //    finally
        //    {
        //        con.Close();
        //    }
        //    return cust;
        //}
        public static Customer GetSingleCustomer(int CustomerId)
        {
            Customer cust = null; // Initialize the customer as null

            SqlConnection con = new SqlConnection();
            con.ConnectionString = @"Data Source=(localdb)\ProjectModels;Initial Catalog=CarRental;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False";

            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "SELECT * FROM Customer WHERE CustomerId = @CustomerId";

                // Use the correct parameter name and value
                cmd.Parameters.AddWithValue("@CustomerId", CustomerId);

                SqlDataReader dr = cmd.ExecuteReader();

                if (dr.Read())
                {
                    // Create a new Customer instance
                    cust = new Customer();
                    cust.CustomerId = CustomerId;
                    cust.Name = dr.GetString(dr.GetOrdinal("Name"));
                    cust.Surname = dr.GetString(dr.GetOrdinal("Surname"));
                    cust.PhoneNumber = dr.GetString(dr.GetOrdinal("PhoneNumber"));
                    cust.Email = dr.GetString(dr.GetOrdinal("Email"));
                    cust.Password = dr.GetString(dr.GetOrdinal("Password"));
                }

                // No need to executeNonQuery here, so removing it

                dr.Close();
            }
            catch (Exception ex)
            {
                // Handle exceptions properly (log, throw, etc.)
                Console.WriteLine("Error: " + ex.Message);
                throw; // Re-throw the exception to handle it further up the call stack
            }
            finally
            {
                con.Close();
            }

            return cust; // Return the retrieved customer, if found
        }

        public static void InsertCustomer(Customer cust)
        {
            using (SqlConnection con = new SqlConnection())
            {
                con.ConnectionString = @"Data Source=(localdb)\ProjectModels;Initial Catalog=CarRental;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False";
                con.Open();

                try
                {
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.Connection = con;
                        cmd.CommandType = CommandType.Text;
                        cmd.CommandText = "INSERT INTO Customer VALUES (@CustomerId, @Name, @Surname, @PhoneNumber, @Email, @Password)";

                        cmd.Parameters.AddWithValue("@CustomerId", cust.CustomerId);
                        cmd.Parameters.AddWithValue("@Name", cust.Name);
                        cmd.Parameters.AddWithValue("@Surname", cust.Surname);
                        cmd.Parameters.AddWithValue("@PhoneNumber", cust.PhoneNumber);
                        cmd.Parameters.AddWithValue("@Email", cust.Email);
                        cmd.Parameters.AddWithValue("@Password", cust.Password);

                        cmd.ExecuteNonQuery();
                    }
                }
                catch (Exception ex)
                {
                    // Handle or log the exception as needed
                    throw;
                }
            }
        }

        public static void UpdateCustomer(Customer cust)
        {
            using (SqlConnection con = new SqlConnection())
            {
                con.ConnectionString = @"Data Source=(localdb)\ProjectModels;Initial Catalog=CarRental;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False";
                con.Open();

                try
                {
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.Connection = con;
                        cmd.CommandType = CommandType.Text;
                        cmd.CommandText = "UPDATE Customer SET Name = @Name, Surname = @Surname, PhoneNumber = @PhoneNumber, Email = @Email, Password = @Password WHERE CustomerId = @CustomerId";

                        cmd.Parameters.AddWithValue("@CustomerId", cust.CustomerId);
                        cmd.Parameters.AddWithValue("@Name", cust.Name);
                        cmd.Parameters.AddWithValue("@Surname", cust.Surname);
                        cmd.Parameters.AddWithValue("@PhoneNumber", cust.PhoneNumber);
                        cmd.Parameters.AddWithValue("@Email", cust.Email);
                        cmd.Parameters.AddWithValue("@Password", cust.Password);

                        cmd.ExecuteNonQuery();
                    }
                }
                catch (Exception ex)
                {
                    // Handle or log the exception as needed
                    throw;
                }
            }
        }


        public static void DeleteCustomer(int CustomerId)
        {
            using (SqlConnection con = new SqlConnection())
            {
                con.ConnectionString = @"Data Source=(localdb)\ProjectModels;Initial Catalog=CarRental;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False";
                con.Open();

                try
                {
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.Connection = con;
                        cmd.CommandType = CommandType.Text;
                        cmd.CommandText = "DELETE FROM Customer WHERE CustomerId = @CustomerId";

                        cmd.Parameters.AddWithValue("@CustomerId", CustomerId);

                        cmd.ExecuteNonQuery();
                    }
                }
                catch (Exception ex)
                {
                    // Handle or log the exception as needed
                    throw;
                }
            }
        }

    }
}
