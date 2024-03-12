using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using AtencionTramites.Model.ModelAtencionTramites;

namespace AtencionTramites.Model.DAL
{
	public class PqrsDAL
	{
		public Pqrs ObtenerPqrs(DbAtencionTramites db, long CodigoSolicitud)
		{
			if (CodigoSolicitud == 0L)
			{
				return null;
			}
			Pqrs ret = (from Pqrs in db.Pqrs.Include((Pqrs q) => q.Genero).Include((Pqrs q) => q.TipoSolicitante).Include((Pqrs q) => q.TipoDocumentoIdentificacion)
					.Include((Pqrs q) => q.GrupoEtnico)
					.Include((Pqrs q) => q.SujetoEspecialProteccion)
					.Include((Pqrs q) => q.MedioRespuesta)
					.Include((Pqrs q) => q.TipoPqrs)
					.Include((Pqrs q) => q.NivelEstudios)
					.Include((Pqrs q) => q.EstadoCivil)
					.Include((Pqrs q) => q.Sexo)
					.Include((Pqrs q) => q.OrientacionSexual)
					.Include((Pqrs q) => q.Procedencia)
					.Include((Pqrs q) => q.RangoEdad)
					.AsNoTracking()
				where Pqrs.CodigoSolicitud == CodigoSolicitud
				select Pqrs).FirstOrDefault();
			if (ret != null)
			{
				ret.PqrsDocumento = (from q in db.PqrsDocumento.AsNoTracking()
					where q.CodigoSolicitud == CodigoSolicitud
					select q).ToList();
			}
			LlenarPqrs(ret);
			return ret;
		}

		public List<Pqrs> ObtenerPqrsParaProcesar(DbAtencionTramites db)
		{
			List<Pqrs> ret = (from Pqrs in db.Pqrs.Include((Pqrs q) => q.Genero).Include((Pqrs q) => q.TipoSolicitante).Include((Pqrs q) => q.TipoDocumentoIdentificacion)
					.Include((Pqrs q) => q.MedioRespuesta)
					.Include((Pqrs q) => q.TipoPqrs)
					.Include((Pqrs q) => q.Pais)
					.Include((Pqrs q) => q.Departamento)
					.Include((Pqrs q) => q.Ciudad)
					.Include((Pqrs q) => q.SujetoEspecialProteccion)
					.Include((Pqrs q) => q.GrupoEtnico)
					.Include((Pqrs q) => q.NivelEstudios)
					.Include((Pqrs q) => q.EstadoCivil)
					.Include((Pqrs q) => q.Sexo)
					.Include((Pqrs q) => q.OrientacionSexual)
					.Include((Pqrs q) => q.Procedencia)
					.Include((Pqrs q) => q.RangoEdad)
				where Pqrs.CodigoEstadoPqrs == (int?)1
				select Pqrs).ToList();
			LlenarPqrsList(ret);
			return ret;
		}

		public void LlenarPqrsList(List<Pqrs> PqrsList)
		{
			if (PqrsList == null)
			{
				return;
			}
			foreach (Pqrs Pqrs in PqrsList)
			{
				LlenarPqrs(Pqrs);
			}
		}

		public void LlenarPqrs(Pqrs Pqrs)
		{
			if (Pqrs != null)
			{
				if (Pqrs.Genero != null)
				{
					Pqrs.NombreGenero = Pqrs.Genero.Nombre;
					Pqrs.Genero = null;
				}
				if (Pqrs.TipoSolicitante != null)
				{
					Pqrs.NombreTipoSolicitante = Pqrs.TipoSolicitante.NombreTipoSolicitante;
					Pqrs.TipoSolicitante = null;
				}
				if (Pqrs.TipoDocumentoIdentificacion != null)
				{
					Pqrs.NombreTipoDocumentoIdentificacion = Pqrs.TipoDocumentoIdentificacion.Nombre;
					Pqrs.TipoDocumentoIdentificacion = null;
				}
				if (Pqrs.MedioRespuesta != null)
				{
					Pqrs.NombreMedioRespuesta = Pqrs.MedioRespuesta.Nombre;
					Pqrs.MedioRespuesta = null;
				}
				if (Pqrs.TipoPqrs != null)
				{
					Pqrs.NombreTipoPqrs = Pqrs.TipoPqrs.Nombre;
					Pqrs.TipoPqrs = null;
				}
				if (Pqrs.GrupoEtnico != null)
				{
					Pqrs.NombreGrupoEtnico = Pqrs.GrupoEtnico.Nombre;
					Pqrs.GrupoEtnico = null;
				}
				if (Pqrs.Pais != null)
				{
					Pqrs.NombrePais = Pqrs.Pais.NombrePais;
					Pqrs.Pais = null;
				}
				if (Pqrs.Departamento != null)
				{
					Pqrs.NombreDepartamento = Pqrs.Departamento.Nombre;
					Pqrs.Departamento = null;
				}
				if (Pqrs.Ciudad != null)
				{
					Pqrs.NombreCiudad = Pqrs.Ciudad.Nombre;
					Pqrs.Ciudad = null;
				}
				if (Pqrs.SujetoEspecialProteccion != null)
				{
					Pqrs.NombreSujetoEspecialProteccion = Pqrs.SujetoEspecialProteccion.Nombre;
					Pqrs.SujetoEspecialProteccion = null;
				}
				if (Pqrs.NivelEstudios != null)
				{
					Pqrs.NombreNivelEstudios = Pqrs.NivelEstudios.Nombre;
					Pqrs.NivelEstudios = null;
				}
				if (Pqrs.EstadoCivil != null)
				{
					Pqrs.NombreEstadoCivil = Pqrs.EstadoCivil.Nombre;
					Pqrs.EstadoCivil = null;
				}
				if (Pqrs.Sexo != null)
				{
					Pqrs.NombreSexo = Pqrs.Sexo.Nombre;
					Pqrs.Sexo = null;
				}
				if (Pqrs.OrientacionSexual != null)
				{
					Pqrs.NombreOrientacionSexual = Pqrs.OrientacionSexual.Nombre;
					Pqrs.OrientacionSexual = null;
				}
				if (Pqrs.Procedencia != null)
				{
					Pqrs.NombreProcedencia = Pqrs.Procedencia.Nombre;
					Pqrs.Procedencia = null;
				}
				if (Pqrs.RangoEdad != null)
				{
					Pqrs.NombreRangoEdad = Pqrs.RangoEdad.Nombre;
					Pqrs.RangoEdad = null;
				}
			}
		}
	}
}