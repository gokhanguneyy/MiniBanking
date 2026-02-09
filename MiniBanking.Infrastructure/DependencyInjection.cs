using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MiniBanking.Application.Abstractions;
using MiniBanking.Infrastructure.Persistence;
using MiniBanking.Infrastructure.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniBanking.Infrastructure
{
    /*
     * Bu dependencyInjection class'ı Infrastructure katmanından kullanılacak servisler
     * için oluşturuldu. örn: Redis / DbContext / MessageBroker vs.
     * 
     * Class'ın static olmasının sebebi de, bu class içinde neler varsa hepsini bir kere
     * de sisteme tanıt, yani bunlardan instance oluşturup kullanılmayacak. Bu sebeple
     * sadece static yapılması yeterli.
     */
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration config)
        {

            /*
             * Uygulama içinde DB’ye erişmek isteyen bir servis AppDbContext 
             * talep ettiğinde, sistem SQL Server’a bağlı bir AppDbContext 
             * oluşturur; bağlantı bilgisini appsettings.json içindeki 
             * connection string’den alır ve veri tabanına erişimi sağlar.
             */

            services.AddDbContext<AppDbContext>(opt =>
                opt.UseSqlServer(config.GetConnectionString("SqlServer")));

            services.AddScoped<IJwtTokenService, JwtTokenService>();

            return services;
        }
    }
}
