//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Entidades
{
    using System;
    using System.Collections.Generic;
    
    public partial class Recorrido
    {
        public int Id { get; set; }
        public string LugarSalida { get; set; }
        public string LugarLlegada { get; set; }
        public Nullable<System.DateTime> FechaHora { get; set; }
        public Nullable<int> Tiempo { get; set; }
        public string Precio { get; set; }
        public Nullable<int> IdUsuario { get; set; }
        public Nullable<int> IdBici { get; set; }
    
        public virtual Bicicleta Bicicleta { get; set; }
        public virtual Usuario Usuario { get; set; }
    }
}
