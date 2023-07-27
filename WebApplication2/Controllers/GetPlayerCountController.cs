using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WebApplication2.Controllers
{
    public class GetPlayerCountController : ApiController
    {
        public int Get()
        {
            DatabaseManager dbman = new DatabaseManager();
            int count = dbman.GetPlayerCount();

            return count;
        }
    }
}