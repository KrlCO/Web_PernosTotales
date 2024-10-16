﻿using System.Collections.Generic;

namespace JSD.SUNKU.Control.Base
{
    public class ParametroControlDto
    {
        public string llave { get; set; }
        public string valor { get; set; }
    }

    public class ListaParametroControlDto
    {
        public List<ParametroControlDto> parametros { get; set; }
    }
}
