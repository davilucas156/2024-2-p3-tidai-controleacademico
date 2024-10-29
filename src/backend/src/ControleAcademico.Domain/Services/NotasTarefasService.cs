using System;
using System.Linq;
using System.Threading.Tasks;
using ControleAcademico.Domain.Entities;
using ControleAcademico.Domain.Interfaces.Repositories;
using ControleAcademico.Domain.Interfaces.Services;

namespace ControleAcademico.Domain.Services
{
    public class NotasTarefasService : INotasTarefasService
    {
        private readonly INotasTarefasRepo _NotasTarefasRepo;

        public NotasTarefasService(INotasTarefasRepo NotasTarefasRepo) 
        {
            _NotasTarefasRepo = NotasTarefasRepo;
        }

        public async Task<NotasTarefa> AdicionarNotas(NotasTarefa model)
        {
            // Adiciona a nova nota
            _NotasTarefasRepo.Adicionar(model);

            if (await _NotasTarefasRepo.SalvarMudancaAsync())
                return model;

            throw new Exception("Erro ao salvar a nota.");
        }

        public async Task<NotasTarefa> AtualizarNotas(NotasTarefa model)
        {
            if (model.Matricula <= 0)
                throw new ArgumentException("ID da matrícula é inválido.");

            // Verifica se a nota existe
            var notasExistentes = await _NotasTarefasRepo.PegarTarefasPorTudoAsync(matricula: model.Matricula);
            var nota = notasExistentes.FirstOrDefault(n => n.IdTarefa == model.IdTarefa);
            if (nota == null)
                throw new InvalidOperationException("Nota inexistente.");

            // Atualiza a nota
            _NotasTarefasRepo.Atualizar(model);
            if (await _NotasTarefasRepo.SalvarMudancaAsync())
                return model;

            throw new Exception("Erro ao atualizar a nota.");
        }

        public async Task<bool> DeletarNotas(int idNotas)
        {
            var notas = await _NotasTarefasRepo.PegarTarefasPorTudoAsync(idTarefa: idNotas);
            var nota = notas.FirstOrDefault(); // Obter a primeira nota encontrada

            if (nota == null)
                throw new Exception("Nota que tentou deletar não existe.");

            _NotasTarefasRepo.Deletar(nota);
            return await _NotasTarefasRepo.SalvarMudancaAsync();
        }

        public async Task<NotasTarefa[]> PegarNotasPorTudo(int? nota = null, int? matricula = null, int? idTarefa = null)
        {
            try
            {
                var notas = await _NotasTarefasRepo.PegarTarefasPorTudoAsync(nota, matricula, idTarefa);
                return notas ?? Array.Empty<NotasTarefa>();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<NotasTarefa[]> PegarTodosNotasAsynk()
        {
            try
            {
                var notas = await _NotasTarefasRepo.PegarTodasAsync();
                return notas ?? Array.Empty<NotasTarefa>();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
