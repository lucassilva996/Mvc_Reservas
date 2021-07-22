using Microsoft.AspNetCore.Mvc;
using mvc_reservas.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace mvc_reservas.Controllers
{
    public class ReservasController : Controller
    {
        private readonly string apiUrl = " https://localhost:44311/api/reservas";

        public async Task<IActionResult> Index()
        {
            List<Reserva> listaReservas = new List<Reserva>();

            using (var httpClient = new HttpClient())
            {
                using(var response = await httpClient.GetAsync(apiUrl))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    listaReservas = JsonConvert.DeserializeObject<List<Reserva>>(apiResponse);
                }
            }

            return View(listaReservas);
        }
    }
}
