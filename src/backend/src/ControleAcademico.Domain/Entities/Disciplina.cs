using System;
using System.Collections.Generic;

namespace ControleAcademico.Domain.Entities;
public partial class Disciplina
{
    public int IdDisciplinas { get; set; }
    public string? Nome { get; set; }
    public int? Semestre { get; set; }
    public int IdCurso { get; set; }

    public virtual Curso? IdCursoNavigation { get; set; } = null!;
    
    public virtual ICollection<DisciplinasUsuario> DisciplinasUsuarios { get; set; } = new HashSet<DisciplinasUsuario>();
    public virtual ICollection<MaterialDisciplina> MaterialDisciplinas { get; set; } = new List<MaterialDisciplina>();
    public virtual ICollection<TarefasDisciplina> TarefasDisciplinas { get; set; } = new List<TarefasDisciplina>();
}
