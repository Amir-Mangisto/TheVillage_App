using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TheVillage_App.Models;

namespace TheVillage_App.Controllers.api
{
    public class ElderController : ApiController
    {
        ElderContextDataContext elderContextDataContext = new ElderContextDataContext();
        // GET: api/Elder
        public IHttpActionResult Get()
        {
            try
            {
                return Ok(elderContextDataContext.Elders.ToList());
            }
            catch (SqlException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception err)
            {
                return BadRequest(err.Message);
            }
        }

        // GET: api/Elder/5
        public IHttpActionResult Get(int id)
        {
            try
            {
                Elder elder = elderContextDataContext.Elders.First(elderItem=>elderItem.Id == id);
                if (elder.FirstName != null) return Ok(elder);
                else
                {
                    return NotFound();
                }

            }
            catch (SqlException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception err)
            {
                return BadRequest(err.Message);
            }
        }

        // POST: api/Elder
        public IHttpActionResult Post([FromBody] Elder addElder)
        {
            try
            {
                elderContextDataContext.Elders.InsertOnSubmit(addElder);
                elderContextDataContext.SubmitChanges();
                return Ok("Elder was Added");
            }
            catch (SqlException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception err)
            {
                return BadRequest(err.Message);
            }
        }

        // PUT: api/Elder/5
        public IHttpActionResult Put(int id, [FromBody] Elder updateElder)
        {
            try
            {
                Elder elderToUpdate = elderContextDataContext.Elders.First(elderItem => elderItem.Id == id);
                elderToUpdate.FirstName = updateElder.FirstName;
                elderToUpdate.Birth=updateElder.Birth;
                elderToUpdate.Seniority = updateElder.Seniority;
                elderContextDataContext.SubmitChanges();
                return Ok("Elder was Updated");
            }
            catch (SqlException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception err)
            {
                return BadRequest(err.Message);
            }
        }

        // DELETE: api/Elder/5
        public IHttpActionResult Delete(int id)
        {
            try
            {
                Elder elderToDelete = elderContextDataContext.Elders.First(elderItem => elderItem.Id == id);
                elderContextDataContext.Elders.DeleteOnSubmit(elderToDelete);
                elderContextDataContext.SubmitChanges();
                return Ok("Elder was Deleted");
            }
            catch (SqlException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception err)
            {
                return BadRequest(err.Message);
            }
        }
    }
}
