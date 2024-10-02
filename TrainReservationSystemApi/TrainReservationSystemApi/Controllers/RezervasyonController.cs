using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TrainReservationSystemApi.Models;
using TrainReservationSystemApi.Services;

namespace TrainReservationSystemApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RezervasyonController : ControllerBase
    {
        private readonly IRezervasyonService _rezervasyonService;
        public RezervasyonController(IRezervasyonService rezervasyonService)
        {
            _rezervasyonService = rezervasyonService;
        }

        [HttpPost]
        public ActionResult<RezervasyonSonucu> Yap(RezervasyonTalebi talep) 
        {
            var sonuc = _rezervasyonService.RezervasyonYap(talep);
            return Ok(sonuc);
        }

    }
}
