using blog_orm_structure_with_ef.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace blog_fluent_mapping.Data.Mappings
{
    public class CategoryMap : IEntityTypeConfiguration<Category> //=> interface
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            // tabela
            builder.ToTable("Category");

            // primary key
            // builder.HasKey(x => x.Id);

            // identity (1, 1) e primary key
            builder.Property(x => x.Id).ValueGeneratedOnAdd().UseIdentityColumn();

            // property
            builder.Property(x => x.Name)
            .IsRequired() // NOT NULL
            .HasColumnName("Name") // COLUMN NAME
            .HasColumnType("NVARCHAR") // PROPERTY TYPE
            .HasMaxLength(80); // MAX LENGTH

            builder.Property(x => x.Slug)
            .IsRequired() // NOT NULL
            .HasColumnName("Slug") // COLUMN NAME
            .HasColumnType("VARCHAR") // PROPERTY TYPE
            .HasMaxLength(80); // MAX LENGTH

            // indexes
            builder.HasIndex(x => x.Slug, "IX_Category_Slug").IsUnique();
        }
    }
}