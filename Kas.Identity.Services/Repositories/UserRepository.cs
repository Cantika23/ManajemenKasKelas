using Kas.Identity.Domain;
using Kas.Identity.Domain.Entities;
using Kas.Identity.Services.Models;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace Kas.Identity.Services.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly ILogger<UserRepository> _logger;
        private readonly IdentityContext _context;

        public UserRepository(ILogger<UserRepository> logger, IdentityContext context)
        {
            _logger = logger;
            _context = context;
        }

        public async Task<string> CreateUserAsync(CreateUserModel model)
        {
            try
            {

                var role = await _context.Roles.FirstOrDefaultAsync(x => x.Id == model.id);

                var dataUser = new User();

                dataUser.id = Guid.NewGuid().ToString();
                dataUser.username = model.username;
                dataUser.password = model.password;
                dataUser.roleId = role.Id;


                this._context.Add(dataUser);
                await _context.SaveChangesAsync();

                return dataUser.id;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                throw;
            }

        }

        public async Task<string> DeleteUserAsync(string id)
        {
            try
            {
                var agunan = await _context.Users.Where(x => x.id == id).ExecuteDeleteAsync();

                await _context.SaveChangesAsync();

                return "0";
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                throw;
            }
        }

        public async Task<List<ReadUserModel>> ReadUserAsync()
        {
            try
            {
                var user = await _context.Users
                    .Select(x => new ReadUserModel()
                    {
                        id = x.id,
                        username = x.username,
                    })
                    .ToListAsync();

                return user;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                throw;
            }
        }

        public async Task<string> UpdateUserAsync(UpdateUserModel model)
        {
            try
            {
                var User = await _context.Users.Where(x => x.id == model.id)
                   .FirstOrDefaultAsync();

                if (User == null)
                    throw new GlobalException("902", "Data Not Found");


                var dataUser = new User();

                dataUser.id = Guid.NewGuid().ToString();
                dataUser.username = model.username;
                dataUser.password = model.password;
                dataUser.roleId = model.role;



                this._context.Update(dataUser);
                await _context.SaveChangesAsync();

                return dataUser.id;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                throw;
            }
        }
    }
}
