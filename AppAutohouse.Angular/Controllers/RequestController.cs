using AppAutohouse.BLL;
using Microsoft.AspNetCore.Mvc;
using MVCAppAutohouse.DAL.Entities;
using Serilog;
using System.Linq;
using System.Threading.Tasks;

namespace AppAutohouse.Angular.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RequestController : Controller
    {
        private readonly IRequestService _requestService;
        public RequestController(IRequestService requestService)
        {
            _requestService = requestService;
        }


        [HttpPost("add")]
        public async Task<IActionResult> AddAsync(Request request)
        {
            if (ModelState.IsValid)
            {
                await _requestService.AddNewAsync(request);
                Log.Information($"Request for {request.Name} {request.Surname} created");
                return Ok();
            }

            return BadRequest(ModelState.Values.SelectMany(x => x.Errors.Select(x => x.ErrorMessage)));
        }
    }
}

