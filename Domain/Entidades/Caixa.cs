using Domain.Exceptions;
using System.Collections.Generic;
using System.Linq;

namespace Domain.Entidades
{
    public class Caixa
    {
        private Cofre Cofre { get; set; }

        public Caixa(IEnumerable<Cedula> cedulas)
        {
            Cofre = new Cofre(cedulas);
        }

        public IEnumerable<Cedula> Saca(int valorSaque)
        {
            var saque = new Saque(valorSaque);

            while (!saque.Concluido())
            {
                var cedulasDisponiveis = Cofre.CedulasDisponiveis();

                if (cedulasDisponiveis.Length == 0)
                    throw new CofreVazioException();

                foreach (var cedula in cedulasDisponiveis)
                {
                    if ((saque.Total + cedula.Valor) <= valorSaque)
                    {
                        saque.AdicionaCedula(Cofre.PegaCedula(cedula));
                        break;
                    }
                }
            }

            return saque.Cedulas;
        }
    }
}