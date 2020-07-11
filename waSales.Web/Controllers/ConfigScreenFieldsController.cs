using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using waSales.Data;
using waSales.Entities.Configuration;
using waSales.Entities.System;
using waSales.Web.Models.Configuration.ScreenField;

namespace waSales.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ConfigScreenFieldsController : ControllerBase
    {
        private readonly DbContextApp _context;

        public ConfigScreenFieldsController(DbContextApp context)
        {
            _context = context;
        }

        // GET: api/ConfigScreenFields
        [HttpGet]
        public IEnumerable<ConfigScreenField> GetConfigScreenFields()
        {
            return _context.ConfigScreenFields;
        }


    }
}