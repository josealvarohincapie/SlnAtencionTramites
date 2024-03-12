using System.Collections.Generic;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using AtencionTramites.Model.Classes;
using AtencionTramites.Model.ModelAtencionTramites;
using Newtonsoft.Json;

namespace AtencionTramites.Model.DAL
{
	public class RadicadoDAL
	{
		public Radicado ObtenerRadicado(DbAtencionTramites db, long CodigoSolicitud)
		{
			if (CodigoSolicitud == 0L)
			{
				return null;
			}
			Radicado ret = (from Radicado in db.Radicado.Include((Radicado q) => q.Fuente).Include((Radicado q) => q.Genero).Include((Radicado q) => q.GrupoEtnico)
					.Include((Radicado q) => q.SituacionDiscapacidad)
					.Include((Radicado q) => q.SujetoEspecialProteccion)
					.Include((Radicado q) => q.TipoDocumento)
					.Include((Radicado q) => q.SubTipoDocumento)
					.Include((Radicado q) => q.EstadoTarea)
					.Include((Radicado q) => q.TipoSolicitante)
					.Include((Radicado q) => q.TipoDocumentoIdentificacion)
					.Include((Radicado q) => q.TipoTramite)
					.Include((Radicado q) => q.MedioRespuesta)
					.Include((Radicado q) => q.TipoPqrs)
					.Include((Radicado q) => q.NivelEstudios)
					.Include((Radicado q) => q.EstadoCivil)
					.Include((Radicado q) => q.Sexo)
					.Include((Radicado q) => q.OrientacionSexual)
					.Include((Radicado q) => q.Procedencia)
					.Include((Radicado q) => q.RangoEdad)
					.Include((Radicado q) => q.Pais)
					.Include((Radicado q) => q.Departamento)
					.Include((Radicado q) => q.Ciudad)
					.Include((Radicado q) => q.Departamento1)
					.Include((Radicado q) => q.Ciudad1)
					.Include((Radicado q) => q.Formato)
					.AsNoTracking()
				where Radicado.CodigoSolicitud == CodigoSolicitud
				select Radicado).FirstOrDefault();
			if (ret != null)
			{
				ret.RadicadoAdicional = (from q in db.RadicadoAdicional.AsNoTracking()
					where q.CodigoSolicitud == CodigoSolicitud
					select q).ToList();
				ret.RadicadoDocumento = (from q in db.RadicadoDocumento.AsNoTracking()
					where q.CodigoSolicitud == CodigoSolicitud
					select q).ToList();
			}
			LlenarRadicado(ret);
			return ret;
		}

		public Radicado ObtenerRadicado(DbAtencionTramites db, int CodigoFuente, string NumeroRadicadoTemporal)
		{
			Radicado ret = (from Radicado in db.Radicado.AsNoTracking()
				where Radicado.CodigoFuente == CodigoFuente && Radicado.NumeroRadicadoTemporal.Trim().ToLower() == NumeroRadicadoTemporal.Trim().ToLower()
				select Radicado).FirstOrDefault();
			LlenarRadicado(ret);
			return ret;
		}

		public Radicado ObtenerRadicado(DbAtencionTramites db, string NumeroRadicado)
		{
			Radicado ret = (from Radicado in db.Radicado.AsNoTracking()
				where Radicado.NumeroRadicado.Trim().ToLower() == NumeroRadicado.Trim().ToLower()
				select Radicado).FirstOrDefault();
			LlenarRadicado(ret);
			return ret;
		}

		public List<RadicadoTramite> CargarTramites(DbAtencionTramites db, string NumeroDocumentoIdentificacion)
		{
			SqlParameter clientIdParameter = new SqlParameter("@NumeroDocumentoIdentificacion", NumeroDocumentoIdentificacion);
			return db.Database.SqlQuery<RadicadoTramite>("CorrTramitesPorIdentificacion @NumeroDocumentoIdentificacion", new object[1] { clientIdParameter }).ToList();
		}

