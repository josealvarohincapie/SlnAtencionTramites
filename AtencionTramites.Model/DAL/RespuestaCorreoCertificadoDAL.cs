using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using AtencionTramites.Model.ModelAtencionTramites;
using Ultimus.Interfaces;

namespace AtencionTramites.Model.DAL
{
	public class RespuestaCorreoCertificadoDAL
	{
		public RespuestaCorreoCertificado Obtener(DbAtencionTramites db, long CodigoSolicitud, int CodigoTipoCorrero, string CorreoDestinatario)
		{
			return (from RespuestaCorreoCertificado in db.RespuestaCorreoCertificado.AsNoTracking()
				where RespuestaCorreoCertificado.CodigoSolicitud == CodigoSolicitud && RespuestaCorreoCertificado.CodigoTipoCorreo == CodigoTipoCorrero && RespuestaCorreoCertificado.CorreoDestinatario.Trim().ToLower() == CorreoDestinatario.Trim().ToLower()
				select RespuestaCorreoCertificado).FirstOrDefault();
		}

		public List<RespuestaCorreoCertificado> ObtenerNoEntregados(DbAtencionTramites db)
		{
			return (from RespuestaCorreoCertificado in db.RespuestaCorreoCertificado.AsNoTracking()
				where RespuestaCorreoCertificado.Entregado != (bool?)true
				select RespuestaCorreoCertificado).ToList();
		}

		public void Guardar(DbAtencionTramites db, RespuestaCorreoCertificado RespuestaCorreoCertificado, UltimusJson model)
		{
			RespuestaCorreoCertificado ele = db.RespuestaCorreoCertificado.Where((RespuestaCorreoCertificado q) => q.CodigoSolicitud == RespuestaCorreoCertificado.CodigoSolicitud && RespuestaCorreoCertificado.CodigoTipoCorreo == 1 && q.CorreoDestinatario == RespuestaCorreoCertificado.CorreoDestinatario).FirstOrDefault();
			if (ele == null)
			{
				RespuestaCorreoCertificado.CodigoRespuestaCorreoCertificado = Guid.NewGuid();
				RespuestaCorreoCertificado.FechaCreacion = DateTime.Now;
				RespuestaCorreoCertificado.IDUsuarioCreacion = model.UltimusUserID;
				RespuestaCorreoCertificado.NombreUsuarioCreacion = model.UltimusUserFullName;
				db.RespuestaCorreoCertificado.Add(RespuestaCorreoCertificado);
				db.SaveChanges();
			}
			else
			{
				ele.IdMensaje = RespuestaCorreoCertificado.IdMensaje;
				ele.Asunto = RespuestaCorreoCertificado.Asunto;
				ele.Cuerpo = RespuestaCorreoCertificado.Cuerpo;
				ele.Adjunto = RespuestaCorreoCertificado.Adjunto;
				ele.NombreAdjunto = RespuestaCorreoCertificado.NombreAdjunto;
				db.Entry(ele).State = EntityState.Modified;
				db.SaveChanges();
			}
		}

		public void GuardarComprobante(DbAtencionTramites db, RespuestaCorreoCertificado RespuestaCorreoCertificado)
		{
			RespuestaCorreoCertificado ele = db.RespuestaCorreoCertificado.Where((RespuestaCorreoCertificado q) => q.IdMensaje == RespuestaCorreoCertificado.IdMensaje).FirstOrDefault();
			if (ele != null)
			{
				ele.Entregado = true;
				ele.RutaFisicaDocumento = RespuestaCorreoCertificado.RutaFisicaDocumento;
				ele.RutaVirtualDocumento = RespuestaCorreoCertificado.RutaVirtualDocumento;
				db.Entry(ele).State = EntityState.Modified;
				db.SaveChanges();
			}
		}
	}
}
