using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ControleAcademico.Domain.Entities;

namespace ControleAcademico.Domain.Interfaces.Repositories
{
    public interface ICurso
    {
        Task<Curso[]> PegaTodasAsync();
        Task<Curso> PegaPorIdAsync();
        Task<Curso> PegaPorNomeAsync();
    }
}