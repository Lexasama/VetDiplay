using System.Threading.Tasks;
using VetDisplay.DAL;

namespace VetDisplay.Services
{
    public class ConfigService
    {
        readonly ConfigGateway _configGateway;
        readonly PasswordHasher _passwordHasher;

        
        public ConfigService(ConfigGateway configGateway, PasswordHasher passwordHasher)
        {
            _configGateway = configGateway;
            _passwordHasher = passwordHasher;
        }

        public Task<Result<int>> CreatePasswordUser(string email, string password)
        {
            return _configGateway.CreatePasswordUser(email, _passwordHasher.HashPassword(password));
        }

        public async Task<ConfigData> FindUser(string email, string password)
        {
            ConfigData config = await _configGateway.FindByEmail(email);
            if (config != null && _passwordHasher.VerifyHashedPassword(config.Password, password) == PasswordVerificationResult.Success)
            {
                return config;
            }

            return null;
        }
    }
}
