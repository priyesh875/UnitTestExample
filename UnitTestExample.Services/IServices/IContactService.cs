using UnitTestExample.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTestExample.Services.IServices
{
    public interface IContactService
    {
        Task<ContactVM?> GetContact(int id);
        Task<List<ContactVM>> GetContacts();
        Task<ResultVM> AddContact(ContactVM contact);
        Task<ResultVM> UpdateContact(ContactVM contact);
        Task<ResultVM> DeleteContact(int id);
        Task<List<CompanyVM>> GetCompanies();
    }
}
