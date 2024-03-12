using System.Linq;
using AtencionTramites.Model.ModelAtencionTramites;

namespace AtencionTramites.Model.DAL
{
	public class TipoDocumentoDAL
	{
		public TipoDocumento ObtenerTipoDocumento(DbAtencionTramites db, int Codigo)
		{
			return (from q in db.TipoDocumento.AsNoTracking()
				where q.Codigo == Codigo
				select q).FirstOrDefault();
		}
	}
}
