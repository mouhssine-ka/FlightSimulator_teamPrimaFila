﻿using System.Net;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Server.HttpSys;

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
        biglietto.PostiDaPrenotare, biglietto.ImportoTotale, biglietto.DataAcquisto);

        return Ok(result);
    }

    // GetBigliettiByVoloId(long idVolo)
    [HttpGet("GetBigliettiByVolo")]
    [ProducesResponseType(typeof(string), (int)HttpStatusCode.NotFound)]
    [ProducesResponseType(typeof(List<BigliettoApi>), (int)HttpStatusCode.OK)]
    public async Task<IActionResult> GetBigliettiByVolo(long idVolo)
    {
        List<BigliettoApi> BigliettiPerVolo = new List<BigliettoApi>();
    
        // Recupero le informazioni dal db     
        var Biglietti = await _databaseService.GetElencoBiglietti();

        if (Biglietti == null)
        {
            return NotFound("NON E' STATO TROVATO NESSUNO BIGLIETTO");
        }

        foreach(var biglietto in Biglietti)
        {
        // convertiamo nel modello del contratto
            var bigliettoVolo = new BigliettoApi(biglietto.BigliettoId, biglietto.Volo,
            biglietto.PostiDaPrenotare, biglietto.ImportoTotale, biglietto.DataAcquisto);

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
        List<Volo> voli = await _databaseService.GetElencoVoli();

        if(voli == null){
            return BadRequest("Non è stato trovato nessun volo");
        }

        Volo? volo = voli.FirstOrDefault(x => x.VoloId == request.IdVolo);

        if(volo == null){
            return BadRequest("Non è presente nessun volo con l'id " + request.IdVolo);
        }

        if((volo.PostiRimanenti - request.PostiDaPrenotare) < 0){
            return BadRequest("Il numero posti da prenotare non è disponibile");
        }

        volo.PostiRimanenti = volo.PostiRimanenti - request.PostiDaPrenotare;

        decimal importoTotale = request.PostiDaPrenotare * volo.CostoDelPosto;
        var biglietto = new Biglietto(volo, request.PostiDaPrenotare, importoTotale, DateTime.Now);

        await _databaseService.AddBiglietto(volo, request.PostiDaPrenotare);
        
        // Restituisco il modello api
        return Ok(biglietto);
    }


    // Delete(long idBiglietto)
    [HttpDelete()]
    [ProducesResponseType(typeof(long), (int)HttpStatusCode.NotFound)]
    [ProducesResponseType(typeof(HttpStatusCode), (int)HttpStatusCode.OK)]
    public async Task<IActionResult> Delete(long idBiglietto)
    {
        // Recupero le informazioni dal db     
        var biglietto = await _databaseService.GetBigliettoByID(idBiglietto);
        if (biglietto == null)
        {
            return NotFound("NON E' STATO TROVATO NESSUNO BIGLIETTO");
        }
        await _databaseService.DeleteBigliettoByID(idBiglietto);
        return Ok();
    }
}
