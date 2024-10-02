namespace TrainReservationSystemApi.Models
{
    public class ReservationRequest
    {
        public Train Train { get; set; }
        public int NumberOfPeopleToBook { get; set; }
        public bool PersonsCanBeAccommodatedInDifferentWagons { get; set; }
    }
}
