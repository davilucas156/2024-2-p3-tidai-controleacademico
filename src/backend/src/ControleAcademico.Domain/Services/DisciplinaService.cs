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
    public class DisciplinaService : IDisciplinaService
    {
        private readonly IDisciplinaRepo _disciplinaRepo;
        private readonly ICursoRepo _cursoRepo;
        public DisciplinaService(IDisciplinaRepo disciplinaRepo, ICursoRepo cursoRepo)
        {
            this._disciplinaRepo = disciplinaRepo;
            this._cursoRepo = cursoRepo;
        }

    public async Task<Disciplina> AdicionarDisciplina(Disciplina model)
    {
        try
        {
            // Verifica se já existe um curso com o mesmo nome
            var disciplinasComMesmoNome = await _disciplinaRepo.PegarDisciplinaPorTudoAsync(nome: model.Nome);
            if (disciplinasComMesmoNome.FirstOrDefault() != null)
                throw new InvalidOperationException("Já existe uma disciplina com esse nome.");

            // Verifica se o curso existe
            var cursoExistente = await _cursoRepo.PegarCursoPorTudoAsync(model.IdCurso);
            if (cursoExistente == null)
                throw new InvalidOperationException("Curso inexistente.");

            // Adiciona o novo curso
            _disciplinaRepo.Adicionar(model);
            if (await _disciplinaRepo.SalvarMudancaAsync())
                return model;
            return null;
        }
        catch (Exception ex)
        {
            // Aqui você pode registrar o erro para facilitar o diagnóstico
            throw new Exception($"Erro ao tentar adicionar disciplina: {ex.Message}");
        }
    }


public async Task<Disciplina> AtualizarDisciplina(Disciplina model)
{
    // Verifica se o ID da disciplina é válido
    if (model.IdDisciplinas <= 0)
        throw new ArgumentException("ID da disciplina é inválido.");

    // Verifica se o curso existe
    var cursoExistente = await _cursoRepo.PegarCursoPorTudoAsync(model.IdCurso);
    if (cursoExistente == null)
        throw new InvalidOperationException("Curso inexistente.");

    // Atualiza a disciplina
    _disciplinaRepo.Atualizar(model);
    if (await _disciplinaRepo.SalvarMudancaAsync())
        return model;

    throw new Exception("Erro ao atualizar a disciplina.");
}


        public async Task<bool> DeletarDisciplina(int IdDisciplina)
        {
            {
                var disciplinas = await _disciplinaRepo.PegarDisciplinaPorTudoAsync(id: IdDisciplina);
                var curso = disciplinas.FirstOrDefault(); // Obter o primeiro curso encontrado

                if (curso == null) throw new Exception("Curso que tentou deletar não existe");

                _disciplinaRepo.Deletar(curso);
                return await _disciplinaRepo.SalvarMudancaAsync();
            }
        }


        public async Task<Disciplina[]> PegarDisciplinaPorTudo(int? id= null, string? nome= null, int? semestre= null, int?IdCurso=null, Curso? idCursoNavigation=null)
        {
            try
            {
                var curso = await _disciplinaRepo.PegarDisciplinaPorTudoAsync(id, nome,semestre, IdCurso, idCursoNavigation);
                if (curso == null) return null;

                return curso;
            }
            catch (System.Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<Disciplina[]> PegarTodosDisciplinaAsynk()
        {
            try
            {
                var disciplinas = await _disciplinaRepo.PegarTodasAsync();
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
