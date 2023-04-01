using JohnAndJaneBanking.Identity.Models;

namespace JohnAndJaneBanking.Identity.Services;

public interface IJwtService
{
    string GenerateJwtToken(ApplicationUser user);
}