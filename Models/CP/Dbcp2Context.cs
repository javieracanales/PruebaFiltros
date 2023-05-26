using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace PruebaFiltros.Models.CP;

public partial class Dbcp2Context : DbContext
{
    public Dbcp2Context()
    {
    }

    public Dbcp2Context(DbContextOptions<Dbcp2Context> options)
        : base(options)
    {
    }

    public virtual DbSet<Acceso> Accesos { get; set; }

    public virtual DbSet<Actore> Actores { get; set; }

    public virtual DbSet<Asignacione> Asignaciones { get; set; }

    public virtual DbSet<ControlVersione> ControlVersiones { get; set; }

    public virtual DbSet<Dispositivo> Dispositivos { get; set; }

    public virtual DbSet<Empresa> Empresas { get; set; }

    public virtual DbSet<Errore> Errores { get; set; }

    public virtual DbSet<Estacionamiento> Estacionamientos { get; set; }

    public virtual DbSet<Faciale> Faciales { get; set; }

    public virtual DbSet<Historiale> Historiales { get; set; }

    public virtual DbSet<Horario> Horarios { get; set; }

    public virtual DbSet<Huella> Huellas { get; set; }

    public virtual DbSet<ListasNegra> ListasNegras { get; set; }

    public virtual DbSet<Pase> Pases { get; set; }

    public virtual DbSet<Patente> Patentes { get; set; }

    public virtual DbSet<Persona> Personas { get; set; }

    public virtual DbSet<PersonasEmpresa> PersonasEmpresas { get; set; }

    public virtual DbSet<PersonasEstacionamiento> PersonasEstacionamientos { get; set; }

    public virtual DbSet<PersonasUbicacione> PersonasUbicaciones { get; set; }

    public virtual DbSet<PinPass> PinPasses { get; set; }

    public virtual DbSet<Registro> Registros { get; set; }

    public virtual DbSet<Role> Roles { get; set; }

    public virtual DbSet<RoleClaim> RoleClaims { get; set; }

    public virtual DbSet<Sentido> Sentidos { get; set; }

    public virtual DbSet<Sociedade> Sociedades { get; set; }

    public virtual DbSet<Tarjeta> Tarjetas { get; set; }

    public virtual DbSet<TiposActore> TiposActores { get; set; }

    public virtual DbSet<TiposEmpresa> TiposEmpresas { get; set; }

    public virtual DbSet<TiposPersona> TiposPersonas { get; set; }

    public virtual DbSet<TiposTarjeta> TiposTarjetas { get; set; }

    public virtual DbSet<TiposUbicacione> TiposUbicaciones { get; set; }

    public virtual DbSet<TiposVisita> TiposVisitas { get; set; }

    public virtual DbSet<Ubicacione> Ubicaciones { get; set; }

    public virtual DbSet<User> Users { get; set; }

    public virtual DbSet<UserClaim> UserClaims { get; set; }

    public virtual DbSet<UserLogin> UserLogins { get; set; }

    public virtual DbSet<UserToken> UserTokens { get; set; }

    public virtual DbSet<Visita> Visitas { get; set; }

