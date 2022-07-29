using AutoMapper;
using UnitTestExample.DataAccess.IRepository;
using UnitTestExample.Models;
using UnitTestExample.Models.ViewModels;
using UnitTestExample.Services.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTestExample.Services
{
    public class ContactService : IContactService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ContactService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<ResultVM> AddContact(ContactVM contact)
        {
            var _contact = _mapper.Map<Contact>(contact);
            _contact.LastDateContacted = DateTime.Parse(contact.LastDateContacted);
            await _unitOfWork.Contact.AddAsync(_contact);
            await _unitOfWork.SaveChangesAsync();
            return new ResultVM() { Success = true, Message = "Contact has been added successfully!" };
        }

        public async Task<ResultVM> DeleteContact(int id)
        {
            var objFromDb = await _unitOfWork.Contact.GetAsync(id);
            if (objFromDb == null)
            {
                return new ResultVM { Success = false, Message = "Error while removing." };
            }

            await _unitOfWork.Contact.RemoveAsync(objFromDb);
            await _unitOfWork.SaveChangesAsync();

            return new ResultVM { Success = true, Message = "Deleted Successfully!" };
        }

        public async Task<List<CompanyVM>> GetCompanies()
        {
            var result = await _unitOfWork.Company.GetAllAsync();
            var list = _mapper.Map<List<CompanyVM>>(result.ToList());
            return list;
        }

        public async Task<ContactVM?> GetContact(int id)
        {
            var result = await _unitOfWork.Contact.GetAsync(id);
            if (result == null)
                return null;

            var model = _mapper.Map<ContactVM>(result);
            model.LastDateContacted = result.LastDateContacted.ToString("MM/dd/yyyy");
            return model;
        }

        public async Task<List<ContactVM>> GetContacts()
        {
            var result = await _unitOfWork.Contact.GetAllAsync(includeProperties: "Company");
            var list = _mapper.Map<List<ContactVM>>(result.ToList());
            return list;
        }

        public async Task<ResultVM> UpdateContact(ContactVM contact)
        {
            var _contact = await _unitOfWork.Contact.GetAsync(contact.Id.Value);
            if (_contact != null)
            {
                _contact = _mapper.Map<Contact>(contact);
                _contact.Id = contact.Id.Value;
                _contact.LastDateContacted = DateTime.Parse(contact.LastDateContacted);

                await _unitOfWork.Contact.UpdateAsync(_contact);
                await _unitOfWork.SaveChangesAsync();
                return new ResultVM() { Success = true, Message = "Contact has been updated successfully!" };
            }
            else
            {
                return new ResultVM() { Success = false, Message = "Invalid request!" };
            }
        }
    }
}
