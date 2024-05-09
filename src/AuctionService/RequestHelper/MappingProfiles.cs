using AuctionService.DTOs;
using AuctionService.Entities;
using AutoMapper;

namespace AuctionService.MappingHelper;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<Auction, AuctionDto>().IncludeMembers(x => x.Item).ReverseMap();
        CreateMap<Item, AuctionDto>().ReverseMap();
        CreateMap<CreateAuctionDto, Auction>().ForMember(d => d.Item, o => o.MapFrom(s => s)).ReverseMap();
        CreateMap<CreateAuctionDto, Item>().ReverseMap();
    }
}
