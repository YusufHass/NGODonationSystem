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
        public string Email { get; set; }
        public string Role { get; set; }
        /*  public RoleType?Role { get; set; }

      }
      public enum RoleType
      {
          Admin, User
              }*/
    }
}

