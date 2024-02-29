using System.Net;
using Microsoft.AspNetCore.Mvc;

namespace CompanyService.Controllers;

[ApiController]
[ApiVersion("1.0")]
[Route("api/v{version:apiVersion}/volo")]
public class VoloController : ControllerBase
{
    private IDatabaseService _databaseService;
    private IConversionService _conversionService;
    public VoloController(IDatabaseService databaseService, IConversionService conversionService)
    {
        _databaseService = databaseService;
        _conversionService = conversionService;
    }

    [HttpGet()]
    [ProducesResponseType(typeof(string), (int)HttpStatusCode.NotFound)]
    [ProducesResponseType(typeof(FlottaApi), (int)HttpStatusCode.OK)]

     public async Task<IActionResult> Get(long idVolo)
    {
        // Recupero le informazioni dal db     
        var volo = await _databaseService.GetVoloByID(idVolo);
        if (volo == null)
        {
            return NotFound("Non ho trovato il volo");
        }

        List<VoloApi> voli = new List<VoloApi>();
        foreach (var Volo in voli)
        {
            
        }

        // convertiamo nel modello del contratto
        var result = FlottaApi.FlottaApiFactory(flotta.FlottaId, flotta.Nome, aerei);
        return Ok(result);
    }

    // Get(long idVolo)

    // GetVoliConPostiDisponibili()

    // Post(CreateVoloRequest)

    // Delete(long idVolo)

    // Put(UpdateVoloRequest)
}
