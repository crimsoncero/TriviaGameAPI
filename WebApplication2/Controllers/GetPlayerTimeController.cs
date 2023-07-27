using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WebApplication2.Controllers
{
    public class GetPlayerTimeController : ApiController
    {
        public int Get(int playerId)
        {
            DatabaseManager dbman = new DatabaseManager();
            int time = dbman.GetPlayerTime(playerId);

            return time;
        }
    }
}