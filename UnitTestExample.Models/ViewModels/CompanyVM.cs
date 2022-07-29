using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace UnitTestExample.Models.ViewModels
{
    public class CompanyVM
    {
        public int Id { get; set; }

        public string Name { get; set; }
    }
}