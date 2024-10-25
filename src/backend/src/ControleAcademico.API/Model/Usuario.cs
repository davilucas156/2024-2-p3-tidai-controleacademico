using System;
using System.Collections.Generic;

namespace ControleAcademico.API.Model;

public partial class Usuario
{
    public int Matricula { get; set; }

    public string? Nome { get; set; }

    public string? Cpf { get; set; }

    public string? Email { get; set; }

    public string? Endereco { get; set; }

    public int? Tipo { get; set; }

    public string? Senha { get; set; }

    public int IdCurso { get; set; }

    public virtual Curso IdCursoNavigation { get; set; } = null!;

    public virtual ICollection<NotasTarefa> NotasTarefas { get; set; } = new List<NotasTarefa>();
}
