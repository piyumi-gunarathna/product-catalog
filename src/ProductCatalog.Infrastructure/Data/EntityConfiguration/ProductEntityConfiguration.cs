using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ProductCatalog.Infrastructure.Data.EntityConfiguration
{
    internal class ProductEntityConfiguration: IEntityTypeConfiguration<ProductDbModel>
    {

        public void Configure(EntityTypeBuilder<ProductDbModel> builder)
        {
            builder.ToTable("Products");
            builder.HasKey(v => v.Id);

            builder.Property(v => v.Id)
                .HasColumnName("Id")
                .HasColumnType("int")
                .ValueGeneratedOnAdd();

            builder.Property(v => v.Name)
                .HasColumnName("Name")
                .HasColumnType("varchar(200)")
                .IsRequired();

            builder.Property(v => v.Description)
                .HasColumnName("Description")
                .HasColumnType("varchar(800)")
                .IsRequired();

            builder.Property(v => v.Price)
                .HasColumnName("Price")
                .HasColumnType("decimal(12,2)")
                .IsRequired();

            builder.HasOne(s => s.Category)
                .WithMany()
                .HasForeignKey(s => s.CategoryId);
        }
    }
}
