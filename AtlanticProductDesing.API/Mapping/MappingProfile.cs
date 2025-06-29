using AtlanticProductDesing.API.Dtos.Country;
using AtlanticProductDesing.API.Dtos.Person;
using AtlanticProductDesing.API.Dtos.PersonContact;
using AtlanticProductDesing.API.Dtos.Product;
using AtlanticProductDesing.Application.Features.People.Commands.CreatePerson;
using AtlanticProductDesing.Application.Features.People.Commands.UpdatePerson;
using AtlanticProductDesing.Domain.Entities;
using AutoMapper;


namespace AtlanticProductDesing.API.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {


            // Instructor Mappings



            // PersonContactMethod Mappings
            CreateMap<PersonContactMethodDto, PersonContactMethod>();
            CreateMap<PersonContactMethod, PersonContactMethodDto>();



            //people
            CreateMap<CreatePersonCommand, PersonDto>().ReverseMap();
            CreateMap<UpdatePersonCommand, PersonDto>().ReverseMap();
            CreateMap<Person, PersonDto>().ReverseMap();

           


        }
    }
}
