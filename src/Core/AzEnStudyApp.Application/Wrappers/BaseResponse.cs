using System;

namespace AzEnStudyApp.Application.Wrappers
{
    public class BaseResponse
    {
        public long Id { get; set; }
        public bool Success { get; set; }
        public string Message { get; set; }
    }
}