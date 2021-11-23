using System;
using System.Collections.Generic;
using System.Text;

namespace inventarioTMP
{
    class MovimientosDTO
    {
        public int id { get; set; }
        public String detalle { get; set; }
        public String tipo { get; set; }
        public int id_bodega { get; set; }
        public int id_producto { get; set; }
        public int cantidad { get; set; }
        public DateTime created_at { get; set; }

        public String textoTitulo => $"{tipo}: \n {created_at} | {id_producto} | {cantidad}";
    }
}
