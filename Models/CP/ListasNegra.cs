using System;
using System.Collections.Generic;

namespace PruebaFiltros.Models.CP;

public partial class ListasNegra
{
    public int IdListaNegra { get; set; }

    public DateTime FechaIngreso { get; set; }

    public int PersonaId { get; set; }

    public int CreadorId { get; set; }

    public virtual Persona Persona { get; set; } = null!;
}
