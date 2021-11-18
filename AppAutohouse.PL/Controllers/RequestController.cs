using AppAutohouse.BLL;
using AppAutohouse.BLL.Services;
using AppAutohouse.PL.Models;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MVCAppAutohouse.DAL.Entities;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace AppAutohouse.PL
{
    public class RequestController : Controller

    {
        private readonly IRequestService _requestService;
        private readonly IMapper _mapper;
        private const int itemsPerPage = 3;

        public RequestController(IRequestService requestService, IMapper mapper)
        {
            _requestService = requestService;
            _mapper = mapper;
        }

        [Route("requests/{pageNumber?}")]
        public IActionResult Requests(int pageNumber = 1)
        {
            ViewBag.CurrentPage = pageNumber;
            var (requests, itemsAmount) = _requestService.GetAll(pageNumber, itemsPerPage);
            (IEnumerable<Request> requests, int pagesAmount) result = (requests, PaginationService.PagesAmountCalculation(itemsAmount, itemsPerPage));
            return View(_mapper.Map<(IEnumerable<RequestModel>,int)>(result));
        }

        [HttpGet]
        [Route("confirmed-requests/{pageNumber?}")]
        public IActionResult ConfirmedRequests(int pageNumber = 1)
        {
            ViewBag.CurrentPage = pageNumber;
            var (requests, itemsAmount) = _requestService.GetAllConfirmed(pageNumber, itemsPerPage);
            (IEnumerable<Request> requests, int pagesAmount) result = (requests, PaginationService.PagesAmountCalculation(itemsAmount, itemsPerPage));
            return View(_mapper.Map<(IEnumerable<RequestModel>,int)>(result));
        }
        [HttpPost]
        public async Task<IActionResult> ConfirmRequestAsync(int id)
        {
           await _requestService.ConfirmAsync(id);
            
            return RedirectToAction("ConfirmedRequests");
        }

        [HttpGet]
        [Route("declined-requests/{pageNumber?}")]
        public IActionResult DeclinedRequests(int pageNumber = 1)
        {
            ViewBag.CurrentPage = pageNumber;
            var (requests, itemsAmount) = _requestService.GetAllDeclined(pageNumber, itemsPerPage);
            (IEnumerable<Request> requests, int pagesAmount) result = (requests, PaginationService.PagesAmountCalculation(itemsAmount, itemsPerPage));
            return View(_mapper.Map<(IEnumerable<RequestModel>,int)>(result));
        }
        [HttpPost]
        public async Task<IActionResult> DeclineRequestAsync(int id)
        {
            await _requestService.DeclineAsync(id);          
            return RedirectToAction("DeclinedRequests");
        }
        [HttpGet("download")]
        public IActionResult Download()
        {
            Stream content = _requestService.GetCsvContent();
            var contentType = "text/plain";
            var fileName = "Requests.csv";
            return File(content, contentType, fileName);
        }
    }
}
