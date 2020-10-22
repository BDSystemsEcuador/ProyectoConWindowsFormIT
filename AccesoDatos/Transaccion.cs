using System;
using System.Data;

using Microsoft.Practices.EnterpriseLibrary.Data;

namespace Btgsa.Cgweb.Proyecto.AccesoDatos
{
    /// <summary>
	/// Clase que permite realizar transaccines.
	/// </summary>
    public class Transaccion

    {
        private Database baseDatos;

        public Transaccion()
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

        /// <summary>
        /// Mtodo BeginTransaction. Inicia una conexin a la base de datos
        /// e inicializa una transaccin.
        /// </summary>
        /// <param name="nivelAislamiento">nivel de aislamiento de la transaccin</param>
        /// <returns></returns>
        public IDbTransaction BeginTransaction(IsolationLevel nivelAislamiento)
        {
            IDbConnection connection = baseDatos.GetConnection();

            try
            {
                connection.Open();
                return connection.BeginTransaction(nivelAislamiento);
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Error al iniciar la transaccion", ex);
            }
        }

        public IDbTransaction BeginTransaction()
        {
            return BeginTransaction(IsolationLevel.ReadCommitted);
        }

        public void CommitTransaction(IDbTransaction trans)
        {
            try
            {
                trans.Commit();
                CloseConnection(trans);
            }
            catch
            {
                RollbackTransaction(trans);
                throw;
            }
        }

        public void RollbackTransaction(IDbTransaction trans)
        {
            try
            {
                trans.Rollback();
            }
            catch
            {
                throw;
            }
            finally
            {
                CloseConnection(trans);
            }
        }

        public void CloseConnection(IDbTransaction trans)
        {
            IDbConnection connection = trans.Connection;
            if (connection != null && connection.State != ConnectionState.Closed)
            {
                connection.Close();
                connection.Dispose();
            }
        }

    }
}
