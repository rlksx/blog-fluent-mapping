using blog_orm_structure_with_ef.Models;
using Microsoft.EntityFrameworkCore;

namespace blog_orm_structure_with_ef.Data
{
    public class BlogDataContext : DbContext
    {
        

        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlServer(@"Server=localhost,1433;Database=Blog;User ID=sa;Password=1q2w3e4r@#$;Trusted_Connection=False; TrustServerCertificate=True;");
    }
}