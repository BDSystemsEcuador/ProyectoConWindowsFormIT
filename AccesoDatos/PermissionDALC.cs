using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Btgsa.Cgweb.Proyecto.EntidadNegocio;
using System.Data;
using LogicStudio.CGIFS.ConstantesCG;
using Microsoft.Practices.EnterpriseLibrary.Data;

namespace Btgsa.Cgweb.Proyecto.AccesoDatos
{
    public class PermissionDALC : AccesoDatosBase
    {
        public PermissionDALC()
        {

        }


        public PermissionDTS Fill()
        {

            StringBuilder sql = new StringBuilder();
            sql.Append("SELECT ");
            sql.Append("PERMISSION_ID Permission_Id, ");
            sql.Append("PERMISSION_FLOW Permission_Flow, ");
            sql.Append("PERMISSION_TYPE Permission_Type, ");
            sql.Append("PERMISSION_ADMINISTRATOR Permission_Administrador, ");
            sql.Append("PERMISSION_NEW_REQUEST Permission_New_Request, ");
            sql.Append("PERMISSION_PUBLISH_REPORTS Permission_Publish_Reports, ");
            sql.Append("PERMISSION_VIEW_INDICATORS Permission_View_Indicators, ");
            sql.Append("PERMISSION_SEARCH Permission_Search, ");
            sql.Append("PERMISSION_FILETYPES Permission_Filetypes, ");
            sql.Append("PERMISSION_REPORTS Permission_Reports, ");


            sql.Append(" FROM  ");
            sql.Append("EF_PERMISSION ");
            sql.Append(" ORDER BY PERMISSION_ID ASC ");
            DBCommandWrapper dbCommandWrapper = BaseDatos.GetSqlStringCommandWrapper(sql.ToString());
            PermissionDTS dsPermission = new PermissionDTS();
            BaseDatos.LoadDataSet(dbCommandWrapper, dsPermission, "EF_PERMISSION");
            return dsPermission;
        }

