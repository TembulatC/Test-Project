using Domain.Models;

namespace Domain.Repositories
{
    public interface IJWTProviderRepository
    {
        string GenerateToken(Client client);
    }
}