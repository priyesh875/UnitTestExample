using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UnitTestExample.Models
{
    public class Company
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "Required")]
        [StringLength(50)]
        public string Name { get; set; }
        public virtual ICollection<Contact> Contacts { get; set; }
    }
}