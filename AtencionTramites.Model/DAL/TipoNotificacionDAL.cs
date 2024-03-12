using System.Collections.Generic;
using System.Linq;
using AtencionTramites.Model.ModelAtencionTramites;

namespace AtencionTramites.Model.DAL
{
	public class TipoNotificacionDAL
	{
		public List<TipoNotificacion> ObtenerTipoNotificaciones(DbAtencionTramites db)
		{
			return (from q in db.TipoNotificacion.AsNoTracking()
				where q.Habilitado
				select q).ToList();
		}
	}
}
