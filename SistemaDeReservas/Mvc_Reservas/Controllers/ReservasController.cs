using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Mvc_Reservas.Models;
using Newtonsoft.Json;

namespace Mvc_Reservas.Controllers
{
    public class ReservasController : Controller
    {
        private readonly string apiUrl = " https://localhost:44311/api/reservas";

        public async Task<IActionResult> Index()
        {
            List<Reserva> listaReservas = new List<Reserva>();
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

        public ViewResult GetReserva() => View();

        [HttpPost]
        public async Task<IActionResult> GetReserva(int id)
        {
            Reserva reserva = new Reserva();
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync(apiUrl + "/" + id))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    reserva = JsonConvert.DeserializeObject<Reserva>(apiResponse);
                }
            }
            return View(reserva);
        }

        public ViewResult AddReserva() => View();

        [HttpPost]
        public async Task<IActionResult> AddReserva(Reserva reserva)
        {
            Reserva reservaRecebida = new Reserva();

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

        [HttpGet]
        public async Task<IActionResult> UpdateReserva(int id)
        {
            Reserva reserva = new Reserva();
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync(apiUrl + "/" + id))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    reserva = JsonConvert.DeserializeObject<Reserva>(apiResponse);
                }
            }
            return View(reserva);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateReserva(Reserva reserva)
        {
            Reserva reservaRecebida = new Reserva();

            using (var httpClient = new HttpClient())
            {
                var content = new MultipartFormDataContent();

                content.Add(new StringContent(reserva.ReservaId.ToString()), "ReservaId");
                content.Add(new StringContent(reserva.Nome), "Nome");
                content.Add(new StringContent(reserva.InicioLocacao), "InicioLocacao");
                content.Add(new StringContent(reserva.FimLocacao), "FimLocacao");

                //content.Add(new StringContent(JsonConvert.SerializeObject(reserva)));

                using (var response = await httpClient.PutAsync(apiUrl, content))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    ViewBag.Result = "Sucesso";
                    reservaRecebida = JsonConvert.DeserializeObject<Reserva>(apiResponse);
                }
            }
            return View(reservaRecebida);
        }

        [HttpPost]
        public async Task<IActionResult> DeleteReserva(int ReservaId)
        {
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.DeleteAsync(apiUrl + "/" + ReservaId))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                }
            }
            return RedirectToAction("Index");
        }
    }
}