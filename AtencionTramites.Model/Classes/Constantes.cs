using System.Collections.Generic;
using System.Globalization;

namespace AtencionTramites.Model.Classes
{
    public class Constantes
    {
        public static CultureInfo esPA = new CultureInfo("es-PA");

        public enum CodigoTipoDecision { Avanzar = 1, Rechazar = 2, Devolver = 3 }
        public enum CodigoTipoSolicitud { CartaTrabajo = 1, Vacaciones = 2, Permiso = 3, Herramientas = 4 }

        public static class ClasificacionTramites
        {
            public static class Etapas
            {
                public static class AnalisisPeticionClasificacion
                {
                    public static class Decisiones
                    {
                        public static int Decision1 = 1;

                        public static int Decision2 = 2;

                        public static int Decision3 = 3;
                    }

                    public static string Nombre = "AnalisisPeticionClasificacion";
                }

                public static class Asesoria
                {
                    public static class Decisiones
                    {
                        public static int Decision1 = 1;

                        public static int Decision2 = 2;

                        public static int Decision3 = 3;
                    }

                    public static string Nombre = "Asesoria";
                }

                public static class Solicitud
                {
                    public static class Decisiones
                    {
                        public static int Decision1 = 1;

                        public static int Decision2 = 2;

                        public static int Decision3 = 3;
                    }

                    public static string Nombre = "Solicitud";
                }

                public static class Queja
                {
                    public static class Decisiones
                    {
                        public static int Decision1 = 1;

                        public static int Decision2 = 2;

                        public static int Decision3 = 3;
                    }

                    public static string Nombre = "Queja";
                }

                public static class Fin
                {
                    public static class Decisiones
                    {
                        public static int Decision1 = 1;

                        public static int Decision2 = 2;

                        public static int Decision3 = 3;
                    }

                    public static string Nombre = "Fin";
                }
            }

            public static string Sigla = "1";

            public static string Nombre = "AtencionTramiteAse";

            public static string Iniciadores = "AtencionTramiteAse_GenerarCarta";
        }

        public static class AtencionTramiteAse
        {
            public static class Etapas
            {
                public static class GenerarDocumento
                {
                    public static class Decisiones
                    {
                        public static int Decision1 = 1;

                        public static int Decision2 = 2;

                        public static int Decision3 = 3;
                    }

                    public static string Nombre = "GenerarDocumento";
                }

                public static class RealizarRevisionPreliminar
                {
                    public static class Decisiones
                    {
                        public static int Decision1 = 1;

                        public static int Decision2 = 2;

                        public static int Decision3 = 3;
                    }

                    public static string Nombre = "RealizarRevisionPreliminar";
                }

                public static class AprobacionVoBo
                {
                    public static class Decisiones
                    {
                        public static int Decision1 = 1;

                        public static int Decision2 = 2;

                        public static int Decision3 = 3;
                    }

                    public static string Nombre = "AprobacionVoBo";
                }

                public static class AprobarCarta
                {
                    public static class Decisiones
                    {
                        public static int Decision1 = 1;

                        public static int Decision2 = 2;

                        public static int Decision3 = 3;
                    }

                    public static string Nombre = "AprobarCarta";
                }

                public static class AprobacionCartaRespuesta
                {
                    public static class Decisiones
                    {
                        public static int Decision1 = 1;

                        public static int Decision2 = 2;

                        public static int Decision3 = 3;
                    }

                    public static string Nombre = "AprobacionCartaRespuesta";
                }

                public static class ValidarMedioRespuestaAsesoria
                {
                    public static class Decisiones
                    {
                        public static int Decision1 = 1;

                        public static int Decision2 = 2;

                        public static int Decision3 = 3;
                    }

                    public static string Nombre = "ValidarMedioRespuestaAsesoria";
                }

                public static class ConcluirArchivarAsesoria
                {
                    public static class Decisiones
                    {
                        public static int Decision1 = 1;

                        public static int Decision2 = 2;

