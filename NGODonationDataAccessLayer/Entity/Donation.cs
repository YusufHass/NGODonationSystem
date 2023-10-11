using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NGODonationDataAccessLayer.Entity
{
    public class Donation
    {
        [Key]
        public int Id { get; set; }

        public string Email { get; set; }
        public string Date { get; set; }
        public int Amount { get; set; }
        public int DonationType { get; set; }
    }
}
