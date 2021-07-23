using Microsoft.AspNetCore.Mvc;
using mvc_reservas.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace mvc_reservas.Controllers
{
    public class ReservasController : Controller
    {
        private readonly string apiUrl = " https://localhost:44311/api/reservas";

        public async Task<IActionResult> Index()
        {
            List<Reserva> listaReservas = new List<Reserva>();
            try
            {
                using (var httpClient = new HttpClient())
                {
                    using (var response = await httpClient.GetAsync(apiUrl))
                    {
                        string apiResponse = await response.Content.ReadAsStringAsync();
                        listaReservas = JsonConvert.DeserializeObject<List<Reserva>>(apiResponse);
                    }
                }
                return View(listaReservas);
            }
            catch (Exception ex)
            {
                throw new ArgumentOutOfRangeException("Erro inesperado!", ex);
            }
            
        }

        public ViewResult GetReserva() => View();
        [HttpPost]
        public async Task <IActionResult> GetReserva(int id)
        {
            Reserva reserva = new Reserva();

            try
            {

                using (var httpClient = new HttpClient())
                {
                    using(var response = await httpClient.GetAsync(apiUrl + "/" + id))
                    {
                        string apiResponse = await response.Content.ReadAsStringAsync();
                        reserva = JsonConvert.DeserializeObject<Reserva>(apiResponse);
                    }
                }
                return View(reserva);
            }
            catch (Exception ex)
            {
                throw new ArgumentOutOfRangeException("Erro inesperado!", ex);
            }
        }

        public ViewResult AddReserva() => View();
        [HttpPost]
        public async Task<IActionResult> AddReserva(Reserva reserva)
        {
            Reserva reservaRecebida = new Reserva();

            try
            {

                using (var httpClient = new HttpClient())
                {
                    StringContent content = new StringContent(JsonConvert.SerializeObject(reserva),
                        Encoding.UTF8, "application/json");
                    using (var response = await httpClient.PostAsync(apiUrl, content))
                    {
                        string apiResponse = await response.Content.ReadAsStringAsync();
                        reservaRecebida = JsonConvert.DeserializeObject<Reserva>(apiResponse);
                    }
                }
                return View(reservaRecebida);
            }
            catch (Exception ex)
            {
                throw new ArgumentOutOfRangeException("Erro inesperado!", ex);
            }
        }
    }
}
