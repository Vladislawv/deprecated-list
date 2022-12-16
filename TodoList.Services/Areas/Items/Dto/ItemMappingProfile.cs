using AutoMapper;
using TodoList.Infrastructure.Entities;

namespace TodoList.Services.Areas.Items.Dto;

public class ItemMappingProfile : Profile
{
    public ItemMappingProfile()
    {
        CreateMap<ItemDtoInput, Item>();
        
        CreateMap<Item, ItemDto>();
        
        CreateMap<Item, ArchivedItem>()
            .ForMember(a => a.Id, opt => opt.Ignore());
        
        CreateMap<ItemDto, ItemDtoInput>();
    }
}