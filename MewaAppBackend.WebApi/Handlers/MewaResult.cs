using Microsoft.AspNetCore.Mvc;

namespace MewaAppBackend.WebApi.Handlers
{
    public class MewaResult<T>: ActionResult
    {
        public string Message { get; set; }
        public T Response { get; set; }
        public int Code { get; set; }
    }
}
