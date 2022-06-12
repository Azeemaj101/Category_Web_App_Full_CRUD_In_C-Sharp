using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
namespace MyWebApp.Models
{
    public class Category
    {
        [Key]
        public int ID { get; set; }
        [Required]

        public string? Name { get; set; }
        [DisplayName("Display Order")]

        public int DisplayOrder { get; set; }
        public DateTime CreateDataTime { get; set; } = DateTime.Now;

    }
}
