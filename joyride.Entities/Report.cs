using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace joyride.Entities
{
    public class Report
    {
        private int id;
        private Ride rideReportedOn;
        private StatusOptions status;
        private DateTime reportTime;
        private string notes;
        
        public Report()
        {

        }
        public Report(int id, Ride rideReportedOn, StatusOptions status, DateTime reportTime, string notes)
        {
            Id = id;
            RideReportedOn = rideReportedOn;
            Status = status;
            ReportTime = reportTime;
            Notes = notes;
        }

        public string Notes
        {
            get { return notes; }
            set { notes = value; }
        }
        public DateTime ReportTime
        {
            get { return reportTime; }
            set { reportTime = value; }
        }
        public StatusOptions Status
        {
            get { return status; }
            set { status = value; }
        }
        public Ride RideReportedOn
        {
            get { return rideReportedOn; }
            set { rideReportedOn = value; }
        }
        public int Id
        {
            get { return id; }
            set { id = value; }
        }
    }
}
