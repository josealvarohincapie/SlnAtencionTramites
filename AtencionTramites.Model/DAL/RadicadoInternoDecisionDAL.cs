using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using AtencionTramites.Model.ModelAtencionTramites;

namespace AtencionTramites.Model.DAL
{
	public class RadicadoInternoDecisionDAL
	{
		public List<RadicadoInternoDecision> ObtenerRadicadoInternoDecisionList(DbAtencionTramites db, long CodigoSolicitud)
		{
			if (CodigoSolicitud == 0L)
			{
				return null;
			}
			List<RadicadoInternoDecision> ret = (from RadicadoInternoDecision in db.RadicadoInternoDecision.Include((RadicadoInternoDecision q) => q.Decision).AsNoTracking()
				where RadicadoInternoDecision.CodigoSolicitud == CodigoSolicitud
				orderby RadicadoInternoDecision.FechaFin
				select RadicadoInternoDecision).ToList();
			LlenarRadicadoInternoDecisionList(ret);
			return ret;
		}

		public RadicadoInternoDecision ObtenerRadicadoInternoDecision(DbAtencionTramites db, string Hash)
		{
			RadicadoInternoDecision ret = (from RadicadoInternoDecision in db.RadicadoInternoDecision.Include((RadicadoInternoDecision q) => q.Decision).AsNoTracking()
				where RadicadoInternoDecision.Hash == Hash
				select RadicadoInternoDecision).FirstOrDefault();
			LlenarRadicadoInternoDecision(ret);
			return ret;
		}

		public void LlenarRadicadoInternoDecisionList(List<RadicadoInternoDecision> RadicadoInternoDecisionList)
		{
			if (RadicadoInternoDecisionList == null)
			{
				return;
			}
			foreach (RadicadoInternoDecision RadicadoInternoDecision in RadicadoInternoDecisionList)
			{
				LlenarRadicadoInternoDecision(RadicadoInternoDecision);
			}
		}

		public void LlenarRadicadoInternoDecision(RadicadoInternoDecision RadicadoInternoDecision)
		{
			if (RadicadoInternoDecision != null && RadicadoInternoDecision.Decision != null)
			{
				RadicadoInternoDecision.NombreDecision = RadicadoInternoDecision.Decision.Nombre;
				RadicadoInternoDecision.Decision = null;
			}
		}
	}
}