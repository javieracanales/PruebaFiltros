using System;
using System.Collections.Generic;

namespace PruebaFiltros.Models.CP;

public partial class Dispositivo
{
    public int IdDispositivo { get; set; }

    public string DispositivoCorreo { get; set; } = null!;

    public string Token { get; set; } = null!;

    public int PersonaId { get; set; }

    public virtual ICollection<Historiale> Historiales { get; set; } = new List<Historiale>();

    public virtual Persona Persona { get; set; } = null!;
}
