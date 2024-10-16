using System;

namespace JSD.SUNKU.Control.Model
{
    public class ResponseContainerModel
    {
        public ResponseContainerModel() { }

        public string Token { get; set; }
        public DateTime FechaInicioVigencia { get; set; }
        public DateTime FechaFinVigencia { get; set; }
    }
}
