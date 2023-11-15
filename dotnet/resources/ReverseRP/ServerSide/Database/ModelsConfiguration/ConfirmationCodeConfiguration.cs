using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ServerSide.Database.Models;

namespace ServerSide.Database.ModelsConfiguration;

public class ConfirmationCodeConfiguration : IEntityTypeConfiguration<ConfirmationCode>
{
    public void Configure(EntityTypeBuilder<ConfirmationCode> builder)
    {
        builder.HasKey(i => i.Id);
    }
}