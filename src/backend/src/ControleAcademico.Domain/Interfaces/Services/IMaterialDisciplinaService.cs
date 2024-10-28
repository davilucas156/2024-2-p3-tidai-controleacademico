using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ControleAcademico.Domain.Entities;
using static ControleAcademico.Domain.Entities.Disciplina;


namespace ControleAcademico.Domain.Interfaces.Services
{
    public interface IMaterialDisciplinaService
    {
        Task<MaterialDisciplina> AdicionarMaterial(MaterialDisciplina model);
        Task<MaterialDisciplina> AtualizarMaterial(MaterialDisciplina model);
        Task<bool> DeletarMaterial(int IdMaterial);
        Task<MaterialDisciplina[]> PegarTodosMaterialAsynk();
        Task<MaterialDisciplina[]> PegarMaterialPorTudo(int? idMateria=null, int? modulo=null, string? titulo=null, string? linkVideoaula=null, string? descricao=null, int? idDisciplinas=null, Disciplina? idDisciplinasNavigation=null);
    }
}