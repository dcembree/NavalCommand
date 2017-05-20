using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using NavalCommand.Models;

namespace NavalCommand.Controllers
{
    public class VesselsApiController : ApiController
    {
        private NavalCommandContext db = new NavalCommandContext();

        // GET: api/VesselsApi
        public IQueryable<Vessel> GetVessels()
        {
            var activeStatusList = new[] {"Completed", "Christened", "Deployed", "OnManeuvers", "InAction", "DryDock"};
            return db.Vessels.Where(v => activeStatusList.Any(s => s == v.DeploymentStatus));
        }

        // GET: api/VesselsApi/5
        [ResponseType(typeof(Vessel))]
        public async Task<IHttpActionResult> GetVessel(int id)
        {
            Vessel vessel = await db.Vessels.FindAsync(id);
            if (vessel == null)
            {
                return NotFound();
            }

            return Ok(vessel);
        }

        // PUT: api/VesselsApi/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutVessel(int id, Vessel vessel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != vessel.Id)
            {
                return BadRequest();
            }

            db.Entry(vessel).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!VesselExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/VesselsApi
        [ResponseType(typeof(Vessel))]
        public async Task<IHttpActionResult> PostVessel(Vessel vessel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Vessels.Add(vessel);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = vessel.Id }, vessel);
        }

        // DELETE: api/VesselsApi/5
        [ResponseType(typeof(Vessel))]
        public async Task<IHttpActionResult> DeleteVessel(int id)
        {
            Vessel vessel = await db.Vessels.FindAsync(id);
            if (vessel == null)
            {
                return NotFound();
            }

            //If the vessel has not been built, delete it outright from the database
            if (vessel.DeploymentStatus == "Planned")
            {
                db.Vessels.Remove(vessel);
                await db.SaveChangesAsync();
            }
                //If the vessel is built, deleting means it has been destroyed and the status should change to "Sunk". The ship remains in the database, but is not returned as an active ship.
            else
            {
                vessel.DeploymentStatus = "Sunk";
                vessel.HullStatus = "Breached";
                if (!vessel.DecommissionDate.HasValue)
                    vessel.DecommissionDate = DateTime.Now;
                vessel.CurrentDepth = 500;
                vessel.CurrentOrders = "Rest in peace";
                vessel.CurrentSpeed = 0;
                db.Entry(vessel).State = EntityState.Modified;

                try
                {
                    await db.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!VesselExists(id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
            }

            return Ok(vessel);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool VesselExists(int id)
        {
            return db.Vessels.Count(e => e.Id == id) > 0;
        }
    }
}