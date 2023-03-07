using DataModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SampleWebAPI.Controllers
{
    [Route("[controller]")]
    [Authorize(Roles="Widget Manager")]
    public class Widgets : ControllerBase
    {
        private readonly Iwidget _wrepo;

        public Widgets(Iwidget repo)
        {
            _wrepo = repo;
        }
        
        [HttpGet("GetAll")]
        public IEnumerable<Widget> Get()
        {
            return _wrepo.GetAll();
        }

    }
}
