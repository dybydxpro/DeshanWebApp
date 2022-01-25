using System.ComponentModel.DataAnnotations;

namespace DeshanWebApp.Models
{
    public class Asset
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string ISBN { get; set; }
    }
}
