using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WebApplication2.Controllers
{
    public class GetPlayerIDController : ApiController
    {
      
        public int Get(string name, int loginTime)
        {
            DatabaseManager dbman = new DatabaseManager();
           int playerID = dbman.GetPlayerID(name, loginTime);

            return playerID;
        }

    }
}