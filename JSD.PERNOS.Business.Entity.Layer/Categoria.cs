using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JSD.PERNOS.Business.Entity.Layer
{
    public class Categoria
    {
        public int IdCategoria { get; set; }
        public string Nombre { get; set; }
        public string Descripcion {get; set; }
        public bool Estado { get; set; }

         //Campos de Auditoria
        internal string UsuarioRegistro { get; set; }
        internal DateTime FechaRegistro { get; set; }
        internal string UsuarioModificacion { get; set; }
        internal DateTime? FechaModificacion { get; set; }

        public ICollection<Producto> Productos { get; set; }

    }
}
