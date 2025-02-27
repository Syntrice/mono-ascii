using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MonoASCII.Engine;

var builder = new HostApplicationBuilder();
builder.Services.AddSingleton<MonoGameEngine>();
builder.Services.AddHostedService<GameEngineService>();
var app = builder.Build();
await app.RunAsync();