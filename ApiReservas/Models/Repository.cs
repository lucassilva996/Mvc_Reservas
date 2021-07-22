using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiReservas.Models
{
    public class Repository : IRepository
    {
        private Dictionary<int, Reserva> items;
        public Reserva this[int id] => throw new NotImplementedException();

        public Repository()
        {
            items = new Dictionary<int, Reserva>();

            new List<Reserva>
            {
                new Reserva {ReservaId=1, Nome="Lucas", InicioLocacao = "Sao Paulo", FimLocacao = "Guarulhos" },
                new Reserva {ReservaId=2, Nome="Dani", InicioLocacao = "Sao Paulo", FimLocacao = "Suzano" },
                new Reserva {ReservaId=3, Nome="Tiago", InicioLocacao = "Sao Paulo", FimLocacao = "Itaquá" },
            }.ForEach(r => AddReserva(r));
        }

        public IEnumerable<Reserva> Reservas => items.Values;

        public Reserva AddReserva(Reserva reserva)
        {
            if(reserva.ReservaId == 0)
            {
                int key = items.Count;
                while(items.ContainsKey(key)) { key++; };
                reserva.ReservaId = key;
            }
            items[reserva.ReservaId] = reserva;
            return reserva;
        }

        public void DeleteReserva(int id)
        {
            items.Remove(id);
        }

        public Reserva UpdateReserva(Reserva reserva)
        {
            AddReserva(reserva);
            return reserva;
        }
    }
}
