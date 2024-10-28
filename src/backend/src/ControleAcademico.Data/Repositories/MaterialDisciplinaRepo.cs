using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ControleAcademico.Data.Context;
using ControleAcademico.Domain.Entities;
using ControleAcademico.Domain.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;
using static ControleAcademico.Domain.Entities.Disciplina;

namespace ControleAcademico.Data.Repositories
{
    public class MaterialDisciplinaRepo : GeralRepo, IMaterialDisciplinaRepo
    {
        private readonly ControleAcademicoContext _context;
        public MaterialDisciplinaRepo(ControleAcademicoContext context) : base (context)
        {
            _context = context;
        }

        public async Task<MaterialDisciplina[]> PegarMaterialPorTudoAsync(int? idMateria = null, int? modulo = null, string? titulo = null, string? linkVideoaula = null, string? descricao = null, int? idDisciplinas = null, Disciplina? idDisciplinasNavigation = null)
        {
            IQueryable<MaterialDisciplina> query = _context.MaterialDisciplinas.AsNoTracking().OrderBy(ativ => ativ.IdMateria);

            // Aplica os filtros dinamicamente
                if (idMateria.HasValue)
                    query = query.Where(material => material.IdMateria == idMateria.Value);

                if (modulo.HasValue)
                    query = query.Where(material => material.Modulo == modulo.Value);

                if (!string.IsNullOrWhiteSpace(titulo))
                    query = query.Where(material => material.Titulo == titulo);

                if (!string.IsNullOrWhiteSpace(linkVideoaula))
                    query = query.Where(material => material.LinkVideoaula == linkVideoaula);

                if (!string.IsNullOrWhiteSpace(descricao))
                    query = query.Where(material => material.Descricao == descricao);

                if (idDisciplinas.HasValue)
                    query = query.Where(material => material.IdDisciplinas == idDisciplinas.Value);

                if (idDisciplinasNavigation != null)
                    query = query.Where(material => material.IdDisciplinasNavigation == idDisciplinasNavigation);

                return await query.ToArrayAsync();
        }

        public async Task<MaterialDisciplina[]> PegarTodasAsync()
        {
            IQueryable<MaterialDisciplina> query = _context.MaterialDisciplinas;

            query = query
                        .AsNoTracking()
                        .OrderBy(ativ => ativ.IdMateria);

            return await query.ToArrayAsync();
        }
    }
}