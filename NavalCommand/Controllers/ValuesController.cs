using NavalCommand.DAL;
using NavalCommand.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace NavalCommand.Controllers
{
    public class ValuesController : ApiController
    {
        #region Constructor

        public ValuesController()
        {
            this.Data = new DataAccess(@"Data Source=.\SQLEXPRESS;Initial Catalog=NavalCommandDb;Integrated Security=True");
        }

        #endregion

        #region Properties

        public DataAccess Data { get; set; }

        #endregion

        #region Members

        // GET api/values
        public IEnumerable<string> Get()
        {
            var vessels = Data.GetVessels();
            var results = new List<string>();
            if (null != vessels)
            {
                foreach (var vessel in vessels)
                {
                    results.Add(vessel.ToJson());
                }
            }
            else
                results.Add(new HttpResponseMessage(HttpStatusCode.NoContent).ToString());
            return results;
        }

        // GET api/values/5
        public string Get(int id)
        {
            var vessel = Data.GetVessel(id);
            if (null != vessel)
                return vessel.ToJson();
            else
                return new HttpResponseMessage(HttpStatusCode.NoContent).ToString();
        }

        // POST api/values
        public void Post([FromBody]Vessel value)
        {
            Data.CreateVessel(value);
        }

        // PUT api/values/5
        public void Put(int id, [FromBody]Vessel value)
        {
            Data.UpdateVessel(value);
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
            var currentVessel = Data.GetVessel(id);
            if (null != currentVessel)
                if (currentVessel.DeploymentStatus == "Planned")
                    Data.DeleteVessel(id);
        }

        #endregion
    }
}
