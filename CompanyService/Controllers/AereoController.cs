using System.Net;
using CompanyService;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace AirRouteAdministrator.API;

[ApiController]
[ApiVersion("1.0")]
[Route("api/v{version:apiVersion}/aereo")]
public class AereoController : ControllerBase
{
    private IDatabaseService _databaseService;

    public AereoController(IDatabaseService databaseService)
    {
        _databaseService = databaseService;
    }

    [HttpGet()]
    [ProducesResponseType(typeof(string), (int)HttpStatusCode.NotFound)]
    [ProducesResponseType(typeof(AereoApi), (int)HttpStatusCode.OK)]
    public async Task<IActionResult> Get(long idAereo)
    {
        // Recupero le informazioni dal db     
        var aereo = await _databaseService.GetAereoDaIdAereo(idAereo);
        if (aereo == null)
        {
            return NotFound("Non ho trovato l'aereo");
        }

        // convertiamo nel modello del contratto
        var result = new AereoApi(aereo.AereoId, aereo.CodiceAereo,
        aereo.Colore, aereo.NumeroDiPosti);

        return Ok(result);
    }


    [HttpPost()]
    [ProducesResponseType(typeof(long), (int)HttpStatusCode.NotFound)]
    [ProducesResponseType(typeof(AereoApi), (int)HttpStatusCode.OK)]
    public async Task<IActionResult> Post(CreateAereoRequest request)
    {
        // Verifichiamo l'esistenza della flotta
        var flotta = await _databaseService.GetFlottaByIdFlotta(request.IdFLotta);
        if (flotta == null)
        {
            return BadRequest("No ho trovato la flotta");
        }

        // Inserimento nel database
        var aereoBl = await _databaseService.AddAereoAFlotta(request.IdFLotta, request.CodiceAereo, request.Colore, request.NumeroDiPosti);

        // Converto il modello di bl in quello api
        var aereoApi = new AereoApi(aereoBl.AereoId, aereoBl.CodiceAereo, aereoBl.Colore, aereoBl.NumeroDiPosti);

        // Restituisco il modello api
        return Ok(aereoApi);
    }

    [HttpDelete()]
    [ProducesResponseType(typeof(long), (int)HttpStatusCode.NotFound)]
    [ProducesResponseType(typeof(AereoApi), (int)HttpStatusCode.OK)]
    public async Task<IActionResult> Delete(long idAereo)
    {
         // Recupero le informazioni dal db     
        var aereo = await _databaseService.GetAereoDaIdAereo(idAereo);
        if (aereo == null)
        {
            return NotFound();
        }
        await _databaseService.DeleteAereoDaIdAereo(idAereo);
        return Ok();
    }

    [HttpPut()]
    [ProducesResponseType(typeof(long), (int)HttpStatusCode.NotFound)]
    [ProducesResponseType(typeof(AereoApi), (int)HttpStatusCode.OK)]
    public async Task<IActionResult> Put(UpdateAereoRequest request)
    {
         // Recupero le informazioni dal db     
        var aereo = await _databaseService.GetAereoDaIdAereo(request.IdAereo);
        if (aereo == null)
        {
            return NotFound();
        }

        var aereoBl = await _databaseService.UpdateAereoByIdAereo(request.IdAereo, request.CodiceAereo, request.Colore, request.NumeroDiPosti);

         // Converto il modello di bl in quello api
        var aereoApi = new AereoApi(aereoBl.AereoId, aereoBl.CodiceAereo, aereoBl.Colore, aereoBl.NumeroDiPosti);

        // Restituisco il modello api
        return Ok(aereoApi);

    }
}
