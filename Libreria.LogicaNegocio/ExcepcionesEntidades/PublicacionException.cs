using System.Runtime.Serialization;

namespace Libreria.LogicaNegocio.ExcepcionesEntidades
{
    [Serializable]
    internal class PublicacionException : Exception
    {
        public PublicacionException()
        {
        }

        public PublicacionException(string? message) : base(message)
        {
        }

        public PublicacionException(string? message, Exception? innerException) : base(message, innerException)
        {
        }

       
    }
}