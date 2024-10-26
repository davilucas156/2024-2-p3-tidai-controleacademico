using System;
using System.Collections.Generic;

namespace ControleAcademico.Domain.Entities;

public partial class Curso
{
    public int IdCursos { get; set; }

    public string? Nome { get; set; }

    public Niveis Nivel { get; set; }

    public Tipos Tipo { get; set; }

    public virtual ICollection<Disciplina> Disciplinas { get; set; } = new List<Disciplina>();

    public virtual ICollection<Usuario> Usuarios { get; set; } = new List<Usuario>();

    // Construtor padrão
    public Curso() { }


    // Construtor com parâmetros
    public Curso(string? nome, Niveis nivel, Tipos tipo)
    {
        Nome = nome;
        Nivel = nivel;
        Tipo = tipo;
        Disciplinas = new List<Disciplina>(); // Inicializa a coleção
        Usuarios = new List<Usuario>();       // Inicializa a coleção
    }

    public enum Tipos
    {
        Presencial,
        Ead,
        Misto,
        
    }
    public enum Niveis
    {
        Graduação,
        PósGraduação,
        Doutorado,
        Mestrado,
    }
}
