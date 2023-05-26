using System;
using System.Collections.Generic;

namespace PruebaFiltros.Models.CP;

public partial class Estacionamiento
{
    public int IdEstacionamiento { get; set; }

    public int ZonaId { get; set; }

    public string Numero { get; set; } = null!;

    public virtual ICollection<PersonasEstacionamiento> PersonasEstacionamientos { get; set; } = new List<PersonasEstacionamiento>();

    public virtual Zona Zona { get; set; } = null!;
}
