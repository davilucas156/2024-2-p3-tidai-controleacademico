using System;
using System.Linq;
using System.Threading.Tasks;
using ControleAcademico.Data.Context;
using ControleAcademico.Domain.Entities;
using ControleAcademico.Domain.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;

namespace ControleAcademico.Data.Repositories
{
    public class RelacionamentoRepo : GeralRepo, IRelacionamentoUsuarioDisciplinaRepo
    {
        private readonly ControleAcademicoContext _context;

        public RelacionamentoRepo(ControleAcademicoContext context) : base(context)
        {
            _context = context;
        }

        // Método para buscar relacionamentos com base nos parâmetros fornecidos
        public async Task<DisciplinasUsuario[]> PegarRelacionamentoPorTudoAsync(int? matricula = null, int? idDisciplinas = null)
        {
            IQueryable<DisciplinasUsuario> query = _context.DisciplinasUsuarios.AsNoTracking();

            // Aplicando filtros dinamicamente
            if (matricula.HasValue)
                query = query.Where(r => r.Matricula == matricula.Value);

            if (idDisciplinas.HasValue)
                query = query.Where(r => r.IdDisciplinas == idDisciplinas.Value);

            return await query.ToArrayAsync();
        }

        // Método para pegar todos os relacionamentos
        public async Task<DisciplinasUsuario[]> PegarTodasAsync()
        {
            return await _context.DisciplinasUsuarios.AsNoTracking().ToArrayAsync();
        }
    }
}
