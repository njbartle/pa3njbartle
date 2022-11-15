using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.models;
using System.Data;
using MySql.Data;
using MySql.Data.MySqlClient;

namespace api.database
{
    public class CreateDriverData
    {
        public Driver CreateDriver(int id)
        {
            ConnectionString myConnection = new ConnectionString();
            string cs = myConnection.cs;

            using var con = new MySqlConnection();
            con.Open();
            string stm = $"Insert into driver set (EmployeeName, EmployeeRating, DateHired, Deleted)  Values (@EmployeeName, @EmployeeRating, @DateHired, @Deleted);";
            using var cmd = new MySqlCommand(stm, con);
            cmd.Parameters.AddWithValue("@EmployeeName", EmployeeName);
            cmd.Parameters.AddWithValue("@EmployeeRating", EmployeeRating);
            cmd.Parameters.AddWithValue("@DateHired", DateHired);
            cmd.Parameters.AddWithValue("@Deleted", Deleted);

            cmd.Prepare();

            using MySqlDataReader rdr = cmd.ExecuteReader();
            rdr.Read();
            Driver newDriver = new Driver() { Id = rdr.GetInt32(0), EmployeeName = rdr.GetString(1), EmployeeRating = rdr.GetDouble(2), DateHired = rdr.GetDateTime(3), Deleted = rdr.GetBoolean(4) };
            return newDriver;
        }
    }
}