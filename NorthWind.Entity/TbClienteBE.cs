using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NorthWind.Entity
{
    public class TbClienteBE:EventArgs
    {
        public string CodCliente { get; set; }
        public string Nombre { get; set; }
        public string Ruc { get; set; }

        //public TbClienteBE(string codcliente,
        //    string  nombre , 
        //    string  ruc)
        //{
        //    this.CodCliente  =codcliente;
        //    this.Nombre = nombre;
        //    this.Ruc  = ruc;        
        //}

        //public static List<TbClienteBE> SelectAll()
        //{
        //    List<TbClienteBE> clientes = new List<TbClienteBE>();
        //    clientes.Add(new TbClienteBE("c001", "Garcia","1585658"));
        //    clientes.Add(new TbClienteBE("c002", "Rojas","1585658"));
        //    clientes.Add(new TbClienteBE("c003", "Vega","1585658"));
        //    clientes.Add(new TbClienteBE("c004", "Hinojosa","1585658"));            
        //    return clientes;

        //}
    }
}
