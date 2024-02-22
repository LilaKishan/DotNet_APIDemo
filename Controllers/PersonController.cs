using APIDemo.BAL;
using APIDemo.DAL;
using APIDemo.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Practices.EnterpriseLibrary.Data.Sql;
using System.Data;
using System.Data.Common;

namespace APIDemo.Controllers
{
        [Route("api/[controller]/[action]")]
        [ApiController]

        public class PersonController : Controller
        {
            [HttpGet]
            public IActionResult Get()
            {
                Person_BALBase bal = new Person_BALBase();
                List<PersonModel> person = bal.API_Person_SelectAll();

                Console.WriteLine(person);
                Dictionary<string, dynamic> response = new Dictionary<string, dynamic>();
                if (person.Count > 0 && person != null)
                {
                    response.Add("status", true);
                    response.Add("message", "Data Found.");
                    response.Add("data", person);
                    return Ok(response);
                }
                else
                {
                    response.Add("status", false);
                    response.Add("message", "Data not Found.");
                    response.Add("data", null);
                    return NotFound(response);
                }
            }

            #region selectbyid
            [HttpGet("{PersonID}")]
            public IActionResult GetByID(int PersonID)
            {
                Person_BALBase personBALBase = new Person_BALBase();
                PersonModel personModel = personBALBase.API_Person_SelectByPK(PersonID);
                // Make the Response in Key Value Pair
                Dictionary<string, dynamic> response = new Dictionary<string, dynamic>();
                if (personModel.PersonID != 0)
                {
                    response.Add("status", true);
                    response.Add("message", "Data Found");
                    response.Add("data", personModel);
                    return Ok(response);
                }
                else
                {
                    response.Add("status", false);
                    response.Add("message", "Data Not Found");
                    response.Add("data", null);
                    return NotFound(response);
                }
            }
            #endregion

            #region Delete

            [HttpDelete("{PersonID}")]
            public IActionResult Delete(int PersonID)
            {
                Person_BALBase personBALBase = new Person_BALBase();
                bool IsSuccess = personBALBase.API_Person_Delete(PersonID);
                // Make the Response in Key Value Pair
                Dictionary<string, dynamic> response = new Dictionary<string, dynamic>();
                if (IsSuccess)
                {
                    response.Add("status", true);
                    response.Add("message", "Data delete successfully");
                    
                    return Ok(response);
                }
                else
                {
                    response.Add("status", false);
                    response.Add("message", "some error occur..!");
                    
                    return NotFound(response);
                }

            }
        #endregion

        #region Post
        [HttpPost]
            public IActionResult Post([FromForm] PersonModel personModel)
            {
                Person_BALBase personBALBase = new Person_BALBase();
                bool IsSuccess = personBALBase.API_Person_Insert(personModel);
                // Make the Response in Key Value Pair
                Dictionary<string, dynamic> response = new Dictionary<string, dynamic>();
                if (IsSuccess)
                {
                    response.Add("status", true);
                    response.Add("message", "Data inserted successfully");

                    return Ok(response);
                }
                else
                {
                    response.Add("status", false);
                    response.Add("message", "some error occur..!");

                    return NotFound(response);
                }

            }
        #endregion

        #region Update mthod:Put
        [HttpPut("{PersonID}")]
            public IActionResult Put(int PersonID,[FromForm]PersonModel personModel)
            {
                Person_BALBase personBALBase = new Person_BALBase();
                personModel.PersonID = PersonID;
                bool IsSuccess = personBALBase.API_Person_Update(personModel);
                
                // Make the Response in Key Value Pair
                Dictionary<string, dynamic> response = new Dictionary<string, dynamic>();
                if (IsSuccess )
                {
                    response.Add("status", true);
                    response.Add("message", "Data updated successfully");
                    
                    return Ok(response);
                }
                else
                {
                    response.Add("status", false);
                    response.Add("message", "some error occures...!");
                
                    return NotFound(response);
                }
            }
        #endregion


        #region Post
        [HttpPost]
        public IActionResult Postuser([FromForm] UserModel userModel)
        {
           // Person_BALBase personBALBase = new Person_BALBase();
           // bool IsSuccess = personBALBase.API_Person_Insert(userModel);
            // Make the Response in Key Value Pair
            Dictionary<string, dynamic> response = new Dictionary<string, dynamic>();
            if (true)
            {
                response.Add("status", true);
                response.Add("message", "Data inserted successfully");

                return Ok(response);
            }
            else
            {
                response.Add("status", false);
                response.Add("message", "some error occur..!");

                return NotFound(response);
            }

        }
        #endregion

    }
}
