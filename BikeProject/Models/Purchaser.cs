using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BikeProject.Models
{
    public class Purchaser
    {
        [Key]
        public int PurchaserID { get; set; }//primary key for client
        public string FirstName { get; set; } // customer first name
        public string LastName { get; set; } // customer last name

        public string Address { get; set; } // customer address

        public string Phone { get; set; }// customer phone number
        public string DOB { get; set; }// date of birth

    }
}
