using System.Net;
using CompanyService;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace AirRouteAdministrator.API;

[ApiController]
[ApiVersion("1.0")]
[Route("api/v{version:apiVersion}/flotta")]
public class FlottaController : ControllerBase
{
    private IDatabaseService _databaseService;
    private IConversionService _conversionService;

    public FlottaController(IDatabaseService databaseService, IConversionService conversionService)
    {
        _databaseService = databaseService;
        _conversionService = conversionService;
    }

    [HttpGet()]
    [ProducesResponseType(typeof(string), (int)HttpStatusCode.NotFound)]
    [ProducesResponseType(typeof(FlottaApi), (int)HttpStatusCode.OK)]
    public async Task<IActionResult> Get(long idFlotta)
    {
        // Recupero le informazioni dal db     
        var flotta = await _databaseService.GetFlottaByIdFlotta(idFlotta);
        if (flotta == null)
        {
            return NotFound("Non ho trovato la flotta");
        }

        List<AereoApi> aerei = new List<AereoApi>();
        foreach (var aereo in flotta.Aerei)
        {
            var a = new AereoApi(aereo.AereoId, aereo.CodiceAereo, aereo.Colore, aereo.NumeroDiPosti);
            aerei.Add(a);
        }

        // convertiamo nel modello del contratto
        var result = FlottaApi.FlottaApiFactory(flotta.FlottaId, flotta.Nome, aerei);
        return Ok(result);
    }

    [HttpGet("GetElencoFlotte")]
    [ProducesResponseType(typeof(string), (int)HttpStatusCode.NotFound)]
    [ProducesResponseType(typeof(List<FlottaApi>), (int)HttpStatusCode.OK)]
    public async Task<IActionResult> GetElencoFlotte()
    {
        // Recupero le informazioni dal db     
        var flotte = await _databaseService.GetElencoFlotte();
        List<FlottaApi> flotteApi = new List<FlottaApi>();

        foreach (var flotta in flotte)
        {
            List<AereoApi> aerei = new List<AereoApi>();
            foreach (var aereo in flotta.Aerei)
            {
                var a = new AereoApi(aereo.AereoId, aereo.CodiceAereo, aereo.Colore, aereo.NumeroDiPosti);
                aerei.Add(a);
            }

            flotteApi.Add(FlottaApi.FlottaApiFactory(flotta.FlottaId, flotta.Nome, aerei));
        }
        return Ok(flotteApi);
    }


    [HttpPost()]
    [ProducesResponseType(typeof(long), (int)HttpStatusCode.NotFound)]
    [ProducesResponseType(typeof(FlottaApi), (int)HttpStatusCode.OK)]
    public async Task<IActionResult> Post(CreateFlottaRequest request)
    {
        // Inserimento nel database
        var flotta = await _databaseService.CreateFlotta(request.NomeFlotta);

        List<AereoApi> aerei = new List<AereoApi>();
        foreach (var aereo in flotta.Aerei)
        {
            var a = _conversionService.ConvertAereoToAereoApi(aereo);
            aerei.Add(a);
        }

        // Converto il modello di bl in quello api
        var flottaApi = _conversionService.ConvertFlottaToFlottaApi(flotta, aerei);

        // Restituisco il modello api
        return Ok(flottaApi);
    }
}
