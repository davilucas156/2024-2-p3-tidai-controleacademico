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
    public class RelacionamentoUsuarioDisciplinaService : IRelacionamentoUsuarioDisciplinaService
        {
        private readonly IRelacionamentoUsuarioDisciplinaRepo _RelacionamentoRepo;

        public RelacionamentoUsuarioDisciplinaService(IRelacionamentoUsuarioDisciplinaRepo NotasTarefasRepo) 
        {
            _RelacionamentoRepo = NotasTarefasRepo;
        }


        public async Task<DisciplinasUsuario> AdicionarRelacionamento(DisciplinasUsuario model)
        {
            // Adiciona o novo curso
            _RelacionamentoRepo.Adicionar(model);

            if (await _RelacionamentoRepo.SalvarMudancaAsync())
                return model;

            throw new Exception("Erro ao salvar o curso.");
        }


        public async Task<DisciplinasUsuario> AtualizarRelacionamento(DisciplinasUsuario model)
        {
            if (model.Matricula <= 0)
                throw new ArgumentException("ID do curso é inválido.");

            // Verifica se o curso existe
            var cursoExistente = await _RelacionamentoRepo.PegarRelacionamentoPorTudoAsync(matricula: model.Matricula);
            var curso = cursoExistente.FirstOrDefault();
            if (curso == null)
                throw new InvalidOperationException("Curso inexistente.");

            // Atualiza o curso
            _RelacionamentoRepo.Atualizar(model);
            if (await _RelacionamentoRepo.SalvarMudancaAsync())
                return model;

            throw new Exception("Erro ao atualizar o curso.");
        }


        public async Task<bool> DeletarRelacionamento(int Matricula)
        {
            {
                var disciplinas = await _RelacionamentoRepo.PegarRelacionamentoPorTudoAsync(matricula: Matricula);
                var curso = disciplinas.FirstOrDefault(); // Obter o primeiro curso encontrado

                if (curso == null) throw new Exception("Curso que tentou deletar não existe");

                _RelacionamentoRepo.Deletar(curso);
                return await _RelacionamentoRepo.SalvarMudancaAsync();
            }
        }

        public async Task<DisciplinasUsuario[]> PegarRelacionamentoPorTudo(int? matricula = null, int? idDisciplinas = null)
        {
            try
            {
                var curso = await _RelacionamentoRepo.PegarRelacionamentoPorTudoAsync(matricula, idDisciplinas);
                if (curso == null) return null;

                return curso;
            }
            catch (System.Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }


        public async Task<DisciplinasUsuario[]> PegarTodosRelacionamentoAsynk()
        {
            try
            {
                var cursos = await _RelacionamentoRepo.PegarTodasAsync();
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
