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
    public class ProductController : BaseCrudController<ProductDto, Product>
    {
        private readonly IProductApplication _productApplication;

        public ProductController(
            IProductApplication application) : base(application)
        {
            _productApplication = application;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ProductDto>> GetByIdAsync([FromRoute] int id)
        {
            try
            {
                return await _productApplication.GetByIdAsync(id);
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
                return _productApplication.IsNameTaken(new ProductDto{Name =  name, Id = id});
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
                return _productApplication.ValidateDelete(id);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet("by/name/{name}")]
        public ActionResult<IEnumerable<ProductDto>> GetByName([FromRoute] string name)
        {
            try
            {
                return new ActionResult<IEnumerable<ProductDto>>(_productApplication.GetByName(name));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}