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
    public class RuleDALC : AccesoDatosBase
    {
        public RuleDALC()
        {

        }


        public RuleDST Fill()
        {

            StringBuilder sql = new StringBuilder();
            sql.Append("SELECT ");
            sql.Append("RULE_ID Rule_Id, ");
            sql.Append("RULE_FLOW Rule_Flow, ");
            sql.Append("RULE_NAME Rule_Name, ");
            sql.Append("RULE_DESCRIPTION Rule_Description, ");
            sql.Append("RULE_TYPE Rule_Type, ");
            sql.Append("RULE_MESSAGE Rule_Message, ");
            sql.Append("RULE_DEFAULT_FLOW Rule_Default_Flow, ");
            sql.Append("RULE_DEFAULT_STEP Rule_Default_Step");


            sql.Append(" FROM  ");
            sql.Append("EF_RULE ");
            sql.Append(" ORDER BY RULE_ID ASC ");
            DBCommandWrapper dbCommandWrapper = BaseDatos.GetSqlStringCommandWrapper(sql.ToString());
            RuleDST dsRule = new RuleDST();
            BaseDatos.LoadDataSet(dbCommandWrapper, dsRule, "EF_RULE");
            return dsRule;
        }

        public int Update(RuleDST dsRule, IDbTransaction trans)
        {

            #region comando insert


            string sql = "INSERT INTO ";
            sql += "EF_RULE ";

            sql += "(";
            sql += BaseDatos.ConfigurationName == Constantes.BDDORACLE ? "RULE_ID, " : ""; //SOLO ORACLE 
            sql += "RULE_FLOW, RULE_NAME, RULE_DESCRIPTION, RULE_TYPE, RULE_MESSAGE, RULE_DEFAULT_FLOW," +
                " RULE_DEFAULT_STEP) "
                    + " VALUES( ";
            sql += BaseDatos.ConfigurationName == Constantes.BDDORACLE ? "RULE_ID.NEXTVAL, " : ""; //SOLO ORACLE 
            sql += "@Rule_Id, @Rule_Flow, @Rule_Name, @Rule_Description, @Rule_Type, @Rule_Message, @Rule_Default_Flow" +
                "@Rule_Default_Step)";

            DBCommandWrapper insertCommand = BaseDatos.GetSqlStringCommandWrapper(sql);
            insertCommand.AddInParameter(
                    "@Rule_Flow", DbType.Int32, dsRule.EF_RULE.RULE_FLOWColumn, DataRowVersion.Current);
            insertCommand.AddInParameter(
                    "@Rule_Name", DbType.AnsiStringFixedLength, dsRule.EF_RULE.RULE_NAMEColumn, DataRowVersion.Current);
            insertCommand.AddInParameter(
                    "@Rule_Description", DbType.AnsiStringFixedLength, dsRule.EF_RULE.RULE_DESCRIPTIONColumn, DataRowVersion.Current);
            insertCommand.AddInParameter(
                    "@Rule_Type", DbType.AnsiStringFixedLength, dsRule.EF_RULE.RULE_TYPEColumn, DataRowVersion.Current);
            insertCommand.AddInParameter(
                    "@Rule_Message", DbType.AnsiStringFixedLength, dsRule.EF_RULE.RULE_MESSAGEColumn, DataRowVersion.Current);
            insertCommand.AddInParameter(
                    "@Rule_Default_Flow", DbType.Int32, dsRule.EF_RULE.RULE_DEFAULT_FLOWColumn, DataRowVersion.Current);
            insertCommand.AddInParameter(
                    "@Rule_Default_Step", DbType.Int32, dsRule.EF_RULE.RULE_DEFAULT_STEPColumn, DataRowVersion.Current);

            #endregion

            sql += "@Rule_Id, @Rule_Flow, @Rule_Name, @Rule_Description, @Rule_Type, @Rule_Message, @Rule_Default_Flow" +
                "@Rule_Default_Step)";

            #region sentencia update

            sql = "UPDATE ";
            sql += "EF_RULE  ";
            sql += "SET ";
            sql += " RULE_FLOW  = @Rule_Flow, "
                    + " RULE_NAME = @Rule_Name, "
                    + " RULE_DESCRIPTION = @Rule_Description, "
                    + " RULE_TYPE = @Rule_Type, "
                    + " RULE_MESSAGE = @Rule_Message, "
                    + " RULE_DEFAULT_FLOW = @Rule_Default_Flow, "
                    + " RULE_DEFAULT_STEP = @Rule_Default_Step "
                    + " WHERE "
                    + " RULE_ID = @Rule_idOriginal ";
            DBCommandWrapper updateCommand = BaseDatos.GetSqlStringCommandWrapper(sql);

            #endregion

            #region parametros del update

            sql += "RULE_FLOW, RULE_NAME, RULE_DESCRIPTION, RULE_TYPE, RULE_MESSAGE, RULE_DEFAULT_FLOW," +
                " RULE_DEFAULT_STEP) ";

            updateCommand.AddInParameter(
            "@Rule_idOriginal ", DbType.Int32, dsRule.EF_RULE.RULE_IDColumn, DataRowVersion.Original);
            updateCommand.AddInParameter(
                      "@Rule_Flow", DbType.Int32, dsRule.EF_RULE.RULE_FLOWColumn, DataRowVersion.Current);
            updateCommand.AddInParameter(
                    "@Rule_Name", DbType.AnsiStringFixedLength, dsRule.EF_RULE.RULE_NAMEColumn, DataRowVersion.Current);
            updateCommand.AddInParameter(
                    "@Rule_Description", DbType.AnsiStringFixedLength, dsRule.EF_RULE.RULE_DESCRIPTIONColumn, DataRowVersion.Current);
            updateCommand.AddInParameter(
                    "@Rule_Type", DbType.AnsiStringFixedLength, dsRule.EF_RULE.RULE_TYPEColumn, DataRowVersion.Current);
            updateCommand.AddInParameter(
                    "@Rule_Message", DbType.AnsiStringFixedLength, dsRule.EF_RULE.RULE_MESSAGEColumn, DataRowVersion.Current);
            updateCommand.AddInParameter(
                    "@Rule_Default_Flow", DbType.Int32, dsRule.EF_RULE.RULE_DEFAULT_FLOWColumn, DataRowVersion.Current);
            updateCommand.AddInParameter(
                    "@Rule_Default_Step", DbType.Int32, dsRule.EF_RULE.RULE_DEFAULT_STEPColumn, DataRowVersion.Current);

            DBCommandWrapper deleteCommand = null;

            #endregion


            #region sql del Delete

            sql = "DELETE FROM ";
            sql += "EF_RULE  ";
            sql += "WHERE ";
            sql += "  RULE_ID = @Rule_idOriginal ";

            deleteCommand = BaseDatos.GetSqlStringCommandWrapper(sql);

            #endregion

            #region parametros del delete
            deleteCommand.AddInParameter("@Rule_idOriginal", DbType.Int32, dsRule.EF_RULE.RULE_IDColumn, DataRowVersion.Original);
            #endregion

            if (trans == null)
                return BaseDatos.UpdateDataSet(dsRule, "EF_RULE", insertCommand, updateCommand, deleteCommand, UpdateBehavior.Standard);
            else
                return BaseDatos.UpdateDataSet(dsRule, dsRule.EF_RULE.TableName, insertCommand, updateCommand, deleteCommand, trans);
        }
    }
}