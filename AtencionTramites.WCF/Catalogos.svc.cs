using AtencionTramites.Model.Classes;
using AtencionTramites.Model.ModelAtencionTramites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Activation;
using Ultimus.Interfaces;
using Ultimus.Utilitarios;

namespace AtencionTramites.WCF
{
    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
    [ServiceBehavior(IncludeExceptionDetailInFaults = true)]

    public class Catalogos : ICatalogos
    {
        private UltimusLogs UltimusLogs = new UltimusLogs("Catalogos");

        public List<JsonCatalogos> ObtenerEstratoSocioEconomico(CatalogoPostJSON model)
        {
            List<JsonCatalogos> ret = new List<JsonCatalogos>();
            try
            {
                using (DbAtencionTramites db = new DbAtencionTramites())
                {
                    foreach (EstratoSocioEconomico ele in from q in db.EstratoSocioEconomico.AsNoTracking()
                                                          where (string.IsNullOrEmpty(model.filtro) || q.Nombre.ToLower().Contains(model.filtro.ToLower())) && q.Habilitado
                                                          orderby q.Nombre
                                                          select q)
                    {
                        ret.Add(new JsonCatalogos
                        {
                            codigo = Convert.ToString(ele.Codigo),
                            descripcion = ele.Nombre
                        });
                    }
                }
            }
            catch (Exception ex)
            {
                UltimusLogs.Error(ex);
            }
            return ret;
        }

        public List<JsonCatalogos> ObtenerCentroPoblado(CatalogoPostJSON model)
        {
            List<JsonCatalogos> ret = new List<JsonCatalogos>();
            try
            {
                using (DbAtencionTramites db = new DbAtencionTramites())
                {
                    foreach (CentroPoblado ele in from q in db.CentroPoblado.AsNoTracking()
                                                  where (string.IsNullOrEmpty(model.filtro) || q.Nombre.ToLower().Contains(model.filtro.ToLower())) && q.Habilitado
                                                  orderby q.Nombre
                                                  select q)
                    {
                        ret.Add(new JsonCatalogos
                        {
                            codigo = Convert.ToString(ele.Codigo),
                            descripcion = ele.Nombre
                        });
                    }
                }
            }
            catch (Exception ex)
            {
                UltimusLogs.Error(ex);
            }
            return ret;
        }

        public List<JsonCatalogos> ObtenerExpresionGenero(CatalogoPostJSON model)
        {
            List<JsonCatalogos> ret = new List<JsonCatalogos>();
            try
            {
                using (DbAtencionTramites db = new DbAtencionTramites())
                {
                    foreach (ExpresionGenero ele in from q in db.ExpresionGenero.AsNoTracking()
                                                    where (string.IsNullOrEmpty(model.filtro) || q.Nombre.ToLower().Contains(model.filtro.ToLower())) && q.Habilitado
                                                    orderby q.Nombre
                                                    select q)
                    {
                        ret.Add(new JsonCatalogos
                        {
                            codigo = Convert.ToString(ele.Codigo),
                            descripcion = ele.Nombre
                        });
                    }
                }
            }
            catch (Exception ex)
            {
                UltimusLogs.Error(ex);
            }
            return ret;
        }

        public List<JsonCatalogos> ObtenerGrupo(CatalogoPostJSON model)
        {
            List<JsonCatalogos> ret = new List<JsonCatalogos>();
            try
            {
                using (DbAtencionTramites db = new DbAtencionTramites())
                {
                    foreach (Grupo ele in from q in db.Grupo.AsNoTracking()
                                          where (string.IsNullOrEmpty(model.filtro) || q.Nombre.ToLower().Contains(model.filtro.ToLower())) && q.Habilitado
                                          orderby q.Nombre
                                          select q)
                    {
                        ret.Add(new JsonCatalogos
                        {
                            codigo = Convert.ToString(ele.Codigo),
                            descripcion = ele.Nombre
                        });
                    }
                }
            }
            catch (Exception ex)
            {
                UltimusLogs.Error(ex);
            }
            return ret;
        }

        public List<JsonCatalogos> ObtenerSubGrupo(CatalogoPostJSON model)
        {
            List<JsonCatalogos> ret = new List<JsonCatalogos>();
            try
            {
                using (DbAtencionTramites db = new DbAtencionTramites())
                {
                    foreach (SubGrupo ele in from q in db.SubGrupo.AsNoTracking()
                                             where (string.IsNullOrEmpty(model.filtro) || q.Nombre.ToLower().Contains(model.filtro.ToLower())) && q.Habilitado
                                             orderby q.Nombre
                                             select q)
                    {
                        ret.Add(new JsonCatalogos
                        {
                            codigo = Convert.ToString(ele.Codigo),
                            descripcion = ele.Nombre
                        });
                    }
                }
            }
            catch (Exception ex)
            {
                UltimusLogs.Error(ex);
            }
            return ret;
        }

        public List<JsonCatalogos> ObtenerComunidad(CatalogoPostJSON model)
        {
            List<JsonCatalogos> ret = new List<JsonCatalogos>();
            try
            {
                using (DbAtencionTramites db = new DbAtencionTramites())
                {
                    foreach (Comunidad ele in from q in db.Comunidad.AsNoTracking()
                                              where (string.IsNullOrEmpty(model.filtro) || q.Nombre.ToLower().Contains(model.filtro.ToLower())) && q.Habilitado
                                              orderby q.Nombre
                                              select q)
                    {
                        ret.Add(new JsonCatalogos
                        {
                            codigo = Convert.ToString(ele.Codigo),
                            descripcion = ele.Nombre
                        });
                    }
                }
            }
            catch (Exception ex)
            {
                UltimusLogs.Error(ex);
            }
            return ret;
        }

