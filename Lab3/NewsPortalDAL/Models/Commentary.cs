using System.ComponentModel.DataAnnotations.Schema;

namespace NewsPortalDAL.Models
{
    [Table("Comments")]
    public class Commentary
    {
        public int id { get; set; }
        public int ArticleId { get; set; }
        public int AuthorId { get; set; }
        public string content { get; set; }

    }
}