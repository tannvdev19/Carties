using AuctionService.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AuctionService.ConfigurationEF;

public class AuctionConfiguration : IEntityTypeConfiguration<Auction>
{
    public void Configure(EntityTypeBuilder<Auction> builder)
    {
        builder.ToTable("AUCTION");
        builder.HasKey(a => a.Id);

        builder.Property(a => a.CreatedAt).HasDefaultValueSql("CURRENT_TIMESTAMP AT TIME ZONE 'UTC'").ValueGeneratedOnAdd();
        builder.Property(a => a.UpdatedAt).HasDefaultValueSql("CURRENT_TIMESTAMP AT TIME ZONE 'UTC'").ValueGeneratedOnAddOrUpdate();

        builder.HasOne(a => a.Item).WithOne(i => i.Auction).HasForeignKey<Item>(i => i.AuctionId);
    }
}
