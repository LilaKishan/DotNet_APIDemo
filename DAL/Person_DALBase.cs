using APIDemo.Models;
using Microsoft.Practices.EnterpriseLibrary.Data.Sql;
using System.Data.Common;
using System.Data;
using Microsoft.Practices.EnterpriseLibrary.Data;
using Microsoft.Extensions.Logging.Abstractions;

namespace APIDemo.DAL
{
    public class Person_DALBase : DAL_Helper
    {
        #region API_Person_SelectAll 
        public List<PersonModel> API_Person_SelectAll()
        {
            try
            {
                SqlDatabase sqlDatabase = new SqlDatabase(connstr);
                DbCommand cmd = sqlDatabase.GetStoredProcCommand("API_PERSON_SELECTALL");
                List<PersonModel> personlist = new List<PersonModel>();

                using (IDataReader dr = sqlDatabase.ExecuteReader(cmd))
                {
                    while (dr.Read())
                    {
                        PersonModel pm = new PersonModel();
                        pm.PersonID = Convert.ToInt32(dr["PersonID"].ToString());
                        pm.Pname = dr["Pname"].ToString();
                        pm.Email = dr["Email"].ToString();
                        pm.Contact = dr["Contact"].ToString();
                        personlist.Add(pm);

                    }

                }

                return personlist;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        #endregion

        #region API_PERSON_SELECTBYPK
        public PersonModel API_Person_SelectByPK(int PersonID)
        {
            try
            {
                SqlDatabase sqldb = new SqlDatabase(connstr);
                DbCommand cmd = sqldb.GetStoredProcCommand("API_PERSON_SELECTBYPK");
                sqldb.AddInParameter(cmd, "@PersonID", DbType.Int32, PersonID);
                PersonModel personModel = new PersonModel();
                using (IDataReader dr = sqldb.ExecuteReader(cmd))
                {
                    dr.Read();

                    personModel.PersonID = Convert.ToInt32(dr["PersonID"].ToString());

                    personModel.Pname = dr["Pname"].ToString();
                    personModel.Email = dr["Email"].ToString();
                    personModel.Contact = dr["Contact"].ToString();
                }

                return personModel;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        #endregion

        #region API_Person_Delete
        public  bool API_Person_Delete(int PersonID)
        {
            try
            {
                SqlDatabase sqldb = new SqlDatabase(connstr);
                DbCommand cmd = sqldb.GetStoredProcCommand("API_Person_Delete");
                sqldb.AddInParameter(cmd, "@PersonID", DbType.Int32,PersonID);

                if (Convert.ToBoolean(sqldb.ExecuteNonQuery(cmd)))
                {
                    return true;
                }

                else
                {
                    return false;
                }


            }
            catch(Exception ex)
            {
                return false;
            }
        }
        #endregion

        #region API_Person_Insert
        public bool API_Person_Insert(PersonModel personModel)
        {
            try
            {
                SqlDatabase sqldb = new SqlDatabase(connstr);
                DbCommand cmd = sqldb.GetStoredProcCommand("API_Person_Insert");
                //sqldb.AddInParameter(cmd, "@PersonID", DbType.Int32, personModel.PersonID);
                sqldb.AddInParameter(cmd, "@Pname", DbType.String, personModel.Pname);
                sqldb.AddInParameter(cmd, "@Email", DbType.String, personModel.Email);
                sqldb.AddInParameter(cmd, "@Contact", DbType.String, personModel.Contact);

                if (Convert.ToBoolean(sqldb.ExecuteNonQuery(cmd)))
                {
                    return true;
                }
                else
                {
                    return false;
                }
               
            }
            catch(Exception ex)
            {
                return false;
            }
        }
        #endregion

        #region API_Person_Update
        public bool API_Person_Update(PersonModel personModel)
        {
            try
            {
                SqlDatabase sqldb = new SqlDatabase(connstr);
                DbCommand cmd = sqldb.GetStoredProcCommand("API_Person_update");
                //PersonModel.PersonID = PersonID;
                sqldb.AddInParameter(cmd, "@PersonID", DbType.Int32, personModel.PersonID);
                sqldb.AddInParameter(cmd, "@Pname", DbType.String, personModel.Pname);
                sqldb.AddInParameter(cmd, "@Email", DbType.String, personModel.Email);
                sqldb.AddInParameter(cmd, "@Contact", DbType.String, personModel.Contact);

                if (Convert.ToBoolean(sqldb.ExecuteNonQuery(cmd)))
                {
                    return true;
                }
                else
                {
                    return false;
                }

            }
            catch (Exception ex)
            {
                return false;
            }
        }
       
        #endregion

    }
}
