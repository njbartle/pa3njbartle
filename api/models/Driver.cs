using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.models
{
    public class Driver
    {
        public int Id { get; set; }
        public string EmployeeName { get; set; }
        public double  EmployeeRating { get; set; }
        public DateTime DateHired { get; set; }
        public bool Deleted { get; set; }
    }
}