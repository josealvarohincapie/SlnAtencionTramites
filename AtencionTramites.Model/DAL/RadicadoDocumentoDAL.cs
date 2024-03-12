using System.Collections.Generic;
using System.Linq;
using AtencionTramites.Model.ModelAtencionTramites;

namespace AtencionTramites.Model.DAL
{
	public class RadicadoDocumentoDAL
	{
		public List<RadicadoDocumento> ObtenerRadicadoDocumentoList(DbAtencionTramites db, long CodigoSolicitud)
		{
			if (CodigoSolicitud == 0L)
			{
				return null;
			}
			List<RadicadoDocumento> ret = (from RadicadoDocumento in db.RadicadoDocumento.AsNoTracking()
				where RadicadoDocumento.CodigoSolicitud == CodigoSolicitud
				select RadicadoDocumento).ToList();
			LlenarRadicadoDocumentoList(ret);
			return ret;
		}

		public void LlenarRadicadoDocumentoList(List<RadicadoDocumento> RadicadoDocumentoList)
		{
			if (RadicadoDocumentoList == null)
			{
				return;
			}
			foreach (RadicadoDocumento RadicadoDocumento in RadicadoDocumentoList)
			{
				LlenarRadicadoDocumento(RadicadoDocumento);
			}
		}

		public void LlenarRadicadoDocumento(RadicadoDocumento RadicadoDocumento)
		{
		}
	}
}
