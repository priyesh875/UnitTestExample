using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using UnitTestExample.Models.ViewModels;
using UnitTestExample.Services.IServices;
using System.Diagnostics;

namespace UnitTestExample.Controllers
{
    public class HomeController : Controller
    {
        private readonly IContactService _contactService;
        public HomeController(IContactService contactService)
        {
            _contactService = contactService;
        }

        public IActionResult Index()
        {
            return View();
        }

        [ApiExplorerSettings(IgnoreApi = true)]
        [Route("contact/{id}")]
        public async Task<IActionResult> Contact(int? id)
        {
            var model = new ContactVM();
            if (id != null)
                model = await _contactService.GetContact(id.Value);

            var companies = await _contactService.GetCompanies();

            model.CompanyList = companies.Select(c =>
            new SelectListItem()
            {
                Text = c.Name,
                Value = c.Id.ToString(),
            });

            return View("ContactUpsert", model);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}