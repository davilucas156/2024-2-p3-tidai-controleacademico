using System;
using System.Collections.Generic;

namespace ControleAcademico.API.Model;

public partial class NotasTarefa
{
    public int Nota { get; set; }

    public int Matricula { get; set; }

    public int IdTarefa { get; set; }

    public virtual TarefasDisciplina IdTarefaNavigation { get; set; } = null!;

    public virtual Usuario MatriculaNavigation { get; set; } = null!;
}
