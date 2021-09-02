using InventoryManagement.Domian.InventoryAgg;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace InventoryManagement.Infrastructure.EFCore.Mapping
{
    public class InventoryMapping : IEntityTypeConfiguration<Inventory>
    {
        public void Configure(EntityTypeBuilder<Inventory> builder)
        {
            builder.HasKey(x => x.Id);

            builder.OwnsMany(x => x.Operations,
                x =>
                {
                    x.HasKey(x => x.Id);
                    x.Property(x => x.Description).HasMaxLength(1000);

                    x.WithOwner(x => x.Inventory)
                        .HasForeignKey(x => x.InventoryId);
                });
        }
    }
}