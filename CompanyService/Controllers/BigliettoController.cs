using System.Net;
using Microsoft.AspNetCore.Mvc;

namespace CompanyService.Controllers;

[ApiController]
[ApiVersion("1.0")]
[Route("api/v{version:apiVersion}/biglietto")]
public class BigliettoController : ControllerBase
{

    public BigliettoController()
    {
    }

    // Get(long idBiglietto)

    // Post(CreateBigliettoRequest)

    // GetBigliettiByVoloId(long idVolo)

    // Delete(long idBiglietto)
}
