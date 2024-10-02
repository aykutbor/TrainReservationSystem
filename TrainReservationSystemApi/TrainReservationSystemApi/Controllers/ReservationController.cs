using Microsoft.AspNetCore.Mvc;
using System.Numerics;
using TrainReservationSystemApi.Models;

namespace TrainReservationSystemApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReservationController : Controller
    {
        [HttpPost]
        public ActionResult<ReservationResult> MakeAReservation(ReservationRequest request)
        {
            var result = new ReservationResult();
            int RemainingPersonNumber = request.NumberOfPeopleToBook;

            foreach (var Wagon in request.Train.Wagons)
            {
                int NumberOfSeatsAvailable = (int)(Wagon.Capacity * 0.7) - Wagon.NumberOfFilledSeats;

                if(NumberOfSeatsAvailable > 0) 
                {
                    int PersonToBePlaced = Math.Min(RemainingPersonNumber, NumberOfSeatsAvailable);
                    result.SettlementDetails.Add(new ReservationResult.SettlementDetail 
                    {
                        WagonName = Wagon.Name,
                        RemainingPersonNumber = PersonToBePlaced,
                    });

                    RemainingPersonNumber -= PersonToBePlaced;

                    if (RemainingPersonNumber == 0)
                        break;
                }
            }
            result.ReservationAvailable = RemainingPersonNumber == 0;

            if(!request.PersonsCanBeAccommodatedInDifferentWagons && result.SettlementDetails.Count > 1)
            {
                result.ReservationAvailable = false;
                result.SettlementDetails.Clear();
            }
            return Ok(result);
        }

    }

   
}
