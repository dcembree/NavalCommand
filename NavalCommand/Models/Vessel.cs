using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Helpers;

namespace NavalCommand.Models
{
    public class Vessel
    {
        #region Constructor

        #endregion

        #region Properties

        [DisplayName("Serial Number")]
        public int Id { get; set; }

        [DisplayName("Vessel Name")]
        public string Name { get; set; }

        [DisplayName("Vessel Class")]
        public string VesselClass { get; set; }

        [DisplayName("Home Port")]
        public string HomePort { get; set; }

        [DisplayName("Commission Date")]
        public DateTime CommissionDate { get; set; }

        [DisplayName("Decommision Date")]
        public DateTime? DecommissionDate { get; set; }

        [DisplayName("Hull Configuration")]
        public string HullConfiguration { get; set; }

        [DisplayName("Hull Status")]
        public string HullStatus { get; set; }

        [DisplayName("Damage Report")]
        public string[] DamageReport { get; set; }

        [DisplayName("Deployment Status")]
        public string DeploymentStatus { get; set; }

        [DisplayName("Crew Complement")]
        public int CrewComplement { get; set; }

        [DisplayName("Current Longitude")]
        public double CurrentLongitude { get; set; }

        [DisplayName("Current Latitude")]
        public double CurrentLatitude { get; set; }

        [DisplayName("Current Heading")]
        public double CurrentHeading { get; set; }

        [DisplayName("Current Speed")]
        public double CurrentSpeed { get; set; }

        [DisplayName("Current Depth")]
        public double CurrentDepth { get; set; }

        [DisplayName("Current Orders")]
        public string CurrentOrders { get; set; }

        #endregion

        #region Members

        #endregion

    }
}