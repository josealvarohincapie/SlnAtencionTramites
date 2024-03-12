using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using AtencionTramites.Model.ModelAtencionTramites;

namespace AtencionTramites.Model.DAL
{
	public class SecretariaDAL
	{
		public List<Secretaria> ObtenerSecretarias(DbAtencionTramites db)
		{
			return db.Secretaria.AsNoTracking().ToList();
		}

		public Secretaria ObtenerSecretaria(DbAtencionTramites db, string Nombre)
		{
			return (from q in db.Secretaria.AsNoTracking()
				where q.Nombre == Nombre
				select q).FirstOrDefault();
		}

		public void GuardarSecretaria(DbAtencionTramites db, string CargoAprobadorRemplazo, string CodigoDependencia, int? CodigoIntegracionDozzier, string Correo, string Nombre, bool Habilitado)
		{
			Secretaria ele = db.Secretaria.Where((Secretaria q) => q.Nombre == Nombre).FirstOrDefault();
			if (ele == null)
			{
				ele = new Secretaria();
				ele.CargoAprobadorRemplazo = CargoAprobadorRemplazo;
				ele.Codigo = ((!db.Secretaria.Any()) ? 1 : (db.Secretaria.Max((Secretaria q) => q.Codigo) + 1));
				ele.CodigoDependencia = CodigoDependencia;
				ele.CodigoIntegracionDozzier = CodigoIntegracionDozzier;
				ele.Correo = Correo;
				ele.Habilitado = Habilitado;
				ele.Nombre = Nombre;
				db.Secretaria.Add(ele);
			}
			else
			{
				ele.CargoAprobadorRemplazo = CargoAprobadorRemplazo;
				ele.CodigoDependencia = CodigoDependencia;
				ele.CodigoIntegracionDozzier = CodigoIntegracionDozzier;
				ele.Correo = Correo;
				ele.Habilitado = Habilitado;
				db.Entry(ele).State = EntityState.Modified;
			}
			db.SaveChanges();
		}
	}
}
