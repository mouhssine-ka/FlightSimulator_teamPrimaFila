using System.Net;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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
    [ProducesResponseType(typeof(VoloApi), (int)HttpStatusCode.OK)]

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
            VoloApi a = new VoloApi(volo.VoloId, volo.Aereo, volo.PostiRimanenti,
        volo.CostoDelPosto, volo.CittaPartenza, volo.CittaArrivo, volo.OrarioPartenza, volo.OrarioArrivo, Volo.Biglietti);
            voli.Add(a);
        }

        // convertiamo nel modello del contratto
        var result = new VoloApi(volo.VoloId, volo.Aereo, volo.PostiRimanenti, volo.CostoDelPosto,
        volo.CittaPartenza, volo.CittaArrivo, volo.OrarioArrivo, volo.OrarioArrivo, volo.Biglietti);
        return Ok(result);
    }

    [HttpGet("GetVoliConPostiDisponibili")]
    [ProducesResponseType(typeof(string), (int)HttpStatusCode.NotFound)]
    [ProducesResponseType(typeof(VoloApi), (int)HttpStatusCode.OK)]

    public async Task<IActionResult> GetVoliConPostiDisponibili()
    {
        // Recupero le informazioni dal db     
        var Voli = await _databaseService.GetElencoVoli();
        var voliConPostiDisponibili = new List<VoloApi>();
        foreach (var volo in Voli)
        {
            if (volo.PostiRimanenti > 0)
            {
                var result = new VoloApi(volo.VoloId, volo.Aereo, volo.PostiRimanenti, volo.CostoDelPosto,
                volo.CittaPartenza, volo.CittaArrivo, volo.OrarioArrivo, volo.OrarioArrivo, volo.Biglietti);
                voliConPostiDisponibili.Add(result);
            }
        }
        return Ok(voliConPostiDisponibili);

    }

    [HttpPost()]
    [ProducesResponseType(typeof(long), (int)HttpStatusCode.NotFound)]
    [ProducesResponseType(typeof(VoloApi), (int)HttpStatusCode.OK)]
    public async Task<IActionResult> Post(CreateVoloRequest request)
    {
        var voloRequest = await _databaseService.AddVolo(request.AereoId, request.CostoDelPosto,
        request.CittaPartenza, request.CittaArrivo, request.OrarioPartenza, request.OrarioArrivo);

        //controllo che l'input del costo sia un numero valido
        if (voloRequest == null)
        {
            return BadRequest("Aereo non trovato !");
        }
        if (request.CostoDelPosto <= 0)
        {
            return BadRequest("Costo del Posto non valido !");
        }
        
        else
        return Ok(voloRequest);
        
    }

    [HttpDelete()]
    [ProducesResponseType(typeof(long), (int)HttpStatusCode.NotFound)]
    [ProducesResponseType(typeof(VoloApi), (int)HttpStatusCode.OK)]
    public async Task<IActionResult> Delete(long idVolo)
    {
        var volo = await _databaseService.GetVoloByID(idVolo);
        if (volo == null)
        {
            return NotFound("Volo non Presente !");
        }
        await _databaseService.DeleteVoloByID(volo.VoloId);
        return Ok();
    }

    [HttpPut()]
    [ProducesResponseType(typeof(long), (int)HttpStatusCode.NotFound)]
    [ProducesResponseType(typeof(VoloApi), (int)HttpStatusCode.OK)]
    public async Task<IActionResult> Put(UpdateVoloRequest request)
    {
        // Recupero le informazioni dal db     
        var volo = await _databaseService.GetVoloByID(request.VoloId);
        if (volo == null)
        {
            return NotFound("Volo non Presente !");
        }
        if (request.CostoDelPosto <= 0)
        {
            return BadRequest("Costo del Posto non valido !");
        }
        if(request.Posti>volo.Aereo.NumeroDiPosti)
        {
            return BadRequest("Numero di posti non valido !");
        }

        var voloAggiornato = await _databaseService.UpdateVoloById(request);

        // Restituisco il modello api
        return Ok(voloAggiornato);

    }
}
