using System;
using AspNetCoreWebAppTodoList.Model;
using Microsoft.AspNetCore.Mvc;

namespace AspNetCoreWebAppTodoList.Api.V1
{
    [ApiController]
    [ApiExplorerSettings(GroupName = "v1")]
    [Route("api/v1/timeServer")]
    public class TimeServerController : Controller
    {
        [HttpGet]
        [ProducesResponseType(typeof(Time), 200)]
        public ActionResult<Time> Get()
        {
            var now = DateTimeOffset.UtcNow;
            
            return Ok(now);
        }
    }
}