using AutoMapper;
using Domain;
using DTOs.Aggregates;
using DTOs.Aggregates.Scenario;

namespace WebServer.Mappings
{
    public class ScenarioMappings : Profile
    {
        public ScenarioMappings()
        {
            CreateMap<Scenario, ScenarioDTO>();
            CreateMap<ScenarioDTO, Scenario>();
            CreateMap<ScenarioStep, ScenarioStepDTO>();
        }
    }
}
