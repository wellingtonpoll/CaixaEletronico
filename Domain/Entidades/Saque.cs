using System.Collections.Generic;
using System.Linq;

namespace Domain.Entidades
{
    public class Saque
    {
        public Saque(int valor)
        {
            Valor = valor;
            Cedulas = new List<Cedula>();
        }

        public int Valor { get; private set; }
        public int Total { get { return Cedulas.Sum(c => c.Valor); } }
        public ICollection<Cedula> Cedulas { get; private set; }

        public void AdicionaCedula(Cedula cedula)
        {
            Cedulas.Add(cedula);
        }

        public bool Concluido()
        {
            return Total == Valor;
        }
    }
}
