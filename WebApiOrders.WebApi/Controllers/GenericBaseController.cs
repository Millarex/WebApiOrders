using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebApiOrders.Application.Interfaces;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApiOrders.WebApi.Controllers
{
    [ApiController]
    public class GenericBaseController<T> : ControllerBase where T : class
    {
        private IGenericRepository<T> _repository;

        public GenericBaseController(IGenericRepository<T> repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public virtual async Task<IActionResult> GetAllAsync()
        {
            var result = await _repository.GetAllAsync();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public virtual async Task<IActionResult> GetByIdAsync(int id)
        {
            var result = await _repository.GetByIdAsync(id);

            if (result == null)
                return NotFound();

            return Ok(result);
        }

        [HttpPost]
        public virtual async Task<IActionResult> Post([FromBody] T entity)
        {
            await _repository.CreateAsync(entity);
            return CreatedAtAction(nameof(T), entity);
        }

        [HttpPut("{id}")]
        public virtual async Task<IActionResult> Update(int id, [FromBody] T entity)
        {
            var db_Entity = await _repository.GetByIdAsync(id);

            if (db_Entity == null)
                return NotFound();
            //Add validation
            await _repository.UpdateAsync(entity);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var entity = await _repository.GetByIdAsync(id);

            if (entity == null)
                return NotFound();

            await _repository.DeleteAsync(id);
            return NoContent();
        }
    }
}
