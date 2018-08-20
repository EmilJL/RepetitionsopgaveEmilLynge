using System;
using System.Collections.Generic;
using System.Data;

using System.Linq;
using System.Text;
using System.Threading.Tasks;
using joyride.Entities;


namespace joyride.DataAccess
{
    public class DBHandler
    {
        CommonDB cDB;
        DBHandler(CommonDB cDB)
        {
            this.cDB = cDB;
        }

        private string query;
        List<Report> reports;

        public List<Report> GetAllReports()
        {
            query = $"SELECT * FROM Reports";
            var data = cDB.ExecuteQuery(query);

            return data.Tables[0].AsEnumerable().Select(dataRow => new Report
            {
                Id = dataRow.Field<int>("Id"),
                /* insert ride */
                Status = (StatusOptions)System.Enum.Parse(typeof(StatusOptions), dataRow.Field<string>("Status")),
                ReportTime = dataRow.Field<DateTime>("ReportTime"),
                Notes = dataRow.Field<string>("Notes")
            }).ToList();
        }
        public List<Ride> GetAllRides()
        {
            query = $"SELECT * FROM Rides";
            var data = cDB.ExecuteQuery(query);

            return data.Tables[0].AsEnumerable().Select(dataRow => new Ride
            {
                Id = dataRow.Field<int>("Id"),
                Name = dataRow.Field<string>("Name"),
                Category = (CategoryOptions)System.Enum.Parse(typeof(CategoryOptions), dataRow.Field<string>("Category")),
                Status = (StatusOptions)System.Enum.Parse(typeof(StatusOptions), dataRow.Field<string>("Status")),
                Reports = GetReportsForRide(dataRow.Field<int>("Id"))
            }).ToList();
        }
        public Ride GetRide(int id)
        {
            query = $"SELECT * FROM Rides WHERE Id = '{id}'";
            var data = cDB.ExecuteQuery(query);

            int rideId = data.Tables[0].Rows[0].Field<int>("Id");

            List<Report> reports = new List<Report>();

            return new Ride(rideId, data.Tables[0].Rows[0].Field<string>("Name"), (CategoryOptions)System.Enum.Parse(typeof(CategoryOptions), data.Tables[0].Rows[0].Field<string>("Category")), (StatusOptions)System.Enum.Parse(typeof(StatusOptions), data.Tables[0].Rows[0].Field<string>("Status")), GetReportsForRide(rideId));
        }
        public List<Report> GetReportsForRide(int id)
        {
            query = $"SELECT * FROM Reports WHERE RideId = '{id}'";
            var data = cDB.ExecuteQuery(query);

            Ride theRide = GetRide(id);

            return data.Tables[0].AsEnumerable().Select(dataRow => new Report
            {
                Id = dataRow.Field<int>("Id"),
                RideReportedOn = theRide,
                Status = (StatusOptions)System.Enum.Parse(typeof(StatusOptions), dataRow.Field<string>("Status")),
                ReportTime = dataRow.Field<DateTime>("ReportTime"),
                Notes = dataRow.Field<string>("Notes")
            }).ToList();
        }
        public Report GetReport(int id)
        {
            query = $"SELECT * FROM Reports WHERE Id = {id}";
            var data = cDB.ExecuteQuery(query);

            return new Report(id, GetRide(data.Tables[0].Rows[0].Field<int>("RideId")), (StatusOptions)System.Enum.Parse(typeof(StatusOptions), data.Tables[0].Rows[0].Field<string>("Status")), data.Tables[0].Rows[0].Field<DateTime>("ReportTime"), data.Tables[0].Rows[0].Field<string>("Notes"));
        }
    }
}
