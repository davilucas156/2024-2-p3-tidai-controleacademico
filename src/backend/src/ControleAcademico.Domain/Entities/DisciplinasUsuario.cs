using System;
using System.Collections.Generic;

namespace ControleAcademico.Domain.Entities;
public partial class DisciplinasUsuario
{
    public int Matricula { get; set; }

    public int IdDisciplinas { get; set; }

    public virtual Disciplina IdDisciplinasNavigation { get; set; } = null!;

    public virtual Usuario MatriculaNavigation { get; set; } = null!;

    // Construtor
        public DisciplinasUsuario(int matricula, int idDisciplinas)
        {
            Matricula = matricula;
            IdDisciplinas = idDisciplinas;
        }

        // Construtor padrão (opcional)
        public DisciplinasUsuario() { }
}
