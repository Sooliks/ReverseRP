using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ServerSide.Database.Models;
using ServerSide.Database.Models.Businesses;

namespace ServerSide.Database.ModelsConfiguration;

public class OrderBusinessConfiguration : IEntityTypeConfiguration<OrderBusiness>
{
    public void Configure(EntityTypeBuilder<OrderBusiness> builder)
    {
        builder.HasKey(i => i.Id);
    }
}