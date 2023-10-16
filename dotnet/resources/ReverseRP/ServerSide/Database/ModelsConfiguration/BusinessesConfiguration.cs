using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ServerSide.Database.Models;

namespace ServerSide.Database.ModelsConfiguration;

public class BusinessesConfiguration : IEntityTypeConfiguration<BusinessBase>
{
    public void Configure(EntityTypeBuilder<BusinessBase> builder)
    {
        builder.HasKey(i => i.Id);
    }
}