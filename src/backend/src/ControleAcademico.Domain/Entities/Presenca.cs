using System;
using System.Collections.Generic;

namespace ControleAcademico.Domain.Entities;
public partial class Presenca
{
    public int IdPresenca {get;set;}
    public DateOnly? Data { get; set; }
    public Presença? Presenca1 { get; set; }
    public int IdDisciplinasUsuario { get; set; }
    public enum Presença
    {
        Falta,
        Presença,
    }
}
