using NavalCommand.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace NavalCommand.Controllers
{
    public class VesselsController : Controller
    {
        // GET: Vessels
        public async Task<ActionResult> Index()
        {
            var client = new HttpClient();
            var response = await client.GetAsync("http://localhost:56541/api/VesselsApi/");
            var vessels = await response.Content.ReadAsAsync<IEnumerable<Vessel>>();
            return View("Vessels", vessels);
        }

        public ActionResult NewVessel()
        {
            return View("NewVessel");
        }

        public async Task<ActionResult> EditVessel(int id)
        {
            var client = new HttpClient();
            var response = await client.GetAsync("http://localhost:56541/api/VesselsApi/" + id);
            var vessel = await response.Content.ReadAsAsync<Vessel>();
            return View("EditVessel", vessel);
        }

        public async Task<ActionResult> ShipDetail(int id)
        {
            var client = new HttpClient();
            var response = await client.GetAsync("http://localhost:56541/api/VesselsApi/" + id);
            var vessel = await response.Content.ReadAsAsync<Vessel>();
            return View("ShipDetail", vessel);
        }

        public async Task<ActionResult> DeleteVessel(int id)
        {
            var client = new HttpClient();
            var response = await client.DeleteAsync("http://localhost:56541/api/VesselsApi/" + id);
            
            return await Index();
        }
    }
}