
namespace Mvc_Reservas.Controllers
{
    public class ReservasController
    {
        private readonly string apiUrl = " https://localhost:44311/api/reservas";

        public async Task<IActionResult> Index(){
            List<Reserva> listaReservas = new List<Reserva>();

            using(var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync(apiUrl))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    listaReservas = JsonConvert.DeserializeObject<List<ReservasController>>(apiResponse);
                }
            }
            return View(listaReservas);
        }
    }
}