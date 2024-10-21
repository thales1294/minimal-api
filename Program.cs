using MinimalApi.Infraestrutura.Db;
using MinimalApi.DTOs;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

builder.Services.AddDbContext<DbContexto>(options => {
    options.UseMySql(
    builder.Configuration.GetConnectionString("mysql"),
    ServerVersion.AutoDetect(builder.Configuration.GetConnectionString("mysql"))
    );
});

app.MapGet("/", () => "Hello World!");

app.MapPost("/login", (LoginDTO loginDTO) => {
    if(loginDTO.Email =="adm@teste.com" && loginDTO.Senha == "123456")
        return Results.Ok("Login com sucesso!");
    else
    return Results.Unauthorized();
});

app.Run();

public class LoginDTO
{
    public string Email {get; set;} = default!;
    public string Senha {get; set;} = default!;
}   