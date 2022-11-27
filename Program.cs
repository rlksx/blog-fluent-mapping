
using blog_orm_structure_with_ef.Data;
using blog_orm_structure_with_ef.Models;

namespace blog_fluent_mapping
{
    public class Program
    {
        static void Main(string[] args)
        {
            using var context = new BlogDataContext();

            context.Users.Add(new User
            {
                Bio = "Software Engineer Student",
                Email = "ryan.bromati@hotmail.com",
                Image = "https://...",
                Name = "Ryan Gabriel",
                PasswordHash = "HASH",
                Slug = "ryan-bromati"
            });
        }
    }
}