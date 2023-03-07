using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModel
{
    public class BusinessContext : DbContext
    {
        public DbSet<Widget> Widgets { get; set; }

        public BusinessContext()
            : base()
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

            var myconnectionstring = "Data Source = (localdb)\\MSSQLLocalDB; Initial Catalog = ppowell-WidgetDB";
            optionsBuilder.UseSqlServer(myconnectionstring);
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            List<Widget> widgets = new List<Widget>()
            {
                new Widget{ID=1, Cost=12.0f, Description="Widget 1"},
                new Widget{ID=2, Cost=15.0f, Description="Widget 2"},

            };
            builder.Entity<Widget>().HasData(widgets);

            List<Widget> cvs_widegts = DBHelper.Get<Widget, WidgetMap>("DataModel.CSVMapper.Widgets.csv");
            builder.Entity<Widget>().HasData(cvs_widegts);

            base.OnModelCreating(builder);
        }
    }
}
