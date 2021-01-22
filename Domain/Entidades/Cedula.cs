using System.Collections.Generic;

namespace Domain.Entidades
{
    public struct Cedula
    {
        public int Valor { get; private set; }

        public Cedula(int valor)
        {
            Valor = valor;
        }

        public override string ToString()
        {
            return $"R$ {Valor},00";
        }

        public static class Factor
        {
            public static IEnumerable<Cedula> CreateMany(int valor, int index)
            {
                var cedulas = new List<Cedula>();
                for (int i = 0; i < index; i++)
                    cedulas.Add(new Cedula(valor));
                return cedulas;
            }
        }
    }
}
