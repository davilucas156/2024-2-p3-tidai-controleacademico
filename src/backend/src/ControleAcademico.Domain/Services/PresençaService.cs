using System;
using System.Linq;
using System.Threading.Tasks;
using ControleAcademico.Domain.Entities;
using ControleAcademico.Domain.Interfaces.Repositories;
using ControleAcademico.Domain.Interfaces.Services;
using static ControleAcademico.Domain.Entities.Presenca;

namespace ControleAcademico.Domain.Services
{
    public class PresencaService : IPresencaService
    {
        private readonly IPresencaRepo _PresencaRepo;

        public PresencaService(IPresencaRepo PresencaRepo) 
        {
            _PresencaRepo = PresencaRepo;
        }

        public async Task<Presenca> AdicionarPresenca(Presenca model)
        {
            // Adiciona a nova presença
            _PresencaRepo.Adicionar(model);

            if (await _PresencaRepo.SalvarMudancaAsync())
                return model;

            throw new Exception("Erro ao salvar a presença.");
        }

        public async Task<Presenca> AtualizarPresenca(Presenca model)
        {
            if (model.IdDisciplinasUsuario <= 0)
                throw new ArgumentException("ID da presença é inválido.");

            // Verifica se a presença existe
            var presencaExistente = await _PresencaRepo.PegarPresencaPorTudoAsync(idDisciplinasUsuario: model.IdDisciplinasUsuario, data: null, presenca: null);
            if (presencaExistente.FirstOrDefault() == null)
                throw new InvalidOperationException("Presença inexistente.");

            // Atualiza a presença
            _PresencaRepo.Atualizar(model);
            if (await _PresencaRepo.SalvarMudancaAsync())
                return model;

            throw new Exception("Erro ao atualizar a presença.");
        }

        public async Task<bool> DeletarPresenca(int idPresenca)
        {
            var presenca = await _PresencaRepo.PegarPresencaPorTudoAsync(idDisciplinasUsuario: null, data: null, presenca: null);
            var presencaEncontrada = presenca.FirstOrDefault();

            if (presencaEncontrada == null)
                throw new Exception("Presença que tentou deletar não existe.");

            _PresencaRepo.Deletar(presencaEncontrada);
            return await _PresencaRepo.SalvarMudancaAsync();
        }

        public async Task<Presenca[]> PegarPresencaPorTudo(DateOnly? data = null, Presença? presenca = null, int? idDisciplinasUsuario = null)
        {
            try
            {
                var presencas = await _PresencaRepo.PegarPresencaPorTudoAsync(data, presenca, idDisciplinasUsuario);
                return presencas ?? Array.Empty<Presenca>();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<Presenca[]> PegarTodosPresencaAsynk()
        {
            try
            {
                var presencas = await _PresencaRepo.PegarTodasAsync();
                return presencas ?? Array.Empty<Presenca>();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
