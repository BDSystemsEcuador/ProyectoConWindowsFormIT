using System;
using System.Collections.Generic;
using System.Text;

namespace Btgsa.Cgweb.Proyecto.AccesoDatos
{
    public class AccesoDatosGenerica : AccesoDatosBase
    {
        //Obtiene el nombre la configuracion si es SQLSever, Oracle o Db2
        public string ObtenerInstanciaBaseDatos()
        {
            return this.BaseDatos.ConfigurationName;
        }
    }
}