        public List<JsonCatalogos> ObtenerConclusionAsesoria(CatalogoPostJSON model)
        {
            List<JsonCatalogos> ret = new List<JsonCatalogos>();
            try
            {
                using (DbAtencionTramites db = new DbAtencionTramites())
                {
                    foreach (ConclusionAsesoria ele in from q in db.ConclusionAsesoria.AsNoTracking()
                                                       where (string.IsNullOrEmpty(model.filtro) || q.Nombre.ToLower().Contains(model.filtro.ToLower())) && q.Habilitado
                                                       orderby q.Nombre
                                                       select q)
                    {
                        ret.Add(new JsonCatalogos
                        {
                            codigo = Convert.ToString(ele.Codigo),
                            descripcion = ele.Nombre
                        });
                    }
                }
            }
            catch (Exception ex)
            {
                UltimusLogs.Error(ex);
            }
            return ret;
        }

        public List<JsonCatalogos> ObtenerAreaDerecho(CatalogoPostJSON model)
        {
            List<JsonCatalogos> ret = new List<JsonCatalogos>();
            try
            {
                using (DbAtencionTramites db = new DbAtencionTramites())
                {
                    foreach (AreaDerecho ele in from q in db.AreaDerecho.AsNoTracking()
                                                where (string.IsNullOrEmpty(model.filtro) || q.Nombre.ToLower().Contains(model.filtro.ToLower())) && q.Habilitado
                                                orderby q.Nombre
                                                select q)
                    {
                        ret.Add(new JsonCatalogos
                        {
                            codigo = Convert.ToString(ele.Codigo),
                            descripcion = ele.Nombre
                        });
                    }
                }
            }
            catch (Exception ex)
            {
                UltimusLogs.Error(ex);
            }
            return ret;
        }

        public List<JsonCatalogos> ObtenerDerecho(CatalogoPostJSON model)
        {
            List<JsonCatalogos> ret = new List<JsonCatalogos>();
            try
            {
                using (DbAtencionTramites db = new DbAtencionTramites())
                {
                    foreach (Derecho ele in from q in db.Derecho.AsNoTracking()
                                            where (string.IsNullOrEmpty(model.filtro) || q.Nombre.ToLower().Contains(model.filtro.ToLower())) && q.Habilitado
                                            orderby q.Nombre
                                            select q)
                    {
                        ret.Add(new JsonCatalogos
                        {
                            codigo = Convert.ToString(ele.Codigo),
                            descripcion = ele.Nombre
                        });
                    }
                }
            }
            catch (Exception ex)
            {
                UltimusLogs.Error(ex);
            }
            return ret;
        }

        public List<JsonCatalogos> ObtenerTipoPeticion(CatalogoPostJSON model)
        {
            List<JsonCatalogos> ret = new List<JsonCatalogos>();
            try
            {
                using (DbAtencionTramites db = new DbAtencionTramites())
                {
                    foreach (TipoPeticion ele in from q in db.TipoPeticion.AsNoTracking()
                                                 where (string.IsNullOrEmpty(model.filtro) || q.Nombre.ToLower().Contains(model.filtro.ToLower())) && q.Habilitado
                                                 orderby q.Nombre
                                                 select q)
                    {
                        ret.Add(new JsonCatalogos
                        {
                            codigo = Convert.ToString(ele.Codigo),
                            descripcion = ele.Nombre
                        });
                    }
                }
            }
            catch (Exception ex)
            {
                UltimusLogs.Error(ex);
            }
            return ret;
        }

        public List<JsonCatalogos> ObtenerDecision(CatalogoPostJSON model)
        {
            List<JsonCatalogos> ret = new List<JsonCatalogos>();
            try
            {
                using (DbAtencionTramites db = new DbAtencionTramites())
                {
                    List<Decision> list = (from q in db.Decision.AsNoTracking()
                                           where (string.IsNullOrEmpty(model.filtro) || q.Nombre.ToLower().Contains(model.filtro.ToLower())) && q.Proceso == model.UltimusProcess && q.Etapa == model.UltimusStep && q.Habilitado
                                           orderby q.Orden
                                           select q).ToList();
                    if (model.UltimusStep == Constantes.AtencionTramiteAse.Etapas.GenerarDocumento.Nombre)
                    {
                        foreach (TipoDocumentoOcultaDecision ocultar in db.TipoDocumentoOcultaDecision.Where((TipoDocumentoOcultaDecision q) => (int?)q.CodigoTipoDocumento == model.CodigoTipoDocumento && ((int?)q.CodigoSubTipoDocumento == model.CodigoSubTipoDocumento || q.CodigoSubTipoDocumento == 0)).ToList())
                        {
                            Decision encontrado = list.FirstOrDefault((Decision q) => q.Codigo == ocultar.CodigoDecision);
                            if (encontrado != null)
                            {
                                list.Remove(encontrado);
                            }
                        }
                    }
                    foreach (Decision ele in list)
                    {
                        ret.Add(new JsonCatalogos
                        {
                            codigo = Convert.ToString(ele.Codigo),
                            descripcion = ele.Nombre
                        });
                    }
                }
            }
            catch (Exception ex)
            {
                UltimusLogs.Error(ex);
            }
            return ret;
        }
    }
}