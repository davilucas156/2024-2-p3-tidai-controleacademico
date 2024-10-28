using System;
using System.Collections.Generic;

namespace ControleAcademico.Domain.Entities;
public partial class MaterialDisciplina
{
    public int IdMateria { get; set; }

    public int? Modulo { get; set; }

    public string? Titulo { get; set; }

    public string? LinkVideoaula { get; set; }

    public string? Descricao { get; set; }

    public int IdDisciplinas { get; set; }

    public virtual Disciplina IdDisciplinasNavigation { get; set; } = null!;
        // Construtor sem parâmetros
        public MaterialDisciplina() { }

        // Construtor com todos os parâmetros
        public MaterialDisciplina(int idMateria, int? modulo, string? titulo, string? linkVideoaula, string? descricao, int idDisciplinas, Disciplina idDisciplinasNavigation)
        {
            IdMateria = idMateria;
            Modulo = modulo;
            Titulo = titulo;
            LinkVideoaula = linkVideoaula;
            Descricao = descricao;
            IdDisciplinas = idDisciplinas;
            IdDisciplinasNavigation = idDisciplinasNavigation;
        }
}