using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.database
{
    public class ConnectionString
    {
        public string cs { get; set; }
        public ConnectionString()
        {

            string server = "qvti2nukhfiig51b.cbetxkdyhwsb.us-east-1.rds.amazonaws.com";
            string database = "cl04vt1gg6cxe1gi";
            string port = "3306";
            string userName = "u1pqernccohf97sx";
            string password = "mfye4qu9vlhk0t5w";

            cs = $@"server = {server};user = {userName};database = {database};port = {port};password = {password};";

        }
    }
}