                        public static int Decision3 = 3;
                    }

                    public static string Nombre = "ConcluirArchivarAsesoria";
                }
            }

            public static string Sigla = "1";

            public static string Nombre = "AtencionTramiteAse";

            public static string Iniciadores = "AtencionTramiteAse_GenerarCarta";
        }

        public static class AtencionTramiteQue
        {
            public static class Etapas
            {
                public static class CalificarDerechosConductasVulneatorias
                {
                    public static class Decisiones
                    {
                        public static int Decision1 = 1;

                        public static int Decision2 = 2;

                        public static int Decision3 = 3;
                    }

                    public static string Nombre = "CalificarDerechosConductasVulneatorias";
                }

                public static class GestionarQueja
                {
                    public static class Decisiones
                    {
                        public static int Decision1 = 1;

                        public static int Decision2 = 2;

                        public static int Decision3 = 3;
                    }

                    public static string Nombre = "GestionarQueja";
                }

                public static class GenerarDocumento
                {
                    public static class Decisiones
                    {
                        public static int Decision1 = 1;

                        public static int Decision2 = 2;

                        public static int Decision3 = 3;
                    }

                    public static string Nombre = "GenerarDocumento";
                }

                public static class ConcluirQueja
                {
                    public static class Decisiones
                    {
                        public static int Decision1 = 1;

                        public static int Decision2 = 2;

                        public static int Decision3 = 3;
                    }

                    public static string Nombre = "ConcluirQueja";
                }

                public static class Archivar
                {
                    public static class Decisiones
                    {
                        public static int Decision1 = 1;

                        public static int Decision2 = 2;

                        public static int Decision3 = 3;
                    }

                    public static string Nombre = "Archivar";
                }
            }

            public static string Sigla = "2";

            public static string Nombre = "AtencionTramiteQue";

            public static string Iniciadores = "AtencionTramiteQue_Calificar";
        }

        public static class AtencionTramiteSol
        {
            public static class Etapas
            {
                public static class Inicio
                {
                    public static class Decisiones
                    {
                        public static int Decision1 = 1;

                        public static int Decision2 = 2;

                        public static int Decision3 = 3;
                    }

                    public static string Nombre = "Inicio";
                }

                public static class GenerarCarta
                {
                    public static class Decisiones
                    {
                        public static int Decision1 = 1;

                        public static int Decision2 = 2;

                        public static int Decision3 = 3;
                    }

                    public static string Nombre = "GenerarCarta";
                }

                public static class RealizarRevisionPreliminar
                {
                    public static class Decisiones
                    {
                        public static int Decision1 = 1;

                        public static int Decision2 = 2;

                        public static int Decision3 = 3;
                    }

                    public static string Nombre = "RealizarRevisionPreliminar";
                }

                public static class AprobacionVoBo
                {
                    public static class Decisiones
                    {
                        public static int Decision1 = 1;

                        public static int Decision2 = 2;

                        public static int Decision3 = 3;
                    }

                    public static string Nombre = "AprobacionVoBo";
                }

                public static class AprobarCarta
                {
                    public static class Decisiones
                    {
                        public static int Decision1 = 1;

                        public static int Decision2 = 2;

                        public static int Decision3 = 3;
                    }

                    public static string Nombre = "AprobarCarta";
                }

                public static class AprobacionCartaRespuesta
                {
                    public static class Decisiones
                    {
                        public static int Decision1 = 1;

                        public static int Decision2 = 2;

                        public static int Decision3 = 3;
                    }

                    public static string Nombre = "AprobacionCartaRespuesta";
                }

                public static class ValidarMedioRespuestaSolicitud
                {
                    public static class Decisiones
                    {
                        public static int Decision1 = 1;

                        public static int Decision2 = 2;

                        public static int Decision3 = 3;
                    }

                    public static string Nombre = "ValidarMedioRespuestaSolicitud";
                }

                public static class Archivar
                {
                    public static class Decisiones
                    {
                        public static int Decision1 = 1;

