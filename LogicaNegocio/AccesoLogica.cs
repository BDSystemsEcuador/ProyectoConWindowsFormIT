using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LogicStudio.CGIFS.ConstantesCG;
using Btgsa.Cgweb.Proyecto.AccesoDatos;

namespace Btgsa.Cgweb.Proyecto.LogicaNegocio
{
    public class AccesoLogica
    {

        public string ObtenerBaseDatos()
        {
            AccesoDatosGenerica acceso = new AccesoDatosGenerica();
            return acceso.ObtenerInstanciaBaseDatos();
        }
    }
}
