using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ControleAcademico.Domain.Interfaces.Repositories
{
    public interface IgeralRepo
    {
        void Adicionar<T>(T entity) where T : class;        
        void Atualizar<T>(T entity) where T : class;        
        void Deletar<T>(T entity) where T : class;        
        void DeletarVárias<T>(T[] entity) where T : class;      

        Task<bool> SalvarMudançaAsync();
  
    }
}