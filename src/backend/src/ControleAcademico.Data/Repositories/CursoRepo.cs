using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ControleAcademico.Data.Context;
using ControleAcademico.Domain.Entities;
using ControleAcademico.Domain.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;
using static ControleAcademico.Domain.Entities.Curso;

namespace ControleAcademico.Data.Repositories
{
    public class CursoRepo : GeralRepo, ICursoRepo
    {
        private readonly ControleAcademicoContext _context;
        public CursoRepo(ControleAcademicoContext context) : base (context)
        {
            _context = context;
        }

        public async Task<Curso[]> PegarTodasAsync()
        {
            IQueryable<Curso> query = _context.Cursos;

            query = query
                        .AsNoTracking()
                        .Include(c => c.Disciplinas)
                        .OrderBy(ativ => ativ.IdCursos);

            return await query.ToArrayAsync();
        }

        public async Task<Curso[]>  PegarCursoPorTudoAsync(int? id = null, string? nome = null, TiposCurso? tipo = null, Niveis? nivel = null)
        {
            IQueryable<Curso> query = _context.Cursos.AsNoTracking().OrderBy(curso => curso.IdCursos);

            // Aplica os filtros dinamicamente
            if (id.HasValue)
                query = query.Where(curso => curso.IdCursos == id.Value);

            if (!string.IsNullOrWhiteSpace(nome))
                query = query.Where(curso => curso.Nome == nome);

            if (tipo.HasValue)
                query = query.Where(curso => curso.Tipo == tipo.Value);

            if (nivel.HasValue)
                query = query.Where(curso => curso.Nivel == nivel.Value);

            return await query.ToArrayAsync();
        }
    }
}