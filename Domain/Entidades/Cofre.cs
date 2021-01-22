using Domain.Exceptions;
using System.Collections.Generic;
using System.Linq;

namespace Domain.Entidades
{
    public class Cofre
    {
        private IEnumerable<Cedula> Cedulas { get; set; }

        public Cofre(IEnumerable<Cedula> cedulas)
        {
            Cedulas = cedulas;
        }

        public Cedula[] CedulasDisponiveis()
        {
            return Cedulas.OrderByDescending(c => c.Valor).Distinct().ToArray();
        }

        public bool PossuiCedula(Cedula cedula)
        {
            return Cedulas.Any(c => c.Valor == cedula.Valor);
        }

        public Cedula PegaCedula(Cedula cedula)
        {
            if (PossuiCedula(cedula))
            {
                var cedulas = Cedulas.ToList();
                cedulas.Remove(cedula);
                Cedulas = cedulas;
                return cedula;
            }

            throw new CedulaEmFaltaException();
        }
    }
}
