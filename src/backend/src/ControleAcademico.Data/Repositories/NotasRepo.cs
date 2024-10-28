using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ControleAcademico.Data.Context;
using ControleAcademico.Domain.Entities;
using ControleAcademico.Domain.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;

namespace ControleAcademico.Data.Repositories
{
    public class NotasTarefasRepo : GeralRepo, INotasTarefasRepo
    {
        private readonly ControleAcademicoContext _context;

        public NotasTarefasRepo(ControleAcademicoContext context) : base(context)
        {
            _context = context;
        }

        // Método para buscar notas de tarefas com base nos parâmetros fornecidos
        public async Task<NotasTarefa[]> PegarTarefasPorTudoAsync(int? nota = null, int? matricula = null, int? idTarefa = null)
        {
            IQueryable<NotasTarefa> query = _context.NotasTarefas.AsNoTracking();

            // Aplicando filtros dinamicamente
            if (nota.HasValue)
                query = query.Where(nt => nt.Nota == nota.Value);

            if (matricula.HasValue)
                query = query.Where(nt => nt.Matricula == matricula.Value);

            if (idTarefa.HasValue)
                query = query.Where(nt => nt.IdTarefa == idTarefa.Value);

            return await query.ToArrayAsync();
        }

        // Método para pegar todas as notas de tarefas
        public async Task<NotasTarefa[]> PegarTodasAsync()
        {
            return await _context.NotasTarefas.AsNoTracking().ToArrayAsync();
        }
    }
}
