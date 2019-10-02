using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Sales.Api.Controllers.Common;
using Sales.Application.Dtos;
using Sales.Application.Services.Interfaces;
using Sales.Domain.Entities;

namespace Sales.Api.Controllers
{
    [Route("api/[controller]")]
    public class SalesController :  BaseCrudController<SalesDto, Sale>
    {
        private ISalesApplication _salesApplication { get; }

        public SalesController(
            ISalesApplication application
            ) : base(application)
        {
            _salesApplication = application;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<SalesDto>> GetByIdAsync([FromRoute] int id)
        {
            try
            {
                return await _salesApplication.GetByIdAsync(id);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet("comissions")]
        public async Task<ActionResult<List<ComissaoDto>>> Comissoes()
        {
            try
            {
                return await _salesApplication.GetComissionsAsync();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet("sales/day")]
        public async Task<ActionResult<List<SalesDto>>> SalesDay()
        {
            try
            {
                return await _salesApplication.SalesDay();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }


    }
}