using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace AtencionTramites.Model.ModelAtencionTramites
{
    public partial class DbAtencionTramites : DbContext
    {
        public virtual DbSet<AreaDerecho> AreaDerecho { get; set; }
        public virtual DbSet<CentroPoblado> CentroPoblado { get; set; }
        public virtual DbSet<Ciudad> Ciudad { get; set; }
        public virtual DbSet<Comunidad> Comunidad { get; set; }
        public virtual DbSet<ConclusionAsesoria> ConclusionAsesoria { get; set; }
        public virtual DbSet<Decision> Decision { get; set; }
        public virtual DbSet<Departamento> Departamento { get; set; }
        public virtual DbSet<Derecho> Derecho { get; set; }
        public virtual DbSet<Entidad> Entidad { get; set; }
        public virtual DbSet<EstadoCivil> EstadoCivil { get; set; }
        public virtual DbSet<EstadoTarea> EstadoTarea { get; set; }
        public virtual DbSet<EstratoSocioEconomico> EstratoSocioEconomico { get; set; }
        public virtual DbSet<ExpresionGenero> ExpresionGenero { get; set; }
        public virtual DbSet<Finalizacion> Finalizacion { get; set; }
        public virtual DbSet<Formato> Formato { get; set; }
        public virtual DbSet<Fuente> Fuente { get; set; }
        public virtual DbSet<Funcionario> Funcionario { get; set; }
        public virtual DbSet<Genero> Genero { get; set; }
        public virtual DbSet<Grupo> Grupo { get; set; }
        public virtual DbSet<GrupoEtnico> GrupoEtnico { get; set; }
        public virtual DbSet<IdentidadGenero> IdentidadGenero { get; set; }
        public virtual DbSet<MedioRespuesta> MedioRespuesta { get; set; }
        public virtual DbSet<NivelEstudios> NivelEstudios { get; set; }
        public virtual DbSet<OrientacionSexual> OrientacionSexual { get; set; }
        public virtual DbSet<Pais> Pais { get; set; }
        public virtual DbSet<Procedencia> Procedencia { get; set; }
        public virtual DbSet<RangoEdad> RangoEdad { get; set; }
        public virtual DbSet<Remitente> Remitente { get; set; }
        public virtual DbSet<Secretaria> Secretaria { get; set; }
        public virtual DbSet<Sexo> Sexo { get; set; }
        public virtual DbSet<SituacionDiscapacidad> SituacionDiscapacidad { get; set; }
        public virtual DbSet<SubGrupo> SubGrupo { get; set; }
        public virtual DbSet<SubTipoDocumento> SubTipoDocumento { get; set; }
        public virtual DbSet<SujetoEspecialProteccion> SujetoEspecialProteccion { get; set; }
        public virtual DbSet<TipoCorreo> TipoCorreo { get; set; }
        public virtual DbSet<TipoDireccion> TipoDireccion { get; set; }
        public virtual DbSet<TipoDocumento> TipoDocumento { get; set; }
        public virtual DbSet<TipoDocumentoFinalizacion> TipoDocumentoFinalizacion { get; set; }
        public virtual DbSet<TipoDocumentoFormato> TipoDocumentoFormato { get; set; }
        public virtual DbSet<TipoDocumentoIdentificacion> TipoDocumentoIdentificacion { get; set; }
        public virtual DbSet<TipoDocumentoOcultaDecision> TipoDocumentoOcultaDecision { get; set; }
        public virtual DbSet<TipoDocumentoRespuestaIntegrada> TipoDocumentoRespuestaIntegrada { get; set; }
        public virtual DbSet<TipoNotificacion> TipoNotificacion { get; set; }
        public virtual DbSet<TipoOficio> TipoOficio { get; set; }
        public virtual DbSet<TipoPeticion> TipoPeticion { get; set; }
        public virtual DbSet<TipoPqrs> TipoPqrs { get; set; }
        public virtual DbSet<TipoSolicitante> TipoSolicitante { get; set; }
        public virtual DbSet<TipoTramite> TipoTramite { get; set; }
        public virtual DbSet<ClasificacionPeticion> ClasificacionPeticion { get; set; }
        public virtual DbSet<DerechosClasificacion> DerechosClasificacion { get; set; }
        public virtual DbSet<ExternalServiceToken> ExternalServiceToken { get; set; }
        public virtual DbSet<Notificacion> Notificacion { get; set; }
        public virtual DbSet<Pqrs> Pqrs { get; set; }
        public virtual DbSet<PqrsDocumento> PqrsDocumento { get; set; }
        public virtual DbSet<Radicado> Radicado { get; set; }
        public virtual DbSet<RadicadoAdicional> RadicadoAdicional { get; set; }
        public virtual DbSet<RadicadoDecision> RadicadoDecision { get; set; }
        public virtual DbSet<RadicadoDocumento> RadicadoDocumento { get; set; }
        public virtual DbSet<RadicadoInterno> RadicadoInterno { get; set; }
        public virtual DbSet<RadicadoInternoAdicional> RadicadoInternoAdicional { get; set; }
        public virtual DbSet<RadicadoInternoDecision> RadicadoInternoDecision { get; set; }
        public virtual DbSet<RadicadoInternoDocumento> RadicadoInternoDocumento { get; set; }
        public virtual DbSet<Respuesta> Respuesta { get; set; }
        public virtual DbSet<RespuestaAdicional> RespuestaAdicional { get; set; }
        public virtual DbSet<RespuestaCorreoCertificado> RespuestaCorreoCertificado { get; set; }
        public virtual DbSet<RespuestaDecision> RespuestaDecision { get; set; }
        public virtual DbSet<RespuestaDocumento> RespuestaDocumento { get; set; }
        public virtual DbSet<sysdiagrams> sysdiagrams { get; set; }
        public virtual DbSet<BIS> BIS { get; set; }
        public virtual DbSet<Cardinalidad> Cardinalidad { get; set; }
        public virtual DbSet<Condicion> Condicion { get; set; }
        public virtual DbSet<Letra> Letra { get; set; }
        public virtual DbSet<TipoFirma> TipoFirma { get; set; }
        public virtual DbSet<Via> Via { get; set; }
        public virtual DbSet<Vivienda> Vivienda { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AreaDerecho>()
                .Property(e => e.Nombre)
                .IsUnicode(false);

            modelBuilder.Entity<AreaDerecho>()
                .HasMany(e => e.ClasificacionPeticion)
                .WithOptional(e => e.AreaDerecho)
                .HasForeignKey(e => e.CodigoAreaDerecho);

            modelBuilder.Entity<AreaDerecho>()
                .HasMany(e => e.Derecho)
                .WithRequired(e => e.AreaDerecho)
                .HasForeignKey(e => e.CodigoAreaDerecho)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<CentroPoblado>()
                .Property(e => e.Nombre)
                .IsUnicode(false);

            modelBuilder.Entity<Ciudad>()
                .Property(e => e.Nombre)
                .IsUnicode(false);

            modelBuilder.Entity<Ciudad>()
                .HasMany(e => e.Pqrs)
                .WithOptional(e => e.Ciudad)
                .HasForeignKey(e => e.CodigoCiudad);

            modelBuilder.Entity<Ciudad>()
                .HasMany(e => e.Pqrs1)
                .WithOptional(e => e.Ciudad1)
                .HasForeignKey(e => e.CodigoMunicipioHechos);

            modelBuilder.Entity<Ciudad>()
                .HasMany(e => e.Radicado)
                .WithOptional(e => e.Ciudad)
                .HasForeignKey(e => e.CodigoCiudad);

            modelBuilder.Entity<Ciudad>()
                .HasMany(e => e.Radicado1)
                .WithOptional(e => e.Ciudad1)
                .HasForeignKey(e => e.CodigoMunicipioHechos);

            modelBuilder.Entity<Comunidad>()
                .Property(e => e.Nombre)
                .IsUnicode(false);

            modelBuilder.Entity<ConclusionAsesoria>()
                .Property(e => e.Nombre)
                .IsUnicode(false);

            modelBuilder.Entity<ConclusionAsesoria>()
                .HasMany(e => e.ClasificacionPeticion)
                .WithOptional(e => e.ConclusionAsesoria)
                .HasForeignKey(e => e.CodigoConclusionAsesoria);

            modelBuilder.Entity<Decision>()
                .Property(e => e.Nombre)
                .IsUnicode(false);

            modelBuilder.Entity<Decision>()
                .Property(e => e.Proceso)
                .IsUnicode(false);

            modelBuilder.Entity<Decision>()
                .Property(e => e.Etapa)
                .IsUnicode(false);

            modelBuilder.Entity<Decision>()
                .HasMany(e => e.RadicadoDecision)
                .WithRequired(e => e.Decision)
                .HasForeignKey(e => e.CodigoDecision)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Decision>()
                .HasMany(e => e.RadicadoInternoDecision)
                .WithRequired(e => e.Decision)
                .HasForeignKey(e => e.CodigoDecision)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Decision>()
                .HasMany(e => e.RespuestaDecision)
                .WithRequired(e => e.Decision)
                .HasForeignKey(e => e.CodigoDecision)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Departamento>()
                .Property(e => e.Nombre)
                .IsUnicode(false);

            modelBuilder.Entity<Departamento>()
                .Property(e => e.shpLongitud)
                .HasPrecision(18, 5);

            modelBuilder.Entity<Departamento>()
                .Property(e => e.shpLatitud)
                .HasPrecision(18, 5);

            modelBuilder.Entity<Departamento>()
                .HasMany(e => e.Pqrs)
                .WithOptional(e => e.Departamento)
                .HasForeignKey(e => e.CodigoDepartamento);

            modelBuilder.Entity<Departamento>()
                .HasMany(e => e.Pqrs1)
                .WithOptional(e => e.Departamento1)
                .HasForeignKey(e => e.CodigoDepartamentoHechos);

            modelBuilder.Entity<Departamento>()
                .HasMany(e => e.Radicado)
                .WithOptional(e => e.Departamento)
                .HasForeignKey(e => e.CodigoDepartamento);

            modelBuilder.Entity<Departamento>()
                .HasMany(e => e.Radicado1)
                .WithOptional(e => e.Departamento1)
                .HasForeignKey(e => e.CodigoDepartamentoHechos);

            modelBuilder.Entity<Derecho>()
                .Property(e => e.Nombre)
                .IsUnicode(false);

            modelBuilder.Entity<Derecho>()
                .HasMany(e => e.DerechosClasificacion)
                .WithRequired(e => e.Derecho)
                .HasForeignKey(e => e.CodigoDerecho)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Entidad>()
                .Property(e => e.Nombre)
                .IsUnicode(false);

            modelBuilder.Entity<Entidad>()
                .Property(e => e.Departamento)
                .IsUnicode(false);

            modelBuilder.Entity<Entidad>()
                .Property(e => e.Municipio)
                .IsUnicode(false);

            modelBuilder.Entity<Entidad>()
                .Property(e => e.Sigla)
                .IsUnicode(false);

            modelBuilder.Entity<Entidad>()
                .Property(e => e.RutaDocumentos)
                .IsUnicode(false);

            modelBuilder.Entity<Entidad>()
                .Property(e => e.Dominio)
                .IsUnicode(false);

            modelBuilder.Entity<Entidad>()
                .Property(e => e.Pop3Server)
                .IsUnicode(false);

            modelBuilder.Entity<Entidad>()
                .Property(e => e.Pop3Password)
                .IsUnicode(false);

            modelBuilder.Entity<Entidad>()
                .Property(e => e.Pop3Email)
                .IsUnicode(false);

            modelBuilder.Entity<Entidad>()
                .Property(e => e.SmtpServer)
                .IsUnicode(false);

            modelBuilder.Entity<Entidad>()
                .Property(e => e.SmtpUsername)
                .IsUnicode(false);

            modelBuilder.Entity<Entidad>()
                .Property(e => e.SmtpPassword)
                .IsUnicode(false);

            modelBuilder.Entity<Entidad>()
                .Property(e => e.SmtpEmail)
                .IsUnicode(false);

            modelBuilder.Entity<Entidad>()
                .Property(e => e.RecipienteNotificaciones)
                .IsUnicode(false);

            modelBuilder.Entity<EstadoCivil>()
                .Property(e => e.Nombre)
                .IsUnicode(false);

            modelBuilder.Entity<EstadoCivil>()
                .HasMany(e => e.Pqrs)
                .WithOptional(e => e.EstadoCivil)
                .HasForeignKey(e => e.CodigoEstadoCivil);

            modelBuilder.Entity<EstadoCivil>()
                .HasMany(e => e.Radicado)
                .WithOptional(e => e.EstadoCivil)
                .HasForeignKey(e => e.CodigoEstadoCivil);

            modelBuilder.Entity<EstadoTarea>()
                .Property(e => e.Nombre)
                .IsUnicode(false);

            modelBuilder.Entity<EstadoTarea>()
                .HasMany(e => e.Radicado)
                .WithOptional(e => e.EstadoTarea)
                .HasForeignKey(e => e.CodigoEstadoTarea);

            modelBuilder.Entity<EstadoTarea>()
                .HasMany(e => e.RadicadoInterno)
                .WithOptional(e => e.EstadoTarea)
                .HasForeignKey(e => e.CodigoEstadoTarea);

            modelBuilder.Entity<EstadoTarea>()
                .HasMany(e => e.Respuesta)
                .WithOptional(e => e.EstadoTarea)
                .HasForeignKey(e => e.CodigoEstadoTarea);

            modelBuilder.Entity<EstratoSocioEconomico>()
                .Property(e => e.Nombre)
                .IsUnicode(false);

            modelBuilder.Entity<ExpresionGenero>()
                .Property(e => e.Nombre)
                .IsUnicode(false);

            modelBuilder.Entity<Finalizacion>()
                .Property(e => e.Nombre)
                .IsUnicode(false);

            modelBuilder.Entity<Finalizacion>()
                .HasMany(e => e.TipoDocumentoFinalizacion)
                .WithRequired(e => e.Finalizacion)
                .HasForeignKey(e => e.CodigoFinalizacion)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Formato>()
                .Property(e => e.Nombre)
                .IsUnicode(false);

            modelBuilder.Entity<Formato>()
                .HasMany(e => e.Radicado)
                .WithOptional(e => e.Formato)
                .HasForeignKey(e => e.CodigoFormato);

            modelBuilder.Entity<Formato>()
                .HasMany(e => e.RadicadoInterno)
                .WithOptional(e => e.Formato)
                .HasForeignKey(e => e.CodigoFormato);

            modelBuilder.Entity<Formato>()
                .HasMany(e => e.Respuesta)
                .WithOptional(e => e.Formato)
                .HasForeignKey(e => e.CodigoFormato);

            modelBuilder.Entity<Fuente>()
                .Property(e => e.Nombre)
                .IsUnicode(false);

            modelBuilder.Entity<Fuente>()
                .HasMany(e => e.Radicado)
                .WithRequired(e => e.Fuente)
                .HasForeignKey(e => e.CodigoFuente)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Funcionario>()
                .Property(e => e.Cedula)
                .IsUnicode(false);

            modelBuilder.Entity<Funcionario>()
                .Property(e => e.Correo)
                .IsUnicode(false);

            modelBuilder.Entity<Funcionario>()
                .Property(e => e.Usuario)
                .IsUnicode(false);

            modelBuilder.Entity<Funcionario>()
                .Property(e => e.Firma)
                .IsUnicode(false);

            modelBuilder.Entity<Genero>()
                .Property(e => e.Nombre)
                .IsUnicode(false);

            modelBuilder.Entity<Genero>()
                .HasMany(e => e.Pqrs)
                .WithOptional(e => e.Genero)
                .HasForeignKey(e => e.CodigoGenero);

            modelBuilder.Entity<Genero>()
                .HasMany(e => e.Radicado)
                .WithOptional(e => e.Genero)
                .HasForeignKey(e => e.CodigoGenero);

            modelBuilder.Entity<Grupo>()
                .Property(e => e.Nombre)
                .IsUnicode(false);

            modelBuilder.Entity<GrupoEtnico>()
                .Property(e => e.Nombre)
                .IsUnicode(false);

            modelBuilder.Entity<GrupoEtnico>()
                .HasMany(e => e.Pqrs)
                .WithOptional(e => e.GrupoEtnico)
                .HasForeignKey(e => e.CodigoGrupoEtnico);

            modelBuilder.Entity<GrupoEtnico>()
                .HasMany(e => e.Radicado)
                .WithOptional(e => e.GrupoEtnico)
                .HasForeignKey(e => e.CodigoGrupoEtnico);

            modelBuilder.Entity<IdentidadGenero>()
                .Property(e => e.Nombre)
                .IsUnicode(false);

            modelBuilder.Entity<MedioRespuesta>()
                .Property(e => e.Nombre)
                .IsUnicode(false);

            modelBuilder.Entity<MedioRespuesta>()
                .HasMany(e => e.Pqrs)
                .WithOptional(e => e.MedioRespuesta)
                .HasForeignKey(e => e.CodigoMedioRedpuesta);

            modelBuilder.Entity<MedioRespuesta>()
                .HasMany(e => e.Radicado)
                .WithOptional(e => e.MedioRespuesta)
                .HasForeignKey(e => e.CodigoMedioRedpuesta);

            modelBuilder.Entity<NivelEstudios>()
                .Property(e => e.Nombre)
                .IsUnicode(false);

            modelBuilder.Entity<NivelEstudios>()
                .HasMany(e => e.Pqrs)
                .WithOptional(e => e.NivelEstudios)
                .HasForeignKey(e => e.CodigoNivelEstudios);

            modelBuilder.Entity<NivelEstudios>()
                .HasMany(e => e.Radicado)
                .WithOptional(e => e.NivelEstudios)
                .HasForeignKey(e => e.CodigoNivelEstudios);

            modelBuilder.Entity<OrientacionSexual>()
                .Property(e => e.Nombre)
                .IsUnicode(false);

            modelBuilder.Entity<OrientacionSexual>()
                .HasMany(e => e.Pqrs)
                .WithOptional(e => e.OrientacionSexual)
                .HasForeignKey(e => e.CodigoOrientacionSexual);

            modelBuilder.Entity<OrientacionSexual>()
                .HasMany(e => e.Radicado)
                .WithOptional(e => e.OrientacionSexual)
                .HasForeignKey(e => e.CodigoOrientacionSexual);

            modelBuilder.Entity<Pais>()
                .Property(e => e.NombrePais)
                .IsUnicode(false);

            modelBuilder.Entity<Pais>()
                .HasMany(e => e.Pqrs)
                .WithOptional(e => e.Pais)
                .HasForeignKey(e => e.CodigoPais);

            modelBuilder.Entity<Pais>()
                .HasMany(e => e.Radicado)
                .WithOptional(e => e.Pais)
                .HasForeignKey(e => e.CodigoPais);

            modelBuilder.Entity<Procedencia>()
                .Property(e => e.Nombre)
                .IsUnicode(false);

            modelBuilder.Entity<Procedencia>()
                .HasMany(e => e.Pqrs)
                .WithOptional(e => e.Procedencia)
                .HasForeignKey(e => e.CodigoProcedencia);

            modelBuilder.Entity<Procedencia>()
                .HasMany(e => e.Radicado)
                .WithOptional(e => e.Procedencia)
                .HasForeignKey(e => e.CodigoProcedencia);

            modelBuilder.Entity<RangoEdad>()
                .Property(e => e.Nombre)
                .IsUnicode(false);

            modelBuilder.Entity<RangoEdad>()
                .HasMany(e => e.Pqrs)
                .WithOptional(e => e.RangoEdad)
                .HasForeignKey(e => e.CodigoRangoEdad);

            modelBuilder.Entity<RangoEdad>()
                .HasMany(e => e.Radicado)
                .WithOptional(e => e.RangoEdad)
                .HasForeignKey(e => e.CodigoRangoEdad);

            modelBuilder.Entity<Remitente>()
                .Property(e => e.Nombre)
                .IsUnicode(false);

            modelBuilder.Entity<Secretaria>()
                .Property(e => e.Nombre)
                .IsUnicode(false);

            modelBuilder.Entity<Secretaria>()
                .Property(e => e.CodigoDependencia)
                .IsUnicode(false);

            modelBuilder.Entity<Secretaria>()
                .Property(e => e.Correo)
                .IsUnicode(false);

            modelBuilder.Entity<Secretaria>()
                .Property(e => e.CargoAprobadorRemplazo)
                .IsUnicode(false);

            modelBuilder.Entity<Secretaria>()
                .Property(e => e.Contacto)
                .IsUnicode(false);

            modelBuilder.Entity<Sexo>()
                .Property(e => e.Nombre)
                .IsUnicode(false);

            modelBuilder.Entity<Sexo>()
                .HasMany(e => e.Pqrs)
                .WithOptional(e => e.Sexo)
                .HasForeignKey(e => e.CodigoSexo);

            modelBuilder.Entity<Sexo>()
                .HasMany(e => e.Radicado)
                .WithOptional(e => e.Sexo)
                .HasForeignKey(e => e.CodigoSexo);

            modelBuilder.Entity<SituacionDiscapacidad>()
                .Property(e => e.Nombre)
                .IsUnicode(false);

            modelBuilder.Entity<SituacionDiscapacidad>()
                .HasMany(e => e.Pqrs)
                .WithOptional(e => e.SituacionDiscapacidad)
                .HasForeignKey(e => e.CodigoSituacionDiscapacidad);

            modelBuilder.Entity<SituacionDiscapacidad>()
                .HasMany(e => e.Radicado)
                .WithOptional(e => e.SituacionDiscapacidad)
                .HasForeignKey(e => e.CodigoSituacionDiscapacidad);

            modelBuilder.Entity<SubGrupo>()
                .Property(e => e.Nombre)
                .IsUnicode(false);

            modelBuilder.Entity<SubTipoDocumento>()
                .Property(e => e.Nombre)
                .IsUnicode(false);

            modelBuilder.Entity<SubTipoDocumento>()
                .Property(e => e.GrupoValidadores)
                .IsUnicode(false);

            modelBuilder.Entity<SubTipoDocumento>()
                .HasMany(e => e.Radicado)
                .WithOptional(e => e.SubTipoDocumento)
                .HasForeignKey(e => e.CodigoSubTipoDocumento);

            modelBuilder.Entity<SujetoEspecialProteccion>()
                .Property(e => e.Nombre)
                .IsUnicode(false);

            modelBuilder.Entity<SujetoEspecialProteccion>()
                .HasMany(e => e.Pqrs)
                .WithOptional(e => e.SujetoEspecialProteccion)
                .HasForeignKey(e => e.CodigoSujetoEspecialProteccion);

            modelBuilder.Entity<SujetoEspecialProteccion>()
                .HasMany(e => e.Radicado)
                .WithOptional(e => e.SujetoEspecialProteccion)
                .HasForeignKey(e => e.CodigoSujetoEspecialProteccion);

            modelBuilder.Entity<TipoCorreo>()
                .Property(e => e.Nombre)
                .IsUnicode(false);

            modelBuilder.Entity<TipoCorreo>()
                .HasMany(e => e.RespuestaCorreoCertificado)
                .WithRequired(e => e.TipoCorreo)
                .HasForeignKey(e => e.CodigoTipoCorreo)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<TipoDireccion>()
                .Property(e => e.NombreTipoDireccion)
                .IsUnicode(false);

            modelBuilder.Entity<TipoDocumento>()
                .Property(e => e.Nombre)
                .IsUnicode(false);

            modelBuilder.Entity<TipoDocumento>()
                .Property(e => e.GrupoValidadores)
                .IsUnicode(false);

            modelBuilder.Entity<TipoDocumento>()
                .HasMany(e => e.SubTipoDocumento)
                .WithOptional(e => e.TipoDocumento)
                .HasForeignKey(e => e.CodigoTipoDocumento);

            modelBuilder.Entity<TipoDocumento>()
                .HasMany(e => e.Radicado)
                .WithOptional(e => e.TipoDocumento)
                .HasForeignKey(e => e.CodigoTipoDocumento);

            modelBuilder.Entity<TipoDocumentoIdentificacion>()
                .Property(e => e.Nombre)
                .IsUnicode(false);

            modelBuilder.Entity<TipoDocumentoIdentificacion>()
                .HasMany(e => e.Pqrs)
                .WithOptional(e => e.TipoDocumentoIdentificacion)
                .HasForeignKey(e => e.CodigoTipoDocumentoIdentificacion);

            modelBuilder.Entity<TipoDocumentoIdentificacion>()
                .HasMany(e => e.Radicado)
                .WithOptional(e => e.TipoDocumentoIdentificacion)
                .HasForeignKey(e => e.CodigoTipoDocumentoIdentificacion);

            modelBuilder.Entity<TipoNotificacion>()
                .Property(e => e.Nombre)
                .IsUnicode(false);

            modelBuilder.Entity<TipoNotificacion>()
                .HasMany(e => e.Notificacion)
                .WithRequired(e => e.TipoNotificacion)
                .HasForeignKey(e => e.CodigoTipoNotificacion)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<TipoOficio>()
                .Property(e => e.Nombre)
                .IsUnicode(false);

            modelBuilder.Entity<TipoOficio>()
                .HasMany(e => e.RadicadoInterno)
                .WithOptional(e => e.TipoOficio)
                .HasForeignKey(e => e.CodigoTipoOficio);

            modelBuilder.Entity<TipoPeticion>()
                .Property(e => e.Nombre)
                .IsUnicode(false);

            modelBuilder.Entity<TipoPeticion>()
                .HasMany(e => e.ClasificacionPeticion)
                .WithRequired(e => e.TipoPeticion)
                .HasForeignKey(e => e.CodigoTipoPeticion)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<TipoPqrs>()
                .Property(e => e.Nombre)
                .IsUnicode(false);

            modelBuilder.Entity<TipoPqrs>()
                .Property(e => e.GrupoValidadores)
                .IsUnicode(false);

            modelBuilder.Entity<TipoPqrs>()
                .HasMany(e => e.Pqrs)
                .WithOptional(e => e.TipoPqrs)
                .HasForeignKey(e => e.CodigoTipoPqrs);

            modelBuilder.Entity<TipoPqrs>()
                .HasMany(e => e.Radicado)
                .WithOptional(e => e.TipoPqrs)
                .HasForeignKey(e => e.CodigoTipoPqrs);

            modelBuilder.Entity<TipoSolicitante>()
                .Property(e => e.NombreTipoSolicitante)
                .IsUnicode(false);

            modelBuilder.Entity<TipoSolicitante>()
                .HasMany(e => e.Pqrs)
                .WithOptional(e => e.TipoSolicitante)
                .HasForeignKey(e => e.CodigoTipoSolicitante);

            modelBuilder.Entity<TipoSolicitante>()
                .HasMany(e => e.Radicado)
                .WithOptional(e => e.TipoSolicitante)
                .HasForeignKey(e => e.CodigoTipoSolicitante);

            modelBuilder.Entity<TipoTramite>()
                .Property(e => e.Nombre)
                .IsUnicode(false);

            modelBuilder.Entity<TipoTramite>()
                .HasMany(e => e.TipoDocumento)
                .WithOptional(e => e.TipoTramite)
                .HasForeignKey(e => e.CodigoTipoTramite);

            modelBuilder.Entity<TipoTramite>()
                .HasMany(e => e.Pqrs)
                .WithOptional(e => e.TipoTramite)
                .HasForeignKey(e => e.CodigoTipoTramite);

            modelBuilder.Entity<TipoTramite>()
                .HasMany(e => e.Radicado)
                .WithOptional(e => e.TipoTramite)
                .HasForeignKey(e => e.CodigoTipoTramite);

            modelBuilder.Entity<ClasificacionPeticion>()
                .Property(e => e.DescripcionAsesoria)
                .IsUnicode(false);

            modelBuilder.Entity<ClasificacionPeticion>()
                .Property(e => e.Observaciones)
                .IsUnicode(false);

            modelBuilder.Entity<ClasificacionPeticion>()
                .Property(e => e.NombreUsuarioCreacion)
                .IsUnicode(false);

            modelBuilder.Entity<ClasificacionPeticion>()
                .Property(e => e.IDUsuarioCreacion)
                .IsUnicode(false);

            modelBuilder.Entity<ClasificacionPeticion>()
                .Property(e => e.NombreUsuarioModifica)
                .IsUnicode(false);

            modelBuilder.Entity<DerechosClasificacion>()
                .Property(e => e.NombreUsuarioCreacion)
                .IsUnicode(false);

            modelBuilder.Entity<DerechosClasificacion>()
                .Property(e => e.IDUsuarioCreacion)
                .IsUnicode(false);

            modelBuilder.Entity<DerechosClasificacion>()
                .Property(e => e.NombreUsuarioModifica)
                .IsUnicode(false);

            modelBuilder.Entity<ExternalServiceToken>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<ExternalServiceToken>()
                .Property(e => e.RefreshToken)
                .IsUnicode(false);

            modelBuilder.Entity<Pqrs>()
                .Property(e => e.NombreEntidad)
                .IsUnicode(false);

            modelBuilder.Entity<Pqrs>()
                .Property(e => e.NombreSecretaria)
                .IsUnicode(false);

            modelBuilder.Entity<Pqrs>()
                .Property(e => e.NumeroDocumentoIdentificacion)
                .IsUnicode(false);

            modelBuilder.Entity<Pqrs>()
                .Property(e => e.NombreCompleto)
                .IsUnicode(false);

            modelBuilder.Entity<Pqrs>()
                .Property(e => e.Correo)
                .IsUnicode(false);

            modelBuilder.Entity<Pqrs>()
                .Property(e => e.Telefono)
                .IsUnicode(false);

            modelBuilder.Entity<Pqrs>()
                .Property(e => e.Direccion)
                .IsUnicode(false);

            modelBuilder.Entity<Pqrs>()
                .Property(e => e.GrupoEtnicoIndigenaComunidad)
                .IsUnicode(false);

            modelBuilder.Entity<Pqrs>()
                .Property(e => e.GrupoEtnicoCual)
                .IsUnicode(false);

            modelBuilder.Entity<Pqrs>()
                .Property(e => e.GrupoEtnicoConsejoComunitario)
                .IsUnicode(false);

            modelBuilder.Entity<Pqrs>()
                .Property(e => e.GrupoEtnicoTerritorioColectivo)
                .IsUnicode(false);

            modelBuilder.Entity<Pqrs>()
                .Property(e => e.CodigoPostal)
                .IsUnicode(false);

            modelBuilder.Entity<Pqrs>()
                .Property(e => e.DescripcionHechos)
                .IsUnicode(false);

            modelBuilder.Entity<Pqrs>()
                .Property(e => e.DescripcionSolicitud)
                .IsUnicode(false);

            modelBuilder.Entity<Pqrs>()
                .Property(e => e.SistemaGenera)
                .IsUnicode(false);

            modelBuilder.Entity<Pqrs>()
                .Property(e => e.NombreUsuarioCreacion)
                .IsUnicode(false);

            modelBuilder.Entity<Pqrs>()
                .Property(e => e.IDUsuarioCreacion)
                .IsUnicode(false);

            modelBuilder.Entity<PqrsDocumento>()
                .Property(e => e.RutaFisicaArchivo)
                .IsUnicode(false);

            modelBuilder.Entity<PqrsDocumento>()
                .Property(e => e.RutaVirtualArchivo)
                .IsUnicode(false);

            modelBuilder.Entity<PqrsDocumento>()
                .Property(e => e.TituloArchivo)
                .IsUnicode(false);

            modelBuilder.Entity<PqrsDocumento>()
                .Property(e => e.NombreUsuarioCreacion)
                .IsUnicode(false);

            modelBuilder.Entity<PqrsDocumento>()
                .Property(e => e.IDUsuarioCreacion)
                .IsUnicode(false);

            modelBuilder.Entity<Radicado>()
                .Property(e => e.NumeroRadicado)
                .IsUnicode(false);

            modelBuilder.Entity<Radicado>()
                .Property(e => e.NumeroRadicadoTemporal)
                .IsUnicode(false);

            modelBuilder.Entity<Radicado>()
                .Property(e => e.NumeroRadicadoDepartamental)
                .IsUnicode(false);

            modelBuilder.Entity<Radicado>()
                .Property(e => e.Remitente)
                .IsUnicode(false);

            modelBuilder.Entity<Radicado>()
                .Property(e => e.Asunto)
                .IsUnicode(false);

            modelBuilder.Entity<Radicado>()
                .Property(e => e.Direccion)
                .IsUnicode(false);

            modelBuilder.Entity<Radicado>()
                .Property(e => e.Telefono)
                .IsUnicode(false);

            modelBuilder.Entity<Radicado>()
                .Property(e => e.NombreEntidad)
                .IsUnicode(false);

            modelBuilder.Entity<Radicado>()
                .Property(e => e.NombreSecretaria)
                .IsUnicode(false);

            modelBuilder.Entity<Radicado>()
                .Property(e => e.Correo)
                .IsUnicode(false);

            modelBuilder.Entity<Radicado>()
                .Property(e => e.Anexos)
                .IsUnicode(false);

            modelBuilder.Entity<Radicado>()
                .Property(e => e.RutaFisicaBarcode)
                .IsUnicode(false);

            modelBuilder.Entity<Radicado>()
                .Property(e => e.RutaVirtualBarcode)
                .IsUnicode(false);

            modelBuilder.Entity<Radicado>()
                .Property(e => e.RutaFisicaBarcodeDepartamental)
                .IsUnicode(false);

            modelBuilder.Entity<Radicado>()
                .Property(e => e.RutaVirtualBarcodeDepartamental)
                .IsUnicode(false);

            modelBuilder.Entity<Radicado>()
                .Property(e => e.DatosFuente)
                .IsUnicode(false);

            modelBuilder.Entity<Radicado>()
                .Property(e => e.NombreUsuarioCreacion)
                .IsUnicode(false);

            modelBuilder.Entity<Radicado>()
                .Property(e => e.IDUsuarioCreacion)
                .IsUnicode(false);

            modelBuilder.Entity<Radicado>()
                .Property(e => e.HashAprobacion)
                .IsUnicode(false);

            modelBuilder.Entity<Radicado>()
                .Property(e => e.IPAprobacion)
                .IsUnicode(false);

            modelBuilder.Entity<Radicado>()
                .Property(e => e.GrupoEtnicoIndigenaComunidad)
                .IsUnicode(false);

            modelBuilder.Entity<Radicado>()
                .Property(e => e.GrupoEtnicoCual)
                .IsUnicode(false);

            modelBuilder.Entity<Radicado>()
                .Property(e => e.GrupoEtnicoConsejoComunitario)
                .IsUnicode(false);

            modelBuilder.Entity<Radicado>()
                .Property(e => e.GrupoEtnicoTerritorioColectivo)
                .IsUnicode(false);

            modelBuilder.Entity<Radicado>()
                .Property(e => e.SistemaGenera)
                .IsUnicode(false);

            modelBuilder.Entity<Radicado>()
                .Property(e => e.NumeroDocumentoIdentificacion)
                .IsUnicode(false);

            modelBuilder.Entity<Radicado>()
                .Property(e => e.Resumen)
                .IsUnicode(false);

            modelBuilder.Entity<Radicado>()
                .Property(e => e.DescripcionHechos)
                .IsUnicode(false);

            modelBuilder.Entity<Radicado>()
                .Property(e => e.DescripcionSolicitud)
                .IsUnicode(false);

            modelBuilder.Entity<Radicado>()
                .Property(e => e.Observaciones)
                .IsUnicode(false);

            modelBuilder.Entity<Radicado>()
                .HasOptional(e => e.ClasificacionPeticion)
                .WithRequired(e => e.Radicado);

            modelBuilder.Entity<Radicado>()
                .HasMany(e => e.DerechosClasificacion)
                .WithRequired(e => e.Radicado)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<RadicadoAdicional>()
                .Property(e => e.NombreSecretaria)
                .IsUnicode(false);

            modelBuilder.Entity<RadicadoAdicional>()
                .Property(e => e.Correo)
                .IsUnicode(false);

            modelBuilder.Entity<RadicadoDocumento>()
                .Property(e => e.RutaFisicaArchivo)
                .IsUnicode(false);

            modelBuilder.Entity<RadicadoDocumento>()
                .Property(e => e.RutaVirtualArchivo)
                .IsUnicode(false);

            modelBuilder.Entity<RadicadoDocumento>()
                .Property(e => e.TituloArchivo)
                .IsUnicode(false);

            modelBuilder.Entity<RadicadoDocumento>()
                .Property(e => e.Etapa)
                .IsUnicode(false);

            modelBuilder.Entity<RadicadoDocumento>()
                .Property(e => e.NombreUsuarioCreacion)
                .IsUnicode(false);

            modelBuilder.Entity<RadicadoDocumento>()
                .Property(e => e.IDUsuarioCreacion)
                .IsUnicode(false);

            modelBuilder.Entity<RadicadoInterno>()
                .Property(e => e.NumeroRadicado)
                .IsUnicode(false);

            modelBuilder.Entity<RadicadoInterno>()
                .Property(e => e.NombreEntidad)
                .IsUnicode(false);

            modelBuilder.Entity<RadicadoInterno>()
                .Property(e => e.NombreSecretaria)
                .IsUnicode(false);

            modelBuilder.Entity<RadicadoInterno>()
                .Property(e => e.Calificativo)
                .IsUnicode(false);

            modelBuilder.Entity<RadicadoInterno>()
                .Property(e => e.Nombre)
                .IsUnicode(false);

            modelBuilder.Entity<RadicadoInterno>()
                .Property(e => e.Cargo)
                .IsUnicode(false);

            modelBuilder.Entity<RadicadoInterno>()
                .Property(e => e.Correo)
                .IsUnicode(false);

            modelBuilder.Entity<RadicadoInterno>()
                .Property(e => e.RutaFisicaDocumento)
                .IsUnicode(false);

            modelBuilder.Entity<RadicadoInterno>()
                .Property(e => e.RutaVirtualDocumento)
                .IsUnicode(false);

            modelBuilder.Entity<RadicadoInterno>()
                .Property(e => e.AsuntoDocumento)
                .IsUnicode(false);

            modelBuilder.Entity<RadicadoInterno>()
                .Property(e => e.CuerpoDocumento)
                .IsUnicode(false);

            modelBuilder.Entity<RadicadoInterno>()
                .Property(e => e.NombreSecretariaSolicitarInformaciones)
                .IsUnicode(false);

            modelBuilder.Entity<RadicadoInterno>()
                .Property(e => e.NombreUsuarioCreacion)
                .IsUnicode(false);

            modelBuilder.Entity<RadicadoInterno>()
                .Property(e => e.IDUsuarioCreacion)
                .IsUnicode(false);

            modelBuilder.Entity<RadicadoInterno>()
                .Property(e => e.NombreUsuarioProyectar)
                .IsUnicode(false);

            modelBuilder.Entity<RadicadoInterno>()
                .Property(e => e.IDUsuarioProyectar)
                .IsUnicode(false);

            modelBuilder.Entity<RadicadoInterno>()
                .Property(e => e.CodigoFirmaUsuarioProyectar)
                .IsUnicode(false);

            modelBuilder.Entity<RadicadoInterno>()
                .Property(e => e.NombreUsuarioRevisar)
                .IsUnicode(false);

            modelBuilder.Entity<RadicadoInterno>()
                .Property(e => e.IDUsuarioRevisar)
                .IsUnicode(false);

            modelBuilder.Entity<RadicadoInterno>()
                .Property(e => e.CodigoFirmaUsuarioRevisar)
                .IsFixedLength();

            modelBuilder.Entity<RadicadoInterno>()
                .Property(e => e.NombreUsuarioAprobacion)
                .IsUnicode(false);

            modelBuilder.Entity<RadicadoInterno>()
                .Property(e => e.IDUsuarioAprobacion)
                .IsUnicode(false);

            modelBuilder.Entity<RadicadoInterno>()
                .Property(e => e.CargoUsuarioAprobacion)
                .IsUnicode(false);

            modelBuilder.Entity<RadicadoInterno>()
                .Property(e => e.CodigoFirmaUsuarioAprobacion)
                .IsUnicode(false);

            modelBuilder.Entity<RadicadoInterno>()
                .Property(e => e.HashAprobacion)
                .IsUnicode(false);

            modelBuilder.Entity<RadicadoInterno>()
                .Property(e => e.IPAprobacion)
                .IsUnicode(false);

            modelBuilder.Entity<RadicadoInternoAdicional>()
                .Property(e => e.NombreSecretariaSolicitarInformaciones)
                .IsUnicode(false);

            modelBuilder.Entity<RadicadoInternoAdicional>()
                .Property(e => e.Calificativo)
                .IsUnicode(false);

            modelBuilder.Entity<RadicadoInternoAdicional>()
                .Property(e => e.Nombre)
                .IsUnicode(false);

            modelBuilder.Entity<RadicadoInternoAdicional>()
                .Property(e => e.Cargo)
                .IsUnicode(false);

            modelBuilder.Entity<RadicadoInternoAdicional>()
                .Property(e => e.Correo)
                .IsUnicode(false);

            modelBuilder.Entity<RadicadoInternoAdicional>()
                .Property(e => e.RutaFisicaDocumento)
                .IsUnicode(false);

            modelBuilder.Entity<RadicadoInternoAdicional>()
                .Property(e => e.RutaVirtualDocumento)
                .IsUnicode(false);

            modelBuilder.Entity<RadicadoInternoDocumento>()
                .Property(e => e.RutaFisicaArchivo)
                .IsUnicode(false);

            modelBuilder.Entity<RadicadoInternoDocumento>()
                .Property(e => e.RutaVirtualArchivo)
                .IsUnicode(false);

            modelBuilder.Entity<RadicadoInternoDocumento>()
                .Property(e => e.TituloArchivo)
                .IsUnicode(false);

            modelBuilder.Entity<RadicadoInternoDocumento>()
                .Property(e => e.Etapa)
                .IsUnicode(false);

            modelBuilder.Entity<RadicadoInternoDocumento>()
                .Property(e => e.NombreUsuarioCreacion)
                .IsUnicode(false);

            modelBuilder.Entity<RadicadoInternoDocumento>()
                .Property(e => e.IDUsuarioCreacion)
                .IsUnicode(false);

            modelBuilder.Entity<Respuesta>()
                .Property(e => e.NumeroRadicado)
                .IsUnicode(false);

            modelBuilder.Entity<Respuesta>()
                .Property(e => e.NombreEntidad)
                .IsUnicode(false);

            modelBuilder.Entity<Respuesta>()
                .Property(e => e.NombreSecretaria)
                .IsUnicode(false);

            modelBuilder.Entity<Respuesta>()
                .Property(e => e.Calificativo)
                .IsUnicode(false);

            modelBuilder.Entity<Respuesta>()
                .Property(e => e.Nombre)
                .IsUnicode(false);

            modelBuilder.Entity<Respuesta>()
                .Property(e => e.Cargo)
                .IsUnicode(false);

            modelBuilder.Entity<Respuesta>()
                .Property(e => e.Ciudad)
                .IsUnicode(false);

            modelBuilder.Entity<Respuesta>()
                .Property(e => e.Correo)
                .IsUnicode(false);

            modelBuilder.Entity<Respuesta>()
                .Property(e => e.Anexos)
                .IsUnicode(false);

            modelBuilder.Entity<Respuesta>()
                .Property(e => e.RutaFisicaDocumento)
                .IsUnicode(false);

            modelBuilder.Entity<Respuesta>()
                .Property(e => e.RutaVirtualDocumento)
                .IsUnicode(false);

            modelBuilder.Entity<Respuesta>()
                .Property(e => e.UrlParaFirma)
                .IsUnicode(false);

            modelBuilder.Entity<Respuesta>()
                .Property(e => e.RutaFisicaDocumentoSinFirma)
                .IsUnicode(false);

            modelBuilder.Entity<Respuesta>()
                .Property(e => e.RutaVirtualDocumentoSinFirma)
                .IsUnicode(false);

            modelBuilder.Entity<Respuesta>()
                .Property(e => e.AsuntoDocumento)
                .IsUnicode(false);

            modelBuilder.Entity<Respuesta>()
                .Property(e => e.CuerpoDocumento)
                .IsUnicode(false);

            modelBuilder.Entity<Respuesta>()
                .Property(e => e.NumeroGuia)
                .IsUnicode(false);

            modelBuilder.Entity<Respuesta>()
                .Property(e => e.NombreUsuarioCreacion)
                .IsUnicode(false);

            modelBuilder.Entity<Respuesta>()
                .Property(e => e.IDUsuarioCreacion)
                .IsUnicode(false);

            modelBuilder.Entity<Respuesta>()
                .Property(e => e.NombreUsuarioProyectar)
                .IsUnicode(false);

            modelBuilder.Entity<Respuesta>()
                .Property(e => e.IDUsuarioProyectar)
                .IsUnicode(false);

            modelBuilder.Entity<Respuesta>()
                .Property(e => e.CodigoFirmaUsuarioProyectar)
                .IsUnicode(false);

            modelBuilder.Entity<Respuesta>()
                .Property(e => e.NombreUsuarioRevisar)
                .IsUnicode(false);

            modelBuilder.Entity<Respuesta>()
                .Property(e => e.IDUsuarioRevisar)
                .IsUnicode(false);

            modelBuilder.Entity<Respuesta>()
                .Property(e => e.CodigoFirmaUsuarioRevisar)
                .IsUnicode(false);

            modelBuilder.Entity<Respuesta>()
                .Property(e => e.NombreUsuarioAprobacion)
                .IsUnicode(false);

            modelBuilder.Entity<Respuesta>()
                .Property(e => e.IDUsuarioAprobacion)
                .IsUnicode(false);

            modelBuilder.Entity<Respuesta>()
                .Property(e => e.CargoUsuarioAprobacion)
                .IsUnicode(false);

            modelBuilder.Entity<Respuesta>()
                .Property(e => e.CodigoFirmaUsuarioAprobacion)
                .IsUnicode(false);

            modelBuilder.Entity<Respuesta>()
                .Property(e => e.HashAprobacion)
                .IsUnicode(false);

            modelBuilder.Entity<Respuesta>()
                .Property(e => e.IPAprobacion)
                .IsUnicode(false);

            modelBuilder.Entity<Respuesta>()
                .Property(e => e.RutaFisicaBarcode)
                .IsUnicode(false);

            modelBuilder.Entity<Respuesta>()
                .Property(e => e.RutaVirtualBarcode)
                .IsUnicode(false);

            modelBuilder.Entity<Respuesta>()
                .Property(e => e.Telefono)
                .HasPrecision(18, 0);

            modelBuilder.Entity<Respuesta>()
                .Property(e => e.NombreDefensor)
                .IsUnicode(false);

            modelBuilder.Entity<Respuesta>()
                .Property(e => e.HoraCita)
                .IsUnicode(false);

            modelBuilder.Entity<Respuesta>()
                .Property(e => e.CuerpoEmail)
                .IsUnicode(false);

            modelBuilder.Entity<RespuestaAdicional>()
                .Property(e => e.Calificativo)
                .IsUnicode(false);

            modelBuilder.Entity<RespuestaAdicional>()
                .Property(e => e.Nombre)
                .IsUnicode(false);

            modelBuilder.Entity<RespuestaAdicional>()
                .Property(e => e.Cargo)
                .IsUnicode(false);

            modelBuilder.Entity<RespuestaAdicional>()
                .Property(e => e.Entidad)
                .IsUnicode(false);

            modelBuilder.Entity<RespuestaAdicional>()
                .Property(e => e.Ciudad)
                .IsUnicode(false);

            modelBuilder.Entity<RespuestaAdicional>()
                .Property(e => e.Correo)
                .IsUnicode(false);

            modelBuilder.Entity<RespuestaAdicional>()
                .Property(e => e.NombreSolicitudOriginal)
                .IsUnicode(false);

            modelBuilder.Entity<RespuestaCorreoCertificado>()
                .Property(e => e.Asunto)
                .IsUnicode(false);

            modelBuilder.Entity<RespuestaCorreoCertificado>()
                .Property(e => e.Cuerpo)
                .IsUnicode(false);

            modelBuilder.Entity<RespuestaCorreoCertificado>()
                .Property(e => e.NombreDestinatario)
                .IsUnicode(false);

            modelBuilder.Entity<RespuestaCorreoCertificado>()
                .Property(e => e.CorreoDestinatario)
                .IsUnicode(false);

            modelBuilder.Entity<RespuestaCorreoCertificado>()
                .Property(e => e.Adjunto)
                .IsUnicode(false);

            modelBuilder.Entity<RespuestaCorreoCertificado>()
                .Property(e => e.NombreAdjunto)
                .IsUnicode(false);

            modelBuilder.Entity<RespuestaCorreoCertificado>()
                .Property(e => e.RutaFisicaDocumento)
                .IsUnicode(false);

            modelBuilder.Entity<RespuestaCorreoCertificado>()
                .Property(e => e.RutaVirtualDocumento)
                .IsUnicode(false);

            modelBuilder.Entity<RespuestaCorreoCertificado>()
                .Property(e => e.NombreUsuarioCreacion)
                .IsUnicode(false);

            modelBuilder.Entity<RespuestaCorreoCertificado>()
                .Property(e => e.IDUsuarioCreacion)
                .IsUnicode(false);

            modelBuilder.Entity<RespuestaDocumento>()
                .Property(e => e.RutaFisicaArchivo)
                .IsUnicode(false);

            modelBuilder.Entity<RespuestaDocumento>()
                .Property(e => e.RutaVirtualArchivo)
                .IsUnicode(false);

            modelBuilder.Entity<RespuestaDocumento>()
                .Property(e => e.TituloArchivo)
                .IsUnicode(false);

            modelBuilder.Entity<RespuestaDocumento>()
                .Property(e => e.Etapa)
                .IsUnicode(false);

            modelBuilder.Entity<RespuestaDocumento>()
                .Property(e => e.NombreUsuarioCreacion)
                .IsUnicode(false);

            modelBuilder.Entity<RespuestaDocumento>()
                .Property(e => e.IDUsuarioCreacion)
                .IsUnicode(false);

            modelBuilder.Entity<BIS>()
                .Property(e => e.Nombre)
                .IsUnicode(false);

            modelBuilder.Entity<Cardinalidad>()
                .Property(e => e.Nombre)
                .IsUnicode(false);

            modelBuilder.Entity<Condicion>()
                .Property(e => e.Nombre)
                .IsUnicode(false);

            modelBuilder.Entity<Letra>()
                .Property(e => e.Codigo)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Letra>()
                .Property(e => e.Nombre)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<TipoFirma>()
                .Property(e => e.Nombre)
                .IsUnicode(false);

            modelBuilder.Entity<Via>()
                .Property(e => e.Nombre)
                .IsUnicode(false);

            modelBuilder.Entity<Vivienda>()
                .Property(e => e.Nombre)
                .IsUnicode(false);
        }
    }
}