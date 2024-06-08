using Microsoft.AspNetCore.Mvc;
using Sistema_Venta_y_Renta_Peliculas.DAL.Entities;
using Sistema_Venta_y_Renta_Peliculas.Domain.Interfaces;
using Sistema_Venta_y_Renta_Peliculas.Domain.Services;

namespace Sistema_Venta_y_Renta_Peliculas.Controllers
{
    [Route("api/[controller]")]//Listo pero se necesita crear un usuario primero
    [ApiController]
    public class PayMethodController : Controller
    {
        private readonly IPayMethodService _payMethodService;

        public PayMethodController(IPayMethodService payMethodService)
        {
            _payMethodService = payMethodService;
        }

        [HttpGet, ActionName("Get")]
        [Route("GetAll")]
        public async Task<ActionResult<IEnumerable<PaymentMethod>>> GetPayMenthodAsync()
        {
            var payMethod = await _payMethodService.GetPayMenthodAsync();

            if (payMethod == null || !payMethod.Any())
            {
                return NotFound();
            }
            return Ok(payMethod);
        }

        [HttpGet, ActionName("Get")]
        [Route("GetById/{id}")]
        public async Task<ActionResult<PaymentMethod>> GetPayMethodByIdAsync(Guid id)
        {
            var payMethod = await _payMethodService.GetPayMethodByIdAsync(id);

            if (payMethod == null)
            {
                return NotFound();
            }
            return Ok(payMethod);
        }

        [HttpPost, ActionName("Create")]
        [Route("Create")]
        public async Task<ActionResult<PaymentMethod>> CreatePayMethodAsync(PaymentMethod payMeth)
        {
            var newPayMeth = await _payMethodService.CreatePayMethodAsync(payMeth);

            if (newPayMeth == null) return NotFound();

            return Ok(newPayMeth);
        }

        [HttpPut, ActionName("Edit")]
        [Route("Edit")]
        public async Task<ActionResult<PaymentMethod>> EditPayMethodAsync(PaymentMethod payMeth)
        {
            var editedPayMeth = await _payMethodService.EditPayMethodAsync(payMeth);

            if (editedPayMeth == null) return NotFound();

            return Ok(editedPayMeth);
        }

        [HttpDelete, ActionName("Delete")]
        [Route("Delete")]
        public async Task<ActionResult<Payment>> DeletePayMethodAsync(Guid id)
        {

            if (id == null) return BadRequest();

            var deletedPayMeth = await _payMethodService.DeletePayMethodAsync(id);

            if (deletedPayMeth == null) return NotFound();

            return Ok(deletedPayMeth);

        }
    }
}
