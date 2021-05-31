using System;
namespace todolistbackend.domain.Model
{
    public class ErrorDetails
    {
        public int StatusCode { get; set; }
        public string Message { get; set; }
        public override string ToString()
        {
            return $"{{ \"StatusCode\" :\"{StatusCode}\" , \"Message\": \"{Message}\"}}";
        }
    }
}
