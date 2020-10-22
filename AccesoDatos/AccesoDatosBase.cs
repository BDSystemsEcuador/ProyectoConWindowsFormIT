using System;
using System.Data;
using System.Text;

using Microsoft.Practices.EnterpriseLibrary.Data;
using LogicStudio.CGIFS.ConstantesCG;



namespace Btgsa.Cgweb.Proyecto.AccesoDatos
{
    public abstract class AccesoDatosBase
    {
        private Database baseDatos;

        public AccesoDatosBase()
        {
            baseDatos = DatabaseFactory.CreateDatabase();
        }

        protected virtual Database BaseDatos
        {
            get
            {
                return this.baseDatos;
            }
        }

        public IDbTransaction ObtenerTransaccion(IsolationLevel nivelAislamiento)
        {
            IDbConnection connection = baseDatos.GetConnection();

            if (connection.State != ConnectionState.Open)
            {
                connection.Open();
            }

            return connection.BeginTransaction(nivelAislamiento);
        }

        public IDbTransaction ObtenerTransaccion()
        {
            return ObtenerTransaccion(IsolationLevel.ReadCommitted);
        }
    }
}
