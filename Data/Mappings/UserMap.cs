using blog_orm_structure_with_ef.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace blog_fluent_mapping.Data.Mappings
{
    public class UserMap : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            // tabela
            builder.ToTable("User");

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

            builder.Property(x => x.Bio);
            builder.Property(x => x.Email);
            builder.Property(x => x.Image);
            builder.Property(x => x.PasswordHash);

            builder.Property(x => x.Name)
            .IsRequired() // NOT NULL
            .HasColumnName("Slug") // COLUMN NAME
            .HasColumnType("VARCHAR") // PROPERTY TYPE
            .HasMaxLength(80); // MAX LENGTH

            // indexe
            builder.HasIndex(x => x.Slug, "IX_USER_SLUG").IsUnique();
        }
    }
}