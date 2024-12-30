namespace NewsPortalDAL.Models
{
    public class Author
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }

        public virtual ICollection<Commentary> Comments { get; set; }
    }
}