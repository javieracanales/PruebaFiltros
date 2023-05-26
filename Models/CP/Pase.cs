using System;
using System.Collections.Generic;

namespace PruebaFiltros.Models.CP;

public partial class Pase
{
    public int IdPase { get; set; }

    public bool Estado { get; set; }

    public DateTime FechaAsignacion { get; set; }

    public DateTime FechaTermino { get; set; }

    public int PersonaId { get; set; }

    public int TarjetaId { get; set; }

    public virtual Persona Persona { get; set; } = null!;

    public virtual Tarjeta Tarjeta { get; set; } = null!;
}
