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
    public class MaterialDisciplinaService : IMaterialDisciplinaService
    {
        private readonly IDisciplinaRepo _disciplinaRepo;
        private readonly IMaterialDisciplinaRepo _materialRepo;
        public MaterialDisciplinaService(IMaterialDisciplinaRepo materialRepo, IDisciplinaRepo disciplinaRepo)
        {
            _disciplinaRepo = disciplinaRepo;
            _materialRepo = materialRepo;
        }

        public async Task<MaterialDisciplina> AdicionarMaterial(MaterialDisciplina model)
        {
            // Verifica se já existe um curso com o mesmo nome
            var disciplinasComMesmoNome = await _materialRepo.PegarMaterialPorTudoAsync(titulo: model.Titulo);
            if (disciplinasComMesmoNome.FirstOrDefault() != null)
                throw new InvalidOperationException("Já existe um curso com esse nome.");

            var disciplinasComCurso = await _materialRepo.PegarMaterialPorTudoAsync(idDisciplinasNavigation: model.IdDisciplinasNavigation);
            if (disciplinasComCurso.FirstOrDefault() != null) // se exitir o curso
            {
                // Adiciona o novo curso
                _materialRepo.Adicionar(model);
                if (await _materialRepo.SalvarMudancaAsync())
                    return model;
            }
            throw new Exception("Erro ao salvar o curso.");
        }

        public async Task<MaterialDisciplina> AtualizarMaterial(MaterialDisciplina model)
        {
            if (model.IdDisciplinas <= 0)
                throw new ArgumentException("ID do curso é inválido.");

            // Verifica se o curso existe
            var cursoExistente = await _materialRepo.PegarMaterialPorTudoAsync(idMateria: model.IdMateria);
            var curso = cursoExistente.FirstOrDefault();
            if (curso == null)
                throw new InvalidOperationException("Curso inexistente.");

            // Atualiza o curso
            _materialRepo.Atualizar(model);
            if (await _materialRepo.SalvarMudancaAsync())
                return model;

            throw new Exception("Erro ao atualizar o curso.");
        }

        public async Task<bool> DeletarMaterial(int IdMaterial)
        {
            {
                var disciplinas = await _materialRepo.PegarMaterialPorTudoAsync(idMateria: IdMaterial);
                var curso = disciplinas.FirstOrDefault(); // Obter o primeiro curso encontrado

                if (curso == null) throw new Exception("Curso que tentou deletar não existe");

                _materialRepo.Deletar(curso);
                return await _materialRepo.SalvarMudancaAsync();
            }
        }


        public async Task<MaterialDisciplina[]> PegarMaterialPorTudo(int? idMateria = null, int? modulo = null, string? titulo = null, string? linkVideoaula = null, string? descricao = null, int? idDisciplinas = null, Disciplina? idDisciplinasNavigation = null)
        {
            try
            {
                var curso = await _materialRepo.PegarMaterialPorTudoAsync(idMateria, modulo,titulo, linkVideoaula,descricao,idDisciplinas,idDisciplinasNavigation);
                if (curso == null) return null;

                return curso;
            }
            catch (System.Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<MaterialDisciplina[]> PegarTodosMaterialAsynk()
        {
            try
            {
                var disciplinas = await _materialRepo.PegarTodasAsync();
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
