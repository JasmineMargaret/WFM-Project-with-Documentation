using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WorkForceManagement.Models
{
    public class Skills
    {
        [Key]
        public int skillid { get; set; }
        public string skillname { get; set; }
        public ICollection<Skillmaps> skillmaps { get; set; }
    }

    public class Skillswithemployees
    {
        public int skillid { get; set; }
        public string skillname { get; set; }
        public List<string> Employees { get; set; }

    }
}