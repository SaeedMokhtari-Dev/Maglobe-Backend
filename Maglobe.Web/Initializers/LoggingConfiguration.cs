using System;
using Maglobe.Web.Configuration.Constants;
using Maglobe.Web.Logging.Loggers;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using NLog;

namespace Maglobe.Web.Initializers
{
    public static class LoggingConfiguration
    {
        public static IServiceCollection ConfigureLogger(this IServiceCollection services, IConfiguration configuration)
        {
            var config = configuration.GetSection(nameof(SettingsKeys.Logging));

            FileLogger.Create()
                .Level(config[SettingsKeys.Logging.LogLevel])
                .KeepMaxLogs(config.GetValue<int>(SettingsKeys.Logging.KeepMaxLogs))
                .Directory(config[SettingsKeys.Logging.ServerDirectory].Replace("APP_DIR", AppDomain.CurrentDomain.BaseDirectory))
                .Initialize();

            FileLogger.Create()
                .Name("Client")
                .Layout("${message}")
                .Level(config[SettingsKeys.Logging.LogLevel])
                .KeepMaxLogs(config.GetValue<int>(SettingsKeys.Logging.KeepMaxLogs))
                .Directory(config[SettingsKeys.Logging.ClientDirectory].Replace("APP_DIR", AppDomain.CurrentDomain.BaseDirectory))
                .Initialize();

            DebugLogger.Create().Initialize();

            LogManager.GetCurrentClassLogger().Info("Successfully initialized the logger");

            return services;
        }
    }
}
