using System.ComponentModel.DataAnnotations;

namespace Notes.WebApi.Contracts.Users
{
    public record LoginUserRequest
    (
        [Required] string Email,
        [Required] string Password
    );
}
