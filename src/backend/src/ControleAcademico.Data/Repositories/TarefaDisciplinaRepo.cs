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
    public class TarefaDisciplinaRepo : GeralRepo, ITarefasDisciplinaRepo
    {
        private readonly ControleAcademicoContext _context;
        public TarefaDisciplinaRepo(ControleAcademicoContext context) : base (context)
        {
            _context = context;
        }

        public async Task<TarefasDisciplina[]> PegarTarefaPorTudoAsync(int? idTarefa = null, string? modulo = null, string? titulo = null, int? valor = null, DateOnly? dataEntrega = null, string? linkArquivoTarefa = null, int? idDisciplinas = null)
        {
            IQueryable<TarefasDisciplina> query = _context.TarefasDisciplinas.AsNoTracking().OrderBy(ativ => ativ.IdDisciplinas);

            // Aplica os filtros dinamicamente
            if (idTarefa.HasValue)
                query = query.Where(tarefa => tarefa.IdTarefa == idTarefa.Value);

            if (!string.IsNullOrWhiteSpace(modulo))
                query = query.Where(tarefa => tarefa.Modulo == modulo);

            if (!string.IsNullOrWhiteSpace(titulo))
                query = query.Where(tarefa => tarefa.Titulo == titulo);

            if (valor.HasValue)
                query = query.Where(tarefa => tarefa.Valor == valor.Value);

            if (dataEntrega.HasValue)
                query = query.Where(tarefa => tarefa.DataEntrega == dataEntrega.Value);

            if (!string.IsNullOrWhiteSpace(linkArquivoTarefa))
                query = query.Where(tarefa => tarefa.LinkArquivoTarefa == linkArquivoTarefa);

            if (idDisciplinas.HasValue)
                query = query.Where(tarefa => tarefa.IdDisciplinas == idDisciplinas.Value);

            // Ordena o resultado, se necessário
            query = query.OrderBy(tarefa => tarefa.IdDisciplinas);

            return await query.ToArrayAsync();
        }


        async Task<TarefasDisciplina[]> ITarefasDisciplinaRepo.PegarTodasAsync()
        {
            IQueryable<TarefasDisciplina> query = _context.TarefasDisciplinas;

            query = query
                        .AsNoTracking()
                        .OrderBy(ativ => ativ.IdTarefa);

            return await query.ToArrayAsync();
        }
    }
}