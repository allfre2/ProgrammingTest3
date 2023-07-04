using Data.Interfaces;
using Data.Model;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        readonly IBussinessUnitOfWork unitOfWork;

        public ProductController(IBussinessUnitOfWork bussinessUnitOfWork)
        {
            this.unitOfWork = bussinessUnitOfWork;
        }

        [HttpGet]
        public async Task<IEnumerable<Product>> Get()
        {
            return await unitOfWork.Products.GetAll();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var product = await unitOfWork.Products.Get(id);
            if (product == null) return NotFound();
            else return Ok(product);
        }

        [HttpPost]
        public async Task<IActionResult> Post(Product product)
        {
            try
            {
                await unitOfWork.Products.Add(product);
                product.Guid = Guid.NewGuid();
                await unitOfWork.Complete();
                return Created(HttpContext.Request.Path, product);
            }
            catch (Exception ex)
            {
                return BadRequest(new
                {
                    Message = "No se ha podido agregar el producto",
                    Exception = ex.InnerException?.Message ?? ex.Message
                });
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, Product newValues)
        {
            try
            {
                var product = await unitOfWork.Products.Get(id);

                if (product == null) return NotFound();

                product.Name = newValues.Name;
                product.Description = newValues.Description;
                product.ImageURL = newValues.ImageURL;

                await unitOfWork.Complete();

                return Created(HttpContext.Request.Path, product);
            }
            catch (Exception ex)
            {
                return BadRequest(new
                {
                    Message = $"No se ha podido modificar el producto con id: {id}",
                    Exception = ex.InnerException?.Message ?? ex.Message
                });
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try 
            {
                await unitOfWork.Products.Remove(id);
                await unitOfWork.Complete();

                return Ok(id);
            }
            catch (Exception ex)
            {
                return BadRequest(new
                {
                    Message = $"No se ha podido eliminar el producto con id: {id}",
                    Exception = ex.InnerException?.Message ?? ex.Message
                });
            }
        }
    }
}
