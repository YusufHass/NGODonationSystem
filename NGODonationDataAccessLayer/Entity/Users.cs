using System;
using System.ComponentModel.DataAnnotations;

namespace NGODonationDataAccessLayer.Entity
{
    public class Users
    {
        [Key]
        public int UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Password { get; set; }

    }
}
