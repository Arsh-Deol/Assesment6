using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BikeProject.Models
{
    public class SaleMan
    {

        [Key]

        public int SaleManId { get; set; } // employee  foreign key
        public string SaleManName { get; set; } // staff member name who sale car
        public double BikeAmount { get; set; } //Bike amount for sale

        [DataType(DataType.Date)]// it will show only date rather than time
        public DateTime SaleDate { get; set; } // date of sale

    }
}
