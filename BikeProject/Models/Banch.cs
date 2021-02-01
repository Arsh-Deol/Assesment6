using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BikeProject.Models
{
    public class Banch
    {
        // Bike project center details
        [Key]
        public int BranchID { get; set; } // primary key for branch

        public string BranchName { get; set; } // branch name

        public string Address { get; set; } // address of branch

        [DataType(DataType.Time)]//it will show only time rather than date
        public DateTime OpeningTime { get; set; } //  opening time of ech center

        [DataType(DataType.Time)]//it will show only time rather than date
        public DateTime CloseingTime { get; set; }//  opening time of ech center

    }
}