                        public static int Decision2 = 2;

                        public static int Decision3 = 3;
                    }

                    public static string Nombre = "Archivar";
                }
            }

            public static string Sigla = "3";

            public static string Nombre = "AtencionTramiteSol";

            public static string Iniciadores = "AtencionTramiteSol_ConcluirSolicitud";
        }

        public static class TipoTramite
        {
            public static class Administrativa
            {
                public static int Codigo = 1;

                public static string Nombre = "ADMINISTRATIVA";
            }

            public static class Misional
            {
                public static int Codigo = 2;

                public static string Nombre = "MISIONAL";
            }
        }

        public enum Fuente
        {
            Fisico = 1,
            Correo,
            PQRSD,
            APP,
            Presencial,
            Telefonico
        }

        public enum EstadoPqrs
        {
            PendienteProcesar = 1,
            ProcesadoSatisfactoriamente,
            ProcesadoConErrores
        }

        public enum Formato
        {
            Carta = 1,
            Oficio,
            Defensor,
            Informe,
            Publicacion,
            Respuesta,
            Sugerencia,
            Denuncia,
            Felicitacion,
            Irrespetuosa
        }

        public enum TipoOficio
        {
            RadicadoUnico = 1,
            Simple,
            RadicadoPorDestinatario
        }

        public enum Tipo
        {
            Proyectar = 1,
            ProyectarRespuesta
        }

        public enum TipoDocumento
        {
            RutaFisica = 1,
            Base64
        }

        public enum TipoFirma
        {
            SGDEA = 1,
            Certificada
        }

        public enum TipoCorreo
        {
            Respuesta = 1,
            Ampliacion
        }

        public static class Grupos
        {
            public static string Funcionarios = "Funcionarios";

            public static string ArchivoSecretaria = "ArchivoSecretaria";

            public static string VentanillaSecretaria = "VentanillaSecretaria";

            public static string Aprobadores = "Aprobadores";

            public static string AbogadosAprobadores = "AbogadosAprobadores";

            public static string RepartoInterno = "RepartoInterno";

            public static string Digitalizadores = "Digitalizadores";

            public static string ValidadoresVentanilla = "ValidadoresVentanilla";

            public static string ValidadoresWeb = "ValidadoresWeb";

            public static string ValidadoresCorreo = "ValidadoresCorreo";

            public static string Defensores = "Defensores";
        }

        public static string MensajeGenerarSolicitud = "Generar una solicitud (pestaña Solicitud)";
        
        public static string MensajeLlenarCamposRequeridos = "Llenar los campos requeridos (pestaña Solicitud)";
        
        public static string MensajeErrorGenerico = "Ha ocurrido un error, contacte el administrador";
        
        public static int MaximoRegistros = 500;
        
        public static int MaximoDiasNotificacionPersonal = 13;

        public static string Vacio = "____________________";

        public static string MensajeSatisfactorioGenerico = "Datos actualizados";

        public static string MensajeValidarFormulario = "Valide el formulario";

        public static string MensajeFirmarFormulario = "Ingrese su contraseña y firme el formulario";

        public static string MensajeEliminar = "¿Eliminar?";

        public static string MensajeErrorGeneracionDocumento = "El documento no se ha podido generar";

        public static string MensajeErrorEntidadesRelacionadas = "No se puede eliminar porque tiene algo relacionado";

        public static string MensajeErrorEntidadNoConfigurada = "La entidad no ha sido configurada";

        public static string MensajeErrorConexionSMTPNoConfigurada = "La conexión SMTP no ha sido configurada";

        public static string MensajeErrorRecipienteNotificacionesNoConfigurada = "El recipiente de las notificaciones no ha sido configurado";

        public static string MensajeErrorSecretariaNoConfigurada = "La secretaria no ha sido configurada";

        public static string MensajeNombreYaExiste = "Ya existe este nombre";

