using AuctionService.Constants;
using AuctionService.Data;
using AuctionService.Entities;
using Bogus;

namespace AuctionService.Services;

public class SeedDataService
{
    private readonly AuctionDbContext _context;

    public SeedDataService(AuctionDbContext context)
    {
        _context = context;
    }

    List<string> images = new List<string>
        {
            "https://cdn.pixabay.com/photo/2016/05/06/16/32/car-1376190_960_720.jpg",
            "https://cdn.pixabay.com/photo/2012/05/29/00/43/car-49278_960_720.jpg",
            "https://cdn.pixabay.com/photo/2012/11/02/13/02/car-63930_960_720.jpg",
            "https://cdn.pixabay.com/photo/2016/04/17/22/10/mercedes-benz-1335674_960_720.png",
            "https://cdn.pixabay.com/photo/2017/08/31/05/47/bmw-2699538_960_720.jpg",
            "https://cdn.pixabay.com/photo/2017/11/09/01/49/ferrari-458-spider-2932191_960_720.jpg",
            "https://cdn.pixabay.com/photo/2017/11/08/14/39/ferrari-f430-2930661_960_720.jpg",
            "https://cdn.pixabay.com/photo/2019/12/26/20/50/audi-r8-4721217_960_720.jpg",
            "https://cdn.pixabay.com/photo/2016/09/01/15/06/audi-1636320_960_720.jpg",
            "https://cdn.pixabay.com/photo/2017/08/02/19/47/vintage-2573090_960_720.jpg"
        };

    public Faker<Auction> CreateFakerAuction(List<string> images)
    {
        Faker<Auction> auctionFaker = new Faker<Auction>()
            .RuleFor(a => a.Id, f => f.Random.Guid())
            .RuleFor(a => a.Status, f => AuctionStatus.Live)
            .RuleFor(a => a.ReservePrice, f => f.Random.Number(20000, 150000))
            .RuleFor(a => a.Seller, f => f.Person.FirstName)
            .RuleFor(a => a.AuctionEnd, f => f.Date.Future())
            .RuleFor(a => a.Item, f => new Faker<Item>()
                .RuleFor(i => i.Make, f => f.Vehicle.Manufacturer())
                .RuleFor(i => i.Model, f => f.Vehicle.Model())
                .RuleFor(i => i.Color, f => f.Commerce.Color())
                .RuleFor(i => i.Mileage, f => f.Random.Number(5000, 150000))
                .RuleFor(i => i.Year, f => f.Random.Number(1930, 2025))
                .RuleFor(i => i.ImageUrl, f => f.PickRandom(images)));

        return auctionFaker;
    }

    public void SeedAuctions(int count = 100)
    {
        Faker<Auction> auctionFaker = CreateFakerAuction(images);

        List<Auction> auctions = auctionFaker.Generate(count);

        _context.Auctions.AddRange(auctions);
        _context.SaveChanges();
    }
}
