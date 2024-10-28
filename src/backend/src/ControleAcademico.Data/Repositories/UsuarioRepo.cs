using System;
using System.Linq;
using System.Threading.Tasks;
using ControleAcademico.Data.Context;
using ControleAcademico.Domain.Entities;
using ControleAcademico.Domain.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;

namespace ControleAcademico.Data.Repositories
{
    public class UsuarioRepo : GeralRepo, IUsuarioRepo
    {
        private readonly ControleAcademicoContext _context;

        public UsuarioRepo(ControleAcademicoContext context) : base(context)
        {
            _context = context;
        }

        // Método para obter todos os usuários
        public async Task<Usuario[]> PegarTodasAsync()
        {
            return await _context.Usuarios.AsNoTracking().ToArrayAsync();
        }

        // Método para buscar usuários com base nos parâmetros fornecidos
        public async Task<Usuario[]> PegarUsuarioPorTudoAsync(int? matricula = null, string? nome = null, string? cpf = null, string? email = null, string? endereco = null, Usuario.Tipos? tipo = null, string? senha = null, int? idCurso = null, Curso? idCursoNavigation = null)
        {
            IQueryable<Usuario> query = _context.Usuarios.AsNoTracking();

            // Aplicando filtros dinamicamente
            if (matricula.HasValue)
                query = query.Where(u => u.Matricula == matricula.Value);

            if (!string.IsNullOrWhiteSpace(nome))
                query = query.Where(u => u.Nome.Contains(nome));

            if (!string.IsNullOrWhiteSpace(cpf))
                query = query.Where(u => u.Cpf == cpf);

            if (!string.IsNullOrWhiteSpace(email))
                query = query.Where(u => u.Email == email);

            if (!string.IsNullOrWhiteSpace(endereco))
                query = query.Where(u => u.Endereco.Contains(endereco));

            if (tipo.HasValue)
                query = query.Where(u => u.Tipo == tipo.Value);

            if (!string.IsNullOrWhiteSpace(senha))
                query = query.Where(u => u.Senha == senha);

            if (idCurso.HasValue)
                query = query.Where(u => u.IdCurso == idCurso.Value);

            if (idCursoNavigation != null)
                query = query.Include(u => u.IdCursoNavigation).Where(u => u.IdCursoNavigation == idCursoNavigation);

            return await query.ToArrayAsync();
        }
    }
}
