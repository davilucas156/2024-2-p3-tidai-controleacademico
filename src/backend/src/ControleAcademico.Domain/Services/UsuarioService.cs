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
    public class UsuarioService : IUsuarioService
        {
        private readonly IUsuarioRepo _UsuarioRepo;

        public UsuarioService(IUsuarioRepo UsuarioRepo) // Atualize o construtor
        {
            this._UsuarioRepo = UsuarioRepo;
        }

        public async Task<Usuario> AdicionarUsuario(Usuario model)
        {
            // Verifica se já existe um curso com o mesmo nome
            var cursosComMesmoNome = await _UsuarioRepo.PegarUsuarioPorTudoAsync(nome: model.Nome);
            if (cursosComMesmoNome.FirstOrDefault() != null)
                throw new InvalidOperationException("Já existe um curso com esse nome.");

            // Adiciona o novo curso
            _UsuarioRepo.Adicionar(model);

            if (await _UsuarioRepo.SalvarMudancaAsync())
                return model;

            throw new Exception("Erro ao salvar o curso.");
        }

        public async Task<Usuario> AtualizarUsuario(Usuario model)
        {
            if (model.Matricula <= 0)
                throw new ArgumentException("ID do curso é inválido.");

            // Verifica se o curso existe
            var cursoExistente = await _UsuarioRepo.PegarUsuarioPorTudoAsync(matricula: model.Matricula);
            var curso = cursoExistente.FirstOrDefault();
            if (curso == null)
                throw new InvalidOperationException("Curso inexistente.");

            // Atualiza o curso
            _UsuarioRepo.Atualizar(model);
            if (await _UsuarioRepo.SalvarMudancaAsync())
                return model;

            throw new Exception("Erro ao atualizar o curso.");
        }

        public async Task<bool> DeletarUsuario(int Matricula)
        {
            {
                var disciplinas = await _UsuarioRepo.PegarUsuarioPorTudoAsync(matricula: Matricula);
                var curso = disciplinas.FirstOrDefault(); // Obter o primeiro curso encontrado

                if (curso == null) throw new Exception("Curso que tentou deletar não existe");

                _UsuarioRepo.Deletar(curso);
                return await _UsuarioRepo.SalvarMudancaAsync();
            }
        }

        public async Task<Usuario[]> PegarTodosUsuarioAsynk()
        {
            try
            {
                var cursos = await _UsuarioRepo.PegarTodasAsync();
                if (cursos == null) return null;

                return cursos;
            }
            catch (System.Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<Usuario[]> PegarUsuarioPorTudo(int? matricula = null, string? nome = null, string? cpf = null, string? email = null, string? endereco = null, Usuario.Tipos? tipo = null, string? senha = null, int? idCurso = null, Curso? idCursoNavigation = null)
        {
            try
            {
                var curso = await _UsuarioRepo.PegarUsuarioPorTudoAsync(matricula, nome,cpf,email,endereco,tipo,senha, idCurso,idCursoNavigation);
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
