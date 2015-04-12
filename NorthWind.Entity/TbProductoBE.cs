using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NorthWind.Entity
{
    public class TbProductoBE
    {
        public string CodProducto { get; set; }
        public string Descripcion { get; set; }
        public string Precio { get; set; }

        public override string ToString()
        {
            return Descripcion;
        }

        public TbProductoBE(
            string  codproducto,
            string  descripcion , 
            string  precio)
        {
            this.CodProducto  =codproducto;
            this.Descripcion = descripcion;
            this.Precio  = precio;        
        }

        public static List<TbProductoBE> SelectAll()
        {
            List<TbProductoBE> productos = new List<TbProductoBE>();
            productos.Add(new TbProductoBE("p001", "Producto 1", "50"));
            productos.Add(new TbProductoBE("p002", "Producto 2", "80"));
            productos.Add(new TbProductoBE("p003", "Producto 3", "70"));
            productos.Add(new TbProductoBE("p004", "Producto 4", "10"));
            
            return productos;

        }
    }
}