        public int Update(PermissionDTS dsPermission, IDbTransaction trans)
        {

            #region comando insert


            string sql = "INSERT INTO ";
            sql += "EF_PERMISSION ";

            sql += "(";
            sql += BaseDatos.ConfigurationName == Constantes.BDDORACLE ? "PERMISSION_ID, " : ""; //SOLO ORACLE 
            sql += "PERMISSION_FLOW, PERMISSION_TYPE, PERMISSION_ADMINISTRATOR, PERMISSION_NEW_REQUEST, PERMISSION_PUBLISH_REPORTS," +
                " PERMISSION_VIEW_INDICATORS, PERMISSION_SEARCH, PERMISSION_FILETYPES, PERMISSION_REPORTS,)" 
                + " VALUES( ";
            sql += BaseDatos.ConfigurationName == Constantes.BDDORACLE ? "PERMISSION_ID.NEXTVAL, " : ""; //SOLO ORACLE 
            sql += "@Permission_Flow, @Permission_Type, @Permission_Administrator, " +
                "@Permission_New_Request, @Permission_Publish_Reports, @Permission_View_Indicators, " +
                "@Permission_Search, @Permission_Filetypes, @Permission_Reports)";

            DBCommandWrapper insertCommand = BaseDatos.GetSqlStringCommandWrapper(sql);
            insertCommand.AddInParameter(
                    "Permission_Flow", DbType.AnsiStringFixedLength, dsPermission.EF_PERMISSION.PERMISSION_FLOWColumn, DataRowVersion.Current);
            insertCommand.AddInParameter(
                    "@Permission_Type", DbType.AnsiStringFixedLength, dsPermission.EF_PERMISSION.PERMISSION_TYPEColumn, DataRowVersion.Current);
            insertCommand.AddInParameter(
                    "@Permission_Administrator", DbType.AnsiStringFixedLength, dsPermission.EF_PERMISSION.PERMISSION_ADMINISTRATORColumn, DataRowVersion.Current);
            insertCommand.AddInParameter(
                    "@Permission_New_Request", DbType.AnsiStringFixedLength, dsPermission.EF_PERMISSION.PERMISSION_NEW_REQUESTColumn, DataRowVersion.Current);
            insertCommand.AddInParameter(
                    "@Permission_Publish_Reports", DbType.AnsiStringFixedLength, dsPermission.EF_PERMISSION.PERMISSION_PUBLISH_REPORTSColumn, DataRowVersion.Current);
            insertCommand.AddInParameter(
                    "@Permission_View_Indicators", DbType.AnsiStringFixedLength, dsPermission.EF_PERMISSION.PERMISSION_VIEW_INDICATORSColumn, DataRowVersion.Current);
            insertCommand.AddInParameter(
                    "@Permission_Search", DbType.AnsiStringFixedLength, dsPermission.EF_PERMISSION.PERMISSION_SEARCHColumn, DataRowVersion.Current);
            insertCommand.AddInParameter(
                    "@Permission_Filetypes", DbType.AnsiStringFixedLength, dsPermission.EF_PERMISSION.PERMISSION_FILETYPESColumn, DataRowVersion.Current);
            insertCommand.AddInParameter(
                    "@Permission_Reports", DbType.Int32, dsPermission.EF_PERMISSION.PERMISSION_REPORTSColumn, DataRowVersion.Current);
         


            #endregion

            #region sentencia update

            sql = "UPDATE ";
            sql += "EF_PERMISSION  ";
            sql += "SET ";
            sql += " PERMISSION_ID  = @Permission_Id, "
                    + " PERMISSION_FLOW = @Permission_Flow, "
                    + " PERMISSION_TYPE = @Permission_Type, "
                    + " PERMISSION_VALUE = @Permission_Value, "
                    + " PERMISSION_ADMINISTRATOR = @Permission_Administrator, "
                    + " PERMISSION_NEW_REQUEST = @Permission_New_Request, "
                    + " PERMISSION_PUBLISH_REPORTS = @Permission_Publish_Reports, "
                    + " PERMISSION_VIEW_INDICATORS = @Permission_View_Indicators, "
                    + " PERMISSION_SEARCH = @Permission_Search, "
                    + " PERMISSION_FILETYPES = @Permission_Filetypes, "
                    + " PERMISSION_REPORTS = @Permission_Reports, "
                    + " WHERE "
                    + " PERMISSION_ID = @Permission_idOriginal ";
            DBCommandWrapper updateCommand = BaseDatos.GetSqlStringCommandWrapper(sql);

            #endregion

            #region parametros del update

            sql += "PERMISSION_FLOW, PERMISSION_TYPE, PERMISSION_VALUE, PERMISSION_ADMINISTRATOR, PERMISSION_NEW_REQUEST, PERMISSION_PUBLISH_REPORTS," +
                " PERMISSION_VIEW_INDICATORS, PERMISSION_SEARCH, PERMISSION_FILETYPES, PERMISSION_REPORTS) ";

            updateCommand.AddInParameter(
            "@Permission_idOriginal ", DbType.Int32, dsPermission.EF_PERMISSION.PERMISSION_IDColumn, DataRowVersion.Original);
            updateCommand.AddInParameter(
                      "@Permission_Flow", DbType.Int32, dsPermission.EF_PERMISSION.PERMISSION_FLOWColumn, DataRowVersion.Current);
            updateCommand.AddInParameter(
                    "@Permission_Type", DbType.AnsiStringFixedLength, dsPermission.EF_PERMISSION.PERMISSION_TYPEColumn, DataRowVersion.Current);
            updateCommand.AddInParameter(
                    "@Permission_Administrator", DbType.Int32, dsPermission.EF_PERMISSION.PERMISSION_ADMINISTRATORColumn, DataRowVersion.Current);
            updateCommand.AddInParameter(
                    "@Permission_New_Request", DbType.Int32, dsPermission.EF_PERMISSION.PERMISSION_NEW_REQUESTColumn, DataRowVersion.Current);
            updateCommand.AddInParameter(
                    "@Permission_Publish_Reports", DbType.Int32, dsPermission.EF_PERMISSION.PERMISSION_PUBLISH_REPORTSColumn, DataRowVersion.Current);
            updateCommand.AddInParameter(
                    "@Permission_View_Indicators", DbType.Int32, dsPermission.EF_PERMISSION.PERMISSION_VIEW_INDICATORSColumn, DataRowVersion.Current);
            updateCommand.AddInParameter(
                    "@Permission_Search", DbType.AnsiStringFixedLength, dsPermission.EF_PERMISSION.PERMISSION_SEARCHColumn, DataRowVersion.Current);
            updateCommand.AddInParameter(
                    "@Permission_Filetypes", DbType.AnsiStringFixedLength, dsPermission.EF_PERMISSION.PERMISSION_FILETYPESColumn, DataRowVersion.Current);
            updateCommand.AddInParameter(
                     "@Permission_Reports", DbType.AnsiStringFixedLength, dsPermission.EF_PERMISSION.PERMISSION_REPORTSColumn, DataRowVersion.Current);
           


            DBCommandWrapper deleteCommand = null;

            #endregion


            #region sql del Delete

            sql = "DELETE FROM ";
            sql += "EF_PERMISSION  ";
            sql += "WHERE ";
            sql += "  PERMISSION_ID = @Permission_idOriginal ";

            deleteCommand = BaseDatos.GetSqlStringCommandWrapper(sql);

            #endregion

            #region parametros del delete
            deleteCommand.AddInParameter("@Permission_idOriginal", DbType.Int32, dsPermission.EF_PERMISSION.PERMISSION_IDColumn, DataRowVersion.Original);
            #endregion

            if (trans == null)
                return BaseDatos.UpdateDataSet(dsPermission, "EF_PERMISSION", insertCommand, updateCommand, deleteCommand, UpdateBehavior.Standard);
            else
                return BaseDatos.UpdateDataSet(dsPermission, dsPermission.EF_PERMISSION.TableName, insertCommand, updateCommand, deleteCommand, trans);
        }
    }
}