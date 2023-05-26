using System;
using System.Collections.Generic;

namespace PruebaFiltros.Models.CP;

public partial class TiposTarjeta
{
    public int IdTipoTarjeta { get; set; }

    public string Tipo { get; set; } = null!;

    public virtual ICollection<Tarjeta> Tarjeta { get; set; } = new List<Tarjeta>();
}
