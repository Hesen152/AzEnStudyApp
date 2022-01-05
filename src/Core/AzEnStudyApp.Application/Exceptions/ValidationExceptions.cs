using System;

namespace AzEnStudyApp.Application.Exceptions
{
    public class ValidationExceptions:Exception

    {

        public ValidationExceptions():this("validatio Error occured")
        {
            
        }

        public ValidationExceptions(string message):base(message)
        {
                
        }

        public ValidationExceptions(Exception ex) :this(ex.Message)
        {
            
        }
    }
}