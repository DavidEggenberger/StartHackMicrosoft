using AutoMapper;
using Domain;
using DTOs;
using DTOs.Aggregates;

namespace WebServer.Mappings
{
    public class LearningBadgeMappings : Profile
    {
        public LearningBadgeMappings()
        {
            CreateMap<LearningBadge, LearningBadgeDTO>();
            CreateMap<LearningDTO, Learning>();
        }
    }
}
