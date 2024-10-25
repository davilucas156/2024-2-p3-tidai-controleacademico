using System;
using System.Collections.Generic;

namespace ControleAcademico.API.Model;

public partial class MaterialDisciplina
{
    public string IdMateria { get; set; } = null!;

    public int? Modulo { get; set; }

    public string? Titulo { get; set; }

    public string? LinkVideoaula { get; set; }

    public int? Descricao { get; set; }

    public int IdDisciplinas { get; set; }

    public virtual Disciplina IdDisciplinasNavigation { get; set; } = null!;
}
