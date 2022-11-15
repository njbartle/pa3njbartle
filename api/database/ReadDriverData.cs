using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Controllers;
using api.models;
using api.interfaces;
using System.Data;
using MySql.Data;
using MySql.Data.MySqlClient;



namespace api.database
{
    public class ReadDriverData : IGetAllDrivers, IGetDriver
    {
        public string cs { get; set; }
        public ReadDriverData()
        {
            cs = new ConnectionString().cs;
        }
        public List<Driver> GetAllDrivers()
        {
            using var con = new MySqlConnection(cs);
            con.Open();
            string stm = "Select * from driver;";
            using var cmd = new MySqlCommand(stm, con);


            MySqlDataReader rdr = cmd.ExecuteReader();
            List<Driver> driverList = new List<Driver>();
            while (rdr.Read())
            {
                Driver newDriver = new Driver()
                {
                    Id = rdr.GetInt32(0),
                    EmployeeName = rdr.GetString(1),
                    EmployeeRating = rdr.GetDouble(2),
                    DateHired = rdr.GetDateTime(3),
                    Deleted = rdr.GetBoolean(4)
                };
                driverList.Add(newDriver);
            }
            return driverList;
        }

        public Driver GetDriver(int Id)
        {
            using var con = new MySqlConnection(cs);
            con.Open();
            string stm = $"Select * from driver where Id = @Id;";
            using var cmd = new MySqlCommand(stm, con);

            cmd.Parameters.AddWithValue("@id", Id);                         //sql prepared statements and parameters
            cmd.Prepare();
            using MySqlDataReader rdr = cmd.ExecuteReader(); 
            rdr.Read();
            Driver thisDriver = new Driver(){Id = rdr.GetInt32(0), EmployeeName = rdr.GetString(1), EmployeeRating = rdr.GetDouble(2), DateHired = rdr.GetDateTime(3), Deleted = rdr.GetBoolean(4)};
            
            return thisDriver;
        }
    }

}