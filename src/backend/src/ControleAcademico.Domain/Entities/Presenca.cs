using System;
using System.Collections.Generic;

namespace ControleAcademico.Domain.Entities;
public partial class Presenca
{
    public DateOnly? Data { get; set; }

    public int? Presenca1 { get; set; }

    public int IdDisciplinasUsuario { get; set; }

            // Construtor
        public Presenca(DateOnly? data, int? presenca, int idDisciplinasUsuario)
        {
            Data = data;
            Presenca1 = presenca;
            IdDisciplinasUsuario = idDisciplinasUsuario;
        }

        // Construtor padrão (opcional)
        public Presenca() { }
}
