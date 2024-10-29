using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ControleAcademico.Domain.Entities;
using static ControleAcademico.Domain.Entities.Disciplina;
using static ControleAcademico.Domain.Entities.Presenca;


namespace ControleAcademico.Domain.Interfaces.Services
{
    public interface IPresencaService
    {
        Task<Presenca> AdicionarPresenca(Presenca model);
        Task<Presenca> AtualizarPresenca(Presenca model);
        Task<bool> DeletarPresenca(int IdPresenca);
        Task<Presenca[]> PegarTodosPresencaAsynk();
        Task<Presenca[]> PegarPresencaPorTudo(DateOnly? data=null, Presença? presenca=null, int? idDisciplinasUsuario=null);
    }
}