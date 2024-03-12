using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using AtencionTramites.Model.ModelAtencionTramites;

namespace AtencionTramites.Model.DAL
{
	public class RadicadoDecisionDAL
	{
		public List<RadicadoDecision> ObtenerRadicadoDecisionList(DbAtencionTramites db, long CodigoSolicitud)
		{
			if (CodigoSolicitud == 0L)
			{
				return null;
			}
			List<RadicadoDecision> ret = (from RadicadoDecision in db.RadicadoDecision.Include((RadicadoDecision q) => q.Decision).AsNoTracking()
				where RadicadoDecision.CodigoSolicitud == CodigoSolicitud
				orderby RadicadoDecision.FechaFin
				select RadicadoDecision).ToList();
			LlenarRadicadoDecisionList(ret);
			return ret;
		}

		public RadicadoDecision ObtenerRadicadoDecision(DbAtencionTramites db, string Hash)
		{
			RadicadoDecision ret = (from RadicadoDecision in db.RadicadoDecision.Include((RadicadoDecision q) => q.Decision).AsNoTracking()
				where RadicadoDecision.Hash == Hash
				select RadicadoDecision).FirstOrDefault();
			LlenarRadicadoDecision(ret);
			return ret;
		}

		public void LlenarRadicadoDecisionList(List<RadicadoDecision> RadicadoDecisionList)
		{
			if (RadicadoDecisionList == null)
			{
				return;
			}
			foreach (RadicadoDecision RadicadoDecision in RadicadoDecisionList)
			{
				LlenarRadicadoDecision(RadicadoDecision);
			}
		}

		public void LlenarRadicadoDecision(RadicadoDecision RadicadoDecision)
		{
			if (RadicadoDecision != null && RadicadoDecision.Decision != null)
			{
				RadicadoDecision.NombreDecision = RadicadoDecision.Decision.Nombre;
				RadicadoDecision.Decision = null;
			}
		}
	}
}