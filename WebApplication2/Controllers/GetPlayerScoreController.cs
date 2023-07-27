using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WebApplication2.Controllers
{
    public class GetPlayerScoreController : ApiController
    {
        public int Get(int playerId)
        {
            DatabaseManager dbman = new DatabaseManager();
            int totalScore = dbman.GetPlayerScore(playerId);

            return totalScore;
        }
    }
}