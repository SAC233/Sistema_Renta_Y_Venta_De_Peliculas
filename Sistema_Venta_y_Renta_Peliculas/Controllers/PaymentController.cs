using Microsoft.AspNetCore.Mvc;
using Sistema_Venta_y_Renta_Peliculas.DAL.Entities;
using Sistema_Venta_y_Renta_Peliculas.Domain.Interfaces;
using Sistema_Venta_y_Renta_Peliculas.Domain.Services;

namespace Sistema_Venta_y_Renta_Peliculas.Controllers
{
    [Route("api/[controller]")]//Listo pero se debe crear un metodo de pago primero
    [ApiController]
    public class PaymentController : Controller
    {
        private readonly IPaymentService _paymentService;

        public PaymentController(IPaymentService paymentService)
        {
            _paymentService = paymentService;
        }

        [HttpGet, ActionName("Get")]
        [Route("GetAll")]
        public async Task<ActionResult<IEnumerable<Payment>>> GetPaymentAsync()
        {
            var payment = await _paymentService.GetPaymentAsync();

            if (payment == null || !payment.Any())
            {
                return NotFound();
            }
            return Ok(payment);
        }

        [HttpGet, ActionName("Get")]
        [Route("GetById/{id}")]
        public async Task<ActionResult<Payment>> GetPaymentByIdAsync(Guid id)
        {
            var payment = await _paymentService.GetPaymentByIdAsync(id);

            if (payment == null)
            {
                return NotFound();
            }
            return Ok(payment);
        }

        [HttpPost, ActionName("Create")]
        [Route("Create")]
        public async Task<ActionResult<Payment>> CreatePaymentAsync(Payment payment)
        {
            var newPayment = await _paymentService.CreatePaymentAsync(payment);

            if (newPayment == null) return NotFound();

            return Ok(newPayment);

        }

        [HttpPut, ActionName("Edit")]
        [Route("Edit")]
        public async Task<ActionResult<Payment>> EditPaymentAsync(Payment payment)
        {
            var editedPayment = await _paymentService.EditPaymentAsync(payment);

            if (editedPayment == null) return NotFound();

            return Ok(editedPayment);
        }

        [HttpDelete, ActionName("Delete")]
        [Route("Delete")]
        public async Task<ActionResult<Payment>> DeletePaymentAsync(Guid Id)
        {

            if (Id == Guid.Empty) return BadRequest();

            var deletedPayment = await _paymentService.DeletePaymentAsync(Id);
            if (deletedPayment == null) return NotFound();
            return Ok(deletedPayment);

        }
    }
}
