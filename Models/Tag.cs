using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace blog_orm_structure_with_ef.Models
{
    [Table("Tag")] //=> buscará Tag no bando e não "Tags" como esta no DbSet.
    public class Tag
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Slug { get; set; }

        public IList<Post> Posts { get; set; }
    }
}