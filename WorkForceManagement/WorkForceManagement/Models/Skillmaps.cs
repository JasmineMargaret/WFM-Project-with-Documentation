using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WorkForceManagement.Models
{
    public class Skillmaps
    {
        public int employee_id { get; set; }
        public Employees employees { get; set; }
        public int skillid { get; set; }
        public Skills skills { get; set; }
    }
}