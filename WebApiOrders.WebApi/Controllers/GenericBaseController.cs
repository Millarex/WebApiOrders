using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebApiOrders.Application.Interfaces;

namespace WebApiOrders.WebApi.Controllers
{
    [ApiController]
    public class GenericBaseController<Tentity, Tdto> : ControllerBase
        where Tentity : class
        where Tdto : IDto
    {
        protected IGenericRepository<Tentity> _repository;
        protected readonly IMapper _mapper;

        public GenericBaseController(IGenericRepository<Tentity> repository, IMapper mapper)
        {
            _mapper = mapper;
            _repository = repository;
        }

        [HttpGet]
        public virtual async Task<IActionResult> GetAllAsync()
        {
            //TODO: Add Mapping for query data
            var result = await _repository.GetAllAsync();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public virtual async Task<IActionResult> GetByIdAsync(int id)
        {
            //TODO: Add Mapping for query data
            var result = await _repository.GetByIdAsync(id);

            if (result == null)
                return NotFound();

            return Ok(result);
        }

        [HttpPost]
        public virtual async Task<IActionResult> Post([FromBody] Tdto entryEntity)
        {
            var entity = _mapper.Map<Tentity>(entryEntity);
            var result = await _repository.CreateAsync(entity);
            if (result)
                return Ok();
            return BadRequest();
        }

        [HttpPut("{id}")]
        public virtual async Task<IActionResult> Update(int id, [FromBody] Tdto entryEntity)
        {
            var entity = _mapper.Map<Tentity>(entryEntity);
            var result = await _repository.UpdateAsync(id, entity);
            if (!result)
                return BadRequest();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _repository.DeleteAsync(id);
            if (!result)
                return NotFound();
            return NoContent();
        }
    }
}
