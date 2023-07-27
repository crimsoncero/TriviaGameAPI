using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WebApplication2.Controllers
{
    public class UpdatePlayerScoreController : ApiController
    {
        public void Get(int playerId, int score)
        {
            DatabaseManager dbman = new DatabaseManager();
            dbman.UpdatePlayerScore(playerId, score);
        }

    }
}