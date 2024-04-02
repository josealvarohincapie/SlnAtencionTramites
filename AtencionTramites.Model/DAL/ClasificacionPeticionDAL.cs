using System.Data.Entity;
using System.Linq;
using AtencionTramites.Model.ModelAtencionTramites;

namespace AtencionTramites.Model.DAL
{
	public class ClasificacionPeticionDAL
	{
		public ClasificacionPeticion ObtenerClasificacionPeticion(DbAtencionTramites db, long CodigoSolicitud)
		{
            if (CodigoSolicitud == 0L)
            {
                return null;
            }

            ClasificacionPeticion clasificacionPeticion = (from ClasificacionPeticion in db.ClasificacionPeticion
                .Include((ClasificacionPeticion q) => q.TipoPeticion)
                .Include((ClasificacionPeticion q) => q.AreaDerecho)
                .Include((ClasificacionPeticion q) => q.ConclusionAsesoria)
                .AsNoTracking()
                 where ClasificacionPeticion.CodigoSolicitud == CodigoSolicitud
				 select ClasificacionPeticion).FirstOrDefault();

            LlenarClasificacionPeticion(clasificacionPeticion);

            return clasificacionPeticion;

        }

        public ClasificacionPeticion GuardarClasificacionPeticion(DbAtencionTramites db, long CodigoSolicitud)
        {
            if (CodigoSolicitud == 0L)
            {
                return null;
            }

            ClasificacionPeticion clasificacionPeticion = (
                from ClasificacionPeticion in db.ClasificacionPeticion
                .AsNoTracking()
                where ClasificacionPeticion.CodigoSolicitud == CodigoSolicitud
                select ClasificacionPeticion).FirstOrDefault();

            if (clasificacionPeticion != null) 
            {
                //db.
               // db.SaveChanges
                db.Commit();
            }

            return clasificacionPeticion;

        }

        public void LlenarClasificacionPeticion(ClasificacionPeticion clasificacionPeticion)
        {
            if (clasificacionPeticion == null)
            {
                return;
            }
            if (clasificacionPeticion.AreaDerecho != null)
            {
               // clasificacionPeticion.NombreAreaDerecho = clasificacionPeticion.AreaDerecho.Nombre;
                //Radicado.Fuente = null;
            }
            
        }
    }
}
