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
public class MaterialDisciplinaService : IMaterialDisciplinaService
{
    private readonly IDisciplinaRepo _disciplinaRepo;
    private readonly IMaterialDisciplinaRepo _materialRepo;

    public MaterialDisciplinaService(IMaterialDisciplinaRepo materialRepo, IDisciplinaRepo disciplinaRepo)
    {
        _disciplinaRepo = disciplinaRepo;
        _materialRepo = materialRepo;
    }

    public async Task<MaterialDisciplina> AdicionarMaterial(MaterialDisciplina model)
    {
        var materiaisComMesmoTitulo = await _materialRepo.PegarMaterialPorTudoAsync(titulo: model.Titulo);
        if (materiaisComMesmoTitulo.FirstOrDefault() != null)
            throw new InvalidOperationException("Já existe um material com esse título.");

        // Verifica se a disciplina existe
        var disciplinaExistente = await _disciplinaRepo.PegarDisciplinaPorTudoAsync(id: model.IdDisciplinas);
        if (disciplinaExistente == null)
            throw new InvalidOperationException("Disciplina inexistente.");

        _materialRepo.Adicionar(model);
        if (await _materialRepo.SalvarMudancaAsync())
            return model;

        throw new Exception("Erro ao salvar o material.");
    }

    public async Task<MaterialDisciplina> AtualizarMaterial(MaterialDisciplina model)
    {
        if (model.IdMateria <= 0)
            throw new ArgumentException("ID do material é inválido.");

        var materialExistente = await _materialRepo.PegarMaterialPorTudoAsync(idMateria: model.IdMateria);
        if (materialExistente.FirstOrDefault() == null)
            throw new InvalidOperationException("Material inexistente.");

        _materialRepo.Atualizar(model);
        if (await _materialRepo.SalvarMudancaAsync())
            return model;

        throw new Exception("Erro ao atualizar o material.");
    }

    public async Task<bool> DeletarMaterial(int IdMaterial)
    {
        var materiais = await _materialRepo.PegarMaterialPorTudoAsync(idMateria: IdMaterial);
        var material = materiais.FirstOrDefault();

        if (material == null) throw new Exception("Material que tentou deletar não existe");

        _materialRepo.Deletar(material);
        return await _materialRepo.SalvarMudancaAsync();
    }

    public async Task<MaterialDisciplina[]> PegarMaterialPorTudo(int? idMateria = null, int? modulo = null, string? titulo = null, string? linkVideoaula = null, string? descricao = null, int? idDisciplinas = null, Disciplina? idDisciplinasNavigation = null)
    {
        try
        {
            var materiais = await _materialRepo.PegarMaterialPorTudoAsync(idMateria, modulo, titulo, linkVideoaula, descricao, idDisciplinas, idDisciplinasNavigation);
            return materiais ?? Array.Empty<MaterialDisciplina>(); // Retorna uma lista vazia se for nulo
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }

    public async Task<MaterialDisciplina[]> PegarTodosMaterialAsynk()
    {
        try
        {
            var materiais = await _materialRepo.PegarTodasAsync();
            return materiais ?? Array.Empty<MaterialDisciplina>(); // Retorna uma lista vazia se for nulo
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }
}

}
