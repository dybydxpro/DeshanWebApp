using System.ComponentModel.DataAnnotations;

namespace DeshanWebApp.Models
{
    public class Cart
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public int AssetID { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string ISBN { get; set; }
    }
}
