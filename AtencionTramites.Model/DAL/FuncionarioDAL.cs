using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using AtencionTramites.Model.ModelAtencionTramites;

namespace AtencionTramites.Model.DAL
{
	public class FuncionarioDAL
	{
		public List<Funcionario> ObtenerFuncionarios(DbAtencionTramites db)
		{
			return db.Funcionario.AsNoTracking().ToList();
		}

		public Funcionario ObtenerFuncionario(DbAtencionTramites db, string Usuario)
		{
			return (from q in db.Funcionario.AsNoTracking()
				where q.Usuario == Usuario
				select q).FirstOrDefault();
		}

		public void GuardarFuncionario(DbAtencionTramites db, string Cedula, string Firma, string Correo, string Usuario)
		{
			Funcionario ele = db.Funcionario.Where((Funcionario q) => q.Usuario.ToLower() == Usuario.ToLower()).FirstOrDefault();
			if (ele == null)
			{
				ele = new Funcionario();
				ele.Cedula = Cedula;
				ele.Codigo = ((!db.Funcionario.Any()) ? 1 : (db.Funcionario.Max((Funcionario q) => q.Codigo) + 1));
				ele.Firma = Firma;
				ele.Correo = Correo;
				ele.Habilitado = true;
				ele.Usuario = Usuario;
				db.Funcionario.Add(ele);
			}
			else
			{
				ele.Cedula = Cedula;
				ele.Firma = Firma;
				ele.Correo = Correo;
				db.Entry(ele).State = EntityState.Modified;
			}
			db.SaveChanges();
		}
	}
}
