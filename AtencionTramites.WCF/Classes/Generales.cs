using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using AtencionTramites.Model.Classes;
using AtencionTramites.Model.ModelAtencionTramites;

namespace AtencionTramites.WCF.Classes
{
	public class Generales
	{
		public void GenerarNumeroRadicado(DbAtencionTramites db, Radicado Radicado)
		{
			if (Radicado.Descartado)
			{
				Radicado.Secuencial = null;
				Radicado.NumeroRadicado = null;
			}
			else
			{
				if (Radicado.Secuencial.HasValue || !string.IsNullOrEmpty(Radicado.NumeroRadicado) || !Radicado.Fecha.HasValue)
				{
					return;
				}
				if (Radicado.CodigoEntidad.HasValue && Radicado.CodigoSecretaria.HasValue)
				{
					Entidad Entidad = (from q in db.Entidad.AsNoTracking()
						where q.Nombre == Radicado.NombreEntidad
						select q).FirstOrDefault();
					Secretaria Secretaria = (from q in db.Secretaria.AsNoTracking()
						where q.Nombre == Radicado.NombreSecretaria
						select q).FirstOrDefault();
					if (Entidad == null)
					{
						throw new Exception(Constantes.MensajeErrorEntidadNoConfigurada);
					}
					if (Secretaria == null)
					{
						throw new Exception(Constantes.MensajeErrorSecretariaNoConfigurada);
					}
					List<int> SecuenciaList2 = (from q in db.Radicado.AsNoTracking()
						where q.Secuencial != null && q.Fecha.Value.Year == Radicado.Fecha.Value.Year && q.NombreEntidad == Entidad.Nombre
						select q.Secuencial.Value).ToList();
					if (SecuenciaList2 == null || !SecuenciaList2.Any())
					{
						Radicado.Secuencial = Entidad.SecuencialInicio;
					}
					else
					{
						int SecuencialMax = SecuenciaList2.Max();
						int j;
						for (j = 1; j <= SecuencialMax; j++)
						{
							if (!SecuenciaList2.Any((int q) => q == j))
							{
								Radicado.Secuencial = j;
								break;
							}
						}
						if (!Radicado.Secuencial.HasValue)
						{
							Radicado.Secuencial = SecuencialMax + 1;
						}
					}
					Radicado.NumeroRadicado = UltimusUtility.ObtenerNumeroRadicado(Entidad.Sigla, Constantes.ClasificacionTramites.Sigla, Radicado.Fecha.Value, Secretaria.CodigoDependencia, Radicado.Secuencial.Value);
				}
				else
				{
					if (Radicado.SecuencialDepartamental.HasValue || !string.IsNullOrEmpty(Radicado.NumeroRadicadoDepartamental))
					{
						return;
					}
					List<int> SecuenciaList = (from q in db.Radicado.AsNoTracking()
						where q.SecuencialDepartamental != null && q.Fecha.Value.Year == Radicado.Fecha.Value.Year
						select q.SecuencialDepartamental.Value).ToList();
					if (SecuenciaList == null || !SecuenciaList.Any())
					{
						Radicado.SecuencialDepartamental = 1;
					}
					else
					{
						int SecuencialMax2 = SecuenciaList.Max();
						int i;
						for (i = 1; i <= SecuencialMax2; i++)
						{
							if (!SecuenciaList.Any((int q) => q == i))
							{
								Radicado.SecuencialDepartamental = i;
								break;
							}
						}
						if (!Radicado.SecuencialDepartamental.HasValue)
						{
							Radicado.SecuencialDepartamental = SecuencialMax2 + 1;
						}
					}
					Radicado.NumeroRadicadoDepartamental = UltimusUtility.ObtenerNumeroRadicadoDepartamental(Radicado.Fecha.Value, Radicado.SecuencialDepartamental.Value);
				}
			}
		}

		public string GetBase64(string path)
		{
			if (File.Exists(path))
			{
				return Convert.ToBase64String(File.ReadAllBytes(path));
			}
			throw new Exception("El archivo '" + path + "' no existe en el servidor");
		}
	}
}
