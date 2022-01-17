using Backend.Domain.Entities;
using Backend.Domain.Exceptions;
using Backend.Infrastructure.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers
{
    [Controller]
    [Route("v1/products")]
    public class ProductController : ControllerBase
    {
        private readonly IProductRepository _productRepository;

        public ProductController(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        [HttpGet("getall")]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                return Ok(await _productRepository.GetAllAsync());
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Message = ex.Message, Status = "Failure" });
            }
        }

        [HttpGet("byid/{id:int}")]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                return Ok(await _productRepository.GetByIdAsync(id));
            }
            catch (ProductException ex)
            {
                return BadRequest(new { Message = ex.Message, Status = "Failure" });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Message = ex.Message, Status = "Failure" });
            }
        }

        [HttpPost("create")]
        public async Task<IActionResult> Create([FromBody] Product model)
        {
            try
            {
                if (!ModelState.IsValid) return BadRequest(ModelState);

                await _productRepository.SaveAsync(model);

                return Ok();
            }
            catch (ProductException ex)
            {
                return BadRequest(new { Message = ex.Message, Status = "Failure" });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Message = ex.Message, Status = "Failure" });
            }
        }


        [HttpPut("update/{id:int}")]
        public async Task<IActionResult> Update([FromBody] Product model, int id)
        {
            try
            {
                if (!ModelState.IsValid) return BadRequest(ModelState);

                await _productRepository.UpdateAsync(id, model);

                return Ok();
            }
            catch (ProductException ex)
            {
                return BadRequest(new { Message = ex.Message, Status = "Failure" });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Message = ex.Message, Status = "Failure" });
            }
        }

        [HttpDelete("delete/{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await _productRepository.DeleteAsync(id);

                return Ok();
            }
            catch (ProductException ex)
            {
                return BadRequest(new { Message = ex.Message, Status = "Failure" });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Message = ex.Message, Status = "Failure" });
            }
        }
    }
}
