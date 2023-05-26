using System;
using System.Collections.Generic;

namespace PruebaFiltros.Models.CP;

public partial class Historiale
{
    public int IdHistorial { get; set; }

    public string MensajeNotificacion { get; set; } = null!;

    public DateTime Fecha { get; set; }

    public int DispositivoId { get; set; }

    public virtual Dispositivo Dispositivo { get; set; } = null!;
}
