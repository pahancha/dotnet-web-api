using api.Models;

namespace api.Interfaces
{
    public interface ICommentRepository
    {
        Task<List<Comment>> GetAllSync();
        Task<Comment?> GetByIdAsync(int id);
    }
}
