using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WebApplication2.Controllers
{
    public class GetQuestionController : ApiController
    {
        // GET api/<controller>
        public Dictionary<string, string> Get(int id)
        {
            DatabaseManager dbman = new DatabaseManager();
            Dictionary<string, string> questionDict = dbman.GetQuestion(id);

            return questionDict;
        }

    }
}