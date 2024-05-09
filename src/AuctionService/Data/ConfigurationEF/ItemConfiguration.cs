using AuctionService.Entities;
using Microsoft.EntityFrameworkCore;

namespace AuctionService.ConfigurationEF;

public class ItemConfiguration : IEntityTypeConfiguration<Item>
{
    public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Item> builder)
    {
        builder.ToTable("ITEM");
        builder.HasKey(i => i.Id);

    }
}
