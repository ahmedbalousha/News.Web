namespace News.Web.Models
{
    public class BaseEntity
    {
        public DateTime CreatedAt { get; set; }
        public string CreatedBy { get; set; } = string.Empty;
        public DateTime? UpdatedAt { get; set; }
        public string UpdatedBy { get; set; } = string.Empty;

        public BaseEntity()
        {
            CreatedAt = DateTime.Now;
        }
    }
}
