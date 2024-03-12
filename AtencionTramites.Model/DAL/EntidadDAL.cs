using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using AtencionTramites.Model.ModelAtencionTramites;

namespace AtencionTramites.Model.DAL
{
	public class EntidadDAL
	{
		public List<Entidad> ObtenerEntidades(DbAtencionTramites db)
		{
			return db.Entidad.AsNoTracking().ToList();
		}

		public Entidad ObtenerEntidad(DbAtencionTramites db, string Nombre)
		{
			return (from q in db.Entidad.AsNoTracking()
				where q.Nombre == Nombre
				select q).FirstOrDefault();
		}

		public void GuardarEntidad(DbAtencionTramites db, string Departamento, string Municipio, string Nombre, string RutaDocumentos, int SecuencialInicio, string Sigla, string Dominio, string RecipienteNotificaciones, bool Habilitado)
		{
			Entidad ele = db.Entidad.Where((Entidad q) => q.Nombre == Nombre).FirstOrDefault();
			if (ele == null)
			{
				ele = new Entidad();
				ele.Codigo = ((!db.Entidad.Any()) ? 1 : (db.Funcionario.Max((Funcionario q) => q.Codigo) + 1));
				ele.Departamento = Departamento;
				ele.Dominio = Dominio;
				ele.Habilitado = Habilitado;
				ele.Municipio = Municipio;
				ele.Nombre = Nombre;
				ele.RecipienteNotificaciones = RecipienteNotificaciones;
				ele.RutaDocumentos = RutaDocumentos;
				ele.SecuencialInicio = SecuencialInicio;
				ele.Sigla = Sigla;
				db.Entidad.Add(ele);
			}
			else
			{
				ele.Departamento = Departamento;
				ele.Dominio = Dominio;
				ele.Habilitado = Habilitado;
				ele.Municipio = Municipio;
				ele.RecipienteNotificaciones = RecipienteNotificaciones;
				ele.RutaDocumentos = RutaDocumentos;
				ele.SecuencialInicio = SecuencialInicio;
				ele.Sigla = Sigla;
				db.Entry(ele).State = EntityState.Modified;
			}
			db.SaveChanges();
		}
	}
}
