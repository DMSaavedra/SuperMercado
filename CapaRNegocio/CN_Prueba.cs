using CapaDatos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaRNegocio
{
    public class CN_Prueba
    {
        private CD_Prueba objetoCD = new CD_Prueba();

        public void ver_datos()
        {
            objetoCD.traerDatos();
        }

    }
}
