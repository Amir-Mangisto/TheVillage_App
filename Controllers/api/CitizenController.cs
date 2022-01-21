using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using TheVillage_App.Models;

namespace TheVillage_App.Controllers.api
{
    public class CitizenController : ApiController
    {
        TheVillageContext theVillageContext = new TheVillageContext();
        // GET: api/Citizen
        public IHttpActionResult Get()
        {
            try
            {
                return Ok(theVillageContext.Citizens.ToList());
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

        // GET: api/Citizen/5
        public async  Task<IHttpActionResult> Get(int id)
        {
            try
            {
                Citizen citizen = await theVillageContext.Citizens.FindAsync(id);
                if (citizen.FatherName != null) return Ok(citizen);
                else
                {
                    return NotFound();
                }

            }
            catch(SqlException ex)
            {
                return BadRequest(ex.Message);
            }
            catch(Exception err)
            {
                return BadRequest(err.Message);
            }
        }

        // POST: api/Citizen
        public async Task<IHttpActionResult> Post([FromBody] Citizen addCitizen)
        {
            try
            {
                theVillageContext.Citizens.Add(addCitizen);
                await theVillageContext.SaveChangesAsync();
                return Ok("Citizen was Added");
            }
            catch(SqlException ex)
            {
                return BadRequest(ex.Message);
            }
            catch(Exception err)
            {
                return BadRequest(err.Message);
            }
        }

        // PUT: api/Citizen/5
        public async Task<IHttpActionResult> Put(int id, [FromBody] Citizen userCitizen)
        {
            try
            {
                Citizen citizenToUpdate = await theVillageContext.Citizens.FindAsync(id);
                citizenToUpdate.FirstName = userCitizen.FirstName;
                citizenToUpdate.FatherName = userCitizen.FatherName;
                citizenToUpdate.Gender= userCitizen.Gender;
                citizenToUpdate.BornInVillage=userCitizen.BornInVillage;
                citizenToUpdate.BirthDate = userCitizen.BirthDate;
                await theVillageContext.SaveChangesAsync();

                return Ok("Citizen was Updated");
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

        // DELETE: api/Citizen/5
        public async Task<IHttpActionResult> Delete(int id)
        {
            try
            {
                Citizen citizenToDelet = await theVillageContext.Citizens.FindAsync(id);
                theVillageContext.Citizens.Remove(citizenToDelet);
                await theVillageContext.SaveChangesAsync();
                return Ok("Citizen was deleted");
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
