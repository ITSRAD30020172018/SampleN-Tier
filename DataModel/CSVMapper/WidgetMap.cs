using CsvHelper.Configuration;
using DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModel
{
    public class WidgetMap : ClassMap<Widget>  
    {
        public WidgetMap()
        {
            Map(m => m.ID).Name("ID");
            Map(m => m.Description).Name("Description");
            Map(m => m.Cost).Name("Cost");

        }
    }
}
