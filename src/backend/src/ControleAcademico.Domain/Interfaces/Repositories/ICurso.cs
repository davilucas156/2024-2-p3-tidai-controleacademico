using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ControleAcademico.Domain.Entities;
using static ControleAcademico.Domain.Entities.Curso;

namespace ControleAcademico.Domain.Interfaces.Repositories
{
    public interface ICursoRepo : IgeralRepo
    {
        Task<Curso[]> PegarTodasAsync();
        Task<Curso[]> PegarCursoPorTudoAsync(int? id = null, string? nome = null, TiposCurso? tipo = null, Niveis? nivel = null);
    }
}