using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace BlogApp_SemihKaraoglan.Models
{
    public class CustomUser : IdentityUser
    {
        [Display(Name = "Name & Surname")]
        public string FullName { get; set; }

        [Display(Name = "Gender")]
        public string Gender { get; set; }

        [Display(Name = "Birthday")]
        [DataType(DataType.DateTime)]
        public DateTime DateOfBirth { get; set; }
    }
}
