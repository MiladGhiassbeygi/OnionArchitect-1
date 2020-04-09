using Infra.Authentication.Jwt.Models;
using System.Threading;
using System.Threading.Tasks;

namespace Infra.Authentication.Jwt.Contracts
{
    public interface ITokenService
    {
        Task DeleteExpiredRefreshTokensAsync(CancellationToken cancellationToken=default(CancellationToken));
        Task DeleteRefreshTokenAsync(long id, CancellationToken cancellationToken=default(CancellationToken));
        Task<UserToken> FindRefreshToken(int userId, string refreshToken,CancellationToken cancellationToken=default(CancellationToken));
       void UpdateRefreshToken(UserToken userToken);
        Task SaveRefreshTokenAsync(UserToken userToken, CancellationToken cancellationToken=default(CancellationToken));
    }
}
