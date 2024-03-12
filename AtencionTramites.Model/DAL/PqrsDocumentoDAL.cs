using System.Collections.Generic;
using System.Linq;
using AtencionTramites.Model.ModelAtencionTramites;

namespace AtencionTramites.Model.DAL
{
	public class PqrsDocumentoDAL
	{
		public List<PqrsDocumento> ObtenerPqrsDocumentoList(DbAtencionTramites db, long CodigoSolicitud)
		{
			if (CodigoSolicitud == 0L)
			{
				return null;
			}
			return (from PqrsDocumento in db.PqrsDocumento.AsNoTracking()
				where PqrsDocumento.CodigoSolicitud == CodigoSolicitud
				select PqrsDocumento).ToList();
		}
	}
}
