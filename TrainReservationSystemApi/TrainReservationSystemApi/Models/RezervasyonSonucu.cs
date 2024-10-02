namespace TrainReservationSystemApi.Models
{
    public class RezervasyonSonucu
    {
        public bool RezervasyonYapilabilir { get; set; }
        public List<YerlesimAyrinti> YerlesimAyrintisi { get; set; } = new List<YerlesimAyrinti> { };

        public class YerlesimAyrinti
        {
            public string VagonAdi { get; set; }
            public int KisiSayisi { get; set; }
        }
    }
}