        public static string MensajeDigitalizarDocumentos = "Digitalizar los documentos (pestaña Radicado)";

        public static string MensajeLlenarSecretaria = "Llenar el campo 'Secretaría' (pestaña Radicado)";

        public static string MensajeLlenarArea = "Llenar el campo 'Área' (pestaña Radicado)";

        public static string MensajeLlenarGrupo = "Llenar el campo 'Grupo' (pestaña Radicado)";

        public static string MensajeLlenarFuncionario = "Llenar el campo 'Funcionario' (pestaña Radicado)";

        public static string MensajeLlenarDecision = "Llenar el campo 'Decisión' (pestaña Radicado)";

        public static string MensajeLlenarNumeroRadicado = "Llenar el campo 'No. Radicado' (pestaña Radicado)";

        public static string MensajeLlenarNumeroRadicadoDepartamental = "Llenar el campo 'No. Radicado Departamental' (pestaña Radicado)";

        public static string MensajeLlenarAbogado = "Llenar el campo 'Abogado' (pestaña Radicado)";

        public static string MensajeEscanearDigitalizarDocumentoFirmado = "Escanear y digitalizar el documento firmado, el mismo debe ser un PDF y el titulo debe ser igual al campo 'No. Radicado' (pestaña Radicado)";

        public static string MensajeEscanearDigitalizarSoporteEntrega = "Escanear y digitalizar el soporte de entrega, el mismo debe ser un PDF y el titulo debe ser igual al campo 'No. Guía' (pestaña Radicado)";

        public static string MensajeArchivar = "Archivar los documentos (pestaña Radicado)";

        public static string MensajeArchivoNoPermitido = "El archivo '{0}' tiene extensión {1}, las extensiones permitidas son: {2}";

        public static string MensajeArchivoMuyPesado = "El archivo '{0}' pesa {1} bytes, el máximo permitido es: {2} bytes";

        public static string MensajeArchivoVacio = "El archivo '{0}' está vacío";

        public static string MensajeErrorCorreoVacio = "No se puede escoger esta decisión ya que no se ha diligenciado el campo correo";

        public static string MensajeAdjuntarDocumentos = "Adjuntar por lo menos un archivo (sección Anexos del PQRSD)";

        public static string MensajeAceptarPolitica = "Por favor, acepte la politica de tratamiento de datos";

        public static string MensajeTokenInvalido = "Token inválido";

        public static string MensajeDatosActualizados = "Datos Actualizados";

        public static string MensajeErrorEnvioCorreoNoValido = "La dirección de correo no es valida";

        public static string MensajeErrorEnvioCorreoGenerico = "Error genérico en el envío del correo, contacte el administrador";

        public static string MensajeIncluirDominio = "El nombre de usuario debe incluir el dominio";

        public static string MensajeRadicadoNoEncontrado = "El radicado no ha sido encontrado";

        public static string MensajeRadicadoEstaSiendoProcesado = "El radicado está siendo procesado, vuelva a intentarlo más tarde";

        public static string MensajeIngreseNoIdentificacionCorreo = "Ingrese su no. de identificación o su correo";

        public static string MensajeDocumentoNoFirmado = "La Firma Certificada no fue registrada correctamente en el documento, por lo que debe seleccionar la opción Devolver para que se vuelva a firmar.";

        public static string MensajeHashNoEsValido = "El hash no es valido";

        public static string MensajeArchivoNoEsValido = "El archivo no es valido";

        public static string MensajeCampoVacio = "El campo '{0}' está vacío";

        public static string MensajeArchivoNoExiste = "El archivo '{0}' no existe";

        public static string MensajeAdjuntoNumeroRadicado = "Debe adjuntar un archivo que tenga el mismo nombre que el número de radicado '{0}'.";

        public static string CarpetaAdjuntos = "Adjuntos";

        public static string CarpetaGenerados = "Generados";

        public static int CodigoPaisDefault = 39;

        public static string NombrePaisDefault = "COLOMBIA";
    }
}