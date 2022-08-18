using System;

namespace RestaurantsApi.Exceptions
{
    public class NotFoundExceptions : Exception
    {
        public NotFoundExceptions(string message) :base(message)
        {
            
        }
    }
}
