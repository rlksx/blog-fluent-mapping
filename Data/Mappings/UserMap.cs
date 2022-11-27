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
            builder.HasKey(x => x.Id);

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

            // index
            builder.HasIndex(x => x.Slug, "IX_USER_SLUG").IsUnique();

            // relations
            builder.HasMany(x => x.Roles).WithMany(x => x.Users)
            .UsingEntity<Dictionary <string, object> >(
                "UserRole",
                role => role.HasOne<Role>().WithMany()
                .HasForeignKey("RoleId").HasConstraintName("FK_UserRole_RoleId")
                .OnDelete(DeleteBehavior.Cascade),

                user => user.HasOne<User>().WithMany()
                .HasForeignKey("UserId").HasConstraintName("FK_UserRole_UserId")
                .OnDelete(DeleteBehavior.Cascade)
            );
        }
    }
}