using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ServerSide.Database.Models;

namespace ServerSide.Database.ModelsConfiguration;

public class ItemBaseConfiguration : IEntityTypeConfiguration<ItemBase>
{
    public void Configure(EntityTypeBuilder<ItemBase> builder)
    {
        builder.HasKey(i => i.Id);
        builder.HasOne<Character>(i => i.Character);
    }
}