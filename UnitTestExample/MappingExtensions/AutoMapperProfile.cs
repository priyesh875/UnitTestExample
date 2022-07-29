using AutoMapper;
using Microsoft.AspNetCore.Mvc.Rendering;
using UnitTestExample.Models;
using UnitTestExample.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CMS.MappingExtensions
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Contact, ContactVM>()
                .ForMember(x => x.Company, opt => opt.MapFrom(src => src.Company));
            CreateMap<ContactVM, Contact>();
            CreateMap<Company, CompanyVM>();
        }
    }
}
