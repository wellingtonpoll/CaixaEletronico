using System;

namespace Domain.Exceptions
{
    public class CofreVazioException : Exception
    {
        public CofreVazioException()
            : base ("Cofre vazio")
        {

        }
    }
}
