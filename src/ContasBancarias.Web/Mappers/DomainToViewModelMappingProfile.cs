using AutoMapper;
using ContasBancarias.Domain.Models;
using ContasBancarias.Web.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ContasBancarias.Web.Mappers
{
    public class DomainToViewModelMappingProfile : Profile
    {
        public DomainToViewModelMappingProfile()
        {
            CreateMap<Contas, ContasDTO>();
        }
    }
}