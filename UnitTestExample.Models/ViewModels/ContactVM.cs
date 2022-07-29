using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace UnitTestExample.Models.ViewModels
{
    public class ContactVM
    {
        public int? Id { get; set; }

        [Required(ErrorMessage = "Required")]
        [StringLength(50)]
        public string Name { get; set; }

        [Display(Name = "Job Title")]
        [StringLength(200)]
        public string? Address { get; set; }

        [StringLength(200)]
        public string? JobTitle { get; set; }

        [StringLength(20)]
        public string? Phone { get; set; }

        [StringLength(500)]
        public string? Comments { get; set; }

        [Required(ErrorMessage = "Required")]
        [EmailAddress(ErrorMessage = "Invalid e-mail address!")]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Required")]
        [Display(Name = "Company")]
        public int CompanyId { get; set; }

        [JsonIgnore]
        public IEnumerable<SelectListItem>? CompanyList { get; set; }

        public CompanyVM? Company { get; set; }

        [Required(ErrorMessage = "Required")]
        [StringLength(100)]
        [Display(Name = "Last Date Contacted")]
        public string LastDateContacted { get; set; }
    }
}