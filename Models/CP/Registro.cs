using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PruebaFiltros.Models.CP;

public partial class Registro
{
    [Key]
    public int IdRegistro { get; set; }
    public DateTime Fecha { get; set; }

    [ForeignKey("ZonaId")]
    public int ZonaId { get; set; }
    public virtual Zona? Zona { get; set; }

    [ForeignKey("SentidoId")]
    public int? SentidoId { get; set; }
    public virtual Sentido? Sentido { get; set; }

    [ForeignKey("PatenteId")]
    public int? PatenteId { get; set; }
    public virtual Patente? Patente { get; set; }

    [ForeignKey("PersonaId")]
    public int? PersonaId { get; set; }
    public virtual Persona? Persona { get; set; }

    [ForeignKey("TipoActorId")]
    public int TipoActorId { get; set; }
    public virtual TiposActore? TipoActor { get; set; }

    [ForeignKey("UbicacionId")]
    public int? UbicacionId { get; set; }
    public virtual Ubicacione? Ubicacion { get; set; }

}
