using System;
using System.Collections.Generic;

namespace PruebaFiltros.Models.CP;

public partial class Ubicacione
{
    public int IdUbicacion { get; set; }

    public int ZonaId { get; set; }

    public int TipoUbicacionId { get; set; }

    public string Nombre { get; set; } = null!;

    public string? Piso { get; set; }

    public string Numeracion { get; set; } = null!;

    public virtual ICollection<PersonasUbicacione> PersonasUbicaciones { get; set; } = new List<PersonasUbicacione>();

    public virtual ICollection<Registro> Registros { get; set; } = new List<Registro>();

    public virtual TiposUbicacione TipoUbicacion { get; set; } = null!;

    public virtual ICollection<Visita> Visita { get; set; } = new List<Visita>();

    public virtual Zona Zona { get; set; } = null!;
}
