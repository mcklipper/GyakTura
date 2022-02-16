using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace GyakTura.Models
{
    public class Tour
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public IdentityUser User { get; set; }

        [Required]
        public DateTime Date { get; set; }

        [Required]
        [StringLength(64)]
        public string Destination { get; set; }

        [Required]
        [Range(0, 512)]
        public int Km { get; set; }

        [StringLength(255)]
        public string Comment { get; set; }

    }
}
