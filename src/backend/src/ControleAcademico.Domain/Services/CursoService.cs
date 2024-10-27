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
    public class CursoService : ICursoService
    {
        private readonly ICursoRepo _cursoRepo;
        public CursoService(ICursoRepo cursoRepo)
        {
            this._cursoRepo = cursoRepo;
        }
        public async Task<Curso> AdicionarCurso(Curso model)
        {
            // Verifica se já existe um curso com o mesmo nome
            var cursosComMesmoNome = await _cursoRepo.PegarCursoPorTudoAsync(nome: model.Nome);
            if (cursosComMesmoNome.FirstOrDefault() != null)
                throw new InvalidOperationException("Já existe um curso com esse nome.");

            // Adiciona o novo curso
            _cursoRepo.Adicionar(model);
            if (await _cursoRepo.SalvarMudancaAsync())
                return model;

            throw new Exception("Erro ao salvar o curso.");
        }


        public async Task<Curso> AtualizarCurso(Curso model)
        {
            if (model.IdCursos <= 0)
                throw new ArgumentException("ID do curso é inválido.");

            // Verifica se o curso existe
            var cursoExistente = await _cursoRepo.PegarCursoPorTudoAsync(id: model.IdCursos);
            var curso = cursoExistente.FirstOrDefault();
            if (curso == null)
                throw new InvalidOperationException("Curso inexistente.");

            // Atualiza o curso
            _cursoRepo.Atualizar(model);
            if (await _cursoRepo.SalvarMudancaAsync())
                return model;

            throw new Exception("Erro ao atualizar o curso.");
        }


        public async Task<bool> DeletarCurso(int cursoId)
        {
            var cursos = await _cursoRepo.PegarCursoPorTudoAsync(id: cursoId);
            var curso = cursos.FirstOrDefault(); // Obter o primeiro curso encontrado

            if (curso == null) throw new Exception("Curso que tentou deletar não existe");

            _cursoRepo.Deletar(curso);
            return await _cursoRepo.SalvarMudancaAsync();
        }

        public async Task<Curso[]> PegarTodosCursoAsynk()
        {
            try
            {
                var cursos = await _cursoRepo.PegarTodasAsync();
                if (cursos == null) return null;

                return cursos;
            }
            catch (System.Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<Curso[]> PegarCursoPorTudo(int? id = null, string? nome = null, TiposCurso? tipo = null, Niveis? nivel = null)
        {
            try
            {
                var curso = await _cursoRepo.PegarCursoPorTudoAsync(id, nome,tipo, nivel);
                if (curso == null) return null;

                return curso;
            }
            catch (System.Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
