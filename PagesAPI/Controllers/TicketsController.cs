using Microsoft.AspNetCore.Mvc;
using ParcialAPI.DAL.Entities;
using Newtonsoft.Json;
using System.Net.Http;

namespace PagesAPI.Controllers
{
    public class TicketsController : Controller
    {

        private readonly IHttpClientFactory _HttpClient;
        private readonly IConfiguration _Configuration;

        public TicketsController(IHttpClientFactory HttpClient, IConfiguration Configuration)
        {
            _HttpClient = HttpClient;
            _Configuration = Configuration;
        }


        [HttpGet]
        public async Task<IActionResult> Index()
        {

            return View();

        }


        [HttpGet]
        public async Task<ActionResult> Verificar(Guid id)
        {

            var url = "https://localhost:7173/api/Tickets/Get/895645fe-2b9f-4de4-34e7-08db5a44ff83";
            var json = await _HttpClient.CreateClient().GetStringAsync(url);
            Ticket tickets = JsonConvert.DeserializeObject<Ticket>(json);



            if (tickets != null)
            {
                if (tickets.isUsed == false)
                {
                    return View();
                }
            }
            return NotFound();



        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Verificar(Guid id, Ticket ticket)
        {

            var url = "https://localhost:7173/api/Tickets/Get/895645fe-2b9f-4de4-34e7-08db5a44ff83";
            await _HttpClient.CreateClient().PutAsJsonAsync(url, ticket);

            return RedirectToAction("index");



        }






    }


    
}
