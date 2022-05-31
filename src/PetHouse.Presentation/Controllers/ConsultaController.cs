using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PetHouse.Services.Abstractios;
using System.Net.Mime;

namespace PetHouse.Presentation.Controllers
{
    [Authorize]
    [Route("api/consutas")]
    [ApiController]
    [Produces(MediaTypeNames.Application.Json)]
    public class ConsultaController : ControllerBase
    {
        public readonly IServiceManager _serviceManager;

        public ConsultaController(IServiceManager serviceManager)
        {
            _serviceManager = serviceManager;
        }


    }
}
