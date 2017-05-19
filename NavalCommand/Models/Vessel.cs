using System;
using System.Collections.Generic;
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

        public int Id { get; set; }

        public string Name { get; set; }

        public string VesselClass { get; set; }

        public string HomePort { get; set; }

        public DateTime CommissionDate { get; set; }

        public DateTime? DecommissionDate { get; set; }

        public string HullConfiguration { get; set; }

        public string HullStatus { get; set; }

        public string[] DamageReport { get; set; }

        public string DeploymentStatus { get; set; }

        public int CrewComplement { get; set; }

        public double CurrentLongitude { get; set; }

        public double CurrentLatitude { get; set; }

        public double CurrentHeading { get; set; }

        public double CurrentSpeed { get; set; }

        public double CurrentDepth { get; set; }

        public string CurrentOrders { get; set; }

        #endregion

        #region Members

        public string ToJson()
        {
            return Json.Encode(this);
        }

        public string ToColumnList()
        {
            StringBuilder sb = new StringBuilder();
            if (!string.IsNullOrWhiteSpace(Name))
                sb.AppendFormat("{0},", "Name");
            if (!string.IsNullOrWhiteSpace(VesselClass))
                sb.AppendFormat("{0},", "VesselClass");
            if (!string.IsNullOrWhiteSpace(HomePort))
                sb.AppendFormat("{0},", "HomePort");
            sb.AppendFormat("{0},", "CommissionDate");
            if (DecommissionDate.HasValue)
                sb.AppendFormat("{0},", "DecommissionDate");
            if (!string.IsNullOrWhiteSpace(HullConfiguration))
                sb.AppendFormat("{0},", "HullConfiguration");
            if (!string.IsNullOrWhiteSpace(HullStatus))
                sb.AppendFormat("{0},", "HullStatus");
            if (DamageReport.Count() > 0)
                sb.AppendFormat("{0},", "DamageReport");
            if (!string.IsNullOrWhiteSpace(DeploymentStatus))
                sb.AppendFormat("{0},", "DeploymentStatus");
            if (CrewComplement > 0)
                sb.AppendFormat("{0},", "CrewComplement");
            if (CurrentLongitude > 0)
                sb.AppendFormat("{0},", "CurrentLongitude");
            if (CurrentLatitude > 0)
                sb.AppendFormat("{0},", "CurrentLatitude");
            if (CurrentHeading >= 0 && CurrentHeading <= 360)
                sb.AppendFormat("{0},", "CurrentHeading");
            if (CurrentSpeed >= 0)
                sb.AppendFormat("{0},", "CurrentSpeed");
            if (CurrentDepth >= 0)
                sb.AppendFormat("{0},", "CurrentDepth");
            if (!string.IsNullOrWhiteSpace(CurrentOrders))
                sb.AppendFormat("{0},", "CurrentOrders");
            return sb.ToString().Remove(sb.Length - 2);
        }

        public string ToValueList()
        {
            StringBuilder sb = new StringBuilder();
            if (!string.IsNullOrWhiteSpace(Name))
                sb.AppendFormat("'{0}',", Name);
            if (!string.IsNullOrWhiteSpace(VesselClass))
                sb.AppendFormat("'{0}',", VesselClass);
            if (!string.IsNullOrWhiteSpace(HomePort))
                sb.AppendFormat("'{0}',", HomePort);
            sb.AppendFormat("'{0}',", CommissionDate.ToShortDateString());
            if (DecommissionDate.HasValue)
                sb.AppendFormat("'{0}',", DecommissionDate.Value.ToShortDateString());
            if (!string.IsNullOrWhiteSpace(HullConfiguration))
                sb.AppendFormat("'{0}',", HullConfiguration);
            if (!string.IsNullOrWhiteSpace(HullStatus))
                sb.AppendFormat("'{0}',", HullStatus);
            if (DamageReport.Count() > 0)
            {
                sb.Append("'");
                foreach (var rpt in DamageReport)
                {
                    sb.AppendFormat("{0}|", rpt.Replace("'", ""));
                }
                sb.Append("',");
            }
            if (!string.IsNullOrWhiteSpace(DeploymentStatus))
                sb.AppendFormat("'{0}',", DeploymentStatus);
            if (CrewComplement > 0)
                sb.AppendFormat("'{0}',", CrewComplement);
            if (CurrentLongitude > 0)
                sb.AppendFormat("'{0}',", CurrentLongitude);
            if (CurrentLatitude > 0)
                sb.AppendFormat("'{0}',", CurrentLatitude);
            if (CurrentHeading >= 0 && CurrentHeading <= 360)
                sb.AppendFormat("'{0}',", CurrentHeading);
            if (CurrentSpeed >= 0)
                sb.AppendFormat("'{0}',", CurrentSpeed);
            if (CurrentDepth >= 0)
                sb.AppendFormat("'{0}',", CurrentDepth);
            if (!string.IsNullOrWhiteSpace(CurrentOrders))
                sb.AppendFormat("'{0}',", CurrentOrders);
            return sb.ToString().Remove(sb.Length - 2);
        }

        public string ToUpdateList()
        {
            StringBuilder sb = new StringBuilder();
            if (!string.IsNullOrWhiteSpace(Name))
                sb.AppendFormat("{0} = '{1}',", "Name", Name);
            if (!string.IsNullOrWhiteSpace(VesselClass))
                sb.AppendFormat("{0} = '{1}',", "VesselClass", VesselClass);
            if (!string.IsNullOrWhiteSpace(HomePort))
                sb.AppendFormat("{0} = '{1}',", "HomePort", HomePort);
            sb.AppendFormat("{0} = '{1}',", "CommissionDate", CommissionDate.ToShortDateString());
            if (DecommissionDate.HasValue)
                sb.AppendFormat("{0} = '{1}',", "DecommissionDate", DecommissionDate.Value.ToShortDateString());
            if (!string.IsNullOrWhiteSpace(HullConfiguration))
                sb.AppendFormat("{0} = '{1}',", "HullConfiguration", HullConfiguration);
            if (!string.IsNullOrWhiteSpace(HullStatus))
                sb.AppendFormat("{0} = '{1}',", "HullStatus", HullStatus);
            if (DamageReport.Count() > 0)
            {
                sb.Append("DamageReport = '");
                foreach (var rpt in DamageReport)
                {
                    sb.AppendFormat("{0}|", rpt.Replace("'", ""));
                }
                sb.Append("',");
            }
            if (!string.IsNullOrWhiteSpace(DeploymentStatus))
                sb.AppendFormat("{0} = '{1}',", "DeploymentStatus", DeploymentStatus);
            if (CrewComplement > 0)
                sb.AppendFormat("{0} = '{1}',", "CrewComplement", CrewComplement);
            if (CurrentLongitude > 0)
                sb.AppendFormat("{0} = '{1}',", "CurrentLongitude", CurrentLongitude);
            if (CurrentLatitude > 0)
                sb.AppendFormat("{0} = '{1}',", "CurrentLatitude", CurrentLatitude);
            if (CurrentHeading >= 0 && CurrentHeading <= 360)
                sb.AppendFormat("{0} = '{1}',", "CurrentHeading", CurrentHeading);
            if (CurrentSpeed >= 0)
                sb.AppendFormat("{0} = '{1}',", "CurrentSpeed", CurrentSpeed);
            if (CurrentDepth >= 0)
                sb.AppendFormat("{0} = '{1}',", "CurrentDepth", CurrentDepth);
            if (!string.IsNullOrWhiteSpace(CurrentOrders))
                sb.AppendFormat("{0} = '{1}',", "CurrentOrders", CurrentOrders);
            return sb.ToString().Remove(sb.Length - 2);
        }

        #endregion

    }
}