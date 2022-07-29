using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UnitTestExample.Models
{
    public class Testing
    {
        [Key]
        public Guid Id { get; set; }
        [Required(ErrorMessage = "Required")]
        [StringLength(500)]
        public string Name { get; set; }
    }
}