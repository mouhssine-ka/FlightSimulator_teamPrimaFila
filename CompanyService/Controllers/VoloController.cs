using System.Net;
using Microsoft.AspNetCore.Mvc;

namespace CompanyService.Controllers;

[ApiController]
[ApiVersion("1.0")]
[Route("api/v{version:apiVersion}/volo")]
public class VoloController : ControllerBase
{

    public VoloController()
    {
    }

    // Get(long idVolo)

    // GetVoliConPostiDisponibili()

    // Post(CreateVoloRequest)

    // Delete(long idVolo)

    // Put(UpdateVoloRequest)
}
