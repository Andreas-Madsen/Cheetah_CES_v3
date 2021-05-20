using ExternalIntegration.Validations;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace ExternalIntegration.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TelstarRoutesController : ControllerBase
    {
        private readonly ILogger<TelstarRoutesController> _logger;

        public TelstarRoutesController(ILogger<TelstarRoutesController> logger)
        {
            _logger = logger;
        }

        private TelstarResponse returnError(string errorMsg) 
        {
            return new TelstarResponse {
                price = -1,
                time = -1,
                error = errorMsg
            };
        }

        private int GetPrice() {
            //TODO implement
            return 10;
        }

        private int GetTime() {
            //TODO implement
            return 10;
        }


        [HttpGet]
        public TelstarResponse Get([FromBody] TelstarRequest telstarRequest) 
        {
            string errorMsg = CommunicationValidation.verifyTelstarRequest(telstarRequest);
            if (errorMsg != null) {
                return returnError(errorMsg);
            }

            return new TelstarResponse {
                price = GetPrice(),
                time = GetTime(),
                error = "NO_ERROR"
            };
        }
    }
}
