using AutoMapper;
using TodoList.Infrastructure.Entities;

namespace TodoList.Services.Areas.Items.Dto;

public class ItemMappingProfile : Profile
{
    public ItemMappingProfile()
    {
        CreateMap<ItemDtoInput, Item>();
        CreateMap<Item, ItemDto>();
        CreateMap<ItemDto, ItemDtoInput>();
    }
}