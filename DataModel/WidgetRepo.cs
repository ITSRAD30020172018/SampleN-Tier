using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataModel
{
    public class WidgetRepo : Iwidget
    {
        BusinessContext ctx;
        public WidgetRepo(BusinessContext context)
        {
            ctx = context;
        }
        
        public void Add(Widget entity)
        {
            throw new NotImplementedException();
        }

        public void AddRange(IEnumerable<Widget> entities)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Widget> Find(Expression<Func<Widget, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public Widget Get(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Widget> GetAll()
        {
            return ctx.Widgets.ToList();
        }

        public void Remove(Widget entity)
        {
            throw new NotImplementedException();
        }

        public void RemoveRange(IEnumerable<Widget> entities)
        {
            throw new NotImplementedException();
        }
    }
}
