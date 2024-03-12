using System.Linq;
using AtencionTramites.Model.ModelAtencionTramites;

namespace AtencionTramites.Model.DAL
{
	public class FormatoDAL
	{
		public int? ObtenerPorTipoDocumento(DbAtencionTramites db, int CodigoTipoDocumento, int CodigoSubTipoDocumento)
		{
			return db.TipoDocumentoFormato.AsNoTracking().FirstOrDefault((TipoDocumentoFormato q) => q.CodigoTipoDocumento == CodigoTipoDocumento && (q.CodigoSubTipoDocumento == CodigoSubTipoDocumento || q.CodigoSubTipoDocumento == 0))?.CodigoFormato;
		}
	}
}
