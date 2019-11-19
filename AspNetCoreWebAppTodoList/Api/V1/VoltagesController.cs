﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using AspNetCoreWebAppTodoList.Context;
using AspNetCoreWebAppTodoList.Model;
using Microsoft.AspNetCore.Mvc;

namespace AspNetCoreWebAppTodoList.Api.V1
{
    [ApiController]
    [ApiExplorerSettings(GroupName = "v1")]
    [Route("api/v1/voltages")]
    public class VoltagesController : Controller
    {
        private readonly IVoltageContext _context;

        public VoltagesController(IVoltageContext context)
        {
            _context = context;
            if (!_context.Any())
            {
                AddDummyData().GetAwaiter().GetResult();
            }
        }

        private async Task AddDummyData()
        {
            await _context.AddAsync(new VoltageItem
                {Timestamp = new DateTimeOffset(2019, 10, 10, 10, 10, 10, TimeSpan.FromHours(2))});
            await _context.SaveChangesAsync();
        }

        [HttpGet]
        [ProducesResponseType(typeof(List<VoltageItem>), 200)]
        public async Task<ActionResult<List<VoltageItem>>> GetAll()
        {
            return await _context.ToListAsync();
        }

        [HttpPost]
        [ProducesResponseType(201)]
        public async Task<IActionResult> Create([FromBody, Required] VoltageItem item)
        {
            await _context.AddAsync(item);
            await _context.SaveChangesAsync();

            return CreatedAtRoute("GetVoltageItem", new {id = item.Id}, item);
        }

        [HttpGet("{id}", Name = "GetVoltageItem")]
        [ProducesResponseType(typeof(VoltageItem), 200)]
        [ProducesResponseType(404)]
        public async Task<ActionResult<VoltageItem>> GetById([FromRoute]long id)
        {
            var item = await _context.FindAsync(id);
            return item ?? (ActionResult<VoltageItem>)NotFound();
        }
    }
}