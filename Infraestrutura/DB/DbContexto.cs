using Microsoft.EntityFrameworkCore;
using MinimalApi.Dominio.Entidades;

namespace MinimalApi.Infraestrutura.Db;

public class DbContexto : DbContext
{
    private readonly IConfiguration _configracaoAppSettings;

    public DbContexto(IConfiguration configuracaoAppSettings)
    {
        _configracaoAppSettings = configuracaoAppSettings;
    }
    public DbSet<Administrador> Administradores {get; set;} = default!;

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if(!optionsBuilder.IsConfigured)
        {
            var stringConexao = _configracaoAppSettings.GetConnectionString("mysql")?.ToString();
            if(!string.IsNullOrEmpty(stringConexao))
            {
                optionsBuilder.UseMySql(
                    stringConexao, 
                    ServerVersion.AutoDetect(stringConexao)
                );
            }
        }
    }
}
