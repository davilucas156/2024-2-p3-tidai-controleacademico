using System;
using System.Collections.Generic;

namespace ControleAcademico.Domain.Entities;
public partial class Usuario
{
    public int Matricula { get; set; }

    public string? Nome { get; set; }

    public string? Cpf { get; set; }

    public string? Email { get; set; }

    public string? Endereco { get; set; }

    public Tipos Tipo { get; set; }

    public string? Senha { get; set; }

    public int IdCurso { get; set; }

    public virtual Curso IdCursoNavigation { get; set; } = null!;

    public virtual ICollection<NotasTarefa> NotasTarefas { get; set; } = new List<NotasTarefa>();

    public Usuario() { }

    public Usuario(int matricula, string? nome, string? cpf, string? email, string? endereco, Tipos tipo, string? senha, int idCurso, Curso idCursoNavigation)
    {
        Matricula = matricula;
        Nome = nome;
        Cpf = cpf;
        Email = email;
        Endereco = endereco;
        Tipo = tipo;
        Senha = senha;
        IdCurso = idCurso;
        IdCursoNavigation = idCursoNavigation;
        NotasTarefas = new List<NotasTarefa>(); // Inicializa a coleção
    }

    public enum Tipos
    {
        Aluno,
        Professor,
        Secretário
    }
}


