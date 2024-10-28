using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ControleAcademico.Domain.Entities;
using ControleAcademico.Domain.Interfaces.Repositories;
using ControleAcademico.Domain.Interfaces.Services;

namespace ControleAcademico.Domain.Services
{
    public class TarefaDisciplinaService : ITarefaDisciplinaService
    {
        private readonly IDisciplinaRepo _disciplinaRepo;
        private readonly ITarefasDisciplinaRepo _TarefaRepo;
        public TarefaDisciplinaService(ITarefasDisciplinaRepo TarefaRepo, IDisciplinaRepo disciplinaRepo)
        {
            _disciplinaRepo = disciplinaRepo;
            _TarefaRepo = TarefaRepo;
        }

        public async Task<TarefasDisciplina> AdicionarTarefa(TarefasDisciplina model)
        {
            // Verifica se já existe um curso com o mesmo nome
            var disciplinasComMesmoNome = await _TarefaRepo.PegarTarefaPorTudoAsync(titulo: model.Titulo);
            if (disciplinasComMesmoNome.FirstOrDefault() != null)
                throw new InvalidOperationException("Já existe um curso com esse nome.");

            var disciplinasComCurso = await _disciplinaRepo.PegarDisciplinaPorTudoAsync(id: model.IdDisciplinas);
            if (disciplinasComCurso.FirstOrDefault() != null) // se exitir a disciplina
            {
                // Adiciona o novo curso
                _TarefaRepo.Adicionar(model);
                if (await _TarefaRepo.SalvarMudancaAsync())
                    return model;
            }
            throw new Exception("Erro ao salvar o curso.");
        }

        public async Task<TarefasDisciplina> AtualizarTarefa(TarefasDisciplina model)
        {
            if (model.IdDisciplinas <= 0)
                throw new ArgumentException("ID do curso é inválido.");

            // Verifica se o curso existe
            var cursoExistente = await _TarefaRepo.PegarTarefaPorTudoAsync(idTarefa: model.IdTarefa);
            var curso = cursoExistente.FirstOrDefault();
            if (curso == null)
                throw new InvalidOperationException("Curso inexistente.");

            // Atualiza o curso
            _TarefaRepo.Atualizar(model);
            if (await _TarefaRepo.SalvarMudancaAsync())
                return model;

            throw new Exception("Erro ao atualizar o curso.");
        }

        public async Task<bool> DeletarTarefa(int IdTarefa)
        {
            {
                var disciplinas = await _TarefaRepo.PegarTarefaPorTudoAsync(idTarefa: IdTarefa);
                var curso = disciplinas.FirstOrDefault(); // Obter o primeiro curso encontrado

                if (curso == null) throw new Exception("Curso que tentou deletar não existe");

                _TarefaRepo.Deletar(curso);
                return await _TarefaRepo.SalvarMudancaAsync();
            }
        }

        public async Task<TarefasDisciplina[]> PegarTarefaPorTudo(int? idTarefa = null, string? modulo = null, string? titulo = null, int? valor = null, DateOnly? dataEntrega = null, string? linkArquivoTarefa = null, int? idDisciplinas = null)
        {
            try
            {
                var curso = await _TarefaRepo.PegarTarefaPorTudoAsync(idTarefa, modulo,titulo, valor, dataEntrega, linkArquivoTarefa, idDisciplinas);
                if (curso == null) return null;

                return curso;
            }
            catch (System.Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<TarefasDisciplina[]> PegarTodosTarefaAsynk()
        {
            try
            {
                var disciplinas = await _TarefaRepo.PegarTodasAsync();
                if (disciplinas == null) return null;

                return disciplinas;
            }
            catch (System.Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}