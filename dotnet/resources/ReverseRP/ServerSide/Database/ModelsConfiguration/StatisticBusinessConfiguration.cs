using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ServerSide.Database.Models;

namespace ServerSide.Database.ModelsConfiguration;

public class StatisticBusinessConfiguration : IEntityTypeConfiguration<StatisticBusiness>
{
    public void Configure(EntityTypeBuilder<StatisticBusiness> builder)
    {
        builder.HasKey(i => i.Id);
    }
}