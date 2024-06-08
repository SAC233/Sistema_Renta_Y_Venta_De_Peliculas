using Microsoft.AspNetCore.Mvc;
using Sistema_Venta_y_Renta_Peliculas.DAL.Entities;
using Sistema_Venta_y_Renta_Peliculas.Domain.Interfaces;  

namespace Sistema_Venta_y_Renta_Peliculas.Controllers
{
    [Route("api/[controller]")] //Esta es el nombre inicial de mi RUTA, URL o PATH
    [ApiController]//por que no es un controlador de tipo API
    public class BillsController : Controller
    {
        private readonly IBillService _billService; //me conecto a la interfaz, pero nunca al servicio, por temas de seguridad no se puede acceder directamente

        public BillsController(IBillService billService) //Este constructor se parametriza o sobrecarga con la dependendicia que se esta inyectando, parta poder y utilizar los metodos que hay alli
        {
            _billService = billService;
        }


        //GET
        [HttpGet, ActionName("Get")] //ActionName: Datanotation del nombre con el que quiero complementar para la ruta
        [Route("GetAll")] //Datanotation
        public async Task<ActionResult<IEnumerable<Bill>>> GetBillAsync()
        {
            var bills = await _billService.GetBillAsync(); //Esta llamando el metodo GetBillAsync y se guarda en la variable bills

            if (bills == null || !bills.Any())
            {
                return NotFound();//Que retorne un 404 si es nulo o si esta vacio con el Any negado, Any: para ver si al menos hay 1 elemento
            }
            return Ok(bills); //En caso de que si tenga facturas me retorna un 200 y la lista de facturas
        }


        //GET por ID
        [HttpGet, ActionName("Get")] //ActionName: Datanotation del nombre con el que quiero complementar para la ruta
        [Route("GetById/{id}")] //URL: api/.....,Datanotation
        public async Task<ActionResult<Bill>> GetBillByIdAsync(Guid id)
        {
            var bills = await _billService.GetBillByIdAsync(id); //Esta llamando el metodo GetBillByIdAsync y se guarda en la variable movies

            if (bills == null) //Aqui el any no funciona por que es para listas, colecciones y arreglos, y en este caso es solo 1 elemento el que me trae
            {
                return NotFound();//Estatus Code "NotFound": 404, Que retorne un 404 si es nulo o si esta vacio con el Any negado, Any: para ver si al menos hay 1 elemento
            }
            return Ok(bills); //Estatus Code "Ok": 200, En caso de que si tenga facturas me retorna un 200 y la factura
        }


        //CREATE
        [HttpPost, ActionName("Create")]
        [Route("Create")]
        public async Task<ActionResult<Bill>> CreateBillAsync(Bill bill)
        {
            try
            {
                var newBill = await _billService.CreateBillAsync(bill);
                if (newBill == null) return NotFound();//Validamos tambien que no sea nuleable
                return Ok(newBill);
            }
            catch (Exception ex) //validamos duplicidad en la excepciones
            {
                if (ex.Message.Contains("duplicate"))//Si dentro de la excepcion tengo un "Duplicate"
                    return Conflict(String.Format("{0} ya existe", bill.FullName));
                return Conflict(ex.Message);

            }
        }

    }
}
