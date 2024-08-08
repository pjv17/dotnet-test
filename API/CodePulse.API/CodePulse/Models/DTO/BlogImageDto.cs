namespace CodePulse.Models.DTO
{
    public class BlogImageDto
    {
        public Guid id { get; set; }
        public string Filename { get; set; }
        public string FileExtension { get; set; }
        public string Title { get; set; }
        public string Url { get; set; }
        public DateTime DateCreated { get; set; }
    }
}
