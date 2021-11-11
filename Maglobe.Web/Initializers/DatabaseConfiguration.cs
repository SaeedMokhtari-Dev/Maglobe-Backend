using Maglobe.DataAccess.Contexts;
using Maglobe.Web.Configuration.Constants;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using NLog;

namespace Maglobe.Web.Initializers
{
    public static class DatabaseConfiguration
    {
        private static readonly ILogger Logger = LogManager.GetCurrentClassLogger();

        public static IServiceCollection ConfigureDatabase(this IServiceCollection services, IConfiguration configuration)
        {
            //Logger.Info("Configuring the database and running migrations");

            var connectionString = configuration.GetValue<string>(SettingsKeys.ConnectionString);

            services.AddScoped(x => new MaglobeContext(connectionString));

            /*var migrator = new MysqlMigrator<MySqlConnection>(new MigratorOptions(connectionString, typeof(MaglobeContext).Assembly));

            migrator.Migrate();*/

            return services;
        }
    }
}
