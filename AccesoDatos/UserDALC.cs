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
    public class UserDALC : AccesoDatosBase
    {
        public UserDALC()
        {

        }


        public UserDST Fill()
        {

            StringBuilder sql = new StringBuilder();
            sql.Append("SELECT ");
            sql.Append("USER_ID User_Id, "); 
            sql.Append("USER_NAME User_Name, ");
            sql.Append("USER_ROLE User_Role, ");
            sql.Append("USER_AREA User_Area, ");
            sql.Append("USER_BLOCKED User_Blocked, "); 
            sql.Append("USER_ACTIVE User_Active, ");
            sql.Append("USER_IMAGE User_Image, "); 
            sql.Append("USER_EMAIL User_Email, ");
            sql.Append("USER_LASTFLOW User_Lastflow, ");
            sql.Append("USER_REPORTS_TO User_Reports_To, ");
            sql.Append("USER_ADDITIONAL_DATA_1 User_Additional_Data1, ");
            sql.Append("USER_ADDITIONAL_DATA_2 User_Additional_Data2, ");
            sql.Append("USER_ADDITIONAL_DATA_3 User_Additional_Data3, ");
            sql.Append("USER_ADDITIONAL_DATA_4 User_Additional_Data4, ");
            sql.Append("USER_ADDITIONAL_DATA_5 User_Additional_Data5, ");
            sql.Append("USER_ADDITIONAL_DATA_6 User_Additional_Data6, ");
            sql.Append("USER_ADDITIONAL_DATA_7 User_Additional_Data7, ");
            sql.Append("USER_ADDITIONAL_DATA_8 User_Additional_Data8, ");
            sql.Append("USER_ADDITIONAL_DATA_9 User_Additional_Data9, ");
            sql.Append("USER_ADDITIONAL_DATA_10 User_Additional_Data10 ");

            sql.Append(" FROM  ");
            sql.Append("EF_USER ");
            sql.Append(" ORDER BY STEP_ID ASC ");
            DBCommandWrapper dbCommandWrapper = BaseDatos.GetSqlStringCommandWrapper(sql.ToString());
            UserDST dsUser = new UserDST();
            BaseDatos.LoadDataSet(dbCommandWrapper, dsUser, "EF_USER");
            return dsUser;
        }

        public int Update(UserDST dsUser, IDbTransaction trans)
        {

            #region comando insert


            string sql = "INSERT INTO ";
            sql += "EF_USER ";

            sql += "(";
            sql += BaseDatos.ConfigurationName == Constantes.BDDORACLE ? "USER_ID, " : ""; //SOLO ORACLE 
            sql += "USER_NAME, USER_ROLE, USER_AREA, USER_BLOCKED, USER_ACTIVE, USER_IMAGE," +
                " USER_EMAIL, USER_LASTFLOW, USER_REPORTS_TO, USER_ADDITIONAL_DATA_1, USER_ADDITIONAL_DATA_2" +
                "USER_ADDITIONAL_DATA_3,USER_ADDITIONAL_DATA_4,USER_ADDITIONAL_DATA_5,USER_ADDITIONAL_DATA_6" +
                "USER_ADDITIONAL_DATA_7, USER_ADDITIONAL_DATA_8, USER_ADDITIONAL_DATA_9, USER_ADDITIONAL_DATA_10 ) "
                    + " VALUES( ";
            sql += BaseDatos.ConfigurationName == Constantes.BDDORACLE ? "STEP_ID.NEXTVAL, " : ""; //SOLO ORACLE 
            sql += "@User_Id, @User_Name, @User_Role, @User_Area, @User_Blocked, @User_Active, @User_Image" +
                "@User_Email, @User_Lastflow, @User_Reports_To, @User_Additional_Data1, " +
                "@User_Additional_Data2, @User_Additional_Data3, @User_Additional_Data4," +
                "@User_Additional_Data5, @User_Additional_Data6, @User_Additional_Data7, " +
                "@User_Additional_Data8, @User_Additional_Data9, @User_Additional_Data10)";

            DBCommandWrapper insertCommand = BaseDatos.GetSqlStringCommandWrapper(sql);
            insertCommand.AddInParameter(
                    "@User_Name", DbType.AnsiStringFixedLength, dsUser.EF_USER.USER_NAMEColumn, DataRowVersion.Current);
            insertCommand.AddInParameter(
                    "@User_Role", DbType.AnsiStringFixedLength, dsUser.EF_USER.USER_ROLEColumn, DataRowVersion.Current);
            insertCommand.AddInParameter(
                    "@USER_AREA", DbType.AnsiStringFixedLength, dsUser.EF_USER.USER_AREAColumn, DataRowVersion.Current);
            insertCommand.AddInParameter(
                    "@User_Blocked", DbType.AnsiStringFixedLength, dsUser.EF_USER.USER_BLOCKEDColumn, DataRowVersion.Current);
            insertCommand.AddInParameter(
                    "@User_Active", DbType.AnsiStringFixedLength, dsUser.EF_USER.USER_ACTIVEColumn, DataRowVersion.Current);
            insertCommand.AddInParameter(
                    "@User_Image", DbType.AnsiStringFixedLength, dsUser.EF_USER.USER_IMAGEColumn, DataRowVersion.Current);
            insertCommand.AddInParameter(
                    "@User_Email", DbType.AnsiStringFixedLength, dsUser.EF_USER.USER_EMAILColumn, DataRowVersion.Current);
            insertCommand.AddInParameter(
                    "@User_Lastflow", DbType.Int32, dsUser.EF_USER.USER_LASTFLOWColumn, DataRowVersion.Current);
            insertCommand.AddInParameter(
                     "@User_Reports_To", DbType.AnsiStringFixedLength, dsUser.EF_USER.USER_REPORTS_TOColumn, DataRowVersion.Current);
            insertCommand.AddInParameter(
                    "@User_Additional_Data1", DbType.AnsiStringFixedLength, dsUser.EF_USER.USER_ADDITIONAL_DATA_1Column, DataRowVersion.Current);
            insertCommand.AddInParameter(
                    "@User_Additional_Data2", DbType.AnsiStringFixedLength, dsUser.EF_USER.USER_ADDITIONAL_DATA_2Column, DataRowVersion.Current);
            insertCommand.AddInParameter(
                    "@User_Additional_Data3", DbType.AnsiStringFixedLength, dsUser.EF_USER.USER_ADDITIONAL_DATA_3Column, DataRowVersion.Current);
            insertCommand.AddInParameter(
                    "@User_Additional_Data4", DbType.AnsiStringFixedLength, dsUser.EF_USER.USER_ADDITIONAL_DATA_4Column, DataRowVersion.Current);
            insertCommand.AddInParameter(
                    "@User_Additional_Data5", DbType.AnsiStringFixedLength, dsUser.EF_USER.USER_ADDITIONAL_DATA_5Column, DataRowVersion.Current);
            insertCommand.AddInParameter(
                    "@User_Additional_Data6", DbType.AnsiStringFixedLength, dsUser.EF_USER.USER_ADDITIONAL_DATA_6Column, DataRowVersion.Current);
            insertCommand.AddInParameter(
                    "@User_Additional_Data7", DbType.AnsiStringFixedLength, dsUser.EF_USER.USER_ADDITIONAL_DATA_7Column, DataRowVersion.Current);
            insertCommand.AddInParameter(
                    "@User_Additional_Data8", DbType.AnsiStringFixedLength, dsUser.EF_USER.USER_ADDITIONAL_DATA_8Column, DataRowVersion.Current);
            insertCommand.AddInParameter(
                    "@User_Additional_Data9", DbType.AnsiStringFixedLength, dsUser.EF_USER.USER_ADDITIONAL_DATA_9Column, DataRowVersion.Current);
            insertCommand.AddInParameter(
                    "@User_Additional_Data10", DbType.AnsiStringFixedLength, dsUser.EF_USER.USER_ADDITIONAL_DATA_10Column, DataRowVersion.Current);



            #endregion

            #region sentencia update

            sql = "UPDATE ";
            sql += "EF_USER  ";
            sql += "SET ";
            sql += " USER_NAME  = @User_Name, "
                    + " USER_ROLE = @User_Role, "
                    + " USER_AREA = @User_Area, "
                    + " USER_BLOCKED = @User_Blocked, "
                    + " USER_ACTIVE = @User_Active, "
                    + " USER_IMAGE = @User_Image, "
                    + " USER_EMAIL = @User_Email, "
                    + " USER_LASTFLOW = @User_Lastflow, "
                    + " USER_REPORTS_TO = @User_Reports_To, "
                    + " USER_ADDITIONAL_DATA_1 = @User_Additional_Data1, "
                    + " USER_ADDITIONAL_DATA_2 = @User_Additional_Data2, "
                    + " USER_ADDITIONAL_DATA_3 = @User_Additional_Data3, "
                    + " USER_ADDITIONAL_DATA_4 = @User_Additional_Data4, "
                    + " USER_ADDITIONAL_DATA_5 = @User_Additional_Data5, "
                    + " USER_ADDITIONAL_DATA_6 = @User_Additional_Data6, "
                    + " USER_ADDITIONAL_DATA_7 = @User_Additional_Data7, "
                    + " USER_ADDITIONAL_DATA_8 = @User_Additional_Data8, "
                    + " USER_ADDITIONAL_DATA_9 = @User_Additional_Data9, "
                    + " USER_ADDITIONAL_DATA_10 = @User_Additional_Data10"
                    + " WHERE "
                    + " USER_ID = @User_idOriginal ";
            DBCommandWrapper updateCommand = BaseDatos.GetSqlStringCommandWrapper(sql);

            #endregion

            #region parametros del update

            sql += "USER_NAME, USER_ROLE, USER_AREA, USER_BLOCKED, USER_ACTIVE, USER_IMAGE," +
                " USER_EMAIL, USER_LASTFLOW, USER_REPORTS_TO, USER_ADDITIONAL_DATA_1, USER_ADDITIONAL_DATA_2" +
                "USER_ADDITIONAL_DATA_3,USER_ADDITIONAL_DATA_4,USER_ADDITIONAL_DATA_5,USER_ADDITIONAL_DATA_6" +
                "USER_ADDITIONAL_DATA_7, USER_ADDITIONAL_DATA_8, USER_ADDITIONAL_DATA_9, USER_ADDITIONAL_DATA_10 ) ";

            updateCommand.AddInParameter(
            "@User_idOriginal ", DbType.Int32, dsUser.EF_USER.USER_IDColumn, DataRowVersion.Original);
            updateCommand.AddInParameter(
                      "@User_Name", DbType.AnsiStringFixedLength, dsUser.EF_USER.USER_NAMEColumn, DataRowVersion.Current);
            updateCommand.AddInParameter(
                    "@User_Role", DbType.AnsiStringFixedLength, dsUser.EF_USER.USER_ROLEColumn, DataRowVersion.Current);
            updateCommand.AddInParameter(
                    "@User_Area", DbType.AnsiStringFixedLength, dsUser.EF_USER.USER_AREAColumn, DataRowVersion.Current);
            updateCommand.AddInParameter(
                    "@User_Blocked", DbType.AnsiStringFixedLength, dsUser.EF_USER.USER_BLOCKEDColumn, DataRowVersion.Current);
            updateCommand.AddInParameter(
                    "@User_Active", DbType.AnsiStringFixedLength, dsUser.EF_USER.USER_ACTIVEColumn, DataRowVersion.Current);
            updateCommand.AddInParameter(
                    "@User_Image", DbType.AnsiStringFixedLength, dsUser.EF_USER.USER_IMAGEColumn, DataRowVersion.Current);
            updateCommand.AddInParameter(
                    "@User_Email", DbType.AnsiStringFixedLength, dsUser.EF_USER.USER_EMAILColumn, DataRowVersion.Current);
            updateCommand.AddInParameter(
                    "@User_Lastflow", DbType.AnsiStringFixedLength, dsUser.EF_USER.USER_LASTFLOWColumn, DataRowVersion.Current);
            updateCommand.AddInParameter(
                     "@User_Reports_To", DbType.AnsiStringFixedLength, dsUser.EF_USER.USER_REPORTS_TOColumn, DataRowVersion.Current);
            updateCommand.AddInParameter(
                    "@User_Additional_Data1", DbType.AnsiStringFixedLength, dsUser.EF_USER.USER_ADDITIONAL_DATA_1Column, DataRowVersion.Current);
            updateCommand.AddInParameter(
                    "@User_Additional_Data2", DbType.AnsiStringFixedLength, dsUser.EF_USER.USER_ADDITIONAL_DATA_2Column, DataRowVersion.Current);
            updateCommand.AddInParameter(
                     "@User_Additional_Data3", DbType.AnsiStringFixedLength, dsUser.EF_USER.USER_ADDITIONAL_DATA_3Column, DataRowVersion.Current);
            updateCommand.AddInParameter(
                    "@User_Additional_Data4", DbType.AnsiStringFixedLength, dsUser.EF_USER.USER_ADDITIONAL_DATA_4Column, DataRowVersion.Current);
            updateCommand.AddInParameter(
                    "@User_Additional_Data5", DbType.AnsiStringFixedLength, dsUser.EF_USER.USER_ADDITIONAL_DATA_5Column, DataRowVersion.Current);
            updateCommand.AddInParameter(
                     "@User_Additional_Data6", DbType.AnsiStringFixedLength, dsUser.EF_USER.USER_ADDITIONAL_DATA_6Column, DataRowVersion.Current);
            updateCommand.AddInParameter(
                    "@User_Additional_Data7", DbType.AnsiStringFixedLength, dsUser.EF_USER.USER_ADDITIONAL_DATA_7Column, DataRowVersion.Current);
            updateCommand.AddInParameter(
                    "@User_Additional_Data8", DbType.AnsiStringFixedLength, dsUser.EF_USER.USER_ADDITIONAL_DATA_8Column, DataRowVersion.Current);
            updateCommand.AddInParameter(
                     "@User_Additional_Data9", DbType.AnsiStringFixedLength, dsUser.EF_USER.USER_ADDITIONAL_DATA_9Column, DataRowVersion.Current);
            updateCommand.AddInParameter(
                    "@User_Additional_Data10", DbType.AnsiStringFixedLength, dsUser.EF_USER.USER_ADDITIONAL_DATA_10Column, DataRowVersion.Current);



            DBCommandWrapper deleteCommand = null;

            #endregion


            #region sql del Delete

            sql = "DELETE FROM ";
            sql += "EF_USER  ";
            sql += "WHERE ";
            sql += "  USER_ID = @User_idOriginal ";

            deleteCommand = BaseDatos.GetSqlStringCommandWrapper(sql);

            #endregion

            #region parametros del delete
            deleteCommand.AddInParameter("@User_idOriginal", DbType.Int32, dsUser.EF_USER.USER_IDColumn, DataRowVersion.Original);
            #endregion

            if (trans == null)
                return BaseDatos.UpdateDataSet(dsUser, "EF_USER", insertCommand, updateCommand, deleteCommand, UpdateBehavior.Standard);
            else
                return BaseDatos.UpdateDataSet(dsUser, dsUser.EF_USER.TableName, insertCommand, updateCommand, deleteCommand, trans);
        }
    }
}
