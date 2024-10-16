namespace JSD.PERNOS.Business.Logic.Layer.Utils
{
    public static class Constantes
    {
        public struct Estado
        {
            public const string Activo = "1";
            public const string Inactivo = "0";
        }

        public struct Reporte
        {
            public const string SubtituloCliente = "I. DATOS DEL CLIENTE:";
            public const string SubtituloHitosImportantes = "II. HITOS IMPORTANTES DEL MES:";
            public const string SubtituloDetalleEstadoActual = "III. DETALLE GENERAL DE ESTADO ACTUAL:";
            public const string SubtituloOrdenesServicioRealizadas = "IV. ORDENES DE SERVICIO REALIZADAS";
            public const string SubtituloEquiposMtoProximo = "V. EQUIPOS CON MANTENIMIENTO PRÓXIMO";
            public const string SubtituloProgramacionPresupuestal = "VI. PROGRAMACIÓN PRESUPUESTAL ";

            public const string LabelDireccion = "DIRECCIÓN:";
            public const string LabelRazonSocial = "RAZÓN SOCIAL:";
            public const string LabelRUC = "RUC:";
            public const string LabelResponsable = "RESPONSABLE:";

            public const string HeaderUbicacion = "UBICACIÓN";
            public const string HeaderNombre = "NOMBRE";
            public const string HeaderCodigo = "CÓDIGO";
            public const string HeaderEstado = "ESTADO";
            public const string FechaUltimoMto = "ÚLTIMO MANTENIMIENTO";
            public const string PresupuestoEstimado = "PRESUPUESTO ESTIMADO";
            //

            public const string LabelCantidadEquipos = "CANTIDAD DE EQUIPOS";
            public const string LabelOrdenesServicio = "ORDENES DE SERVICIO";
            public const string LabelPresupuestoEjecutado = "PRESUPUESTO EJECUTADO";

            public const string LabelReduccionEmisiones = "REDUCCIÓN DE EMISIONES";
            public const string LabelAhorroElectricidad = "AHORRO DE ELECTRICIDAD";
            public const string LabelReduccionIncidencias = "REDUCCIÓN DE INCIDENCIAS";

            public const string LabelEstimacionUltimoMes = "Estimación del último mes";
            public const string LabelCalculoUltimoMes = "Cálculo del último mes";
        }

        public struct MargenReporte
        {
            public const int Titulo = 10;
            public const int Subtitulo = 7;
            public const int Seccion = 20;
        }
    }
}
