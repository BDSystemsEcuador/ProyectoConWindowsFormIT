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
    public class FileTypeDALC: AccesoDatosBase
    {
        public FileTypeDALC()
        {

        }


        public FileTypeDST Fill()
        {

            StringBuilder sql = new StringBuilder();
            sql.Append("SELECT ");
            sql.Append("FILETYPE_ID Filetype_Id, ");
            sql.Append("FILETYPE_NAME Filetype_Name, ");
            sql.Append("FILETYPE_DESCRIPTION Filetype_Description, ");
            sql.Append("FILETYPE_TYPES Filetype_Type, ");
            sql.Append("FILETYPE_FLOW Filetype_Flow, ");
            sql.Append("FILETYPE_CATEGORY Filetype_Category ");
            sql.Append(" FROM  ");
            sql.Append("EF_FILETYPE ");
            sql.Append(" ORDER BY FILETYPE_ID ASC ");
            DBCommandWrapper dbCommandWrapper = BaseDatos.GetSqlStringCommandWrapper(sql.ToString());
            FileTypeDST dsFileType = new FileTypeDST();
            BaseDatos.LoadDataSet(dbCommandWrapper, dsFileType, "EF_FILETYPE");
            return dsFileType;
        }

        public int Update(FileTypeDST dsFileType, IDbTransaction trans)
        {

            #region comando insert


            string sql = "INSERT INTO ";
            sql += "EF_FILETYPE ";

            sql += "(";
            sql += BaseDatos.ConfigurationName == Constantes.BDDORACLE ? "FILETYPE_ID, " : ""; //SOLO ORACLE 
            sql += "FILETYPE_NAME, FILETYPE_DESCRIPTION, FILETYPE_TYPES,  "
                    + "FILETYPE_FLOW, FILETYPE_CATEGORY ) "
                    + " VALUES( ";
            sql += BaseDatos.ConfigurationName == Constantes.BDDORACLE ? "FILETYPE_ID.NEXTVAL, " : ""; //SOLO ORACLE 
            sql += " @Nombre, @Cedula, "
                    + "@Telefono, @Edad )";

            DBCommandWrapper insertCommand = BaseDatos.GetSqlStringCommandWrapper(sql);
            insertCommand.AddInParameter(
                    "@Filetype_Name", DbType.AnsiStringFixedLength, dsFileType.EF_FILETYPE.FILETYPE_NAMEColumn, DataRowVersion.Current);
            insertCommand.AddInParameter(
                    "@Filetype_Description", DbType.AnsiStringFixedLength, dsFileType.EF_FILETYPE.FILETYPE_DESCRIPTIONColumn, DataRowVersion.Current);
            insertCommand.AddInParameter(
                    "@Filetype_Types", DbType.AnsiStringFixedLength, dsFileType.EF_FILETYPE.FILETYPE_TYPESColumn, DataRowVersion.Current);
            insertCommand.AddInParameter(
                   "@Filetype_Flow", DbType.Int32, dsFileType.EF_FILETYPE.FILETYPE_FLOWColumn, DataRowVersion.Current);
            insertCommand.AddInParameter(
                 "@Filetype_Category", DbType.AnsiStringFixedLength, dsFileType.EF_FILETYPE.FILETYPE_CATEGORYColumn, DataRowVersion.Current);

            #endregion

            #region sentencia update

            sql = "UPDATE ";
            sql += "EF_FILETYPE  ";
            sql += "SET ";
            sql += " FILETYPE_NAME  = @Filetype_Name,"
                    + " FILETYPE_DESCRIPTION  = @Filetype_Description, "
                    + " FILETYPE_TYPES  = @Filetype_Types, "
                    + " FILETYPE_FLOW  = @Filetype_Flow, "
                    + " FILETYPE_CATEGORY  = @Filetype_Category "
                    + " WHERE "
                    + " FILETYPE_ID = @Filetype_idOriginal ";
            DBCommandWrapper updateCommand = BaseDatos.GetSqlStringCommandWrapper(sql);

            #endregion

            #region parametros del update


            updateCommand.AddInParameter(
            "@Filetype_idOriginal ", DbType.Int32, dsFileType.EF_FILETYPE.FILETYPE_IDColumn, DataRowVersion.Original);
            updateCommand.AddInParameter(
                "@Filetype_Name", DbType.AnsiStringFixedLength, dsFileType.EF_FILETYPE.FILETYPE_NAMEColumn, DataRowVersion.Current);
            updateCommand.AddInParameter(
                "@Filetype_Description", DbType.AnsiStringFixedLength, dsFileType.EF_FILETYPE.FILETYPE_DESCRIPTIONColumn, DataRowVersion.Current);
            updateCommand.AddInParameter(
                "@Filetype_Types", DbType.AnsiStringFixedLength, dsFileType.EF_FILETYPE.FILETYPE_TYPESColumn, DataRowVersion.Current);
            updateCommand.AddInParameter(
               "@Filetype_Flow", DbType.Int32, dsFileType.EF_FILETYPE.FILETYPE_FLOWColumn, DataRowVersion.Current);
            updateCommand.AddInParameter(
               "@Filetype_Category", DbType.AnsiStringFixedLength, dsFileType.EF_FILETYPE.FILETYPE_CATEGORYColumn, DataRowVersion.Current);

            DBCommandWrapper deleteCommand = null;

            #endregion


            #region sql del Delete

            sql = "DELETE FROM ";
            sql += "EF_FILETYPE  ";
            sql += "WHERE ";
            sql += "  FILETYPE_ID = @Filetype_idOriginal ";

            deleteCommand = BaseDatos.GetSqlStringCommandWrapper(sql);

            #endregion

            #region parametros del delete
            deleteCommand.AddInParameter("@Filetype_idOriginal", DbType.Int32, dsFileType.EF_FILETYPE.FILETYPE_IDColumn, DataRowVersion.Original);
            #endregion

            if (trans == null)
                return BaseDatos.UpdateDataSet(dsFileType, "EF_FILETYPE", insertCommand, updateCommand, deleteCommand, UpdateBehavior.Standard);
            else
                return BaseDatos.UpdateDataSet(dsFileType, dsFileType.EF_FILETYPE.TableName, insertCommand, updateCommand, deleteCommand, trans);
        }
    }
}


