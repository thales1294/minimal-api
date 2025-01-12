using MinimalApi.Dominio.Entidades;
using MinimalApi.DTOs;

namespace MinimalApi.Dominio.Interfaces;

public interface IVeiculoServico
{
    List<Veiculo> Todos(int? pagina = 1, string? nome = null, string? marca = null);
    Veiculo? BuscaPorId (int id);
    void Incluir(Veiculo veiculo);
    void Atualizar(Veiculo veuculo);
    void Apagar(Veiculo veiculo);
    }