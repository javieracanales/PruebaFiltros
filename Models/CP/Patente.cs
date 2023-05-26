using System;
using System.Collections.Generic;

namespace PruebaFiltros.Models.CP;

public partial class Patente
{
    public int IdPatente { get; set; }

    public string PatenteDigitos { get; set; } = null!;

    public int PersonaId { get; set; }

    public virtual Persona Persona { get; set; } = null!;

    public virtual ICollection<Registro> Registros { get; set; } = new List<Registro>();
}
