using MinimalApi.Domain.Enuns;

namespace MinimalApi.Domain.DTOs
{
    public class AdministratorDTO
    {
        public string Email { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public Profile Profile { get; set; } = Profile.Editor;
    }
}
