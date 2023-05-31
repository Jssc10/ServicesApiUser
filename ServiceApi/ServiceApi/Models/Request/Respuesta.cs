namespace ServiceApi.Models.Request
{
    public class Respuesta
    {
        public string respCode { get; set; } = "00";
        public string respMessage { get; set; } = "OK";
        public object data { get; set; } = default!;
    }
}
