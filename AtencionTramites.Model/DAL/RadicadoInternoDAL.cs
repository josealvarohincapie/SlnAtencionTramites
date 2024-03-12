using System.Data.Entity;
using System.Linq;
using AtencionTramites.Model.ModelAtencionTramites;

namespace AtencionTramites.Model.DAL
{
	public class RadicadoInternoDAL
	{
		public RadicadoInterno ObtenerRadicadoInterno(DbAtencionTramites db, long CodigoSolicitud, int CodigoTipo)
		{
			if (CodigoSolicitud == 0L)
			{
				return null;
			}
			RadicadoInterno ret = (from RadicadoInterno in db.RadicadoInterno.Include((RadicadoInterno q) => q.Formato).Include((RadicadoInterno q) => q.TipoOficio).Include((RadicadoInterno q) => q.EstadoTarea)
					.AsNoTracking()
				where RadicadoInterno.CodigoSolicitud == CodigoSolicitud && RadicadoInterno.CodigoTipo == CodigoTipo
				select RadicadoInterno).FirstOrDefault();
			if (ret != null)
			{
				ret.RadicadoInternoAdicional = (from q in db.RadicadoInternoAdicional.AsNoTracking()
					where q.CodigoSolicitud == CodigoSolicitud && q.CodigoTipo == CodigoTipo
					select q).ToList();
				ret.RadicadoInternoDocumento = (from q in db.RadicadoInternoDocumento.AsNoTracking()
					where q.CodigoSolicitud == CodigoSolicitud && q.CodigoTipo == CodigoTipo
					select q).ToList();
			}
			LlenarRadicadoInterno(ret);
			return ret;
		}

		public RadicadoInterno ObtenerRadicadoInterno(DbAtencionTramites db, string NumeroRadicado)
		{
			RadicadoInterno ret = (from RadicadoInterno in db.RadicadoInterno.AsNoTracking()
				where RadicadoInterno.NumeroRadicado.Trim().ToLower() == NumeroRadicado.Trim().ToLower() && RadicadoInterno.CodigoTipo == 1
				select RadicadoInterno).FirstOrDefault();
			LlenarRadicadoInterno(ret);
			return ret;
		}

		public void LlenarRadicadoInterno(RadicadoInterno RadicadoInterno)
		{
			if (RadicadoInterno != null)
			{
				if (RadicadoInterno.Formato != null)
				{
					RadicadoInterno.NombreFormato = RadicadoInterno.Formato.Nombre;
					RadicadoInterno.Formato = null;
				}
				if (RadicadoInterno.TipoOficio != null)
				{
					RadicadoInterno.NombreTipoOficio = RadicadoInterno.TipoOficio.Nombre;
					RadicadoInterno.TipoOficio = null;
				}
				if (RadicadoInterno.EstadoTarea != null)
				{
					RadicadoInterno.NombreEstadoTarea = RadicadoInterno.EstadoTarea.Nombre;
					RadicadoInterno.EstadoTarea = null;
				}
			}
		}
	}
}
