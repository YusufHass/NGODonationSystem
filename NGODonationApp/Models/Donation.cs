using System.ComponentModel.DataAnnotations;

namespace NGODonationApp.Models
{
    public class Donation
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public DataType Date { get; set; }
        public int Amount { get; set; }
        public int DonationType { get; set; }
    }
}
