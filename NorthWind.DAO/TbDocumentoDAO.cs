using NorthWind.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NorthWind.DAO
{
    public class TbDocumentoDAO
    {
        public eEstadoProceso GuardarDocumento(
            DocumentoBE oDocumento)
        {

            //Si todo esta OK se guarda como Correcto
            return eEstadoProceso.Correcto;
        }

    }
}
