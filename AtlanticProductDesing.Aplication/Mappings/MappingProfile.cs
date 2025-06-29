using AtlanticProductDesing.Application.DTOs;
using AtlanticProductDesing.Application.Features.People.Commands.CreatePerson;
using AtlanticProductDesing.Application.Features.People.Commands.UpdatePerson;
using AtlanticProductDesing.Application.Models.Checkout;
using AtlanticProductDesing.Domain.Entities;
using AutoMapper;

namespace AtlanticProductDesing.Application.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {







            //Peoples
            CreateMap<CreatePersonCommand, Person>();
            CreateMap<UpdatePersonCommand, Person>();

         















            CreateMap<RateDto, ExchangeRate>()
                .ReverseMap();






        }
    }
}
