using System;
using System.Collections.Generic;

namespace PruebaFiltros.Models.CP;

public partial class Errore
{
    public int IdError { get; set; }

    public string Donde { get; set; } = null!;

    public DateTime Fecha { get; set; }

    public string Mensaje { get; set; } = null!;

    public int EmpresaId { get; set; }

    public bool Resuelto { get; set; }

    public DateTime? FechaResolucion { get; set; }

    public string? ComentarioCierre { get; set; }

    public virtual Empresa Empresa { get; set; } = null!;
}
