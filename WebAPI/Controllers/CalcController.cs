using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CalcController : ControllerBase
    {
        [HttpGet]
        public int Add(int a, int b)
        {
            return a + b;
        }

        [HttpGet]
        public int Reduce(int a, int b)
        {
            return a - b;
        }
    }
}
