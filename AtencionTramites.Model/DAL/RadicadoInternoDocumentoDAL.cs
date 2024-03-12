using System.Collections.Generic;
using System.Linq;
using AtencionTramites.Model.ModelAtencionTramites;

namespace AtencionTramites.Model.DAL
{
	public class RadicadoInternoDocumentoDAL
	{
		public List<RadicadoInternoDocumento> ObtenerRadicadoInternoDocumentoList(DbAtencionTramites db, long CodigoSolicitud, int CodigoTipo)
		{
			if (CodigoSolicitud == 0L)
			{
				return null;
			}
			List<RadicadoInternoDocumento> ret = (from RadicadoInternoDocumento in db.RadicadoInternoDocumento.AsNoTracking()
				where RadicadoInternoDocumento.CodigoSolicitud == CodigoSolicitud && RadicadoInternoDocumento.CodigoTipo == CodigoTipo
				select RadicadoInternoDocumento).ToList();
			LlenarRadicadoInternoDocumentoList(ret);
			return ret;
		}

		public void LlenarRadicadoInternoDocumentoList(List<RadicadoInternoDocumento> RadicadoInternoDocumentoList)
		{
			if (RadicadoInternoDocumentoList == null)
			{
				return;
			}
			foreach (RadicadoInternoDocumento RadicadoInternoDocumento in RadicadoInternoDocumentoList)
			{
				LlenarRadicadoInternoDocumento(RadicadoInternoDocumento);
			}
		}

		public void LlenarRadicadoInternoDocumento(RadicadoInternoDocumento RadicadoInternoDocumento)
		{
		}
	}
}
