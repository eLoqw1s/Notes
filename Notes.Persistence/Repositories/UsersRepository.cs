using Microsoft.EntityFrameworkCore;
using Notes.Application.Common.Exeptions;
using Notes.Application.Interfaces;
using Notes.Domain.Models;

namespace Notes.Persistence.Repositories
{
    public class UsersRepository : IUsersRepository
    {
        private readonly NotesDbContext _context;

        public UsersRepository(NotesDbContext notesDbContext)
        {
            _context = notesDbContext;
        }

        public async Task Add(User user)
        {
            var userEntity = new User
            {
                Id = user.Id,
                UserName = user.UserName,
                PasswordHash = user.PasswordHash,
                Email = user.Email,
            };

            await _context.Users.AddAsync(userEntity);
            await _context.SaveChangesAsync();
        }

        public async Task<User> GerByEmail(string email)
        {
            var userEntity = await _context.Users
                .AsNoTracking()
                .FirstOrDefaultAsync(user => user.Email == email);

            if (userEntity == null)
            {
                throw new NotFoundExeption(nameof(Note), email);
            }

            return userEntity;
        }
    }
}
