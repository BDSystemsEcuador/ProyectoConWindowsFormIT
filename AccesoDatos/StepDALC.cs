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
    public class StepDALC : AccesoDatosBase
    {
        public StepDALC()
        {

        }


        public StepDST Fill()
        {

            StringBuilder sql = new StringBuilder();
            sql.Append("SELECT ");
            sql.Append("STEP_FLOW Step_Flow, "); 
            sql.Append("STEP_ID Step_Id, ");
            sql.Append("STEP_NAME Step_Name, ");
            sql.Append("STEP_DESCRIPTION Step_Description, ");
            sql.Append("STEP_NEXT_TYPE Step_next_Type, "); 
            sql.Append("STEP_NEXT_VALUE Step_next_Value, ");
            sql.Append("STEP_PREV_TYPE Step_prev_Type, "); 
            sql.Append("STEP_PREV_VALUE Step_prev_Value, ");
            sql.Append("STEP_ASSIGNTO_TYPE Step_Assignto_Type, ");
            sql.Append("STEP_ASSIGNTO_VALUE Step_Assignto_Value, ");
            sql.Append("STEP_ASSIGNTO_ALGORITHM Step_Assignto_Algorithm, ");
            sql.Append("STEP_STATUS Step_Status, "); 
            sql.Append("STEP_PERCENT_WEIGHT Step_Percent_Weight, ");
            sql.Append("STEP_DURATION Step_Duration, "); 
            sql.Append("STEP_START_DATE Step_Start_Date, "); 
            sql.Append("STEP_LIMIT_DATE Step_Limit_Date, ");
            sql.Append("STEP_VIEW_METADATA Step_View_Metadata, ");
            sql.Append("STEP_EDIT_METADATA Step_Edit_Metadata, "); 
            sql.Append("STEP_ENTER_FUNCTION Step_Enter_Function, ");
            sql.Append("STEP_EXIT_FUNCTION Step_Exit_Function, ");
            sql.Append("STEP_ASSIGN_PIC Step_Assign_Pic, ");
            sql.Append("STEP_CHECKLIST Step_Checklist, ");
            sql.Append("STEP_SHOW_HELP Step_Show_Help, "); 
            sql.Append("STEP_HELP_HTML Step_Help_Html, ");
            sql.Append("STEP_CONSOLIDATOR Step_Consolidator, ");
            sql.Append("STEP_FORM_TYPE Step_Form_Type, ");
            sql.Append("STEP_FORM_VALUE Step_Form_Value ");
            sql.Append(" FROM  ");
            sql.Append("EF_STEP ");
            sql.Append(" ORDER BY STEP_ID ASC ");
            DBCommandWrapper dbCommandWrapper = BaseDatos.GetSqlStringCommandWrapper(sql.ToString());
            StepDST dsStep = new StepDST();
            BaseDatos.LoadDataSet(dbCommandWrapper, dsStep, "EF_STEP");
            return dsStep;
        }

        public int Update(StepDST dsStep, IDbTransaction trans)
        {

            #region comando insert


            string sql = "INSERT INTO ";
            sql += "EF_STEP ";

            sql += "(";
            sql += BaseDatos.ConfigurationName == Constantes.BDDORACLE ? "STEP_ID, STEP_FLOW " : ""; //SOLO ORACLE 
            sql += "STEP_NAME, STEP_DESCRIPTION ,STEP_NEXT_TYPE," +
                "STEP_NEXT_VALUE,STEP_PREV_TYPE,STEP_PREV_VALUE,STEP_ASSIGNTO_TYPE," +
                "STEP_ASSIGNTO_VALUE,STEP_ASSIGNTO_ALGORITHM,STEP_STATUS,STEP_PERCENT_WEIGHT," +
                "STEP_DURATION,STEP_START_DATE,STEP_LIMIT_DATE,STEP_VIEW_METADATA,STEP_EDIT_METADATA," +
                "STEP_ENTER_FUNCTION,STEP_EXIT_FUNCTION,STEP_ASSIGN_PIC,STEP_CHECKLIST,STEP_SHOW_HELP," +
                "STEP_HELP_HTML,STEP_CONSOLIDATOR,STEP_FORM_TYPE,STEP_FORM_VALUE ) "
                    + " VALUES( ";
            sql += BaseDatos.ConfigurationName == Constantes.BDDORACLE ? "STEP_ID.NEXTVAL, " : ""; //SOLO ORACLE 
            sql += " @Step_Flow,@Step_Id,@Step_Name,@Step_Description,@Step_next_Type,@Step_next_Value," +
                "@Step_prev_Type,@Step_prev_Value,@Step_Assignto_Type,@Step_Assignto_Value," +
                "@Step_Assignto_Algorithm,@Step_Status,@Step_Percent_Weight,@Step_Duration," +
                "@Step_Start_Date,@Step_Limit_Date,@Step_View_Metadata,@Step_Edit_Metadata," +
                "@Step_Enter_Function,@Step_Exit_Function,@Step_Assign_Pic,@Step_Checklist,@Step_Show_Help," +
                "@Step_Help_Html,@Step_Consolidator,@Step_Form_Type,@Step_Form_Value)";

            DBCommandWrapper insertCommand = BaseDatos.GetSqlStringCommandWrapper(sql);
            insertCommand.AddInParameter(
                    "@Step_Name", DbType.AnsiStringFixedLength, dsStep.EF_STEP.STEP_NAMEColumn, DataRowVersion.Current);
            insertCommand.AddInParameter(
                    "@Step_Description", DbType.AnsiStringFixedLength, dsStep.EF_STEP.STEP_DESCRIPTIONColumn, DataRowVersion.Current);
            insertCommand.AddInParameter(
                    "@Step_next_Type", DbType.AnsiStringFixedLength, dsStep.EF_STEP.STEP_NEXT_TYPEColumn, DataRowVersion.Current);
            insertCommand.AddInParameter(
                    "@Step_next_Value", DbType.AnsiStringFixedLength, dsStep.EF_STEP.STEP_NEXT_VALUEColumn, DataRowVersion.Current);
            insertCommand.AddInParameter(
                    "@Step_prev_Type", DbType.AnsiStringFixedLength, dsStep.EF_STEP.STEP_PREV_TYPEColumn, DataRowVersion.Current);
            insertCommand.AddInParameter(
                    "@Step_prev_Value", DbType.AnsiStringFixedLength, dsStep.EF_STEP.STEP_PREV_VALUEColumn, DataRowVersion.Current);
            insertCommand.AddInParameter(
                    "@Step_Assignto_Type", DbType.AnsiStringFixedLength, dsStep.EF_STEP.STEP_ASSIGNTO_TYPEColumn, DataRowVersion.Current);
            insertCommand.AddInParameter(
                    "@Step_Assignto_Value", DbType.AnsiStringFixedLength, dsStep.EF_STEP.STEP_ASSIGNTO_VALUEColumn, DataRowVersion.Current);
            insertCommand.AddInParameter(
                     "@Step_Assignto_Algorithm", DbType.AnsiStringFixedLength, dsStep.EF_STEP.STEP_ASSIGNTO_ALGORITHMColumn, DataRowVersion.Current);
            insertCommand.AddInParameter(
                    "@Step_Status", DbType.AnsiStringFixedLength, dsStep.EF_STEP.STEP_STATUSColumn, DataRowVersion.Current);
            insertCommand.AddInParameter(
                    "@Step_Percent_Weight", DbType.Double, dsStep.EF_STEP.STEP_PERCENT_WEIGHTColumn, DataRowVersion.Current);
            insertCommand.AddInParameter(
                     "@Step_Duration", DbType.AnsiStringFixedLength, dsStep.EF_STEP.STEP_DURATIONColumn, DataRowVersion.Current);
            insertCommand.AddInParameter(
                    "@Step_Start_Date", DbType.DateTime, dsStep.EF_STEP.STEP_START_DATEColumn, DataRowVersion.Current);
            insertCommand.AddInParameter(
                    "@Step_Limit_Date", DbType.DateTime, dsStep.EF_STEP.STEP_LIMIT_DATEColumn, DataRowVersion.Current);
            insertCommand.AddInParameter(
                     "@Step_View_Metadata", DbType.Int32, dsStep.EF_STEP.STEP_VIEW_METADATAColumn, DataRowVersion.Current);
            insertCommand.AddInParameter(
                    "@Step_Edit_Metadata", DbType.Int32, dsStep.EF_STEP.STEP_EDIT_METADATAColumn, DataRowVersion.Current);
            insertCommand.AddInParameter(
                    "@Step_Enter_Function", DbType.AnsiStringFixedLength, dsStep.EF_STEP.STEP_ENTER_FUNCTIONColumn, DataRowVersion.Current);
            insertCommand.AddInParameter(
                     "@Step_Exit_Function", DbType.AnsiStringFixedLength, dsStep.EF_STEP.STEP_EXIT_FUNCTIONColumn, DataRowVersion.Current);
            insertCommand.AddInParameter(
                    "@Step_Assign_Pic", DbType.Int32, dsStep.EF_STEP.STEP_ASSIGN_PICColumn, DataRowVersion.Current);
            insertCommand.AddInParameter(
                    "@Step_Checklist", DbType.Int32, dsStep.EF_STEP.STEP_CHECKLISTColumn, DataRowVersion.Current);
            insertCommand.AddInParameter(
                     "@Step_Show_Help", DbType.Int32, dsStep.EF_STEP.STEP_SHOW_HELPColumn, DataRowVersion.Current);
            insertCommand.AddInParameter(
                    "@Step_Help_Html", DbType.AnsiStringFixedLength, dsStep.EF_STEP.STEP_HELP_HTMLColumn, DataRowVersion.Current);
            insertCommand.AddInParameter(
                    "@Step_Consolidator", DbType.Int32, dsStep.EF_STEP.STEP_CONSOLIDATORColumn, DataRowVersion.Current);
            insertCommand.AddInParameter(
                     "@@Step_Form_Type", DbType.AnsiStringFixedLength, dsStep.EF_STEP.STEP_FORM_TYPEColumn, DataRowVersion.Current);
            insertCommand.AddInParameter(
                    "@Step_Form_Value", DbType.AnsiStringFixedLength, dsStep.EF_STEP.STEP_FORM_VALUEColumn, DataRowVersion.Current);
           
            #endregion

            #region sentencia update

            sql = "UPDATE ";
            sql += "EF_STEP  ";
            sql += "SET ";
            sql += " STEP_NAME  = @Step_Name,"
                    + " STEP_DESCRIPTION  = @Step_Description, "
                    + " STEP_NEXT_TYPE = @Step_next_Type, "
                    + " STEP_NEXT_VALUE = @Step_next_Value, "
                    + " STEP_PREV_TYPE = @Step_prev_Type, "
                    + " STEP_PREV_VALUE = @Step_prev_Value, "
                    + " STEP_ASSIGNTO_TYPE = @Step_Assignto_Type, "
                    + " STEP_ASSIGNTO_VALUE = @Step_Assignto_Value, "
                    + " STEP_ASSIGNTO_ALGORITHM = @Step_Assignto_Algorithm, "
                    + " STEP_STATUS = @Step_Status, "
                    + " STEP_PERCENT_WEIGHT = @Step_Percent_Weight, "
                    + " STEP_DURATION = @Step_Duration, "
                    + " STEP_START_DATE = Step_Start_Date, "
                    + " STEP_LIMIT_DATE = @Step_Limit_Date, "
                    + " STEP_VIEW_METADATA = @Step_View_Metadata, "
                    + " STEP_EDIT_METADATA = @Step_Edit_Metadata, "
                    + " STEP_ENTER_FUNCTION = @Step_Enter_Function, "
                    + " STEP_EXIT_FUNCTION = @Step_Exit_Function, "
                    + " STEP_ASSIGN_PIC = @Step_Assign_Pic, "
                    + " STEP_CHECKLIST = @Step_Checklist, "
                    + " STEP_SHOW_HELP = @Step_Show_Help, "
                    + " STEP_HELP_HTML = @Step_Help_Html, "
                    + " STEP_CONSOLIDATOR = @Step_Consolidator, "
                    + " STEP_FORM_TYPE = @Step_Form_Type, "
                    + " STEP_FORM_VALUE = @Step_Form_Value "



                    + " WHERE "
                    + " STEP_ID = @Step_idOriginal ";
            DBCommandWrapper updateCommand = BaseDatos.GetSqlStringCommandWrapper(sql);

            #endregion

            #region parametros del update


            updateCommand.AddInParameter(
            "@Step_idOriginal ", DbType.Int32, dsStep.EF_STEP.STEP_IDColumn, DataRowVersion.Original);
            updateCommand.AddInParameter(
                      "@Step_Name", DbType.AnsiStringFixedLength, dsStep.EF_STEP.STEP_NAMEColumn, DataRowVersion.Current);
            updateCommand.AddInParameter(
                    "@Step_Description", DbType.AnsiStringFixedLength, dsStep.EF_STEP.STEP_DESCRIPTIONColumn, DataRowVersion.Current);
            updateCommand.AddInParameter(
                    "@Step_next_Type", DbType.AnsiStringFixedLength, dsStep.EF_STEP.STEP_NEXT_TYPEColumn, DataRowVersion.Current);
            updateCommand.AddInParameter(
                    "@Step_next_Value", DbType.AnsiStringFixedLength, dsStep.EF_STEP.STEP_NEXT_VALUEColumn, DataRowVersion.Current);
            updateCommand.AddInParameter(
                    "@Step_prev_Type", DbType.AnsiStringFixedLength, dsStep.EF_STEP.STEP_PREV_TYPEColumn, DataRowVersion.Current);
            updateCommand.AddInParameter(
                    "@Step_prev_Value", DbType.AnsiStringFixedLength, dsStep.EF_STEP.STEP_PREV_VALUEColumn, DataRowVersion.Current);
            updateCommand.AddInParameter(
                    "@Step_Assignto_Type", DbType.AnsiStringFixedLength, dsStep.EF_STEP.STEP_ASSIGNTO_TYPEColumn, DataRowVersion.Current);
            updateCommand.AddInParameter(
                    "@Step_Assignto_Value", DbType.AnsiStringFixedLength, dsStep.EF_STEP.STEP_ASSIGNTO_VALUEColumn, DataRowVersion.Current);
            updateCommand.AddInParameter(
                     "@Step_Assignto_Algorithm", DbType.AnsiStringFixedLength, dsStep.EF_STEP.STEP_ASSIGNTO_ALGORITHMColumn, DataRowVersion.Current);
            updateCommand.AddInParameter(
                    "@Step_Status", DbType.AnsiStringFixedLength, dsStep.EF_STEP.STEP_STATUSColumn, DataRowVersion.Current);
            updateCommand.AddInParameter(
                    "@Step_Percent_Weight", DbType.Double, dsStep.EF_STEP.STEP_PERCENT_WEIGHTColumn, DataRowVersion.Current);
            updateCommand.AddInParameter(
                     "@Step_Duration", DbType.AnsiStringFixedLength, dsStep.EF_STEP.STEP_DURATIONColumn, DataRowVersion.Current);
            updateCommand.AddInParameter(
                    "@Step_Start_Date", DbType.DateTime, dsStep.EF_STEP.STEP_START_DATEColumn, DataRowVersion.Current);
            updateCommand.AddInParameter(
                    "@Step_Limit_Date", DbType.DateTime, dsStep.EF_STEP.STEP_LIMIT_DATEColumn, DataRowVersion.Current);
            updateCommand.AddInParameter(
                     "@Step_View_Metadata", DbType.Int32, dsStep.EF_STEP.STEP_VIEW_METADATAColumn, DataRowVersion.Current);
            updateCommand.AddInParameter(
                    "@Step_Edit_Metadata", DbType.Int32, dsStep.EF_STEP.STEP_EDIT_METADATAColumn, DataRowVersion.Current);
            updateCommand.AddInParameter(
                    "@Step_Enter_Function", DbType.AnsiStringFixedLength, dsStep.EF_STEP.STEP_ENTER_FUNCTIONColumn, DataRowVersion.Current);
            updateCommand.AddInParameter(
                     "@Step_Exit_Function", DbType.AnsiStringFixedLength, dsStep.EF_STEP.STEP_EXIT_FUNCTIONColumn, DataRowVersion.Current);
            updateCommand.AddInParameter(
                    "@Step_Assign_Pic", DbType.Int32, dsStep.EF_STEP.STEP_ASSIGN_PICColumn, DataRowVersion.Current);
            updateCommand.AddInParameter(
                                    "@Step_Checklist", DbType.AnsiStringFixedLength, dsStep.EF_STEP.STEP_CHECKLISTColumn, DataRowVersion.Current);
            updateCommand.AddInParameter(
                     "@Step_Show_Help", DbType.Int32, dsStep.EF_STEP.STEP_SHOW_HELPColumn, DataRowVersion.Current);
            updateCommand.AddInParameter(
                    "@Step_Help_Html", DbType.AnsiStringFixedLength, dsStep.EF_STEP.STEP_HELP_HTMLColumn, DataRowVersion.Current);
            updateCommand.AddInParameter(
                    "@Step_Consolidator", DbType.Int32, dsStep.EF_STEP.STEP_CONSOLIDATORColumn, DataRowVersion.Current);
            updateCommand.AddInParameter(
                     "@@Step_Form_Type", DbType.AnsiStringFixedLength, dsStep.EF_STEP.STEP_FORM_TYPEColumn, DataRowVersion.Current);
            updateCommand.AddInParameter(
                    "@Step_Form_Value", DbType.AnsiStringFixedLength, dsStep.EF_STEP.STEP_FORM_VALUEColumn, DataRowVersion.Current);



            DBCommandWrapper deleteCommand = null;

            #endregion


            #region sql del Delete

            sql = "DELETE FROM ";
            sql += "EF_STEP  ";
            sql += "WHERE ";
            sql += "  STEP_ID = @Step_idOriginal ";

            deleteCommand = BaseDatos.GetSqlStringCommandWrapper(sql);

            #endregion

            #region parametros del delete
            deleteCommand.AddInParameter("@Step_idOriginal", DbType.Int32, dsStep.EF_STEP.STEP_IDColumn, DataRowVersion.Original);
            #endregion

            if (trans == null)
                return BaseDatos.UpdateDataSet(dsStep, "EF_STEP", insertCommand, updateCommand, deleteCommand, UpdateBehavior.Standard);
            else
                return BaseDatos.UpdateDataSet(dsStep, dsStep.EF_STEP.TableName, insertCommand, updateCommand, deleteCommand, trans);
        }
    }
}