    public virtual DbSet<Zona> Zonas { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=LAU-CM; Database=DBCP2; Trusted_connection=true; encrypt=false;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Acceso>(entity =>
        {
            entity.HasKey(e => e.IdAcceso);

            entity.HasIndex(e => e.PersonaId, "IX_Accesos_PersonaId");

            entity.HasIndex(e => e.ZonaId, "IX_Accesos_ZonaId");

            entity.HasOne(d => d.Persona).WithMany(p => p.Accesos)
                .HasForeignKey(d => d.PersonaId)
                .OnDelete(DeleteBehavior.ClientSetNull);

            entity.HasOne(d => d.Zona).WithMany(p => p.Accesos)
                .HasForeignKey(d => d.ZonaId)
                .OnDelete(DeleteBehavior.ClientSetNull);
        });

        modelBuilder.Entity<Actore>(entity =>
        {
            entity.HasKey(e => e.IdActor);

            entity.HasIndex(e => e.TipoActorId, "IX_Actores_TipoActorId");

            entity.HasIndex(e => e.ZonaId, "IX_Actores_ZonaId");

            entity.Property(e => e.Clave).HasMaxLength(100);
            entity.Property(e => e.Ip).HasMaxLength(20);
            entity.Property(e => e.Mac).HasMaxLength(20);
            entity.Property(e => e.Nombre).HasMaxLength(100);
            entity.Property(e => e.Serial).HasMaxLength(100);

            entity.HasOne(d => d.TipoActor).WithMany(p => p.Actores)
                .HasForeignKey(d => d.TipoActorId)
                .OnDelete(DeleteBehavior.ClientSetNull);

            entity.HasOne(d => d.Zona).WithMany(p => p.Actores)
                .HasForeignKey(d => d.ZonaId)
                .OnDelete(DeleteBehavior.ClientSetNull);
        });

        modelBuilder.Entity<Asignacione>(entity =>
        {
            entity.HasKey(e => e.IdAsignacion);

            entity.HasIndex(e => e.HorarioId, "IX_Asignaciones_HorarioId");

            entity.HasIndex(e => e.PersonaId, "IX_Asignaciones_PersonaId");

            entity.HasOne(d => d.Horario).WithMany(p => p.Asignaciones)
                .HasForeignKey(d => d.HorarioId)
                .OnDelete(DeleteBehavior.ClientSetNull);

            entity.HasOne(d => d.Persona).WithMany(p => p.Asignaciones)
                .HasForeignKey(d => d.PersonaId)
                .OnDelete(DeleteBehavior.ClientSetNull);
        });

        modelBuilder.Entity<ControlVersione>(entity =>
        {
            entity.HasKey(e => e.IdControlVersion);

            entity.HasIndex(e => e.TipoActorId, "IX_ControlVersiones_TipoActorId");

            entity.Property(e => e.UrlDescarga).HasColumnName("urlDescarga");
            entity.Property(e => e.Version).HasMaxLength(40);

            entity.HasOne(d => d.TipoActor).WithMany(p => p.ControlVersiones)
                .HasForeignKey(d => d.TipoActorId)
                .OnDelete(DeleteBehavior.ClientSetNull);
        });

        modelBuilder.Entity<Dispositivo>(entity =>
        {
            entity.HasKey(e => e.IdDispositivo);

            entity.HasIndex(e => e.PersonaId, "IX_Dispositivos_PersonaId");

            entity.Property(e => e.DispositivoCorreo).HasMaxLength(100);

            entity.HasOne(d => d.Persona).WithMany(p => p.Dispositivos)
                .HasForeignKey(d => d.PersonaId)
                .OnDelete(DeleteBehavior.ClientSetNull);
        });

        modelBuilder.Entity<Empresa>(entity =>
        {
            entity.HasKey(e => e.IdEmpresa);

            entity.HasIndex(e => e.SociedadId, "IX_Empresas_SociedadId");

            entity.HasIndex(e => e.TipoEmpresaId, "IX_Empresas_TipoEmpresaId");

            entity.HasOne(d => d.Sociedad).WithMany(p => p.Empresas).HasForeignKey(d => d.SociedadId);

            entity.HasOne(d => d.TipoEmpresa).WithMany(p => p.Empresas)
                .HasForeignKey(d => d.TipoEmpresaId)
                .OnDelete(DeleteBehavior.ClientSetNull);
        });

        modelBuilder.Entity<Errore>(entity =>
        {
            entity.HasKey(e => e.IdError);

            entity.HasIndex(e => e.EmpresaId, "IX_Errores_EmpresaId");

            entity.Property(e => e.ComentarioCierre).HasColumnName("comentarioCierre");
            entity.Property(e => e.Donde).HasMaxLength(100);
            entity.Property(e => e.FechaResolucion).HasColumnName("fechaResolucion");

            entity.HasOne(d => d.Empresa).WithMany(p => p.Errores)
                .HasForeignKey(d => d.EmpresaId)
                .OnDelete(DeleteBehavior.ClientSetNull);
        });

        modelBuilder.Entity<Estacionamiento>(entity =>
        {
            entity.HasKey(e => e.IdEstacionamiento);

            entity.HasIndex(e => e.ZonaId, "IX_Estacionamientos_ZonaId");

            entity.Property(e => e.Numero)
                .HasMaxLength(50)
                .HasColumnName("numero");

            entity.HasOne(d => d.Zona).WithMany(p => p.Estacionamientos)
                .HasForeignKey(d => d.ZonaId)
                .OnDelete(DeleteBehavior.ClientSetNull);
        });

        modelBuilder.Entity<Faciale>(entity =>
        {
            entity.HasKey(e => e.IdFacial);

            entity.HasIndex(e => e.PersonaId, "IX_Faciales_PersonaId");

            entity.HasOne(d => d.Persona).WithMany(p => p.Faciales)
                .HasForeignKey(d => d.PersonaId)
                .OnDelete(DeleteBehavior.ClientSetNull);
        });

        modelBuilder.Entity<Historiale>(entity =>
        {
            entity.HasKey(e => e.IdHistorial);

            entity.HasIndex(e => e.DispositivoId, "IX_Historiales_DispositivoId");

            entity.HasOne(d => d.Dispositivo).WithMany(p => p.Historiales)
                .HasForeignKey(d => d.DispositivoId)
                .OnDelete(DeleteBehavior.ClientSetNull);
        });

        modelBuilder.Entity<Horario>(entity =>
        {
            entity.HasKey(e => e.IdHorario);

            entity.HasIndex(e => e.EmpresaId, "IX_Horarios_EmpresaId");

            entity.Property(e => e.Nombre).HasMaxLength(100);

            entity.HasOne(d => d.Empresa).WithMany(p => p.Horarios)
                .HasForeignKey(d => d.EmpresaId)
                .OnDelete(DeleteBehavior.ClientSetNull);
        });

        modelBuilder.Entity<Huella>(entity =>
        {
            entity.HasKey(e => e.IdHuella);

            entity.HasIndex(e => e.PersonaId, "IX_Huellas_PersonaId");

            entity.Property(e => e.DedoRegistrado).HasMaxLength(30);

            entity.HasOne(d => d.Persona).WithMany(p => p.Huellas)
                .HasForeignKey(d => d.PersonaId)
                .OnDelete(DeleteBehavior.ClientSetNull);
        });

        modelBuilder.Entity<ListasNegra>(entity =>
        {
            entity.HasKey(e => e.IdListaNegra);

            entity.HasIndex(e => e.PersonaId, "IX_ListasNegras_PersonaId");

            entity.HasOne(d => d.Persona).WithMany(p => p.ListasNegras)
                .HasForeignKey(d => d.PersonaId)
                .OnDelete(DeleteBehavior.ClientSetNull);
        });

        modelBuilder.Entity<Pase>(entity =>
        {
            entity.HasKey(e => e.IdPase);

            entity.HasIndex(e => e.PersonaId, "IX_Pases_PersonaId");

            entity.HasIndex(e => e.TarjetaId, "IX_Pases_TarjetaId");

            entity.HasOne(d => d.Persona).WithMany(p => p.Pases)
                .HasForeignKey(d => d.PersonaId)
                .OnDelete(DeleteBehavior.ClientSetNull);

            entity.HasOne(d => d.Tarjeta).WithMany(p => p.Pases)
                .HasForeignKey(d => d.TarjetaId)
                .OnDelete(DeleteBehavior.ClientSetNull);
        });

        modelBuilder.Entity<Patente>(entity =>
        {
            entity.HasKey(e => e.IdPatente);

            entity.HasIndex(e => e.PersonaId, "IX_Patentes_PersonaId");

            entity.Property(e => e.PatenteDigitos).HasMaxLength(10);

            entity.HasOne(d => d.Persona).WithMany(p => p.Patentes)
                .HasForeignKey(d => d.PersonaId)
                .OnDelete(DeleteBehavior.ClientSetNull);
        });

        modelBuilder.Entity<Persona>(entity =>
        {
            entity.HasKey(e => e.IdPersona);

            entity.HasIndex(e => e.TipoPersonaId, "IX_Personas_TipoPersonaId");

            entity.HasOne(d => d.TipoPersona).WithMany(p => p.Personas).HasForeignKey(d => d.TipoPersonaId);
        });

        modelBuilder.Entity<PersonasEmpresa>(entity =>
        {
            entity.HasKey(e => e.IdPersonaEmpresa);

            entity.HasIndex(e => e.EmpresaId, "IX_PersonasEmpresas_EmpresaId");

            entity.HasIndex(e => e.PersonaId, "IX_PersonasEmpresas_PersonaId");

            entity.HasOne(d => d.Empresa).WithMany(p => p.PersonasEmpresas)
                .HasForeignKey(d => d.EmpresaId)
                .OnDelete(DeleteBehavior.ClientSetNull);

            entity.HasOne(d => d.Persona).WithMany(p => p.PersonasEmpresas)
                .HasForeignKey(d => d.PersonaId)
                .OnDelete(DeleteBehavior.ClientSetNull);
        });

        modelBuilder.Entity<PersonasEstacionamiento>(entity =>
        {
            entity.HasKey(e => e.IdPersonaEstacionamiento);

            entity.HasIndex(e => e.EstacionamientoId, "IX_PersonasEstacionamientos_EstacionamientoId");

            entity.HasIndex(e => e.PersonaId, "IX_PersonasEstacionamientos_PersonaId");

            entity.Property(e => e.FechaAsignacion).HasColumnName("fechaAsignacion");

            entity.HasOne(d => d.Estacionamiento).WithMany(p => p.PersonasEstacionamientos)
                .HasForeignKey(d => d.EstacionamientoId)
                .OnDelete(DeleteBehavior.ClientSetNull);

            entity.HasOne(d => d.Persona).WithMany(p => p.PersonasEstacionamientos)
                .HasForeignKey(d => d.PersonaId)
                .OnDelete(DeleteBehavior.ClientSetNull);
        });

        modelBuilder.Entity<PersonasUbicacione>(entity =>
        {
            entity.HasKey(e => e.IdPersonaUbicacion);

            entity.HasIndex(e => e.PersonaId, "IX_PersonasUbicaciones_PersonaId");

            entity.HasIndex(e => e.UbicacionId, "IX_PersonasUbicaciones_UbicacionId");

            entity.HasOne(d => d.Persona).WithMany(p => p.PersonasUbicaciones)
                .HasForeignKey(d => d.PersonaId)
                .OnDelete(DeleteBehavior.ClientSetNull);

            entity.HasOne(d => d.Ubicacion).WithMany(p => p.PersonasUbicaciones)
                .HasForeignKey(d => d.UbicacionId)
                .OnDelete(DeleteBehavior.ClientSetNull);
        });

        modelBuilder.Entity<PinPass>(entity =>
        {
            entity.HasKey(e => e.IdPinPass);

            entity.HasIndex(e => e.PersonaId, "IX_PinPasses_PersonaId");

            entity.HasOne(d => d.Persona).WithMany(p => p.PinPasses)
                .HasForeignKey(d => d.PersonaId)
                .OnDelete(DeleteBehavior.ClientSetNull);
        });

        modelBuilder.Entity<Registro>(entity =>
        {
            entity.HasKey(e => e.IdRegistro);

            entity.HasIndex(e => e.PatenteId, "IX_Registros_PatenteId");

            entity.HasIndex(e => e.PersonaId, "IX_Registros_PersonaId");

            entity.HasIndex(e => e.SentidoId, "IX_Registros_SentidoId");

            entity.HasIndex(e => e.TipoActorId, "IX_Registros_TipoActorId");

            entity.HasIndex(e => e.UbicacionId, "IX_Registros_UbicacionId");

            entity.HasIndex(e => e.ZonaId, "IX_Registros_ZonaId");

            entity.HasOne(d => d.Patente).WithMany(p => p.Registros).HasForeignKey(d => d.PatenteId);

            entity.HasOne(d => d.Persona).WithMany(p => p.Registros).HasForeignKey(d => d.PersonaId);

            entity.HasOne(d => d.Sentido).WithMany(p => p.Registros).HasForeignKey(d => d.SentidoId);

            entity.HasOne(d => d.TipoActor).WithMany(p => p.Registros)
                .HasForeignKey(d => d.TipoActorId)
                .OnDelete(DeleteBehavior.ClientSetNull);

            entity.HasOne(d => d.Ubicacion).WithMany(p => p.Registros).HasForeignKey(d => d.UbicacionId);

            entity.HasOne(d => d.Zona).WithMany(p => p.Registros)
                .HasForeignKey(d => d.ZonaId)
                .OnDelete(DeleteBehavior.ClientSetNull);
        });

        modelBuilder.Entity<Role>(entity =>
        {
            entity.ToTable("Role");

            entity.HasIndex(e => e.NormalizedName, "RoleNameIndex")
                .IsUnique()
                .HasFilter("([NormalizedName] IS NOT NULL)");

            entity.Property(e => e.Name).HasMaxLength(256);
            entity.Property(e => e.NormalizedName).HasMaxLength(256);
        });

        modelBuilder.Entity<RoleClaim>(entity =>
        {
            entity.ToTable("RoleClaim");

            entity.HasIndex(e => e.RoleId, "IX_RoleClaim_RoleId");

            entity.HasOne(d => d.Role).WithMany(p => p.RoleClaims)
                .HasForeignKey(d => d.RoleId)
                .OnDelete(DeleteBehavior.ClientSetNull);
        });

        modelBuilder.Entity<Sentido>(entity =>
        {
            entity.HasKey(e => e.IdSentido);

            entity.Property(e => e.Direccion).HasMaxLength(10);
        });

        modelBuilder.Entity<Sociedade>(entity =>
        {
            entity.HasKey(e => e.IdSociedad);

            entity.Property(e => e.Nombre).HasMaxLength(200);
        });

        modelBuilder.Entity<Tarjeta>(entity =>
        {
            entity.HasKey(e => e.IdTarjeta);

            entity.HasIndex(e => e.TipoTarjetaId, "IX_Tarjetas_TipoTarjetaId");

            entity.HasOne(d => d.TipoTarjeta).WithMany(p => p.Tarjeta)
                .HasForeignKey(d => d.TipoTarjetaId)
                .OnDelete(DeleteBehavior.ClientSetNull);
        });

        modelBuilder.Entity<TiposActore>(entity =>
        {
            entity.HasKey(e => e.IdTipoActor);

            entity.Property(e => e.Tipo).HasMaxLength(50);
        });

        modelBuilder.Entity<TiposEmpresa>(entity =>
        {
            entity.HasKey(e => e.IdTipoEmpresa);

            entity.Property(e => e.Tipo).HasMaxLength(50);
        });

        modelBuilder.Entity<TiposPersona>(entity =>
        {
            entity.HasKey(e => e.IdTipoPersona);

            entity.HasIndex(e => e.EmpresaId, "IX_TiposPersonas_EmpresaId");

            entity.Property(e => e.Tipo).HasMaxLength(100);

            entity.HasOne(d => d.Empresa).WithMany(p => p.TiposPersonas)
                .HasForeignKey(d => d.EmpresaId)
                .OnDelete(DeleteBehavior.ClientSetNull);
        });

        modelBuilder.Entity<TiposTarjeta>(entity =>
        {
            entity.HasKey(e => e.IdTipoTarjeta);

            entity.Property(e => e.Tipo).HasMaxLength(50);
        });

        modelBuilder.Entity<TiposUbicacione>(entity =>
        {
            entity.HasKey(e => e.IdTipoUbicacion);

            entity.HasIndex(e => e.EmpresaId, "IX_TiposUbicaciones_EmpresaId");

            entity.Property(e => e.Tipo).HasMaxLength(50);

            entity.HasOne(d => d.Empresa).WithMany(p => p.TiposUbicaciones)
                .HasForeignKey(d => d.EmpresaId)
                .OnDelete(DeleteBehavior.ClientSetNull);
        });

        modelBuilder.Entity<TiposVisita>(entity =>
        {
            entity.HasKey(e => e.IdTipoVisita);

            entity.HasIndex(e => e.EmpresaId, "IX_TiposVisitas_EmpresaId");

            entity.Property(e => e.Tipo).HasMaxLength(50);

            entity.HasOne(d => d.Empresa).WithMany(p => p.TiposVisita)
                .HasForeignKey(d => d.EmpresaId)
                .OnDelete(DeleteBehavior.ClientSetNull);
        });

        modelBuilder.Entity<Ubicacione>(entity =>
        {
            entity.HasKey(e => e.IdUbicacion);

            entity.HasIndex(e => e.TipoUbicacionId, "IX_Ubicaciones_TipoUbicacionId");

            entity.HasIndex(e => e.ZonaId, "IX_Ubicaciones_ZonaId");

            entity.Property(e => e.Nombre)
                .HasMaxLength(100)
                .HasColumnName("nombre");
            entity.Property(e => e.Numeracion)
                .HasMaxLength(50)
                .HasColumnName("numeracion");
            entity.Property(e => e.Piso).HasColumnName("piso");

            entity.HasOne(d => d.TipoUbicacion).WithMany(p => p.Ubicaciones)
                .HasForeignKey(d => d.TipoUbicacionId)
                .OnDelete(DeleteBehavior.ClientSetNull);

            entity.HasOne(d => d.Zona).WithMany(p => p.Ubicaciones)
                .HasForeignKey(d => d.ZonaId)
                .OnDelete(DeleteBehavior.ClientSetNull);
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.ToTable("User");

            entity.HasIndex(e => e.NormalizedEmail, "EmailIndex");

            entity.HasIndex(e => e.NormalizedUserName, "UserNameIndex")
                .IsUnique()
                .HasFilter("([NormalizedUserName] IS NOT NULL)");

            entity.Property(e => e.Email).HasMaxLength(256);
            entity.Property(e => e.NormalizedEmail).HasMaxLength(256);
            entity.Property(e => e.NormalizedUserName).HasMaxLength(256);
            entity.Property(e => e.UserName).HasMaxLength(256);

            entity.HasMany(d => d.Roles).WithMany(p => p.Users)
                .UsingEntity<Dictionary<string, object>>(
                    "UserRole",
                    r => r.HasOne<Role>().WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.ClientSetNull),
                    l => l.HasOne<User>().WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.ClientSetNull),
                    j =>
                    {
                        j.HasKey("UserId", "RoleId");
                        j.ToTable("UserRole");
                        j.HasIndex(new[] { "RoleId" }, "IX_UserRole_RoleId");
                    });
        });

        modelBuilder.Entity<UserClaim>(entity =>
        {
            entity.ToTable("UserClaim");

            entity.HasIndex(e => e.UserId, "IX_UserClaim_UserId");

            entity.HasOne(d => d.User).WithMany(p => p.UserClaims)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull);
        });

        modelBuilder.Entity<UserLogin>(entity =>
        {
            entity.HasKey(e => new { e.LoginProvider, e.ProviderKey });

            entity.ToTable("UserLogin");

            entity.HasIndex(e => e.UserId, "IX_UserLogin_UserId");

            entity.Property(e => e.LoginProvider).HasMaxLength(128);
            entity.Property(e => e.ProviderKey).HasMaxLength(128);

            entity.HasOne(d => d.User).WithMany(p => p.UserLogins)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull);
        });

        modelBuilder.Entity<UserToken>(entity =>
        {
            entity.HasKey(e => new { e.UserId, e.LoginProvider, e.Name });

            entity.ToTable("UserToken");

            entity.Property(e => e.LoginProvider).HasMaxLength(128);
            entity.Property(e => e.Name).HasMaxLength(128);

            entity.HasOne(d => d.User).WithMany(p => p.UserTokens)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull);
        });

        modelBuilder.Entity<Visita>(entity =>
        {
            entity.HasKey(e => e.IdVisita);

            entity.HasIndex(e => e.PersonaId, "IX_Visitas_PersonaId");

            entity.HasIndex(e => e.TipoVisitaId, "IX_Visitas_TipoVisitaId");

            entity.HasIndex(e => e.UbicacionId, "IX_Visitas_UbicacionId");

            entity.HasOne(d => d.Persona).WithMany(p => p.Visita)
                .HasForeignKey(d => d.PersonaId)
                .OnDelete(DeleteBehavior.ClientSetNull);

            entity.HasOne(d => d.TipoVisita).WithMany(p => p.Visita)
                .HasForeignKey(d => d.TipoVisitaId)
                .OnDelete(DeleteBehavior.ClientSetNull);

            entity.HasOne(d => d.Ubicacion).WithMany(p => p.Visita)
                .HasForeignKey(d => d.UbicacionId)
                .OnDelete(DeleteBehavior.ClientSetNull);
        });

        modelBuilder.Entity<Zona>(entity =>
        {
            entity.HasKey(e => e.IdZona);

            entity.HasIndex(e => e.EmpresaId, "IX_Zonas_EmpresaId");

            entity.Property(e => e.Nombre).HasMaxLength(50);

            entity.HasOne(d => d.Empresa).WithMany(p => p.Zonas)
                .HasForeignKey(d => d.EmpresaId)
                .OnDelete(DeleteBehavior.ClientSetNull);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
