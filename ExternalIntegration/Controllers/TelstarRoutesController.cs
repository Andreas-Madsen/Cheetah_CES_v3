using System;
using System.Collections.Generic;
using System.Linq;
using ExternalIntegration.Enums;
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

        private TelstarRoutes returnError(string errorMsg) 
        {
            return new TelstarRoutes {
                Price = -1,
                Time = -1,
                Error = errorMsg
            };
        }

        [HttpGet]
        public TelstarRoutes Get([FromBody] TelstarRequest telstarRequest) 
        {
            //Validation
            string errorMsg = ValidationController.verifyTelstarRequest(telstarRequest);
            if (errorMsg != null) {
                return returnError(errorMsg);
            }

            return new TelstarRoutes {
                Price = 3,
                Time = 20,
                Error = "NO_ERROR"
            };
        }
    }
}
