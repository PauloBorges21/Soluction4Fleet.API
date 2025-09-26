using Soluction4Fleet.API.Application.DTOs.Relatorio;
using Soluction4Fleet.API.Application.Interfaces.Repository;
using Soluction4Fleet.API.Application.Interfaces.Services;
using System.Text;

namespace Soluction4Fleet.API.Application.Services
{
    public class RelatorioService : IRelatorioService
    {
        private readonly IRelatorioRepository _repository;
        public RelatorioService(IRelatorioRepository repository)
        {
            _repository = repository;
        }

        private byte[] GerarCsv<T>(List<T> dados, List<string> colunas, Func<T, string[]> mapFunc)
        {
            var sb = new StringBuilder();

            // Usar ponto e vírgula como separador
            var separador = ";";

            // Cabeçalho
            sb.AppendLine(string.Join(separador, colunas));

            // Dados
            foreach (var item in dados)
            {
                // Evitar problemas com vírgulas no texto
                var valores = mapFunc(item).Select(v => $"\"{v}\"");
                sb.AppendLine(string.Join(separador, valores));
            }

            return Encoding.UTF8.GetBytes(sb.ToString());
        }


        public async Task<byte[]> GetLocadorasVeiculosCsvAsync(LocadoraVeiculoFiltroDTO filtro)
        {
            var dados = await _repository.GetLocadorasVeiculosAsync(filtro);
            return GerarCsv(dados,
                new List<string> { "Nome da Locadora", "Modelo", "Placa", "Data de Cadastro" },
                d => new[] { d.NomeLocadora, d.Modelo, d.Placa, d.DataCadastro.ToString("dd/MM/yyyy") });
        }

        public async Task<byte[]> GetLocadorasModelosCsvAsync()
        {
            var dados = await _repository.GetLocadorasModelosAsync();
            return GerarCsv(dados,
                new List<string> { "Nome da Locadora", "Modelo", "Quantidade" },
                d => new[] { d.NomeLocadora, d.Modelo, d.Quantidade.ToString() });
        }

        public async Task<byte[]> GetLogVeiculosCsvAsync()
        {
            var dados = await _repository.GetLogVeiculosAsync();
            return GerarCsv(dados,
                new List<string> { "Nome da Locadora", "Modelo", "Data Entrada", "Data Saida" },
                d => new[] { d.NomeLocadora, d.Modelo, d.DataEntrada.ToString("dd/MM/yyyy"), d.DataSaida?.ToString("dd/MM/yyyy") ?? "" });
        }
    }
}
