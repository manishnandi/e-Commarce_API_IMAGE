using System.ComponentModel.DataAnnotations;

namespace e_Commarce_API.Models.Dto
{
    public class CategoryDTO
    {
        public int Id { get; set; }

        [Required, StringLength(255)]
        public string Name { get; set; }

        [Required]
        public string Description { get; set; }

        [StringLength(255)]
        public string Thumbnail { get; set; }

        [Required, Display(Name = "Publish")]
        public bool IsPublish { get; set; }
    }
}
