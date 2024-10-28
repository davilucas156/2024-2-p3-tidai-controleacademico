using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ControleAcademico.Domain.Entities;
using ControleAcademico.Domain.Interfaces.Repositories;
using ControleAcademico.Domain.Interfaces.Services;
using static ControleAcademico.Domain.Entities.Curso;

namespace ControleAcademico.Domain.Services
{
    public class PresencaService : IPresencaService
        {
        private readonly IPresencaRepo _PresencaRepo;

        public PresencaService(IPresencaRepo PresencaRepo) 
        {
            _PresencaRepo = PresencaRepo;
        }

        public async Task<Presenca> AdicionarPresenca(Presenca model)
        {
            // Adiciona o novo curso
            _PresencaRepo.Adicionar(model);

            if (await _PresencaRepo.SalvarMudancaAsync())
                return model;

            throw new Exception("Erro ao salvar o curso.");
        }

        public async Task<Presenca> AtualizarPresenca(Presenca model)
        {


            // Atualiza o curso
            _PresencaRepo.Atualizar(model);
            if (await _PresencaRepo.SalvarMudancaAsync())
                return model;

            throw new Exception("Erro ao atualizar o curso.");
        }


        public async Task<bool> DeletarPresenca(int IdPresenca)
        {
            {
                //var disciplinas = await _PresencaRepo.PegarTarefasPorTudoAsync(idTarefa: IdNotas);
                //var curso = disciplinas.FirstOrDefault(); // Obter o primeiro curso encontrado

                //if (curso == null) throw new Exception("Curso que tentou deletar não existe");

                //_PresencaRepo.Deletar(curso);
                //return await _PresencaRepo.SalvarMudancaAsync();
                return false;
            }
        }


        public async Task<Presenca[]> PegarPresencaPorTudo(DateOnly? data = null, int? presenca = null, int? idDisciplinasUsuario = null)
        {

            try
            {
                var curso = await _PresencaRepo.PegarPresencaPorTudoAsync(data, presenca,idDisciplinasUsuario);
                if (curso == null) return null;

                return curso;
            }
            catch (System.Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }


        public async Task<Presenca[]> PegarTodosPresencaAsynk()
        {
            try
            {
                var cursos = await _PresencaRepo.PegarTodasAsync();
                if (cursos == null) return null;

                return cursos;
            }
            catch (System.Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
