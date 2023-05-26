using System;
using System.Collections.Generic;

namespace PruebaFiltros.Models.CP;

public partial class Tarjeta
{
    public int IdTarjeta { get; set; }

    public bool Estado { get; set; }

    public int TipoTarjetaId { get; set; }

    public virtual ICollection<Pase> Pases { get; set; } = new List<Pase>();

    public virtual TiposTarjeta TipoTarjeta { get; set; } = null!;
}
