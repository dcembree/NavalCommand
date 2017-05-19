using NavalCommand.Models;
using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Linq;

namespace NavalCommand.DAL
{
    public class DataAccess : IDisposable
    {
        #region Constructor

        public DataAccess(string connectionString)
        {
            this.Context = new DataContext(connectionString);
        }

        #endregion

        #region Properties

        public DataContext Context { get; set; }

        public Exception Error { get; set; }

        #endregion

        #region Members

        public List<Vessel> GetVessels()
        {
            try
            {
                return Context.ExecuteQuery<Vessel>("SELECT * FROM Vessels WHERE DeploymentStatus IN ('Completed', 'Christened', 'Deployed', 'OnManeuvers', 'InAction', 'DryDock')").ToList();
            }
            catch (Exception ex)
            {
                Error = ex;
                return null;
            }
        }

        public Vessel GetVessel(int id)
        {
            try
            {
                return Context.ExecuteQuery<Vessel>("SELECT * FROM Vessels WHERE id = {0}", id).FirstOrDefault();
            }
            catch (Exception ex)
            {
                Error = ex;
                return null;
            }
        }

        public void CreateVessel(Vessel vessel)
        {
            try
            {
                int result = Context.ExecuteCommand("INSERT INTO Vessels ({0}) VALUES ({1})", vessel.ToColumnList(), vessel.ToValueList());
                if (result != 1)
                    Error = new Exception("New row was NOT created.");

            }
            catch (Exception ex) { Error = ex; }
        }

        public void UpdateVessel(Vessel vessel)
        {
            try
            {
                int result = Context.ExecuteCommand("UPDATE Vessels SET {0} WHERE Id = {1}", vessel.ToUpdateList(), vessel.Id);
                if (result != 1)
                    Error = new Exception("Row was NOT updated.");
            }
            catch (Exception ex) { Error = ex; }
        }

        public void DeleteVessel(int id)
        {
            try
            {
                int result = Context.ExecuteCommand("DELETE FROM Vessels WHERE Id = {0}", id);
                if (result != 1)
                    Error = new Exception("Row was NOT deleted.");
            }
            catch (Exception ex) { Error = ex; }
        }

        #endregion

        #region Helpers

        #endregion

        #region IDisposable members

        public void Dispose()
        {
            this.Context.Dispose();
            this.Error = null;
        }

        #endregion
    }
}