using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ControleAcademico.Domain.Entities;
using ControleAcademico.Domain.Interfaces.Repositories;
using ControleAcademico.Domain.Interfaces.Services;

namespace ControleAcademico.Domain.Services
{
public class TarefaDisciplinaService : ITarefaDisciplinaService
{
    private readonly IDisciplinaRepo _disciplinaRepo;
    private readonly ITarefasDisciplinaRepo _tarefaRepo;

    public TarefaDisciplinaService(ITarefasDisciplinaRepo tarefaRepo, IDisciplinaRepo disciplinaRepo)
    {
        _disciplinaRepo = disciplinaRepo;
        _tarefaRepo = tarefaRepo;
    }

    public async Task<TarefasDisciplina> AdicionarTarefa(TarefasDisciplina model)
    {
        var tarefasComMesmoTitulo = await _tarefaRepo.PegarTarefaPorTudoAsync(titulo: model.Titulo);
        if (tarefasComMesmoTitulo.FirstOrDefault() != null)
            throw new InvalidOperationException("Já existe uma tarefa com esse título.");

        var disciplinaExistente = await _disciplinaRepo.PegarDisciplinaPorTudoAsync(id: model.IdDisciplinas);
        if (disciplinaExistente.FirstOrDefault() == null)
            throw new InvalidOperationException("Disciplina inexistente.");

        _tarefaRepo.Adicionar(model);
        if (await _tarefaRepo.SalvarMudancaAsync())
            return model;

        throw new Exception("Erro ao salvar a tarefa.");
    }

    public async Task<TarefasDisciplina> AtualizarTarefa(TarefasDisciplina model)
    {
        if (model.IdTarefa <= 0)
            throw new ArgumentException("ID do material é inválido.");

        var materialExistente = await _tarefaRepo.PegarTarefaPorTudoAsync(idTarefa: model.IdTarefa);
        if (materialExistente.FirstOrDefault() == null)
            throw new InvalidOperationException("Material inexistente.");

        _tarefaRepo.Atualizar(model);
        if (await _tarefaRepo.SalvarMudancaAsync())
            return model;

        throw new Exception("Erro ao atualizar o material.");
    }

    public async Task<bool> DeletarTarefa(int IdTarefa)
    {
        var tarefas = await _tarefaRepo.PegarTarefaPorTudoAsync(idTarefa: IdTarefa);
        var tarefa = tarefas.FirstOrDefault();

        if (tarefa == null) 
            throw new Exception("Tarefa que tentou deletar não existe");

        _tarefaRepo.Deletar(tarefa);
        return await _tarefaRepo.SalvarMudancaAsync();
    }

    public async Task<TarefasDisciplina[]> PegarTarefaPorTudo(int? idTarefa = null, string? modulo = null, string? titulo = null, int? valor = null, DateOnly? dataEntrega = null, string? linkArquivoTarefa = null, int? idDisciplinas = null)
    {
        try
        {
            var tarefas = await _tarefaRepo.PegarTarefaPorTudoAsync(idTarefa, modulo, titulo, valor, dataEntrega, linkArquivoTarefa, idDisciplinas);
            return tarefas ?? Array.Empty<TarefasDisciplina>(); // Retorna uma lista vazia se for nulo
        }
        catch (Exception ex)
        {
            throw new Exception($"Erro ao processar a requisição: {ex.Message}");
        }
    }

    public async Task<TarefasDisciplina[]> PegarTodosTarefaAsynk()
    {
        try
        {
            var tarefas = await _tarefaRepo.PegarTodasAsync();
            return tarefas ?? Array.Empty<TarefasDisciplina>(); // Retorna uma lista vazia se for nulo
        }
        catch (Exception ex)
        {
            throw new Exception($"Erro ao processar a requisição: {ex.Message}");
        }
    }
}

}