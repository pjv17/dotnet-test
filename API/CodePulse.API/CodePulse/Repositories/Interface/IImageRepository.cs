using CodePulse.Models.Domain;

namespace CodePulse.Repositories.Interface
{
    public interface IImageRepository
    {
       Task<BlogImage> Upload(IFormFile file, BlogImage blogImage);

        Task<IEnumerable<BlogImage>> GetAll();
    }
}
