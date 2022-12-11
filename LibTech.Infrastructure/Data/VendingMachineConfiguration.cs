using LibTech.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LibTech.Infrastructure.Data
{
    internal class VendingMachineConfiguration : IEntityTypeConfiguration<VendingMachine>
    {
        public void Configure(EntityTypeBuilder<VendingMachine> builder)
        {
            builder
                .HasKey(p => p.Id);

            builder
                .OwnsOne(p => p.MoneyInside)
                .Property(p => p.OneCentCount)
                .HasColumnName("OneCentCount");

            builder
                .OwnsOne(p => p.MoneyInside)
                .Property(p => p.TenCentCount)
                .HasColumnName("TenCentCount");

            builder
                .OwnsOne(p => p.MoneyInside)
                .Property(p => p.QuarterCount)
                .HasColumnName("QuarterCount");

            builder
                .OwnsOne(p => p.MoneyInside)
                .Property(p => p.OneDollarCount)
                .HasColumnName("OneDollarCount");

            builder
                .OwnsOne(p => p.MoneyInside)
                .Property(p => p.FiveDollarCount)
                .HasColumnName("FiveDollarCount");

            builder
                .OwnsOne(p => p.MoneyInside)
                .Property(p => p.TwentyDollarCount)
                .HasColumnName("TwentyDollarCount");

            builder.Ignore(p => p.MoneyInTransaction);
        }
    }
}
