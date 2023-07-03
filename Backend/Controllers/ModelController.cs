using Data.Interfaces;
using Data.Model;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ModelController : ControllerBase
    {
        readonly IBussinessUnitOfWork unitOfWork;

        public ModelController(IBussinessUnitOfWork bussinessUnitOfWork)
        {
            this.unitOfWork = bussinessUnitOfWork;
        }

        [HttpGet]
        public async Task<IEnumerable<Model>> Get()
        {
            return await unitOfWork.Models.GetAll();
        }

        [HttpGet("single/{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var model = await unitOfWork.Models.Get(id);
            if (model == null) return NotFound();
            else return Ok(model);
        }

        [HttpPost]
        public async Task<IActionResult> Post(Model model)
        {
            try
            {
                await unitOfWork.Models.Add(model);
                await unitOfWork.Complete();
                return Created(HttpContext.Request.Path, model);
            }
            catch (Exception ex)
            {
                return BadRequest(new
                {
                    Message = $"No se ha podido agregar el modelo para el producto {model.ProductId}",
                    Exception = ex.InnerException?.Message ?? ex.Message
                });
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, Model newValues)
        {
            try
            {
                var model = await unitOfWork.Models.Get(id);

                if (model == null) return NotFound();

                model.InStock = newValues.InStock;
                model.Price = newValues.Price;
                model.Color = newValues.Color;
                model.Description = newValues.Description;
                await unitOfWork.Complete();

                return Created(HttpContext.Request.Path, model);
            }
            catch (Exception ex)
            {
                return BadRequest(new
                {
                    Message = $"No se ha podido modificar el modelo con id: {id}",
                    Exception = ex.InnerException?.Message ?? ex.Message
                });
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await unitOfWork.Models.Remove(id);
                await unitOfWork.Complete();
                return Ok(id);
            }
            catch (Exception ex)
            {
                return BadRequest(new
                {
                    Message = $"No se ha podido eliminar el modelo con id: {id}",
                    Exception = ex.InnerException?.Message ?? ex.Message
                });
            }
        }
    }
}
