using Microsoft.Data.SqlClient;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WebApiDemo_Car
{
    public class Car
    {
        [Key]
        public int CarId { get; set; }

        [Required]
        [RegularExpression(@"^[A-Z]{2}\d{2}[A-Z]{2}\d{4}$", ErrorMessage = "Car number must be in the format AB12CD3456")]
        public string Car_No { get; set; }

        [Required]
        [StringLength(20, MinimumLength = 3)]
        public string Model { get; set; }

        [Required]
        [StringLength(20, MinimumLength = 3)]
        public string Company { get; set; }

        [Required]
        [StringLength(10, MinimumLength = 3)]
        public string Type { get; set; }

        [Required]
        [StringLength(20, MinimumLength = 3)]
        public string Colour { get; set; }

        public int Year_Of_Manufacturing { get; set; }

        [Required]
        public int Seating_Capacity { get; set; }

        [Required]
        public decimal Charges_Per_Km { get; set; }

        public static List<Car> GetAll()
        {
            List<Car> list = new List<Car>();

            SqlConnection con = new SqlConnection();

            con.ConnectionString = @"Data Source=(localdb)\ProjectModels;Initial Catalog=CarRental;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False";

            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "Select * from Car";

                SqlDataReader dr = cmd.ExecuteReader();
                while(dr.Read())
                {
                    Car obj = new Car();
                    obj.CarId = dr.GetInt32("CarId");
                    obj.Car_No = dr.GetString("Car_No");
                    obj.Model = dr.GetString("Model");
                    obj.Company = dr.GetString("Company");
                    obj.Type = dr.GetString("Type");
                    obj.Colour = dr.GetString("Colour");
                    obj.Year_Of_Manufacturing = dr.GetInt32("Year_Of_Manufacturing");
                    obj.Seating_Capacity = dr.GetInt32("Seating_Capacity");
                    obj.Charges_Per_Km = dr.GetDecimal("Charges_Per_Km");

                    list.Add(obj);
                      
                }
                dr.Close();
            }
            catch(Exception ex) 
            {
                Console.WriteLine("Error : " +ex.Message);
            }
            finally
            {
                con.Close();
            }

            return list;
        }

        public static Car GetSingleCar(int CarId)
        {
            Car obj = new Car();

            SqlConnection con = new SqlConnection();

            con.ConnectionString = @"Data Source=(localdb)\ProjectModels;Initial Catalog=CarRental;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False";

            con.Open();

            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "Select * from Car where CarId = @CarId";

                cmd.Parameters.AddWithValue("@CarId", CarId);

                SqlDataReader dr = cmd.ExecuteReader();

                if (dr.Read())
                {
                    obj.CarId = dr.GetInt32("CarId");
                    obj.Car_No = dr.GetString("Car_No");
                    obj.Model = dr.GetString("Model");
                    obj.Company = dr.GetString("Company");
                    obj.Type = dr.GetString("Type");
                    obj.Colour = dr.GetString("Colour");
                    obj.Year_Of_Manufacturing = dr.GetInt32("Year_Of_Manufacturing");
                    obj.Seating_Capacity = dr.GetInt32("Seating_Capacity");
                    obj.Charges_Per_Km = dr.GetDecimal("Charges_Per_Km");
                }
                else
                {
                    obj = null;

                }
                dr.Close();
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw;
            }
            finally
            {
                con.Close();
            }
            return obj;
        }


        public static void InsertCar(Car obj)
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = @"Data Source=(localdb)\ProjectModels;Initial Catalog=CarRental;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False";
            con.Open();

            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandType = CommandType.Text;
                //cmd.CommandText = "Insert into Car values (@CarId, @Car_No, @Model, @Company, @Type, @Colour , @Year_Of_Manufacturing, @Seating_Capacity, @Charges_Per_Km)";
                cmd.CommandText = "INSERT INTO Car VALUES (@CarId, @Car_No, @Model, @Company, @Type, @Colour, @Year_Of_Manufacturing, @Seating_Capacity, @Charges_Per_Km)";

                cmd.Parameters.AddWithValue("@CarId", obj.CarId);
                cmd.Parameters.AddWithValue("@Car_No", obj.Car_No);
                cmd.Parameters.AddWithValue("@Model", obj.Model);
                cmd.Parameters.AddWithValue("@Company", obj.Company);
                cmd.Parameters.AddWithValue("@Type", obj.Type);
                cmd.Parameters.AddWithValue("@Colour", obj.Colour);
                cmd.Parameters.AddWithValue("@Year_Of_Manufacturing", obj.Year_Of_Manufacturing);
                cmd.Parameters.AddWithValue("@Seating_Capacity", obj.Seating_Capacity);
                cmd.Parameters.AddWithValue("@Charges_Per_Km", obj.Charges_Per_Km);

                cmd.ExecuteNonQuery();


            }
            catch(Exception ex)
            {
                throw;

            }
            finally { con.Close(); }
        }

        public static void UpdateCar(Car obj)
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = @"Data Source=(localdb)\ProjectModels;Initial Catalog=CarRental;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False";
            con.Open();

            try
            {
                SqlCommand cmd = new SqlCommand();  
                cmd.Connection = con;
                cmd.CommandType = CommandType.Text;
                //cmd.CommandText = "Update Car set Car_No = @Car_No, Model = @Model, Company = @Company, Type = @Type, Colour = @Colour , Year_Of_Manufacturing = @Year_Of_Manufacturing, Seating_Capacity = @Seating_Capacity, Charges_Per_Km = @Charges_Per_Km where CarId = @CarId";
                cmd.CommandText = "UPDATE Car SET Car_No = @Car_No, Model = @Model, Company = @Company, Type = @Type, Colour = @Colour, Year_Of_Manufacturing = @Year_Of_Manufacturing, Seating_Capacity = @Seating_Capacity, Charges_Per_Km = @Charges_Per_Km WHERE CarId = @CarId";

                cmd.Parameters.AddWithValue("@CarId", obj.CarId);
                cmd.Parameters.AddWithValue("@Car_No", obj.Car_No);
                cmd.Parameters.AddWithValue("@Model", obj.Model);
                cmd.Parameters.AddWithValue("@Company", obj.Company);
                cmd.Parameters.AddWithValue("@Type", obj.Type);
                cmd.Parameters.AddWithValue("@Colour", obj.Colour);
                cmd.Parameters.AddWithValue("@Year_Of_Manufacturing", obj.Year_Of_Manufacturing);
                cmd.Parameters.AddWithValue("@Seating_Capacity", obj.Seating_Capacity);
                cmd.Parameters.AddWithValue("@Charges_Per_Km", obj.Charges_Per_Km);

                cmd.ExecuteNonQuery();
            }
            catch(Exception ex) { throw; } 
            finally { con.Close(); }
        }

        public static void DeleteCar(int CarId)
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = @"Data Source=(localdb)\ProjectModels;Initial Catalog=CarRental;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False";
            con.Open();

            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "Delete from Car where CarId = @CarId";

                cmd.Parameters.AddWithValue("@CarId", CarId);

                cmd.ExecuteNonQuery();
            }
            catch (Exception ex) { throw; }
            finally { con.Close(); }
        }


    }
}
