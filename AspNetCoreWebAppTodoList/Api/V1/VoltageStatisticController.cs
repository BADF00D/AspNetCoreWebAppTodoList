using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AspNetCoreWebAppTodoList.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace AspNetCoreWebAppTodoList.Api.V1
{
    [Authorize]
    [ApiController]
    [ApiExplorerSettings(GroupName = "v1")]
    [Route("api/v1/voltageStatistics")]
    public class VoltageStatisticController : Controller
    {
        private static readonly TimeSpan _OneMinuite = TimeSpan.FromMinutes(1);


        [HttpGet]
        [ProducesResponseType(typeof(List<VoltageItem>), 200)]
        public async Task<ActionResult<List<VoltageItem>>> GetAll([FromQuery] DateTimeOffset from, [FromQuery] DateTimeOffset to, [FromQuery] TimeSpan sampleInterval)
        //public async Task<ActionResult<List<VoltageItem>>> GetAll()
        {
            //currently this list some dummy data
            //if (sampleInterval < _OneMinuite) return BadRequest("Expect sampleInterval to be at least 60 seconds");
            //if (from < to) return BadRequest("Expect parameter 'from' to be before parameter 'to'");

            var dummyData = await GenerateDummyData(from, to, sampleInterval);

            return dummyData;
        }

        private static Task<List<VoltageItem>> GenerateDummyData(DateTimeOffset @from, DateTimeOffset to, TimeSpan sampleInterval)
        {
            return Task.Run(() =>
            {
                var result = new List<VoltageItem>((int) ((to - from).TotalMinutes / sampleInterval.TotalMinutes + 1));

                const float maxVoltage = 12.8f;
                const float minVoltage = 11.4f;
                var random = new Random();

                var currentTime = @from;
                var lastVoltage = maxVoltage;
                while (currentTime < to)
                {
                    if (random.Next(5) == 0)
                    {
                        var range = lastVoltage - minVoltage;
                        lastVoltage -= (float) random.NextDouble() / 100;
                    }

                    result.Add(new VoltageItem
                    {
                        Timestamp = currentTime,
                        Value = lastVoltage,
                    });
                    currentTime += sampleInterval;
                }

                return result;
            });
        }
    }
}