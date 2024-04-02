using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Validation;
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

        public DerechosClasificacion GuardarDerechosClasificacion(DbAtencionTramites db, DerechosClasificacion derechosClasificacion)
        {
            DerechosClasificacion derecho = new DerechosClasificacion();

            if (derechosClasificacion == null)
            {
                return null;
            }
            try
            {
                derecho = db.DerechosClasificacion.SingleOrDefault(b =>
                            b.CodigoSolicitud == derechosClasificacion.CodigoSolicitud
                            && b.CodigoDerecho == derechosClasificacion.CodigoDerecho
                            && b.Habilitado == true);

                if (derecho != null)
                {
                    derecho = null;
                }
                else
                {
                    derecho = new DerechosClasificacion();

                    derecho.CodigoDerecho = derechosClasificacion.CodigoDerecho;
                    derecho.CodigoSolicitud = derechosClasificacion.CodigoSolicitud;
                    derecho.NombreUsuarioCreacion = derechosClasificacion.NombreUsuarioCreacion;
                    derecho.IDUsuarioCreacion = derechosClasificacion.IDUsuarioCreacion;
                    derecho.FechaCreacion = DateTime.Now;
                    derecho.FechaUsuarioModifica = DateTime.Now;

                    derecho.Habilitado = true;

                    db.SaveChanges();
                    db.Commit();
                }
            }
            catch (DbUpdateException ex)
            {
                db.Rollback();
            }
            /*
            DbUpdateException
            DbUpdateConcurrencyException

            DbEntityValidationException

            NotSupportedException

            ObjectDisposedException


            InvalidOperationException  
            */

            finally 
            { 
                db.Close();
            }

            return derecho;

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
