using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Sales.Application.Dtos.Common;
using Sales.Application.Services.Common;
using Sales.Domain.Entities.Common;

namespace Sales.Api.Controllers.Common
{

    public abstract class BaseCrudController<TDto,TEntity> : ControllerBase
        where TDto : BaseCrudDto
        where TEntity : BaseEntity
    {
        protected readonly ICrudApplication<TDto, TEntity> Application;

        protected BaseCrudController(ICrudApplication<TDto, TEntity> application)
        {
            Application = application;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<TDto>>> GetAllAsync()
        {
            try
            {
                return new ActionResult<IEnumerable<TDto>>(await Application.GetAllAsync());
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPost]
        public async Task<ActionResult<TDto>> AddAsync([FromBody] TDto dto)
        {

            try
            {
                return await Application.AddAsync(dto);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }

        }

        [HttpPut]
        public ActionResult<TDto> Update([FromBody] TDto dto)
        {
            
            try
            {
                return Application.Update(dto);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }

        }

        [HttpDelete("{id}")]
        public ActionResult<TDto> Delete([FromRoute] int id)
        {
            try
            {
                Application.Delete(id);
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }

        }

    }
}