		public void LlenarRadicado(Radicado Radicado)
		{
			if (Radicado == null)
			{
				return;
			}
			if (Radicado.Fuente != null)
			{
				Radicado.NombreFuente = Radicado.Fuente.Nombre;
				Radicado.Fuente = null;
			}
			if (Radicado.Genero != null)
			{
				Radicado.NombreGenero = Radicado.Genero.Nombre;
				Radicado.Genero = null;
			}
			if (Radicado.GrupoEtnico != null)
			{
				Radicado.NombreGrupoEtnico = Radicado.GrupoEtnico.Nombre;
				Radicado.GrupoEtnico = null;
			}
			if (Radicado.SituacionDiscapacidad != null)
			{
				Radicado.NombreSituacionDiscapacidad = Radicado.SituacionDiscapacidad.Nombre;
				Radicado.SituacionDiscapacidad = null;
			}
			if (Radicado.SujetoEspecialProteccion != null)
			{
				Radicado.NombreSujetoEspecialProteccion = Radicado.SujetoEspecialProteccion.Nombre;
				Radicado.SujetoEspecialProteccion = null;
			}
			if (Radicado.TipoDocumento != null)
			{
				Radicado.NombreTipoDocumento = Radicado.TipoDocumento.Nombre;
				Radicado.TipoDocumento = null;
			}
			if (Radicado.SubTipoDocumento != null)
			{
				Radicado.NombreSubTipoDocumento = Radicado.SubTipoDocumento.Nombre;
				Radicado.SubTipoDocumento = null;
			}
			if (Radicado.EstadoTarea != null)
			{
				Radicado.NombreEstadoTarea = Radicado.EstadoTarea.Nombre;
				Radicado.EstadoTarea = null;
			}
			if (Radicado.DatosFuente != null)
			{
				if (Radicado.CodigoFuente == 2)
				{
					Radicado.CorreoFuente = JsonConvert.DeserializeObject<CorreoFuente>(Radicado.DatosFuente);
				}
				else if (Radicado.CodigoFuente == 3)
				{
					Radicado.PqrsFuente = JsonConvert.DeserializeObject<PqrsFuente>(Radicado.DatosFuente);
				}
			}
			if (Radicado.TipoTramite != null)
			{
				Radicado.NombreTipoTramite = Radicado.TipoTramite.Nombre;
				Radicado.TipoTramite = null;
			}
			if (Radicado.TipoSolicitante != null)
			{
				Radicado.NombreTipoSolicitante = Radicado.TipoSolicitante.NombreTipoSolicitante;
				Radicado.TipoSolicitante = null;
			}
			if (Radicado.TipoDocumentoIdentificacion != null)
			{
				Radicado.NombreTipoDocumentoIdentificacion = Radicado.TipoDocumentoIdentificacion.Nombre;
				Radicado.TipoDocumentoIdentificacion = null;
			}
			if (Radicado.MedioRespuesta != null)
			{
				Radicado.NombreMedioRespuesta = Radicado.MedioRespuesta.Nombre;
				Radicado.MedioRespuesta = null;
			}
			if (Radicado.TipoPqrs != null)
			{
				Radicado.NombreTipoPqrs = Radicado.TipoPqrs.Nombre;
				Radicado.TipoPqrs = null;
			}
			if (Radicado.Pais != null)
			{
				Radicado.NombrePais = Radicado.Pais.NombrePais;
				Radicado.Pais = null;
			}
			if (Radicado.Departamento != null)
			{
				Radicado.NombreDepartamento = Radicado.Departamento.Nombre;
				Radicado.Departamento = null;
			}
			if (Radicado.Ciudad != null)
			{
				Radicado.NombreCiudad = Radicado.Ciudad.Nombre;
				Radicado.Ciudad = null;
			}
			if (Radicado.NivelEstudios != null)
			{
				Radicado.NombreNivelEstudios = Radicado.NivelEstudios.Nombre;
				Radicado.NivelEstudios = null;
			}
			if (Radicado.EstadoCivil != null)
			{
				Radicado.NombreEstadoCivil = Radicado.EstadoCivil.Nombre;
				Radicado.EstadoCivil = null;
			}
			if (Radicado.Sexo != null)
			{
				Radicado.NombreSexo = Radicado.Sexo.Nombre;
				Radicado.Sexo = null;
			}
			if (Radicado.OrientacionSexual != null)
			{
				Radicado.NombreOrientacionSexual = Radicado.OrientacionSexual.Nombre;
				Radicado.OrientacionSexual = null;
			}
			if (Radicado.Procedencia != null)
			{
				Radicado.NombreProcedencia = Radicado.Procedencia.Nombre;
				Radicado.Procedencia = null;
			}
			if (Radicado.RangoEdad != null)
			{
				Radicado.NombreRangoEdad = Radicado.RangoEdad.Nombre;
				Radicado.RangoEdad = null;
			}
			if (Radicado.Departamento1 != null)
			{
				Radicado.NombreDepartamentoHechos = Radicado.Departamento1.Nombre;
				Radicado.Departamento1 = null;
			}
			if (Radicado.Ciudad1 != null)
			{
				Radicado.NombreMunicipioHechos = Radicado.Ciudad1.Nombre;
				Radicado.Ciudad1 = null;
			}
			if (Radicado.Formato != null)
			{
				Radicado.NombreFormato = Radicado.Formato.Nombre;
				Radicado.Formato = null;
			}
		}
	}
}
