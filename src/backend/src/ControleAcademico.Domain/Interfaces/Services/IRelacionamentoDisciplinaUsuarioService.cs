using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ControleAcademico.Domain.Entities;
using static ControleAcademico.Domain.Entities.Disciplina;


namespace ControleAcademico.Domain.Interfaces.Services
{
    public interface IRelacionamentoUsuarioDisciplinaService
    {
        Task<DisciplinasUsuario> AdicionarRelacionamento(DisciplinasUsuario model);
        Task<DisciplinasUsuario> AtualizarRelacionamento(DisciplinasUsuario model);
        Task<bool> DeletarRelacionamento(int IdRelacionamento);
        Task<DisciplinasUsuario[]> PegarTodosRelacionamentoAsynk();
        Task<DisciplinasUsuario[]> PegarRelacionamentoPorTudo(int? matricula=null, int? idDisciplinas=null);
    }
}