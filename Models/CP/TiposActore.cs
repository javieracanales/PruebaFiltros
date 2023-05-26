using System;
using System.Collections.Generic;

namespace PruebaFiltros.Models.CP;

public partial class TiposActore
{
    public int IdTipoActor { get; set; }

    public string Tipo { get; set; } = null!;

    public virtual ICollection<Actore> Actores { get; set; } = new List<Actore>();

    public virtual ICollection<ControlVersione> ControlVersiones { get; set; } = new List<ControlVersione>();

    public virtual ICollection<Registro> Registros { get; set; } = new List<Registro>();
}
