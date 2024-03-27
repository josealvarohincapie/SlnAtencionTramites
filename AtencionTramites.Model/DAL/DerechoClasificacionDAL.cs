using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using AtencionTramites.Model.ModelAtencionTramites;

namespace AtencionTramites.Model.DAL
{
	public class DerechoClasificacionDAL
    {
		public List<DerechosClasificacion> ObtenerDerechosClasificacion(DbAtencionTramites db, long CodigoSolicitud)
		{
            if (CodigoSolicitud == 0L)
            {
                return null;
            }

            List<DerechosClasificacion> derechosClasificacionLista = 
                (from DerechosClasificacion in db.DerechosClasificacion
                .Include((DerechosClasificacion q) => q.Derecho)
                .AsNoTracking()
                 where DerechosClasificacion.CodigoSolicitud == CodigoSolicitud
				 select DerechosClasificacion).ToList();

            LlenarDerechosClasificacion(derechosClasificacionLista);

            return derechosClasificacionLista;

        }

        public void LlenarDerechosClasificacion(List<DerechosClasificacion> derechosClasificacionLista)
        {
            if (derechosClasificacionLista == null)
            {
                return;
            }
        }
    }
}
