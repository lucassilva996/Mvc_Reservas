using System.Collections.Generic;

namespace ApiReservas.Models
{
    public class Repository : IRepository
    {
        private Dictionary<int, Reserva> items;

        public Repository()
        {
            items = new Dictionary<int, Reserva>();
            new List<Reserva> { 
                new Reserva {ReservaId=1, Nome = "Lucas", InicioLocacao = "São Paulo", FimLocacao="Rio de Janeiro" },
                new Reserva {ReservaId=2, Nome = "Dani", InicioLocacao = "Campinas", FimLocacao="São Paulo" },
                new Reserva {ReservaId=3, Nome = "Tiago", InicioLocacao = "Jundiaí", FimLocacao="Campinas" },
                new Reserva {ReservaId=4, Nome = "Malu", InicioLocacao = "Jundiaí", FimLocacao="Campinas" },
                new Reserva {ReservaId=5, Nome = "Kinder", InicioLocacao = "Jundiaí", FimLocacao="Campinas" },
                new Reserva {ReservaId=6, Nome = "Paçoca", InicioLocacao = "Jundiaí", FimLocacao="Campinas" },
                new Reserva {ReservaId=7, Nome = "Tica", InicioLocacao = "Jundiaí", FimLocacao="Campinas" },
                new Reserva {ReservaId=8, Nome = "Thor", InicioLocacao = "Jundiaí", FimLocacao="Campinas" },
                new Reserva {ReservaId=9, Nome = "Lays", InicioLocacao = "Jundiaí", FimLocacao="Campinas" },
                new Reserva {ReservaId=10, Nome = "Cafu", InicioLocacao = "Jundiaí", FimLocacao="Campinas" }
                }.ForEach(r => AddReserva(r));
        }

        public Reserva this[int id] => items.ContainsKey(id) ? items[id] : null;

        public IEnumerable<Reserva> Reservas => items.Values;

        public Reserva AddReserva(Reserva reserva)
        {
            if (reserva.ReservaId == 0)
            {
                int key = items.Count;
                while (items.ContainsKey(key)) { key++; };
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
