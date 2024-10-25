using System;
using System.Collections.Generic;

namespace ControleAcademico.API.Model;

public partial class Presenca
{
    public DateOnly? Data { get; set; }

    public int? Presenca1 { get; set; }

    public int IdDisciplinasUsuario { get; set; }
}
