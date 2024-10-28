using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ControleAcademico.Domain.Entities;
using ControleAcademico.Domain.Interfaces.Repositories;
using ControleAcademico.Domain.Interfaces.Services;
using static ControleAcademico.Domain.Entities.Curso;

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
            // Adiciona o novo curso
            _NotasTarefasRepo.Adicionar(model);

            if (await _NotasTarefasRepo.SalvarMudancaAsync())
                return model;

            throw new Exception("Erro ao salvar o curso.");
        }


        public async Task<NotasTarefa> AtualizarNotas(NotasTarefa model)
        {
            if (model.Matricula <= 0)
                throw new ArgumentException("ID do curso é inválido.");

            // Verifica se o curso existe
            var cursoExistente = await _NotasTarefasRepo.PegarTarefasPorTudoAsync(matricula: model.Matricula);
            var curso = cursoExistente.FirstOrDefault();
            if (curso == null)
                throw new InvalidOperationException("Curso inexistente.");

            // Atualiza o curso
            _NotasTarefasRepo.Atualizar(model);
            if (await _NotasTarefasRepo.SalvarMudancaAsync())
                return model;

            throw new Exception("Erro ao atualizar o curso.");
        }


        public async Task<bool> DeletarNotas(int IdNotas)
        {
            {
                var disciplinas = await _NotasTarefasRepo.PegarTarefasPorTudoAsync(idTarefa: IdNotas);
                var curso = disciplinas.FirstOrDefault(); // Obter o primeiro curso encontrado

                if (curso == null) throw new Exception("Curso que tentou deletar não existe");

                _NotasTarefasRepo.Deletar(curso);
                return await _NotasTarefasRepo.SalvarMudancaAsync();
            }
        }


        public async Task<NotasTarefa[]> PegarNotasPorTudo(int? nota = null, int? matricula = null, int? idTarefa = null)
        {

            try
            {
                var curso = await _NotasTarefasRepo.PegarTarefasPorTudoAsync(nota, matricula,idTarefa);
                if (curso == null) return null;

                return curso;
            }
            catch (System.Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<NotasTarefa[]> PegarTodosNotasAsynk()
        {
            try
            {
                var cursos = await _NotasTarefasRepo.PegarTodasAsync();
                if (cursos == null) return null;

                return cursos;
            }
            catch (System.Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }


        
    }
}
