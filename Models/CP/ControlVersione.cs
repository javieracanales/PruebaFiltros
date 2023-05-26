using System;
using System.Collections.Generic;

namespace PruebaFiltros.Models.CP;

public partial class ControlVersione
{
    public int IdControlVersion { get; set; }

    public int TipoActorId { get; set; }

    public string Version { get; set; } = null!;

    public string UrlDescarga { get; set; } = null!;

    public virtual TiposActore TipoActor { get; set; } = null!;
}
