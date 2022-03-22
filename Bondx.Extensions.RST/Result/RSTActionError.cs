namespace Bondx.Extensions.RST
{
    public class RSTActionError
    {
        public int Code { get; set; }

        public string Message { get; set; }

        public string Service { get; set; }

        public RSTActionError(int code, string message, string service = null)
        {
            Code = code;
            Message = message;
            Service = service;
        }
    }
}
