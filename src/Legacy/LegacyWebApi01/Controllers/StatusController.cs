using System;
using System.Web.Http;

namespace LegacyWebApi01.Controllers
{
    [RoutePrefix("api/status")]
    public class StatusController : ApiController
    {
        [HttpGet]
        [Route("")]
        public IHttpActionResult Get()
        {
            return Ok(new
            {
                application = "LegacyWebApi1",
                status = "healthy",
                framework = ".NET Framework 4.8",
                utcTime = DateTime.UtcNow
            });
        }
    }
}
