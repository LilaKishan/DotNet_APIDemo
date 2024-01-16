using APIDemo.DAL;
using APIDemo.Models;

namespace APIDemo.BAL
{
    public class Person_BALBase
    {
        #region API_Person_SelectAll
        public List<PersonModel> API_Person_SelectAll()
        {
            try
            {
                Person_DALBase dalPerson = new Person_DALBase();
                List<PersonModel> pm=dalPerson.API_Person_SelectAll();
         
                return pm;
            }
            catch (Exception ex){ return null; }
        }
        #endregion

        #region API_Person_SelectByPK
        public PersonModel API_Person_SelectByPK(int PersonId)
        {
            try
            {
                Person_DALBase personDAL = new Person_DALBase();
                PersonModel personModel = personDAL.API_Person_SelectByPK(PersonId);
                //Console.WriteLine(personModel);
                return personModel;
            }
            catch (Exception ex) { return null; }

        }
        #endregion

        #region API_Person_Delete
        public bool API_Person_Delete(int PersonID)
        {
            try
            {
                Person_DALBase personDAL = new Person_DALBase();
                
                
                if (personDAL.API_Person_Delete(PersonID))
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

        #region API_Person_Insert
        public bool API_Person_Insert(PersonModel personModel)
        {
            try
            {
                Person_DALBase DALperson = new Person_DALBase();

                if (DALperson.API_Person_Insert(personModel))
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

        #region API_Person_Update
        public bool API_Person_Update(PersonModel personModel)
        {
            try
            {
                Person_DALBase personDAL = new Person_DALBase();
                
                if (personDAL.API_Person_Update(personModel))
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
