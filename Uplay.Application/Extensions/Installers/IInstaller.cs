using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Uplay.Application.Extensions.Installers
{
    public interface IInstaller
    {
        public void InstallServices(IServiceCollection services, IConfiguration configuration);
    }
}
