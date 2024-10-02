using TrainReservationSystemApi.Models;

namespace TrainReservationSystemApi.Services
{
    public interface IRezervasyonService
    {
        RezervasyonSonucu RezervasyonYap(RezervasyonTalebi talep);
    }
}
