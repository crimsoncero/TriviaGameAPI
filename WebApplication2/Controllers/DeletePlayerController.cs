using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WebApplication2.Controllers
{
    public class DeletePlayerController : ApiController
    {
        public void Get(int playerID)
        {
            DatabaseManager dbman = new DatabaseManager();
            dbman.DeletePlayer(playerID);
        }
    }
}