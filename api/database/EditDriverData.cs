using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data;
using MySql.Data;
using MySql.Data.MySqlClient;
using api.models;

namespace api.database
{
    public class EditDriverData
    {
        public Driver EditDriver(double EmployeeRating, int Id)
        {
            using var con = new MySqlConnection();
            con.Open();
            string stm = $"Update driver set EmployeeRating = @EmployeeRating where id = @EmployeeId;";
            using var cmd = new MySqlCommand(stm, con);
            cmd.Parameters.AddWithValue("@EmployeeRating", EmployeeRating);
            cmd.Parameters.AddWithValue("@id", Id);

            cmd.Prepare();

            using MySqlDataReader rdr = cmd.ExecuteReader();
            rdr.Read();
            Driver updatedRating = new Driver() { Id = rdr.GetInt32(0), EmployeeName = rdr.GetString(1), EmployeeRating = rdr.GetDouble(2), DateHired = rdr.GetDateTime(3), Deleted = rdr.GetBoolean(4) };
            return updatedRating;
        }
    }
}