/*using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NGODonationDataAccessLayer.Entity
{
    public class UserLogin
    {

        [Key]
        public int Id { get; set; }


        [Required(ErrorMessage = "Please Enter User Name")]
        [Display(Name = "Please Enter User Name")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Please Enter Password")]
        [Display(Name = "Please Enter Password")]
        public string passcode { get; set; }
        public int IsActive { get; set; }
    }
}
*/