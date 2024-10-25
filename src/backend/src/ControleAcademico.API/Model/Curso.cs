using System;
using System.Collections.Generic;

namespace ControleAcademico.API.Model;

public partial class Curso
{
    public int IdCursos { get; set; }

    public string? Nome { get; set; }

    public int? Nivel { get; set; }

    public int? Tipo { get; set; }

    public virtual ICollection<Disciplina> Disciplinas { get; set; } = new List<Disciplina>();

    public virtual ICollection<Usuario> Usuarios { get; set; } = new List<Usuario>();
}
