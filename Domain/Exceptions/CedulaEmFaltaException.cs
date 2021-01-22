using System;

namespace Domain.Exceptions
{
    public class CedulaEmFaltaException : Exception
    {
        public CedulaEmFaltaException()
            : base ("Cédula em falta")
        {

        }
    }
}
