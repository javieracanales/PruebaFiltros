using System;
using System.Collections.Generic;

namespace PruebaFiltros.Models.CP;

public partial class PinPass
{
    public int IdPinPass { get; set; }

    public int Clave { get; set; }

    public int PersonaId { get; set; }

    public virtual Persona Persona { get; set; } = null!;
}
