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
    public class TaskDALC : AccesoDatosBase
    {
        public TaskDALC()
        {

        }


        public TaskDST Fill()
        {

            StringBuilder sql = new StringBuilder();
            sql.Append("SELECT ");
            sql.Append("TASK_ID Task_Id, ");
            sql.Append("TASK_REQUEST Task_Request, ");
            sql.Append("TASK_FLOW Task_Flow, ");
            sql.Append("TASK_STEP Task_Step, ");
            sql.Append("TASK_SEQ Task_Seq, ");
            sql.Append("TASK_ASSIGNEDTO Task_Assignedto, ");
            sql.Append("TASK_STATUS Task_Status, ");
            sql.Append("TASK_SPLIT_GROUP Task_Split_Group");


            sql.Append(" FROM  ");
            sql.Append("EF_TASK ");
            sql.Append(" ORDER BY TASK_ID ASC ");
            DBCommandWrapper dbCommandWrapper = BaseDatos.GetSqlStringCommandWrapper(sql.ToString());
            TaskDST dsTask = new TaskDST();
            BaseDatos.LoadDataSet(dbCommandWrapper, dsTask, "EF_TASK");
            return dsTask;
        }

        public int Update(TaskDST dsTask, IDbTransaction trans)
        {

            #region comando insert


            string sql = "INSERT INTO ";
            sql += "EF_TASK ";

            sql += "(";
            sql += BaseDatos.ConfigurationName == Constantes.BDDORACLE ? "TASK_ID, " : ""; //SOLO ORACLE 
            sql += "TASK_REQUEST, TASK_FLOW, TASK_STEP, TASK_SEQ, TASK_ASSIGNEDTO, TASK_STATUS," +
                " TASK_SPLIT_GROUP) "
                    + " VALUES( ";
            sql += BaseDatos.ConfigurationName == Constantes.BDDORACLE ? "TASK_ID.NEXTVAL, " : ""; //SOLO ORACLE 
            sql += "@Task_Id, @Task_Request, @Task_Flow, @Task_Step, @Task_Seq, @Task_Assignedto, @Task_Status" +
                "@Task_Split_Group)";

            DBCommandWrapper insertCommand = BaseDatos.GetSqlStringCommandWrapper(sql);
            insertCommand.AddInParameter(
                    "@Task_Request", DbType.Int32, dsTask.EF_TASK.TASK_REQUESTColumn, DataRowVersion.Current);
            insertCommand.AddInParameter(
                    "@Task_Flow", DbType.Int32, dsTask.EF_TASK.TASK_FLOWColumn, DataRowVersion.Current);
            insertCommand.AddInParameter(
                    "@Task_Step", DbType.Int32, dsTask.EF_TASK.TASK_STEPColumn, DataRowVersion.Current);
            insertCommand.AddInParameter(
                    "@Task_Seq", DbType.Int32, dsTask.EF_TASK.TASK_SEQColumn, DataRowVersion.Current);
            insertCommand.AddInParameter(
                    "@Task_Assignedto", DbType.AnsiStringFixedLength, dsTask.EF_TASK.TASK_ASSIGNEDTOColumn, DataRowVersion.Current);
            insertCommand.AddInParameter(
                    "@Task_Status", DbType.AnsiStringFixedLength, dsTask.EF_TASK.TASK_STATUSColumn, DataRowVersion.Current);
            insertCommand.AddInParameter(
                    "@Task_Split_Group", DbType.AnsiStringFixedLength, dsTask.EF_TASK.TASK_SPLIT_GROUPColumn, DataRowVersion.Current);

            #endregion

            sql += "@Task_Id, @Task_Request, @Task_Flow, @Task_Step, @Task_Seq, @Task_Assignedto, @Task_Status" +
                "@Task_Split_Group)";

            #region sentencia update

            sql = "UPDATE ";
            sql += "EF_TASK  ";
            sql += "SET ";
            sql += " TASK_REQUEST  = @Task_Request, "
                    + " PERMISIONS_ROLE = @Task_Flow, "
                    + " PERMISIONS_AREA = @Task_Step, "
                    + " PERMISIONS_BLOCKED = @Task_Seq, "
                    + " PERMISIONS_ACTIVE = @Task_Assignedto, "
                    + " PERMISIONS_IMAGE = @Task_Status, "
                    + " PERMISIONS_EMAIL = @Task_Split_Group "
                    + " WHERE "
                    + " TASK_ID = @Task_idOriginal ";
            DBCommandWrapper updateCommand = BaseDatos.GetSqlStringCommandWrapper(sql);

            #endregion

            #region parametros del update

            sql += "TASK_REQUEST, TASK_FLOW, TASK_STEP, TASK_SEQ, TASK_ASSIGNEDTO, TASK_STATUS," +
                " TASK_SPLIT_GROUP) ";

            updateCommand.AddInParameter(
            "@Task_idOriginal ", DbType.Int32, dsTask.EF_TASK.TASK_IDColumn, DataRowVersion.Original);
            updateCommand.AddInParameter(
                      "@Task_Request", DbType.Int32, dsTask.EF_TASK.TASK_REQUESTColumn, DataRowVersion.Current);
            updateCommand.AddInParameter(
                    "@Task_Flow", DbType.Int32, dsTask.EF_TASK.TASK_FLOWColumn, DataRowVersion.Current);
            updateCommand.AddInParameter(
                    "@Task_Step", DbType.Int32, dsTask.EF_TASK.TASK_STEPColumn, DataRowVersion.Current);
            updateCommand.AddInParameter(
                    "@Task_Seq", DbType.Int32, dsTask.EF_TASK.TASK_SEQColumn, DataRowVersion.Current);
            updateCommand.AddInParameter(
                    "@Task_Assignedto", DbType.AnsiStringFixedLength, dsTask.EF_TASK.TASK_ASSIGNEDTOColumn, DataRowVersion.Current);
            updateCommand.AddInParameter(
                    "@Task_Status", DbType.AnsiStringFixedLength, dsTask.EF_TASK.TASK_STATUSColumn, DataRowVersion.Current);
            updateCommand.AddInParameter(
                    "@Task_Split_Group", DbType.AnsiStringFixedLength, dsTask.EF_TASK.TASK_SPLIT_GROUPColumn, DataRowVersion.Current);

            DBCommandWrapper deleteCommand = null;

            #endregion


            #region sql del Delete

            sql = "DELETE FROM ";
            sql += "EF_TASK  ";
            sql += "WHERE ";
            sql += "  TASK_ID = @Task_idOriginal ";

            deleteCommand = BaseDatos.GetSqlStringCommandWrapper(sql);

            #endregion

            #region parametros del delete
            deleteCommand.AddInParameter("@Task_idOriginal", DbType.Int32, dsTask.EF_TASK.TASK_IDColumn, DataRowVersion.Original);
            #endregion

            if (trans == null)
                return BaseDatos.UpdateDataSet(dsTask, "EF_TASK", insertCommand, updateCommand, deleteCommand, UpdateBehavior.Standard);
            else
                return BaseDatos.UpdateDataSet(dsTask, dsTask.EF_TASK.TableName, insertCommand, updateCommand, deleteCommand, trans);
        }
    }
}
