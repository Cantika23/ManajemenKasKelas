using Kas.Identity.Services.Models;

namespace Kas.Identity.Services.Repositories
{
    public interface IUserRepository
    {
        Task<string> CreateUserAsync(CreateUserModel model);
        Task<List<ReadUserModel>> ReadUserAsync();
        Task<string> UpdateUserAsync(UpdateUserModel model);
        Task<string> DeleteUserAsync(string id);

    }
}
