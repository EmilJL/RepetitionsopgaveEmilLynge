using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace joyride.Entities
{
    public enum CategoryOptions
    {
        Vandforlstelse,
        Pendulforlystelse,
        Rutsjebane
    }
    public enum StatusOptions
    {
        Virker,
        [Description("Mangler service")]
        ManglerService,
        Nedbrud
    }

    public class Ride
    {
        private int id;
        private string name;
        private StatusOptions status;
        private CategoryOptions category;
        private List<Report> reports;

        public Ride()
        {

        }
        public Ride(int id, string name, CategoryOptions category, StatusOptions status, List<Report> reports = null)
        {
            Id = id;
            Name = name;
            Category = category;
            Status = status;
            Reports = reports;
        }

        public List<Report> Reports
        {
            get { return reports; }
            set { reports = value; }
        }
        public CategoryOptions Category
        {
            get { return category; }
            set { category = value; }
        }
        public StatusOptions Status
        {
            get { return status; }
            set { status = value; }
        }
        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        public int Id
        {
            get { return id; }
            set { id = value; }
        }
    }
}
