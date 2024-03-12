using System.Collections.Generic;
using System.Linq;
using AtencionTramites.Model.ModelAtencionTramites;

namespace AtencionTramites.Model.DAL
{
	public class TipoSolicitanteDAL
	{
		public List<TipoSolicitante> ObtenierTipoSolicitante(DbAtencionTramites db)
		{
			return (from q in db.TipoSolicitante.AsNoTracking()
				where q.Habilitado
				select q).ToList();
		}
	}
}
