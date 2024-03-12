using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using AtencionTramites.Model.ModelAtencionTramites;

namespace AtencionTramites.Model.DAL
{
	public class NotificacionDAL
	{
		public List<Notificacion> ObtenerNotificaciones(DbAtencionTramites db)
		{
			return db.Notificacion.AsNoTracking().ToList();
		}

		public void GuardarNotificacion(DbAtencionTramites db, int CodigoTipoNotificacion)
		{
			Notificacion ele = db.Notificacion.Where((Notificacion q) => q.CodigoTipoNotificacion == CodigoTipoNotificacion).FirstOrDefault();
			if (ele == null)
			{
				ele = new Notificacion();
				ele.CodigoNotificacion = Guid.NewGuid();
				ele.CodigoTipoNotificacion = CodigoTipoNotificacion;
				ele.FechaEnvio = DateTime.Now;
				db.Notificacion.Add(ele);
			}
			else
			{
				ele.FechaEnvio = DateTime.Now;
				db.Entry(ele).State = EntityState.Modified;
			}
			db.SaveChanges();
		}
	}
}
