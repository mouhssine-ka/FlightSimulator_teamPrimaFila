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
            VoloApi a = new VoloApi(volo.IdVolo,volo.Aereo,volo.PostiRimanenti,
        volo.CostoDelPosto,volo.CittaPartenza,volo.CittaArrivo,volo.OrarioPartenza,volo.OrarioArrivo,Volo.Biglietti);
            voli.Add(a);
        }

        // convertiamo nel modello del contratto
        var result = new VoloApi(volo.IdVolo,volo.Aereo,volo.PostiRimanenti,volo.CostoDelPosto,
        volo.CittaPartenza,volo.CittaArrivo,volo.OrarioArrivo,volo.OrarioArrivo,volo.Biglietti);
        return Ok(result);
    }
    [HttpGet()]
    [ProducesResponseType(typeof(string), (int)HttpStatusCode.NotFound)]
    [ProducesResponseType(typeof(VoloApi), (int)HttpStatusCode.OK)]

     public async Task<IActionResult> GetVoliConPostiDisponibili()
    {
        // Recupero le informazioni dal db     
        var Voli = await _databaseService.GetElencoVoli();
        foreach (var volo in Voli) 
        {
            if (volo.PostiRimanenti > 0)
            {
            var result = new VoloApi(volo.IdVolo,volo.Aereo,volo.PostiRimanenti,volo.CostoDelPosto,
            volo.CittaPartenza,volo.CittaArrivo,volo.OrarioArrivo,volo.OrarioArrivo,volo.Biglietti);
            return Ok(result);
            }
        }
        return Ok("Voli Terminati");

        // convertiamo nel modello del contratto
    }

    [HttpPost()]
    [ProducesResponseType(typeof(long), (int)HttpStatusCode.NotFound)]
    [ProducesResponseType(typeof(VoloApi), (int)HttpStatusCode.OK)]
    public async Task<IActionResult> Post(CreateVoloRequest request)
    {
        var voloRequest = await _databaseService.AddVolo(request.Aereo, request.PostiRimanenti, request.CostoDelPosto,
        request.CittaPartenza, request.CittaArrivo, request.OrarioPartenza, request.OrarioArrivo);

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
            return NotFound();
        }
        await _databaseService.DeleteVoloDaId(volo);
        return Ok();
    }

    [HttpPut()]
    [ProducesResponseType(typeof(long), (int)HttpStatusCode.NotFound)]
    [ProducesResponseType(typeof(VoloApi), (int)HttpStatusCode.OK)]
    public async Task<IActionResult> Put(UpdateVoloRequest request)
    {
         // Recupero le informazioni dal db     
         var volo = await _databaseService.GetVoloByID(idVolo);
        if (volo == null)
        {
            return NotFound();
        }

        var voloBl = await _databaseService.UpdateVoloRequest(request.IdAereo, request.OrarioPartenza, request.OrarioArrivo);

         // Converto il modello di bl in quello api
        var voloApi = new VoloApi(voloBl.idVolo, voloBl.aereo, voloBl.postiRimanenti, voloBl.costoDelPosto,
        voloBl.cittaPartenza, voloBl.cittaArrivo, voloBl.orarioPartenza, voloBl.orarioArrivo,voloBl.biglietti);

        // Restituisco il modello api
        return Ok(voloApi);

    }
}
