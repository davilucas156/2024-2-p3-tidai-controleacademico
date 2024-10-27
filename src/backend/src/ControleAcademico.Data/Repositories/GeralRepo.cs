using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ControleAcademico.Data.Context;
using ControleAcademico.Domain.Interfaces.Repositories;

namespace ControleAcademico.Data.Repositories
{
    public class GeralRepo : IgeralRepo
    {
        private readonly ControleAcademicoContext _context;
        public GeralRepo(ControleAcademicoContext context)
        {
            _context = context;
        }
    
        public void Adicionar<T>(T entity) where T : class
        {
            _context.Add(entity);
        }

        public void Atualizar<T>(T entity) where T : class
        {
            _context.Update(entity);
        }

        public void Deletar<T>(T entity) where T : class
        {
            _context.Remove(entity);
        }

        public void DeletarVárias<T>(T[] entityArray) where T : class
        {
            _context.RemoveRange(entityArray);
        }

        public async Task<bool> SalvarMudancaAsync()
        {
            return (await _context.SaveChangesAsync()) > 0;
        }
    }
}