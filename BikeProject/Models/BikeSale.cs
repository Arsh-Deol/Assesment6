using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BikeProject.Models
{
    public class BikeSale
    {
        [Key]
        public int ID { get; set; }//foreign key
        public int PurchaserID { get; set; }// foreign key for client name
        public Purchaser Purchaser { get; set; }


        public int BanchID { get; set; }//foreign key
        public Banch Banch { get; set; }// foreign key of staff 

    }
}
