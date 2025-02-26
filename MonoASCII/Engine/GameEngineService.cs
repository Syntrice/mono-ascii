using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace MonoASCII.Engine;

public class GameEngineService(ILogger<GameEngineService> logger, IHostApplicationLifetime appLifetime, GameEngine engine) : BackgroundService
{
    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        logger.LogInformation("Starting game engine...");
        await Task.Run(engine.Run, stoppingToken);
        appLifetime.StopApplication();
    }
}