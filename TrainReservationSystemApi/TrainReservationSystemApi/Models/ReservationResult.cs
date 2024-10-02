namespace TrainReservationSystemApi.Models
{
    public class ReservationResult
    {
        public bool ReservationAvailable { get; set; }
        public List<SettlementDetail> SettlementDetails { get; set; } = new List<SettlementDetail> { };

        public class SettlementDetail
        {
            public string WagonName { get; set; }
            public int PersonNumber { get; set; }
            public int RemainingPersonNumber { get; set; }
        }
    }
}
