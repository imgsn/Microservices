namespace Microservices.Web.Models
{
    public class ResponseDto
    {
        public bool IsSuccess { get; set; } = true;
        public object Result { get; set; }
        public string Message { get; set; }
        public List<string> Errors { get; set; }
    }
}
