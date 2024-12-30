namespace NewsPortalBLL.DTO
{
    public class CommentaryDTO
    {
        public int id { get; set; }
        public int ArticleId { get; set; }
        public int UserId { get; set; }
        public string content { get; set; }
    }
}