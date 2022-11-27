using blog_orm_structure_with_ef.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace blog_fluent_mapping.Data.Mappings
{
    public class PostMap : IEntityTypeConfiguration<Post>
    {
        public void Configure(EntityTypeBuilder<Post> builder)
        {
            // tabela
            builder.ToTable("Post");

            // primary key
            builder.HasKey(x => x.Id);

            // identity (1, 1) e primary key
            builder.Property(x => x.Id).ValueGeneratedOnAdd().UseIdentityColumn();

            // property
            builder.Property(x => x.LastUpdateDate)
            .IsRequired() // NOT NULL
            .HasColumnName("LastUpdateDate") //=> DATETIME  NOT NULL DEFAULT(GETDATE())
            .HasColumnType("SMALLDATETIME")
            .HasDefaultValue(DateTime.Now.ToUniversalTime()); // UTC formated
            //.HasDefaultValueSql("GETDATE()");

            // indexe
            builder.HasIndex(x => x.Slug, "IX_POST_SLUG").IsUnique();

            // relations
            builder.HasOne(x => x.Author).WithMany(x => x.Posts) //=> One to Many
            .HasConstraintName("FK_Post_Author").OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(x => x.Category).WithMany(x => x.Posts) //=> One to many
            .HasConstraintName("FK_Post_Category").OnDelete(DeleteBehavior.Cascade);

            /* gerando uma tabela PostTag */
            builder.HasMany(x => x.Tags).WithMany(x => x.Posts)
            .UsingEntity<Dictionary <string, object> >(
                "PostTag",
                post => post.HasOne<Tag>().WithMany()
                .HasForeignKey("PostId").HasConstraintName("FK_PostTag_PostId")
                .OnDelete(DeleteBehavior.Cascade),

                tag => tag.HasOne<Post>().WithMany()
                .HasForeignKey("TagId").HasConstraintName("FK_PostTag_TagId")
                .OnDelete(DeleteBehavior.Cascade)
            );
        }
    }
}