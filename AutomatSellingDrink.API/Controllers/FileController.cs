using Microsoft.AspNetCore.Mvc;

namespace AutomatSellingDrink.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FileController: ControllerBase
    {
        [HttpPost("uploadfile")]
        public void UploadFile()
        {
            
        }
    }
}