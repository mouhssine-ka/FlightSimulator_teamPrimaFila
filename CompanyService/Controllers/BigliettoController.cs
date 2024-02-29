using System.Net;
using Microsoft.AspNetCore.Mvc;

namespace CompanyService.Controllers;

[ApiController]
[ApiVersion("1.0")]
[Route("api/v{version:apiVersion}/biglietto")]
public class BigliettoController : ControllerBase
{
    private IDatabaseService _databaseService;
    public BigliettoController(IDatabaseService databaseService)
    {
        _databaseService = databaseService;
    }

    // Get(long idBiglietto)
    [HttpGet()]
    [ProducesResponseType(typeof(string), (int)HttpStatusCode.NotFound)]
    [ProducesResponseType(typeof(BigliettoApi), (int)HttpStatusCode.OK)]
    public async Task<IActionResult> Get(long idBiglietto)
    {
        // Recupero le informazioni dal db     
        var biglietto = await _databaseService.GetBigliettoByID(idBiglietto);
        if (biglietto == null)
        {
            return NotFound("NON E' STATO TROVATO NESSUNO BIGLIETTO");
        }

        // convertiamo nel modello del contratto
        var result = new BigliettoApi(biglietto.BigliettoId, biglietto.Volo,
        biglietto.PostiPrenotati, biglietto.ImportoTotale, biglietto.DataAcquisto);

        return Ok(result);
    }

    // GetBigliettiByVoloId(long idVolo)
    [HttpGet()]
    [ProducesResponseType(typeof(string), (int)HttpStatusCode.NotFound)]
    [ProducesResponseType(typeof(List<BigliettoApi>), (int)HttpStatusCode.OK)]
    public async Task<IActionResult> GetBigliettiByVolo(long idVolo)
    {
        List<BigliettoApi> BigliettiPerVolo = new List<BigliettoApi>();
    
        // Recupero le informazioni dal db     
     var volo = await _databaseService.GetVoloByID(idVolo);

        if (volo == null)
        {
            return NotFound("NON E' STATO TROVATO NESSUNO BIGLIETTO");
        }

        foreach(var biglietto in volo.Biglietti)
        {
        // convertiamo nel modello del contratto
            var bigliettoVolo = new BigliettoApi(biglietto.BigliettoId, volo,
            biglietto.PostiPrenotati, biglietto.ImportoTotale, biglietto.DataAcquisto);

            BigliettiPerVolo.Add(bigliettoVolo);
        }

        // convertiamo nel modello del contratto


        return Ok(BigliettiPerVolo);
    }
  

    // Post(CreateBigliettoRequest)
    [HttpPost()]
    [ProducesResponseType(typeof(long), (int)HttpStatusCode.NotFound)]
    [ProducesResponseType(typeof(BigliettoApi), (int)HttpStatusCode.OK)]
    public async Task<IActionResult> Post(CreateBigliettoRequest request)
    {
        // Verifichiamo l'esistenza del biglietto
        var biglietto = await _databaseService.GetBigliettoByID(request.BigliettoId);
        if (biglietto == null)
        {
            return BadRequest("NON HO TROVATO NESSUN BIGLIETTO");
        }

        foreach(var b in)
        {
           // Inserimento nel database
           var bigliettoBl = await _databaseService.AddBiglietti(request.Volo, request.PostiPrenotati, request., request.); 
        }
        
        // Converto il modello di bl in quello api
        var aereoApi = new AereoApi(aereoBl.AereoId, aereoBl.CodiceAereo, aereoBl.Colore, aereoBl.NumeroDiPosti);

        // Restituisco il modello api
        return Ok(aereoApi);
    }


    // Delete(long idBiglietto)
}
