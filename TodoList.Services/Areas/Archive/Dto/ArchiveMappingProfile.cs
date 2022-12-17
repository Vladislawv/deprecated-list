using AutoMapper;
using TodoList.Infrastructure.Entities;

namespace TodoList.Services.Areas.Archive.Dto;

public class ArchiveMappingProfile : Profile
{
    public ArchiveMappingProfile()
    {
        CreateMap<ArchivedItem, Item>()
            .ForMember(i => i.Id, opt => opt.Ignore());
        
        CreateMap<ArchivedItem, ArchivedDto>();
    }
}