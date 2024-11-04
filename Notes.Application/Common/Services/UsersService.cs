using Notes.Application.Interfaces;
using Notes.Application.Interfaces.Auth;
using Notes.Domain.Models;

namespace Notes.Application.Common.Services
{
    public class UsersService
    {
        private readonly IPasswordHasher _passwordHasher;
        private readonly IUsersRepository _userRepository;
        private readonly IJwtProvider _jwtProvider;

        public UsersService(
            IPasswordHasher passwordHasher, 
            IUsersRepository userRepository,
            IJwtProvider jwtProvider) 
        {
            _passwordHasher = passwordHasher;
            _userRepository = userRepository;
            _jwtProvider = jwtProvider;
        }

        public async Task Register(string UserName, string email, string password)
        {
            var hashedPassword = _passwordHasher.Generate(password);
            var userEntity = new User
            {
                Id = Guid.NewGuid(),
                UserName = UserName,
                PasswordHash = hashedPassword,
                Email = email
            };
            await _userRepository.Add(userEntity);
        }

        public async Task<string> Login(string Email, string password)
        {
            var userEntity = await _userRepository.GerByEmail(Email);

            var result = _passwordHasher.Verify(password, userEntity.PasswordHash);

            if(result == false)
            {
                throw new Exception("Failed login");
            }

            var token = _jwtProvider.GenerateToken(userEntity);

            return token;
        }
    }
}
