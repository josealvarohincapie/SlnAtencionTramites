using System.Data.Entity;
using System.Linq;
using AtencionTramites.Model.ModelAtencionTramites;

namespace AtencionTramites.Model.DAL
{
	public class RespuestaDAL
	{
		public void ActualizarEnvioFirma(DbAtencionTramites db, Respuesta Respuesta)
		{
			Respuesta ele = db.Respuesta.Where((Respuesta q) => q.CodigoSolicitud == Respuesta.CodigoSolicitud).FirstOrDefault();
			ele.UrlParaFirma = Respuesta.UrlParaFirma;
			ele.IdDocumentoFirmado = Respuesta.IdDocumentoFirmado;
			ele.DocumentoFirmado = Respuesta.DocumentoFirmado;
			ele.RutaFisicaDocumento = Respuesta.RutaFisicaDocumento;
			ele.RutaVirtualDocumento = Respuesta.RutaVirtualDocumento;
			db.Entry(ele).State = EntityState.Modified;
			db.SaveChanges();
		}

		public void ActualizarRecepcionFirma(DbAtencionTramites db, Respuesta Respuesta)
		{
			Respuesta ele = db.Respuesta.Where((Respuesta q) => q.CodigoSolicitud == Respuesta.CodigoSolicitud).FirstOrDefault();
			ele.RutaFisicaDocumento = Respuesta.RutaFisicaDocumento;
			ele.RutaVirtualDocumento = Respuesta.RutaVirtualDocumento;
			ele.RutaFisicaDocumentoSinFirma = Respuesta.RutaFisicaDocumentoSinFirma;
			ele.RutaVirtualDocumentoSinFirma = Respuesta.RutaVirtualDocumentoSinFirma;
			ele.DocumentoFirmado = Respuesta.DocumentoFirmado;
			db.Entry(ele).State = EntityState.Modified;
			db.SaveChanges();
		}

		public Respuesta ObtenerRespuesta(DbAtencionTramites db, long CodigoSolicitud)
		{
			if (CodigoSolicitud == 0L)
			{
				return null;
			}
			Respuesta ret = (from Respuesta in db.Respuesta.Include((Respuesta q) => q.Formato).Include((Respuesta q) => q.EstadoTarea).AsNoTracking()
				where Respuesta.CodigoSolicitud == CodigoSolicitud
				select Respuesta).FirstOrDefault();
			if (ret != null)
			{
				ret.RespuestaDocumento = (from q in db.RespuestaDocumento.AsNoTracking()
					where q.CodigoSolicitud == CodigoSolicitud
					select q).ToList();
				ret.RespuestaAdicional = (from q in db.RespuestaAdicional.AsNoTracking()
					where q.CodigoSolicitud == CodigoSolicitud
					select q).ToList();
			}
			LlenarRespuesta(ret);
			return ret;
		}

		public Respuesta ObtenerRespuestaSolucitudPrincipal(DbAtencionTramites db, long CodigoSolicitudPrincipal)
		{
			if (CodigoSolicitudPrincipal == 0L)
			{
				return null;
			}
			Respuesta ret = (from Respuesta in db.Respuesta.Include((Respuesta q) => q.Formato).Include((Respuesta q) => q.EstadoTarea).AsNoTracking()
				where Respuesta.CodigoSolicitudOriginal == (long?)CodigoSolicitudPrincipal
				select Respuesta).FirstOrDefault();
			if (ret != null)
			{
				ret.RespuestaDocumento = (from q in db.RespuestaDocumento.AsNoTracking()
					where q.CodigoSolicitud == ret.CodigoSolicitud
					select q).ToList();
				ret.RespuestaAdicional = (from q in db.RespuestaAdicional.AsNoTracking()
					where q.CodigoSolicitud == ret.CodigoSolicitud
					select q).ToList();
			}
			LlenarRespuesta(ret);
			return ret;
		}

		public Respuesta ObtenerRespuesta(DbAtencionTramites db, string NumeroRadicado)
		{
			Respuesta ret = (from Respuesta in db.Respuesta.AsNoTracking()
				where Respuesta.NumeroRadicado.Trim().ToLower() == NumeroRadicado.Trim().ToLower()
				select Respuesta).FirstOrDefault();
			LlenarRespuesta(ret);
			return ret;
		}

		public void LlenarRespuesta(Respuesta Respuesta)
		{
			if (Respuesta != null)
			{
				if (Respuesta.Formato != null)
				{
					Respuesta.NombreFormato = Respuesta.Formato.Nombre;
					Respuesta.Formato = null;
				}
				if (Respuesta.EstadoTarea != null)
				{
					Respuesta.NombreEstadoTarea = Respuesta.EstadoTarea.Nombre;
					Respuesta.EstadoTarea = null;
				}
			}
		}
	}
}