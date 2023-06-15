using AutoMapper;
using Nutrition.And.Exercise.Domain.Dtos.Response;
using Nutrition.And.Exercise.Domain.Entities;

namespace Nutrition.And.Exercise.Data.MappingsProfile
{
    public class ClientMappingProfile : Profile
    {
        public ClientMappingProfile() {
            //CreateMap<ClientRequest, Client>()
            //    .ForMember(d => d.DataNascimento, o => o.MapFrom(x => x.DataNascimento.Date));
            CreateMap<Client, ClientResponse>();

            CreateMap<List<Client>, IEnumerable<ClientResponse>>();
        }
    }
}
