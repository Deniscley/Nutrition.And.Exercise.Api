using AutoMapper;
using Nutrition.And.Exercise.Borders.Dtos.Response;
using Nutrition.And.Exercise.Borders.Entities;

namespace Nutrition.And.Exercise.Data.MappingsProfile
{
    public class ClientMappingProfile : Profile
    {
        public ClientMappingProfile() {
            //CreateMap<ClientRequest, Client>()
            //    .ForMember(d => d.DataNascimento, o => o.MapFrom(x => x.DataNascimento.Date));
            CreateMap<Client, ClientResponse>();
        }
    }
}
