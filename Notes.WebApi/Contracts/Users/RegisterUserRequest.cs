using System.ComponentModel.DataAnnotations;

namespace Notes.WebApi.Contracts.Users
{
    public record RegisterUserRequest
    (
        [Required] string UserName,
        [Required] string Email,
        [Required] string Password
    );
}
