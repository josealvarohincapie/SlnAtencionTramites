using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using AtencionTramites.Model.ModelAtencionTramites;

namespace AtencionTramites.Model.DAL
{
	public class RespuestaDecisionDAL
	{
		public List<RespuestaDecision> ObtenerRespuestaDecisionList(DbAtencionTramites db, long CodigoSolicitud)
		{
			if (CodigoSolicitud == 0L)
			{
				return null;
			}
			List<RespuestaDecision> ret = (from RespuestaDecision in db.RespuestaDecision.Include((RespuestaDecision q) => q.Decision).AsNoTracking()
				where RespuestaDecision.CodigoSolicitud == CodigoSolicitud
				orderby RespuestaDecision.FechaFin
				select RespuestaDecision).ToList();
			LlenarRespuestaDecisionList(ret);
			return ret;
		}

		public RespuestaDecision ObtenerRespuestaDecision(DbAtencionTramites db, string Hash)
		{
			RespuestaDecision ret = (from RespuestaDecision in db.RespuestaDecision.Include((RespuestaDecision q) => q.Decision).AsNoTracking()
				where RespuestaDecision.Hash == Hash
				select RespuestaDecision).FirstOrDefault();
			LlenarRespuestaDecision(ret);
			return ret;
		}

		public RespuestaDecision ObtenerRespuestaDecision(DbAtencionTramites db, long CodigoSolicitud, string Etapa)
		{
			if (CodigoSolicitud == 0L)
			{
				return null;
			}
			RespuestaDecision ret = (from RespuestaDecision in db.RespuestaDecision.Include((RespuestaDecision q) => q.Decision).AsNoTracking()
				where RespuestaDecision.CodigoSolicitud == CodigoSolicitud && RespuestaDecision.Etapa == Etapa
				orderby RespuestaDecision.FechaFin descending
				select RespuestaDecision).FirstOrDefault();
			LlenarRespuestaDecision(ret);
			return ret;
		}

		public void LlenarRespuestaDecisionList(List<RespuestaDecision> RespuestaDecisionList)
		{
			if (RespuestaDecisionList == null)
			{
				return;
			}
			foreach (RespuestaDecision RespuestaDecision in RespuestaDecisionList)
			{
				LlenarRespuestaDecision(RespuestaDecision);
			}
		}

		public void LlenarRespuestaDecision(RespuestaDecision RespuestaDecision)
		{
			if (RespuestaDecision != null && RespuestaDecision.Decision != null)
			{
				RespuestaDecision.NombreDecision = RespuestaDecision.Decision.Nombre;
				RespuestaDecision.Decision = null;
			}
		}
	}
}