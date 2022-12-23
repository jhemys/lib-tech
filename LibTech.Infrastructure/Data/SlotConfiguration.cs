using LibTech.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LibTech.Infrastructure.Data
{
    internal class SlotConfiguration : IEntityTypeConfiguration<Slot>
    {
        public void Configure(EntityTypeBuilder<Slot> builder)
        {
            builder
                .HasKey(p => p.Id);

            builder
                .OwnsOne(p => p.BookPile);

            builder
                .Property(p => p.Position);

            builder
                .HasOne(p => p.VendingMachine)
                .WithMany(p => p.Slots);

            builder
                .OwnsOne(p => p.BookPile, a =>
                {
                    a.Property(p => p.Quantity).HasColumnName("Quantity");
                    a.Property(p => p.Price).HasColumnName("Price");

                    a.HasOne(p => p.Book).WithMany().HasForeignKey("BookId");
                    a.Navigation(p => p.Book).AutoInclude();
                });
        }
    }
}
