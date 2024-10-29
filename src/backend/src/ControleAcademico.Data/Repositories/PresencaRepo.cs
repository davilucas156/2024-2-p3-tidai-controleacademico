using System;
using System.Linq;
using System.Threading.Tasks;
using ControleAcademico.Data.Context;
using ControleAcademico.Domain.Entities;
using ControleAcademico.Domain.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;
using static ControleAcademico.Domain.Entities.Presenca;

namespace ControleAcademico.Data.Repositories
{
    public class PresencaRepo : GeralRepo, IPresencaRepo
    {
        private readonly ControleAcademicoContext _context;

        public PresencaRepo(ControleAcademicoContext context) : base(context)
        {
            _context = context;
        }

        // Método para buscar presenças com base nos parâmetros fornecidos
        public async Task<Presenca[]> PegarPresencaPorTudoAsync(DateOnly? data = null, Presença? presenca = null, int? idDisciplinasUsuario = null)
        {
            IQueryable<Presenca> query = _context.Presencas.AsNoTracking();

            // Aplicando filtros dinamicamente
            if (data.HasValue)
                query = query.Where(p => p.Data == data.Value);

            if (presenca.HasValue)
                query = query.Where(p => p.Presenca1 == presenca.Value);

            if (idDisciplinasUsuario.HasValue)
                query = query.Where(p => p.IdDisciplinasUsuario == idDisciplinasUsuario.Value);

            return await query.ToArrayAsync();
        }

        // Método para pegar todas as presenças
        public async Task<Presenca[]> PegarTodasAsync()
        {
            return await _context.Presencas.AsNoTracking().ToArrayAsync();
        }
    }
}
