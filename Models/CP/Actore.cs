using System;
using System.Collections.Generic;

namespace PruebaFiltros.Models.CP;

public partial class Actore
{
    public int IdActor { get; set; }

    public string Nombre { get; set; } = null!;

    public string Mac { get; set; } = null!;

    public string? Serial { get; set; }

    public string Ip { get; set; } = null!;

    public int Puerto { get; set; }

    public string? Clave { get; set; }

    public bool Estado { get; set; }

    public DateTime FechaActualizacion { get; set; }

    public int ZonaId { get; set; }

    public int TipoActorId { get; set; }

    public virtual TiposActore TipoActor { get; set; } = null!;

    public virtual Zona Zona { get; set; } = null!;
}
