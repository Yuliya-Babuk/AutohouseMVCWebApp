using AppAutohouse.BLL;
using AppAutohouse.PL.Models;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AppAutohouse.PL
{
    public class RequestController : Controller

    {
        private readonly IRequestService _requestService;
        private readonly IMapper _mapper;

        public RequestController(IRequestService requestService, IMapper mapper)
        {
            _requestService = requestService;
            _mapper = mapper;
        }

        [Route("requests")]
        public IActionResult Requests()
        {
            var res = _requestService.GetAll();
            return View(_mapper.Map<IEnumerable<RequestModel>>(_requestService.GetAll()));
        }

        [HttpGet]
        [Route("confirmed-requests")]
        public IActionResult ConfirmedRequests()
        {
            return View(_mapper.Map<IEnumerable<RequestModel>>(_requestService.GetAllConfirmed()));
        }
        [HttpPost]
        public async Task<IActionResult> ConfirmRequestAsync(int id)
        {
           await _requestService.ConfirmAsync(id);
            
            return RedirectToAction("Requests");
        }

        [HttpGet]
        [Route("declined-requests")]
        public IActionResult DeclinedRequests()
        {
            return View(_mapper.Map<IEnumerable<RequestModel>>(_requestService.GetAllDeclined()));
        }
        [HttpPost]
        public async Task<IActionResult> DeclineRequestAsync(int id)
        {
            await _requestService.DeclineAsync(id);
            var e = await _requestService.GetByIdAsync(id);
            return RedirectToAction("Requests");
        }
    }
}
