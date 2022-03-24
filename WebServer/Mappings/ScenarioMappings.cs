using AutoMapper;
using Domain;
using DTOs.Aggregates;

namespace WebServer.Mappings
{
    public class ScenarioMappings : Profile
    {
        public ScenarioMappings()
        {
            CreateMap<Scenario, ScenarioDTO>();
            CreateMap<ScenarioDTO, Scenario>();
        }
    }
}
