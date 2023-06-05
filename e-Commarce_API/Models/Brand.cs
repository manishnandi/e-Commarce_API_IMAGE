using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Xml.Linq;

namespace e_Commarce_API.Models
{
    public class Brand
    {
        [Key]
        public int Id { get; set; }

        [Required, StringLength(255)]
        public string Name { get; set; }

        [Required, StringLength(255)]
        public string Slogan { get; set; }

        [Required, StringLength(255)]
        public string Address { get; set; }

        [Required, Phone, StringLength(255)]
        public string Phone { get; set; }

        [Required, EmailAddress, StringLength(255)]
        public string Email { get; set; }

        [Required, StringLength(255), Display(Name = "Contact Person")]
        public string ContactPerson { get; set; }

        [StringLength(255), Display(Name = "Nav Bar Logo")]
        public string NavLogo { get; set; }

        [StringLength(255), Display(Name = "Logo")]
        public string Logo { get; set; }

        [Required, Display(Name = "Show Nav Logo")]
        public bool IsShowNavLogo { get; set; }

        [Required, Display(Name = "Show Logo")]
        public bool IsShowLogo { get; set; }


        [NotMapped]
        public IFormFile? FileNavLogo { get; set; }

        [NotMapped]
        public IFormFile? FileLogo { get; set; }
    }
}
