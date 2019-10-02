using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Sales.Api.Controllers.Common;
using Sales.Application.Dtos;
using Sales.Application.Services.Interfaces;
using Sales.Domain.Entities;

namespace Sales.Api.Controllers
{
    [Route("api/[controller]")]
    public class SellerController : BaseCrudController<SellerDto, Seller>
    {
        private readonly ISellerApplication _application;

        public SellerController(
            ISellerApplication application) : base(application)
        {
            _application = application;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<SellerDto>> GetByIdAsync([FromRoute] int id)
        {
            try
            {
                return await _application.GetByIdAsync(id);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet("nameTaken/{name}/{id}")]
        public ActionResult<bool> IsNameTaken([FromRoute] string name, [FromRoute] int id)
        {
            try
            {
                return _application.IsNameTaken(new SellerDto { Name = name, Id = id });
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet("validate/delete/{id}")]
        public ActionResult<bool> ValidateDelete([FromRoute] int id)
        {
            try
            {
                return _application.ValidateDelete(id);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet("by/name/{name}")]
        public ActionResult<IEnumerable<SellerDto>> GetByName([FromRoute] string name)
        {
            try
            {
                return new ActionResult<IEnumerable<SellerDto>>(_application.GetByName(name));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}