using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace MonoASCII.Engine;

/// <summary>
/// Responsible for controlling the lifecycle of the application and starting up the game engine.
/// </summary>
public class GameEngineService(ILogger<GameEngineService> logger, IHostApplicationLifetime appLifetime, MonoGameEngine engine) : BackgroundService
{
    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        logger.LogInformation("Starting game engine...");
        await Task.Run(engine.Run, stoppingToken);
        appLifetime.StopApplication();
    }
}