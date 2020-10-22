using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data;
using Btgsa.Cgweb.Proyecto.AccesoDatos;
using Btgsa.Cgweb.Proyecto.EntidadNegocio;
///using Btgsa.Cgweb.Proyecto.LogicaNegocio;


namespace Btgsa.Cgweb.Proyecto.LogicaNegocio
{
    public class ProfesorManejador
    {
        public ProfesorManejador()
        {

        }

        public FileTypeDST ListarProfesores()
        {
            return new FileTypeDALC().Fill();
        }

        public int GrabarEF_FILETYPE(FileTypeDST dsFileType)
        {

            Transaccion objTransaction = new Transaccion();

            IDbTransaction trans = objTransaction.BeginTransaction();

            try
            {
                new FileTypeDALC().Update(dsFileType, trans);

                trans.Commit();
                return 0;
            }
            catch (System.Exception ex)
            {
                trans.Rollback();
                throw;

            }


        }

        public int GrabarFileTypeSinDataSet(string FILETYPE_NAME, string FILETYPE_DESCRIPTION, string FILETYPE_TYPES, int FILETYPE_FLOW)
        {
            FileTypeDST dsFileType = new FileTypeDST();
            FileTypeDST.EF_FILETYPERow unFileType = null;
            unFileType = dsFileType.EF_FILETYPE.NewEF_FILETYPERow();
            unFileType.FILETYPE_ID = 0;
            unFileType.FILETYPE_NAME = FILETYPE_NAME;
            unFileType.FILETYPE_DESCRIPTION = FILETYPE_DESCRIPTION;
            unFileType.FILETYPE_TYPES = FILETYPE_TYPES;
            unFileType.FILETYPE_FLOW = FILETYPE_FLOW;
            dsFileType.EF_FILETYPE.AddEF_FILETYPERow(unFileType);
            return GrabarEF_FILETYPE(dsFileType);
        }
        public List<EF_FILETYPE> ListarProfesorClase()
        {
            List<EF_FILETYPE> listaEF_FILETYPE = new List<EF_FILETYPE>();
            FileTypeDST dsFileType = new FileTypeDALC().Fill();
            foreach (FileTypeDST.EF_FILETYPERow row in dsFileType.EF_FILETYPE)
            {
                EF_FILETYPE objEF_FILETYPE = new EF_FILETYPE();
                objEF_FILETYPE.FILETYPE_ID = row.FILETYPE_ID;
                objEF_FILETYPE.FILETYPE_DESCRIPTION = row.FILETYPE_DESCRIPTION;
                objEF_FILETYPE.FILETYPE_NAME = row.FILETYPE_NAME;
                objEF_FILETYPE.FILETYPE_TYPES = row.FILETYPE_TYPES;
                objEF_FILETYPE.FILETYPE_FLOW = row.FILETYPE_FLOW;
                listaEF_FILETYPE.Add(objEF_FILETYPE);
            }
            return listaEF_FILETYPE;
        }



    }
}
