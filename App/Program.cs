using ApiTodoList.Domain.Interfaces;
using ApiTodoList.Domain.Services;
using ApiTodoList.Infra.Repositories;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSingleton<ITarefaRepository, TarefaRepositoryInMemory>();
builder.Services.AddScoped<TarefaService>();

builder.WebHost.UseUrls("http://0.0.0.0:80");

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCors(options =>
{
    options.AddPolicy("DevCorsPolicy", policy =>
    {
        policy.AllowAnyOrigin()
              .AllowAnyMethod()
              .AllowAnyHeader();
    });
});

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.UseRouting();

app.UseCors("DevCorsPolicy");

app.UseAuthorization();
app.MapControllers();

app.Run();
